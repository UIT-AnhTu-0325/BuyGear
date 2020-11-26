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
    public partial class Form_SanPham : Form
    {
        Form_Main parent;
        public Form_SanPham(string masp , Form_Main parent)
        {
            this.parent = parent;
            InitializeComponent();
            this._masp = masp;
            // set size
          
            int left = Data.Instance.Getx() - pnlChiTietRight.Size.Width;
          
            //pnlChiTietPicLeft.Size = new Size(200, 200);
            //.Location.X = pnlChiTietPicLeft.Location.X + (int)pnlChiTietPicLeft.Size.Width / 2;
            pnlChiTietRight.Size = new Size(Data.Instance.Getx() * 1 / 2, pnlChiTietRight.Size.Height);
            pnlChiTietPicLeft.Size = new Size(left, left * 7 / 10);

        }
        public Form_SanPham(string masp)
        { 
            this._masp = masp;
            InitializeComponent();
            Load_Form();
        }
        public Form_SanPham()
        { 

        }
        //
        //Các hàm đặc trưng
        //
        private void Load_Form()
        {
            List<string> list_top = new List<string>();
            string sqlQuery = @"select loaisp from SanPham where masp = '" + _masp + "'";
            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);
            if (dataTable.Rows[0] != null)
            {
                DataRow row = dataTable.Rows[0];
                switch (row["loaisp"].ToString())
                {
                    case "BanPhim":
                        {
                            Keyboard sp = new Keyboard();
                            sp.loadData(_masp);
                            // txtNameSP.Text = sp.TenSP;
                            lblTenSanPham.Text = sp.TenSP;

                            // txtNhaSX.Text = sp.NhaSX;
                            lblThuongHieuText.Text = sp.NhaSX;
                            // txtGia.Text = sp.Gia.ToString();
                            lblGia.Text = giaFix(sp.Gia);
                            // txtXuatXu.Text = sp.XuatXu;
                            lblXuatXu.Text = sp.XuatXu;
                            //=====tùy chỉnh thêm.
                            picSanPhamMain.SizeMode = PictureBoxSizeMode.Zoom;
                            picSanPhamMain.Image = Image.FromFile(sp.link_image[0]);
                            picAnh1.SizeMode = PictureBoxSizeMode.Zoom;
                            picAnh1.Image = Image.FromFile(sp.link_image[1]);
                            picAnh2.SizeMode = PictureBoxSizeMode.Zoom;
                            picAnh2.Image = Image.FromFile(sp.link_image[2]);
                            picAnh3.SizeMode = PictureBoxSizeMode.Zoom;
                            picAnh3.Image = Image.FromFile(sp.link_image[3]);
                            break;
                        }
                    case "Chuot":
                        {
                            Mouse sp = new Mouse();
                            sp.loadData(_masp);
                            // txtNameSP.Text = sp.TenSP;
                            lblTenSanPham.Text = sp.TenSP;

                            // txtNhaSX.Text = sp.NhaSX;
                            lblThuongHieuText.Text = sp.NhaSX;
                            // txtGia.Text = sp.Gia.ToString();
                            lblGia.Text = giaFix(sp.Gia);
                            // txtXuatXu.Text = sp.XuatXu;
                            lblXuatXu.Text = sp.XuatXu;
                            //=====tùy chỉnh thêm.
                            picSanPhamMain.SizeMode = PictureBoxSizeMode.Zoom;
                            picSanPhamMain.Image = Image.FromFile(sp.link_image[0]);
                            picAnh1.SizeMode = PictureBoxSizeMode.Zoom;
                            picAnh1.Image = Image.FromFile(sp.link_image[1]);
                            picAnh2.SizeMode = PictureBoxSizeMode.Zoom;
                            picAnh2.Image = Image.FromFile(sp.link_image[2]);
                            picAnh3.SizeMode = PictureBoxSizeMode.Zoom;
                            picAnh3.Image = Image.FromFile(sp.link_image[3]);
                            break;
                        }
                    case "ManHinh":
                        {
                            Monitor sp = new Monitor();
                            sp.loadData(_masp);
                            // txtNameSP.Text = sp.TenSP;
                            lblTenSanPham.Text = sp.TenSP;

                            // txtNhaSX.Text = sp.NhaSX;
                            lblThuongHieuText.Text = sp.NhaSX;
                            // txtGia.Text = sp.Gia.ToString();
                            lblGia.Text = giaFix(sp.Gia);
                            // txtXuatXu.Text = sp.XuatXu;
                            lblXuatXu.Text = sp.XuatXu;
                            //=====tùy chỉnh thêm.
                            picSanPhamMain.SizeMode = PictureBoxSizeMode.Zoom;
                            picSanPhamMain.Image = Image.FromFile(sp.link_image[0]);
                            picAnh1.SizeMode = PictureBoxSizeMode.Zoom;
                            picAnh1.Image = Image.FromFile(sp.link_image[1]);
                            picAnh2.SizeMode = PictureBoxSizeMode.Zoom;
                            picAnh2.Image = Image.FromFile(sp.link_image[2]);
                            picAnh3.SizeMode = PictureBoxSizeMode.Zoom;
                            picAnh3.Image = Image.FromFile(sp.link_image[3]);
                            break;
                        }
                    case "oCung":
                        {
                            Storage sp = new Storage();
                            sp.loadData(_masp);
                            // txtNameSP.Text = sp.TenSP;
                            lblTenSanPham.Text = sp.TenSP;

                            // txtNhaSX.Text = sp.NhaSX;
                            lblThuongHieuText.Text = sp.NhaSX;
                            // txtGia.Text = sp.Gia.ToString();
                            lblGia.Text = giaFix(sp.Gia);
                            // txtXuatXu.Text = sp.XuatXu;
                            lblXuatXu.Text = sp.XuatXu;
                            //=====tùy chỉnh thêm.
                            picSanPhamMain.SizeMode = PictureBoxSizeMode.Zoom;
                            picSanPhamMain.Image = Image.FromFile(sp.link_image[0]);
                            picAnh1.SizeMode = PictureBoxSizeMode.Zoom;
                            picAnh1.Image = Image.FromFile(sp.link_image[1]);
                            picAnh2.SizeMode = PictureBoxSizeMode.Zoom;
                            picAnh2.Image = Image.FromFile(sp.link_image[2]);
                            picAnh3.SizeMode = PictureBoxSizeMode.Zoom;
                            picAnh3.Image = Image.FromFile(sp.link_image[3]);
                            break;
                        }
                    case "TanNhiet":
                        {
                            fanLaptop sp = new fanLaptop();
                            sp.loadData(_masp);
                            // txtNameSP.Text = sp.TenSP;
                            lblTenSanPham.Text = sp.TenSP;

                            // txtNhaSX.Text = sp.NhaSX;
                            lblThuongHieuText.Text = sp.NhaSX;
                            // txtGia.Text = sp.Gia.ToString();
                            lblGia.Text = giaFix(sp.Gia);
                            // txtXuatXu.Text = sp.XuatXu;
                            lblXuatXu.Text = sp.XuatXu;
                            //=====tùy chỉnh thêm.
                            picSanPhamMain.SizeMode = PictureBoxSizeMode.Zoom;
                            picSanPhamMain.Image = Image.FromFile(sp.link_image[0]);
                            picAnh1.SizeMode = PictureBoxSizeMode.Zoom;
                            picAnh1.Image = Image.FromFile(sp.link_image[1]);
                            picAnh2.SizeMode = PictureBoxSizeMode.Zoom;
                            picAnh2.Image = Image.FromFile(sp.link_image[2]);
                            picAnh3.SizeMode = PictureBoxSizeMode.Zoom;
                            picAnh3.Image = Image.FromFile(sp.link_image[3]);
                            break;
                        }
                    case "USB":
                        {
                            USB sp = new USB();
                            sp.loadData(_masp);
                            // txtNameSP.Text = sp.TenSP;
                            lblTenSanPham.Text = sp.TenSP;

                            // txtNhaSX.Text = sp.NhaSX;
                            lblThuongHieuText.Text = sp.NhaSX;
                            // txtGia.Text = sp.Gia.ToString();
                            lblGia.Text = giaFix(sp.Gia);
                            // txtXuatXu.Text = sp.XuatXu;
                            lblXuatXu.Text = sp.XuatXu;
                            //=====tùy chỉnh thêm.
                            picSanPhamMain.SizeMode = PictureBoxSizeMode.Zoom;
                            picSanPhamMain.Image = Image.FromFile(sp.link_image[0]);
                            picAnh1.SizeMode = PictureBoxSizeMode.Zoom;
                            picAnh1.Image = Image.FromFile(sp.link_image[1]);
                            picAnh2.SizeMode = PictureBoxSizeMode.Zoom;
                            picAnh2.Image = Image.FromFile(sp.link_image[2]);
                            picAnh3.SizeMode = PictureBoxSizeMode.Zoom;
                            picAnh3.Image = Image.FromFile(sp.link_image[3]);
                            break;
                        }
                    default:
                        break;
                }
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
        //
        //Các envent của control
        //
        private void Form_SanPham_Load(object sender, EventArgs e)
        {
            this.Load_Form();
        }

        private void btnReturn_main_Click(object sender, EventArgs e)
        {
            this.parent.fpnlChitiet.Visible = false;
            this.parent.fpnlProduct.Visible = true;
            this.Close();
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
    }
}
