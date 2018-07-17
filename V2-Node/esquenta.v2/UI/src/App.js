import '@progress/kendo-theme-default/dist/all.css';
import React from 'react';
//import { BrowserRouter, Route } from 'react-router-dom';

import Produtos from './components/produtos';
import MainMenu from './components/menu/MainMenu';
//import AddProduto from './components/forms/produto';
//import Teste from './components/teste';

class App extends React.Component {

  render() {
    return (
      <div>
        <MainMenu />
        <Produtos />
      </div>
      // <BrowserRouter>
      //   <div>
      //     <Route exact path="/" component={Teste} />
      //     <Route path="/Produtos" component={Produtos} />
      //     <Route path="/Add" component={AddProduto} />
      //   </div>
      // </BrowserRouter>
    );
  }
}

export default App;