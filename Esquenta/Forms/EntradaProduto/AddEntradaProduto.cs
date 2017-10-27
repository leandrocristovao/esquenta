using System;
using System.Windows.Forms;

namespace Esquenta.Forms.EntradaProduto
{
    public partial class AddEntradaProduto : Form
    {
        private ConnectionService _service;
        private Entities.EntradaProduto _entradaProduto;

        public AddEntradaProduto()
        {
            InitializeComponent();
        }

        public AddEntradaProduto(ConnectionService service)
        {
            InitializeComponent();
            _service = service;
        }

        public AddEntradaProduto(ConnectionService service, Entities.EntradaProduto entradaProduto)
        {
            InitializeComponent();
            _service = service;
            _entradaProduto = entradaProduto;

            if (_entradaProduto != null)
            {
            }
        }

        private void AddEntradaProduto_Load(object sender, EventArgs e)
        {
            produtoBindingSource.DataSource = _service.GetProdutoRepository().List(x=>x.Itens.Count == 1);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Entities.Produto produto = (Entities.Produto)cbProduto.SelectedItem;
            var entrada = new Esquenta.Entities.EntradaProduto
            {
                Produto = produto,
                Quantidade = int.Parse(txtQuantidade.Text),
                Valor = decimal.Parse(txtValor.Text),
                DataEntrada = DateTime.Now
            };

            _service.GetEntradaProdutoRepository().Save(entrada);
            Close();
        }
    }
}