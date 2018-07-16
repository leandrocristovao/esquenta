import React from 'react';
import { NumericTextBox } from '@progress/kendo-react-inputs';
import { Button } from '@progress/kendo-react-buttons';

class Produto extends React.Component {
    constructor(props) {
        super(props);
        
        this.state = {
            formatOptions: {
                style: 'decimal',
                minimumFractionDigits: 0,
                minimumIntegerDigits: 0,
                maximumFractionDigits: 2
                //currency: 'BRL',
                //currencyDisplay: 'name'
            }
        };
    }
    render() {
        return (
            <div className="row">
                <div className="col-xs-12 col-sm-6 offset-sm-3">
                    <div >
                        <div>
                            <form>
                                <fieldset className="k-form-inline">
                                    <legend>Adicionar Produto</legend>
                                    <label className="k-form-field">
                                        <span>Código de Barras</span>
                                        <input className="k-textbox" placeholder="Digite o código de barras" />
                                    </label>
                                    <label className="k-form-field">
                                        <span>Nome do Produto</span>
                                        <input className="k-textbox" placeholder="Digite o nome do produto" />
                                    </label>
                                    <label className="k-form-field">
                                        <span>Descrição</span>
                                        <textarea className="k-textarea" placeholder="Digite descrição do produto" />
                                    </label>
                                    <label className="k-form-field">
                                        <span>Estoque</span>
                                        <input className="k-textbox" placeholder="0"/>

                                        <span>Estoque Mínimo</span>
                                        <input className="k-textbox" placeholder="0" />

                                        <span>Valor</span>
                                        <NumericTextBox className="k-textbox" placeholder="0" format={this.state.formatOptions}/>

                                        <Button primary={true} disabled={false}>Novo Item</Button> &nbsp;
                                        <Button primary={false} disabled={false}>Novo Estoque</Button>

                                    </label>
                                </fieldset>

                                <div className="text-right">
                                    <Button primary={true} disabled={false}>Salvar</Button> &nbsp;
                                    <Button primary={false} disabled={false}>Cancelar</Button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

export default Produto;