using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            bool isNew = false;
            if (_comanda == null)
            {
                isNew = true;
                _comanda = new Entities.Comanda();
            }

            _comanda.CodigoBarras = txtCodigoBarra.Text;
            _comanda.Nome = txtNome.Text;

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
    }
}
