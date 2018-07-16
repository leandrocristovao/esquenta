using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Esquenta.Entities;
using NHibernate.Util;

namespace Esquenta.Forms.Caixa
{
    public partial class Caixa : Form
    {
        private readonly AutoCompleteStringCollection _comandasAutoComplete = new AutoCompleteStringCollection();
        private readonly List<ItemVenda> _itens = new List<ItemVenda>();
        private readonly AutoCompleteStringCollection _produtosAutoComplete = new AutoCompleteStringCollection();
        private readonly ConnectionService _service;
        private CalculoVenda _calculo;
        private Comanda _comanda;
        private State _currentState = State.AguardandoComanda;
        private bool _quantidadeAutomatica;
        private Venda _venda;

        public Caixa()
        {
            InitializeComponent();

            _service = ConnectionService.GetInstance();

            var periodo = _service.GetPeriodoVendaRepository().GetPeriodoAtual();
            lblStatus.Text = @"Aguardando comanda";
            txtComanda.Focus();

            var listaProduto = _service.GetProdutoRepository().List();
            listaProduto.Where(x => x.Valor > 0).ForEach(produto => { _produtosAutoComplete.Add(produto.Nome); });

            var listaComanda = _service.GetComandaRepository().List();
            listaComanda.ForEach(comanda => { _comandasAutoComplete.Add(comanda.Nome); });

            txtComanda.AutoCompleteCustomSource = _comandasAutoComplete;
            lblQuantidadeItem.Text = "";
        }

        private void ClearScreen(bool forceDelete = false)
        {
            _currentState = State.AguardandoComanda;

            dataGridView1.Rows.Clear();
            _itens.Clear();

            if (_comanda != null && forceDelete && _comanda.Id > 2)
            {
                var venda = _service.GetVendaRepository().GetVendasEmAberto(_comanda);
                var deletar = MessageBox.Show(@"Cancelar venda registrada?", @"Cancelar Venda?", MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
                if (deletar)
                {
                    if (venda != null) _service.GetVendaRepository().Delete(venda);
                }
                else
                {
                    if (venda.Id > 2 && !string.IsNullOrEmpty(venda.Terminal)) ;
                    _service.GetVendaRepository().EntradaTerminal(venda, null);
                }
            }

            lblStatus.Text = @"Aguardando comanda";
            lblValorTotal.Text = @"0,00";
            lblNomeComanda.Text = @"---";

            txtDesconto.Text = @"0,00";
            txtAcrescimo.Text = @"0,00";
            txtTroco.Text = @"0,00";
            txtValorPago.Text = @"0,00";

            txtComanda.Text = "";
            txtComanda.Focus();

            _calculo = null;
            _comanda = null;
            _venda = new Venda();

            txtComanda.AutoCompleteCustomSource = _comandasAutoComplete;
            lblQuantidadeItem.Text = "";
        }

        private void txtComanda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (!string.IsNullOrEmpty(txtComanda.Text))
                    ProcessState();
        }

