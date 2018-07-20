import React, { Component } from 'react';

import {
  Badge,
  Button,
  ButtonDropdown,
  Card,
  CardBody,
  CardFooter,
  CardHeader,
  Col,
  Collapse,
  DropdownItem,
  DropdownMenu,
  DropdownToggle,
  Fade,
  Form,
  FormGroup,
  FormText,
  FormFeedback,
  Input,
  InputGroup,
  InputGroupAddon,
  InputGroupText,
  Label,
  Row
} from 'reactstrap';

import Lista from './Lista.js';

class Vendas extends Component {
  constructor(props) {
    super(props);

    this.state = {
      resumo: {
        "periodo": {
          "id": 0,
          "dataInicial": null,
          "dataFinal": null,
          "valorEmAberto": 0,
          "valorCaixa": 0,
          "createdAt": null,
          "updatedAt": null
        },
        "vendas": {
          "valorTotal": 0,
          "valorDesconto": 0,
          "valorFinal": 0,
          "valorAcrescimo": 0,
          "valorPago": 0,
          "valorCC": 0,
          "valorCD": 0,
          "valorD": 0,
          "quantidadeItens": 0,
          "totalVendas": 0
        }
      },
      lista: {
        title: "",
        header: [
          
        ],
        data: [
          [
            
          ]
        ]
      }
    };
  }

  componentDidMount() {
    let request = 'http://localhost:8000/api/';
    fetch(request + 'vendas')
      .then((response) => {
        return response.json();

      }).then((data) => {

        this.setState({lista: data});
      })
      .then(()=>{

        return fetch(request + 'vendas/resumoPeriodo')
      })
      .then((response) => {

        return response.json();
      }).then((data) => {

        this.setState({resumo:data});
      });
  }

  render() {
      let formarter = Intl.NumberFormat('pt-BR', { style: 'currency',  currency: 'BRL' });

    return (
      <div className="animated fadeIn">
      <Row>
      <Col xs="4">
            <Card>
              <CardHeader>Resumo</CardHeader>
              <CardBody>
              
            <dl className="row">
                <dt className="col-sm-8">Total de vendas</dt>
                <dd className="col-sm-4">{this.state.resumo.vendas.totalVendas}</dd> 

                <dt className="col-sm-8">Valor em vendas</dt>
                <dd className="col-sm-4">{formarter.format(this.state.resumo.vendas.valorTotal)}</dd>

                  <dt className="col-sm-8">Valor em aberto</dt>
                  <dd className="col-sm-4">{formarter.format(this.state.resumo.vendas.valorTotal)}</dd>

                  <dt className="col-sm-8 text-truncate">Desconto</dt>
                  <dd className="col-sm-4">{formarter.format(this.state.resumo.vendas.valorDesconto)}</dd>

                  <dt className="col-sm-8 text-truncate">Acréscimo</dt>
                  <dd className="col-sm-4">{formarter.format(this.state.resumo.vendas.valorAcrescimo)}</dd>

                  <dt className="col-sm-8 text-truncate">Caixa</dt>
                  <dd className="col-sm-4">{formarter.format(this.state.resumo.periodo.valorCaixa)}</dd>

                  <dt className="col-sm-8 text-truncate">Valor final</dt>
                  <dd className="col-sm-4">{formarter.format(this.state.resumo.vendas.valorFinal)}</dd>
                </dl>
              </CardBody>
            </Card>
          </Col>
        </Row>
        <Row>
          <Col xs="12">
          <Lista title={this.state.lista.title} header={this.state.lista.header} data={this.state.lista.data}/>
          </Col>
        </Row>
      </div>
    );
  }
}

export default Vendas;
