using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuyGear.DAO;
using BuyGear.DTO;

namespace BuyGear
{
    public partial class Form_Admin : Form
    {
        public Form_Admin()
        {
            InitializeComponent();
        }

        protected List<int> n = new List<int>();

        #region FORM
        private void Form_Admin_Load(object sender, EventArgs e)
        {

            pnlKiemDuyet.Dock = pnlTaiKhoan.Dock = pnlLSGD.Dock = DockStyle.Fill;
            DgvTaiKhoan.DataSource = Data.Instance.GetTaiKhoan();

            this.editDataGridView(DgvTaiKhoan);

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát khỏi ứng dụng ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Account.Instance.userName = "";
                this.Close();
            }
        }

        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {

            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;

            }
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void bunifuFlatButton12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void editDataGridView(DataGridView d)
        {
            d.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            d.ColumnHeadersDefaultCellStyle.Font = btnAccount.Font;
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            txtSearch2.Text = txtSearch3.Text = txtSearch.Text = "";
            pnlDuyet.Visible = pnlQuyen.Visible = pnlCTLS.Visible = false;

            picBoxSlider.Left = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Left;
            picBoxSlider.Width = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Width;

            Form_Register f = new Form_Register();
            f.timer1.Enabled = false;
            f.btnDangkyAdmin.Visible = f.btnThoat.Visible = true;
            f.btnDangky.Visible = false;
            f.bunifuLabel1.Visible = f.bunifuLabel2.Visible = f.bunifuLabel3.Visible = f.bunifuLabel4.Visible = false;
            f.label1.Visible = f.lblDangNhap.Visible = false;
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {
            txtSearch2.Text = txtSearch3.Text = txtSearch.Text = "";
            pnlDuyet.Visible = pnlQuyen.Visible = false;

            picBoxSlider.Left = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Left;
            picBoxSlider.Width = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Width;

            if (MessageBox.Show("Bạn muốn đăng xuất khỏi tài khoản ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Account.Instance.userName = "";
                this.Close();
            }
        }
        #endregion

        #region TAIKHOAN
        private void btnAccount_Click(object sender, EventArgs e)
        {
            txtSearch2.Text = txtSearch3.Text = txtSearch.Text = "";
            txtSearch2.Text = txtSearch3.Text = "";
            pnlDuyet.Visible = pnlCTLS.Visible = false;

            picBoxSlider.Left = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Left;
            picBoxSlider.Width = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Width;

            pnlTaiKhoan.Visible = true;
            pnlLSGD.Visible = false;
            pnlKiemDuyet.Visible = false;

            DgvTaiKhoan.DataSource = Data.Instance.GetTaiKhoan();

        }

        private void DgvTaiKhoan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            pnlQuyen.Visible = true;
            if (DgvTaiKhoan.SelectedRows[0].Cells[4].Value.ToString() == "khong")
            {
                pnlBan.Visible = false;
            }
            else if (DgvTaiKhoan.SelectedRows[0].Cells[4].Value.ToString() == "co")
            {
                pnlBan.Visible = true;
                rdoCo.Checked = true;
            }
            else
            {
                pnlBan.Visible = true;
                rdoCo.Checked = rdoKhong.Checked = false;
            }
            if (DgvTaiKhoan.SelectedRows[0].Cells[5].Value.ToString() == "khong")
            {
                chkHoatdong.Checked = false;
            }
            else
                chkHoatdong.Checked = true;
        }

        private void chkHoatdong_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chkHoatdong.Checked)
            {
                this.DgvTaiKhoan.SelectedRows[0].Cells[5].Value = "co";
            }
            else
                this.DgvTaiKhoan.SelectedRows[0].Cells[5].Value = "khong";
        }

        private void DgvTaiKhoan_Sorted(object sender, EventArgs e)
        {
            pnlQuyen.Visible = false;

            txtSearch.Text = "";
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Data.Instance.CapNhatQuyenTaiKhoan(DgvTaiKhoan);
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            Form_DKBH f = new Form_DKBH();
            f.panel1.Visible = f.btnDangKy.Visible = false;
            f.txtTenCH.Enabled = f.rdoCaNhan.Enabled = f.rdoCongTy.Enabled = f.rdoCo.Enabled = f.rdoKhong.Enabled = f.cboxDiaChi.Enabled = false;
            DataRow row = Account.Instance.ShowTTCH(DgvTaiKhoan.SelectedRows[0].Cells["ID"].Value.ToString());
            f.txtTenCH.Text = row["tengianhang"].ToString();
            if (row["loaihinh"].ToString() == "Cá nhân")
            {
                f.rdoCaNhan.Checked = true;
            }
            else
                f.rdoCongTy.Checked = true;
            f.rdoCo.Checked = true;
            f.cboxDiaChi.Text = row["diachikho"].ToString();
            f.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search(DgvTaiKhoan, txtSearch, pnlKQ, lbIndex, lbSum,lbKhongKQ);
        }

        private void lbUp_Click(object sender, EventArgs e)
        {
            lbIndex.Text = Up(DgvTaiKhoan, lbIndex.Text, lbSum.Text);
        }

        private void lbDown_Click(object sender, EventArgs e)
        {
            lbIndex.Text = Down(DgvTaiKhoan, lbIndex.Text, lbSum.Text);
        }

        private void lbClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void DgvTaiKhoan_SelectionChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                pnlQuyen.Visible = true;
                if (DgvTaiKhoan.SelectedRows[0].Cells[4].Value.ToString() == "khong")
                {
                    pnlBan.Visible = false;
                }
                else if (DgvTaiKhoan.SelectedRows[0].Cells[4].Value.ToString() == "co")
                {
                    pnlBan.Visible = true;
                    rdoCo.Checked = true;
                }
                else
                {
                    pnlBan.Visible = true;
                    rdoCo.Checked = rdoKhong.Checked = false;
                }
                if (DgvTaiKhoan.SelectedRows[0].Cells[5].Value.ToString() == "khong")
                {
                    chkHoatdong.Checked = false;
                }
                else
                    chkHoatdong.Checked = true;
            }

        }
        #endregion

        #region LSGD
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            txtSearch2.Text = txtSearch3.Text = txtSearch.Text = "";
            pnlDuyet.Visible = pnlQuyen.Visible = false;

            picBoxSlider.Left = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Left;
            picBoxSlider.Width = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Width;

            pnlTaiKhoan.Visible = false;
            pnlLSGD.Visible = true;
            pnlKiemDuyet.Visible = false;

            DgvLSGD.DataSource = Data.Instance.GetCTHD();
            this.editDataGridView(DgvLSGD);
        }

        private void DgvLSGD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pnlCTLS.Visible = true;
        }

        private void bunifuFlatButton1_Click_3(object sender, EventArgs e)
        {
            ShowInforByID(DgvLSGD, "ID người mua");
        }

        private void btnXemchitiet_Click_1(object sender, EventArgs e)
        {
            ShowItem(DgvLSGD);
        }

        private void bunifuFlatButton3_Click_3(object sender, EventArgs e)
        {
            ShowInforByID(DgvLSGD, "ID người bán");
        }

        private void DgvLSGD_Sorted(object sender, EventArgs e)
        {
            pnlCTLS.Visible = false;

            txtSearch2.Text = "";
        }

        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            Search(DgvLSGD, txtSearch2, pnlKQ2, lbIndex2, lbSum2,lbKhongKQ2);
        }

        private void bunifuCustomLabel8_Click(object sender, EventArgs e)
        {
            lbIndex2.Text = Up(DgvLSGD, lbIndex2.Text, lbSum2.Text);
        }

        private void btnDown2_Click(object sender, EventArgs e)
        {
            lbIndex2.Text = Down(DgvLSGD, lbIndex2.Text, lbSum2.Text);
        }

        private void btnX2_Click(object sender, EventArgs e)
        {
            txtSearch2.Text = "";
        }

        private void DgvLSGD_SelectionChanged(object sender, EventArgs e)
        {
            if (txtSearch2.Text != "")
            {
                pnlCTLS.Visible = true;
            }
        }
        #endregion

        #region KIEMDUYET
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            txtSearch2.Text = txtSearch3.Text = txtSearch.Text = "";
            pnlQuyen.Visible = pnlCTLS.Visible = false;

            picBoxSlider.Left = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Left;
            picBoxSlider.Width = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Width;

            pnlTaiKhoan.Visible = false;
            pnlLSGD.Visible = false;
            pnlKiemDuyet.Visible = true;

            DgvKiemDuyet.DataSource = Data.Instance.GetKiemDuyet();
            this.editDataGridView(DgvKiemDuyet);
        }

        private void DgvKiemDuyet_Sorted(object sender, EventArgs e)
        {
            pnlDuyet.Visible = false;

            txtSearch2.Text = "";
        }

        private void chkKiemDuyet_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (chkKiemDuyet.Checked)
            {
                this.DgvKiemDuyet.SelectedRows[0].Cells[5].Value = "da kiem duyet";
            }
            else
                this.DgvKiemDuyet.SelectedRows[0].Cells[5].Value = "chua kiem duyet";
        }

        private void DgvKiemDuyet_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            pnlDuyet.Visible = true;
            if (DgvKiemDuyet.SelectedRows[0].Cells[5].Value.ToString() == "chua kiem duyet")
            {
                chkKiemDuyet.Checked = false;
            }
            else
                chkKiemDuyet.Checked = true;
        }

        private void btnLuuKiemDuyet_Click(object sender, EventArgs e)
        {
            Data.Instance.CapNhatKiemDuyet(DgvKiemDuyet);
        }

        private void bunifuFlatButton3_Click_2(object sender, EventArgs e)
        {
            ShowItem(DgvKiemDuyet);
        }

        private void bunifuFlatButton4_Click_1(object sender, EventArgs e)
        {
            ShowInforByID(DgvKiemDuyet, "ID người bán");
        }

        private void DgvKiemDuyet_SelectionChanged(object sender, EventArgs e)
        {
            if (txtSearch3.Text != "")
            {
                pnlDuyet.Visible = true;
                if (DgvKiemDuyet.SelectedRows[0].Cells[5].Value.ToString() == "chua kiem duyet")
                {
                    chkKiemDuyet.Checked = false;
                }
                else
                    chkKiemDuyet.Checked = true;
            }
        }

        private void txtSearch3_TextChanged(object sender, EventArgs e)
        {
            Search(DgvKiemDuyet, txtSearch3, pnlKQ3, lbIndex3, lbSum3, lbKhongKQ3);
        }

        private void lbUp3_Click(object sender, EventArgs e)
        {
            lbIndex3.Text = Up(DgvKiemDuyet, lbIndex3.Text, lbSum3.Text);
        }

        private void lbDown3_Click(object sender, EventArgs e)
        {
            lbIndex3.Text = Down(DgvKiemDuyet, lbIndex3.Text, lbSum3.Text);
        }

        private void lbX3_Click(object sender, EventArgs e)
        {
            txtSearch3.Text = "";
        }
        #endregion

        #region FUNCTION
        public void ShowItem(DataGridView d)
        {
            Form_SanPham f = new Form_SanPham(d.SelectedRows[0].Cells["Mã sản phẩm"].Value.ToString(),this);
            f.Size = this.Size;
            f.Location = this.Location;
            f.ShowDialog();
        }

        public void ShowInfor(DataGridView d)
        {
            Account.Instance.userName = d.SelectedRows[0].Cells["UserName"].Value.ToString();
            Form_Infor f = new Form_Infor();
            f.Size = this.Size;
            f.Location = this.Location;
            f.chkChangePass.Visible = false;
            //f.btnUpdate.Visible = false;
            f.ShowDialog();
        }

        public void ShowInforByID(DataGridView d, string nameColumn)
        {
            Account.Instance.userName = Account.Instance.FindUsername(d.SelectedRows[0].Cells[nameColumn].Value.ToString());
            Form_Infor f = new Form_Infor();
            f.Size = this.Size;
            f.Location = this.Location;
            f.chkChangePass.Visible = false;
            //f.btnUpdate.Visible = false;
            f.ShowDialog();
        }

        public List<int> Search(DataGridView d, string text)
        {
            List<int> n = new List<int>();
            int m = -1;
            for (int i = 0; i < d.RowCount; i++)
            {
                for (int j = 0; j < d.Rows[i].Cells.Count; j++)
                {
                    if (d.Rows[i].Cells[j].Value.ToString().Contains(text))
                    {
                        if (m != i)
                        {
                            n.Add(i);
                            m = i;
                        }
                    }
                }
            }
            return n;
        }

        public string Down(DataGridView d, string index, string sum)
        {
            if (index != sum)
            {
                int i = int.Parse(index);
                d.Rows[n[i]].Selected = true;
                i++;
                return index = i.ToString();
            }
            else
            {
                d.Rows[n[0]].Selected = true;
                return index = "1";
            }
        }

        public string Up(DataGridView d, string index, string sum)
        {
            if (index != "1")
            {
                int i = int.Parse(index) - 1;
                d.Rows[n[i - 1]].Selected = true;
                return index = i.ToString();
            }
            else
            {
                d.Rows[n[int.Parse(sum) - 1]].Selected = true;
                return index = sum;
            }
        }

        public void Search(DataGridView d, TextBox txtSearch, Panel pnlKQ, Label lbIndex, Label lbSum, Label lbKhongKQ)
        {
            n.Clear();
            n = Search(d, txtSearch.Text);
            if (txtSearch.Text != "" && n.Count != 0)
            {
                pnlKQ.Visible = true;

                lbIndex.Text = "1";
                lbSum.Text = n.Count.ToString();

               d.Rows[n[int.Parse(lbIndex.Text.ToString()) - 1]].Selected = true;

            }
            else if (n.Count == 0)
            {
                pnlKQ.Visible = false;
                lbKhongKQ.Visible = true;
            }
            else
            {
                lbKhongKQ.Visible = pnlKQ.Visible = false;
            }
        }


        #endregion

        private void rdoCo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCo.Checked)
            {
                this.DgvTaiKhoan.SelectedRows[0].Cells[4].Value = "co";
            }
        }

        private void rdoKhong_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoKhong.Checked)
            {
                this.DgvTaiKhoan.SelectedRows[0].Cells[4].Value = "khong";
            }
        }

        private void DgvTaiKhoan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowInfor(DgvTaiKhoan);
        }
    }
}
