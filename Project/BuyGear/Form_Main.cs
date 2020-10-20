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
        // hien thi thong tin
        private void NameThongTin()
        {
            if (btnMyInfor.Visible)
            {
                btnMyInfor.Text ="Xin chào "+ Account.Instance.userName;
            }
        }

        //
        //Các hàm đặc trưng
        //

        //
        //Các Event của Control
        //

        private void btnMyInfor_Click(object sender, EventArgs e)
        {
            if (!pnl_TheoDoiDonHang.Visible)
                pnl_TheoDoiDonHang.Visible = true;
            else
                pnl_TheoDoiDonHang.Visible = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đăng xuất khỏi tài khoản ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Account.Instance.userName = "";
                btnMyInfor.Visible = false;
                pnl_TheoDoiDonHang.Visible = false;
                btnLogin.Visible = true;
            }
                
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form_Login f = new Form_Login();
            f.ShowDialog();
            if (Account.Instance.userName != "")
            {
                btnLogin.Visible = false;
                btnMyInfor.Visible = true;
                NameThongTin();

            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Form_Register f = new Form_Register();
            f.ShowDialog();
            if (Account.Instance.userName != "")
            {
                btnLogin.Visible = false;
                btnMyInfor.Visible = true;
                NameThongTin();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát khỏi ứng dụng ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btn_SuaThongTinCaNhan_Click(object sender, EventArgs e)
        {
            Form_Infor f = new Form_Infor();
            f.ShowDialog();
            pnl_TheoDoiDonHang.Visible = false;
        }
    }
}
