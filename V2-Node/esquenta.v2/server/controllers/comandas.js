const Comanda = require('../models').comanda

module.exports = {
  create (req, res) {
    return Comanda
      .create(req.body)
      .then(entity => res.status(201).send(entity))
      .catch(error => res.status(400).send(error))
  },
  list (req, res) {
    return Comanda
      .findAll()
      .then(entities => res.status(200).send(entities))
      .catch(error => res.status(400).send(error))
  },
  get (req, res) {
    return Comanda
      .findById(req.params.id)
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
    return Comanda
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
    return Comanda
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
