using System;
using System.Windows.Forms;

namespace BuyGear
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        //
        //Các hàm đặc trưng
        //

        //
        //Các Event của Control
        //

        private void btnMyInfor_Click(object sender, EventArgs e)
        {
            Form_Infor f = new Form_Infor();
            f.ShowDialog();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đăng xuất khỏi tài khoản ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Account.Instance.userName = "";
                pnlInfo.Visible = false;
                pnlRegister.Visible = true;
            }
                
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form_Login f = new Form_Login();
            f.ShowDialog();
            if (Account.Instance.userName != "")
            {
                pnlInfo.Visible = true;
                pnlRegister.Visible = false;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Form_Register f = new Form_Register();
            f.ShowDialog();
            if (Account.Instance.userName != "")
            {
                pnlInfo.Visible = true;
                pnlRegister.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát khỏi ứng dụng ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
