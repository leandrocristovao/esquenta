﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Esquenta.Forms.Produto
{
    public partial class ListaProduto : Form
    {
        private List<Entities.Produto> lista;
        ConnectionService service;

        public ListaProduto()
        {
            InitializeComponent();
            service = ConnectionService.GetInstance();
        }

        private void ListaProduto_Load(object sender, EventArgs e)
        {
            ReloadList();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            new AddProduto(service).ShowDialog();
            ReloadList();
        }

        private void ReloadList()
        {
            lista = service.GetProdutoRepository().List();
            lista.ForEach(item =>
            {
                //item.Quantidade = (item.Itens.Count > 1 || (item.Itens.Count == 1 && item.Itens[0].Id != item.Id)) ? 456 : item.Quantidade;
            });
            dataGridView1.DataSource = lista;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var produto = lista[e.RowIndex];
            new AddProduto(service, produto).ShowDialog();
            ReloadList();
        }
    }
}