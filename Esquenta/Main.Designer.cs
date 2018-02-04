namespace Esquenta
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCaixa = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemSair = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemComandas = new System.Windows.Forms.ToolStripMenuItem();
            this.relatoriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLivroCaixa = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracoesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBackupPath = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSQLServer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAlterarSenha = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ttsIP = new System.Windows.Forms.ToolStripStatusLabel();
            this.ttsMachineName = new System.Windows.Forms.ToolStripStatusLabel();
            this.ttsIPDB = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuItemConsumo = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sistemaToolStripMenuItem,
            this.cadastrosToolStripMenuItem,
            this.relatoriosToolStripMenuItem,
            this.configuracoesToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1008, 24);
            this.mainMenu.TabIndex = 5;
            this.mainMenu.Text = "menuStrip1";
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCaixa,
            this.toolStripSeparator5,
            this.menuItemSair});
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // menuItemCaixa
            // 
            this.menuItemCaixa.Name = "menuItemCaixa";
            this.menuItemCaixa.Size = new System.Drawing.Size(125, 22);
            this.menuItemCaixa.Text = "Caixa (F2)";
            this.menuItemCaixa.Click += new System.EventHandler(this.menuItemCaixa_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(122, 6);
            // 
            // menuItemSair
            // 
            this.menuItemSair.Name = "menuItemSair";
            this.menuItemSair.Size = new System.Drawing.Size(125, 22);
            this.menuItemSair.Text = "Sair";
            this.menuItemSair.Click += new System.EventHandler(this.menuItemSair_Click);
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemProdutos,
            this.menuItemComandas});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // menuItemProdutos
            // 
            this.menuItemProdutos.Name = "menuItemProdutos";
            this.menuItemProdutos.Size = new System.Drawing.Size(154, 22);
            this.menuItemProdutos.Text = "Produtos (F3)";
            this.menuItemProdutos.Click += new System.EventHandler(this.menuItemProdutos_Click);
            // 
            // menuItemComandas
            // 
            this.menuItemComandas.Name = "menuItemComandas";
            this.menuItemComandas.Size = new System.Drawing.Size(154, 22);
            this.menuItemComandas.Text = "Comandas (F4)";
            this.menuItemComandas.Click += new System.EventHandler(this.menuItemComandas_Click);
            // 
            // relatoriosToolStripMenuItem
            // 
            this.relatoriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLivroCaixa,
            this.menuItemConsumo});
            this.relatoriosToolStripMenuItem.Name = "relatoriosToolStripMenuItem";
            this.relatoriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.relatoriosToolStripMenuItem.Text = "Relatórios";
            // 
            // menuItemLivroCaixa
            // 
            this.menuItemLivroCaixa.Name = "menuItemLivroCaixa";
            this.menuItemLivroCaixa.Size = new System.Drawing.Size(154, 22);
            this.menuItemLivroCaixa.Text = "Livro Caixa (F6)";
            this.menuItemLivroCaixa.Click += new System.EventHandler(this.menuItemLivroCaixa_Click);
            // 
            // configuracoesToolStripMenuItem
            // 
            this.configuracoesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemBackupPath,
            this.menuItemBackup,
            this.menuItemSQLServer,
            this.menuItemAlterarSenha});
            this.configuracoesToolStripMenuItem.Name = "configuracoesToolStripMenuItem";
            this.configuracoesToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.configuracoesToolStripMenuItem.Text = "Configurações";
            // 
            // menuItemBackupPath
            // 
            this.menuItemBackupPath.Name = "menuItemBackupPath";
            this.menuItemBackupPath.Size = new System.Drawing.Size(190, 22);
            this.menuItemBackupPath.Text = "Ajustar Backup";
            this.menuItemBackupPath.Click += new System.EventHandler(this.menuItemBackupPath_Click);
            // 
            // menuItemBackup
            // 
            this.menuItemBackup.Name = "menuItemBackup";
            this.menuItemBackup.Size = new System.Drawing.Size(190, 22);
            this.menuItemBackup.Text = "Backup";
            this.menuItemBackup.Click += new System.EventHandler(this.menuItemBackup_Click);
            // 
            // menuItemSQLServer
            // 
            this.menuItemSQLServer.Name = "menuItemSQLServer";
            this.menuItemSQLServer.Size = new System.Drawing.Size(190, 22);
            this.menuItemSQLServer.Text = "Configurar SQL Server";
            this.menuItemSQLServer.Click += new System.EventHandler(this.menuItemSQLServer_Click);
            // 
            // menuItemAlterarSenha
            // 
            this.menuItemAlterarSenha.Name = "menuItemAlterarSenha";
            this.menuItemAlterarSenha.Size = new System.Drawing.Size(190, 22);
            this.menuItemAlterarSenha.Text = "Alterar Senha";
            this.menuItemAlterarSenha.Click += new System.EventHandler(this.menuItemAlterarSenha_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttsIP,
            this.ttsMachineName,
            this.ttsIPDB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 707);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ttsIP
            // 
            this.ttsIP.Name = "ttsIP";
            this.ttsIP.Size = new System.Drawing.Size(23, 17);
            this.ttsIP.Text = "IP: ";
            // 
            // ttsMachineName
            // 
            this.ttsMachineName.Name = "ttsMachineName";
            this.ttsMachineName.Size = new System.Drawing.Size(56, 17);
            this.ttsMachineName.Text = "Terminal:";
            // 
            // ttsIPDB
            // 
            this.ttsIPDB.Name = "ttsIPDB";
            this.ttsIPDB.Size = new System.Drawing.Size(108, 17);
            this.ttsIPDB.Text = "IP Banco de Dados:";
            // 
            // menuItemConsumo
            // 
            this.menuItemConsumo.Name = "menuItemConsumo";
            this.menuItemConsumo.Size = new System.Drawing.Size(154, 22);
            this.menuItemConsumo.Text = "Consumo";
            this.menuItemConsumo.Click += new System.EventHandler(this.menuItemConsumo_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(1024, 736);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Esquenta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Main_KeyUp);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemCaixa;
        private System.Windows.Forms.ToolStripMenuItem menuItemSair;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemProdutos;
        private System.Windows.Forms.ToolStripMenuItem menuItemComandas;
        private System.Windows.Forms.ToolStripMenuItem relatoriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemLivroCaixa;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ttsIP;
        private System.Windows.Forms.ToolStripMenuItem menuItemSQLServer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripStatusLabel ttsMachineName;
        private System.Windows.Forms.ToolStripStatusLabel ttsIPDB;
        private System.Windows.Forms.ToolStripMenuItem menuItemBackupPath;
        private System.Windows.Forms.ToolStripMenuItem menuItemBackup;
        private System.Windows.Forms.ToolStripMenuItem configuracoesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemAlterarSenha;
        private System.Windows.Forms.ToolStripMenuItem menuItemConsumo;
    }
}