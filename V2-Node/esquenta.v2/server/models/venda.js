'use strict'
module.exports = (sequelize, DataTypes) => {
  var venda = sequelize.define('venda', {
    dataVenda: DataTypes.DATE,
    valorTotal: DataTypes.DECIMAL,
    valorDesconto: DataTypes.DECIMAL,
    valorFinal: DataTypes.DECIMAL,
    emAberto: DataTypes.BOOLEAN,
    valorAcrescimo: DataTypes.DECIMAL,
    valorPago: DataTypes.DECIMAL,
    valorCC: DataTypes.DECIMAL,
    valorCD: DataTypes.DECIMAL,
    valorD: DataTypes.DECIMAL,
    quantidadeItens: DataTypes.INTEGER,
    terminal: DataTypes.STRING
  }, {})
  venda.associate = function (models) {
    venda.belongsTo(models.comanda, {
      foreignKey: 'comandaId',
      as: 'Comanda'
    })

    venda.hasMany(models.itemVenda, {
      foreignKey: 'vendaId',
      as: 'Items'
    })
  }
  return venda
}
