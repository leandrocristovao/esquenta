﻿using Esquenta.Entities;
using Esquenta.Forms.Caixa;
using Esquenta.Forms.Comandas;
using Esquenta.Forms.EntradaProduto;
using Esquenta.Forms.Produto;
using Esquenta.Forms.Relatorios;
using SqlConnectionDialog;
using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Esquenta
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            try
            {
                new ConnectionService();
            }
            catch (Exception)
            {
                OpenSQLConnection();
            }

            var hasPeriodo = ConnectionService.GetInstance().GetPeriodoVendaRepository().List().Count > 0;
            if (!hasPeriodo)
            {
                ConnectionService.GetInstance().GetPeriodoVendaRepository().Save(new PeriodoVenda()
                {
                    DataInicial = DateTime.Now,
                    DataFinal = DateTime.Now
                });
            }

            ttsIP.Text = string.Format("IP: {0}", GetLocalIPAddress());
            ttsIPDB.Text = string.Format("IP Banco de Dados: {0}", ConnectionService.GetInstance().GetIPServer());
            ttsMachineName.Text = string.Format("Terminal: {0}", Environment.MachineName);
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private void menuItemProdutos_Click(object sender, EventArgs e)
        {
            var form = new ListaProduto
            {
                WindowState = FormWindowState.Maximized
            };
            form.ShowDialog();
        }

        private void menuItemComandas_Click(object sender, EventArgs e)
        {
            var form = new ListaComanda
            {
                WindowState = FormWindowState.Maximized
            };
            form.ShowDialog();
        }

        private void menuItemCaixa_Click(object sender, EventArgs e)
        {
            var form = new Caixa
            {
                WindowState = FormWindowState.Maximized
            };
            form.ShowDialog();
        }

        private void menuItemLivroCaixa_Click(object sender, EventArgs e)
        {
            var form = new Vendas
            {
                WindowState = FormWindowState.Maximized
            };
            form.ShowDialog();
        }

        private void menuItemEntradaProduto_Click(object sender, EventArgs e)
        {
            var form = new ListaEntradaProduto
            {
                WindowState = FormWindowState.Maximized
            };
            form.ShowDialog();
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
            //new Form1().Show();
            menuItemCaixa_Click(sender, e);
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

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void menuItemSQLServer_Click(object sender, EventArgs e)
        {
            OpenSQLConnection();
        }

        private void OpenSQLConnection()
        {
            var factory = new ConnectionStringFactory();
            var outConnectionString = factory.BuildConnectionString();

            Properties.Settings.Default.ConnectionString = outConnectionString;
            Properties.Settings.Default.Save();
        }
    }
}