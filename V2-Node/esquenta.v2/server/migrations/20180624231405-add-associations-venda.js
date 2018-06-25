module.exports = {
  up: (queryInterface, Sequelize) => {
    return queryInterface.addColumn(
      'vendas',
      'comandaId',
      {
        type: Sequelize.INTEGER,
        references: {
          model: 'comandas',
          key: 'id'
        },
        onUpdate: 'CASCADE',
        onDelete: 'SET NULL'
      }
    )
  },

  down: (queryInterface, Sequelize) => {
    return queryInterface.removeColumn(
      'vendas',
      'comandaId'
    )
  }
}
