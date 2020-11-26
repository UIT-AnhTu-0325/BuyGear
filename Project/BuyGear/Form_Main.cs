using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace BuyGear
{
    public partial class Form_Main : Form
    {
       
        public Form_Main()
        {
            InitializeComponent();
            SearchButton();
        /*  //  resize
           X = this.Width;
            Y = this.Height;
            setTag(this);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        */
            //initite 
            SearchButtonClear();
            UnvisionAll();
            DoubleBuffered = true;
           // this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.Text = string.Empty;
            this.ControlBox = false;

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        /*
       // resize
        float X;
        float Y;
        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    setTag(con);
                }

            }
        }

        private void setControls(float newx, float newy, Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                if (con.Tag != null)
                {
                    string[] mytag = con.Tag.ToString().Split(new char[] { ':' });

                    float a = Convert.ToSingle(mytag[0]) * newx;
                    con.Width = (int)a;
                    a = Convert.ToSingle(mytag[1]) * newy;
                    con.Height = (int)(a);
                    a = Convert.ToSingle(mytag[2]) * newx;
                    con.Left = (int)(a);
                    a = Convert.ToSingle(mytag[3]) * newy;
                    con.Top = (int)(a);
                    Single currentSize = Convert.ToSingle(mytag[4]) * newy;
                    con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                    if (con.Controls.Count > 0)
                    {
                        setControls(newx, newy, con);
                    }
                }
            }
        }
        private void frmMain_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X;
            this.Height = this.Width * 1080 / 1920;
            float newy = this.Height / Y;
            // float newy = newx * 1920 / 1080;
            setControls(newx, newy, this);
        }

        private const int cGrip = 16, cCaption = 32;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X > this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }
        */


        //
        //Thuộc tính
        //
        private List<string> _list_top = null;
        //
        //Các hàm đặc trưng
        //
        private void NameThongTin()
        {
            if (btnMyInfor.Visible)
            {
                btnMyInfor.Text = "Xin chào " + Account.Instance.userName;
            }
        }
        private List<string> getTopSP()
        {
            List<string> list_top = new List<string>();
            string sqlQuery = @"select masp from SanPham order by masp DESC";
            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);
            for(int i=0;i < dataTable.Rows.Count;i++)
            {
                DataRow row = dataTable.Rows[i];
                list_top.Add(row["masp"].ToString());
            }
            return list_top;
        }
        private List<string> getLinkImage(string masp)
        {
            List<string> list_image = new List<string>();
            string sqlQuery = @"select url from HinhAnh where relation_masp = '" + masp + "'";
            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                list_image.Add(row["url"].ToString());
            }
            return list_image;
        }
        //
        //Các Event của Control
        //
        private void Form_Main_Load(object sender, EventArgs e)
        {
            //_list_top = getTopSP();
            //picTop1.SizeMode = PictureBoxSizeMode.Zoom;
            //picTop1.Image = Image.FromFile(getLinkImage(_list_top[0])[0]);
            //picTop2.SizeMode = PictureBoxSizeMode.Zoom;
            //picTop2.Image = Image.FromFile(getLinkImage(_list_top[1])[0]);

         
        }
//==================================================================================================
        private void btnMyInfor_Click(object sender, EventArgs e)
        {
            this.pnl_TheoDoiDonHang.Visible = !this.pnl_TheoDoiDonHang.Visible;
          

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form_Login f = new Form_Login();
            f.ShowDialog();
            if (Account.Instance.userName != "")
            {
                btnLogin.Visible = false;
                btnMyInfor.Visible = true;
                NameThongTin();

            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Form_Register f = new Form_Register();
            f.ShowDialog();
            if (Account.Instance.userName != "")
            {
                btnLogin.Visible = false;
                btnMyInfor.Visible = true;
                NameThongTin();
            }
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
                btnMyInfor.Visible = false;
              //  pnl_TheoDoiDonHang.Visible = false;
                btnLogin.Visible = true;
                this.pnl_TheoDoiDonHang.Visible = !this.pnl_TheoDoiDonHang.Visible;
            }
        }

        private void btnExitApp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát khỏi ứng dụng ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                bunifuFlatButton1.Enabled = false;
                this.Close();
            }
        }
