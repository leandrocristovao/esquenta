﻿using Esquenta.Forms.Caixa;
using Esquenta.Forms.Comandas;
using Esquenta.Forms.EntradaProduto;
using Esquenta.Forms.Produto;
using Esquenta.Forms.Relatorios;
using System;
using System.Windows.Forms;

namespace Esquenta
{
    public partial class Main : Form
    {
        private ListaEntradaProduto frmListaEntradaProduto;
        private ListaComanda frmListaComanda;
        private ListaProduto frmListaProduto;
        private Caixa frmCaixa;
        private Vendas frmVendas;

        public Main()
        {
            InitializeComponent();

            new ConnectionService();
        }

        private void menuItemProdutos_Click(object sender, EventArgs e)
        {
            if (frmListaProduto != null)
            {
                frmListaProduto.Close();
                frmListaProduto = null;
            }
            frmListaProduto = new ListaProduto
            {
                MdiParent = this
            };
            frmListaProduto.Show();
            frmListaProduto.WindowState = FormWindowState.Maximized;
        }

        private void menuItemComandas_Click(object sender, EventArgs e)
        {
            if (frmListaComanda != null)
            {
                frmListaComanda.Close();
                frmListaComanda = null;
            }
            frmListaComanda = new ListaComanda();
            frmListaComanda.MdiParent = this;
            frmListaComanda.Show();
            frmListaComanda.WindowState = FormWindowState.Maximized;
        }

        private void menuItemCaixa_Click(object sender, EventArgs e)
        {
            if (frmCaixa != null)
            {
                frmCaixa.Close();
                frmCaixa = null;
            }
            frmCaixa = new Caixa();
            frmCaixa.MdiParent = this;
            frmCaixa.Show();
            frmCaixa.WindowState = FormWindowState.Maximized;
        }

        private void menuItemLivroCaixa_Click(object sender, EventArgs e)
        {
            if (frmVendas != null)
            {
                frmVendas.Close();
                frmVendas = null;
            }
            frmVendas = new Vendas();
            frmVendas.MdiParent = this;
            frmVendas.Show();
            frmVendas.WindowState = FormWindowState.Maximized;
        }

        private void menuItemEntradaProduto_Click(object sender, EventArgs e)
        {
            if (frmListaEntradaProduto != null)
            {
                frmListaEntradaProduto.Close();
                frmListaEntradaProduto = null;
            }
            frmListaEntradaProduto = new ListaEntradaProduto();
            frmListaEntradaProduto.MdiParent = this;
            frmListaEntradaProduto.Show();
            frmListaEntradaProduto.WindowState = FormWindowState.Maximized;
        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            //Set KeyPreview:true
            switch (e.KeyCode)
            {
                case Keys.F2:
                    menuItemCaixa_Click(sender, e);
                    break;

                case Keys.F3:
                    menuItemProdutos_Click(sender, e);
                    break;

                case Keys.F4:
                    menuItemComandas_Click(sender, e);
                    break;

                case Keys.F5:
                    menuItemEntradaProduto_Click(sender, e);
                    break;

                case Keys.F6:
                    menuItemLivroCaixa_Click(sender, e);
                    break;
            }
        }

        private void btnCaixa_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            //menuItemCaixa_Click(sender, e);
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            menuItemProdutos_Click(sender, e);
        }

        private void btnComandas_Click(object sender, EventArgs e)
        {
            menuItemComandas_Click(sender, e);
        }

        private void btnEntradaProdutos_Click(object sender, EventArgs e)
        {
            menuItemEntradaProduto_Click(sender, e);
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            menuItemLivroCaixa_Click(sender, e);
        }
    }
}