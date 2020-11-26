using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuyGear
{
    public partial class ucfanLaptop : UserControl
    {
        Form_Main parent;
        public ucfanLaptop(Form_Main parent)
        {
            this.parent = parent;
            InitializeComponent();
        }
        public ucfanLaptop()
        {
            InitializeComponent();
        }

       
        public string _loai;
        public string _masp;
        public string _tensp;
        public string _loaisp;
        public string _dvt;
        public string _xuatxu;
        public string _nhasx;
        public Int32 _soluong;
        public Int32 _gia;
        public List<string> _link_image;

        private void picProduct_Click(object sender, EventArgs e)
        {

            Form_SanPham frmspx = new Form_SanPham(_masp, this.parent) {  TopLevel = false, TopMost = true };
            this.parent.fpnlChitiet.Controls.Clear();
            this.parent.fpnlChitiet.Controls.Add(frmspx);
            this.parent.fpnlProduct.Visible = false;
            this.parent.fpnlChitiet.Visible = true;

            frmspx.Show();
        }
    }
}
