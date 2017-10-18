using Esquenta.Forms.Caixa;
using Esquenta.Forms.Comandas;
using Esquenta.Forms.Produto;
using Esquenta.Forms.Relatorios;
using System;
using System.Windows.Forms;

namespace Esquenta
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            new ConnectionService();
        }

        private void btnCaixa_Click(object sender, EventArgs e)
        {
        }

        private void bntRelatorio_Click(object sender, EventArgs e)
        {
        }

        private void btnCadastroProdutos_Click(object sender, EventArgs e)
        {
            new ListaProduto().ShowDialog();
        }

        private void bntCadastroComandas_Click(object sender, EventArgs e)
        {
        }

        private void menuItemProdutos_Click(object sender, EventArgs e)
        {
            var form = new ListaProduto();
            form.MdiParent = this;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }

        private void menuItemComandas_Click(object sender, EventArgs e)
        {
            var form = new ListaComanda();
            form.MdiParent = this;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }

        private void menuItemCaixa_Click(object sender, EventArgs e)
        {
            var form = new Caixa();
            form.MdiParent = this;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }

        private void menuItemLivroCaixa_Click(object sender, EventArgs e)
        {
            var form = new Vendas();
            form.MdiParent = this;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }

        private void menuItemEntradaProduto_Click(object sender, EventArgs e)
        {
            var form = new Esquenta.Forms.EntradaProduto.ListaEntradaProduto();
            form.MdiParent = this;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }
    }
}