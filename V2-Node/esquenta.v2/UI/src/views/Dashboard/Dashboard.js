import React, { Component } from 'react';
import { Col,  Row } from 'reactstrap';

import Dinheiro from './Dinheiro.js';
import Header from './Header.js';
import Lista from './Lista.js';
import Mensagens from './Mensagens.js';

class Dashboard extends Component {
  constructor(props) {
    super(props);

    this.state = {resumo:{vendas:0,dinheiro:0,itens:0,comandas:0},financeiro:{title:'Financeiro',data:{labels:[],datasets:[{data:[],backgroundColor:['#FF6384','#36A2EB','#FFCE56'],hoverBackgroundColor:['#FF6384','#36A2EB','#FFCE56']}]}},messages:{title:"Mensagens",header:[],data:[]},maisVendidos:{title:"Mais Vendidos",header:[],data:[]},comandas:{title:"Comandas",header:[],data:[]}};
  }

  componentDidMount() {
    let request = 'http://localhost:8000/api/dashboard';
    fetch(request)
      .then((response) => {
        return response.json();
      }).then((data) => {
        //alert(JSON.stringify(data))
        this.setState(data);
      });
  }

  render() {
    return (
      <div className="animated fadeIn">
        <Header data={this.state.resumo}/>
        <Row>
          <Col><Lista title={this.state.maisVendidos.title} header={this.state.maisVendidos.header} data={this.state.maisVendidos.data}/></Col>
          <Col><Lista title={this.state.comandas.title} header={this.state.comandas.header} data={this.state.comandas.data}/></Col>
        </Row>
        <Row>
          <Col><Dinheiro title={this.state.financeiro.title} data={this.state.financeiro.data}/></Col>
          <Col><Lista title={this.state.messages.title} header={this.state.messages.header} data={this.state.messages.data}/></Col>
        </Row>
        
      </div>
    );
  }
}

export default Dashboard;
