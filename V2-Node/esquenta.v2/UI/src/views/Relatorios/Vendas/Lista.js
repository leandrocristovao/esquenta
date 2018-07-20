import React, { Component } from 'react';
import { Badge, Card, CardBody, CardHeader, Table, Pagination, PaginationItem, PaginationLink } from 'reactstrap';

class Row extends Component {
  render () {
    let currencyFormarter = Intl.NumberFormat('pt-BR', { style: 'currency',  currency: 'BRL' });
    let dateTimeFormarter = Intl.DateTimeFormat('pt-BR', { year: 'numeric', month: 'numeric', day: 'numeric', hour: 'numeric', minute: 'numeric', second: 'numeric', hour12: false });
    
    return <tr class={this.props.trClass}>
      {this.props.data.map((col) =>{
        if(col.render===false){
          return
        }
        switch(col.type){
          case 'currency':
            return <td>{currencyFormarter.format(col.value)}</td>

            case 'datetime':
            return <td>{dateTimeFormarter.format(new Date(col.value).getTime())}</td>

            case 'boolean':
            return <td>{col.value ? <Badge color="warning">Aberto</Badge> : <span/>}</td>

          default:
            return <td>{col.value}</td>
        }
        
      }
      )}
    </tr>;
  }
}

class Lista extends Component {
    constructor(props) {
      super(props);
    }

    render() {
      var headerData = (this.props.header != null ? this.props.header : [])
      var contentData = (this.props.data != null ? this.props.data : [])

        const header = headerData.map((title) =>
          <th>{title}</th>
        );

        const content = contentData.map(rows => {
          let classZ = ""
          if(rows != undefined && rows.length > 0 && rows[10].value === true){
            classZ = "table-warning"
          }
          return <Row trClass={classZ} data={rows}/>;
        });

        return <Card>
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
              <Pagination>
                  <PaginationItem active>
                    <PaginationLink previous tag="button" />
                  </PaginationItem>
                  
                  <PaginationItem>
                    <PaginationLink next tag="button" />
                  </PaginationItem>
                </Pagination>
            </CardBody>
          </Card>;
    }
}
export default Lista;