using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using BuyGear.DAO;
using BuyGear.DTO;
using BuyGear.uc;
using System.IO;
using System.Media;

namespace BuyGear
{
    public partial class Form_Main : Form
    {


        public Form_Main()
        {
            InitializeComponent();
            SearchButtonClear();
            UnvisionAll();
            DoubleBuffered = true;
            this.Text = string.Empty;
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
            // minus menu left
            btnDanhMuc.Visible = false;
            btnDanhMucMinus.Visible = true;
            pnlDanhMucLeft.Visible = true;
            pnlDanhMucLeft.Width = 80;
            lblBuyGear.Text = "BG";

            fpnlProduct.Controls.Clear();
            topEvent();

            //some infor
            
            if (Account.Instance.id == "")
                this.btnSoSp.Text = "0";
            

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void btnMyInfor_Click(object sender, EventArgs e)
        {
            //this.pnl_TheoDoiDonHang.Visible = !this.pnl_TheoDoiDonHang.Visible;
            if (Account.Instance.userName == "")
                return;

            //open infor
            Form_Infor frm = new Form_Infor(this)
            {
                TopLevel = false,
                TopMost = true
            };
            this.fpnlChiTiet.Visible = true;
            this.fpnlProduct.Visible = false;
            this.pnlChiTietChange.Visible = true;
            this.fpnlChiTiet.Controls.Clear();
            this.fpnlChiTiet.Controls.Add(frm);
            frm.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Account.Instance.userName != "")
                return;
            // new design login
            Form_Login frm = new Form_Login(this)
            { TopLevel = false, TopMost = true };
            frm.FormClosed += new FormClosedEventHandler(Form_Login_Closed);
            this.fpnlChiTiet.Visible = true;
            this.fpnlProduct.Visible = false;
            this.pnlChiTietChange.Visible = true;
            this.fpnlChiTiet.Controls.Clear();
            this.fpnlChiTiet.Controls.Add(frm);
            
            frm.Show();
            //Form_SanPham frmspx = new Form_SanPham(_masp, this.parent) { TopLevel = false, TopMost = true };
            //this.parent.fpnlChitiet.Controls.Clear();
            //this.parent.fpnlChitiet.Controls.Add(frmspx);
        }
        void Form_Login_Closed(object sender, FormClosedEventArgs e)
        {
            SearchButtonClear();
            this.fpnlChiTiet.Visible = true;
            this.fpnlProduct.Visible = true;
            this.pnlChiTietChange.Visible = false;
            //Loadavtar
            LoadAvatar();
        }

        private void btnEditInfor_Click(object sender, EventArgs e)
        {
            Form_Infor f = new Form_Infor();
            f.ShowDialog();
            pnl_TheoDoiDonHang.Visible = false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đăng xuất khỏi tài khoản ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Account.Instance.userName = "";
                Account.Instance.userName = "";
                Account.Instance.id = "";
                this.lblName.Text = "Đăng nhập";
                //btnMyInfor.Visible = false;
                //  pnl_TheoDoiDonHang.Visible = false;
                //btnLogin.Visible = true;
                this.picAvaMini.Image = Picture.FromFile("../../BuyGear.exe".Replace("BuyGear.exe", "Resources/usericon2.png")); 
                this.picAvatar.Image = Picture.FromFile("../../BuyGear.exe".Replace("BuyGear.exe", "Resources/usericon2.png"));
                this.pnl_TheoDoiDonHang.Visible = !this.pnl_TheoDoiDonHang.Visible;
                this.fpnlChiTiet.Controls.Clear();
            }
        }

