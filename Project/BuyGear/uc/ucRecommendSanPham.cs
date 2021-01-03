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
    public partial class ucRecommendSanPham : UserControl
    {
        Form_Main parent;
        public ucRecommendSanPham()
        {
            InitializeComponent();
        }
        public ucRecommendSanPham(Form_Main parent, string masp, string name, string price
            , List<string> link_image )
        {
            InitializeComponent();
            this.parent = parent;
            _masp = masp;
            this.lbName.Text = name;
            this.lbPrice.Text = price;
            picProduct.Image = Picture.LoadImage_by_ID(link_image[0]);

        }
        protected string _masp;

        private void picProduct_Click(object sender, EventArgs e)
        {
            Form_SanPham frmspx = new Form_SanPham(_masp, this.parent)
            { TopLevel = false, TopMost = true };
            this.parent.fpnlChiTiet.Controls.Clear();
            this.parent.fpnlChiTiet.Controls.Add(frmspx);
            this.parent.fpnlProduct.Visible = false;
            this.parent.fpnlChiTiet.Visible = true;
            this.parent.fpnlChiTiet.BringToFront();
            this.parent.pnlChiTietChange.Visible = true;
            Data_gioHang.Instance.AddDaXem(_masp);
            frmspx.Show();
        }
    }
}
