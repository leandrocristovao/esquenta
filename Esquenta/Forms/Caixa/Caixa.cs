﻿using Esquenta.Entities;
using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Esquenta.Forms.Caixa
{
    public partial class Caixa : Form
    {
        private enum State
        {
            AguardandoComanda = 1,
            AguardandoProduto = 2,
        };

        private AutoCompleteStringCollection comandasAutoComplete = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection produtosAutoComplete = new AutoCompleteStringCollection();
        private CalculoVenda calculo;
        private Comanda _comanda;
        private Venda _venda;
        private ConnectionService service;
        private List<ItemVenda> itens = new List<Entities.ItemVenda>();
        private State CurrentState = State.AguardandoComanda;
        private Boolean _quantidadeAutomatica = false;
        public Caixa()
        {
            InitializeComponent();

            service = ConnectionService.GetInstance();

            var periodo = service.GetPeriodoVendaRepository().GetPeriodoAtual();
            lblStatus.Text = @"Aguardando comanda";
            txtComanda.Focus();

            var listaProduto = service.GetProdutoRepository().List();
            listaProduto.Where(x => x.Valor > 0).ForEach(produto =>
                {
                    produtosAutoComplete.Add(produto.Nome);
                });

            var listaComanda = service.GetComandaRepository().List();
            listaComanda.ForEach(comanda =>
            {
                comandasAutoComplete.Add(comanda.Nome);
            });

            txtComanda.AutoCompleteCustomSource = comandasAutoComplete;
            lblQuantidadeItem.Text = "";
        }

        private void ClearScreen(bool forceDelete = false)
        {
            CurrentState = State.AguardandoComanda;

            dataGridView1.Rows.Clear();
            itens.Clear();

            if (_comanda != null && forceDelete && _comanda.Id > 2)
            {
                var venda = service.GetVendaRepository().GetVendasEmAberto(_comanda);
                var deletar = MessageBox.Show("Cancelar venda registrada?", "Cancelar Venda?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
                if (deletar)
                {
                    if (venda != null)
                    {
                        service.GetVendaRepository().Delete(venda);
                    }
                }
                else
                {
                    if (venda.Id > 2 && !string.IsNullOrEmpty(venda.Terminal)) ;
                    service.GetVendaRepository().EntradaTerminal(venda, null);
                }
            }

            _comanda = null;

            lblStatus.Text = "Aguardando comanda";
            lblValorTotal.Text = "0,00";
            lblNomeComanda.Text = "---";

            txtDesconto.Text = "0,00";
            txtAcrescimo.Text = "0,00";
            txtTroco.Text = "0,00";
            txtValorPago.Text = "0,00";

            txtComanda.Text = "";
            txtComanda.Focus();

            //if (calculo == null)
            //{
            //    calculo = new CalculoVenda();
            //}
            calculo = calculo ?? new CalculoVenda();

            calculo.Acrescimo = 0;
            calculo.Desconto = 0;
            calculo.ValorCC = 0;
            calculo.ValorCD = 0;
            calculo.ValorD = 0;
            calculo.ValorPago = 0;
            calculo.ValorVenda = 0;

            txtComanda.AutoCompleteCustomSource = comandasAutoComplete;
            lblQuantidadeItem.Text = "";
        }

        private void txtComanda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtComanda.Text))
                {
                    ProcessState();
                }
            }
        }

        private void ProcessState()
        {
            switch (CurrentState)
            {
                case State.AguardandoComanda:
                    //Recupero comanda
                    _comanda = CheckComanda();
                    if (_comanda == null)
                    {
                        MessageBox.Show("Comanda inválida");
                        txtComanda.Clear();
                        return;
                    }
                    CurrentState = State.AguardandoProduto;
                    lblStatus.Text = "Aguardando Produto";
                    lblNomeComanda.Text = _comanda.Nome;
                    txtComanda.Clear();

                    txtComanda.AutoCompleteCustomSource = produtosAutoComplete;

                    if (_comanda.Id > 2)
                    {
                        //itens
                        var vendaService = service.GetVendaRepository();
                        _venda = vendaService.GetVendasEmAberto(_comanda);

                        if (_venda != null)
                        {
                            if (!string.IsNullOrEmpty(_venda.Terminal) && !_venda.Terminal.Equals(Environment.MachineName))
                            {
                                MessageBox.Show(string.Format("Comanda aberta no terminal {0}", _venda.Terminal));
                                ClearScreen();
                            }
                            else
                            {
                                vendaService.EntradaTerminal(_venda, Environment.MachineName);
                                _venda.ItemVenda.ForEach(item =>
                                {
                                    itens.Add(item);
                                    dataGridView1.Rows.Add(new String[] { itens.Count.ToString(), item.Produto.Nome, item.Quantidade.ToString(), item.Valor.ToString(), (item.Valor * item.Quantidade).ToString() });
                                });

                                calculo = new CalculoVenda
                                {
                                    Acrescimo = _venda.ValorAcrescimo,
                                    Desconto = _venda.ValorDesconto,
                                    ValorCC = _venda.ValorCC,
                                    ValorCD = _venda.ValorCD,
                                    ValorD = _venda.ValorD,
                                    ValorPago = _venda.ValorPago
                                };
                                AtualizaCalculo(calculo);
                            }
                        }
                    }
                    break;

                case State.AguardandoProduto:
                    if (_comanda == null)
                    {
                        MessageBox.Show("Comanda não cadastrada");
                        txtComanda.Clear();
                        return;
                    }
                    //Recupero Produto
                    var _produto = CheckProduto();
                    if (_produto == null)
                    {
                        MessageBox.Show("Produto não cadastrado");
                        txtComanda.Clear();
                        return;
                    }

                    var estoque = new List<string>();
                    _produto.Itens.Where(x => x.Produto.Quantidade <= x.Produto.QuantidadeMinima).ForEach(item =>
                    {
                        estoque.Add($@"Produto {item.Produto.Nome} está com o estoque baixo: {item.Produto.Quantidade}");
                    });
                    if (estoque.Count > 0)
                    {
                        lblQuantidadeItem.Text = string.Join("\n", estoque.ToArray());
                    }

                    var itemVenda = new ItemVenda
                    {
                        Produto = _produto,
                        Valor = _produto.Valor,
                        DataVenda = DateTime.Now
                    };

                    if (!_quantidadeAutomatica)
                    {
                        using (var form = new Quantidade())
                        {
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                //_produto.Quantidade = form.Total;
                                itemVenda.Quantidade = form.Total;
                            }
                        }
                    }
                    else
                    {
                        itemVenda.Quantidade = 1;
                    }
                    itemVenda.ValorTotal = itemVenda.Quantidade * itemVenda.Valor;
                    itens.Add(itemVenda);
                    //itens.Add(_produto);

                    //var xxx = itens.GroupBy(i => i).Select(c => new { Key = c.Key, total = c.Sum(x => x.Quantidade) });
                    //var xxx = itens.SelectMany(x=> x.Itens).GroupBy(i => i.Produto).Select(c => new { Key = c.Key, total = c.Sum(x => x.Quantidade) });

                    dataGridView1.Rows.Add(new String[] { itens.Count.ToString(), itemVenda.Produto.Nome, itemVenda.Quantidade.ToString(), itemVenda.Valor.ToString(), (itemVenda.Valor * itemVenda.Quantidade).ToString() });

                    decimal valorVenda = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        valorVenda += decimal.Parse(dataGridView1.Rows[i].Cells["Valor"].Value.ToString());
                    }

                    lblValorTotal.Text = string.Format("{0:N}", valorVenda);

                    txtDesconto.Text = "0,00";
                    txtAcrescimo.Text = "0,00";
                    txtTroco.Text = "0,00";
                    txtValorPago.Text = "0,00";

                    txtComanda.Clear();
                    break;
            }
        }

        private Comanda CheckComanda()
        {
            var comanda = service.GetComandaRepository().Get(txtComanda.Text);
            if (comanda == null)
            {
                comanda = service.GetComandaRepository().GetByNome(txtComanda.Text);
            }
            return comanda;
        }

        private Entities.Produto CheckProduto()
        {
            var find = txtComanda.Text;
            Entities.Produto produto;
            produto = service.GetProdutoRepository().GetByCodigoBarra(find);
            if (produto == null)
            {
                produto = service.GetProdutoRepository().GetByNome(find);
            }

            return produto;
        }

        private void FecharVenda()
        {
            if (this.itens.Count == 0)
            {
                return;
            }

            try
            {
                var EmAberto = false;
                Venda venda = null;
                //Comanda 1 - Caixa
                //Comanda 2 - Consumo
                if (_comanda.Id > 2)
                {
                    EmAberto = MessageBox.Show("Deseja encerrar venda?", "Fechar Venda?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes;
                    venda = service.GetVendaRepository().GetVendasEmAberto(_comanda);
                }

                if (venda == null)
                {
                    venda = new Venda
                    {
                        DataVenda = DateTime.Now
                    };
                }
                else
                {
                    //Adiciono tudo novamente
                    venda.ItemVenda.Clear();
                }

                if (calculo == null)
                {
                    calculo = new CalculoVenda();
                    calculo.ValorD = itens.ToList().Sum(x => x.Quantidade * x.Valor);
                    calculo.ValorPago = calculo.ValorD;
                }
                venda.Comanda = _comanda;
                venda.ValorAcrescimo = calculo.Acrescimo;
                venda.ValorDesconto = calculo.Desconto;
                venda.ValorCC = calculo.ValorCC;
                venda.ValorCD = calculo.ValorCD;
                venda.ValorD = calculo.ValorD;
                venda.EmAberto = EmAberto;
                venda.ValorPago = calculo.ValorPago;

                itens.ForEach(produto =>
                {
                    venda.ItemVenda.Add(produto);
                });

                service.GetVendaRepository().Save(venda);
                if (!EmAberto)
                {
                    service.GetVendaRepository().BaixarVenda(venda);
                }
                else
                {
                    if (venda != null)
                    {
                        service.GetVendaRepository().EntradaTerminal(venda, null);
                    }
                }

                ClearScreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCalcularFechar_Click(object sender, EventArgs e)
        {
            FecharVenda();
        }

        private void AtualizaCalculo(CalculoVenda calculo)
        {
            calculo.ValorVenda = itens.ToList().Sum(x => x.Quantidade * x.Valor);
            var valores = calculo.ValorCC + calculo.ValorCD + calculo.ValorD;
            calculo.ValorPago = valores;

            calculo.ValorVenda += calculo.Acrescimo;
            calculo.ValorVenda -= calculo.Desconto;

            var troco = calculo.ValorPago - calculo.ValorVenda;

            txtDesconto.Text = string.Format("{0:N}", calculo.Desconto);
            txtAcrescimo.Text = string.Format("{0:N}", calculo.Acrescimo);
            txtValorPago.Text = string.Format("{0:N}", calculo.ValorPago);
            txtTroco.Text = string.Format("{0:N}", (calculo.ValorPago > 0 ? troco : 0));

            lblValorTotal.Text = string.Format("{0:N}", calculo.ValorVenda);
        }

        private void Calcular()
        {
            if (itens.Count == 0)
            {
                return;
            }
            using (var form = new Calculo(_venda))
            {
               
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    calculo = form.CalculoVenda;
                    AtualizaCalculo(calculo);
                }
            }

            txtComanda.Text = "";
            txtComanda.Focus();
        }

        private void CancelarItem()
        {
            if (itens.Count == 0)
            {
                return;
            }

            using (var form = new RemoverItem())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    try
                    {
                        itens.RemoveAt(--form.NumeroItem);

                        dataGridView1.Rows.Clear();
                        var index = 0;
                        itens.ForEach(item =>
                        {
                            index++;
                            dataGridView1.Rows.Add(new String[] { index.ToString(), item.Produto.Nome, item.Quantidade.ToString(), item.Valor.ToString(), (item.Valor * item.Quantidade).ToString() });
                        });

                        calculo = new CalculoVenda();
                        AtualizaCalculo(calculo);
                        lblQuantidadeItem.Text = "";
                    }
                    catch (Exception)
                    {
                        //Cliente pode colocar um indice fora da faixa, ignoro erro
                    }
                }
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Calcular();
        }

        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {
            ClearScreen(true);
        }

        private void Caixa_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    CancelarItem();
                    break;

                case Keys.F6:
                    _quantidadeAutomatica = !_quantidadeAutomatica;
                    lblQuantidadeAutomatica.Visible = _quantidadeAutomatica;
                    break;

                case Keys.F7:
                    Calcular();
                    break;

                case Keys.F8:
                    ClearScreen(true);
                    break;

                case Keys.F9:
                    FecharVenda();
                    break;

                case Keys.Escape:
                    Close();
                    break;
            }
        }

        private void Caixa_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void Caixa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_comanda != null)
            {
                MessageBox.Show("Comanda em aberto no caixa. Finalize a operação");
                e.Cancel = true;
            }
        }
    }
}