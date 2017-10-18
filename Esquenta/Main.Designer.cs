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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCaixa = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemSair = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemComandas = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLivroCaixa = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEntradaProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sistemaToolStripMenuItem,
            this.cadastrosToolStripMenuItem,
            this.relatóriosToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(624, 24);
            this.mainMenu.TabIndex = 5;
            this.mainMenu.Text = "menuStrip1";
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemEntradaProduto,
            this.menuItemCaixa,
            this.toolStripSeparator1,
            this.menuItemSair});
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // menuItemCaixa
            // 
            this.menuItemCaixa.Name = "menuItemCaixa";
            this.menuItemCaixa.Size = new System.Drawing.Size(181, 22);
            this.menuItemCaixa.Text = "Caixa";
            this.menuItemCaixa.Click += new System.EventHandler(this.menuItemCaixa_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // menuItemSair
            // 
            this.menuItemSair.Name = "menuItemSair";
            this.menuItemSair.Size = new System.Drawing.Size(181, 22);
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
            this.menuItemProdutos.Size = new System.Drawing.Size(152, 22);
            this.menuItemProdutos.Text = "Produtos";
            this.menuItemProdutos.Click += new System.EventHandler(this.menuItemProdutos_Click);
            // 
            // menuItemComandas
            // 
            this.menuItemComandas.Name = "menuItemComandas";
            this.menuItemComandas.Size = new System.Drawing.Size(152, 22);
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
            this.menuItemLivroCaixa.Size = new System.Drawing.Size(152, 22);
            this.menuItemLivroCaixa.Text = "Livro Caixa";
            this.menuItemLivroCaixa.Click += new System.EventHandler(this.menuItemLivroCaixa_Click);
            // 
            // menuItemEntradaProduto
            // 
            this.menuItemEntradaProduto.Name = "menuItemEntradaProduto";
            this.menuItemEntradaProduto.Size = new System.Drawing.Size(181, 22);
            this.menuItemEntradaProduto.Text = "Entrada de Produtos";
            this.menuItemEntradaProduto.Click += new System.EventHandler(this.menuItemEntradaProduto_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.mainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "Main";
            this.Text = "Esquenta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
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
    }
}