'use strict'
module.exports = {
  up: (queryInterface, Sequelize) => {
    return queryInterface.createTable('vendas', {
      id: {
        allowNull: false,
        autoIncrement: true,
        primaryKey: true,
        type: Sequelize.INTEGER
      },
      dataVenda: {
        type: Sequelize.DATE
      },
      valorTotal: {
        type: Sequelize.DECIMAL
      },
      valorDesconto: {
        type: Sequelize.DECIMAL
      },
      valorFinal: {
        type: Sequelize.DECIMAL
      },
      valorAcrescimo: {
        type: Sequelize.DECIMAL
      },
      valorPago: {
        type: Sequelize.DECIMAL
      },
      valorCC: {
        type: Sequelize.DECIMAL
      },
      valorCD: {
        type: Sequelize.DECIMAL
      },
      valorD: {
        type: Sequelize.DECIMAL
      },
      quantidadeItens: {
        type: Sequelize.INTEGER
      },
      emAberto: {
        type: Sequelize.BOOLEAN
      },
      terminal: {
        type: Sequelize.STRING
      },
      createdAt: {
        allowNull: false,
        type: Sequelize.DATE
      },
      updatedAt: {
        allowNull: false,
        type: Sequelize.DATE
      }
    })
  },
  down: (queryInterface, Sequelize) => {
    return queryInterface.dropTable('vendas')
  }
}
