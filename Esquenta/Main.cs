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
            MessageBox.Show(Properties.Settings.Default.AberturaCaixa.ToString());
        }

        private void btnCaixa_Click(object sender, EventArgs e)
        {
            new Caixa().ShowDialog();
        }



        private void bntRelatorio_Click(object sender, EventArgs e)
        {
            new Vendas().ShowDialog();
        }

        private void btnCadastroProdutos_Click(object sender, EventArgs e)
        {
            new ListaProduto().ShowDialog();
        }

        private void bntCadastroComandas_Click(object sender, EventArgs e)
        {
            new ListaComanda().ShowDialog();
        }
    }
}