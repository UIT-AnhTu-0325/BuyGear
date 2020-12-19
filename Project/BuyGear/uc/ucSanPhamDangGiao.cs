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
    public partial class ucSanPhamDangGiao : UserControl
    {
        Form_Main parent;
        public ucSanPhamDangGiao(Form_Main parent)
        {
            this.parent = parent;
            InitializeComponent();
        }
        public string _masp;
        public void SetData(string masp, string tensp , int gia, List<byte[]> link_image)
        {
            this.lblName.Text = tensp;
            this.lblGia.Text = Data.Instance.giaFix(gia);
            _masp = masp;
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
    }
}
