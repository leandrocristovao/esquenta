# esquenta.v2

CREATE TABLES
sequelize model:create --name Comanda --attributes Nome:string,CodigoBarras:string,EmAberto:boolean
sequelize model:create --name EntradaProduto --attributes Quantidade:integer,Valor:decimal,DataEntrada:date
sequelize model:create --name ItemVenda --attributes Quantidade:integer,Valor:decimal,DataVenda:date,ValorTotal:decimal
sequelize model:create --name PeriodoVenda --attributes DataInicial:date,DataFinal:date,DataEntrada:ValorCaixa:decimal,ValorEmAberto:decimal
sequelize model:create --name Produto --attributes Nome:string,CodigoBarras:string,Descricao:string,Quantidade:integer,QuantidadeMinima:integer,Valor:decimal
sequelize model:create --name ProdutoItem --attributes Quantidade:integer
sequelize model:create --name Venda --attributes DataVenda:date,ValorTotal:decimal,ValorDesconto:decimal,ValorFinal:decimal,ValorAcrescimo:decimal,ValorPago:decimal,ValorCC:decimal,ValorCD:decimal:ValorD:decimal,QuantidadeItens:integer,Terminal:string