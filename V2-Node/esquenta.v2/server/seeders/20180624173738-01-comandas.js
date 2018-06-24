'use strict'

module.exports = {
  up: (queryInterface, Sequelize) => {
    return queryInterface.bulkInsert('comandas', [{
      nome: 'Caixa',
      codigoBarras: '1',
      emAberto: false,
      createdAt: new Date(),
      updatedAt: new Date()
    },
    {
      nome: 'Consumo',
      codigoBarras: '2',
      emAberto: false,
      createdAt: new Date(),
      updatedAt: new Date()
    },
    {
      nome: 'Preto',
      codigoBarras: '3',
      emAberto: false,
      createdAt: new Date(),
      updatedAt: new Date()
    }], {})
  },

  down: (queryInterface, Sequelize) => {
    return queryInterface.bulkDelete('comandas', null, {})
  }
}
