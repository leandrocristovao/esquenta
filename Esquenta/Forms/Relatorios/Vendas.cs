﻿using NHibernate.Util;
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
            var vendas = service.GetVendaRepository().GetVendasDia(Properties.Settings.Default.AberturaCaixa.AddMonths(-1));
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
        }

        private void BtnFecharCaixa_Click(object sender, EventArgs e)
        {
            var dateTime = DateTime.Now;
            Properties.Settings.Default.AberturaCaixa = dateTime;
            Properties.Settings.Default.Save();

            ConnectionService service = ConnectionService.GetInstance();
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
    }
}