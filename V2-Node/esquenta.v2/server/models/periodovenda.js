'use strict';
module.exports = (sequelize, DataTypes) => {
  var periodoVenda = sequelize.define('periodoVenda', {
    dataInicial: DataTypes.DATE,
    dataFinal: DataTypes.DATE,
    valorEmAberto: DataTypes.DECIMAL
  }, {});
  periodoVenda.associate = function(models) {
    // associations can be defined here
  };
  return periodoVenda;
};