using Esquenta.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        private State CurrentState = State.AguardandoComanda;
        private ConnectionService service;
        private List<Entities.Produto> itens = new List<Entities.Produto>();
        private decimal valorVenda = 0;
        private decimal valorPago = 0;
        private decimal valorDesconto = 0;
        private decimal valorAcrescimo = 0;

        private Comanda _comanda;
        private Entities.Produto _produto;

        private string CodigoBarrasCalcular = "8888888888888";
        private string CodigoBarrasFecharVenda = "9999999999994";
        private string CodigoBarrasCancelarVenda = "7777777777772";

        private List<Entities.Produto> produtosAutoComplete = new List<Entities.Produto>();

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

            produtosAutoComplete = service.GetProdutoRepository().List();
            produtosAutoComplete.ForEach(produto =>
            {
                txtComanda.AutoCompleteCustomSource.Add(produto.Nome);
            });

        }

        private void ClearScreen()
        {
            CurrentState = State.AguardandoComanda;

            dataGridView1.Rows.Clear();
            itens.Clear();

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
        }

        private void txtComanda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProcessState();
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
                    break;

                case State.AguardandoProduto:
                    if (_comanda == null)
                    {
                        MessageBox.Show("Comanda não cadastrada");
                        txtComanda.Clear();
                        return;
                    }
                    //Recupero Produto
                    _produto = CheckProduto();
                    if (_produto == null)
                    {
                        MessageBox.Show("Produto não cadastrado");
                        txtComanda.Clear();
                        return;
                    }

                    using (var form = new Quantidade())
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            _produto.Quantidade = form.Total;
                        }
                    }

                    itens.Add(_produto);
                    //var xxx = itens.GroupBy(i => i).Select(c => new { Key = c.Key, total = c.Sum(x => x.Quantidade) });
                    //var xxx = itens.SelectMany(x=> x.Itens).GroupBy(i => i.Produto).Select(c => new { Key = c.Key, total = c.Sum(x => x.Quantidade) });

                    dataGridView1.Rows.Add(new String[] { _produto.Nome, _produto.Quantidade.ToString(), _produto.Valor.ToString(), (_produto.Valor * _produto.Quantidade).ToString() });

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
            return service.GetComandaRepository().Get(txtComanda.Text);
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
                var venda = new Venda
                {
                    Comanda = _comanda,
                    DataVenda = DateTime.Now,
                    ValorDesconto = valorDesconto,
                    ValorAcrescimo = valorAcrescimo
                };

                itens.ForEach(produto =>
                {
                    var item = new ItemVenda
                    {
                        Venda = venda,
                        Produto = produto,
                        Valor = produto.Valor,
                        Quantidade = produto.Quantidade
                    };

                    venda.ItemVenda.Add(item);
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
                    valorVenda = 0;// itens.Select(x => x.Valor * x.Quantidade).Sum();
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        valorVenda += decimal.Parse(dataGridView1.Rows[i].Cells["Valor"].Value.ToString());
                    }

                    valorDesconto = form.Desconto;
                    valorAcrescimo = form.Acrescimo;
                    valorPago = form.Valor > 0 ? form.Valor : valorVenda - valorDesconto + valorAcrescimo;
                    valorVenda -= valorDesconto;
                    valorVenda += valorAcrescimo;

                    txtDesconto.Text = string.Format("{0:N}", valorDesconto);
                    txtAcrescimo.Text = string.Format("{0:N}", valorAcrescimo);
                    txtValorPago.Text = string.Format("{0:N}", valorPago);
                    txtTroco.Text = string.Format("{0:N}", (valorPago - valorVenda));
                    lblValorTotal.Text = string.Format("{0:N}", valorVenda);
                }
            }

            txtComanda.Text = "";
            txtComanda.Focus();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Calcular();
        }

        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {
            ClearScreen();
        }

        private void Caixa_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F7:
                    Calcular();
                    break;

                case Keys.F8:
                    ClearScreen();
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