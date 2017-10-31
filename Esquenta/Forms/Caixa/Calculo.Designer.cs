namespace Esquenta.Forms.Caixa
{
    partial class Calculo
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
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtValorPago = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAcrescimo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDesconto
            // 
            this.txtDesconto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesconto.Location = new System.Drawing.Point(12, 33);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(160, 29);
            this.txtDesconto.TabIndex = 1;
            this.txtDesconto.Text = "0.0";
            this.txtDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDesconto.TextChanged += new System.EventHandler(this.txtDesconto_TextChanged);
            this.txtDesconto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDesconto_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 24);
            this.label5.TabIndex = 15;
            this.label5.Text = "Desconto";
            // 
            // txtValorPago
            // 
            this.txtValorPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValorPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorPago.Location = new System.Drawing.Point(12, 159);
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.Size = new System.Drawing.Size(159, 29);
            this.txtValorPago.TabIndex = 3;
            this.txtValorPago.Text = "0.0";
            this.txtValorPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorPago.TextChanged += new System.EventHandler(this.txtDesconto_TextChanged);
            this.txtValorPago.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValorPago_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 24);
            this.label3.TabIndex = 13;
            this.label3.Text = "Valor pago";
            // 
            // txtAcrescimo
            // 
            this.txtAcrescimo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAcrescimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcrescimo.Location = new System.Drawing.Point(12, 100);
            this.txtAcrescimo.Name = "txtAcrescimo";
            this.txtAcrescimo.Size = new System.Drawing.Size(160, 29);
            this.txtAcrescimo.TabIndex = 2;
            this.txtAcrescimo.Text = "0.0";
            this.txtAcrescimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAcrescimo.TextChanged += new System.EventHandler(this.txtDesconto_TextChanged);
            this.txtAcrescimo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAcrescimo_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Acréscimo";
            // 
            // Calculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 205);
            this.Controls.Add(this.txtAcrescimo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDesconto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtValorPago);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Calculo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Calculo_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDesconto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtValorPago;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAcrescimo;
        private System.Windows.Forms.Label label1;
    }
}