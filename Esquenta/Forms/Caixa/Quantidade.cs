using Esquenta.Components;
using System;
using System.Windows.Forms;

namespace Esquenta.Forms.Caixa
{
    public partial class Quantidade : Form
    {
        public long Total;

        public Quantidade()
        {
            InitializeComponent();
        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            TextBoxEnter.TextChanged(sender, e);
        }

        private void txtQuantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                long total = 0;
                long.TryParse(txtQuantidade.Text, out total);
                Total = total;

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void Quantidade_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuantidade.Text))
            {
                txtQuantidade.Focus();
                e.Cancel = true;
            }
        }
    }
}