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
    public partial class fInfo : Form
    {
        public fInfo()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public List<string> list31 = new List<string>() { "Ngày","1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"};
        public List<string> list30 = new List<string>() { "Ngày", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"};
        public List<string> list29 = new List<string>() { "Ngày", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29"};
        public List<string> list28 = new List<string>() { "Ngày", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28"};
        private void Form1_Load(object sender, EventArgs e)
        {
            string query = @"SELECT * FROM dbo.Info WHERE username = N'" + Account.Instance.userName + "'";
            DataTable dataTable = Data.Instance.ExcuteQuery(query);
            DataRow row = dataTable.Rows[0];
            tboxName.Text = row["name"].ToString();
            tboxAddress.Text = row["address"].ToString();
            tboxEmail.Text = row["email"].ToString();
            tboxSDT.Text = row["numberphone"].ToString();
            string gioiTinh = row["sexual"].ToString();
            if (gioiTinh == "Nam")
            {
                rbtnNam.Checked = true;
            }
            else if(gioiTinh == "Nữ")
            {
                rbtnNu.Checked = true;
            }
            if (row["birthday"].ToString() != "")
            {
                string[] ngaySinh = row["birthday"].ToString().Split('/', ' ');
                cboxThang.Text = ngaySinh[0];
                cboxNgay.Text = ngaySinh[1];
                cboxNam.Text = ngaySinh[2];
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "Chỉnh sửa")
            {
                tboxAddress.Enabled = tboxName.Enabled = tboxEmail.Enabled = tboxSDT.Enabled = true;
                rbtnNam.Enabled = rbtnNu.Enabled = true;
                cboxNam.Enabled = cboxNgay.Enabled = cboxThang.Enabled = true;
                btnUpdate.Text = "Cập nhật";
            }
            else
            {
                if (cboxNam.Text != "" && cboxNgay.Text != "" && cboxThang.Text != "" && cboxNam.Text != "Năm" && cboxNgay.Text != "Ngày" && cboxThang.Text != "Tháng" && (rbtnNam.Checked == true || rbtnNu.Checked == true) && tboxAddress.Text != "" && tboxName.Text != "" && tboxEmail.Text != "" && tboxSDT.Text != "")
                {
                    tboxAddress.Enabled = tboxName.Enabled = tboxEmail.Enabled = tboxSDT.Enabled = false;
                    rbtnNam.Enabled = rbtnNu.Enabled = false;
                    cboxNam.Enabled = cboxNgay.Enabled = cboxThang.Enabled = false;
                    btnUpdate.Text = "Chỉnh sửa";
                    string query = "UPDATE dbo.Info SET name = N'" + tboxName.Text + "',address = N'" + tboxAddress.Text + "',email = N'" + tboxEmail.Text + "',numberphone = N'" + tboxSDT.Text + "' WHERE username = N'" + Account.Instance.userName + "'";
                    Data.Instance.ExcuteQuery(query);
                    if (rbtnNam.Checked)
                    {
                        query = "UPDATE dbo.Info SET sexual = N'Nam' WHERE username = N'" + Account.Instance.userName + "'";
                        Data.Instance.ExcuteQuery(query);
                    }
                    else if (rbtnNu.Checked)
                    {
                        query = "UPDATE dbo.Info SET sexual = N'Nữ' WHERE username = N'" + Account.Instance.userName + "'";
                        Data.Instance.ExcuteQuery(query);
                    }
                    query = "UPDATE dbo.Info SET birthday = N'" + cboxNam.Text +"-" + cboxThang.Text +"-" +cboxNgay.Text+ "' WHERE username = N'" + Account.Instance.userName + "'";
                    Data.Instance.ExcuteQuery(query);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin !");
                }

            }
        }

        private void cboxNam_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void cboxNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxThang.SelectedIndex == 2)
            {
                if (cboxNam.SelectedIndex % 4 == 3)
                {
                    int i = cboxNgay.SelectedIndex;
                    cboxNgay.DataSource = list29;
                    if (i > 29)
                        cboxNgay.SelectedIndex = 0;
                    else
                        cboxNgay.SelectedIndex = i;
                }
                else
                {
                    int i = cboxNgay.SelectedIndex;
                    cboxNgay.DataSource = list28;
                    if (i > 28)
                        cboxNgay.SelectedIndex = 0;
                    else
                        cboxNgay.SelectedIndex = i;
                }
            }
            else if (cboxThang.SelectedIndex == 1 || cboxThang.SelectedIndex == 3 || cboxThang.SelectedIndex == 5 || cboxThang.SelectedIndex == 7 || cboxThang.SelectedIndex == 8 || cboxThang.SelectedIndex == 10 || cboxThang.SelectedIndex == 12 || cboxThang.SelectedIndex == 0)
            {
                int i = cboxNgay.SelectedIndex;
                cboxNgay.DataSource = list31;
                cboxNgay.SelectedIndex = i;
            }
            else
            {
                int i = cboxNgay.SelectedIndex;
                cboxNgay.DataSource = list30;
                if (i > 30)
                    cboxNgay.SelectedIndex = 0;
                else
                    cboxNgay.SelectedIndex = i;
            }
        }

        private void cboxThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxThang.SelectedIndex == 2)
            {
                if (cboxNam.SelectedIndex % 4 == 3)
                {
                    int i = cboxNgay.SelectedIndex;
                    cboxNgay.DataSource = list29;
                    if (i > 29)
                        cboxNgay.SelectedIndex = 0;
                    else
                        cboxNgay.SelectedIndex = i;
                }
                else
                {
                    int i = cboxNgay.SelectedIndex;
                    cboxNgay.DataSource = list28;
                    if (i > 28)
                        cboxNgay.SelectedIndex = 0;
                    else
                        cboxNgay.SelectedIndex = i;
                }
            }
            else if (cboxThang.SelectedIndex == 1 || cboxThang.SelectedIndex == 3 || cboxThang.SelectedIndex == 5 || cboxThang.SelectedIndex == 7 || cboxThang.SelectedIndex == 8 || cboxThang.SelectedIndex == 10 || cboxThang.SelectedIndex == 12 || cboxThang.SelectedIndex == 0)
            {
                int i = cboxNgay.SelectedIndex;
                cboxNgay.DataSource = list31;
                cboxNgay.SelectedIndex = i;
            }
            else
            {
                int i = cboxNgay.SelectedIndex;
                cboxNgay.DataSource = list30;
                if (i > 30)
                    cboxNgay.SelectedIndex = 0;
                else
                    cboxNgay.SelectedIndex = i;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            panelChange.Visible = !panelChange.Visible;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lbConfirm.Text == "Mật khẩu trùng khớp")
            {
                if (tboxOldPass.Text == Account.Instance.passWord)
                {
                    string query = "EXEC Pro_UpdatePass  @password , @username";
                    string hashPass = Account.Instance.Encode(tboxPassword.Text);
                    Data.Instance.ExcuteQuery(query, new object[] { hashPass,Account.Instance.userName });
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Mật khẩu cũ chưa chính xác !", "Thông báo", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Mật khẩu chưa trùng khớp !", "Thông báo", MessageBoxButtons.OK);
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            tboxConfirm.UseSystemPasswordChar = tboxOldPass.UseSystemPasswordChar = tboxPassword.UseSystemPasswordChar = !tboxPassword.UseSystemPasswordChar;
        }
    }
}
