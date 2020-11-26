using System;
using System.Windows.Forms;

namespace BuyGear
{
    public partial class Form_Register : Form
    {
        public Form_Register()
        {
            InitializeComponent();
        }

        //
        //Các hàm đặc trưng
        //

        private void do_Register()
        {
            if (lbUsername.Text == "" && lbConfirm.Text == "Mật khẩu trùng khớp")
            {
                Account.Instance.InsertAcc(txtUsername.Text, txtPassword.Text);
                if (MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.OK)
                {
                    Account.Instance.userName = txtUsername.Text;
                    Account.Instance.passWord = txtPassword.Text;
                    this.Close();
                }
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK);
        }

        //
        //Các Envent của Control
        //

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && Data.Instance.ExcuteQuery("EXEC Pro_IsExistUsername @username", new object[] { txtUsername.Text }).Rows.Count > 0)
                lbUsername.Text = "Tên tài khoản đã được sử dụng";
            else if (txtUsername.Text == "")
                lbUsername.Text = "Nhập tài khoản";
            else
                lbUsername.Text = "";
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            if (txtRePass.Text == "")
                lbConfirm.Text = "";
            if (txtRePass.Text == password && txtRePass.Text != "")
                lbConfirm.Text = "Mật khẩu trùng khớp";
            if (txtRePass.Text != password && txtRePass.Text != "")
                lbConfirm.Text = "Mật khẩu chưa trùng khớp";
        }

        private void txtRePass_TextChanged(object sender, EventArgs e)
        {
            string confirm = txtRePass.Text;
            if (confirm == "" && txtPassword.Text == "")
                lbConfirm.Text = "";
            if (txtPassword.Text != confirm)
                lbConfirm.Text = "Mật khẩu chưa trùng khớp";
            if (txtPassword.Text == confirm && confirm != "")
                lbConfirm.Text = "Mật khẩu trùng khớp";
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            txtRePass.UseSystemPasswordChar = !txtRePass.UseSystemPasswordChar;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            do_Register();
        }
        //
        //Các thuộc tính
        //
    }
}
