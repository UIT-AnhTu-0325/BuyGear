using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuyGear.DAO;

namespace BuyGear
{
    public partial class ucSanPham : UserControl
    {
        Form_Main parent;
        public ucSanPham(Form_Main parent)
        {
            this.parent = parent;
            InitializeComponent();
        }
        public void set(string masp, string tensp, string loaisp, string dvt, string xuatxu, string nhasx, int soluong, int gia, string giafix, List<string> link_image)
        {
            _masp = masp;
            _tensp = tensp;
            _loaisp = loaisp;
            _dvt = dvt;
            _xuatxu = xuatxu;
            _nhasx = nhasx;
            _soluong = soluong;
            _gia = gia;
            this.lbName.Text = tensp;
            this.lbPrice.Text = giafix;
            this._link_image = link_image;
            this.picProduct.Image = Picture.LoadImage_by_ID(link_image[0]);
        }
        private void picProduct_Click(object sender, EventArgs e)
        {
            Form_SanPham frmspx = new Form_SanPham(_masp, this.parent) { TopLevel = false, TopMost = true };
            this.parent.fpnlChiTiet.Controls.Clear();
            this.parent.fpnlChiTiet.Controls.Add(frmspx);
            this.parent.fpnlProduct.Visible = false;
            this.parent.fpnlChiTiet.Visible = true;
            this.parent.fpnlChiTiet.BringToFront();
            this.parent.pnlChiTietChange.Visible = true;
            Data_gioHang.Instance.AddDaXem(_masp);
            frmspx.Show();
        }
        public string _masp;
        public string _tensp;
        public string _loaisp;
        public string _dvt;
        public string _xuatxu;
        public string _nhasx;
        public Int32 _soluong;
        public Int32 _gia;
        public List<string> _link_image;

        private void btn_AddSanPham(object sender, EventArgs e)
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
    }
}
