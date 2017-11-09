namespace Esquenta.Forms.Caixa
{
    partial class RemoverItem
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumeroItem = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número do Item";
            // 
            // txtNumeroItem
            // 
            this.txtNumeroItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroItem.Location = new System.Drawing.Point(12, 36);
            this.txtNumeroItem.Name = "txtNumeroItem";
            this.txtNumeroItem.Size = new System.Drawing.Size(160, 29);
            this.txtNumeroItem.TabIndex = 1;
            this.txtNumeroItem.Text = "1";
            this.txtNumeroItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumeroItem.TextChanged += new System.EventHandler(this.txtQuantidade_TextChanged);
            this.txtNumeroItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantidade_KeyDown);
            // 
            // RemoverItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 86);
            this.Controls.Add(this.txtNumeroItem);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemoverItem";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remover item";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Quantidade_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RemoverItem_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumeroItem;
    }
}