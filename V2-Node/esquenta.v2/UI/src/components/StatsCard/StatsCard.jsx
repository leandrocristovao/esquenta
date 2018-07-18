import React, { Component } from "react";
import { Row, Col } from "react-bootstrap";

export class StatsCard extends Component {

  render() {
    let footer;
    if (this.props.showFooter) {
      footer = <div className="footer">
        <hr />
        <div className="stats">
          {this.props.statsIcon} {this.props.statsIconText}
        </div>
      </div>
    } else {
      footer = <span />
    }
    return (
      <div className="card card-stats">
        <div className="content">
          <Row>
            <Col xs={5}>
              <div className="icon-big text-center icon-warning">
                {this.props.bigIcon}
              </div>
            </Col>
            <Col xs={7}>
              <div className="numbers">
                <p>{this.props.statsText}</p>
                {this.props.statsValue}
              </div>
            </Col>
          </Row>
          {footer}
        </div>
      </div>
    );
  }
}

export default StatsCard;