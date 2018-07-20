import React, { Component } from 'react';
import { Row, Col } from 'reactstrap';
import Widget02 from '../../views/Widgets/Widget02'

class Header extends Component {
    constructor(props) {
      super(props);
    }

    render() {
        return (<Row>
            <Col xs="12" sm="6" lg="3">
          <Widget02 header={this.props.data.vendas} mainText="Vendas" icon="fa fa-sellsy" color="secondary" />
          </Col>

          <Col xs="12" sm="6" lg="3">
          <Widget02 header={this.props.data.dinheiro} mainText="Dinheiro" icon="fa fa-money" color="secondary" />
          </Col>

          <Col xs="12" sm="6" lg="3">
          <Widget02 header={this.props.data.itens} mainText="Itens vendidos" icon="fa fa-shopping-basket" color="secondary" />
          </Col>

          <Col xs="12" sm="6" lg="3">
          <Widget02 header={this.props.data.comandas} mainText="Em aberto" icon="fa fa-id-card-o" color="secondary" />
          </Col>
        </Row>)
    }
}
export default Header;