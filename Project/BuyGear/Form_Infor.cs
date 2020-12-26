using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BuyGear.DAO;
using BuyGear.DTO;
using System.Drawing;
using System.IO;

namespace BuyGear
{
    public partial class Form_Infor : Form
    {
        Form_Main parent;
        public Form_Infor()
        {
            InitializeComponent();
        }
        public Form_Infor(Form_Main parent)
        {
            this.parent = parent;

            InitializeComponent();
            txtAddress.Enabled = txtName.Enabled = txtEmail.Enabled = txtSDT.Enabled = true;
            rdoNam.Enabled = rdoNu.Enabled = true;
            chkNam.Enabled = chkNgay.Enabled = chkThang.Enabled = true;
        }

        //
        //Các hàm đặc trưng
        //
        private void Form_Load(object sender, EventArgs e)
        {
            //btnUpdate.PerformClick();
            try
            {
                DataTable dataTable = Account.Instance.Load_Info();
                DataRow row = dataTable.Rows[0];
                txtName.Text = row["name"].ToString();
                txtAddress.Text = row["address"].ToString();
                txtEmail.Text = row["email"].ToString();
                txtSDT.Text = row["numberphone"].ToString();
                string gioiTinh = row["sexual"].ToString();
                if (gioiTinh == "Nam")
                {
                    rdoNam.Checked = true;
                }
                else if (gioiTinh == "Nữ")
                {
                    rdoNu.Checked = true;
                }
                if (row["birthday"].ToString() != "")
                {
                    string[] ngaySinh = row["birthday"].ToString().Split('/', ' ');
                    chkThang.Text = ngaySinh[0];
                    chkNgay.Text = ngaySinh[1];
                    chkNam.Text = ngaySinh[2];
                }
                this.picAvatar.Image = Account.Instance.getAvatar();
            }
            catch
            {

            }

        }
        //
        //Các Envent của Control
        //

        private void btnExit_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void chkThang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkChangePass_CheckedChanged(object sender, EventArgs e)
        {
            pnlChangePass.Visible = !pnlChangePass.Visible;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lbConfirm.Text == "Mật khẩu trùng khớp")
            {
                if (txtOldPass.Text == Account.Instance.passWord)
                {
                    Account.Instance.passWord = txtNewPass.Text;
                    Account.Instance.UpdatePassword(txtNewPass.Text);
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK);
                    txtOldPass.Text = "";
                    txtNewPass.Text = "";
                    txtConfirm.Text = "";
                    MessageBox_form frm = new MessageBox_form();
                    frm.Show();
                }
                else
                    MessageBox.Show("Mật khẩu cũ chưa chính xác !"+'\n'+txtOldPass.Text+'\n'+Account.Instance.passWord, "Thông báo", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Mật khẩu chưa trùng khớp !", "Thông báo", MessageBoxButtons.OK);
        }

        private void txtNewPass_TextChanged(object sender, EventArgs e)
        {
            string password = txtNewPass.Text;
            if (txtConfirm.Text == "")
                lbConfirm.Text = "";
            if (txtConfirm.Text == password && txtConfirm.Text != "")
                lbConfirm.Text = "Mật khẩu trùng khớp";
            if (txtConfirm.Text != password && txtConfirm.Text != "")
                lbConfirm.Text = "Mật khẩu chưa trùng khớp";
        }

        private void txtConfirm_TextChanged(object sender, EventArgs e)
        {
            string confirm = txtConfirm.Text;
            if (confirm == "" && txtNewPass.Text == "")
                lbConfirm.Text = "";
            if (txtNewPass.Text != confirm)
                lbConfirm.Text = "Mật khẩu chưa trùng khớp";
            if (txtNewPass.Text == confirm && confirm != "")
                lbConfirm.Text = "Mật khẩu trùng khớp";
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtConfirm.UseSystemPasswordChar = txtOldPass.UseSystemPasswordChar = txtNewPass.UseSystemPasswordChar = !txtNewPass.UseSystemPasswordChar;
        }
        //
        //Thuộc Tính
        //
        public List<string> list_31 = new List<string>() { "Ngày", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
        public List<string> list_30 = new List<string>() { "Ngày", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" };
        public List<string> list_29 = new List<string>() { "Ngày", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29" };
        public List<string> list_28 = new List<string>() { "Ngày", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28" };

        private void bunifuButton6_Click(object sender, EventArgs e)
        {

        }
        private Color colnew = Color.FromArgb(150, 145, 187);
        private Color coldefault = Color.White;
        private void btnThongTin_Click(object sender, EventArgs e)
        {
            pageTab.SetPage(0);
        }

        private void btnThongTin_MouseUp(object sender, MouseEventArgs e)
        {
            btnThongTin.OnIdleState.BorderColor = colnew;
            btnThongTin.OnIdleState.FillColor = colnew;
            btnThongTin.OnIdleState.ForeColor = Color.White;
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkNam.Text != "" && chkNgay.Text != "" && chkThang.Text != "" && chkNam.Text != "Năm" && chkNgay.Text != "Ngày" && chkThang.Text != "Tháng" && (rdoNam.Checked == true || rdoNu.Checked == true) && txtAddress.Text != "" && txtName.Text != "" && txtEmail.Text != "" && txtSDT.Text != "")
                {
                    MessageBox_form frm = new MessageBox_form();
                    frm.Show();
                    //btnUpdate.Text = "Chỉnh sửa";
                    Account.Instance.Update(txtName.Text, txtAddress.Text, txtEmail.Text, txtSDT.Text);
                    if (rdoNam.Checked)
                    {
                        Account.Instance.UpdateSexual("Nam");
                    }
                    else if (rdoNu.Checked)
                    {
                        Account.Instance.UpdateSexual("Nữ");
                    }
                    Account.Instance.UpdateBirthday(chkNgay.Text, chkThang.Text, chkNam.Text);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin !");
                }
            }
            catch
            {

            }
        }

       

        private void btnThoats_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkChangePass_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            pageTab.SetPage(1);
        }

        private void ckbHienMatKhau_OnChange(object sender, EventArgs e)
        {
            txtOldPass.UseSystemPasswordChar = !txtOldPass.UseSystemPasswordChar;
            txtNewPass.UseSystemPasswordChar = !txtNewPass.UseSystemPasswordChar;
            txtConfirm.UseSystemPasswordChar = !txtConfirm.UseSystemPasswordChar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(Account.Instance.userName == ""))
            {
                string path = Picture.getLinkFromDialog();
                try
                {
                    picAvatar.Image = Picture.FromFile(path);
                    Account.Instance.changeAvatar(path);
                }
                catch
                {

                }
            }
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            pageTab.SetPage(2);
            List<ItemThongBao> listThongBao = Data.Instance.listItemThongBao();
            foreach(ItemThongBao item in listThongBao)
            {
                ucThongBaoDonHang uc = new ucThongBaoDonHang(item);
                this.fpnlThongBao.Controls.Add(uc);
            }
            Data.Instance.CheckThongBao("thongbaoxacnhan_xem", true);
            Data.Instance.CheckThongBao("thongbaodagiao_xem", true);
            Account.Instance.numberNotify = 0;
        }
    }
}
