'use strict'
module.exports = (sequelize, DataTypes) => {
  var produtoItem = sequelize.define('produtoItem', {
    quantidade: DataTypes.INTEGER
  }, {})
  produtoItem.associate = function (models) {
    produtoItem.belongsTo(models.produto, {
      foreignKey: 'produtoId',
      as: 'Item',
      onDelete: 'CASCADE'
    })
  }
  return produtoItem
}
