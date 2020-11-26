using System;
using System.Windows.Forms;

namespace BuyGear
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        //
        //Các hàm đặc biệt
        //

        private void do_Login()
        {
            if (Account.Instance.Login(txtUsername.Text, txtPass.Text) > 0)
            {
                Account.Instance.userName = txtUsername.Text;
                Account.Instance.passWord = txtPass.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
            }
        }

        //
        //Các Envent của Control
        //

        private void btnLogin_Click(object sender, EventArgs e)
        {
            do_Login();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Form_Register f = new Form_Register();
            f.ShowDialog();
            this.Close();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !txtPass.UseSystemPasswordChar;
        }
    }
}
