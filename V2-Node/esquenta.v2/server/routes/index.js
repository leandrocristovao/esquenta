const comandaController = require('../controllers').comandas
const dashboardController = require('../controllers').dashboard
const produtoController = require('../controllers').produtos
const vendaController = require('../controllers').vendas
// TODO: testar import * as models from "../../models";
module.exports = (app) => {
  app.get('/api', (req, res) => res.status(200).send({
    message: 'Welcome to the Esquenta\'s API!'
  }))

  /**
    * Comandas
    */
  app.post('/api/comandas', comandaController.create)
  app.get('/api/comandas', comandaController.list)
  app.get('/api/comandas/:id', comandaController.get)
  app.put('/api/comandas/:id', comandaController.update)
  app.delete('/api/comandas/:id', comandaController.destroy)

  /**
  * Dashboard
  */
  app.get('/api/dashboard', dashboardController.get)

  /**
   * Produtos
   */
  app.post('/api/produtos', produtoController.create)
  app.get('/api/produtos', produtoController.list)
  app.get('/api/produtos/:id', produtoController.get)
  app.put('/api/produtos/:id', produtoController.update)
  app.delete('/api/produtos/:id', produtoController.destroy)

  /**
   * Vendas
   */
  app.post('/api/vendas', vendaController.create)
  app.get('/api/vendas', vendaController.list)
  app.get('/api/vendas/:id', vendaController.get)
  app.put('/api/vendas/:id', vendaController.update)
  app.delete('/api/vendas/:id', vendaController.destroy)
}
