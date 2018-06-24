# esquenta.v2

CREATE TABLES
sequelize model:create --name comanda --attributes nome:string,codigoBarras:string,emAberto:boolean
sequelize model:create --name entradaProduto --attributes quantidade:integer,valor:decimal,dataEntrada:date
sequelize model:create --name itemVenda --attributes quantidade:integer,valor:decimal,dataVenda:date,valorTotal:decimal
sequelize model:create --name periodoVenda --attributes dataInicial:date,dataFinal:date,dataEntrada:valorCaixa:decimal,valorEmAberto:decimal
sequelize model:create --name produto --attributes nome:string,codigoBarras:string,descricao:string,quantidade:integer,quantidadeMinima:integer,valor:decimal
sequelize model:create --name produtoItem --attributes quantidade:integer
sequelize model:create --name venda --attributes dataVenda:date,valorTotal:decimal,valorDesconto:decimal,valorFinal:decimal,valorAcrescimo:decimal,valorPago:decimal,valorCC:decimal,valorCD:decimal:valorD:decimal,quantidadeItens:integer,terminal:string