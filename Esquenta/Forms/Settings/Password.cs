using System;
using System.Windows.Forms;

namespace Esquenta.Forms.Settings
{
    public partial class Password : Form
    {
        public Password()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Program.CheckPassword(txtPWD.Text))
            {
                Program.isAdmin = true;
            }

            Close();
        }
    }
}