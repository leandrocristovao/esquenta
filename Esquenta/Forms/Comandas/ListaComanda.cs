using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Esquenta.Forms.Comandas
{
    public partial class ListaComanda : Form
    {
        private List<Entities.Comanda> lista;
        private ConnectionService service;

        public ListaComanda()
        {
            InitializeComponent();
            service = ConnectionService.GetInstance();
        }

        private void ListaComanda_Load(object sender, EventArgs e)
        {
            ReloadList();
        }

        private void ReloadList()
        {
            lista = service.GetService<Entities.Comanda>().List();
            dataGridView1.DataSource = lista;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var comanda = lista[e.RowIndex];
            new AddComanda(service, comanda).ShowDialog();
            ReloadList();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            new AddComanda(service).ShowDialog();
            ReloadList();
        }
    }
}