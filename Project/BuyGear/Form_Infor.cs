﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BuyGear
{
    public partial class Form_Infor : Form
    {
        public Form_Infor()
        {
            InitializeComponent();
        }

        //
        //Các hàm đặc trưng
        //
        private void Form_Load(object sender, EventArgs e)
        {
            string query = @"SELECT * FROM dbo.Info WHERE username = N'" + Account.Instance.userName + "'";
            DataTable dataTable = Data.Instance.ExcuteQuery(query);
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

        }
        //
        //Các Envent của Control
        //

        private void btnExit_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "Chỉnh sửa")
            {
                txtAddress.Enabled = txtName.Enabled = txtEmail.Enabled = txtSDT.Enabled = true;
                rdoNam.Enabled = rdoNu.Enabled = true;
                chkNam.Enabled = chkNgay.Enabled = chkThang.Enabled = true;
                btnUpdate.Text = "Cập nhật";
            }
            else
            {
                if (chkNam.Text != "" && chkNgay.Text != "" && chkThang.Text != "" && chkNam.Text != "Năm" && chkNgay.Text != "Ngày" && chkThang.Text != "Tháng" && (rdoNam.Checked == true || rdoNu.Checked == true) && txtAddress.Text != "" && txtName.Text != "" && txtEmail.Text != "" && txtSDT.Text != "")
                {
                    txtAddress.Enabled = txtName.Enabled = txtEmail.Enabled = txtSDT.Enabled = false;
                    rdoNam.Enabled = rdoNu.Enabled = false;
                    chkNam.Enabled = chkNgay.Enabled = chkThang.Enabled = false;
                    btnUpdate.Text = "Chỉnh sửa";
                    string query = "UPDATE dbo.Info SET name = N'" + txtName.Text + "',address = N'" + txtAddress.Text + "',email = N'" + txtEmail.Text + "',numberphone = N'" + txtSDT.Text + "' WHERE username = N'" + Account.Instance.userName + "'";
                    Data.Instance.ExcuteQuery(query);
                    if (rdoNam.Checked)
                    {
                        query = "UPDATE dbo.Info SET sexual = N'Nam' WHERE username = N'" + Account.Instance.userName + "'";
                        Data.Instance.ExcuteQuery(query);
                    }
                    else if (rdoNu.Checked)
                    {
                        query = "UPDATE dbo.Info SET sexual = N'Nữ' WHERE username = N'" + Account.Instance.userName + "'";
                        Data.Instance.ExcuteQuery(query);
                    }
                    query = "UPDATE dbo.Info SET birthday = N'" + chkNam.Text + "-" + chkThang.Text + "-" + chkNgay.Text + "' WHERE username = N'" + Account.Instance.userName + "'";
                    Data.Instance.ExcuteQuery(query);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin !");
                }

            }
        }

        private void chkNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkThang.SelectedIndex == 2)
            {
                if (chkNam.SelectedIndex % 4 == 3)
                {
                    int i = chkNgay.SelectedIndex;
                    chkNgay.DataSource = list_29;
                    if (i > 29)
                        chkNgay.SelectedIndex = 0;
                    else
                        chkNgay.SelectedIndex = i;
                }
                else
                {
                    int i = chkNgay.SelectedIndex;
                    chkNgay.DataSource = list_28;
                    if (i > 28)
                        chkNgay.SelectedIndex = 0;
                    else
                        chkNgay.SelectedIndex = i;
                }
            }
            else if (chkThang.SelectedIndex == 1 || chkThang.SelectedIndex == 3 || chkThang.SelectedIndex == 5 || chkThang.SelectedIndex == 7 || chkThang.SelectedIndex == 8 || chkThang.SelectedIndex == 10 || chkThang.SelectedIndex == 12 || chkThang.SelectedIndex == 0)
            {
                int i = chkNgay.SelectedIndex;
                chkNgay.DataSource = list_30;
                chkNgay.SelectedIndex = i;
            }
            else
            {
                int i = chkNgay.SelectedIndex;
                chkNgay.DataSource = list_30;
                if (i > 30)
                    chkNgay.SelectedIndex = 0;
                else
                    chkNgay.SelectedIndex = i;
            }
        }

        private void chkThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkThang.SelectedIndex == 2)
            {
                if (chkNam.SelectedIndex % 4 == 3)
                {
                    int i = chkNgay.SelectedIndex;
                    chkNgay.DataSource = list_29;
                    if (i > 29)
                        chkNgay.SelectedIndex = 0;
                    else
                        chkNgay.SelectedIndex = i;
                }
                else
                {
                    int i = chkNgay.SelectedIndex;
                    chkNgay.DataSource = list_28;
                    if (i > 28)
                        chkNgay.SelectedIndex = 0;
                    else
                        chkNgay.SelectedIndex = i;
                }
            }
            else if (chkThang.SelectedIndex == 1 || chkThang.SelectedIndex == 3 || chkThang.SelectedIndex == 5 || chkThang.SelectedIndex == 7 || chkThang.SelectedIndex == 8 || chkThang.SelectedIndex == 10 || chkThang.SelectedIndex == 12 || chkThang.SelectedIndex == 0)
            {
                int i = chkNgay.SelectedIndex;
                chkNgay.DataSource = list_30;
                chkNgay.SelectedIndex = i;
            }
            else
            {
                int i = chkNgay.SelectedIndex;
                chkNgay.DataSource = list_30;
                if (i > 30)
                    chkNgay.SelectedIndex = 0;
                else
                    chkNgay.SelectedIndex = i;
            }
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
                    string query = "EXEC Pro_UpdatePass  @password , @username";
                    string hashPass = Account.Instance.Encode(txtNewPass.Text);
                    Data.Instance.ExcuteQuery(query, new object[] { hashPass, Account.Instance.userName });
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Mật khẩu cũ chưa chính xác !", "Thông báo", MessageBoxButtons.OK);
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

    }
}
