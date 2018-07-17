const Venda = require('../models').venda
const Comanda = require('../models').comanda
const ItemVenda = require('../models').itemVenda
const Produto = require('../models').produto

module.exports = {
  create (req, res) {
    console.log(req.body)
    return Venda
      .create(req.body)
      .then(entity => res.status(201).send(entity))
      .catch(error => res.status(400).send(error))
  },
  list (req, res) {
    let pageSize = req.query.pageSize
    let currentPage = req.query.currentPage

    if (pageSize == undefined) {
      pageSize = 10
    }

    if (currentPage == undefined) {
      currentPage = 1
    }

    let offset = (currentPage * pageSize) - pageSize

    return Venda
      .findAndCountAll({offset: offset, limit: pageSize })
      .then(entities => res.status(200).send(entities))
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
