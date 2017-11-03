namespace Esquenta.Forms.Relatorios
{
    partial class Vendas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblDesconto = new System.Windows.Forms.Label();
            this.lblTotalItens = new System.Windows.Forms.Label();
            this.BtnFecharCaixa = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dgvDetalheProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDetalheQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDetalheValorUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDetalheValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dvgVendaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvgVendaComanda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvgVendaDataHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvgVendaValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvgVendaAcrescimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvgVendaDesconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvgVendaValorFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAcrescimo = new System.Windows.Forms.Label();
            this.lblValorTotalVenda = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblAcrescimo);
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Controls.Add(this.lblDesconto);
            this.panel2.Controls.Add(this.lblTotalItens);
            this.panel2.Controls.Add(this.BtnFecharCaixa);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 69);
            this.panel2.TabIndex = 6;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(12, 33);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(300, 25);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Valor total em vendas: R$ 0,00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDesconto
            // 
            this.lblDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesconto.Location = new System.Drawing.Point(318, 9);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(300, 25);
            this.lblDesconto.TabIndex = 2;
            this.lblDesconto.Text = "Valor em descontos: R$ 0,00";
            this.lblDesconto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTotalItens
            // 
            this.lblTotalItens.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItens.Location = new System.Drawing.Point(12, 9);
            this.lblTotalItens.Name = "lblTotalItens";
            this.lblTotalItens.Size = new System.Drawing.Size(300, 25);
            this.lblTotalItens.TabIndex = 1;
            this.lblTotalItens.Text = "Total de vendas: 0";
            this.lblTotalItens.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BtnFecharCaixa
            // 
            this.BtnFecharCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnFecharCaixa.Location = new System.Drawing.Point(652, 9);
            this.BtnFecharCaixa.Name = "BtnFecharCaixa";
            this.BtnFecharCaixa.Size = new System.Drawing.Size(120, 49);
            this.BtnFecharCaixa.TabIndex = 0;
            this.BtnFecharCaixa.Text = "Fechar Caixa";
            this.BtnFecharCaixa.UseVisualStyleBackColor = true;
            this.BtnFecharCaixa.Click += new System.EventHandler(this.BtnFecharCaixa_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblValorTotalVenda);
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 492);
            this.panel1.TabIndex = 7;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvDetalheProduto,
            this.dgvDetalheQuantidade,
            this.dgvDetalheValorUnitario,
            this.dgvDetalheValorTotal});
            this.dataGridView2.Location = new System.Drawing.Point(190, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(594, 447);
            this.dataGridView2.TabIndex = 2;
            // 
            // dgvDetalheProduto
            // 
            this.dgvDetalheProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvDetalheProduto.HeaderText = "Produto";
            this.dgvDetalheProduto.Name = "dgvDetalheProduto";
            this.dgvDetalheProduto.ReadOnly = true;
            // 
            // dgvDetalheQuantidade
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvDetalheQuantidade.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvDetalheQuantidade.HeaderText = "Quantidade";
            this.dgvDetalheQuantidade.Name = "dgvDetalheQuantidade";
            this.dgvDetalheQuantidade.ReadOnly = true;
            // 
            // dgvDetalheValorUnitario
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "C2";
            dataGridViewCellStyle19.NullValue = null;
            this.dgvDetalheValorUnitario.DefaultCellStyle = dataGridViewCellStyle19;
            this.dgvDetalheValorUnitario.HeaderText = "Valor Unitário";
            this.dgvDetalheValorUnitario.Name = "dgvDetalheValorUnitario";
            this.dgvDetalheValorUnitario.ReadOnly = true;
            // 
            // dgvDetalheValorTotal
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle20.Format = "C2";
            dataGridViewCellStyle20.NullValue = null;
            this.dgvDetalheValorTotal.DefaultCellStyle = dataGridViewCellStyle20;
            this.dgvDetalheValorTotal.HeaderText = "Valor Total";
            this.dgvDetalheValorTotal.Name = "dgvDetalheValorTotal";
            this.dgvDetalheValorTotal.ReadOnly = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dvgVendaID,
            this.dvgVendaComanda,
            this.dvgVendaDataHora,
            this.dvgVendaValorTotal,
            this.dvgVendaAcrescimo,
            this.dvgVendaDesconto,
            this.dvgVendaValorFinal});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridView1.Size = new System.Drawing.Size(184, 492);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            // 
            // dvgVendaID
            // 
            this.dvgVendaID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dvgVendaID.HeaderText = "ID";
            this.dvgVendaID.Name = "dvgVendaID";
            this.dvgVendaID.ReadOnly = true;
            this.dvgVendaID.Width = 43;
            // 
            // dvgVendaComanda
            // 
            this.dvgVendaComanda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dvgVendaComanda.HeaderText = "Comanda";
            this.dvgVendaComanda.Name = "dvgVendaComanda";
            this.dvgVendaComanda.ReadOnly = true;
            // 
            // dvgVendaDataHora
            // 
            this.dvgVendaDataHora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dvgVendaDataHora.HeaderText = "Data/Hora";
            this.dvgVendaDataHora.Name = "dvgVendaDataHora";
            this.dvgVendaDataHora.ReadOnly = true;
            this.dvgVendaDataHora.Width = 83;
            // 
            // dvgVendaValorTotal
            // 
            this.dvgVendaValorTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "C2";
            dataGridViewCellStyle12.NullValue = null;
            this.dvgVendaValorTotal.DefaultCellStyle = dataGridViewCellStyle12;
            this.dvgVendaValorTotal.HeaderText = "Valor em Compras";
            this.dvgVendaValorTotal.Name = "dvgVendaValorTotal";
            this.dvgVendaValorTotal.ReadOnly = true;
            this.dvgVendaValorTotal.Width = 107;
            // 
            // dvgVendaAcrescimo
            // 
            this.dvgVendaAcrescimo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "C2";
            dataGridViewCellStyle13.NullValue = null;
            this.dvgVendaAcrescimo.DefaultCellStyle = dataGridViewCellStyle13;
            this.dvgVendaAcrescimo.HeaderText = "Acréscimo";
            this.dvgVendaAcrescimo.Name = "dvgVendaAcrescimo";
            this.dvgVendaAcrescimo.ReadOnly = true;
            this.dvgVendaAcrescimo.Width = 81;
            // 
            // dvgVendaDesconto
            // 
            this.dvgVendaDesconto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "C2";
            dataGridViewCellStyle14.NullValue = null;
            this.dvgVendaDesconto.DefaultCellStyle = dataGridViewCellStyle14;
            this.dvgVendaDesconto.HeaderText = "Desconto";
            this.dvgVendaDesconto.Name = "dvgVendaDesconto";
            this.dvgVendaDesconto.ReadOnly = true;
            this.dvgVendaDesconto.Width = 78;
            // 
            // dvgVendaValorFinal
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "C2";
            dataGridViewCellStyle15.NullValue = null;
            this.dvgVendaValorFinal.DefaultCellStyle = dataGridViewCellStyle15;
            this.dvgVendaValorFinal.HeaderText = "Valor Final";
            this.dvgVendaValorFinal.Name = "dvgVendaValorFinal";
            this.dvgVendaValorFinal.ReadOnly = true;
            // 
            // lblAcrescimo
            // 
            this.lblAcrescimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcrescimo.Location = new System.Drawing.Point(318, 33);
            this.lblAcrescimo.Name = "lblAcrescimo";
            this.lblAcrescimo.Size = new System.Drawing.Size(300, 25);
            this.lblAcrescimo.TabIndex = 4;
            this.lblAcrescimo.Text = "Valor em acréscimo: R$ 0,00";
            this.lblAcrescimo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblValorTotalVenda
            // 
            this.lblValorTotalVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValorTotalVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotalVenda.Location = new System.Drawing.Point(472, 458);
            this.lblValorTotalVenda.Name = "lblValorTotalVenda";
            this.lblValorTotalVenda.Size = new System.Drawing.Size(300, 25);
            this.lblValorTotalVenda.TabIndex = 4;
            this.lblValorTotalVenda.Text = "Valor total em vendas: R$ 0,00";
            this.lblValorTotalVenda.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Vendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.Name = "Vendas";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Vendas";
            this.Load += new System.EventHandler(this.Vendas_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Vendas_KeyUp);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDesconto;
        private System.Windows.Forms.Label lblTotalItens;
        private System.Windows.Forms.Button BtnFecharCaixa;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvgVendaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvgVendaComanda;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvgVendaDataHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvgVendaValorTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvgVendaAcrescimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvgVendaDesconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvgVendaValorFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDetalheProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDetalheQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDetalheValorUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDetalheValorTotal;
        private System.Windows.Forms.Label lblAcrescimo;
        private System.Windows.Forms.Label lblValorTotalVenda;
    }
}