        private void btnExitApp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát khỏi ứng dụng ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                bunifuFlatButton1.Enabled = false;
                Application.Exit();
                this.Close();
            }
        }

        private void UnvisionAll()
        {
            picLbanphim.Visible = false;
            picLchuot.Visible = false;
            picLmanhinh.Visible = false;
            picLocung.Visible = false;
            picLtannhiet.Visible = false;
            picLusb.Visible = false;
            picLkhac.Visible = false;
            fpnlProduct.Visible = true;
            fpnlChiTiet.Visible = false;
            pnlChiTietChange.Visible = false;
            

        }

        void loadSP_btnClick(string loaisp)
        {
            List<SanPham> listSP_byBtn = Data.Instance.loadDataSanPham(loaisp);
            foreach (SanPham sp in listSP_byBtn)
            {
                ucSanPham userControl = new ucSanPham(this);
                userControl.set(sp.MASP, sp.TenSP, sp.LoaiSP, sp.DVT, sp.XuatXu,
                    sp.NhaSX, sp.SoLuong, sp.Gia, Data.Instance.giaFix(sp.Gia), sp.link_image);
                fpnlProduct.Controls.Add(userControl);
            }
        }

        // this is 
        private void btnManHinh_Click_1(object sender, EventArgs e)
        {
            UnvisionAll();
            picLmanhinh.Visible = true;
            fpnlProduct.Controls.Clear();
            loadSP_btnClick("ManHinh");
        }
        // btn function giohang 
        public void btnGioHang_click(object sender, EventArgs e)
        {
            if (Account.Instance.userName == "")
            {
                MessageBox.Show("Vui lòng đăng nhập để vào giỏ hàng");
                return;
            }
            Form_GioHang frmGiohang = new Form_GioHang(this)
            {
                TopLevel = false,
                TopMost = true
            };
            this.fpnlChiTiet.Controls.Clear();
            this.fpnlProduct.Visible = false;
            this.pnlChiTietChange.Visible = true;
            this.fpnlChiTiet.Visible = true;
            this.fpnlChiTiet.Controls.Add(frmGiohang);
            frmGiohang.Show();
            this.pnlAddThanhCong.Visible = false;
        }

        private void btnBanphim_Click(object sender, EventArgs e)
        {
            UnvisionAll();
            picLbanphim.Visible = true;
            fpnlProduct.Controls.Clear();
            loadSP_btnClick("BanPhim");
        }

        private void btnChuot_Click(object sender, EventArgs e)
        {
            UnvisionAll();
            picLchuot.Visible = true;
            fpnlProduct.Controls.Clear();
            loadSP_btnClick("Chuot");
        }

        private void btnOcung_Click(object sender, EventArgs e)
        {
            UnvisionAll();
            picLocung.Visible = true;
            fpnlProduct.Controls.Clear();
            loadSP_btnClick("OCung");
        }

        private void btnTanNhiet_Click(object sender, EventArgs e)
        {
            UnvisionAll();
            picLtannhiet.Visible = true;
            fpnlProduct.Controls.Clear();
            loadSP_btnClick("TanNhiet");
        }

        private void btnUSB_Click(object sender, EventArgs e)
        {
            UnvisionAll();
            picLusb.Visible = true;
            fpnlProduct.Controls.Clear();
            loadSP_btnClick("USB");
        }

        private void btnKhac_Click(object sender, EventArgs e)
        {
            UnvisionAll();
            picLkhac.Visible = true;
            fpnlProduct.Controls.Clear();
            SearchButtonClear();
        }
        public string NonUnicode(string text)
        {
            string s = text.ToLower();
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
    "đ",
    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
    "í","ì","ỉ","ĩ","ị",
    "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
    "ý","ỳ","ỷ","ỹ","ỵ"};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
    "d",
    "e","e","e","e","e","e","e","e","e","e","e",
    "i","i","i","i","i",
    "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
    "u","u","u","u","u","u","u","u","u","u","u",
    "y","y","y","y","y"};
            for (int i = 0; i < arr1.Length; i++)
            {
                s = s.Replace(arr1[i], arr2[i]);
            }
            s = s.Replace("ọ", "o");
            return s;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UnvisionAll();
            fpnlChiTiet.Visible = false;
            fpnlProduct.Visible = true;
            fpnlProduct.Controls.Clear();

            List<SanPham> listSP = Data.Instance.loadDataSanPham();
            foreach (var sp in listSP)
            {
                string tensp = sp.TenSP;
                if (this.NonUnicode(tensp).Contains(this.NonUnicode(txtSearch.Text)))
                {
                    ucSanPham userControl = new ucSanPham(this);
                    userControl.set(sp.MASP, sp.TenSP, sp.LoaiSP, sp.DVT, sp.XuatXu, sp.NhaSX, sp.SoLuong, sp.Gia,
                        Data.Instance.giaFix(sp.Gia), sp.link_image);
                    fpnlProduct.Controls.Add(userControl);
                }
            }

        }
        public void CheckSearch(int n)
        {
            //fpnlProduct.Controls.Clear();
            string strSearch;
            if (n == 1)
            {
                strSearch = txtSearch.Text;
            }
            else
            {
                strSearch = "";
            }

            List<SanPham> listSP = Data.Instance.loadDataSanPham();
            foreach (SanPham sp in listSP)
            {
                string tensp = sp.TenSP;
                if (this.NonUnicode(tensp).Contains(this.NonUnicode(strSearch)))
                {
                    ucSanPham userControl = new ucSanPham(this);
                    userControl.set(sp.MASP, sp.TenSP, sp.LoaiSP, sp.DVT, sp.XuatXu, sp.NhaSX, sp.SoLuong, sp.Gia,
                        Data.Instance.giaFix(sp.Gia), sp.link_image);
                    fpnlProduct.Controls.Add(userControl);
                }
            }
        }
        private void SearchButton()
        {
            this.fpnlChiTiet.BringToFront();
            fpnlChiTiet.Visible = false;
            fpnlProduct.Visible = true;
            fpnlProduct.Controls.Clear();
            CheckSearch(1);
        }
       
        private void SearchButtonClear()
        {
            this.fpnlChiTiet.BringToFront();
            fpnlChiTiet.Visible = false;
            fpnlProduct.Visible = true;
            fpnlProduct.Controls.Clear();
            CheckSearch(2);

        }

        private void Maximized_click(object sender, EventArgs e)
        {

            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;

            }
            else
                this.WindowState = FormWindowState.Normal;

        }

        private void Minimize_click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        // MOVE FORM
        private bool ch = false;
        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ch = true;
            // ReleaseCapture();
            //  SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (ch)
            {

            }
        }

        private void pnlHeader_MouseUp(object sender, MouseEventArgs e)
        {
            //   ch = false; ReleaseCapture(); SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            if (pnlDanhMucLeft.Width == 193)
            {
                lblBuyGear.Text = "BG";
                btnDanhMuc.Visible = false;
                btnDanhMucMinus.Visible = true;
                pnlDanhMucLeft.Visible = false;
                pnlDanhMucLeft.Width = 80;
                transDanhmuc.ShowSync(pnlDanhMucLeft);
            }
            else if (pnlDanhMucLeft.Width == 80)
            {
                lblBuyGear.Text = "Buy Gear";
                pnlDanhMucLeft.Visible = false;
                btnDanhMuc.Visible = true;
                btnDanhMucMinus.Visible = false;
                pnlDanhMucLeft.Width = 193;
                transDanhmuc.ShowSync(pnlDanhMucLeft);               

            }

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchButton();
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Data.Instance.Setx(this.fpnlChiTiet.Size.Width);
            Data.Instance.Sety(this.fpnlChiTiet.Size.Height);
            if (Account.Instance.numberNotify > 0)
            {
                lblSothongbao.Visible = true;
                lblSothongbao.Text = Account.Instance.numberNotify.ToString();
            }
            else
                lblSothongbao.Visible = false;
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            pnlAccountRight.Visible = !pnlAccountRight.Visible;
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnXemVaThanhToan_Click(object sender, EventArgs e)
        {
            btnGioHang_click(sender, e);
        }

        private void btnExitInThanhToanTB_Click(object sender, EventArgs e)
        {
            pnlAddThanhCong.Visible = false;
        }
        public void AddSanPham(string masp)
        {
            Data_gioHang.Instance.InsertToGioHang(Account.Instance.id, masp);
            this.ThongTinGioHang();
        }
        public void ThongTinGioHang()
        {
            btnSoSp.Text = Data_gioHang.Instance.SoSanPhamTrongGio().ToString();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            if (!Account.Instance.isDangNhap())
            {
                MessageBox.Show("Bạn phải đăng nhập trước !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Account.Instance.isDuocBan())
            {
                if (Account.Instance.isDaDangKi())
                {
                    MessageBox.Show("Bạn đã đăng kí, hãy chờ admin kiểm duyệt nhé!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn chưa có quyền bán, nếu muốn bán, hãy bấm tiếp tục để đăng kí!",
                        "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        Form_DKBH f = new Form_DKBH();
                        f.Show();
                    }
                }
                return;
            }
            Form_BanHang b = new Form_BanHang(int.Parse(Account.Instance.id));
            this.Hide();
            b.ShowDialog();
            this.Show();
        }
        private void bunifuLabel2_Click(object sender, EventArgs e)
        {
            UnvisionAll();
            fpnlProduct.Visible = true;
            fpnlProduct.Controls.Clear();
            topEvent();
        }
        ucTopMain uctop;
        private void topEvent()
        {
           // uctop = new ucTopMain();
           // fpnlProduct.Controls.Add(uctop);
            ucTabSanPham ucsp_tab = new ucTabSanPham(this, "Sản phẩm bán chạy: ", "top");
            fpnlProduct.Controls.Add(ucsp_tab);
            ucTabSanPham ucsp_ta1b = new ucTabSanPham(this, "Giá sốc hôm nay: ", "daxem");
            fpnlProduct.Controls.Add(ucsp_ta1b);
            ucTabSanPham ucsp_ta2b = new ucTabSanPham(this, "Dành riêng cho bạn: ", "recommend");
            fpnlProduct.Controls.Add(ucsp_ta2b);
            ucTabSanPham ucsp_ta3b = new ucTabSanPham(this, "Các sản phẩm đã xem: ", "daxem");
            fpnlProduct.Controls.Add(ucsp_ta3b);
            fpnlProduct.Visible = true;
        }
       private void LoadAvatar()
        {
            if (!(Account.Instance.userName == ""))
            {
                picAvaMini.Image= Account.Instance.getAvatar();
                picAvatar.Image = Account.Instance.getAvatar();
            }
        }
        private void btnChangeAvatar_Click(object sender, EventArgs e)
        {
            if (!(Account.Instance.userName == ""))
            {
                string path = Picture.getLinkFromDialog();
                picAvaMini.Image = Picture.FromFile(path);
                picAvatar.Image = Picture.FromFile(path);
                Account.Instance.changeAvatar(path);
            }
        }
            
        private void timer_thongbao_Tick(object sender, EventArgs e)
        {
            if (Account.Instance.id != "")
            {
                int thongbao = Data.Instance.CheckThongBao("thongbaoxacnhan", false) +
                    Data.Instance.CheckThongBao("thongbaodagiao", false);
                if (thongbao > 0)
                {
                    Account.Instance.numberNotify = Data.Instance.CheckThongBao("thongbaoxacnhan_xem", false)
                        + Data.Instance.CheckThongBao("thongbaodagiao_xem", false);

                    playSimpleSound();

                }
            }
            
        }
        private void playSimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer("../../BuyGear.exe".Replace("BuyGear.exe", "AudioFolder/notify.wav"));
            simpleSound.Play();
        }
        private void btnThongBao_Click(object sender, EventArgs e)
        {
           
            if (Account.Instance.userName == "")
                return;

            //open infor
            Form_Infor frm = new Form_Infor(this)
            {
                TopLevel = false,
                TopMost = true
            };
            this.fpnlChiTiet.Visible = true;
            this.fpnlProduct.Visible = false;
            this.pnlChiTietChange.Visible = true;
            this.fpnlChiTiet.Controls.Clear();
            this.fpnlChiTiet.Controls.Add(frm);            
            frm.Show();
            frm.btnThongBao.PerformClick();
        }

        private void btnYeuThich_Click(object sender, EventArgs e)
        {
            if (Account.Instance.userName == "")
            {
                MessageBox.Show("Vui lòng đăng nhập để vào yêu thích");
                return;
            }
            Form_GioHang frmGiohang = new Form_GioHang(this)
            {
                TopLevel = false,
                TopMost = true
            };
            this.fpnlChiTiet.Controls.Clear();
            this.fpnlProduct.Visible = false;
            this.pnlChiTietChange.Visible = true;
            this.fpnlChiTiet.Visible = true;
            this.fpnlChiTiet.Controls.Add(frmGiohang);
            frmGiohang.Show();
            frmGiohang.YeuThichclick();
            this.pnlAddThanhCong.Visible = false;
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            if (Account.Instance.userName == "")
            {
                MessageBox.Show("Vui lòng đăng nhập để vào giỏ hàng");
                return;
            }
            Form_GioHang frmGiohang = new Form_GioHang(this,2)
            {
                TopLevel = false,
                TopMost = true
            };
            this.fpnlChiTiet.Controls.Clear();
            this.fpnlProduct.Visible = false;
            this.pnlChiTietChange.Visible = true;
            this.fpnlChiTiet.Visible = true;
            this.fpnlChiTiet.Controls.Add(frmGiohang);
            frmGiohang.Show();
            this.pnlAddThanhCong.Visible = false;
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            if (Account.Instance.userName == "")
                return;

            //open infor
            Form_Infor frm = new Form_Infor(this)
            {
                TopLevel = false,
                TopMost = true
            };
            this.fpnlChiTiet.Visible = true;
            this.fpnlProduct.Visible = false;
            this.pnlChiTietChange.Visible = true;
            this.fpnlChiTiet.Controls.Clear();
            this.fpnlChiTiet.Controls.Add(frm);
            frm.Show();
        }
    }
}




