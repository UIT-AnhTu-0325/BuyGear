using System;
using System.Windows.Forms;
using BuyGear.DAO;
using BuyGear.DTO;
using System.Drawing;
namespace BuyGear
{
    public partial class Form_Login : Form
    {
        Form_Main parent;
        public Form_Login()
        {
            InitializeComponent();
        }
        public Form_Login(Form_Main parent)
        {
            this.parent = parent;
            InitializeComponent();
            //focus username input
            txtUsername.Focus();
            checkfield1 = true;
        }
        //
        //Các hàm đặc biệt
        //

        private void do_Login()
        {
            if (Account.Instance.Login(txtUsername.Text, txtPass.Text) > 0 && Account.Instance.CheckType(txtUsername.Text) == false)
            {
                Account.Instance.userName = txtUsername.Text;
                Account.Instance.passWord = txtPass.Text;
                this.parent.lblName.Text= "Xin chào " + Account.Instance.userName;
                this.parent.ThongTinGioHang();
                this.Close();
            }
            else if (Account.Instance.Login(txtUsername.Text, txtPass.Text) > 0 && Account.Instance.CheckType(txtUsername.Text) == true)
            {
                Account.Instance.userName = txtUsername.Text;
                Account.Instance.passWord = txtPass.Text;
                this.Hide();
                Form_Admin f = new Form_Admin();
                f.ShowDialog();
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
            //Form_Register f = new Form_Register();
            //f.ShowDialog();
            //this.Close();
            Form_Register frm = new Form_Register(this.parent,this)
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

        private void btnExit_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !txtPass.UseSystemPasswordChar;
        }

        private void bunifuCheckBox1_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            txtPass.UseSystemPasswordChar = !txtPass.UseSystemPasswordChar;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Size = new Size(this.parent.fpnlChiTiet.Size.Width, this.parent.fpnlChiTiet.Size.Height);
        }


        // field username and password
        private bool checkfield1 = false, checkfield2 = false;
        private int countSize1 = 0, countSize2 = 0;

    

        private void txtPass_Click(object sender, EventArgs e)
        {
            checkfield2 = true;
        }

        private void lblUserName_MouseClick(object sender, MouseEventArgs e)
        {
            txtUsername.Focus();
            checkfield1 = true;
        }

        private void lblPassWord_Click(object sender, EventArgs e)
        {
            txtPass.Focus();
            checkfield2 = true;
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                txtPass.Focus();
                checkfield2 = true;
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                do_Login();
            }
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            checkfield1 = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(checkfield1 && countSize1<25)
            {
                countSize1++;
                lblUserName.Top -= 1;
            }
            if(checkfield2 && countSize2<25)
            {
                countSize2++;
                lblPassWord.Top -= 1;
            }
        }


    }
}
