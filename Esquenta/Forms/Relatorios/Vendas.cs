using Esquenta.Components;
using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Esquenta.Entities;

namespace Esquenta.Forms.Relatorios
{
    public partial class Vendas : Form
    {
        private decimal _valorVendasEmAberto = 0;
        private decimal _valorVendasFinal = 0;
        private decimal _valorAcrescimoFinal = 0;
        private decimal _valorDescontoFinal = 0;
        private decimal _valorTrocoFinal = 0;
        private decimal _valorEmCaixa = 0;
        private readonly CultureInfo _culture = new CultureInfo("pt-BR");
        private ConnectionService _service;

        public Vendas()
        {
            InitializeComponent();
        }

        private void Vendas_Load(object sender, EventArgs e)
        {
            _service = ConnectionService.GetInstance();
            var dataAbertura = _service.GetPeriodoVendaRepository().GetPeriodoAtual();

            var vendas = _service.GetVendaRepository().GetVendasDia(dataAbertura.DataInicial);
            var consumo = _service.GetItemVendaRepository().GetConsumo(dataAbertura.DataInicial, null);

            var troco = Properties.Settings.Default.Troco;
            txtValorCaixa.Text = troco.ToString();

            CarregaVendas(vendas, consumo);
        }

        private void BtnFecharCaixa_Click(object sender, EventArgs e)
        {
            var emAberto = _service.GetVendaRepository().GetVendasEmAberto();
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

            var periodoEmAberto = _service.GetPeriodoVendaRepository().ChecarPeriodoEmAberto();
            if (!periodoEmAberto)
            {
                var dateTime = DateTime.Now;
                _service.GetPeriodoVendaRepository().FecharPeriodo(dateTime);
                var dataAbertura = _service.GetPeriodoVendaRepository().GetPeriodoAtual();

                var _vendas = _service.GetVendaRepository().GetVendasDia(dataAbertura.DataInicial);
                var consumo = _service.GetItemVendaRepository().GetConsumo(dataAbertura.DataInicial, null);

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
            var venda = _service.GetVendaRepository().Get((int)id);

            dataGridView2.Rows.Clear();
            venda.ItemVenda.ForEach(itemVenda =>
            {
                var dataVenda = itemVenda.DataVenda;
                var nomeProduto = itemVenda.Produto.Nome;
                var quantidade = itemVenda.Quantidade;
                var estoque = itemVenda.Produto.Quantidade;
                var valorUnidade = itemVenda.Valor;
                var valorTotal = valorUnidade * quantidade;

                dataGridView2.Rows.Add(new object[] { dataVenda, nomeProduto, quantidade, valorUnidade.ToString(_culture), valorTotal.ToString(_culture), estoque });
            });

            lblValorTotalVenda.Text = $@"Valor total da venda: {venda.ValorFinal.ToString(_culture)}";
        }

        private void mCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            var start = ((MonthCalendar)sender).SelectionRange.Start;
            var end = ((MonthCalendar)sender).SelectionRange.End;

            //Se for o dia atual, devo pegar o periodo de abertura do caixa
            if (start == DateTime.Today)
            {
                start = _service.GetPeriodoVendaRepository().GetPeriodoAtual().DataInicial;
            }

            List<Entities.Venda> vendas = new List<Entities.Venda>();

            if (start == end)
            {
                //Apenas um dia
                var periodo = _service.GetPeriodoVendaRepository().GetPeriodoInicial(start);
                if (periodo != null)
                {
                    vendas = _service.GetVendaRepository().GetVendasDia(periodo);
                }
            }
            else
            {
                //Faixa de dias
                vendas = _service.GetVendaRepository().GetVendasDia(start, end.AddSeconds(59).AddMinutes(59).AddHours(23));
            }
            var consumo = _service.GetItemVendaRepository().GetConsumo(start, end.AddSeconds(59).AddMinutes(59).AddHours(23));
            CarregaVendas(vendas, consumo);
        }

        private void CarregaVendas(List<Entities.Venda> vendas, List<Entities.ItemVenda> consumo)
        {
            dataGridView2.Rows.Clear();
            lblValorTotalVenda.Text = @"Valor total em vendas: R$ 0,00";

            dataGridView1.Rows.Clear();
            vendas.ForEach(venda =>
            {
                var id = venda.Id;
                var produto = venda.Comanda.Nome;
                var dataVenda = venda.DataVenda;
                var valorVendas = venda.ValorTotal;
                var valorCc = venda.ValorCC;
                var valorCd = venda.ValorCD;
                var valorD = venda.ValorD;
                var valorAcrescimo = venda.ValorAcrescimo;
                var valorDesconto = venda.ValorDesconto;
                var valorFinal = venda.ValorFinal;
                var emAberto = venda.EmAberto;

                dataGridView1.Rows.Add(new object[] { id, produto, dataVenda, valorVendas.ToString(_culture), valorCc.ToString(_culture), valorCd.ToString(_culture), valorD.ToString(_culture), valorAcrescimo.ToString(_culture), valorDesconto.ToString(_culture), valorFinal.ToString(_culture), emAberto });
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
            _valorVendasEmAberto = vendas.Where(x => x.EmAberto == true).Sum(x => x.ValorFinal);

            _valorVendasFinal = vendas.Where(x => x.EmAberto == false).Sum(x => x.ValorFinal);
            var valorCC = vendas.Where(x => x.EmAberto == false).Sum(x => x.ValorCC);
            var valorCD = vendas.Where(x => x.EmAberto == false).Sum(x => x.ValorCD);
            var valorD = vendas.Where(x => x.EmAberto == false).Sum(x => x.ValorD);

            _valorAcrescimoFinal = vendas.Where(x => x.EmAberto == false).Sum(x => x.ValorAcrescimo);
            _valorDescontoFinal = vendas.Where(x => x.EmAberto == false).Sum(x => x.ValorDesconto);
            _valorTrocoFinal = 0;
            decimal.TryParse(txtValorCaixa.Text, out _valorTrocoFinal);

            _valorEmCaixa = _valorVendasFinal + _valorAcrescimoFinal + _valorTrocoFinal - _valorDescontoFinal;

            lblTotalItens.Text = vendas.Count.ToString();
            lblDesconto.Text = _valorDescontoFinal.ToString(_culture);
            lblAcrescimo.Text = _valorAcrescimoFinal.ToString(_culture);
            lblTotal.Text =
                $"{_valorVendasFinal.ToString(_culture):C} - CC: {valorCC.ToString(_culture):C} / CD: {valorCD.ToString(_culture):C} / D:{valorD.ToString(_culture):C}";
            lblTotalEmAberto.Text = _valorVendasEmAberto.ToString(_culture);
            lblValorFinal.Text = _valorEmCaixa.ToString(_culture);
        }

        private void txtValorCaixa_TextChanged(object sender, EventArgs e)
        {
            TextBoxEnter.TextChanged(sender, e);

            decimal valorTrocoFinal = 0;
            decimal.TryParse(txtValorCaixa.Text, out valorTrocoFinal);

            Properties.Settings.Default.Troco = valorTrocoFinal;
            Properties.Settings.Default.Save();

            var dataAbertura = _service.GetPeriodoVendaRepository().GetPeriodoAtual();

            var vendas = _service.GetVendaRepository().GetVendasDia(dataAbertura.DataInicial);
            var consumo = _service.GetItemVendaRepository().GetConsumo(dataAbertura.DataInicial, null);
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
                var venda = _service.GetVendaRepository().Get(vendaID);
                _service.GetVendaRepository().CancelarVenda(venda);

                Vendas_Load(sender, e);
            }
        }
    }
}