using Esquenta.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Esquenta.Forms.Relatorios
{
    public partial class Consumo : Form
    {
        private ConnectionService _service;
        private AutoCompleteStringCollection comandasAutoComplete = new AutoCompleteStringCollection();

        public Consumo()
        {
            InitializeComponent();
        }

        private void Consumo_Load(object sender, EventArgs e)
        {
            _service = ConnectionService.GetInstance();

            var listaComanda = _service.GetComandaRepository().List();
            listaComanda.ForEach(comanda =>
            {
                comandasAutoComplete.Add(comanda.Nome);
            });

            txtComanda.AutoCompleteCustomSource = comandasAutoComplete;
        }

        private void txtComanda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtComanda.Text))
                {
                    var comanda = _service.GetComandaRepository().GetByNome(txtComanda.Text);
                    var vendas = _service.GetVendaRepository().GetVendasMes(dtpPeriodo.Value, comanda);
                    List<ItemVenda> itens = new List<ItemVenda>();

                    dgvVendas.Rows.Clear();
                    vendas.ForEach(venda =>
                    {
                        var id = venda.Id;
                        var dataVenda = venda.DataVenda;
                        var valorVendas = venda.ValorTotal;
                        var valorCC = venda.ValorCC;
                        var valorCD = venda.ValorCD;
                        var valorD = venda.ValorD;
                        var valorAcrescimo = venda.ValorAcrescimo;
                        var valorDesconto = venda.ValorDesconto;
                        var valorFinal = venda.ValorFinal;
                        var emAberto = venda.EmAberto;

                        itens.AddRange(venda.ItemVenda);

                        dgvVendas.Rows.Add(new object[] { id, dataVenda, valorVendas, valorCC, valorCD, valorD, valorAcrescimo, valorDesconto, valorFinal, emAberto });
                    });

                    dgvItens.Rows.Clear();
                    itens.OrderBy(x => x.DataVenda);
                    itens.ForEach(itemVenda =>
                    {
                        var dataVenda = itemVenda.DataVenda;
                        var nomeProduto = itemVenda.Produto.Nome;
                        var quantidade = itemVenda.Quantidade;
                        var estoque = itemVenda.Produto.Quantidade;
                        var valorUnidade = itemVenda.Valor;
                        var valorTotal = valorUnidade * quantidade;

                        dgvItens.Rows.Add(new object[] { dataVenda, nomeProduto, quantidade, valorUnidade, valorTotal, estoque });
                    });
                }
            }
        }
    }
}