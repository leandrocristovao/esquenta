var Sequelize = require('sequelize')
const Venda = require('../models').venda
const Comanda = require('../models').comanda
const ItemVenda = require('../models').itemVenda
const Produto = require('../models').produto
const PeriodoVenda = require('../models').periodoVenda

module.exports = {
  create (req, res) {
    return Venda
      .create(req.body)
      .then(entity => res.status(201).send(entity))
      .catch(error => res.status(400).send(error))
  },

  resumoPeriodo (req, res) {
    var resumo = {
      periodo: {},
      vendas: {}
    }
    return periodoVenda(req.query.periodo)
      .then(data => {
        resumo.periodo = data.dataValues
        return valorVendas(resumo.periodo.dataInicial)
      })
      .then(data => {
        resumo.vendas = data
        return totalVendas(resumo.periodo.dataInicial)
        // res.status(200).send(resumo.periodo.dataInicial)
      })
      .then(data => {
        resumo.vendas.totalVendas = data
        res.status(200).send(resumo)
      })
      .catch(error => res.status(400).send(error))
  },
  list (req, res) {
    let pageSize = req.query.pageSize
    let currentPage = req.query.currentPage

    if (pageSize === undefined) {
      pageSize = 10
    }

    if (currentPage == undefined) {
      currentPage = 1
    }

    let offset = (currentPage * pageSize) - pageSize

    return Venda
      .findAndCountAll({include: [{ model: Comanda, as: 'Comanda' }], offset: offset, limit: pageSize })
      .then(data => {
        var processed = []
        data.rows.map(item => {
          processed.push([
            {
              type: 'int',
              value: item.id
            },
            {
              type: 'string',
              value: item.Comanda.nome
            },
            {
              type: 'datetime',
              value: item.dataVenda
            },
            {
              type: 'currency',
              value: item.valorTotal
            },
            {
              type: 'currency',
              value: item.valorCC
            },
            {
              type: 'currency',
              value: item.valorCD
            },
            {
              type: 'currency',
              value: item.valorD
            },
            {
              type: 'currency',
              value: item.valorAcrescimo
            },
            {
              type: 'currency',
              value: item.valorDesconto
            },
            {
              type: 'currency',
              value: item.valorFinal
            },
            {
              render: false,
              type: 'boolean',
              value: item.emAberto
            }
          ])
        })

        data = {
          resumo: {
            totalVendas: data.count
          },
          lista: {
            title: 'Vendas',
            header: ['#', 'Comanda', 'Data/Hora', 'Valor', 'CC', 'CD', 'D', 'Acréscimo', 'Desconto', 'Valor Final'],
            data: processed
          }
        }
        res.status(200).send(data)
      })
      .catch(error => res.status(400).send(error))
  },
  get (req, res) {
    return Venda
      .findById(req.params.id, {
        // include: [{ all: true }]
        include: [
          { model: Comanda, as: 'Comanda' },
          {
            model: ItemVenda,
            as: 'Items',
            include: [
              { model: Produto, as: 'Produto' }
            ]
          }
        ]
      })
      .then(entity => {
        if (!entity) {
          return res.status(404).send({
            message: 'Record Not Found'
          })
        }
        return res.status(200).send(entity)
      })
      .catch(error => res.status(400).send(error))
  },
  update (req, res) {
    return Venda
      .findById(req.params.id)
      .then(entity => {
        if (!entity) {
          return res.status(404).send({
            message: 'Record Not Found'
          })
        }
        return entity
          .update(req.body)
          .then(() => res.status(200).send(entity))
          .catch((error) => res.status(400).send(error))
      })
      .catch((error) => res.status(400).send(error))
  },
  destroy (req, res) {
    return Venda
      .findById(req.params.id)
      .then(entity => {
        if (!entity) {
          return res.status(400).send({
            message: 'Record Not Found'
          })
        }
        return entity
          .destroy()
          .then(() => res.status(200).send({ message: 'Record deleted successfully.' }))
          .catch(error => res.status(400).send(error))
      })
      .catch(error => res.status(400).send(error))
  }
}

function periodoVenda (periodo) {
  if (periodo == null) {
    return PeriodoVenda
      .findOne({
        order: [
          ['id', 'DESC']
        ]
      })
  } else {
    return PeriodoVenda
      .findOne({
        where: {
          dataVenda: {
            [Sequelize.Op.gt]: periodo
          }
        },
        order: [
          ['id', 'DESC']
        ]
      })
  }
}

function valorVendas (periodo) {
  return Venda
    .findOne({
      attributes: [
        [Sequelize.fn('SUM', Sequelize.col('valorTotal')), 'valorTotal'],
        [Sequelize.fn('SUM', Sequelize.col('valorDesconto')), 'valorDesconto'],
        [Sequelize.fn('SUM', Sequelize.col('valorFinal')), 'valorFinal'],
        [Sequelize.fn('SUM', Sequelize.col('valorAcrescimo')), 'valorAcrescimo'],
        [Sequelize.fn('SUM', Sequelize.col('valorPago')), 'valorPago'],
        [Sequelize.fn('SUM', Sequelize.col('valorCC')), 'valorCC'],
        [Sequelize.fn('SUM', Sequelize.col('valorCD')), 'valorCD'],
        [Sequelize.fn('SUM', Sequelize.col('valorD')), 'valorD'],
        [Sequelize.fn('SUM', Sequelize.col('quantidadeItens')), 'quantidadeItens'],
        [Sequelize.fn('COUNT', Sequelize.col('quantidadeItens')), 'totalVendas']
      ],
      where: {
        dataVenda: {
          [Sequelize.Op.gt]: periodo
        }
      }
    })
    .then(data => {
      return valorVendasEmAberto(data, periodo)
    })
}

function valorVendasEmAberto (data, periodo) {
  return Venda
    .findOne({
      attributes: [
        [Sequelize.fn('SUM', Sequelize.col('valorTotal')), 'valorTotal']
      ],
      where: {
        emAberto: 1,
        dataVenda: {
          [Sequelize.Op.gt]: periodo
        }
      }
    })
    .then(content => {
      // console.log(data.dataValues)
      // console.log(periodo)
      console.log(content.dataValues)
    })
}

function totalVendas (periodo) {
  return Venda.count({
    where: {
      dataVenda: {
        [Sequelize.Op.gte]: periodo
      }
    }
  })
}
