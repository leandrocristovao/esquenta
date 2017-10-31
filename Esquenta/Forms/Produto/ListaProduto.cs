using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Esquenta.Forms.Produto
{
    public partial class ListaProduto : Form
    {
        private List<Entities.Produto> lista;
        private ConnectionService service;

        public ListaProduto()
        {
            InitializeComponent();
            service = ConnectionService.GetInstance();
        }

        private void ListaProduto_Load(object sender, EventArgs e)
        {
            ReloadList();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            new AddProduto(service).ShowDialog();
            ReloadList();
        }

        private void ReloadList()
        {
            dataGridView1.Rows.Clear();
            lista = service.GetProdutoRepository().List();
            //lista.Sort((prod1, prod2) => prod1.Nome.CompareTo(prod2.Nome));

            lista.ForEach(item =>
            {
                //item.Quantidade = (item.Itens.Count > 1 || (item.Itens.Count == 1 && item.Itens[0].Id != item.Id)) ? 456 : item.Quantidade;
                dataGridView1.Rows.Add(new object[] {
                    item.Id,
                    item.CodigoBarras,
                    item.Nome,
                    item.Descricao,
                    item.Quantidade,
                    item.QuantidadeMinima,
                    item.Valor
                });
            });
            dataGridView1.Sort(dgvProduto, ListSortDirection.Ascending);
            //dataGridView1.DataSource = lista;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var produto = lista[e.RowIndex];
            new AddProduto(service, produto).ShowDialog();
            ReloadList();
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var c = ((DataGridView)sender).Columns[1];
            ((DataGridView)sender).Sort(c, System.ComponentModel.ListSortDirection.Ascending);
        }

        private void ListaProduto_KeyUp(object sender, KeyEventArgs e)
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