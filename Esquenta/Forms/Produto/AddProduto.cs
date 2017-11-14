using Esquenta.Components;
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
            LoadItens();
        }

        public AddProduto(ConnectionService service, Entities.Produto produto)
        {
            InitializeComponent();

            _service = service;

            if (produto != null)
            {
                LoadProduto(produto);
            }
            else
            {
                LoadItens();
            }
        }

        private void LoadProduto(Entities.Produto produto)
        {
            _produto = produto;

            txtCodigoBarra.Text = _produto.CodigoBarras;
            txtDescricao.Text = _produto.Descricao;
            txtProduto.Text = _produto.Nome;
            txtQuantidadeMinima.Text = _produto.QuantidadeMinima.ToString();
            txtQuantidade.Text = _produto.Quantidade.ToString();
            txtValor.Text = _produto.Valor.ToString();

            btnEstoque.Enabled = true;

            LoadItens();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoBarra.Text))
            {
                MessageBox.Show("O código de barras deve ser preenchido.");
                return;
            }

            if (string.IsNullOrEmpty(txtProduto.Text))
            {
                MessageBox.Show("O nome do produto deve ser preenchido.");
                return;
            }

            if (string.IsNullOrEmpty(txtQuantidadeMinima.Text))
            {
                MessageBox.Show("A quantidade mínima deve ser preenchido.");
                return;
            }

            if (string.IsNullOrEmpty(txtValor.Text))
            {
                MessageBox.Show("O valor deve ser preenchido.");
                return;
            }

            bool isNew = false;
            if (_produto == null)
            {
                isNew = true;
                _produto = new Entities.Produto();
            }

            _produto.CodigoBarras = txtCodigoBarra.Text;
            _produto.Descricao = txtDescricao.Text.Trim();
            _produto.Nome = txtProduto.Text;
            //_produto.Quantidade = int.Parse(txtQuantidade.Text);
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
                        var quantidade = 0;
                        var strQuantidade = dataGridView1.Rows[i].Cells["Quantidade"].Value;
                        int.TryParse("" + strQuantidade, out quantidade);

                        if (quantidade == 0)
                        {
                            MessageBox.Show(string.Format("Necessário preencher a quantidade para o itens {0}", produto));
                            return;
                        }

                        _produto.Itens.Add(new Entities.ProdutoItem
                        {
                            //Evict??
                            Produto = _service.GetProdutoRepository().Get(id),
                            Parent = _produto,
                            Quantidade = quantidade
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

        private void LoadItens()
        {
            dataGridView1.Rows.Clear();
            var itens = _service.GetProdutoRepository().List();
            itens.ForEach(item =>
            {
                var selecionado = false;
                int quantidade = 0;
                if (_produto != null)
                {
                    var produtoItem = _produto.Itens.Where(x => x.Produto == item).FirstOrDefault();
                    if (produtoItem != null)
                    {
                        selecionado = true;
                        quantidade = produtoItem.Quantidade;
                        dataGridView1.Rows.Add(new object[] { selecionado, item.Id, item.Nome, quantidade });
                    }
                }

            });
        }

        private void txtCodigoBarra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (((TextBox)sender).Name.Equals("txtCodigoBarra"))
                {
                    var found = _service.GetProdutoRepository().GetByCodigoBarra(((TextBox)sender).Text);
                    if (found != null)
                    {
                        //Encontrei o item
                        LoadProduto(found);
                    }
                }
                SendKeys.Send("{TAB}");
            }
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            TextBoxEnter.TextChanged(sender, e);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            using (var form = new SelecionarItem())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var codigoBarras = form.CodigoBarras;
                    var quantidade = form.Quantidade;

                    var item = _service.GetProdutoRepository().GetByCodigoBarra(codigoBarras);
                    dataGridView1.Rows.Add(new object[] { true, item.Id, item.Nome, quantidade });
                    //form.Close()
                }
            }
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            using (var form = new AddEntradaEstoque())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var quantidade = form.Quantidade;
                    var valor = form.Valor;

                    _service.GetEntradaProdutoRepository().SaveOrUpdate(new Entities.EntradaProduto
                    {
                        Quantidade = quantidade,
                        Valor = valor,
                        DataEntrada = DateTime.Now,
                        Produto = _produto
                    });
                    //_produto.Quantidade += quantidade;
                    txtQuantidade.Text = _produto.Quantidade.ToString();
                }
            }
        }
    }
}