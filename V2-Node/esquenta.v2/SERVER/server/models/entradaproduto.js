'use strict'
module.exports = (sequelize, DataTypes) => {
  var entradaProduto = sequelize.define('entradaProduto', {
    quantidade: DataTypes.INTEGER,
    valor: DataTypes.DECIMAL,
    dataEntrada: DataTypes.DATE
  }, {})
  entradaProduto.associate = function (models) {
    // associations can be defined here
  }
  return entradaProduto
}
