using Esquenta.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esquenta.Forms.Produto
{
    public partial class AddEntradaEstoque : Form
    {
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }

        public AddEntradaEstoque()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Quantidade = int.Parse(txtQuantidade.Text);
            Valor = decimal.Parse(txtValor.Text);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            TextBoxEnter.TextChanged(sender, e);
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            TextBoxEnter.TextChanged(sender, e);
        }
    }
}
