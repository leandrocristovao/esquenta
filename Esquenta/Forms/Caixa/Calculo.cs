using System;
using System.Globalization;
using System.Windows.Forms;
using Esquenta.Components;
using Esquenta.Entities;

namespace Esquenta.Forms.Caixa
{
    public partial class Calculo : Form
    {
        private readonly Venda _venda;

        public Calculo()
        {
            InitializeComponent();
        }

        public Calculo(Venda venda)
        {
            InitializeComponent();
            _venda = venda ?? new Venda();

            var culture = new CultureInfo("pt-BR");
            txtAcrescimo.Text = _venda.ValorAcrescimo.ToString(culture);
            txtCC.Text = _venda.ValorCC.ToString(culture);
            txtCD.Text = _venda.ValorCD.ToString(culture);
            txtD.Text = _venda.ValorD.ToString(culture);
            txtDesconto.Text = _venda.ValorDesconto.ToString(culture);
        }

        public CalculoVenda CalculoVenda { get; set; }

        private void txtDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
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
            decimal.TryParse(txtDesconto.Text, NumberStyles.Any, new CultureInfo("pt-BR"), out var desconto);
            decimal.TryParse(txtAcrescimo.Text, NumberStyles.Any, new CultureInfo("pt-BR"), out var valorAcrescimo);
            decimal.TryParse(txtCC.Text, NumberStyles.Any, new CultureInfo("pt-BR"), out var valorCc);
            decimal.TryParse(txtCD.Text, NumberStyles.Any, new CultureInfo("pt-BR"), out var valorCd);
            decimal.TryParse(txtD.Text, NumberStyles.Any, new CultureInfo("pt-BR"), out var valorD);

            var valorPago = valorAcrescimo + valorCc + valorCd + valorD - desconto;

            CalculoVenda = new CalculoVenda
            {
                Acrescimo = valorAcrescimo,
                Desconto = desconto,
                ValorCC = valorCc,
                ValorCD = valorCd,
                ValorD = valorD,
                ValorPago = valorPago
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}