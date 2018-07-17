const Produto = require('../models').produto
const ProdutoItem = require('../models').produtoItem

module.exports = {
  create (req, res) {
    return Produto
      .create(req.body)
      .then(entity => res.status(201).send(entity))
      .catch(error => res.status(400).send(error))
  },
  list (req, res) {
    let pageSize = req.query.pageSize
    let currentPage = req.query.currentPage
    let find = req.query.find

    if (pageSize == undefined) {
      pageSize = 10
    }

    if (currentPage == undefined) {
      currentPage = 1
    }

    if (find == undefined) {
      find = '' 
    }

    let offset = (currentPage * pageSize) - pageSize

    return Produto
      .findAndCountAll({ where: { nome: { $like: '%' + find + '%' } }, offset: offset, limit: pageSize })
      .then(entities => res.status(200).send(entities))
      .catch(error => res.status(400).send(error))
  },
  get (req, res) {
    return Produto
      .findById(req.params.id, {
        include: [
          {
            model: ProdutoItem,
            as: 'Items',
            include: [
              { model: Produto, as: 'Item' }
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
    return Produto
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
    return Produto
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
