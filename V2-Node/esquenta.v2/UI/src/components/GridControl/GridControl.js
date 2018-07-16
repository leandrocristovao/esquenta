import React from 'react';
import { Grid, GridColumn, GridToolbar } from '@progress/kendo-react-grid';
import { Input } from '@progress/kendo-react-inputs';
import { Button } from '@progress/kendo-react-buttons';
import { Dialog, DialogActionsBar } from '@progress/kendo-react-dialogs';
import cellWithEditing from './cellWithEditing.jsx';

import './GridControl.css';

class GridControl extends React.Component {

  constructor(props) {
    super(props);

    this.state = {
      finder: "",
      showEdit: false,
      items: [],
      total: 0,
      skip: 0,
      pageSize: 10,
      pageable: {
        buttonCount: 5,
        info: true,
        type: 'numeric',
        pageSizes: true,
        previousNext: true
      }
    };

    this.pageChange = this.pageChange.bind(this);
    this.finderChange = this.finderChange.bind(this);
    this.finderKeyPress = this.finderKeyPress.bind(this);

    this.toggleDialog = this.toggleDialog.bind(this);
    this.addForm = this.addForm.bind(this);
    this.closeForm = this.closeForm.bind(this);
    this.saveForm = this.saveForm.bind(this);
  }

  addForm() {
    alert('add form');
    this.setState({
      showEdit: true
    });
  }

  closeForm() {
    alert('close form');
    this.setState({
      showEdit: false
    });
  }

  saveForm() {
    alert('save form');
    this.setState({
      showEdit: false
    });
  }

  toggleDialog() {
    this.setState({
      showEdit: !this.state.showEdit
    });
  }
  componentDidMount() {
    this.requestData(1, this.state.pageSize, '', (data => {
      this.setState({
        items: data.rows,
        total: data.count
      });
    }));
  }

  pageChange(event) {
    this.requestData((event.page.skip / event.page.take) + 1, event.page.take, '', (data => {
      this.setState({
        items: data.rows,
        total: data.count,
        skip: event.page.skip,
        pageSize: event.page.take
      });
    }));
  }

  requestData = function (currentPage, pageSize, find, callback) {
    let request = `${this.props.url}?pageSize=${pageSize}&currentPage=${currentPage}&find=${find}`;

    fetch(request)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        callback(data);
      });
  }

  finderKeyPress(e) {
    if (e.key === "Enter") {
      this.requestData(1, this.state.pageSize, this.state.finder, (data => {
        this.setState({
          items: data.rows,
          total: data.count,
          skip: 0,
          pageSize: this.state.pageSize
        });
      }));
    }
  }

  finderChange(event) {
    this.setState({ finder: event.target.value });
  }


  render() {

    return (
      <div>
        <Grid data={this.state.items} onPageChange={this.pageChange} total={this.state.total} skip={this.state.skip} pageable={this.state.pageable} pageSize={this.state.pageSize}>
          <GridToolbar>
            <Button onClick={this.addForm} className="k-button k-primary">Adicionar</Button>

            <span className="right">
              <Input id="finder" value={this.state.finder} onKeyPress={this.finderKeyPress} onChange={this.finderChange} placeholder="Digite algo para pesquisar" className="txt-search" />
            </span>
          </GridToolbar>

          {this.props.columns.map((item, i) => {
            return (<GridColumn field={item.field} title={item.title} />)
          })}

          <GridColumn title="Edit" cell={cellWithEditing(this.edit, this.remove)} width="150px" />
        </Grid>

        {this.state.showEdit && <Dialog title={"Please confirm"} onClose={this.closeForm}>
          <div>{this.props.children}</div>
          <DialogActionsBar>
            <button className="k-button k-primary" onClick={this.saveForm}>Salvar</button>
            <button className="k-button k-secondary" onClick={this.closeForm}>Cancelar</button>
          </DialogActionsBar>
        </Dialog>}
      </div >
    );
  }
}

export default GridControl;