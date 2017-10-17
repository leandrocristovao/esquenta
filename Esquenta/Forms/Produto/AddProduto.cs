using System;
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
            _produto.Valor = decimal.Parse(txtValor.Text);

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