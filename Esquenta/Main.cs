using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esquenta
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnCaixa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Caixa");
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cadastros");
        }

        private void bntRelatorio_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Relatórios");
        }
    }
}
