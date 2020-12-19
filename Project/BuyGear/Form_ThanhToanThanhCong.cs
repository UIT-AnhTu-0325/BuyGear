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
    public partial class Form_ThanhToanThanhCong : Form
    {
        Form_Main parent;
        public Form_ThanhToanThanhCong( Form_Main parent)
        {
            this.parent = parent;
            InitializeComponent();
        }
        public Form_ThanhToanThanhCong()
        {
            InitializeComponent();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            this.parent.CheckSearch(0);
            this.parent.fpnlChiTiet.Visible = false;
            this.parent.fpnlProduct.Visible = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Size = new Size(this.parent.fpnlChiTiet.Size.Width, this.parent.fpnlChiTiet.Size.Height);        
            this.pnlLeft.Size = new Size((this.Size.Width - this.pnlLeftMadonhang.Size.Width- this.pnlThanks.Width) *1/2, this.pnlLeft.Size.Height);
        }
    }
}
