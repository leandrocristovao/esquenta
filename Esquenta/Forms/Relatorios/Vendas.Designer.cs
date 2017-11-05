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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mCalendar = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAcrescimo = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblDesconto = new System.Windows.Forms.Label();
            this.lblTotalItens = new System.Windows.Forms.Label();
            this.BtnFecharCaixa = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvConsumo = new System.Windows.Forms.DataGridView();
            this.lblValorTotalVenda = new System.Windows.Forms.Label();
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
            this.dgvConsumoProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvConsumoQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.mCalendar);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblAcrescimo);
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Controls.Add(this.lblDesconto);
            this.panel2.Controls.Add(this.lblTotalItens);
            this.panel2.Controls.Add(this.BtnFecharCaixa);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1078, 200);
            this.panel2.TabIndex = 6;
            // 
            // mCalendar
            // 
            this.mCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mCalendar.Location = new System.Drawing.Point(839, 26);
            this.mCalendar.MaxSelectionCount = 31;
            this.mCalendar.Name = "mCalendar";
            this.mCalendar.TabIndex = 7;
            this.mCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mCalendar_DateChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(841, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Período";
            // 
            // lblAcrescimo
            // 
            this.lblAcrescimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcrescimo.Location = new System.Drawing.Point(12, 82);
            this.lblAcrescimo.Name = "lblAcrescimo";
            this.lblAcrescimo.Size = new System.Drawing.Size(300, 25);
            this.lblAcrescimo.TabIndex = 4;
            this.lblAcrescimo.Text = "Valor em acréscimo: R$ 0,00";
            this.lblAcrescimo.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.lblDesconto.Location = new System.Drawing.Point(12, 58);
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
            this.BtnFecharCaixa.Location = new System.Drawing.Point(192, 110);
            this.BtnFecharCaixa.Name = "BtnFecharCaixa";
            this.BtnFecharCaixa.Size = new System.Drawing.Size(120, 74);
            this.BtnFecharCaixa.TabIndex = 0;
            this.BtnFecharCaixa.Text = "Fechar Caixa";
            this.BtnFecharCaixa.UseVisualStyleBackColor = true;
            this.BtnFecharCaixa.Click += new System.EventHandler(this.BtnFecharCaixa_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvConsumo);
            this.panel1.Controls.Add(this.lblValorTotalVenda);
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 200);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1078, 361);
            this.panel1.TabIndex = 7;
            // 
            // dgvConsumo
            // 
            this.dgvConsumo.AllowUserToAddRows = false;
            this.dgvConsumo.AllowUserToDeleteRows = false;
            this.dgvConsumo.AllowUserToOrderColumns = true;
            this.dgvConsumo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsumo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle31;
            this.dgvConsumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsumo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvConsumoProduto,
            this.dgvConsumoQuantidade});
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConsumo.DefaultCellStyle = dataGridViewCellStyle34;
            this.dgvConsumo.Location = new System.Drawing.Point(0, 157);
            this.dgvConsumo.Name = "dgvConsumo";
            this.dgvConsumo.ReadOnly = true;
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsumo.RowHeadersDefaultCellStyle = dataGridViewCellStyle35;
            this.dgvConsumo.Size = new System.Drawing.Size(478, 204);
            this.dgvConsumo.TabIndex = 5;
            // 
            // lblValorTotalVenda
            // 
            this.lblValorTotalVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValorTotalVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotalVenda.Location = new System.Drawing.Point(766, 327);
            this.lblValorTotalVenda.Name = "lblValorTotalVenda";
            this.lblValorTotalVenda.Size = new System.Drawing.Size(300, 25);
            this.lblValorTotalVenda.TabIndex = 4;
            this.lblValorTotalVenda.Text = "Valor total em vendas: R$ 0,00";
            this.lblValorTotalVenda.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.dataGridView2.Location = new System.Drawing.Point(484, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(594, 316);
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
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvDetalheQuantidade.DefaultCellStyle = dataGridViewCellStyle36;
            this.dgvDetalheQuantidade.HeaderText = "Quantidade";
            this.dgvDetalheQuantidade.Name = "dgvDetalheQuantidade";
            this.dgvDetalheQuantidade.ReadOnly = true;
            // 
            // dgvDetalheValorUnitario
            // 
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle37.Format = "C2";
            dataGridViewCellStyle37.NullValue = null;
            this.dgvDetalheValorUnitario.DefaultCellStyle = dataGridViewCellStyle37;
            this.dgvDetalheValorUnitario.HeaderText = "Valor Unitário";
            this.dgvDetalheValorUnitario.Name = "dgvDetalheValorUnitario";
            this.dgvDetalheValorUnitario.ReadOnly = true;
            // 
            // dgvDetalheValorTotal
            // 
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle38.Format = "C2";
            dataGridViewCellStyle38.NullValue = null;
            this.dgvDetalheValorTotal.DefaultCellStyle = dataGridViewCellStyle38;
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
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle39.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle39;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dvgVendaID,
            this.dvgVendaComanda,
            this.dvgVendaDataHora,
            this.dvgVendaValorTotal,
            this.dvgVendaAcrescimo,
            this.dvgVendaDesconto,
            this.dvgVendaValorFinal});
            dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle44.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle44.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle44.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle44.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle44.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle44;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle45.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle45.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle45.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle45.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle45.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle45.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle45;
            this.dataGridView1.Size = new System.Drawing.Size(478, 151);
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
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle40.Format = "C2";
            dataGridViewCellStyle40.NullValue = null;
            this.dvgVendaValorTotal.DefaultCellStyle = dataGridViewCellStyle40;
            this.dvgVendaValorTotal.HeaderText = "Valor em Compras";
            this.dvgVendaValorTotal.Name = "dvgVendaValorTotal";
            this.dvgVendaValorTotal.ReadOnly = true;
            this.dvgVendaValorTotal.Width = 107;
            // 
            // dvgVendaAcrescimo
            // 
            this.dvgVendaAcrescimo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle41.Format = "C2";
            dataGridViewCellStyle41.NullValue = null;
            this.dvgVendaAcrescimo.DefaultCellStyle = dataGridViewCellStyle41;
            this.dvgVendaAcrescimo.HeaderText = "Acréscimo";
            this.dvgVendaAcrescimo.Name = "dvgVendaAcrescimo";
            this.dvgVendaAcrescimo.ReadOnly = true;
            this.dvgVendaAcrescimo.Width = 81;
            // 
            // dvgVendaDesconto
            // 
            this.dvgVendaDesconto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle42.Format = "C2";
            dataGridViewCellStyle42.NullValue = null;
            this.dvgVendaDesconto.DefaultCellStyle = dataGridViewCellStyle42;
            this.dvgVendaDesconto.HeaderText = "Desconto";
            this.dvgVendaDesconto.Name = "dvgVendaDesconto";
            this.dvgVendaDesconto.ReadOnly = true;
            this.dvgVendaDesconto.Width = 78;
            // 
            // dvgVendaValorFinal
            // 
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle43.Format = "C2";
            dataGridViewCellStyle43.NullValue = null;
            this.dvgVendaValorFinal.DefaultCellStyle = dataGridViewCellStyle43;
            this.dvgVendaValorFinal.HeaderText = "Valor Final";
            this.dvgVendaValorFinal.Name = "dvgVendaValorFinal";
            this.dvgVendaValorFinal.ReadOnly = true;
            // 
            // dgvConsumoProduto
            // 
            this.dgvConsumoProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.NullValue = null;
            this.dgvConsumoProduto.DefaultCellStyle = dataGridViewCellStyle32;
            this.dgvConsumoProduto.HeaderText = "Produto";
            this.dgvConsumoProduto.Name = "dgvConsumoProduto";
            this.dgvConsumoProduto.ReadOnly = true;
            // 
            // dgvConsumoQuantidade
            // 
            this.dgvConsumoQuantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle33.Format = "C2";
            dataGridViewCellStyle33.NullValue = null;
            this.dgvConsumoQuantidade.DefaultCellStyle = dataGridViewCellStyle33;
            this.dgvConsumoQuantidade.HeaderText = "Quantidade";
            this.dgvConsumoQuantidade.Name = "dgvConsumoQuantidade";
            this.dgvConsumoQuantidade.ReadOnly = true;
            this.dgvConsumoQuantidade.Width = 87;
            // 
            // Vendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 561);
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
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumo)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvConsumo;
        private System.Windows.Forms.MonthCalendar mCalendar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvConsumoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvConsumoQuantidade;
    }
}