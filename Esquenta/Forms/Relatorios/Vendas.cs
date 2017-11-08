using NHibernate.Util;
using System;
using System.Collections.Generic;
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
            var consumo = service.GetItemVendaRepository().GetConsumo(Properties.Settings.Default.AberturaCaixa, null);

            CarregaVendas(vendas, consumo);
        }

        private void BtnFecharCaixa_Click(object sender, EventArgs e)
        {
            ConnectionService service = ConnectionService.GetInstance();

            var emAberto = service.GetVendaRepository().GetVendasEmAberto();
            if (emAberto.Count > 0)
            {
                List<string> comandas = new List<string>();
                emAberto.ForEach(venda =>
                {
                    comandas.Add(string.Format("{0} - {1}", venda.Comanda.CodigoBarras, venda.Comanda.Nome));
                });
                MessageBox.Show(string.Format("As comandas:\n\n{0}\n\nestão em aberto. O caixa não pode ser fechado!", string.Join(", ", comandas.ToArray())));
                return;
            }

            var dateTime = DateTime.Now;
            Properties.Settings.Default.AberturaCaixa = dateTime;
            Properties.Settings.Default.Save();

            service.GetPeriodoVendaRepository().FecharPeriodo(dateTime);
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

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).CurrentRow == null)
            {
                return;
            }

            var id = ((DataGridView)sender).CurrentRow.Cells[0].Value;
            ConnectionService service = ConnectionService.GetInstance();
            var venda = service.GetVendaRepository().Get((int)id);

            dataGridView2.Rows.Clear();
            venda.ItemVenda.ForEach(itemVenda =>
            {
                var nomeProduto = itemVenda.Produto.Nome;
                var quantidade = itemVenda.Quantidade;
                var estoque = itemVenda.Produto.Quantidade;
                var valorUnidade = itemVenda.Valor;
                var valorTotal = valorUnidade * quantidade;

                dataGridView2.Rows.Add(new object[] { nomeProduto, valorUnidade, quantidade, valorTotal, estoque });
            });

            lblValorTotalVenda.Text = string.Format("Valor total da venda: {0}", venda.ValorFinal);
        }

        private void mCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            var start = ((MonthCalendar)sender).SelectionRange.Start;
            var end = ((MonthCalendar)sender).SelectionRange.End;

            List<Entities.Venda> vendas = new List<Entities.Venda>();
            List<Entities.ItemVenda> consumo = new List<Entities.ItemVenda>();

            ConnectionService service = ConnectionService.GetInstance();

            if (start == end)
            {
                //Apenas um dia
                var periodo = service.GetPeriodoVendaRepository().GetPeriodoInicial(start);
                if (periodo != null)
                {
                    vendas = service.GetVendaRepository().GetVendasDia(periodo);
                }
            }
            else
            {
                //Faixa de dias
                vendas = service.GetVendaRepository().GetVendasDia(start, end.AddSeconds(59).AddMinutes(59).AddHours(23));
            }
            consumo = service.GetItemVendaRepository().GetConsumo(start, end.AddSeconds(59).AddMinutes(59).AddHours(23));
            CarregaVendas(vendas, consumo);
        }

        private void CarregaVendas(List<Entities.Venda> vendas, List<Entities.ItemVenda> consumo)
        {
            dataGridView2.Rows.Clear();
            lblValorTotalVenda.Text = "Valor total em vendas: R$ 0,00";

            dataGridView1.Rows.Clear();
            vendas.ForEach(venda =>
            {
                var id = venda.Id;
                var produto = venda.Comanda.Nome;
                var dataVenda = venda.DataVenda;
                var valorVendas = venda.ValorTotal;
                var valorAcrescimo = venda.ValorAcrescimo;
                var valorDesconto = venda.ValorDesconto;
                var valorFinal = venda.ValorFinal;

                dataGridView1.Rows.Add(new object[] { id, produto, dataVenda, valorVendas, valorAcrescimo, valorDesconto, valorFinal });
            });

            lblTotalItens.Text = string.Format("Total de itens vendidos: {0}", vendas.Count);
            lblDesconto.Text = string.Format("Valor Total em descontos: R$ {0}", vendas.Sum(x => x.ValorDesconto));
            lblAcrescimo.Text = string.Format("Valor Total em acréscimo: R$ {0}", vendas.Sum(x => x.ValorAcrescimo));
            lblTotal.Text = string.Format("Valor Total em vendas: R$ {0}", vendas.Sum(x => x.ValorFinal));

            dgvConsumo.Rows.Clear();
            consumo.ForEach(item =>
            {
                dgvConsumo.Rows.Add(new object[] { item.Produto.Nome, item.Quantidade });
            });
        }
    }
}