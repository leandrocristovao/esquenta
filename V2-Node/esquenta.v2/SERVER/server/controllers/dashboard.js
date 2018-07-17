var Sequelize = require('sequelize')

const Comanda = require('../models').comanda
const ItemVenda = require('../models').itemVenda
const PeriodoVenda = require('../models').periodoVenda
const Produto = require('../models').produto

module.exports = {
  get (req, res) {
    var dashboard = {
      periodo: null,
      totalItensVendidos: 0,
      valorVendas: 15.67,
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
        res.status(200).send(dashboard)
      })
      .catch(error => res.status(400).send(error))
  },

  get2 (req, res) {
    const Op = Sequelize.Op
    var dashboard = {
      periodo: null,
      totalVendas: 0,
      totalvalor: 15.67,
      maisVendidos: [],
      emAberto: []
    }
    // res.send("asdadsad")
    return periodoVenda()
      // return PeriodoVenda
      //   .findOne({
      //     order: [
      //       ['id', 'DESC']
      //     ]
      //   })
      .then(periodo => {
        dashboard.periodo = periodo.dataValues.dataInicial

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
              [Op.gte]: dashboard.periodo
            }
          }
        })
      })
      .then(maisVendidos => {
        dashboard.maisVendidos = maisVendidos
      })
      .then(maisVendidos => {
        return ItemVenda.sum('quantidade', {
          where: {
            dataVenda: {
              [Op.gt]: dashboard.periodo
            }
          }
        })
      })
      .then(quantidade => {
        dashboard.totalvalor = quantidade
      })
      .then(maisVendidos => {
        return ItemVenda.sum('quantidade', {
          where: {
            dataVenda: {
              [Op.gt]: dashboard.periodo
            }
          }
        })
      })
      .then(quantidade => {
        console.log(dashboard)
        dashboard.totalVendas = quantidade
      })
      .then(data => {
        dashboard.emAberto = {
          id: 1
        }
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
  return ItemVenda.sum('quantidade', {
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
