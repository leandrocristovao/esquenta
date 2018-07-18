import React, { Component } from "react";
import { Row, Col } from "react-bootstrap";
import { StatsCard } from "components/StatsCard/StatsCard.jsx";

export class Status extends Component {
  render() {

    return (<div>
        <Col lg={3} sm={3}>
          <StatsCard
            showFooter={false}
            bigIcon={<i className="pe-7s-drawer text-warning" />}
            statsText="Quantidade de vendas"
            statsValue="17"
          />
        </Col>
        <Col lg={3} sm={3}>
          <StatsCard
            showFooter={false}
            bigIcon={<i className="pe-7s-wallet text-success" />}
            statsText="Valor vendido"
            statsValue="$1,345"
          />
        </Col>
        <Col lg={3} sm={3}>
          <StatsCard
            showFooter={false}
            bigIcon={<i className="pe-7s-graph1 text-danger" />}
            statsText="Consumo"
            statsValue="23"
          />
        </Col>
        <Col lg={3} sm={3}>
          <StatsCard
            showFooter={false}
            bigIcon={<i className="pe-7s-note2 text-info" />}
            statsText="Comandas em aberto"
            statsValue="5"
          />
        </Col>
        </div>
    );
  }
}

export default Status;
