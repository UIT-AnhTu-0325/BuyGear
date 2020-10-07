using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuyGear
{
    public partial class fRegister : Form
    {
        public fRegister()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (lbUsername.Text == "" && lbConfirm.Text == "Mật khẩu trùng khớp")
            {
                Account.Instance.InsertAcc(tboxUsername.Text, tboxPassword.Text);
                if (MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.OK)
                    this.Close();
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK);
        }

        private void tboxUsername_TextChanged(object sender, EventArgs e)
        {
            if (tboxUsername.Text != "" && Data.Instance.ExcuteQuery(@"EXEC dbo.Pro_Username @username", new object[] { tboxUsername.Text }).Rows.Count > 0)
                lbUsername.Text = "Tên tài khoản đã được sử dụng";
            else if (tboxUsername.Text == "")
                lbUsername.Text = "Nhập tài khoản";
            else
                lbUsername.Text = "";
        }

        private void tboxPassword_TextChanged(object sender, EventArgs e)
        {
            string password = tboxPassword.Text;
            if (tboxConfirm.Text == "")
                lbConfirm.Text = "";
            if (tboxConfirm.Text == password && tboxConfirm.Text != "")
                lbConfirm.Text = "Mật khẩu trùng khớp";
            if (tboxConfirm.Text != password && tboxConfirm.Text != "")
                lbConfirm.Text = "Mật khẩu chưa trùng khớp";
        }

        private void tboxConfirm_TextChanged(object sender, EventArgs e)
        {
            string confirm = tboxConfirm.Text;
            if (confirm == "" && tboxPassword.Text == "")
                lbConfirm.Text = "";
            if (tboxPassword.Text != confirm)
                lbConfirm.Text = "Mật khẩu chưa trùng khớp";
            if (tboxPassword.Text == confirm && confirm != "")
                lbConfirm.Text = "Mật khẩu trùng khớp";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tboxPassword.UseSystemPasswordChar = !tboxPassword.UseSystemPasswordChar;
            tboxConfirm.UseSystemPasswordChar = !tboxConfirm.UseSystemPasswordChar;
        }
    }
}
