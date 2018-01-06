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
            this.menuItemEntradaProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCaixa = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemSQLServer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemSair = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemComandas = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLivroCaixa = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCaixa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnProdutos = new System.Windows.Forms.ToolStripButton();
            this.btnComandas = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEntradaProdutos = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRelatorios = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ttsIP = new System.Windows.Forms.ToolStripStatusLabel();
            this.ttsMachineName = new System.Windows.Forms.ToolStripStatusLabel();
            this.ttsIPDB = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuItemBackupPath = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sistemaToolStripMenuItem,
            this.cadastrosToolStripMenuItem,
            this.relatóriosToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1008, 24);
            this.mainMenu.TabIndex = 5;
            this.mainMenu.Text = "menuStrip1";
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemEntradaProduto,
            this.menuItemCaixa,
            this.toolStripSeparator1,
            this.menuItemBackupPath,
            this.menuItemBackup,
            this.menuItemSQLServer,
            this.toolStripSeparator5,
            this.menuItemSair});
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // menuItemEntradaProduto
            // 
            this.menuItemEntradaProduto.Name = "menuItemEntradaProduto";
            this.menuItemEntradaProduto.Size = new System.Drawing.Size(190, 22);
            this.menuItemEntradaProduto.Text = "Entrada de Produtos";
            this.menuItemEntradaProduto.Visible = false;
            this.menuItemEntradaProduto.Click += new System.EventHandler(this.menuItemEntradaProduto_Click);
            // 
            // menuItemCaixa
            // 
            this.menuItemCaixa.Name = "menuItemCaixa";
            this.menuItemCaixa.Size = new System.Drawing.Size(190, 22);
            this.menuItemCaixa.Text = "Caixa";
            this.menuItemCaixa.Click += new System.EventHandler(this.menuItemCaixa_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // menuItemSQLServer
            // 
            this.menuItemSQLServer.Enabled = false;
            this.menuItemSQLServer.Name = "menuItemSQLServer";
            this.menuItemSQLServer.Size = new System.Drawing.Size(190, 22);
            this.menuItemSQLServer.Text = "Configurar SQL Server";
            this.menuItemSQLServer.Click += new System.EventHandler(this.menuItemSQLServer_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(187, 6);
            // 
            // menuItemSair
            // 
            this.menuItemSair.Name = "menuItemSair";
            this.menuItemSair.Size = new System.Drawing.Size(190, 22);
            this.menuItemSair.Text = "Sair";
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
            this.menuItemProdutos.Size = new System.Drawing.Size(131, 22);
            this.menuItemProdutos.Text = "Produtos";
            this.menuItemProdutos.Click += new System.EventHandler(this.menuItemProdutos_Click);
            // 
            // menuItemComandas
            // 
            this.menuItemComandas.Name = "menuItemComandas";
            this.menuItemComandas.Size = new System.Drawing.Size(131, 22);
            this.menuItemComandas.Text = "Comandas";
            this.menuItemComandas.Click += new System.EventHandler(this.menuItemComandas_Click);
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLivroCaixa});
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.relatóriosToolStripMenuItem.Text = "Relatórios";
            // 
            // menuItemLivroCaixa
            // 
            this.menuItemLivroCaixa.Name = "menuItemLivroCaixa";
            this.menuItemLivroCaixa.Size = new System.Drawing.Size(131, 22);
            this.menuItemLivroCaixa.Text = "Livro Caixa";
            this.menuItemLivroCaixa.Click += new System.EventHandler(this.menuItemLivroCaixa_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCaixa,
            this.toolStripSeparator4,
            this.btnProdutos,
            this.btnComandas,
            this.toolStripSeparator2,
            this.btnEntradaProdutos,
            this.toolStripSeparator3,
            this.btnRelatorios});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCaixa
            // 
            this.btnCaixa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCaixa.Image = ((System.Drawing.Image)(resources.GetObject("btnCaixa.Image")));
            this.btnCaixa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCaixa.Name = "btnCaixa";
            this.btnCaixa.Size = new System.Drawing.Size(62, 22);
            this.btnCaixa.Text = "(F2) Caixa";
            this.btnCaixa.Click += new System.EventHandler(this.btnCaixa_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnProdutos
            // 
            this.btnProdutos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnProdutos.Image = ((System.Drawing.Image)(resources.GetObject("btnProdutos.Image")));
            this.btnProdutos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new System.Drawing.Size(82, 22);
            this.btnProdutos.Text = "(F3) Produtos";
            this.btnProdutos.Click += new System.EventHandler(this.btnProdutos_Click);
            // 
            // btnComandas
            // 
            this.btnComandas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnComandas.Image = ((System.Drawing.Image)(resources.GetObject("btnComandas.Image")));
            this.btnComandas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnComandas.Name = "btnComandas";
            this.btnComandas.Size = new System.Drawing.Size(91, 22);
            this.btnComandas.Text = "(F4) Comandas";
            this.btnComandas.Click += new System.EventHandler(this.btnComandas_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator2.Visible = false;
            // 
            // btnEntradaProdutos
            // 
            this.btnEntradaProdutos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEntradaProdutos.Image = ((System.Drawing.Image)(resources.GetObject("btnEntradaProdutos.Image")));
            this.btnEntradaProdutos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEntradaProdutos.Name = "btnEntradaProdutos";
            this.btnEntradaProdutos.Size = new System.Drawing.Size(141, 22);
            this.btnEntradaProdutos.Text = "(F5) Entrada de Produtos";
            this.btnEntradaProdutos.Visible = false;
            this.btnEntradaProdutos.Click += new System.EventHandler(this.btnEntradaProdutos_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRelatorios
            // 
            this.btnRelatorios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRelatorios.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatorios.Image")));
            this.btnRelatorios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRelatorios.Name = "btnRelatorios";
            this.btnRelatorios.Size = new System.Drawing.Size(86, 22);
            this.btnRelatorios.Text = "(F6) Relatórios";
            this.btnRelatorios.Click += new System.EventHandler(this.btnRelatorios_Click);
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
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
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemCaixa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemSair;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemProdutos;
        private System.Windows.Forms.ToolStripMenuItem menuItemComandas;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemLivroCaixa;
        private System.Windows.Forms.ToolStripMenuItem menuItemEntradaProduto;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCaixa;
        private System.Windows.Forms.ToolStripButton btnProdutos;
        private System.Windows.Forms.ToolStripButton btnComandas;
        private System.Windows.Forms.ToolStripButton btnEntradaProdutos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnRelatorios;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ttsIP;
        private System.Windows.Forms.ToolStripMenuItem menuItemSQLServer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel ttsMachineName;
        private System.Windows.Forms.ToolStripStatusLabel ttsIPDB;
        private System.Windows.Forms.ToolStripMenuItem menuItemBackupPath;
        private System.Windows.Forms.ToolStripMenuItem menuItemBackup;
    }
}