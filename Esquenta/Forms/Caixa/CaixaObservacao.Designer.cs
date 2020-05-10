namespace Esquenta.Forms.Caixa
{
    partial class CaixaObservacao
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
            this.btnNao = new System.Windows.Forms.Button();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.btnSim = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNao
            // 
            this.btnNao.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNao.Location = new System.Drawing.Point(591, 222);
            this.btnNao.Name = "btnNao";
            this.btnNao.Size = new System.Drawing.Size(75, 23);
            this.btnNao.TabIndex = 0;
            this.btnNao.Text = "Não";
            this.btnNao.UseVisualStyleBackColor = true;
            // 
            // txtNotas
            // 
            this.txtNotas.Location = new System.Drawing.Point(12, 12);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(655, 199);
            this.txtNotas.TabIndex = 1;
            this.txtNotas.TextChanged += new System.EventHandler(this.txtNotas_TextChanged);
            // 
            // btnSim
            // 
            this.btnSim.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnSim.Location = new System.Drawing.Point(510, 222);
            this.btnSim.Name = "btnSim";
            this.btnSim.Size = new System.Drawing.Size(75, 23);
            this.btnSim.TabIndex = 2;
            this.btnSim.Text = "Sim";
            this.btnSim.UseVisualStyleBackColor = true;
            // 
            // CaixaObservacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnNao;
            this.ClientSize = new System.Drawing.Size(679, 257);
            this.Controls.Add(this.btnSim);
            this.Controls.Add(this.txtNotas);
            this.Controls.Add(this.btnNao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CaixaObservacao";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fechar Venda?";
            this.Load += new System.EventHandler(this.CaixaObservacao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNao;
        private System.Windows.Forms.TextBox txtNotas;
        private System.Windows.Forms.Button btnSim;
    }
}