using Esquenta.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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
        private Comanda _comanda;
        private Entities.Produto _produto;
        private string CodigoBarrasFecharVenda = "9999999999994";

        public Caixa()
        {
            InitializeComponent();

            service = ConnectionService.GetInstance();
            lblStatus.Text = "Aguardando comanda";
            lblAberturaCaixa.Text = "Data de abertura do caixa: " + Properties.Settings.Default.AberturaCaixa;
            txtComanda.Focus();

            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            Image imgBarCodeFecharVenda = b.Encode(BarcodeLib.TYPE.EAN13, "9999999999999", Color.Black, Color.White, 100, 25);
            imgFecharConta.Image = imgBarCodeFecharVenda;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            FecharVenda();
        }

        private void ClearScreen()
        {
            dataGridView1.Rows.Clear();
            itens.Clear();
            lblValorTotal.Text = "R$ 0,00";
            valorVenda = 0;
            txtComanda.Text = "";
            lblStatus.Text = "Aguardando comanda";
        }

        private void txtComanda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProcessState();
            }
        }

        private void txtValorPago_TextChanged(object sender, EventArgs e)
        {
            var strValue = ((TextBox)sender).Text;
            decimal decValue = 0;
            decimal.TryParse(strValue, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out decValue);

            txtTroco.Text = (decValue - valorVenda).ToString();
        }

        private void ProcessState()
        {
            string comando = txtComanda.Text;
            if (comando.Equals(CodigoBarrasFecharVenda) && itens.Count > 0)
            {
                FecharVenda();
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

                    itens.Add(_produto);

                    valorVenda = itens.Sum(x => x.Valor);
                    lblValorTotal.Text = string.Format("R$ {0}", valorVenda);

                    dataGridView1.Rows.Add(new String[] { _produto.Nome, _produto.Valor.ToString() });
                    //txtComanda.Focus();
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
            var produto = service.GetProdutoRepository().Get(txtComanda.Text);
            return produto;
        }

        private void FecharVenda()
        {
            try
            {
                var venda = new Venda();
                venda.Comanda = _comanda;
                venda.DataVenda = DateTime.Now;

                itens.ForEach(produto =>
                {
                    var item = new ItemVenda();
                    item.Venda = venda;
                    item.Produto = produto;
                    item.Valor = produto.Valor;

                    venda.ItemVenda.Add(item);
                });

                service.GetVendaRepository().Save(venda);

                ClearScreen();
                txtComanda.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}