        private void ProcessState()
        {
            switch (_currentState)
            {
                case State.AguardandoComanda:
                    //Recupero comanda
                    _comanda = CheckComanda();
                    if (_comanda == null)
                    {
                        MessageBox.Show(@"Comanda inválida");
                        txtComanda.Clear();
                        return;
                    }

                    _currentState = State.AguardandoProduto;
                    lblStatus.Text = @"Aguardando Produto";
                    lblNomeComanda.Text = _comanda.Nome;
                    txtComanda.Clear();

                    txtComanda.AutoCompleteCustomSource = _produtosAutoComplete;

                    if (_comanda.Id > 2)
                    {
                        //itens
                        var vendaService = _service.GetVendaRepository();
                        _venda = vendaService.GetVendasEmAberto(_comanda);

                        if (_venda != null)
                        {
                            if (!string.IsNullOrEmpty(_venda.Terminal) &&
                                !_venda.Terminal.Equals(Environment.MachineName))
                            {
                                MessageBox.Show(string.Format(@"Comanda aberta no terminal {0}", _venda.Terminal));
                                ClearScreen();
                            }
                            else
                            {
                                vendaService.EntradaTerminal(_venda, Environment.MachineName);
                                _venda.ItemVenda.ForEach(item =>
                                {
                                    _itens.Add(item);
                                    dataGridView1.Rows.Add(_itens.Count.ToString(), item.Produto.Nome,
                                        item.Quantidade.ToString(), item.Valor.ToString(),
                                        (item.Valor * item.Quantidade).ToString());
                                });

                                _calculo = new CalculoVenda
                                {
                                    Acrescimo = _venda.ValorAcrescimo,
                                    Desconto = _venda.ValorDesconto,
                                    ValorCC = _venda.ValorCC,
                                    ValorCD = _venda.ValorCD,
                                    ValorD = _venda.ValorD,
                                    ValorPago = _venda.ValorPago
                                };
                                AtualizaCalculo(_calculo);
                            }
                        }
                    }

                    break;

                case State.AguardandoProduto:
                    if (_comanda == null)
                    {
                        MessageBox.Show(@"Comanda não cadastrada");
                        txtComanda.Clear();
                        return;
                    }

                    //Recupero Produto
                    var _produto = CheckProduto();
                    if (_produto == null)
                    {
                        MessageBox.Show(@"Produto não cadastrado");
                        txtComanda.Clear();
                        return;
                    }

                    var estoque = new List<string>();
                    _produto.Itens.Where(x => x.Produto.Quantidade <= x.Produto.QuantidadeMinima).ForEach(item =>
                    {
                        estoque.Add(
                            $@"Produto {item.Produto.Nome} está com o estoque baixo: {item.Produto.Quantidade}");
                    });
                    if (estoque.Count > 0) lblQuantidadeItem.Text = string.Join("\n", estoque.ToArray());

                    var itemVenda = new ItemVenda
                    {
                        Produto = _produto,
                        Valor = _produto.Valor,
                        DataVenda = DateTime.Now
                    };

                    if (!_quantidadeAutomatica)
                        using (var form = new Quantidade())
                        {
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK) itemVenda.Quantidade = form.Total;
                        }
                    else
                        itemVenda.Quantidade = 1;

                    itemVenda.ValorTotal = itemVenda.Quantidade * itemVenda.Valor;
                    _itens.Add(itemVenda);

                    dataGridView1.Rows.Add(_itens.Count.ToString(), itemVenda.Produto.Nome,
                        itemVenda.Quantidade.ToString(), itemVenda.Valor.ToString(),
                        (itemVenda.Valor * itemVenda.Quantidade).ToString());

                    decimal valorVenda = 0;
                    for (var i = 0; i < dataGridView1.Rows.Count; i++)
                        valorVenda += decimal.Parse(dataGridView1.Rows[i].Cells["Valor"].Value.ToString());

                    lblValorTotal.Text = string.Format(@"{0:N}", valorVenda);

                    txtDesconto.Text = @"0,00";
                    txtAcrescimo.Text = @"0,00";
                    txtTroco.Text = @"0,00";
                    txtValorPago.Text = @"0,00";

                    txtComanda.Clear();
                    break;
            }
        }

        private Comanda CheckComanda()
        {
            var comanda = _service.GetComandaRepository().Get(txtComanda.Text);
            if (comanda == null) comanda = _service.GetComandaRepository().GetByNome(txtComanda.Text);
            return comanda;
        }

        private Entities.Produto CheckProduto()
        {
            var find = txtComanda.Text;
            Entities.Produto produto;
            produto = _service.GetProdutoRepository().GetByCodigoBarra(find);
            if (produto == null) produto = _service.GetProdutoRepository().GetByNome(find);

            return produto;
        }

