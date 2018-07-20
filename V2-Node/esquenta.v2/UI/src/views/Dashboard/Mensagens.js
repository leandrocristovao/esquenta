import React, { Component } from 'react';
import { Card, CardBody, CardHeader, Table } from 'reactstrap';
import CloseIcon from './CloseIcon'

class Mensagens extends Component {
    constructor(props) {
      super(props);
    }

    render() {
      const messages = this.props.data.map((message) =>
      <tr><td><CloseIcon/> {message}</td></tr>
    );
        return (<Card>
            <CardHeader>{this.props.title}</CardHeader>
            <CardBody>
              <Table responsive striped>
                <tbody>
                  {messages}
                </tbody>
              </Table>
            </CardBody>
          </Card>)
    }
}
export default Mensagens;