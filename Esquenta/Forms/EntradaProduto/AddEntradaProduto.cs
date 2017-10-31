using Esquenta.Components;
using System;
using System.Windows.Forms;

namespace Esquenta.Forms.EntradaProduto
{
    public partial class AddEntradaProduto : Form
    {
        private ConnectionService _service;

        public AddEntradaProduto()
        {
            InitializeComponent();
        }

        public AddEntradaProduto(ConnectionService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void AddEntradaProduto_Load(object sender, EventArgs e)
        {
            produtoBindingSource.DataSource = _service.GetProdutoRepository().List(x => x.Itens.Count == 1);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var counter = dataGridView1.Rows.Count;
            for (int i = 0; i < counter; i++)
            {

                var id = (int)dataGridView1.Rows[i].Cells["ID"].Value;
                var strQuantidade = dataGridView1.Rows[i].Cells["Quantidade"].Value;
                var strValor = dataGridView1.Rows[i].Cells["Valor"].Value;
                if (strQuantidade == null || strValor == null)
                {
                    continue;
                }

                int quantidade = 0;
                int.TryParse(strQuantidade.ToString(), out quantidade);

                decimal valor = 0;
                decimal.TryParse(strValor.ToString(), out valor);

                Entities.Produto produto = _service.GetProdutoRepository().Get(id);
                var entrada = new Esquenta.Entities.EntradaProduto
                {
                    Produto = produto,
                    Quantidade = quantidade,
                    Valor = valor,
                    DataEntrada = DateTime.Now
                };

                _service.GetEntradaProdutoRepository().Save(entrada);

            }

            Close();
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            TextBoxEnter.TextChanged(sender, e);
        }
    }
}