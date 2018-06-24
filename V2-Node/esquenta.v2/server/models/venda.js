'use strict'
module.exports = (sequelize, DataTypes) => {
  var venda = sequelize.define('venda', {
    dataVenda: DataTypes.DATE,
    valorTotal: DataTypes.DECIMAL,
    valorDesconto: DataTypes.DECIMAL,
    valorFinal: DataTypes.DECIMAL,
    valorAcrescimo: DataTypes.DECIMAL,
    valorPago: DataTypes.DECIMAL,
    valorCC: DataTypes.DECIMAL,
    quantidadeItens: DataTypes.INTEGER,
    terminal: DataTypes.STRING
  }, {})
  venda.associate = function (models) {
    // venda.hasMany(models.itemvenda, {
    //   foreignKey: 'vendaId',
    //   as: 'vendaItems'
    // })
  }
  return venda
}
