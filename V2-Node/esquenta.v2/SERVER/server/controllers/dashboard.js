var Sequelize = require('sequelize')

const Comanda = require('../models').comanda
const ItemVenda = require('../models').itemVenda
const PeriodoVenda = require('../models').periodoVenda
const Produto = require('../models').produto
const Venda = require('../models').venda

module.exports = {
  get (req, res) {
    var dashboard = {
      periodo: null,
      financeiro: 0,
      resumo: {
        vendas: 0,
        dinheiro: 0,
        itens: 0,
        comandas: 0
      },
      maisVendidos: [],
      comandas: [],
      messages: {
        title: 'Mensagens',
        header: [],
        data: [
          ['Mensagem 1'],
          ['Mensagem 2'],
          ['Mensagem 3']
        ]
      }
    }

    return periodoVenda()
      .then(data => {
        dashboard.periodo = data.dataValues
        return valorVendas(dashboard)
      })
      .then(data => {
        dashboard.resumo.dinheiro = data
        return totalItensVendidos(dashboard)
      })
      .then(data => {
        dashboard.resumo.itens = data
        return maisVendidos(dashboard)
      })
      .then(data => {
        var processed = []
        data.map(function (item) {
          processed.push([item.Produto.nome, item.quantidade])
        })
        dashboard.maisVendidos = {
          title: 'Mais Vendidos',
          header: [
            'Produto',
            'Quantidade'
          ],
          data: processed
        }
        return comandasEmAberto(dashboard)
      })
      .then(data => {
        var processed = []
        data.map(function (item) {
          processed.push([item.Comanda.nome,
            item.dataValues.valor])
        })
        dashboard.comandas = {
          title: 'Comandas',
          header: [
            'Nome',
            'valor'
          ],
          data: processed
        }
        dashboard.resumo.comandas = data.length
        return valorVendasFormaPagamento(dashboard)
      })
      .then(data => {
        data = data[0].dataValues

        dashboard.financeiro = {
          title: 'Financeiro',
          data: {
            labels: [
              'Dinheiro',
              'Crédito',
              'Débito'
            ],
            datasets: [{
              data: [data.D, data.CC, data.CD],
              backgroundColor: [
                '#FF6384',
                '#36A2EB',
                '#FFCE56'
              ],
              hoverBackgroundColor: [
                '#FF6384',
                '#36A2EB',
                '#FFCE56'
              ]
            }]
          }
        }
        return totalVendas(dashboard)
      })
      .then(data => {
        dashboard.resumo.vendas = data
        res.status(200).send(dashboard)
      })
      .catch(error => res.status(400).send(error))
  }
}

function periodoVenda () {
  return PeriodoVenda
    .findOne({
      order: [
        ['id', 'DESC']
      ]
    })
}

function valorVendas (dashboard) {
  return Venda.sum('valorTotal', {
    where: {
      dataVenda: {
        [Sequelize.Op.gt]: dashboard.periodo.dataInicial
      }
    }
  })
}

function valorVendasFormaPagamento (dashboard) {
  return Venda.findAll({
    attributes: [
      [Sequelize.fn('SUM', Sequelize.col('valorFinal')), 'Total'],
      [Sequelize.fn('SUM', Sequelize.col('valorD')), 'D'],
      [Sequelize.fn('SUM', Sequelize.col('valorCC')), 'CC'],
      [Sequelize.fn('SUM', Sequelize.col('valorCD')), 'CD']
    ],
    where: {
      dataVenda: {
        [Sequelize.Op.gt]: dashboard.periodo.dataInicial
      }
    }
  })
}

function totalItensVendidos (dashboard) {
  return ItemVenda.sum('quantidade', {
    where: {
      dataVenda: {
        [Sequelize.Op.gt]: dashboard.periodo.dataInicial
      }
    }
  })
}

function totalVendas (dashboard) {
  return Venda.count({
    where: {
      dataVenda: {
        [Sequelize.Op.gte]: dashboard.periodo.dataInicial
      }
    }
  })
}

function maisVendidos (dashboard) {
  return ItemVenda.findAll({
    include: [{
      model: Produto,
      as: 'Produto',
      attributes: [
        [Sequelize.col('nome'), 'nome']
      ]
    }],
    attributes: [
      [Sequelize.col('ItemVenda.produtoId'), 'produtoId'],
      [Sequelize.fn('SUM', Sequelize.col('ItemVenda.quantidade')), 'quantidade']
    ],
    order: Sequelize.literal('SUM(ItemVenda.quantidade) DESC'),
    group: [Sequelize.col('ItemVenda.produtoId'), 'produtoId'],
    limit: 10,
    where: {
      dataVenda: {
        [Sequelize.Op.gte]: dashboard.periodo.dataInicial
      }
    }
  })
}

function comandasEmAberto (dashboard) {
  return Venda.findAll({
    include: [{
      model: Comanda,
      as: 'Comanda',
      attributes: [
        [Sequelize.col('nome'), 'nome']
      ]
    }],
    attributes: [
      [Sequelize.col('venda.valorTotal'), 'valor']
    ],
    where: {
      emAberto: true
    },
    order: [Sequelize.col('comanda.nome')]
  })
}
