﻿using BuyGear.DAO;
using BuyGear.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace BuyGear
{
    public partial class Form_SanPham : Form
    {
        Form_Main parent;
        public Form_SanPham(string masp, Form_Main parent)
        {
            this.parent = parent;
            InitializeComponent();
            this._masp = masp;
            LoadNhanXetFull();
            InitiativeYeuThich();
        }
        private void Load_Form()
        {
            List<string> list_top = new List<string>();
            DataTable dataTable = Data.Instance.Load_SP(_masp);
            if (dataTable.Rows[0] != null)
            {
                DataRow row = dataTable.Rows[0];
                SanPham sp = new SanPham();
                sp = Data.Instance.Load_SP_byMaSP(_masp);
                lblTenSanPham.Text = sp.TenSP;
                lblThuongHieuText.Text = sp.NhaSX;
                lblGia.Text = giaFix(sp.Gia);
                lblXuatXu.Text = sp.XuatXu;
                picSanPhamMain.SizeMode = PictureBoxSizeMode.Zoom;
                picSanPhamMain.Image = Images.BinaryToImage(sp.link_image[0]);
                picAnh1.SizeMode = PictureBoxSizeMode.Zoom;
                picAnh1.Image = Images.BinaryToImage(sp.link_image[1]);
                picAnh2.SizeMode = PictureBoxSizeMode.Zoom;
                picAnh2.Image = Images.BinaryToImage(sp.link_image[2]);
                picAnh3.SizeMode = PictureBoxSizeMode.Zoom;
                picAnh3.Image = Images.BinaryToImage(sp.link_image[3]);

            }


        }
        private string giaFix(int gia)
        {
            string giafix = "";
            if (gia / 1000000 > 0)
            {
                if (gia % 1000000 / 1000 > 100)
                    giafix = (gia / 1000000).ToString() + "." + (gia % 1000000 / 1000).ToString() + ".000";
                else if (gia % 1000000 / 1000 > 10)
                    giafix = (gia / 1000000).ToString() + ".0" + (gia % 1000000 / 1000).ToString() + ".000";
                else giafix = (gia / 1000000).ToString() + ".00" + (gia % 1000000 / 1000).ToString() + ".000";
            }
            else
                giafix = (gia / 1000).ToString() + ".000";
            return giafix + " đồng";

        }
        //
        //Các envent của control
        //
        private void Form_SanPham_Load(object sender, EventArgs e)
        {
            this.Load_Form();
        }

        private void btnReturn_main_Click(object sender, EventArgs e)
        {
            if (this.parent != null)
            {
                this.parent.fpnlChiTiet.Visible = false;
                this.parent.fpnlProduct.Visible = true; 
                this.parent.pnlChiTietChange.Visible = false;
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
        //
        //Thuộc tính
        //
        private string _masp;

        private void picMouseDemo_Click(object sender, EventArgs e)
        {

        }

        private void lblXuatXu_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.parent != null)
            {
                this.Size = this.parent.Size;
               // pnlBottomLeft.Size = new Size(pnlBottomLeft.Size.Width, this.parent.fpnlChitiet.Size.Height * 2 / 3);
                pnlBottomRight.Size = new Size(pnlBottomLeft.Size.Width, this.parent.fpnlChiTiet.Size.Height * 2 / 4);
                picAnh1.Size = new Size(picAnh1.Width, pnlSanPhamNoMainPicture.Size.Height / 3);
                picAnh2.Size = new Size(picAnh2.Width, pnlSanPhamNoMainPicture.Size.Height / 3);
                picAnh3.Size = new Size(picAnh3.Width, pnlSanPhamNoMainPicture.Size.Height / 3);
                pnlSanPhamNoMainPicture.Size = new Size(pnlSanPhamMainPicture.Size.Width / 4, pnlSanPhamNoMainPicture.Height);
                pnlChiTietRight.Size = new Size((this.parent.fpnlChiTiet.Size.Width) * 3 / 5, pnlChiTietRight.Size.Height);
                fpnlNhanXet.Size = new Size(this.fpnlLeftTotal.Size.Width, fpnlNhanXet.Size.Height);
                //
                if (this.parent.Size.Height > 800)
                {
                    pnlBottomRight.Visible = true;
                }
                else
                {
                    pnlBottomRight.Visible = false;
                }
            }
        }

        private void panelDB11_Paint(object sender, PaintEventArgs e)
        {

        }

        #region HOAI
        Form_Admin grandparent;
        public Form_SanPham(string masp, Form_Admin grandparent)
        {
            this.grandparent = grandparent;
            InitializeComponent();
            this._masp = masp;
        }
        #endregion

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (Account.Instance.id != "")
            {
                Data_gioHang.Instance.InsertToGioHang(Account.Instance.id, _masp);
                this.parent.pnlAddThanhCong.Visible = true;
                this.parent.pnlAddThanhCong.Location = new Point(this.parent.pnlTabGioHangThongBao.Location.X - 15,
                    this.parent.pnlAddThanhCong.Location.Y);
                this.parent.ThongTinGioHang();
                this.parent.btnGioHang_click(sender, e);
            }
            else
                MessageBox.Show("Vui lòng đăng nhập để mua hàng");

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (Account.Instance.id != "")
            {
                Data_gioHang.Instance.InsertToGioHang(Account.Instance.id, _masp);
                this.parent.pnlAddThanhCong.Visible = true;
                this.parent.pnlAddThanhCong.Location = new Point(this.parent.pnlTabGioHangThongBao.Location.X - 15,
                    this.parent.pnlAddThanhCong.Location.Y);
                this.parent.ThongTinGioHang();
            }
            else
                MessageBox.Show("Vui lòng đăng nhập để mua hàng");

        }

        private void pnlAboveReviews_Paint(object sender, PaintEventArgs e)
        {

        }


        private void LoadNhanXetFull()
        {
            int sum = 0, nrating = 0, nrate1 = 0, nrate2 = 0, nrate3 = 0, nrate4 = 0, nrate5 = 0; // "n" de phan biet voi rate toolbox
            List<NhanXet> listNhanXet = Data_NhanXet.Instance.loadNhanXet(_masp);
            List<byte[]> linkimage = new List<byte[]>();
            for (int i = 0; i < 5; i++)
            {
                bStar[i] = false;
            }
            for(int i=0; i<6; i++)
            {
                listvoting[i] = new List<NhanXet>();
            }
            foreach (NhanXet nx in listNhanXet)
            {
                
                sum++;
                nrating += nx.Vote;
                switch (nx.Vote)
                {
                    case 1:
                        nrate1++;
                        listvoting[0].Add(nx);
                        break;
                    case 2:
                        nrate2++;
                        listvoting[1].Add(nx);
                        break;
                    case 3:
                        nrate3++;
                        listvoting[2].Add(nx);
                        break;
                    case 4:
                        nrate4++;
                        listvoting[3].Add(nx);
                        break;
                    case 5:
                        nrate5++;
                        listvoting[4].Add(nx);
                        break;
                }
                listvoting[5].Add(nx);
                //  ucNhanXet ucnhanxet = new ucNhanXet(this, "hong", 1, "duoc", "duoc lam nha!!!",linkimage );
                ucNhanXet ucnhanxet = new ucNhanXet(this, nx.TenKhachHang, nx.Vote, nx.NhanXetChinh, nx.NhanXetChiTiet, linkimage);
                this.fpnlNhanXet.Controls.Add(ucnhanxet);
            }
            if (sum != 0)
            {
                voteBar1.Value = nrate1 * 100 / sum;
                voteBar2.Value = nrate2 * 100 / sum;
                voteBar3.Value = nrate3 * 100 / sum;
                voteBar4.Value = nrate4 * 100 / sum;
                voteBar5.Value = nrate5 * 100 / sum;
                lblNumberVote.Text = ((float)nrating / sum).ToString();
            }
            else
            {
                voteBar1.Value = 0;
                voteBar2.Value = 0;
                voteBar3.Value = 0; 
                voteBar4.Value = 0;
                voteBar5.Value = 0;
                lblNumberVote.Text = 0.ToString();
            }   
            lblSoNguoiVote.Text = sum.ToString() + " nhận xét";
           
            
        }
        private bool[] bStar = new bool[5];
        private List<NhanXet>[] listvoting = new List<NhanXet>[6];
        private void returnInitiateColor()
        {
            for(int i=0; i<5; i++)
            {
                bStar[i] = false;
            }
            btn1Star.Normalcolor = btn2Star.Normalcolor = btn3Star.Normalcolor = btn4Star.Normalcolor = btn5Star.Normalcolor
                = Color.WhiteSmoke;
            btn1Star.Textcolor = btn2Star.Textcolor = btn3Star.Textcolor = btn4Star.Textcolor = btn5Star.Textcolor
                = Color.Black;

        }
        private void btnStar_click(int index)
        {
            List<byte[]> linkimage = new List<byte[]>();
            if (!bStar[index-1])
            {
                returnInitiateColor();
                switch(index)
                {
                    case 1:
                        btn1Star.Normalcolor = Color.FromArgb(0, 192, 192);
                        btn1Star.Textcolor = Color.White;
                        break;
                    case 2:
                        btn2Star.Normalcolor = Color.FromArgb(0, 192, 192);
                        btn2Star.Textcolor = Color.White;
                        break;
                    case 3:
                        btn3Star.Normalcolor = Color.FromArgb(0, 192, 192);
                        btn3Star.Textcolor = Color.White;
                        break;
                    case 4:
                        btn4Star.Normalcolor = Color.FromArgb(0, 192, 192);
                        btn4Star.Textcolor = Color.White;
                        break;
                    case 5:
                        btn5Star.Normalcolor = Color.FromArgb(0, 192, 192);
                        btn5Star.Textcolor = Color.White;
                        break;

                }
                bStar[index - 1] = true;
                fpnlNhanXet.Controls.Clear();
                foreach (NhanXet nx in listvoting[index - 1])
                {
                    ucNhanXet ucnhanxet = new ucNhanXet(this, nx.TenKhachHang, nx.Vote, nx.NhanXetChinh, nx.NhanXetChiTiet, linkimage);
                    this.fpnlNhanXet.Controls.Add(ucnhanxet);
                }
            }
            else
            {
                returnInitiateColor();
                switch(index)
                {
                    case 1:
                        btn1Star.Normalcolor = Color.WhiteSmoke;
                        btn1Star.Textcolor = Color.Black;
                        break;
                    case 2:
                        btn2Star.Normalcolor = Color.WhiteSmoke;
                        btn2Star.Textcolor = Color.Black;
                        break;
                    case 3:
                        btn3Star.Normalcolor = Color.WhiteSmoke;
                        btn3Star.Textcolor = Color.Black;
                        break;
                    case 4:
                        btn4Star.Normalcolor = Color.WhiteSmoke;
                        btn4Star.Textcolor = Color.Black;
                        break;
                    case 5:
                        btn5Star.Normalcolor = Color.WhiteSmoke;
                        btn5Star.Textcolor = Color.Black;
                        break;
                }
                bStar[index - 1] = false;
                fpnlNhanXet.Controls.Clear();
                foreach (NhanXet nx in listvoting[5])
                {
                    ucNhanXet ucnhanxet = new ucNhanXet(this, nx.TenKhachHang, nx.Vote, nx.NhanXetChinh, nx.NhanXetChiTiet, linkimage);
                    this.fpnlNhanXet.Controls.Add(ucnhanxet);
                }
            }
        }
        private void btn5Star_Click(object sender, EventArgs e)
        {
            btnStar_click(5);
        }

        private void btn4Star_Click(object sender, EventArgs e)
        {
            btnStar_click(4);
        }

        private void btn3Star_Click(object sender, EventArgs e)
        {
            btnStar_click(3);
        }

        private void btn2Star_Click(object sender, EventArgs e)
        {
            btnStar_click(2);
        }

        private void btn1Star_Click(object sender, EventArgs e)
        {
            btnStar_click(1);
        }

        private void btnYeuThich_Click(object sender, EventArgs e)
        {
            if (!Data_gioHang.Instance.checkYeuThich(_masp))
            {
                btnYeuThich.Image = BuyGear.Properties.Resources.loveIcon1;
                Data_gioHang.Instance.AddYeuthich(_masp);
            }
            else
            {
                btnYeuThich.Image = BuyGear.Properties.Resources.love2;
                Data_gioHang.Instance.DeleteFromYeuThich(_masp);
            }
        }
        private void InitiativeYeuThich()
        {
            if (Data_gioHang.Instance.checkYeuThich(_masp))
            {
                btnYeuThich.Image = BuyGear.Properties.Resources.loveIcon1;
            }
            else
            {
                btnYeuThich.Image = BuyGear.Properties.Resources.love2;
            }
        }
    }
}