        private void FecharVenda()
        {
            if (_itens.Count == 0) return;

            try
            {
                var EmAberto = false;
                Venda venda = null;
                //Comanda 1 - Caixa
                //Comanda 2 - Consumo
                if (_comanda.Id > 2)
                {
                    EmAberto = MessageBox.Show(@"Deseja encerrar venda?", @"Fechar Venda?", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes;
                    venda = _service.GetVendaRepository().GetVendasEmAberto(_comanda);
                }

                if (venda == null)
                    venda = new Venda
                    {
                        DataVenda = DateTime.Now
                    };
                else
                    venda.ItemVenda.Clear();

                if (_calculo == null)
                {
                    _calculo = new CalculoVenda {ValorD = _itens.ToList().Sum(x => x.Quantidade * x.Valor)};
                    _calculo.ValorPago = _calculo.ValorD;
                }

                venda.Comanda = _comanda;
                venda.ValorAcrescimo = _calculo.Acrescimo;
                venda.ValorDesconto = _calculo.Desconto;
                venda.ValorCC = _calculo.ValorCC;
                venda.ValorCD = _calculo.ValorCD;
                venda.ValorD = _calculo.ValorD;
                venda.EmAberto = EmAberto;
                venda.ValorPago = _calculo.ValorPago;

                _itens.ForEach(produto => { venda.ItemVenda.Add(produto); });

                _service.GetVendaRepository().Save(venda);
                if (!EmAberto)
                {
                    _service.GetVendaRepository().BaixarVenda(venda);
                }
                else
                {
                    if (venda != null) _service.GetVendaRepository().EntradaTerminal(venda, null);
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
            calculo.ValorVenda = _itens.ToList().Sum(x => x.Quantidade * x.Valor);
            var valores = calculo.ValorCC + calculo.ValorCD + calculo.ValorD;
            calculo.ValorPago = valores;

            calculo.ValorVenda += calculo.Acrescimo;
            calculo.ValorVenda -= calculo.Desconto;

            var troco = calculo.ValorPago - calculo.ValorVenda;

            txtDesconto.Text = $@"{calculo.Desconto:N}";
            txtAcrescimo.Text = $@"{calculo.Acrescimo:N}";
            txtValorPago.Text = $@"{calculo.ValorPago:N}";
            txtTroco.Text = $@"{(calculo.ValorPago > 0 ? troco : 0):N}";
            lblValorTotal.Text = $@"{calculo.ValorVenda:N}";

            if (_venda == null) _venda = new Venda();

            //Se usuario nao preencher nada, considero que foi pago em $$ OU sera a diferenca do valor debito/credito
            calculo.ValorD = calculo.ValorVenda - (calculo.ValorCC + calculo.ValorCD);
            if (calculo.ValorPago == 0)
                calculo.ValorPago = calculo.ValorD + calculo.ValorCC + calculo.ValorCD + calculo.Acrescimo -
                                    calculo.Desconto;
            _calculo = calculo;

            _venda.ValorAcrescimo = calculo.Acrescimo;
            _venda.ValorDesconto = calculo.Desconto;
            _venda.ValorCC = calculo.ValorCC;
            _venda.ValorCD = calculo.ValorCD;
            _venda.ValorD = calculo.ValorD;
        }

        private void Calcular()
        {
            if (_itens.Count == 0) return;
            using (var form = new Calculo(_venda))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _calculo = form.CalculoVenda;
                    AtualizaCalculo(_calculo);
                }
            }

            txtComanda.Text = "";
            txtComanda.Focus();
        }

        private void CancelarItem()
        {
            if (_itens.Count == 0) return;

            using (var form = new RemoverItem())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                    try
                    {
                        _itens.RemoveAt(--form.NumeroItem);

                        dataGridView1.Rows.Clear();
                        var index = 0;
                        _itens.ForEach(item =>
                        {
                            index++;
                            dataGridView1.Rows.Add(index.ToString(), item.Produto.Nome, item.Quantidade.ToString(),
                                item.Valor.ToString(), (item.Valor * item.Quantidade).ToString());
                        });

                        _calculo = new CalculoVenda();
                        AtualizaCalculo(_calculo);
                        lblQuantidadeItem.Text = "";
                    }
                    catch (Exception)
                    {
                        //Cliente pode colocar um indice fora da faixa, ignoro erro
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

        private void Caixa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_comanda != null)
            {
                MessageBox.Show("Comanda em aberto no caixa. Finalize a operação");
                e.Cancel = true;
            }
        }

        private enum State
        {
            AguardandoComanda = 1,
            AguardandoProduto = 2
        }
    }
}