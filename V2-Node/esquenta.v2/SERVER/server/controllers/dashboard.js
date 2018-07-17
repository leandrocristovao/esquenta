var Sequelize = require('sequelize')

const PeriodoVenda = require('../models').periodoVenda
const Produto = require('../models').produto
const Venda = require('../models').venda
const ProdutoItem = require('../models').produtoItem
const ItemVenda = require('../models').itemVenda

module.exports = {

  get2(req, res) {
    const Op = Sequelize.Op
      //return ItemVenda.findAll({
      return ItemVenda.findById(6621, {
      //include: [{all: true}],
      include: [{
        model:Produto, 
        as: 'Produto'
      }],
      attributes: [
        [Sequelize.col('produtoId'), 'produtoId'],
        [Sequelize.col('Produto.nome'), 'nome']
      ],
      //limit: 1
    })
      .then(data => {
        return res.status(200).send(data)
      })
      .catch(error => res.status(400).send(error))
  },

  get(req, res) {
    const Op = Sequelize.Op
    return PeriodoVenda
      .findOne({
        order: [
          ['id', 'DESC']
        ]
      })
      .then(periodo => {
        console.log(periodo.dataValues.dataInicial);
        return ItemVenda.findAll({
          include: [{
            model:Produto, 
            as: 'Produto',
            attributes:[[Sequelize.col('nome'), 'nome']]
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
              [Op.gte]: periodo.dataValues.dataInicial
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
