using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuyGear.uc;
using BuyGear.DAO;
using BuyGear.DTO;
namespace BuyGear
{
    public partial class Form_Admin2 : Form
    {
        public Form_Admin2()
        {
            InitializeComponent();
        }

        bool expand = false;


        
        #region TAIKHOAN
        ucTaiKhoan InfoUc(string id, string username, string hoatdong)
        {
            ucTaiKhoan uc = new ucTaiKhoan(this);
            uc.lbID.Text = id;
            uc.lbUser.Text = username;
            if (hoatdong == "co")
            {
                uc.bunifuToggleSwitch1.Value = true;
            }
            else
                uc.bunifuToggleSwitch1.Value = false;
            return uc;

        }
        ucBanHang InfoUcBanHang(string id, string username)
        {
            ucBanHang uc = new ucBanHang(this);
            uc.lbID.Text = id;
            uc.lbUser.Text = username;
            return uc;
        }
        ucDuyetSP InfoUcDuyet(string id, string maSP, string thoigian)
        {
            ucDuyetSP uc = new ucDuyetSP(this);
            uc.lbID.Text = id;
            uc.lbMaSP.Text = maSP;
            uc.lbTG.Text = thoigian;
            return uc;
        }
        #endregion

        private void btnAcc_Click(object sender, EventArgs e)
        {
            loadTaiKhoan();
        }

        public void loadTaiKhoan()
        {
            fpnlItem.Visible = true;
            fpnlItem.Controls.Clear();
            panel2.Controls.Clear();
            DataTable data = Data.Instance.GetTaiKhoan();
            foreach (DataRow item in data.Rows)
            {
                ucTaiKhoan uc = new ucTaiKhoan(this);
                uc = InfoUc(item["id"].ToString(), item["username"].ToString(), item["isactive"].ToString());
                if (item["isduocban"].ToString() == "co")
                {
                    uc.picBan.Visible = uc.picHuy.Visible = true;
                }
                fpnlItem.Controls.Add(uc);
            }
        }
        public void LoadTop(FlowLayoutPanel fpnl, string str)
        {
            fpnl.Controls.Clear();
            DataTable data = Data.Instance.loadTop(str);
            foreach (DataRow item in data.Rows)
            {
                ucTaiKhoan uc = new ucTaiKhoan(this);
                uc = InfoUc(item["id"].ToString(), item["username"].ToString(), item["isactive"].ToString());
                if (item["isduocban"].ToString() == "co")
                {
                    uc.picBan.Visible = uc.picHuy.Visible = true;
                }
                fpnl.Controls.Add(uc);
            }
        }
        public void loadYeuCau()
        {
            fpnlItem.Visible = true;
            fpnlItem.Controls.Clear();
            panel2.Controls.Clear();
            DataTable data = Data.Instance.GetTaiKhoan();
            foreach (DataRow item in data.Rows)
            {    
                if (item["isduocban"].ToString() == "cho xac nhan")
                {
                    ucBanHang uc = new ucBanHang(this);
                    uc = InfoUcBanHang(item["id"].ToString(), item["username"].ToString());
                    fpnlItem.Controls.Add(uc);
                }
            }
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            loadYeuCau();
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            loadDuyetSP();
        }
        public void loadDuyetSP()
        {
            fpnlItem.Visible = true;
            fpnlItem.Controls.Clear();
            panel2.Controls.Clear();
            DataTable data = Data.Instance.GetKiemDuyet();
            foreach (DataRow item in data.Rows)
            {
                if (item["trangthaikiemduyet"].ToString() == "chua kiem duyet")
                {
                    ucDuyetSP uc = new ucDuyetSP(this);
                    uc = InfoUcDuyet(item["ID_ngban"].ToString(),item["ma_sp"].ToString(), item["thoigian"].ToString().Remove(10, item["thoigian"].ToString().Length - 10));
                    fpnlItem.Controls.Add(uc);
                }
            }
        }
        public void editDataGridView(DataGridView d)
        {
            d.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            d.ColumnHeadersDefaultCellStyle.Font = btnAcc.Font;
        }

        private void btnLS_Click(object sender, EventArgs e)
        {
            fpnlItem.Visible = false;
            fpnlItem.Controls.Clear();
            panel2.Controls.Clear();
            txtSearch2.Text = "";
            DgvLSGD.DataSource = Data.Instance.GetCTHD();
            pnlLSGD.Dock = DockStyle.Fill;
            this.editDataGridView(DgvLSGD);
            panel2.Controls.Add(pnlLSGD);
        }


        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            ShowInforByID(DgvLSGD, "ID người mua");
        }
        public void ShowInforByID(DataGridView d, string nameColumn)
        {
            Account.Instance.userName = Account.Instance.FindUsername(d.SelectedRows[0].Cells[nameColumn].Value.ToString());
            Form_Infor2 f = new Form_Infor2();
            f.Size = this.Size;
            f.Location = this.Location;
            f.chkChangePass.Visible = false;
            f.btnUpdate.Visible = false;
            f.ShowDialog();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            ShowInforByID(DgvLSGD, "ID người bán");
        }

