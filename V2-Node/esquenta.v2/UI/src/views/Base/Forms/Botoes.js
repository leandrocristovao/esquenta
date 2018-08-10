import React, { Component } from 'react';
import { Card, CardBody, Col, Button, Row } from 'reactstrap';

class Botoes extends Component {
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
                <CardBody className="text-center">
                    <Row className="align-items-center mt-3">
                        <Col col="2" className="mb-3 mb-xl-0 text-center">
                            <Button color="warning" size="lg"><i className="fa fa-calculator"></i>&nbsp;(F7) Calcular</Button>
                        </Col>

                        <Col col="2" className="mb-3 mb-xl-0 text-center">
                            <Button color="danger" size="lg"><i className="fa fa-close"></i>&nbsp;(F8) Cancelar</Button>
                        </Col>

                        <Col col="2" className="mb-3 mb-xl-0 text-center">
                            <Button color="success" size="lg"><i className="fa fa-money"></i>&nbsp;(F9) Fechar</Button>
                        </Col>
                    </Row>
                </CardBody>
            </Card>
        );
    }
}

export default Botoes;