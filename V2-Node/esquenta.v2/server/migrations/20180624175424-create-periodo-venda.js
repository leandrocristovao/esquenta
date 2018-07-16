'use strict';
module.exports = {
  up: (queryInterface, Sequelize) => {
    return queryInterface.createTable('periodoVendas', {
      id: {
        allowNull: false,
        autoIncrement: true,
        primaryKey: true,
        type: Sequelize.INTEGER
      },
      dataInicial: {
        type: Sequelize.DATE
      },
      dataFinal: {
        allowNull: true,
        type: Sequelize.DATE
      },
      valorEmAberto: {
        type: Sequelize.DECIMAL
      },
      valorCaixa: {
        type: Sequelize.DECIMAL
      },
      createdAt: {
        allowNull: false,
        type: Sequelize.DATE
      },
      updatedAt: {
        allowNull: false,
        type: Sequelize.DATE,
      }
    });
  },
  down: (queryInterface, Sequelize) => {
    return queryInterface.dropTable('periodoVendas');
  }
};