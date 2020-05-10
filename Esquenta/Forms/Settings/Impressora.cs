using System;
using System.Windows.Forms;

namespace Esquenta.Forms.Settings
{
    public partial class Impressora : Form
    {
        public Impressora()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Program.SaveImpressora(cbImpressora.SelectedItem.ToString(), txtMensagem.Text, int.Parse(txtLinha.Text));
            Close();
        }

        private void Impressora_Load(object sender, EventArgs e)
        {
            cbImpressora.Items.Clear();
            foreach (var printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cbImpressora.Items.Add(printer);
            }

            txtFonte.Text = ""+Properties.Settings.Default.ImpressoraFontSize;
            txtLinha.Text = Properties.Settings.Default.ImpressoraLinha.ToString();
            txtMensagem.Text = Properties.Settings.Default.ImpressoraMensagem;
        }
    }
}