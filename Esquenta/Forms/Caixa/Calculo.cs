using Esquenta.Components;
using System;
using System.Windows.Forms;

namespace Esquenta.Forms.Caixa
{
    public partial class Calculo : Form
    {
        public decimal Desconto { get; set; }
        public decimal Valor { get; set; }

        public Calculo()
        {
            InitializeComponent();
        }

        private void txtDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtValorPago.Focus();
            }
        }

        private void txtValorPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                decimal desconto = 0;
                decimal.TryParse(txtDesconto.Text, out desconto);

                decimal valorPago = 0;
                decimal.TryParse(txtValorPago.Text, out valorPago);

                Desconto = desconto;
                Valor = valorPago;

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void txtDesconto_TextChanged(object sender, EventArgs e)
        {
            TextBoxEnter.TextChanged(sender, e);
        }

        private void Calculo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDesconto.Text))
            {
                txtDesconto.Focus();
                e.Cancel = true;
            }

            if (string.IsNullOrEmpty(txtValorPago.Text))
            {
                txtValorPago.Focus();
                e.Cancel = true;
            }

        }
    }
}