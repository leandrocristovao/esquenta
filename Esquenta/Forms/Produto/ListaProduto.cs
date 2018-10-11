using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Esquenta.Forms.Produto
{
    public partial class ListaProduto : Form
    {
        private List<Entities.Produto> _lista;
        private ConnectionService service;

        public ListaProduto()
        {
            InitializeComponent();
            service = ConnectionService.GetInstance();
        }

        private void ListaProduto_Load(object sender, EventArgs e)
        {
            _lista = service.GetProdutoRepository().List();
            ReloadList();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new AddProduto(service))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _lista = service.GetProdutoRepository().List();
                    ReloadList();
                }
            }
        }

        private void ReloadList()
        {
            List<Entities.Produto> lista = _lista;
            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                lista = _lista.Where(x => x.Nome.ToUpper().Contains(txtFilter.Text.ToUpper())).ToList();
            }
            dataGridView1.Rows.Clear();
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
                    item.Valor,
                    item.PrecoCusto
                });
            });
            dataGridView1.Sort(dgvProduto, ListSortDirection.Ascending);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = (int)((DataGridView)sender).CurrentRow.Cells[0].Value;
            var produto = _lista.Find(x => x.Id == id);

            using (var form = new AddProduto(service, produto))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _lista = service.GetProdutoRepository().List();
                    ReloadList();
                }
            }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ReloadList();
        }
    }
}