var Sequelize = require('sequelize')

const PeriodoVenda = require('../models').periodoVenda
const Produto = require('../models').produto
const ProdutoItem = require('../models').produtoItem
const ItemVenda = require('../models').itemVenda

module.exports = {

  // get (req, res) {
  //   return PeriodoVenda
  //     .findOne({
  //       order: [['ID', 'DESC']]
  //     })
  //     .then(periodo => {
  //       ItemVenda.findAll({
  //         limit: 10,
  //         where: {
  //           dataVenda: {
  //             [Op.gte]: periodo.dataValues.dataInicial
  //           }
  //         }
  //       })
  //         .then(vendas => {
  //           return res.status(200).send(vendas)
  //         })
  //     })
  //     .then(data => {
  //       return res.status(200).send(data)
  //     })
  //     .catch(error => res.status(400).send(error))
  // }
  get (req, res) {
    const Op = Sequelize.Op
    return PeriodoVenda
      .findOne({
        order: [
          ['ID', 'DESC']
        ]
      })
      .then(periodo => {
        console.log(periodo.dataValues.dataInicial)
        return ItemVenda.findAll({
          limit: 10,
          where: {
            dataVenda: {
              [Op.gte]: '2017-12-01 18:13:20.000'
            }
          }
        })
      })
      .then(data => {
        return res.status(200).send(data)
      })
      .catch(error => res.status(400).send(error))
  }
}
