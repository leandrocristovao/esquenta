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
            this.btnCadastro = new System.Windows.Forms.Button();
            this.bntRelatorio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCaixa
            // 
            this.btnCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCaixa.Location = new System.Drawing.Point(12, 92);
            this.btnCaixa.Name = "btnCaixa";
            this.btnCaixa.Size = new System.Drawing.Size(600, 23);
            this.btnCaixa.TabIndex = 0;
            this.btnCaixa.Text = "Caixa";
            this.btnCaixa.UseVisualStyleBackColor = true;
            this.btnCaixa.Click += new System.EventHandler(this.btnCaixa_Click);
            // 
            // btnCadastro
            // 
            this.btnCadastro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCadastro.Location = new System.Drawing.Point(12, 121);
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.Size = new System.Drawing.Size(600, 23);
            this.btnCadastro.TabIndex = 1;
            this.btnCadastro.Text = "Cadastros";
            this.btnCadastro.UseVisualStyleBackColor = true;
            this.btnCadastro.Click += new System.EventHandler(this.btnCadastro_Click);
            // 
            // bntRelatorio
            // 
            this.bntRelatorio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bntRelatorio.Location = new System.Drawing.Point(12, 150);
            this.bntRelatorio.Name = "bntRelatorio";
            this.bntRelatorio.Size = new System.Drawing.Size(600, 23);
            this.bntRelatorio.TabIndex = 2;
            this.bntRelatorio.Text = "Relatórios";
            this.bntRelatorio.UseVisualStyleBackColor = true;
            this.bntRelatorio.Click += new System.EventHandler(this.bntRelatorio_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.bntRelatorio);
            this.Controls.Add(this.btnCadastro);
            this.Controls.Add(this.btnCaixa);
            this.Name = "Main";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCaixa;
        private System.Windows.Forms.Button btnCadastro;
        private System.Windows.Forms.Button bntRelatorio;
    }
}