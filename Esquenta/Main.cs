using Esquenta.Entities;
using Esquenta.Forms.Caixa;
using Esquenta.Forms.Comandas;
using Esquenta.Forms.Produto;
using Esquenta.Forms.Relatorios;
using System;
using System.Windows.Forms;

namespace Esquenta
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            new ConnectionService();

            //var _produtoRepository = ConnectionService.GetInstance().GetProdutoRepository();
            //var _produtoItemRepository = ConnectionService.GetInstance().GetProdutoItemRepository();
            //_produtoRepository.Save(new Produto {
            //    CodigoBarras = "COCALATA",
            //    Nome = "Coca-Cola - Lata",
            //    Valor = 2,
            //});
            //var parent = new Produto
            //{
            //    CodigoBarras = "1",
            //    Nome = "Parent 1",
            //    Valor = 10
            //};
            //parent = _produtoRepository.Save(parent);

            //var subItem1 = new Produto
            //{
            //    CodigoBarras = "2",
            //    Nome = "SubItem 1",
            //    Valor = 5
            //};
            //subItem1 = _produtoRepository.Save(subItem1);

            //var produtoItem = new ProdutoItem
            //{
            //    Produto = subItem1,
            //    Parent = parent
            //};
            //_produtoItemRepository.Save(produtoItem);

            //Produto p = _produtoRepository.Get(1);
            //p.Itens.Add(produtoItem);
            //_produtoRepository.Save(p);
            //var x = 1;
        }

        private void btnCaixa_Click(object sender, EventArgs e)
        {
        }

        private void bntRelatorio_Click(object sender, EventArgs e)
        {
        }

        private void btnCadastroProdutos_Click(object sender, EventArgs e)
        {
            new ListaProduto().ShowDialog();
        }

        private void bntCadastroComandas_Click(object sender, EventArgs e)
        {
        }

        private void menuItemProdutos_Click(object sender, EventArgs e)
        {
            var form = new ListaProduto();
            form.MdiParent = this;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }

        private void menuItemComandas_Click(object sender, EventArgs e)
        {
            var form = new ListaComanda();
            form.MdiParent = this;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }

        private void menuItemCaixa_Click(object sender, EventArgs e)
        {
            var form = new Caixa();
            form.MdiParent = this;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }

        private void menuItemLivroCaixa_Click(object sender, EventArgs e)
        {
            var form = new Vendas();
            form.MdiParent = this;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }
    }
}