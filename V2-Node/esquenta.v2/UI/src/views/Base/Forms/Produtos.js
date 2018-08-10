import React, { Component } from 'react';
import { Card, CardBody, CardHeader, Table } from 'reactstrap';

class Produtos extends Component {
    constructor(props) {
        super(props);

        var data = [];
        for (var i = 1; i < 30; i++) {
            data.push(
                {
                    id: i,
                    produto: "Heineken",
                    quantidade: i,
                    valor: 5,
                    total: 5 * i
                }
            );
        }
        
        this.state = {
            itens: data
        };

        alert(JSON.stringify(this.state))
    }

    render() {
        alert(JSON.stringify(this.props))
        const content = this.props.itens.map(rows => {

            return <tr>
                <td>1</td>
                <td>Cerveja Heineken</td>
                <td>2</td>
                <td>5.0</td>
                <td>10.0</td>
            </tr>
        })

        return (
            <Card>
                <CardHeader>
                    <strong>Produtos</strong>
                </CardHeader>
                <CardBody className="text-center" style={{ height: 500 + 'px' }}>




                    <Table responsive size="sm">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Produto</th>
                                <th>Quantidade</th>
                                <th>Valor Unit.</th>
                                <th>Total</th>
                            </tr>
                        </thead>
                        <tbody>
                            {content}

                        </tbody>
                    </Table>









                </CardBody>
            </Card>
        );
    }
}

export default Produtos;