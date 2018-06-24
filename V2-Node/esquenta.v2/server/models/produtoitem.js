'use strict';
module.exports = (sequelize, DataTypes) => {
  var produtoItem = sequelize.define('produtoItem', {
    quantidade: DataTypes.INTEGER
  }, {});
  produtoItem.associate = function(models) {
    // associations can be defined here
  };
  return produtoItem;
};