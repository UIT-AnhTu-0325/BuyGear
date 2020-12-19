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
    public partial class ucSanPhamDaGiao : UserControl
    {
        Form_Main parent;  Form_GioHang parentGiohang;
        public ucSanPhamDaGiao(Form_Main parent, Form_GioHang parentGioHang)
        {
            this.parent = parent;
            InitializeComponent();
            this.parentGiohang = parentGioHang;
        }
        public string _masp;
        public void SetData(string masp, string tensp, int gia, List<byte[]> link_image)
        {
            this.lblName.Text = tensp;
            this.lblGia.Text = Data.Instance.giaFix(gia);
            _masp = masp;
            if (Data_gioHang.Instance.CheckComment(masp))
                btnNhanXet1.Visible = false;
            
            this.picHinhAnh.Image = (Images.BinaryToImage(link_image[0]));
        }
        public void Click(object sender, EventArgs e)
        {

            Form_SanPham frmspx = new Form_SanPham(_masp, this.parent) { TopLevel = false, TopMost = true };
            this.parent.fpnlChiTiet.Controls.Clear();
            this.parent.fpnlChiTiet.Controls.Add(frmspx);
            this.parent.fpnlProduct.Visible = false;
            this.parent.fpnlChiTiet.Visible = true;
            frmspx.Show();
        }

        private void btnNhanxet(object sender, EventArgs e)
        {
            this.parent.fpnlChiTiet1.Visible = true;
            this.parent.fpnlChiTiet1.BringToFront();
            Form_NhanXet frm = new Form_NhanXet(this.parent, _masp,this)
            {
                TopLevel = false,
                TopMost = true
            };
            this.parent.fpnlChiTiet1.Controls.Add(frm);
            frm.Show();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.parentGiohang.AddSanPham(_masp);
        }
    }
}
