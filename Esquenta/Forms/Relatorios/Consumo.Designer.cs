namespace Esquenta.Forms.Relatorios
{
    partial class Consumo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpPeriodo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComanda = new System.Windows.Forms.TextBox();
            this.dgvVendas = new System.Windows.Forms.DataGridView();
            this.dvgVendaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvgVendaDataHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvgVendaValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvgVendaCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvgVendaCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvgVendaD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvgVendaAcrescimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvgVendaDesconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvgVendaValorFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEmAberto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvItens = new System.Windows.Forms.DataGridView();
            this.dgvDetalheDataHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDetalheProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDetalheQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDetalheValorUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDetalheValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente";
            // 
            // dtpPeriodo
            // 
            this.dtpPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpPeriodo.Location = new System.Drawing.Point(903, 26);
            this.dtpPeriodo.Name = "dtpPeriodo";
            this.dtpPeriodo.Size = new System.Drawing.Size(256, 20);
            this.dtpPeriodo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(900, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Período";
            // 
            // txtComanda
            // 
            this.txtComanda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComanda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtComanda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtComanda.Location = new System.Drawing.Point(12, 26);
            this.txtComanda.Name = "txtComanda";
            this.txtComanda.Size = new System.Drawing.Size(885, 20);
            this.txtComanda.TabIndex = 9;
            this.txtComanda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtComanda_KeyDown);
            // 
            // dgvVendas
            // 
            this.dgvVendas.AllowUserToAddRows = false;
            this.dgvVendas.AllowUserToOrderColumns = true;
            this.dgvVendas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVendas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dvgVendaID,
            this.dvgVendaDataHora,
            this.dvgVendaValorTotal,
            this.dvgVendaCC,
            this.dvgVendaCD,
            this.dvgVendaD,
            this.dvgVendaAcrescimo,
            this.dvgVendaDesconto,
            this.dvgVendaValorFinal,
            this.dgvEmAberto});
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVendas.DefaultCellStyle = dataGridViewCellStyle23;
            this.dgvVendas.Location = new System.Drawing.Point(12, 52);
            this.dgvVendas.MultiSelect = false;
            this.dgvVendas.Name = "dgvVendas";
            this.dgvVendas.ReadOnly = true;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVendas.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dgvVendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendas.Size = new System.Drawing.Size(885, 483);
            this.dgvVendas.TabIndex = 10;
            // 
            // dvgVendaID
            // 
            this.dvgVendaID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dvgVendaID.HeaderText = "ID";
            this.dvgVendaID.Name = "dvgVendaID";
            this.dvgVendaID.ReadOnly = true;
            this.dvgVendaID.Width = 43;
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
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "C2";
            dataGridViewCellStyle16.NullValue = null;
            this.dvgVendaValorTotal.DefaultCellStyle = dataGridViewCellStyle16;
            this.dvgVendaValorTotal.HeaderText = "Valor em Compras";
            this.dvgVendaValorTotal.Name = "dvgVendaValorTotal";
            this.dvgVendaValorTotal.ReadOnly = true;
            this.dvgVendaValorTotal.Width = 107;
            // 
            // dvgVendaCC
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "C2";
            this.dvgVendaCC.DefaultCellStyle = dataGridViewCellStyle17;
            this.dvgVendaCC.HeaderText = "CC";
            this.dvgVendaCC.Name = "dvgVendaCC";
            this.dvgVendaCC.ReadOnly = true;
            // 
            // dvgVendaCD
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "C2";
            this.dvgVendaCD.DefaultCellStyle = dataGridViewCellStyle18;
            this.dvgVendaCD.HeaderText = "CD";
            this.dvgVendaCD.Name = "dvgVendaCD";
            this.dvgVendaCD.ReadOnly = true;
            // 
            // dvgVendaD
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "C2";
            this.dvgVendaD.DefaultCellStyle = dataGridViewCellStyle19;
            this.dvgVendaD.HeaderText = "D";
            this.dvgVendaD.Name = "dvgVendaD";
            this.dvgVendaD.ReadOnly = true;
            // 
            // dvgVendaAcrescimo
            // 
            this.dvgVendaAcrescimo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle20.Format = "C2";
            dataGridViewCellStyle20.NullValue = null;
            this.dvgVendaAcrescimo.DefaultCellStyle = dataGridViewCellStyle20;
            this.dvgVendaAcrescimo.HeaderText = "Acréscimo";
            this.dvgVendaAcrescimo.Name = "dvgVendaAcrescimo";
            this.dvgVendaAcrescimo.ReadOnly = true;
            this.dvgVendaAcrescimo.Width = 81;
            // 
            // dvgVendaDesconto
            // 
            this.dvgVendaDesconto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.Format = "C2";
            dataGridViewCellStyle21.NullValue = null;
            this.dvgVendaDesconto.DefaultCellStyle = dataGridViewCellStyle21;
            this.dvgVendaDesconto.HeaderText = "Desconto";
            this.dvgVendaDesconto.Name = "dvgVendaDesconto";
            this.dvgVendaDesconto.ReadOnly = true;
            this.dvgVendaDesconto.Width = 78;
            // 
            // dvgVendaValorFinal
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.Format = "C2";
            dataGridViewCellStyle22.NullValue = null;
            this.dvgVendaValorFinal.DefaultCellStyle = dataGridViewCellStyle22;
            this.dvgVendaValorFinal.HeaderText = "Valor Final";
            this.dvgVendaValorFinal.Name = "dvgVendaValorFinal";
            this.dvgVendaValorFinal.ReadOnly = true;
            // 
            // dgvEmAberto
            // 
            this.dgvEmAberto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvEmAberto.HeaderText = "EmAberto";
            this.dgvEmAberto.Name = "dgvEmAberto";
            this.dgvEmAberto.ReadOnly = true;
            this.dgvEmAberto.Visible = false;
            // 
            // dgvItens
            // 
            this.dgvItens.AllowUserToAddRows = false;
            this.dgvItens.AllowUserToDeleteRows = false;
            this.dgvItens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvDetalheDataHora,
            this.dgvDetalheProduto,
            this.dgvDetalheQuantidade,
            this.dgvDetalheValorUnitario,
            this.dgvDetalheValorTotal});
            this.dgvItens.Location = new System.Drawing.Point(903, 52);
            this.dgvItens.MultiSelect = false;
            this.dgvItens.Name = "dgvItens";
            this.dgvItens.ReadOnly = true;
            this.dgvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItens.Size = new System.Drawing.Size(256, 483);
            this.dgvItens.TabIndex = 11;
            // 
            // dgvDetalheDataHora
            // 
            dataGridViewCellStyle25.Format = "g";
            dataGridViewCellStyle25.NullValue = null;
            this.dgvDetalheDataHora.DefaultCellStyle = dataGridViewCellStyle25;
            this.dgvDetalheDataHora.HeaderText = "Data/Hora";
            this.dgvDetalheDataHora.Name = "dgvDetalheDataHora";
            this.dgvDetalheDataHora.ReadOnly = true;
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
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvDetalheQuantidade.DefaultCellStyle = dataGridViewCellStyle26;
            this.dgvDetalheQuantidade.HeaderText = "Quantidade";
            this.dgvDetalheQuantidade.Name = "dgvDetalheQuantidade";
            this.dgvDetalheQuantidade.ReadOnly = true;
            // 
            // dgvDetalheValorUnitario
            // 
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle27.Format = "C2";
            dataGridViewCellStyle27.NullValue = null;
            this.dgvDetalheValorUnitario.DefaultCellStyle = dataGridViewCellStyle27;
            this.dgvDetalheValorUnitario.HeaderText = "Valor Unitário";
            this.dgvDetalheValorUnitario.Name = "dgvDetalheValorUnitario";
            this.dgvDetalheValorUnitario.ReadOnly = true;
            // 
            // dgvDetalheValorTotal
            // 
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle28.Format = "C2";
            dataGridViewCellStyle28.NullValue = null;
            this.dgvDetalheValorTotal.DefaultCellStyle = dataGridViewCellStyle28;
            this.dgvDetalheValorTotal.HeaderText = "Valor Total";
            this.dgvDetalheValorTotal.Name = "dgvDetalheValorTotal";
            this.dgvDetalheValorTotal.ReadOnly = true;
            // 
            // Consumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 547);
            this.Controls.Add(this.dgvItens);
            this.Controls.Add(this.dgvVendas);
            this.Controls.Add(this.txtComanda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpPeriodo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Consumo";
            this.Text = "Consumo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Consumo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpPeriodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtComanda;
        private System.Windows.Forms.DataGridView dgvVendas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvgVendaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvgVendaDataHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvgVendaValorTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvgVendaCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvgVendaCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvgVendaD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvgVendaAcrescimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvgVendaDesconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvgVendaValorFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEmAberto;
        private System.Windows.Forms.DataGridView dgvItens;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDetalheDataHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDetalheProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDetalheQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDetalheValorUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDetalheValorTotal;
    }
}