using System;
using System.Linq;
using System.Windows.Forms;

namespace Esquenta.Forms.Produto
{
    public partial class AddProduto : Form
    {
        private ConnectionService _service;
        private Entities.Produto _produto;

        public AddProduto()
        {
            InitializeComponent();
        }

        public AddProduto(ConnectionService service)
        {
            InitializeComponent();
            _service = service;
        }

        public AddProduto(ConnectionService service, Entities.Produto produto)
        {
            InitializeComponent();
            _service = service;
            _produto = produto;

            if (_produto != null)
            {
                txtDescricao.Text = _produto.Descricao;
                txtProduto.Text = _produto.Nome;
                txtQuantidade.Text = _produto.Quantidade.ToString();
                txtValor.Text = _produto.Valor.ToString();
            }

            var itens = _service.GetProdutoRepository().List();
            itens.ForEach(item =>
            {
                var selecionado = _produto.Itens.Where(x => x.Produto == item).Count() > 0;
                dataGridView1.Rows.Add(new object[] { selecionado, item.Id, item.Nome });
            });
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bool isNew = false;
            if (_produto == null)
            {
                isNew = true;
                _produto = new Entities.Produto();
            }

            _produto.Descricao = txtDescricao.Text;
            _produto.Nome = txtProduto.Text;
            _produto.Quantidade = int.Parse(txtQuantidade.Text);
            _produto.QuantidadeMinima = int.Parse(txtQuantidadeMinima.Text);
            _produto.Valor = decimal.Parse(txtValor.Text);

            var counter = dataGridView1.Rows.Count;
            for (var i = 0; i < counter; i++)
            {
                var selecionado = (bool)dataGridView1.Rows[i].Cells["Add"].Value;
                var id = (int)dataGridView1.Rows[i].Cells["ID"].Value;
                var produto = dataGridView1.Rows[i].Cells["Produto"].Value;

                //Se esta selecionado e nao esta na lista, adiciona
                if (selecionado)
                {
                    var found = _produto.Itens.FirstOrDefault(x => x.Produto.Id == id);
                    if (found == null)
                    {
                        _produto.Itens.Add(new Entities.ProdutoItem
                        {
                            //Evict??
                            Produto = _service.GetProdutoRepository().Get(id),
                            Parent = _produto,
                            Quantidade = 1
                        });
                    }
                }
                //Se nao esta selecionado e esta na lista, removo
                else
                {
                    var found = _produto.Itens.FirstOrDefault(x => x.Produto.Id == id);
                    if (found != null)
                    {
                        _produto.Itens.Remove(found);
                    }
                }
            }

            if (isNew)
            {
                _service.GetProdutoRepository().Save(_produto);
            }
            else
            {
                _service.GetProdutoRepository().Update(_produto);
            }

            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}