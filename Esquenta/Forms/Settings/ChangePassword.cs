using System;
using System.Windows.Forms;

namespace Esquenta.Forms.Settings
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //var pwd = Program.Base64Encode(txtCurrentPWD.Text);
            if (!Program.CheckPassword(txtCurrentPWD.Text))
            {
                MessageBox.Show(@"Senha atual não confere.");
                return;
            }

            var pwd1 = txtPWD1.Text;
            var pwd2 = txtPWD2.Text;
            if (!pwd1.Equals(pwd2))
            {
                MessageBox.Show(@"A nova senha e sua confirmação não conferem.");
                return;
            }
            Program.SavePassword(pwd1);
            MessageBox.Show(@"Senha alterada com sucesso");
            Close();
        }
    }
}