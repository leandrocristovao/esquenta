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
            Program.SaveImpressora(cbImpressora.SelectedItem.ToString());
            Close();
        }

        private void Impressora_Load(object sender, EventArgs e)
        {
            cbImpressora.Items.Clear();
            foreach (var printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cbImpressora.Items.Add(printer);
            }
        }
    }
}