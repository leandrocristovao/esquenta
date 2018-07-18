import React, { Component } from "react";
import { NavItem, Nav, NavDropdown, MenuItem } from "react-bootstrap";

class HeaderLinks extends Component {
  render() {
    return (
      <div>

        <Nav pullRight>

          <NavDropdown
            eventKey={2}
            title="Cadastros"
            id="basic-nav-dropdown-right"
          >
            <MenuItem eventKey={2.1}>Produtos</MenuItem>
            <MenuItem eventKey={2.2}>Comandas</MenuItem>
          </NavDropdown>
          <NavDropdown
            eventKey={3}
            title="Relatórios"
            id="basic-nav-dropdown-right"
          >
            <MenuItem eventKey={3.1}>Vendas</MenuItem>
            <MenuItem eventKey={3.2}>Clientes</MenuItem>
          </NavDropdown>
          <NavDropdown
            eventKey={4}
            title="Configurações"
            id="basic-nav-dropdown-right"
          >
            <MenuItem eventKey={4.1}>Ajustar Backup</MenuItem>
            <MenuItem eventKey={4.2}>Backup</MenuItem>
            <MenuItem eventKey={4.3}>Alterar Senha</MenuItem>
            <MenuItem divider />
            <MenuItem eventKey={4.4}>Limpar base de dados</MenuItem>
          </NavDropdown>
          <NavItem eventKey={5} href="#">
            Log out
          </NavItem>
        </Nav>
      </div>
    );
  }
}

export default HeaderLinks;
