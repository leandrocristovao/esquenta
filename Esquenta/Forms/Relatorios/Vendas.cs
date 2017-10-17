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
            var lista = service.GetItemVendaRepository().GetVendasDia(Properties.Settings.Default.AberturaCaixa);
            var itensAgrupados = lista.GroupBy(x => x.Produto.Id).Select(g => new { IDProduto = g.Key, Count = g.Count() }).ToList();

            string nomeProduto = "";
            int quantidade = 0;
            long estoque = 0;
            decimal valorUnidade = 0;
            decimal valorTotal = 0;
            decimal valorFinal = 0;

            itensAgrupados.ForEach(item =>
            {
                var itemVenda = lista.FirstOrDefault(x => x.Produto.Id == item.IDProduto);
                nomeProduto = itemVenda.Produto.Nome;
                quantidade = item.Count;
                estoque = itemVenda.Produto.Quantidade;
                valorUnidade = itemVenda.Valor;
                valorTotal = valorUnidade * quantidade;
                valorFinal += valorTotal;

                dataGridView1.Rows.Add(new object[] { nomeProduto, quantidade, valorUnidade, valorTotal, estoque });
            });

            lblTotalItens.Text = string.Format("Total de itens vendidos: {0}", itensAgrupados.Sum(x => x.Count));
            lblTotalVendas.Text = string.Format("Valor Total em vendas: R$ {0}", valorFinal);
        }

        private void BtnFecharCaixa_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AberturaCaixa = DateTime.Now;
            Properties.Settings.Default.Save();
        }
    }
}