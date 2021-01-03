using System;
using System.Drawing;
using System.Windows.Forms;
using BuyGear.DAO;
using BuyGear.DTO;
namespace BuyGear
{
    public partial class Form_Register : Form
    {
        public Form_Register()
        {
            InitializeComponent();
        }
        Form_Main parent;
        Form_Login createMe;
        public Form_Register(Form_Main parent,Form_Login createMe)
        {
            this.parent = parent;
            this.createMe = createMe;
            InitializeComponent();
             //focus username input
            txtUsername.Focus();
            checkfield1 = true;
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
                    this.parent.lblName.Text= "Xin chào " + Account.Instance.userName;
                    this.parent.ThongTinGioHang();
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
            if (txtUsername.Text != "" && Account.Instance.Exist(txtUsername.Text) == true)
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

        private void chkShowPass_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            txtRePass.UseSystemPasswordChar = !txtRePass.UseSystemPasswordChar;
        }

        private void lblDangNhap_Click(object sender, EventArgs e)
        {
            Form_Login frm = new Form_Login(this.parent)
            {
                TopLevel = false,
                TopMost = true
            };
            this.parent.fpnlChiTiet.Visible = true;
            this.parent.fpnlProduct.Visible = false;
            this.parent.fpnlChiTiet.Controls.Clear();
            this.parent.fpnlChiTiet.Controls.Add(frm);
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Size = new Size(this.parent.fpnlChiTiet.Size.Width, this.parent.fpnlChiTiet.Size.Height);
        }


        //
        //Các thuộc tính
        //


        // field username and password
        private bool checkfield1 = false, checkfield2 = false, checkfield3 = false;
        private int countSize1 = 0, countSize2 = 0, countSize3 = 0;



        private void txtPass_Click(object sender, EventArgs e)
        {
            checkfield2 = true;
        }

        private void txtRePass_Click(object sender, EventArgs e)
        {
            checkfield3 = true;
        }

        private void lblRePass_Click(object sender, EventArgs e)
        {
            txtRePass.Focus();
            checkfield3 = true;
        }

        private void lblPassWord_Click_1(object sender, EventArgs e)
        {
            checkfield2 = true;
            txtPassword.Focus();
        }

        private void Form_Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (createMe != null)
            {
                this.createMe.Close();
            }
        }

        private void lblUserName_MouseClick(object sender, EventArgs e)
        {
            txtUsername.Focus();
            checkfield1 = true;
        }

        private void btnDangkyAdmin_Click(object sender, EventArgs e)
        {
            this.RegisterAdmin();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
                checkfield2 = true;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRePass.Focus();
                checkfield3 = true;
            }
        }

      

        private void txtRePass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                do_Register();
            }
        }

        private void lblPassWord_Click(object sender, EventArgs e)
        {
            txtPassword.Focus();
            checkfield2 = true;
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            checkfield1 = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (checkfield1 && countSize1 < 25)
            {
                countSize1++;
                lblUserName.Top -= 1;
            }
            if (checkfield2 && countSize2 < 25)
            {
                countSize2++;
                lblPassWord.Top -= 1;
            }
            if(checkfield3 && countSize3<25)
            {
                countSize3++;
                lblRePass.Top -= 1;
            }
        }

        #region HOAI

        private void RegisterAdmin()
        {
            if (lbUsername.Text == "" && lbConfirm.Text == "Mật khẩu trùng khớp")
            {
                Account.Instance.InsertAccAd(txtUsername.Text, txtPassword.Text);
                if (MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK);
        }
        #endregion
    }
}
