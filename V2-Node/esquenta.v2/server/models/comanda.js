'use strict'
module.exports = (sequelize, DataTypes) => {
  var comanda = sequelize.define('comanda', {
    nome: DataTypes.STRING,
    codigoBarras: DataTypes.STRING,
    emAberto: DataTypes.BOOLEAN
  }, {})
  comanda.associate = function (models) {
    // associations can be defined here
  }
  return comanda
}