//================================================================================================== 
        private void picTop1_Click(object sender, EventArgs e)
        {
            Form_SanPham sp = new Form_SanPham(_list_top[0]);
            sp.ShowDialog();
        }
    
        private void picTop2_Click(object sender, EventArgs e)
        {
            Form_SanPham sp = new Form_SanPham(_list_top[1]);
            sp.ShowDialog();
        }

        //==========================================EVENT DANH MUC===================================
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
            fpnlChitiet.Visible = false;

        }
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
           
        }

        private void btnManHinh_Click_1(object sender, EventArgs e)
        {
            UnvisionAll();
            picLmanhinh.Visible = true;

            fpnlProduct.Controls.Clear();
            List<Monitor> listManHinh = Data.Instance.loadDataMonitor();
            foreach (Monitor monitor in listManHinh)
            {
                ucMonitor userControl = new ucMonitor(this);
                userControl.lbName.Text = monitor.TenSP;
                userControl.lbPrice.Text = giaFix(monitor.Gia);
                userControl._masp = monitor.MASP;
                userControl._tensp = monitor.TenSP;
                userControl._loai = monitor.LoaiSP;
                userControl._dvt = monitor.DVT;
                userControl._xuatxu = monitor.XuatXu;
                userControl._nhasx = monitor.NhaSX;
                userControl._soluong = monitor.SoLuong;
                userControl._gia = monitor.Gia;
                userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                userControl.picProduct.Image = Image.FromFile(monitor.link_image[0]);
                fpnlProduct.Controls.Add(userControl);  
               

            }
        }

        private void btnBanphim_Click(object sender, EventArgs e)
        {
            UnvisionAll();
            picLbanphim.Visible = true;
            
            fpnlProduct.Controls.Clear();

            List<Keyboard> listKeyboard = Data.Instance.loadDataKeyboard();
            foreach (Keyboard keyboard in listKeyboard)
            {
                ucItemKeyboard userControl = new ucItemKeyboard(this);
                //userControl.picProduct.Image = new Bitmap(Application.StartupPath + mouse.link_image[0]);
               
                userControl.lbName.Text = keyboard.TenSP;
                userControl.lbPrice.Text = giaFix(keyboard.Gia);
                userControl._masp = keyboard.MASP;
                userControl._tensp = keyboard.TenSP;
                userControl._loai = keyboard.LoaiSP;
                userControl._dvt = keyboard.DVT;
                userControl._xuatxu = keyboard.XuatXu;
                userControl._nhasx = keyboard.NhaSX;
                userControl._soluong = keyboard.SoLuong;
                userControl._gia = keyboard.Gia;

               
                userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                userControl.picProduct.Image = Image.FromFile(keyboard.link_image[1]);
                fpnlProduct.Controls.Add(userControl);

            }
        }
        private string giaFix(int gia)
        {
            string giafix = "";
            if (gia / 1000000 > 0)
                giafix = (gia / 1000000).ToString() + "." + (gia % 1000000/1000).ToString() + ".000";
            else
                giafix = (gia / 1000).ToString() + ".000";
            return giafix + " đồng";

        }
        private void btnChuot_Click(object sender, EventArgs e)
        {
            UnvisionAll();
            picLchuot.Visible = true;

            fpnlProduct.Controls.Clear();
            List<Mouse> listMouse = Data.Instance.loadDataMouse();
            foreach (Mouse mouse in listMouse)
            {
                ucItemMouse userControl = new ucItemMouse(this);
                userControl.lbName.Text = mouse.TenSP;
                userControl.lbPrice.Text = giaFix(mouse.Gia);
                userControl._masp = mouse.MASP;
                userControl._tensp = mouse.TenSP;
                userControl._loai = mouse.Loai;
                userControl._dvt = mouse.DVT;
                userControl._xuatxu = mouse.XuatXu;
                userControl._nhasx = mouse.NhaSX;
                userControl._soluong = mouse.SoLuong;
                userControl._gia = mouse.Gia;

                
                userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                userControl.picProduct.Image = Image.FromFile(mouse.link_image[0]);
                fpnlProduct.Controls.Add(userControl);

            }
        }

        private void btnOcung_Click(object sender, EventArgs e)
        {
            UnvisionAll();
            picLocung.Visible = true;

            fpnlProduct.Controls.Clear();
            List<Storage> listStorage = Data.Instance.loadDataStorage();
            foreach (Storage storage in listStorage)
            {
                ucStorage userControl = new ucStorage(this);
                userControl.lbName.Text = storage.TenSP;
                userControl.lbPrice.Text = giaFix(storage.Gia);
                userControl._masp = storage.MASP;
                userControl._tensp = storage.TenSP;
                userControl._loai = storage.LoaiSP;
                userControl._dvt = storage.DVT;
                userControl._xuatxu = storage.XuatXu;
                userControl._nhasx = storage.NhaSX;
                userControl._soluong = storage.SoLuong;
                userControl._gia = storage.Gia;


                userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                userControl.picProduct.Image = Image.FromFile(storage.link_image[0]);
                fpnlProduct.Controls.Add(userControl);

            }

        }

        private void btnTanNhiet_Click(object sender, EventArgs e)
        {
            UnvisionAll();
            picLtannhiet.Visible = true;

            fpnlProduct.Controls.Clear();
            List<fanLaptop> listfanLaptop = Data.Instance.loadDatafanLaptop();
            foreach (fanLaptop fan in listfanLaptop)
            {
                ucfanLaptop userControl = new ucfanLaptop(this);
                userControl.lbName.Text = fan.TenSP;
                userControl.lbPrice.Text = giaFix(fan.Gia);
                userControl._masp = fan.MASP;
                userControl._tensp = fan.TenSP;
                userControl._loai = fan.LoaiSP;
                userControl._dvt = fan.DVT;
                userControl._xuatxu = fan.XuatXu;
                userControl._nhasx = fan.NhaSX;
                userControl._soluong = fan.SoLuong;
                userControl._gia = fan.Gia;


                userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                userControl.picProduct.Image = Image.FromFile(fan.link_image[0]);
                fpnlProduct.Controls.Add(userControl);

            }
        }

        private void btnUSB_Click(object sender, EventArgs e)
        {
            UnvisionAll();
            picLusb.Visible = true;

            fpnlProduct.Controls.Clear();
            List<USB> listUSB = Data.Instance.loadDataUSB();
            foreach (USB usb in listUSB)
            {
                ucUSB userControl = new ucUSB(this);
                userControl.lbName.Text = usb.TenSP;
                userControl.lbPrice.Text = giaFix(usb.Gia);
                userControl._masp = usb.MASP;
                userControl._tensp = usb.TenSP;
                userControl._loai = usb.LoaiSP;
                userControl._dvt = usb.DVT;
                userControl._xuatxu = usb.XuatXu;
                userControl._nhasx = usb.NhaSX;
                userControl._soluong = usb.SoLuong;
                userControl._gia = usb.Gia;


                userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                userControl.picProduct.Image = Image.FromFile(usb.link_image[0]);
                fpnlProduct.Controls.Add(userControl);

            }


        }

        private void btnKhac_Click(object sender, EventArgs e)
        {
            UnvisionAll();
            picLkhac.Visible = true;

        }
        public string NonUnicode(string text)
        {
            string s = text.ToLower();
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
    "đ",
    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ề",
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
            fpnlChitiet.Visible = false;
            fpnlProduct.Visible = true;
            fpnlProduct.Controls.Clear();

            List<Mouse> listMouse = Data.Instance.loadDataMouse();
            List<Keyboard> listKeyboard = Data.Instance.loadDataKeyboard();
            List<Monitor> listMonitor = Data.Instance.loadDataMonitor();
            List<fanLaptop> listfanLaptop = Data.Instance.loadDatafanLaptop();
            List<Storage> listStorage = Data.Instance.loadDataStorage();
            List<USB> listUSB = Data.Instance.loadDataUSB();
            foreach (Mouse mouse in listMouse)
            {
                string tensp = mouse.TenSP;
                if (this.NonUnicode(tensp).Contains(this.NonUnicode(txtSearch.Text)))
                {
                    ucItemMouse userControl = new ucItemMouse(this);
                    userControl.lbName.Text = mouse.TenSP;
                    userControl.lbPrice.Text = giaFix(mouse.Gia);
                    userControl._masp = mouse.MASP;
                    userControl._tensp = mouse.TenSP;
                    userControl._loai = mouse.Loai;
                    userControl._dvt = mouse.DVT;
                    userControl._xuatxu = mouse.XuatXu;
                    userControl._nhasx = mouse.NhaSX;
                    userControl._soluong = mouse.SoLuong;
                    userControl._gia = mouse.Gia;

                    fpnlProduct.Controls.Add(userControl);
                    userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                    userControl.picProduct.Image = Image.FromFile(mouse.link_image[0]);
                }
            }
            foreach (Keyboard keyboard in listKeyboard)
            {
                string tensp = keyboard.TenSP;
                if (this.NonUnicode(tensp).Contains(this.NonUnicode(txtSearch.Text)))
                {
                    ucItemKeyboard userControl = new ucItemKeyboard(this);
                    //userControl.picProduct.Image = new Bitmap(Application.StartupPath + mouse.link_image[0]);

                    userControl.lbName.Text = keyboard.TenSP;
                    userControl.lbPrice.Text = giaFix(keyboard.Gia);
                    userControl._masp = keyboard.MASP;
                    userControl._tensp = keyboard.TenSP;
                    userControl._loai = keyboard.LoaiSP;
                    userControl._dvt = keyboard.DVT;
                    userControl._xuatxu = keyboard.XuatXu;
                    userControl._nhasx = keyboard.NhaSX;
                    userControl._soluong = keyboard.SoLuong;
                    userControl._gia = keyboard.Gia;

                    fpnlProduct.Controls.Add(userControl);
                    userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                    userControl.picProduct.Image = Image.FromFile(keyboard.link_image[1]);
                }
            }
            foreach (Monitor monitor in listMonitor)
            {
                string tensp = monitor.TenSP;
                if (this.NonUnicode(tensp).Contains(this.NonUnicode(txtSearch.Text)))
                {
                    ucMonitor userControl = new ucMonitor(this);
                    //userControl.picProduct.Image = new Bitmap(Application.StartupPath + mouse.link_image[0]);

                    userControl.lbName.Text = monitor.TenSP;
                    userControl.lbPrice.Text = giaFix(monitor.Gia);
                    userControl._masp = monitor.MASP;
                    userControl._tensp = monitor.TenSP;
                    userControl._loai = monitor.LoaiSP;
                    userControl._dvt = monitor.DVT;
                    userControl._xuatxu = monitor.XuatXu;
                    userControl._nhasx = monitor.NhaSX;
                    userControl._soluong = monitor.SoLuong;
                    userControl._gia = monitor.Gia;

                    fpnlProduct.Controls.Add(userControl);
                    userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                    userControl.picProduct.Image = Image.FromFile(monitor.link_image[1]);
                }
            }
            foreach (Storage storage in listStorage)
            {
                string tensp = storage.TenSP;
                if (this.NonUnicode(tensp).Contains(this.NonUnicode(txtSearch.Text)))
                {
                    ucStorage userControl = new ucStorage(this);
                    //userControl.picProduct.Image = new Bitmap(Application.StartupPath + mouse.link_image[0]);

                    userControl.lbName.Text = storage.TenSP;
                    userControl.lbPrice.Text = giaFix(storage.Gia);
                    userControl._masp = storage.MASP;
                    userControl._tensp = storage.TenSP;
                    userControl._loai = storage.LoaiSP;
                    userControl._dvt = storage.DVT;
                    userControl._xuatxu = storage.XuatXu;
                    userControl._nhasx = storage.NhaSX;
                    userControl._soluong = storage.SoLuong;
                    userControl._gia = storage.Gia;

                    fpnlProduct.Controls.Add(userControl);
                    userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                    userControl.picProduct.Image = Image.FromFile(storage.link_image[1]);
                }
            }
            foreach (USB usb in listUSB)
            {
                string tensp = usb.TenSP;
                if (this.NonUnicode(tensp).Contains(this.NonUnicode(txtSearch.Text)))
                {
                    ucUSB userControl = new ucUSB(this);
                    //userControl.picProduct.Image = new Bitmap(Application.StartupPath + mouse.link_image[0]);

                    userControl.lbName.Text = usb.TenSP;
                    userControl.lbPrice.Text = giaFix(usb.Gia);
                    userControl._masp = usb.MASP;
                    userControl._tensp = usb.TenSP;
                    userControl._loai = usb.LoaiSP;
                    userControl._dvt = usb.DVT;
                    userControl._xuatxu = usb.XuatXu;
                    userControl._nhasx = usb.NhaSX;
                    userControl._soluong = usb.SoLuong;
                    userControl._gia = usb.Gia;

                    fpnlProduct.Controls.Add(userControl);
                    userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                    userControl.picProduct.Image = Image.FromFile(usb.link_image[1]);
                }
            }
            foreach (fanLaptop fanlaptop in listfanLaptop)
            {
                string tensp = fanlaptop.TenSP;
                if (this.NonUnicode(tensp).Contains(this.NonUnicode(txtSearch.Text)))
                {
                    ucfanLaptop userControl = new ucfanLaptop(this);
                    //userControl.picProduct.Image = new Bitmap(Application.StartupPath + mouse.link_image[0]);

                    userControl.lbName.Text = fanlaptop.TenSP;
                    userControl.lbPrice.Text = giaFix(fanlaptop.Gia);
                    userControl._masp = fanlaptop.MASP;
                    userControl._tensp = fanlaptop.TenSP;
                    userControl._loai = fanlaptop.LoaiSP;
                    userControl._dvt = fanlaptop.DVT;
                    userControl._xuatxu = fanlaptop.XuatXu;
                    userControl._nhasx = fanlaptop.NhaSX;
                    userControl._soluong = fanlaptop.SoLuong;
                    userControl._gia = fanlaptop.Gia;

                    fpnlProduct.Controls.Add(userControl);
                    userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                    userControl.picProduct.Image = Image.FromFile(fanlaptop.link_image[1]);
                }
            }


        }
        private void SearchButton()
        {
            fpnlChitiet.Visible = false;
            fpnlProduct.Visible = true;
            fpnlProduct.Controls.Clear();

            List<Mouse> listMouse = Data.Instance.loadDataMouse();
        List<Keyboard> listKeyboard = Data.Instance.loadDataKeyboard();
        List<Monitor> listMonitor = Data.Instance.loadDataMonitor();
        List<fanLaptop> listfanLaptop = Data.Instance.loadDatafanLaptop();
        List<Storage> listStorage = Data.Instance.loadDataStorage();
        List<USB> listUSB = Data.Instance.loadDataUSB();
            foreach (Mouse mouse in listMouse)
            {
                string tensp = mouse.TenSP;
                if (this.NonUnicode(tensp).Contains(this.NonUnicode(txtSearch.Text)))
                {
            ucItemMouse userControl = new ucItemMouse(this);
            userControl.lbName.Text = mouse.TenSP;
            userControl.lbPrice.Text = giaFix(mouse.Gia);
            userControl._masp = mouse.MASP;
            userControl._tensp = mouse.TenSP;
            userControl._loai = mouse.Loai;
            userControl._dvt = mouse.DVT;
            userControl._xuatxu = mouse.XuatXu;
            userControl._nhasx = mouse.NhaSX;
            userControl._soluong = mouse.SoLuong;
            userControl._gia = mouse.Gia;

            fpnlProduct.Controls.Add(userControl);
            userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            userControl.picProduct.Image = Image.FromFile(mouse.link_image[0]);
        }
        }
            foreach (Keyboard keyboard in listKeyboard)
            {
                string tensp = keyboard.TenSP;
                if (this.NonUnicode(tensp).Contains(this.NonUnicode(txtSearch.Text)))
                {
            ucItemKeyboard userControl = new ucItemKeyboard(this);
            //userControl.picProduct.Image = new Bitmap(Application.StartupPath + mouse.link_image[0]);

            userControl.lbName.Text = keyboard.TenSP;
            userControl.lbPrice.Text = giaFix(keyboard.Gia);
            userControl._masp = keyboard.MASP;
            userControl._tensp = keyboard.TenSP;
            userControl._loai = keyboard.LoaiSP;
            userControl._dvt = keyboard.DVT;
            userControl._xuatxu = keyboard.XuatXu;
            userControl._nhasx = keyboard.NhaSX;
            userControl._soluong = keyboard.SoLuong;
            userControl._gia = keyboard.Gia;

            fpnlProduct.Controls.Add(userControl);
            userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            userControl.picProduct.Image = Image.FromFile(keyboard.link_image[0]);
        }
        }
            foreach (Monitor monitor in listMonitor)
            {
                string tensp = monitor.TenSP;
                if (this.NonUnicode(tensp).Contains(this.NonUnicode(txtSearch.Text)))
                {
            ucMonitor userControl = new ucMonitor(this);
            //userControl.picProduct.Image = new Bitmap(Application.StartupPath + mouse.link_image[0]);

            userControl.lbName.Text = monitor.TenSP;
            userControl.lbPrice.Text = giaFix(monitor.Gia);
            userControl._masp = monitor.MASP;
            userControl._tensp = monitor.TenSP;
            userControl._loai = monitor.LoaiSP;
            userControl._dvt = monitor.DVT;
            userControl._xuatxu = monitor.XuatXu;
            userControl._nhasx = monitor.NhaSX;
            userControl._soluong = monitor.SoLuong;
            userControl._gia = monitor.Gia;

            fpnlProduct.Controls.Add(userControl);
            userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            userControl.picProduct.Image = Image.FromFile(monitor.link_image[1]);
        }
        }
            foreach (Storage storage in listStorage)
            {
                string tensp = storage.TenSP;
                if (this.NonUnicode(tensp).Contains(this.NonUnicode(txtSearch.Text)))
                {
            ucStorage userControl = new ucStorage(this);
            //userControl.picProduct.Image = new Bitmap(Application.StartupPath + mouse.link_image[0]);

            userControl.lbName.Text = storage.TenSP;
            userControl.lbPrice.Text = giaFix(storage.Gia);
            userControl._masp = storage.MASP;
            userControl._tensp = storage.TenSP;
            userControl._loai = storage.LoaiSP;
            userControl._dvt = storage.DVT;
            userControl._xuatxu = storage.XuatXu;
            userControl._nhasx = storage.NhaSX;
            userControl._soluong = storage.SoLuong;
            userControl._gia = storage.Gia;

            fpnlProduct.Controls.Add(userControl);
            userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            userControl.picProduct.Image = Image.FromFile(storage.link_image[1]);
        }
        }
            foreach (USB usb in listUSB)
            {
                string tensp = usb.TenSP;
                if (this.NonUnicode(tensp).Contains(this.NonUnicode(txtSearch.Text)))
                {
            ucUSB userControl = new ucUSB(this);
            //userControl.picProduct.Image = new Bitmap(Application.StartupPath + mouse.link_image[0]);

            userControl.lbName.Text = usb.TenSP;
            userControl.lbPrice.Text = giaFix(usb.Gia);
            userControl._masp = usb.MASP;
            userControl._tensp = usb.TenSP;
            userControl._loai = usb.LoaiSP;
            userControl._dvt = usb.DVT;
            userControl._xuatxu = usb.XuatXu;
            userControl._nhasx = usb.NhaSX;
            userControl._soluong = usb.SoLuong;
            userControl._gia = usb.Gia;

            fpnlProduct.Controls.Add(userControl);
            userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            userControl.picProduct.Image = Image.FromFile(usb.link_image[1]);
        }
        }
            foreach (fanLaptop fanlaptop in listfanLaptop)
            {
                string tensp = fanlaptop.TenSP;
                if (this.NonUnicode(tensp).Contains(this.NonUnicode(txtSearch.Text)))
                {
            ucfanLaptop userControl = new ucfanLaptop(this);
            //userControl.picProduct.Image = new Bitmap(Application.StartupPath + mouse.link_image[0]);

            userControl.lbName.Text = fanlaptop.TenSP;
            userControl.lbPrice.Text = giaFix(fanlaptop.Gia);
            userControl._masp = fanlaptop.MASP;
            userControl._tensp = fanlaptop.TenSP;
            userControl._loai = fanlaptop.LoaiSP;
            userControl._dvt = fanlaptop.DVT;
            userControl._xuatxu = fanlaptop.XuatXu;
            userControl._nhasx = fanlaptop.NhaSX;
            userControl._soluong = fanlaptop.SoLuong;
            userControl._gia = fanlaptop.Gia;

            fpnlProduct.Controls.Add(userControl);
            userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            userControl.picProduct.Image = Image.FromFile(fanlaptop.link_image[1]);
        }
        }

    }
        private void SearchButtonClear()
        {
            string noneText = "";
            fpnlChitiet.Visible = false;
            fpnlProduct.Visible = true;
            fpnlProduct.Controls.Clear();

            List<Mouse> listMouse = Data.Instance.loadDataMouse();
            List<Keyboard> listKeyboard = Data.Instance.loadDataKeyboard();
            List<Monitor> listMonitor = Data.Instance.loadDataMonitor();
            List<fanLaptop> listfanLaptop = Data.Instance.loadDatafanLaptop();
            List<Storage> listStorage = Data.Instance.loadDataStorage();
            List<USB> listUSB = Data.Instance.loadDataUSB();
            foreach (Mouse mouse in listMouse)
            {
                string tensp = mouse.TenSP;
                if (this.NonUnicode(tensp).Contains(this.NonUnicode(noneText)))
                {
                    ucItemMouse userControl = new ucItemMouse(this);
                    userControl.lbName.Text = mouse.TenSP;
                    userControl.lbPrice.Text = giaFix(mouse.Gia);
                    userControl._masp = mouse.MASP;
                    userControl._tensp = mouse.TenSP;
                    userControl._loai = mouse.Loai;
                    userControl._dvt = mouse.DVT;
                    userControl._xuatxu = mouse.XuatXu;
                    userControl._nhasx = mouse.NhaSX;
                    userControl._soluong = mouse.SoLuong;
                    userControl._gia = mouse.Gia;

                    fpnlProduct.Controls.Add(userControl);
                    userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                    userControl.picProduct.Image = Image.FromFile(mouse.link_image[0]);
                }
            }
            foreach (Keyboard keyboard in listKeyboard)
            {
                string tensp = keyboard.TenSP;
                if (this.NonUnicode(tensp).Contains(this.NonUnicode(noneText)))
                {
                    ucItemKeyboard userControl = new ucItemKeyboard(this);
                    //userControl.picProduct.Image = new Bitmap(Application.StartupPath + mouse.link_image[0]);

                    userControl.lbName.Text = keyboard.TenSP;
                    userControl.lbPrice.Text = giaFix(keyboard.Gia);
                    userControl._masp = keyboard.MASP;
                    userControl._tensp = keyboard.TenSP;
                    userControl._loai = keyboard.LoaiSP;
                    userControl._dvt = keyboard.DVT;
                    userControl._xuatxu = keyboard.XuatXu;
                    userControl._nhasx = keyboard.NhaSX;
                    userControl._soluong = keyboard.SoLuong;
                    userControl._gia = keyboard.Gia;

                    fpnlProduct.Controls.Add(userControl);
                    userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                    userControl.picProduct.Image = Image.FromFile(keyboard.link_image[0]);
                }
            }
            foreach (Monitor monitor in listMonitor)
            {
                string tensp = monitor.TenSP;
                if (this.NonUnicode(tensp).Contains(this.NonUnicode(noneText)))
                {
                    ucMonitor userControl = new ucMonitor(this);
                    //userControl.picProduct.Image = new Bitmap(Application.StartupPath + mouse.link_image[0]);

                    userControl.lbName.Text = monitor.TenSP;
                    userControl.lbPrice.Text = giaFix(monitor.Gia);
                    userControl._masp = monitor.MASP;
                    userControl._tensp = monitor.TenSP;
                    userControl._loai = monitor.LoaiSP;
                    userControl._dvt = monitor.DVT;
                    userControl._xuatxu = monitor.XuatXu;
                    userControl._nhasx = monitor.NhaSX;
                    userControl._soluong = monitor.SoLuong;
                    userControl._gia = monitor.Gia;

                    fpnlProduct.Controls.Add(userControl);
                    userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                    userControl.picProduct.Image = Image.FromFile(monitor.link_image[1]);
                }
            }
            foreach (Storage storage in listStorage)
            {
                string tensp = storage.TenSP;
                if (this.NonUnicode(tensp).Contains(this.NonUnicode(noneText)))
                {
                    ucStorage userControl = new ucStorage(this);
                    //userControl.picProduct.Image = new Bitmap(Application.StartupPath + mouse.link_image[0]);

                    userControl.lbName.Text = storage.TenSP;
                    userControl.lbPrice.Text = giaFix(storage.Gia);
                    userControl._masp = storage.MASP;
                    userControl._tensp = storage.TenSP;
                    userControl._loai = storage.LoaiSP;
                    userControl._dvt = storage.DVT;
                    userControl._xuatxu = storage.XuatXu;
                    userControl._nhasx = storage.NhaSX;
                    userControl._soluong = storage.SoLuong;
                    userControl._gia = storage.Gia;

                    fpnlProduct.Controls.Add(userControl);
                    userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                    userControl.picProduct.Image = Image.FromFile(storage.link_image[1]);
                }
            }
            foreach (USB usb in listUSB)
            {
                string tensp = usb.TenSP;
                if (this.NonUnicode(tensp).Contains(this.NonUnicode(noneText)))
                {
                    ucUSB userControl = new ucUSB(this);
                    //userControl.picProduct.Image = new Bitmap(Application.StartupPath + mouse.link_image[0]);

                    userControl.lbName.Text = usb.TenSP;
                    userControl.lbPrice.Text = giaFix(usb.Gia);
                    userControl._masp = usb.MASP;
                    userControl._tensp = usb.TenSP;
                    userControl._loai = usb.LoaiSP;
                    userControl._dvt = usb.DVT;
                    userControl._xuatxu = usb.XuatXu;
                    userControl._nhasx = usb.NhaSX;
                    userControl._soluong = usb.SoLuong;
                    userControl._gia = usb.Gia;

                    fpnlProduct.Controls.Add(userControl);
                    userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                    userControl.picProduct.Image = Image.FromFile(usb.link_image[1]);
                }
            }
            foreach (fanLaptop fanlaptop in listfanLaptop)
            {
                string tensp = fanlaptop.TenSP;
                if (this.NonUnicode(tensp).Contains(this.NonUnicode(noneText)))
                {
                    ucfanLaptop userControl = new ucfanLaptop(this);
                    //userControl.picProduct.Image = new Bitmap(Application.StartupPath + mouse.link_image[0]);

                    userControl.lbName.Text = fanlaptop.TenSP;
                    userControl.lbPrice.Text = giaFix(fanlaptop.Gia);
                    userControl._masp = fanlaptop.MASP;
                    userControl._tensp = fanlaptop.TenSP;
                    userControl._loai = fanlaptop.LoaiSP;
                    userControl._dvt = fanlaptop.DVT;
                    userControl._xuatxu = fanlaptop.XuatXu;
                    userControl._nhasx = fanlaptop.NhaSX;
                    userControl._soluong = fanlaptop.SoLuong;
                    userControl._gia = fanlaptop.Gia;

                    fpnlProduct.Controls.Add(userControl);
                    userControl.picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                    userControl.picProduct.Image = Image.FromFile(fanlaptop.link_image[1]);
                }
            }

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

        private void btn_ThemSp_Click(object sender, EventArgs e)
        {
            Form_AddSanPham add = new Form_AddSanPham();
            add.Show();
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            if(pnlDanhMucLeft.Width== 193)
            {
                btnDanhMuc.Visible = false;
                btnDanhMucMinus.Visible = true;
                pnlDanhMucLeft.Visible = false; 
                pnlDanhMucLeft.Width = 65;
                transDanhmuc.ShowSync(pnlDanhMucLeft);
            }
            else if(pnlDanhMucLeft.Width==65)
            {
                pnlDanhMucLeft.Visible = false;
                btnDanhMuc.Visible = true;
                btnDanhMucMinus.Visible = false;
                pnlDanhMucLeft.Width = 193;
                transDanhmuc.ShowSync(pnlDanhMucLeft);
            }
          
        }

        private void panel2_Scroll(object sender, ScrollEventArgs e)
        {
            
           // MessageBox.Show("ls");
            //pnlMenuAbove.Visible = false;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

      

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                SearchButton();
            }    
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Data.Instance.Setx(this.fpnlChitiet.Size.Width);
            Data.Instance.Sety(this.fpnlChitiet.Size.Height);
        }
    }
}


   

