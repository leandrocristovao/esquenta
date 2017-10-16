using Esquenta.Entities;
using System;
using System.Windows.Forms;

namespace Esquenta.Forms.Caixa
{
    public partial class Caixa : Form
    {
        public Caixa()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            var service = ConnectionService.GetInstance();

            var comanda = service.GetService<Comanda>().Get(1);
            var produto = service.GetService<Entities.Produto>().Get(1);

            var venda = new Venda();
            venda.Comanda = comanda;
            venda.DataVenda = DateTime.Today;

            var item = new ItemVenda();
            item.Venda = venda;
            //item.Produto = produto;

            venda.ItemVenda.Add(item);

            service.GetService<Venda>().Teste(venda);
        }
    }
}