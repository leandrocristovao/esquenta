using Esquenta.Forms.Caixa;
using Esquenta.Forms.Produto;
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
            new Caixa().ShowDialog();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            new ListaProduto().ShowDialog();
        }

        private void bntRelatorio_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Relatórios");
        }
    }
}