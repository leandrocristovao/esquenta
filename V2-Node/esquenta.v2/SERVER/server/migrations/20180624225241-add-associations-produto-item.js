module.exports = {
  up: (queryInterface, Sequelize) => {
    return queryInterface.addColumn(
      'produtoItems',
      'produtoId',
      {
        type: Sequelize.INTEGER,
        references: {
          model: 'produtos',
          key: 'id'
        },
        onUpdate: 'CASCADE',
        onDelete: 'CASCADE'
      }
    )
  },

  down: (queryInterface, Sequelize) => {
    return queryInterface.removeColumn(
      'produtoItems',
      'produtoId'
    )
  }
}
