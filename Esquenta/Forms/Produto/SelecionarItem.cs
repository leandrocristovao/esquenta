using Esquenta.Components;
using Esquenta.Forms.Caixa;
using System;
using System.Windows.Forms;

namespace Esquenta.Forms.Produto
{
    public partial class SelecionarItem : Form
    {
        public string CodigoBarras;
        public long Quantidade;

        public SelecionarItem()
        {
            InitializeComponent();
        }

        private void txtCodigoBarras_TextChanged(object sender, EventArgs e)
        {
            TextBoxEnter.TextChanged(sender, e);
        }

        private void txtCodigoBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CodigoBarras = txtCodigoBarras.Text;
                using (var form = new Quantidade())
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Quantidade = form.Total;

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
        }
    }
}