using Esquenta.Entities;
using Esquenta.Forms.Caixa;
using Esquenta.Forms.Comandas;
using Esquenta.Forms.EntradaProduto;
using Esquenta.Forms.Produto;
using Esquenta.Forms.Relatorios;
using SqlConnectionDialog;
using System;
using System.IO;
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
                //To try connect to server
                // ReSharper disable once ObjectCreationAsStatement
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

            ttsIP.Text = $@"IP: {GetLocalIpAddress()}";
            ttsIPDB.Text = $@"IP Banco de Dados: {ConnectionService.GetInstance().GetIPServer()}";
            ttsMachineName.Text = $@"Terminal: {Environment.MachineName}";

            if (!string.IsNullOrEmpty(Properties.Settings.Default.PWD))
            {
                new Forms.Settings.Password().ShowDialog();
            }
            else
            {
                Program.isAdmin = true;
            }
            cadastrosToolStripMenuItem.Enabled = Program.isAdmin;
            configuracoesToolStripMenuItem.Enabled = Program.isAdmin;
        }

        private static string GetLocalIpAddress()
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

        private void menuItemEntradaProduto_Click()
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
                    if (Program.isAdmin)
                    {
                        menuItemProdutos_Click(sender, e);
                    }
                    break;

                case Keys.F4:
                    if (Program.isAdmin)
                    {
                        menuItemComandas_Click(sender, e);
                    }
                    break;

                case Keys.F5:
                    if (Program.isAdmin)
                    {
                        menuItemEntradaProduto_Click();
                    }
                    break;

                case Keys.F6:
                    if (Program.isAdmin)
                    {
                        menuItemLivroCaixa_Click(sender, e);
                    }
                    break;
            }
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

        private void menuItemBackup_Click(object sender, EventArgs e)
        {
            var path = Properties.Settings.Default.BackupFolder;
            if (!Directory.Exists(path))
            {
                menuItemBackupPath_Click(sender, e);
            }
            ConnectionService.GetInstance().MakeBackup();
        }

        private void menuItemBackupPath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    Properties.Settings.Default.BackupFolder = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                    MessageBox.Show($@"Backup será salvo na pasta: {fbd.SelectedPath}");
                }
            }
        }

        private void menuItemAlterarSenha_Click(object sender, EventArgs e)
        {
            new Forms.Settings.ChangePassword().ShowDialog();
        }

        private void menuItemSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItemConsumo_Click(object sender, EventArgs e)
        {
            new Consumo().ShowDialog();
        }
    }
}