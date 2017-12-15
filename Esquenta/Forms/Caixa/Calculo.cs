using Esquenta.Components;
using System;
using System.Windows.Forms;

namespace Esquenta.Forms.Caixa
{
    public class CalculoVenda
    {
        public decimal Desconto { get; set; }
        public decimal Acrescimo { get; set; }
        public decimal ValorCC { get; set; }
        public decimal ValorCD { get; set; }
        public decimal ValorD { get; set; }
        public decimal Valor { get; set; }
    }
    public partial class Calculo : Form
    {

        public decimal Desconto { get; set; }
        public decimal Acrescimo { get; set; }
        public decimal Valor { get; set; }

        public Calculo()
        {
            InitializeComponent();
        }

        private void txtDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAcrescimo.Focus();
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

                decimal valorAcrescimo = 0;
                decimal.TryParse(txtAcrescimo.Text, out valorAcrescimo);

                Desconto = desconto;
                Valor = valorPago;
                Acrescimo = valorAcrescimo;

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

            if (string.IsNullOrEmpty(txtAcrescimo.Text))
            {
                txtAcrescimo.Focus();
                e.Cancel = true;
            }

            if (string.IsNullOrEmpty(txtValorPago.Text))
            {
                txtValorPago.Focus();
                e.Cancel = true;
            }
        }

        private void txtAcrescimo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtValorPago.Focus();
            }
        }
    }
}