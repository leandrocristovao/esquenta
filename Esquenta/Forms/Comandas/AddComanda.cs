using System;
using System.Windows.Forms;

namespace Esquenta.Forms.Comandas
{
    public partial class AddComanda : Form
    {
        private ConnectionService _service;
        private Entities.Comanda _comanda;

        public AddComanda()
        {
            InitializeComponent();
        }

        public AddComanda(ConnectionService service)
        {
            InitializeComponent();
            _service = service;
        }

        public AddComanda(ConnectionService service, Entities.Comanda comanda)
        {
            InitializeComponent();
            _service = service;
            _comanda = comanda;

            if (_comanda != null)
            {
                txtCodigoBarra.Text = _comanda.CodigoBarras;
                txtNome.Text = _comanda.Nome;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoBarra.Text))
            {
                MessageBox.Show("O codigo de barras deve ser preenchido.");
                return;
            }

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("O nome deve ser preenchido.");
                return;
            }

            bool isNew = false;
            if (_comanda == null)
            {
                isNew = true;
                _comanda = new Entities.Comanda();
            }

            _comanda.CodigoBarras = txtCodigoBarra.Text;
            _comanda.Nome = txtNome.Text;

            //TODO Leandro: Mudar para SaveOrUpdate
            if (isNew)
            {
                _service.GetComandaRepository().Save(_comanda);
            }
            else
            {
                _service.GetComandaRepository().Update(_comanda);
            }

            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCodigoBarra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNome.Focus();
            }
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSalvar.Focus();
            }
        }
    }
}