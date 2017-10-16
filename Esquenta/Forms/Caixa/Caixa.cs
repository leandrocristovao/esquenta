using Esquenta.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Esquenta.Forms.Caixa
{
    public partial class Caixa : Form
    {
        ConnectionService service;
        List<Entities.Produto> itens = new List<Entities.Produto>();

        public Caixa()
        {
            InitializeComponent();
            service = ConnectionService.GetInstance();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            int comandaID = int.Parse(txtComanda.Text);
            var comanda = service.GetService<Comanda>().Get(comandaID);

            var venda = new Venda();
            venda.Comanda = comanda;
            venda.DataVenda = DateTime.Today;

            itens.ForEach(produto =>
            {
                var item = new ItemVenda();
                item.Venda = venda;
                item.Produto = produto;
                item.Valor = produto.Valor;

                venda.ItemVenda.Add(item);
            });

            service.GetService<Venda>().Teste(venda);

            ClearScreen();
        }

        private void ClearScreen()
        {
            dataGridView1.Rows.Clear();
            itens.Clear();
            lblValorTotal.Text = "R$ 0,00";

        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            int produtoID = int.Parse(txtProduto.Text);
            var produto = service.GetService<Entities.Produto>().Get(produtoID);
            itens.Add(produto);

            var total = itens.Sum(x => x.Valor);
            lblValorTotal.Text = string.Format("R$ {0}", total);

            dataGridView1.Rows.Add(new String[] { produto.Nome, produto.Valor.ToString() });

        }
    }
}