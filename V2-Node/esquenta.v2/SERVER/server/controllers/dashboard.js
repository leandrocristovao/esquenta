var Sequelize = require('sequelize')

const Comanda = require('../models').comanda
const ItemVenda = require('../models').itemVenda
const PeriodoVenda = require('../models').periodoVenda
const Produto = require('../models').produto
const Venda = require('../models').venda

module.exports = {
  get2 (req, res) {
    return PeriodoVenda
      .findOne({
        order: [
          ['id', 'DESC']
        ]
      })
      .then(data => {
        return Venda.findAll({
          attributes: [
            [Sequelize.fn('SUM', Sequelize.col('valorTotal')), 'ValorTotal'],
            [Sequelize.fn('SUM', Sequelize.col('valorPago')), 'ValorPago'],
            [Sequelize.fn('SUM', Sequelize.col('valorCC')), 'ValorCC'],
            [Sequelize.fn('SUM', Sequelize.col('valorCD')), 'ValorCD']
          ],
          where: {
            dataVenda: {
              [Sequelize.Op.gte]: data.dataValues.dataInicial
            }
          }
        })
      })
      .then(data => {
        res.status(200).send(data)
      })
      .catch(error => res.status(400).send(error))
  },

  get (req, res) {
    var dashboard = {
      periodo: null,
      totalItensVendidos: 0,
      valorVendas: 0,
      valorVendasFormaPagamento: 0,
      maisVendidos: [],
      comandasEmAberto: []
    }

    return periodoVenda()
      .then(data => {
        dashboard.periodo = data.dataValues
        return valorVendas(dashboard)
      })
      .then(data => {
        dashboard.valorVendas = data
        return totalItensVendidos(dashboard)
      })
      .then(data => {
        dashboard.totalItensVendidos = data
        return maisVendidos(dashboard)
      })
      .then(data => {
        dashboard.maisVendidos = data
        return comandasEmAberto(dashboard)
      })
      .then(data => {
        dashboard.comandasEmAberto = data
        return valorVendasFormaPagamento(dashboard)
      })
      .then(data => {
        dashboard.valorVendasFormaPagamento = data
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
      [Sequelize.fn('SUM', Sequelize.col('valorD')), 'Dinheiro'],
      [Sequelize.fn('SUM', Sequelize.col('valorCC')), 'Cartão de Crédito'],
      [Sequelize.fn('SUM', Sequelize.col('valorCD')), 'Cartão de Débito']
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
  return Comanda.findAll({
    attributes: [
      [Sequelize.col('nome'), 'nome']
    ],
    where: {
      emAberto: true
    },
    order: [Sequelize.col('nome'), 'nome']
  })
}