        private void btnXemchitiet_Click(object sender, EventArgs e)
        {
            Form_SanPham f = new Form_SanPham(DgvLSGD.SelectedRows[0].Cells[3].Value.ToString(), this, 1);
            f.bunifuButton1.Visible = f.bunifuButton2.Visible = false;
            f.ShowDialog();
        }

        private void DgvLSGD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pnlCTLS.Visible = true;
        }

        private void DgvLSGD_Sorted(object sender, EventArgs e)
        {
            pnlCTLS.Visible = false;

            txtSearch2.Text = "";
        }

        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            Search(DgvLSGD, txtSearch2, pnlKQ2, lbIndex2, lbSum2, lbKhongKQ2);
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
        protected List<int> n = new List<int>();

        private void btnDK_Click(object sender, EventArgs e)
        {
            txtSearch2.Text = "";
            panel2.Controls.Clear();
            fpnlItem.Controls.Clear();
            fpnlItem.Visible = false;

            Form_Register f = new Form_Register()
            {
                TopLevel = false,
                TopMost = true
            }; 
            f.timer1.Enabled = false;
            f.btnDangkyAdmin.Visible = f.btnThoat.Visible = true;
            f.btnDangky.Visible = false;
            f.bunifuLabel1.Visible = f.bunifuLabel2.Visible = f.bunifuLabel3.Visible = f.bunifuLabel4.Visible = false;
            f.label1.Visible = f.lblDangNhap.Visible = false;
            fpnlItem.Controls.Clear();
            panel2.Controls.Clear();
            panel2.Controls.Add(f);
            f.Show();
        }

        private void btnDX_Click(object sender, EventArgs e)
        {
            txtSearch2.Text = "";
            panel2.Controls.Clear();
            fpnlItem.Controls.Clear();
            fpnlItem.Visible = false;
            if (MessageBox.Show("Bạn muốn đăng xuất khỏi tài khoản ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Account.Instance.userName = "";
                Account.Instance.passWord = "";
                this.Close();
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            fpnlItem.Visible = false;
            fpnlItem.Controls.Clear();
            panel2.Controls.Clear();
            pnlTrangChu.Dock = DockStyle.Fill;
            string[] str = Data.Instance.LoadSoLuong();
            lbTK.Text = str[0];
            lbBan.Text = str[1];
            lbDuyet.Text = str[2];
            lbLS.Text = str[3];
            chart1.Series["Loại sản phẩm"].Points.Clear();
            chart1.Series["Loại sản phẩm"].Points.AddXY("Màn hình", Data.Instance.loadSlLoaiSP("ManHinh").Rows[0][0].ToString());
            chart1.Series["Loại sản phẩm"].Points.AddXY("Bàn phím", Data.Instance.loadSlLoaiSP("BanPhim").Rows[0][0].ToString());
            chart1.Series["Loại sản phẩm"].Points.AddXY("Chuột", Data.Instance.loadSlLoaiSP("Chuot").Rows[0][0].ToString());
            chart1.Series["Loại sản phẩm"].Points.AddXY("Ổ cứng", Data.Instance.loadSlLoaiSP("OCung").Rows[0][0].ToString());
            chart1.Series["Loại sản phẩm"].Points.AddXY("Tản nhiệt", Data.Instance.loadSlLoaiSP("TanNhiet").Rows[0][0].ToString());
            chart1.Series["Loại sản phẩm"].Points.AddXY("USB", Data.Instance.loadSlLoaiSP("USB").Rows[0][0].ToString());

            LoadTop(fpnlThu, "thu");
            LoadTop(flowLayoutPanel2, "chi");
            panel2.Controls.Add(pnlTrangChu);

            
        }




        private void pictureBox8_Click(object sender, EventArgs e)
        {
            expand = true;
            pnlMenu.Visible = false;
            pnlMenu.Width = 206;
            bunifuTransition1.Show(pnlMenu);
            pictureBox8.Visible = false;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            expand = false;
            pnlMenu.Visible = false;
            pnlMenu.Width = 46;
            bunifuTransition1.Show(pnlMenu);
            pictureBox8.Visible = true;
        }

    }
}
