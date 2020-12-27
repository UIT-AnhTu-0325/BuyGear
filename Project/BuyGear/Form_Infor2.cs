using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BuyGear.DAO;
using BuyGear.DTO;
using BuyGear.Something;

namespace BuyGear
{
    public partial class Form_Infor2 : Form
    {
        Form_Main parent;
        public Form_Infor2()
        {
            InitializeComponent();
        }
        public Form_Infor2(Form_Main parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        //
        //Các hàm đặc trưng
        //
        private void Form_Load(object sender, EventArgs e)
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

        }
        //
        //Các Envent của Control
        //

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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



        //
        //Thuộc Tính
        //
        public List<string> list_31 = new List<string>() { "Ngày", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
        public List<string> list_30 = new List<string>() { "Ngày", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" };
        public List<string> list_29 = new List<string>() { "Ngày", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29" };
        public List<string> list_28 = new List<string>() { "Ngày", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28" };

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Something.Utilities.isValid_forNumbertext(e.KeyChar);
        }


    }
}
