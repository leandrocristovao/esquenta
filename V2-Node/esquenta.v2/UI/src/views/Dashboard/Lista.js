import React, { Component } from 'react';
import { Card, CardBody, CardHeader, Table } from 'reactstrap';

class Row extends Component {
  render () {

    return <tr>
      {this.props.data.map((col) =>
        <td>{col}</td>
      )}
    </tr>
  }
}

class Lista extends Component {
    constructor(props) {
      super(props);
    }

    render() {

        const header = this.props.header.map((title) =>
          <th>{title}</th>
        );

        const content = this.props.data.map(rows => {
          
          return <Row data={rows}/>
        })

        return (<Card>
            <CardHeader>{this.props.title}</CardHeader>
            <CardBody>
              <Table responsive>
                <thead>
                <tr>
                  {header}
                </tr>
                </thead>
                <tbody>
                {content}
                </tbody>
              </Table>
            </CardBody>
          </Card>)
    }
}
export default Lista;