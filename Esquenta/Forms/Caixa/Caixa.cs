using Esquenta.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Esquenta.Forms.Caixa
{
    public partial class Caixa : Form
    {
        private ConnectionService service;
        private List<Entities.Produto> itens = new List<Entities.Produto>();

        public Caixa()
        {
            InitializeComponent();
            service = ConnectionService.GetInstance();
            lblAberturaCaixa.Text = "Data de abertura do caixa: " + Properties.Settings.Default.AberturaCaixa;
            txtComanda.Focus();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                int comandaID = int.Parse(txtComanda.Text);
                var comanda = service.GetComandaRepository().Get(comandaID);
                if (comanda == null)
                {
                    throw new Exception("Comanda inválida");
                }

                var venda = new Venda();
                venda.Comanda = comanda;
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

        private void ClearScreen()
        {
            dataGridView1.Rows.Clear();
            itens.Clear();
            lblValorTotal.Text = "R$ 0,00";
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                int produtoID = int.Parse(txtProduto.Text);
                var produto = service.GetProdutoRepository().Get(produtoID);
                if (produto == null)
                {
                    throw new Exception("Produto não cadastrado.");
                }
                itens.Add(produto);

                var total = itens.Sum(x => x.Valor);
                lblValorTotal.Text = string.Format("R$ {0}", total);

                dataGridView1.Rows.Add(new String[] { produto.Nome, produto.Valor.ToString() });
                txtComanda.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtComanda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtProduto.Focus();
            }
        }

        private void txtProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdicionar.Focus();
            }
        }
    }
}