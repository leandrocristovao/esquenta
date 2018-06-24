'use strict'
module.exports = (sequelize, DataTypes) => {
  var itemVenda = sequelize.define('itemVenda', {
    quantidade: DataTypes.INTEGER,
    valor: DataTypes.DECIMAL,
    dataVenda: DataTypes.DATE,
    valorTotal: DataTypes.DECIMAL
  }, {})
  itemVenda.associate = function (models) {
    itemVenda.belongsTo(models.venda, {
      foreignKey: 'vendaId',
      onDelete: 'CASCADE'
    })
  }
  return itemVenda
}
