using Esquenta.Entities;
using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        private State CurrentState = State.AguardandoComanda;
        private ConnectionService service;

        //private List<Entities.Produto> itens = new List<Entities.Produto>();
        private List<Entities.ItemVenda> itens = new List<Entities.ItemVenda>();

        private decimal valorVenda = 0;
        private decimal valorPago = 0;
        private decimal valorDesconto = 0;
        private decimal valorAcrescimo = 0;

        private Comanda _comanda;
        private Entities.Produto _produto;

        private string CodigoBarrasCalcular = "8888888888888";
        private string CodigoBarrasFecharVenda = "9999999999994";
        private string CodigoBarrasCancelarVenda = "7777777777772";

        private AutoCompleteStringCollection produtosAutoComplete = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection comandasAutoComplete = new AutoCompleteStringCollection();

        public Caixa()
        {
            InitializeComponent();

            service = ConnectionService.GetInstance();
            lblStatus.Text = "Aguardando comanda";
            lblAberturaCaixa.Text = "Data de abertura do caixa: " + Properties.Settings.Default.AberturaCaixa;
            txtComanda.Focus();

            BarcodeLib.Barcode b = new BarcodeLib.Barcode();

            Image imgBarCodeCalcular = b.Encode(BarcodeLib.TYPE.EAN13, CodigoBarrasCalcular, Color.Black, Color.White, 100, 50);
            Image imgBarCodeFecharVenda = b.Encode(BarcodeLib.TYPE.EAN13, CodigoBarrasFecharVenda, Color.Black, Color.White, 100, 50);
            Image imgBarCodeCancelarVenda = b.Encode(BarcodeLib.TYPE.EAN13, CodigoBarrasCancelarVenda, Color.Black, Color.White, 100, 50);

            btnCalcularFechar.Image = imgBarCodeFecharVenda;
            btnCalcular.Image = imgBarCodeCalcular;
            btnCancelarVenda.Image = imgBarCodeCancelarVenda;

            var listaProduto = service.GetProdutoRepository().List();
            listaProduto.ForEach(produto =>
            {
                produtosAutoComplete.Add(produto.Nome);
            });

            var listaComanda = service.GetComandaRepository().List();
            listaComanda.ForEach(comanda =>
            {
                comandasAutoComplete.Add(comanda.Nome);
            });

            txtComanda.AutoCompleteCustomSource = comandasAutoComplete;
        }

        private void ClearScreen(bool forceDelete = false)
        {
            CurrentState = State.AguardandoComanda;

            dataGridView1.Rows.Clear();
            itens.Clear();

            if (_comanda != null && forceDelete && _comanda.Id > 2)
            {
                var deletar = MessageBox.Show("Cancelar venda registrada?", "Cancelar Venda?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
                if (deletar)
                {
                    var venda = service.GetVendaRepository().GetVendasEmAberto(_comanda);
                    if (venda != null)
                    {
                        service.GetVendaRepository().Delete(venda);
                    }
                }
            }

            _comanda = null;
            _produto = null;

            lblStatus.Text = "Aguardando comanda";
            lblValorTotal.Text = "0,00";
            lblNomeComanda.Text = "---";

            txtDesconto.Text = "0,00";
            txtAcrescimo.Text = "0,00";
            txtTroco.Text = "0,00";
            txtValorPago.Text = "0,00";

            txtComanda.Text = "";
            txtComanda.Focus();

            valorDesconto = 0;
            valorAcrescimo = 0;
            valorPago = 0;
            valorVenda = 0;

            txtComanda.AutoCompleteCustomSource = comandasAutoComplete;
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
            string comando = txtComanda.Text;
            if (comando.Equals(CodigoBarrasFecharVenda) && itens.Count > 0)
            {
                FecharVenda();
                return;
            }

            if (comando.Equals(CodigoBarrasCalcular) && itens.Count > 0)
            {
                Calcular();
                return;
            }
            if (comando.Equals(CodigoBarrasCancelarVenda) && itens.Count > 0)
            {
                ClearScreen();
                return;
            }

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
                        var venda = service.GetVendaRepository().GetVendasEmAberto(_comanda);
                        if (venda != null)
                        {
                            venda.ItemVenda.ForEach(item =>
                            {
                                item.Produto.Quantidade = item.Quantidade;
                                //item.Produto.Valor = item.Valor;
                                itens.Add(item);
                                dataGridView1.Rows.Add(new String[] { itens.Count.ToString(), item.Produto.Nome, item.Quantidade.ToString(), item.Valor.ToString(), (item.Valor * item.Quantidade).ToString() });
                            });
                            AtualizaCalculo(venda.ValorAcrescimo, venda.ValorDesconto, venda.ValorTotal);
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

                    var itemVenda = new ItemVenda();
                    itemVenda.Produto = _produto;
                    itemVenda.Valor = _produto.Valor;
                    using (var form = new Quantidade())
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            //_produto.Quantidade = form.Total;
                            itemVenda.Quantidade = form.Total;
                        }
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

                venda.Comanda = _comanda;
                venda.ValorDesconto = valorDesconto;
                venda.ValorAcrescimo = valorAcrescimo;
                venda.EmAberto = EmAberto;

                itens.ForEach(produto =>
                {
                    //var item = new ItemVenda
                    //{
                    //    Venda = venda,
                    //    Produto = produto,
                    //    Valor = produto.Valor,
                    //    Quantidade = produto.Quantidade
                    //};

                    //venda.ItemVenda.Add(item);
                    venda.ItemVenda.Add(produto);
                });

                service.GetVendaRepository().Save(venda);

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

        private void AtualizaCalculo(decimal desconto, decimal acrescimo, decimal valor)
        {
            valorVenda = 0;// itens.Select(x => x.Valor * x.Quantidade).Sum();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                valorVenda += decimal.Parse(dataGridView1.Rows[i].Cells["Valor"].Value.ToString());
            }

            valorDesconto = desconto;
            valorAcrescimo = acrescimo;
            valorPago = acrescimo > 0 ? acrescimo : valorVenda - valorDesconto + valorAcrescimo;
            valorVenda -= valorDesconto;
            valorVenda += valorAcrescimo;

            txtDesconto.Text = string.Format("{0:N}", valorDesconto);
            txtAcrescimo.Text = string.Format("{0:N}", valorAcrescimo);
            //txtValorPago.Text = string.Format("{0:N}", valorPago);
            //txtTroco.Text = string.Format("{0:N}", Math.Max(0, (valorPago - valorVenda)));
            txtValorPago.Text = string.Format("{0:N}", valor);
            txtTroco.Text = string.Format("{0:N}", Math.Max(0, (valor - valorVenda)));
            lblValorTotal.Text = string.Format("{0:N}", valorVenda);
        }

        private void Calcular()
        {
            if (this.itens.Count == 0)
            {
                return;
            }
            using (var form = new Calculo())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    AtualizaCalculo(form.Desconto, form.Acrescimo, form.Valor);
                }
            }

            txtComanda.Text = "";
            txtComanda.Focus();
        }

        private void CancelarItem()
        {
            if (this.itens.Count == 0)
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
                        AtualizaCalculo(0, 0, 0);
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
    }
}