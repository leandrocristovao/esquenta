import React, { Component } from 'react';
import {
    Button,
  
  Card,
  CardBody,
  
  CardHeader,
  
  Input,
  
  Label
} from 'reactstrap';

class Comanda extends Component {
    constructor(props) {
      super(props);

      this.state = {
          acrescimo: 0.01,
          desconto: 0.02,
          valor: 0.03,
          troco: 0.04,
          total: 0.05,
      };
    }
  
    render() {
      return (
        <Card>
        <CardHeader>
            <strong>Comanda</strong>
          </CardHeader>
          <CardBody className="text-center" style={{height: 500  + 'px'}}>
            <Input bsSize="lg" className="text-center" type="text" id="name" placeholder="Aguardando Comanda"/>
            <br />
            <Label htmlFor="acrescimo" ><strong>Acréscimo</strong></Label>
            <Button block outline active color="light" aria-pressed="false">{this.state.acrescimo}</Button>
            <br />
            <Label htmlFor="desconto"><strong>Desconto</strong></Label>
            <Button block outline active color="light" aria-pressed="false">{this.state.desconto}</Button>
            <br />
            <Label htmlFor="valor"><strong>Valor Pago</strong></Label>
            <Button block outline active color="light" aria-pressed="false">{this.state.valor}</Button>
            <br />
            <Label htmlFor="troco"><strong>Troco</strong></Label>
            <Button block outline active color="light" aria-pressed="false">{this.state.troco}</Button>
            <br />
            <h1>{this.state.total}</h1>
          </CardBody>
      </Card>
      );
    }
}

export default Comanda;