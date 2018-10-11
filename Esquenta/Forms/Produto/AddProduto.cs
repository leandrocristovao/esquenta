using System;
using System.Linq;
using System.Windows.Forms;
using Esquenta.Components;
using Esquenta.Entities;

namespace Esquenta.Forms.Produto
{
    public partial class AddProduto : Form
    {
        private Entities.Produto _produto;
        private readonly ConnectionService _service;

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
                LoadProduto(produto);
            else
                LoadItens();
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
            txtPrecoCusto.Text = _produto.PrecoCusto.ToString();

            btnEstoque.Enabled = true;

            LoadItens();
            LoadEstoque();
            LoadVendas();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoBarra.Text))
            {
                MessageBox.Show(@"O código de barras deve ser preenchido.");
                return;
            }

            if (string.IsNullOrEmpty(txtProduto.Text))
            {
                MessageBox.Show(@"O nome do produto deve ser preenchido.");
                return;
            }

            if (string.IsNullOrEmpty(txtQuantidadeMinima.Text))
            {
                MessageBox.Show(@"A quantidade mínima deve ser preenchido.");
                return;
            }

            if (string.IsNullOrEmpty(txtValor.Text))
            {
                MessageBox.Show(@"O valor deve ser preenchido.");
                return;
            }

            var isNew = false;
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
            //_produto.PrecoCusto = decimal.Parse(txtPrecoCusto.Text);

            var counter = dataGridView1.Rows.Count;
            decimal precoCusto = 0;
            if (counter > 1)
            {
                for (var i = 0; i < counter; i++)
                {
                    var selecionado = (bool) dataGridView1.Rows[i].Cells["Add"].Value;
                    var id = (int) dataGridView1.Rows[i].Cells["ID"].Value;
                    var produto = dataGridView1.Rows[i].Cells["Produto"].Value;

                    //Se esta selecionado e nao esta na lista, adiciona
                    if (selecionado)
                    {
                        var found = _produto.Itens.FirstOrDefault(x => x.Produto.Id == id);
                        if (found == null)
                        {
                            var strQuantidade = dataGridView1.Rows[i].Cells["Quantidade"].Value;
                            int.TryParse("" + strQuantidade, out var quantidade);

                            if (quantidade == 0)
                            {
                                MessageBox.Show($@"Necessário preencher a quantidade para o itens {produto}");
                                return;
                            }

                            var subProduto = _service.GetProdutoRepository().Get(id);
                            _produto.Itens.Add(new ProdutoItem
                            {
                                //Evict??
                                Produto = subProduto,
                                Parent = _produto,
                                Quantidade = quantidade
                            });

                            var estoque = _service.GetEntradaProdutoRepository().GetByProduto(subProduto)
                                .OrderByDescending(x => x.Id).FirstOrDefault();
                            decimal precoCustoItem = 0;
                            if (estoque != null) precoCustoItem = estoque.Valor;
                            precoCusto += precoCustoItem * quantidade;
                        }
                        else
                        {
                            var estoque = _service.GetEntradaProdutoRepository().GetByProduto(found.Produto)
                                .OrderByDescending(x => x.Id).FirstOrDefault();
                            decimal precoCustoItem = 0;
                            if (estoque != null) precoCustoItem = estoque.Valor;
                            precoCusto += precoCustoItem * found.Quantidade;
                        }
                    }
                    //Se nao esta selecionado e esta na lista, removo
                    else
                    {
                        var found = _produto.Itens.FirstOrDefault(x => x.Produto.Id == id);
                        if (found != null) _produto.Itens.Remove(found);
                    }
                }
            }
            else
            {
                //Quando for um item simples (nao e um combo) devo verificar em todos os outros produtos que sejam combo e este
                //item faca parte, para recalcular o preco de custo
                var itens = _service.GetProdutoRepository()
                    .GetAll(x => x.Itens.Count > 1 && x.Itens.Any(z => z.Produto == _produto)).ToList();
                itens.ForEach(UpdatePrecoCusto);
            }

            _produto.PrecoCusto = precoCusto;

            if (isNew)
                _service.GetProdutoRepository().Save(_produto);
            else
                _service.GetProdutoRepository().Update(_produto);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdatePrecoCusto(Entities.Produto produto)
        {
            decimal precoCusto = 0;
            produto.Itens.ToList().ForEach(subProduto =>
            {
                precoCusto += subProduto.Produto.PrecoCusto * subProduto.Quantidade;
            });

            produto.PrecoCusto = precoCusto;
            _service.GetProdutoRepository().Update(produto);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LoadItens()
        {
            dataGridView1.Rows.Clear();
            var itens = _service.GetProdutoRepository().List();
            itens.ForEach(item =>
            {
                var selecionado = false;
                var quantidade = 0;
                if (_produto != null)
                {
                    var produtoItem = _produto.Itens.FirstOrDefault(x => x.Produto == item);
                    if (produtoItem != null)
                    {
                        selecionado = true;
                        quantidade = produtoItem.Quantidade;
                        dataGridView1.Rows.Add(selecionado, item.Id, item.Nome, quantidade);
                    }
                }
            });
        }

        private void txtCodigoBarra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (((TextBox) sender).Name.Equals("txtCodigoBarra"))
                {
                    var found = _service.GetProdutoRepository().GetByCodigoBarra(((TextBox) sender).Text);
                    if (found != null) LoadProduto(found);
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
                    dataGridView1.Rows.Add(true, item.Id, item.Nome, quantidade);
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
                    txtPrecoCusto.Text = valor.ToString();
                    LoadEstoque();
                }
            }
        }

        private void LoadEstoque()
        {
            if (_produto == null) return;
            var estoque = _service.GetEntradaProdutoRepository().GetByProduto(_produto);
            dgvEstoque.Rows.Clear();
            estoque.ForEach(item =>
            {
                var id = item.Id;
                var data = item.DataEntrada;
                var quantidade = item.Quantidade;
                var valor = item.Valor;
                dgvEstoque.Rows.Add(id, data, quantidade, valor);
            });
        }

        private void LoadVendas()
        {
            if (_produto == null) return;
            var vendas = _service.GetItemVendaRepository().GetVendasByProduto(_produto);
            dgvVendas.Rows.Clear();

            var vendasAgrupadas = vendas.GroupBy(x => new
            {
                Data = x.DataVenda.ToString("dd/MM/yyyy"),
                x.Valor
            }, (key, group) => new
            {
                DataVenda = key.Data,
                key.Valor,
                Quantidade = group.Sum(x => x.Quantidade)
            }).ToList();

            vendasAgrupadas.ForEach(item =>
            {
                var id = 1;
                var data = item.DataVenda;
                var quantidade = item.Quantidade;
                var valor = item.Valor;
                dgvVendas.Rows.Add(id, data, quantidade, valor);
            });
            lblVendasTotal.Text = vendasAgrupadas.Sum(x => x.Quantidade).ToString();
            //vendas.ForEach(item =>
            //{
            //    var id = item.Id;
            //    var data = item.DataVenda;
            //    var quantidade = item.Quantidade;
            //    var valor = item.Valor;
            //    dgvVendas.Rows.Add(new object[] { id, data, quantidade, valor });
            //});lbl
        }
    }
}