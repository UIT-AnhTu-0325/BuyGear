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
                Form_Main fMain = new Form_Main();
                this.Hide();
                fMain.ShowDialog();
                this.Show();
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
            this.Hide();
            f.ShowDialog();
            this.Show();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát ứng dụng ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                Application.Exit();
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !txtPass.UseSystemPasswordChar;
        }
    }
}
