import React, { Component } from "react";
import { Grid, Row, Col, Table } from "react-bootstrap";

import Card from "components/Card/Card.jsx";
import { thArray, tdArray } from "variables/Variables.jsx";

export class Produtos extends Component {
    render() {
        return (
            <div className="content">
                <Grid fluid>
                    <Row>
                        <Col md={12}>

                            <h1>{this.props.name}</h1>
                            <Card
                                title="Mais vendidos"
                                category="Produtos mains vendidos"
                                ctTableFullWidth
                                ctTableResponsive
                                content={
                                    <Table striped hover>
                                        <thead>
                                            <tr>
                                                {this.props.header && this.props.header.map((prop, key) => {
                                                    return <th key={key}>{prop}</th>;
                                                })}
                                            </tr>
                                        </thead>
                                        <tbody>
                                            {this.props.content && this.props.content.map((prop, key) => {
                                                return (
                                                    <tr key={key}>
                                                        {Object.keys(prop).map((fields, key) => {
                                                            return <td>{fields['produtoId']}</td>;
                                                        })}

                                                        {/* {prop.map((prop, key) => {
                                                            return <td key={key}>{prop}</td>;
                                                        })} */}
                                                    </tr>
                                                );
                                            })}
                                        </tbody>
                                    </Table>
                                }
                            />
                        </Col>
                    </Row>
                </Grid>
            </div>
        );
    }
}

export default Produtos;
