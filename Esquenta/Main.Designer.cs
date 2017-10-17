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
            this.btnCaixa = new System.Windows.Forms.Button();
            this.bntRelatorio = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCadastroProdutos = new System.Windows.Forms.Button();
            this.bntCadastroComandas = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCaixa
            // 
            this.btnCaixa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaixa.Location = new System.Drawing.Point(3, 213);
            this.btnCaixa.Name = "btnCaixa";
            this.btnCaixa.Size = new System.Drawing.Size(306, 204);
            this.btnCaixa.TabIndex = 0;
            this.btnCaixa.Text = "Caixa";
            this.btnCaixa.UseVisualStyleBackColor = true;
            this.btnCaixa.Click += new System.EventHandler(this.btnCaixa_Click);
            // 
            // bntRelatorio
            // 
            this.bntRelatorio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bntRelatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntRelatorio.Location = new System.Drawing.Point(315, 213);
            this.bntRelatorio.Name = "bntRelatorio";
            this.bntRelatorio.Size = new System.Drawing.Size(306, 204);
            this.bntRelatorio.TabIndex = 2;
            this.bntRelatorio.Text = "Relatórios";
            this.bntRelatorio.UseVisualStyleBackColor = true;
            this.bntRelatorio.Click += new System.EventHandler(this.bntRelatorio_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnCadastroProdutos, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bntRelatorio, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.bntCadastroComandas, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCaixa, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 441);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // btnCadastroProdutos
            // 
            this.btnCadastroProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCadastroProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastroProdutos.Location = new System.Drawing.Point(3, 3);
            this.btnCadastroProdutos.Name = "btnCadastroProdutos";
            this.btnCadastroProdutos.Size = new System.Drawing.Size(306, 204);
            this.btnCadastroProdutos.TabIndex = 2;
            this.btnCadastroProdutos.Text = "Cadastro de Produtos";
            this.btnCadastroProdutos.UseVisualStyleBackColor = true;
            this.btnCadastroProdutos.Click += new System.EventHandler(this.btnCadastroProdutos_Click);
            // 
            // bntCadastroComandas
            // 
            this.bntCadastroComandas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bntCadastroComandas.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntCadastroComandas.Location = new System.Drawing.Point(315, 3);
            this.bntCadastroComandas.Name = "bntCadastroComandas";
            this.bntCadastroComandas.Size = new System.Drawing.Size(306, 204);
            this.bntCadastroComandas.TabIndex = 5;
            this.bntCadastroComandas.Text = "Cadastro de Comandas";
            this.bntCadastroComandas.UseVisualStyleBackColor = true;
            this.bntCadastroComandas.Click += new System.EventHandler(this.bntCadastroComandas_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Main";
            this.Text = "Esquenta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCaixa;
        private System.Windows.Forms.Button bntRelatorio;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCadastroProdutos;
        private System.Windows.Forms.Button bntCadastroComandas;
    }
}