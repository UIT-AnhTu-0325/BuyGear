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
    public partial class ucDaXemYeuThich : UserControl
    {
        Form_Main parent;Form_GioHang parentGioHang;
        public ucDaXemYeuThich(Form_Main parent, Form_GioHang parentGiohang)
        {
            this.parentGioHang = parentGiohang;
            this.parent = parent;
            InitializeComponent();            
        }
        public string _masp;
        public void SetData(string masp, string tensp, int gia, List<string> link_image)
        {
            this.lblName.Text = tensp;
            this.lblGia.Text = Data.Instance.giaFix(gia);
            _masp = masp;
             this.picHinhAnh.Image = Picture.LoadImage_by_ID(link_image[0]);
        }
        public void dClick(object sender, EventArgs e)
        {

            Form_SanPham frmspx = new Form_SanPham(_masp, this.parent) { TopLevel = false, TopMost = true };
            this.parent.fpnlChiTiet.Controls.Clear();
            this.parent.fpnlChiTiet.Controls.Add(frmspx);
            this.parent.pnlChiTietChange.Visible = true;
            this.parent.fpnlProduct.Visible = false;
            this.parent.fpnlChiTiet.Visible = true;


            frmspx.Show();

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Data_gioHang.Instance.DeleteFromYeuThich(_masp);
            this.parentGioHang.LoadSanPhamYeuThich();
        }

        private void btnThemVaoGio_Click(object sender, EventArgs e)
        {
            this.parentGioHang.AddSanPham(_masp);
        }
    }
}
