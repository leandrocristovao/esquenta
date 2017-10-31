using NHibernate.Util;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Esquenta.Forms.Relatorios
{
    public partial class Vendas : Form
    {
        public Vendas()
        {
            InitializeComponent();
        }

        private void Vendas_Load(object sender, EventArgs e)
        {
            ConnectionService service = ConnectionService.GetInstance();
            var vendas = service.GetVendaRepository().GetVendasDia(Properties.Settings.Default.AberturaCaixa);
            vendas.ForEach(venda =>
            {
                venda.ItemVenda.ForEach(itemVenda =>
                {
                    //itemVenda.Produto.Itens.ForEach(produto => {});
                    var nomeProduto = itemVenda.Produto.Nome;
                    var quantidade = itemVenda.Quantidade;
                    var estoque = itemVenda.Produto.Quantidade;
                    var valorUnidade = itemVenda.Valor;
                    var valorTotal = valorUnidade * quantidade;

                    dataGridView1.Rows.Add(new object[] { nomeProduto, valorUnidade, quantidade, valorTotal, estoque });
                });
            });

            lblTotalItens.Text = string.Format("Total de itens vendidos: {0}", vendas.Count);
            lblDesconto.Text = string.Format("Valor Total em vendas: R$ {0}", vendas.Sum(x => x.ValorDesconto));
            lblTotal.Text = string.Format("Valor Total em vendas: R$ {0}", vendas.Sum(x=>x.ValorFinal));
        }

        private void BtnFecharCaixa_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AberturaCaixa = DateTime.Now;
            Properties.Settings.Default.Save();
        }

        private void Vendas_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
            }
        }
    }
}