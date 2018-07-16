import React from 'react';
import Grid from './GridControl/GridControl';

class Produtos extends React.Component {

  render() {
    const gridColumns = [
      { field: "codigoBarras", title: "Código de Barras" },
      { field: "nome", title: "Produto" },
      { field: "descricao", title: "Descrição" },
      { field: "quantidade", title: "Estoque" },
      { field: "quantidadeMinima", title: "Estoque Mínimo" },
      { field: "valor", title: "Valor" }
    ];

    return (
      <div>
        <Grid url="http://localhost:8000/api/produtos" columns={gridColumns}/>
      </div >
    );
  }
}

export default Produtos;