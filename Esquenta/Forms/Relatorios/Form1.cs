using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esquenta.Forms.Relatorios
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'vendasMDDataSet.Venda' table. You can move, or remove it, as needed.
            this.vendaTableAdapter.Fill(this.vendasMDDataSet.Venda);
            itemVendaTableAdapter1.Fill(this.vendasMDDataSet.ItemVenda);
            //var service = ConnectionService.GetInstance();
            //var lista = service.GetVendaRepository().List(); ;

            //gridControl1.DataSource = lista;
        }
    }
}
