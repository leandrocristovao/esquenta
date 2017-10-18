namespace Esquenta.Forms.Produto
{
    partial class ListaProduto
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
            this.components = new System.ComponentModel.Container();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgvID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(12, 12);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd.TabIndex = 0;
            this.BtnAdd.Text = "Novo";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(624, 45);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 396);
            this.panel1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvID,
            this.DGVNome,
            this.DGVDescricao,
            this.DGVQuantidade,
            this.DGVValor});
            this.dataGridView1.DataSource = this.produtoBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(624, 396);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // dgvID
            // 
            this.dgvID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvID.DataPropertyName = "Id";
            this.dgvID.HeaderText = "Id";
            this.dgvID.Name = "dgvID";
            this.dgvID.ReadOnly = true;
            this.dgvID.Width = 41;
            // 
            // DGVNome
            // 
            this.DGVNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DGVNome.DataPropertyName = "Nome";
            this.DGVNome.HeaderText = "Nome";
            this.DGVNome.Name = "DGVNome";
            this.DGVNome.ReadOnly = true;
            this.DGVNome.Width = 60;
            // 
            // DGVDescricao
            // 
            this.DGVDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGVDescricao.DataPropertyName = "Descricao";
            this.DGVDescricao.HeaderText = "Descricao";
            this.DGVDescricao.Name = "DGVDescricao";
            this.DGVDescricao.ReadOnly = true;
            // 
            // DGVQuantidade
            // 
            this.DGVQuantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DGVQuantidade.DataPropertyName = "Quantidade";
            this.DGVQuantidade.HeaderText = "Quantidade";
            this.DGVQuantidade.Name = "DGVQuantidade";
            this.DGVQuantidade.ReadOnly = true;
            this.DGVQuantidade.Width = 87;
            // 
            // DGVValor
            // 
            this.DGVValor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DGVValor.DataPropertyName = "Valor";
            this.DGVValor.HeaderText = "Valor";
            this.DGVValor.Name = "DGVValor";
            this.DGVValor.ReadOnly = true;
            this.DGVValor.Width = 56;
            // 
            // produtoBindingSource
            // 
            this.produtoBindingSource.DataSource = typeof(Esquenta.Entities.Produto);
            // 
            // ListaProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "ListaProduto";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Listagem de Produtos";
            this.Load += new System.EventHandler(this.ListaProduto_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.BindingSource produtoBindingSource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVValor;
    }
}