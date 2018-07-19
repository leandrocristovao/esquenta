import React, { Component } from "react";
import { Grid, Row, Col } from "react-bootstrap";
import { Produtos } from "./Produtos.jsx";
import { Status } from "./Status.jsx";
import { StatsCard } from "components/StatsCard/StatsCard.jsx";
import { Tasks } from "components/Tasks/Tasks.jsx";
var reactjsAdminlte = require('adminlte-reactjs');
//var InfoTile = require('adminlte-reactjs/src/components/info-tile/InfoTile')


class Dashboard extends Component {

  constructor(props) {
    super(props);
    this.state = {
      "periodo": {
        "id": 23252,
        "dataInicial": "2018-07-15T17:20:36.000Z",
        "dataFinal": null,
        "valorEmAberto": 0,
        "valorCaixa": 0,
        "createdAt": "2018-07-17T18:40:09.200Z",
        "updatedAt": "2018-07-17T18:40:09.200Z"
      },
      "quantidadeVendas": 1,
      "totalItensVendidos": 0,
      "valorVendas": 0,
      "maisVendidos": [],
      "comandasEmAberto": []
    };
  }

  componentDidMount() {
    let request = 'http://localhost:8000/api/dashboard'
    fetch(request)
      .then((response) => {
        return response.json();
      }).then((data) => {
        this.setState(data);
      });
  }
  render() {
    const columns = [
      {
          id: 'objProduto',
          Header: 'Produto',
          accessor: d => d.Produto.nome
      },
      {
          Header: 'Quantidade',
          accessor: 'quantidade'
      }
  ]
    
    return (
      <div className="content">
        <Grid fluid>
          <Row>
            {/* <Status /> */}
            <reactjsAdminlte.InfoTile 
              width = {3} 
              content = {"teste"} 
              icon = "fa-envelope-o" 
              stats = "1,410" 
              subject = "Messages" 
              theme = "bg-aqua"/>
          </Row>
          <Row>
            <Col md={6}>
              <Produtos content={this.state.maisVendidos} />
            </Col>

            <Col md={6}>
              <Produtos content={this.state.maisVendidos} />
            </Col>
          </Row>
        </Grid>
      </div>
    );
  }
}

export default Dashboard;
