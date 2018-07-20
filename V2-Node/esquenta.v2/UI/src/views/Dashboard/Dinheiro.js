import React, { Component } from 'react';
import { Pie } from 'react-chartjs-2';
import { Card, CardBody, CardHeader,  } from 'reactstrap';


class Dinheiro extends Component {
    constructor(props) {
      super(props);
    }

    render() {
        return (<Card>
          <CardHeader>{this.props.title}</CardHeader>
          <CardBody>
            <div className="chart-wrapper">
              <Pie data={this.props.data} />
            </div>
          </CardBody>
        </Card>)
    }
}
export default Dinheiro;