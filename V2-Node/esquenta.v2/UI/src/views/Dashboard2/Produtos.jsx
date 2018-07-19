import React, { Component } from "react";
import ReactTable from 'react-table'
import { ReactTableDefaults } from "react-table";

import { Grid, Row, Col, Table } from "react-bootstrap";

import Card from "components/Card/Card.jsx";
import { thArray, tdArray } from "variables/Variables.jsx";
import 'react-table/react-table.css'

Object.assign(ReactTableDefaults, {
    defaultPageSize: 10,
    minRows: 1,
    showPagination:false
});

export class Produtos extends Component {
    render() {
        const columns = [
            {
                id: 'objProduto',
                Header: 'Produto',
                accessor: d => d.Produto.nome
            },
            {
                Header: 'Quantidade',
                accessor: 'quantidade'
            }
        ]

        const data = [{
            "produtoId": 245,
            "quantidade": 37,
            "Produto": {
                "nome": "gudang avulso"
            }
        }]

        
        return (
            <ReactTable
                data={this.props.content}
                columns={columns}
            />
        );
    }
}

export default Produtos;
