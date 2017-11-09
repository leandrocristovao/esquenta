using Esquenta.Components;
using System;
using System.Windows.Forms;

namespace Esquenta.Forms.Caixa
{
    public partial class RemoverItem : Form
    {
        public int NumeroItem;

        public RemoverItem()
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
                int total = 0;
                int.TryParse(txtNumeroItem.Text, out total);
                NumeroItem = total;

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void Quantidade_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumeroItem.Text))
            {
                txtNumeroItem.Focus();
                e.Cancel = true;
            }
        }

        private void RemoverItem_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();

            }
        }
    }
}