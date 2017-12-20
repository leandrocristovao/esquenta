﻿using Esquenta.Components;
using Esquenta.Repository.Extensions;
using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Esquenta.Forms.Relatorios
{
    public partial class Vendas : Form
    {
        decimal valorVendasEmAberto = 0;
        decimal valorVendasFinal = 0;
        decimal valorAcrescimoFinal = 0;
        decimal valorDescontoFinal = 0;
        decimal valorTrocoFinal = 0;
        decimal valorEmCaixa = 0;
        public Vendas()
        {
            InitializeComponent();
        }

        private void Vendas_Load(object sender, EventArgs e)
        {
            ConnectionService service = ConnectionService.GetInstance();
            var dataAbertura = service.GetPeriodoVendaRepository().GetPeriodoAtual();

            var _vendas = service.GetVendaRepository().GetVendasDia(dataAbertura.DataInicial);
            var consumo = service.GetItemVendaRepository().GetConsumo(dataAbertura.DataInicial, null);

            var troco = Properties.Settings.Default.Troco;
            txtValorCaixa.Text = troco.ToString();

            CarregaVendas(_vendas, consumo);
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
                //MessageBox.Show(string.Format("As comandas:\n\n{0}\n\nestão em aberto. O caixa não pode ser fechado!", string.Join(", ", comandas.ToArray())));
                var fecharCaixa = MessageBox.Show(string.Format("As comandas:\n\n{0}\n\nestão em aberto. Deseja fechar?", string.Join(", ", comandas.ToArray())), "Fechar Venda?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.No;
                if (!fecharCaixa)
                {
                    return;
                }

            }

            var periodoEmAberto = service.GetPeriodoVendaRepository().ChecarPeriodoEmAberto();
            if (!periodoEmAberto)
            {
                var dateTime = DateTime.Now;
                service.GetPeriodoVendaRepository().FecharPeriodo(dateTime);
                var dataAbertura = service.GetPeriodoVendaRepository().GetPeriodoAtual();

                var _vendas = service.GetVendaRepository().GetVendasDia(dataAbertura.DataInicial);
                var consumo = service.GetItemVendaRepository().GetConsumo(dataAbertura.DataInicial, null);

                var troco = Properties.Settings.Default.Troco;
                txtValorCaixa.Text = troco.ToString();

                CarregaVendas(_vendas, consumo);

                MessageBox.Show("Período Encerrado.");
            }
            else
            {
                MessageBox.Show("Período já está fechado.");
            }

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

                dataGridView2.Rows.Add(new object[] { nomeProduto, quantidade, valorUnidade, valorTotal, estoque });
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
                var valorCC = venda.ValorCC;
                var valorCD = venda.ValorCD;
                var valorD = venda.ValorD;
                var valorAcrescimo = venda.ValorAcrescimo;
                var valorDesconto = venda.ValorDesconto;
                var valorFinal = venda.ValorFinal;
                var emAberto = venda.EmAberto;

                dataGridView1.Rows.Add(new object[] { id, produto, dataVenda, valorVendas, valorCC, valorCD, valorD, valorAcrescimo, valorDesconto, valorFinal, emAberto });
            });

            AtualizaCalculos(vendas);

            dgvConsumo.Rows.Clear();
            consumo.ForEach(item =>
            {
                dgvConsumo.Rows.Add(new object[] { item.Produto.Nome, item.Quantidade });
            });
        }

        private void AtualizaCalculos(List<Entities.Venda> vendas)
        {
            valorVendasEmAberto = vendas.Where(x => x.EmAberto == true).Sum(x => x.ValorFinal);

            valorVendasFinal = vendas.Where(x => x.EmAberto == false).Sum(x => x.ValorFinal);
            var valorCC = vendas.Where(x => x.EmAberto == false).Sum(x => x.ValorCC);
            var valorCD = vendas.Where(x => x.EmAberto == false).Sum(x => x.ValorCD);
            var valorD = vendas.Where(x => x.EmAberto == false).Sum(x => x.ValorD);

            valorAcrescimoFinal = vendas.Where(x => x.EmAberto == false).Sum(x => x.ValorAcrescimo);
            valorDescontoFinal = vendas.Where(x => x.EmAberto == false).Sum(x => x.ValorDesconto);
            valorTrocoFinal = 0;
            decimal.TryParse(txtValorCaixa.Text, out valorTrocoFinal);

            valorEmCaixa = valorVendasFinal + valorAcrescimoFinal + valorTrocoFinal - valorDescontoFinal;

            lblTotalItens.Text = vendas.Count.ToString();
            lblDesconto.Text = string.Format("{0:C}", valorDescontoFinal);
            lblAcrescimo.Text = string.Format("{0:C}", valorAcrescimoFinal);
            lblTotal.Text = string.Format("{0:C} - CC: {1:C} / CD: {2:C} / D:{3:C}", valorVendasFinal, valorCC, valorCD, valorD);
            lblTotalEmAberto.Text = string.Format("{0:C}", valorVendasEmAberto);
            lblValorFinal.Text = string.Format("{0:C}", valorEmCaixa);
        }
        private void txtValorCaixa_TextChanged(object sender, EventArgs e)
        {
            TextBoxEnter.TextChanged(sender, e);

            decimal valorTrocoFinal = 0;
            decimal.TryParse(txtValorCaixa.Text, out valorTrocoFinal);

            Properties.Settings.Default.Troco = valorTrocoFinal;
            Properties.Settings.Default.Save();

            ConnectionService service = ConnectionService.GetInstance();
            var dataAbertura = service.GetPeriodoVendaRepository().GetPeriodoAtual();

            var vendas = service.GetVendaRepository().GetVendasDia(dataAbertura.DataInicial);
            var consumo = service.GetItemVendaRepository().GetConsumo(dataAbertura.DataInicial, null);
            AtualizaCalculos(vendas);
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var emAberto = (bool)dataGridView1.Rows[e.RowIndex].Cells["dgvEmAberto"].Value;
            if (emAberto)
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var cancel = MessageBox.Show("Deseja cancelar venda?", "Cancelar Venda?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes;
            if (cancel)
            {
                e.Cancel = cancel;
            }
            else
            {
                var vendaID = (int)((DataGridView)sender).CurrentRow.Cells[0].Value;
                ConnectionService service = ConnectionService.GetInstance();
                var venda = service.GetVendaRepository().Get(vendaID);
                service.GetVendaRepository().CancelarVenda(venda);
            }


        }
    }
}