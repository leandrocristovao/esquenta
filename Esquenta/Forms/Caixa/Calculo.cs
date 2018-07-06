using Esquenta.Components;
using System;
using System.Windows.Forms;
using Esquenta.Entities;

namespace Esquenta.Forms.Caixa
{
    public partial class Calculo : Form
    {
        public CalculoVenda CalculoVenda { get; set; }
        private Venda _venda;

        public Calculo()
        {
            InitializeComponent();
        }
        public Calculo(Venda venda)
        {
            InitializeComponent();
            _venda = venda??new Venda();

            txtAcrescimo.Text = string.Format("{0:N}", _venda.ValorAcrescimo);
            txtCC.Text = string.Format("{0:N}", _venda.ValorCC);
            txtCD.Text = string.Format("{0:N}", _venda.ValorCD);
            txtD.Text = string.Format("{0:N}", _venda.ValorD);
            txtDesconto.Text = string.Format("{0:N}", _venda.ValorDesconto);
        }

        private void txtDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
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

            if (string.IsNullOrEmpty(txtCC.Text))
            {
                txtCC.Focus();
                e.Cancel = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            decimal desconto = 0;
            decimal.TryParse(txtDesconto.Text, out desconto);

            decimal valorAcrescimo = 0;
            decimal.TryParse(txtAcrescimo.Text, out valorAcrescimo);

            decimal valorCC = 0;
            decimal.TryParse(txtCC.Text, out valorCC);

            decimal valorCD = 0;
            decimal.TryParse(txtCD.Text, out valorCD);

            decimal valorD = 0;
            decimal.TryParse(txtD.Text, out valorD);

            decimal valorPago = (valorAcrescimo + valorCC + valorCD + valorD) - desconto;

            CalculoVenda = new CalculoVenda
            {
                Acrescimo = valorAcrescimo,
                Desconto = desconto,
                ValorCC = valorCC,
                ValorCD = valorCD,
                ValorD = valorD,
                ValorPago = valorPago
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}