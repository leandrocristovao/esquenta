import React from 'react';
import { Link } from 'react-router-dom'

import $ from 'jquery';
//import kendo from '@progress/kendo-ui';
import { Menu, MenuItem, SubMenu } from '@progress/kendo-layout-react-wrapper';

class MainMenu extends React.Component {
    constructor(props) {
        super(props);


        this.onSelect = this.onSelect.bind(this);
    }

    onSelect = (e) => {
        alert("Selected: " + ($(e.item).children(".k-link").text() || "ContextMenu"));
    }

    render() {
        return (
            <div id="main-menu">
                <Menu select={this.onSelect} >
                    <MenuItem>
                        Sistema
                         <SubMenu>
                            <MenuItem>Caixa</MenuItem>
                            <MenuItem>Sair</MenuItem>
                        </SubMenu>
                    </MenuItem>
                    <MenuItem>
                        Cadastros
                         <SubMenu>
                         <Link to="/Produtos">Users</Link>
                            <MenuItem>Comandas</MenuItem>
                        </SubMenu>
                    </MenuItem>
                    <MenuItem>
                        Relatórios
                         <SubMenu>
                            <MenuItem>Livro Caixa</MenuItem>
                        </SubMenu>
                    </MenuItem>
                    <MenuItem>
                        Configurações
                         <SubMenu>
                            <MenuItem>Ajustar Backup</MenuItem>
                            <MenuItem>Backup</MenuItem>
                            <MenuItem>Alterar Senha</MenuItem>
                        </SubMenu>
                    </MenuItem>
                </Menu>
            </div>

        );
    }
}

export default MainMenu;