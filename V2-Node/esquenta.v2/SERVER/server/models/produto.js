'use strict'
module.exports = (sequelize, DataTypes) => {
  var produto = sequelize.define('produto', {
    nome: DataTypes.STRING,
    codigoBarras: DataTypes.STRING,
    descricao: DataTypes.STRING,
    quantidade: DataTypes.INTEGER,
    quantidadeMinima: DataTypes.INTEGER,
    valor: DataTypes.DECIMAL
  }, {})
  produto.associate = function (models) {
    produto.hasMany(models.produtoItem, {
      foreignKey: 'parentId',
      as: 'Items'
    })
  }
  return produto
}
