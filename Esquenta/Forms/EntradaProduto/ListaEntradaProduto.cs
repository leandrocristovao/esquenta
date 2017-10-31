using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Esquenta.Forms.EntradaProduto
{
    public partial class ListaEntradaProduto : Form
    {
        private List<Entities.EntradaProduto> lista;
        private ConnectionService service;

        public ListaEntradaProduto()
        {
            InitializeComponent();

            service = ConnectionService.GetInstance();
        }

        private void ListaEntradaProduto_Load(object sender, EventArgs e)
        {
            ReloadList();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            new AddEntradaProduto(service).ShowDialog();
            ReloadList();
        }

        private void ReloadList()
        {
            dataGridView1.Rows.Clear();
            lista = service.GetEntradaProdutoRepository().List();
            lista.ForEach(item =>
            {
                string id = item.Id.ToString();
                string data = item.DataEntrada.ToString("dd/MM/yyyy");
                string produto = item.Produto.Nome;
                string quantidade = item.Quantidade.ToString();
                string valor = item.Valor.ToString();

                dataGridView1.Rows.Add(new string[] { id, data, produto, quantidade, valor });
            });
        }

        private void ListaEntradaProduto_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
            }
        }
    }
}