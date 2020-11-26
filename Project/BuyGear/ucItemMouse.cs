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
    public partial class ucItemMouse : UserControl
    {
        Form_Main parent;
        public ucItemMouse(Form_Main parent)
        {
            this.parent = parent;
            InitializeComponent();
            Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000;
            timer1.Tick += new System.EventHandler(timer1_Tick);
            timer1.Start();
            

          
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //frmspx.Size = new Size(Data.Instance.Getx(), 500);
            
        }
        public ucItemMouse()
        {
            InitializeComponent();

           // frmspx = new Form_SanPham(_masp, this.parent) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
           
        }
        public Int32 _DPI;
        public string _loai;
        public string _masp;
        public string _tensp;
        public string _loaisp;
        public string _dvt;
        public string _xuatxu;
        public string _nhasx;
        public  Int32 _soluong;
        public Int32 _gia;
        public List<string> _link_image;
        Form_SanPham frmspx;


        private void picProduct_Click(object sender, EventArgs e)
        {


            frmspx = new Form_SanPham(_masp, this.parent) { TopLevel = false, TopMost = true };
            frmspx.Size = new Size(Data.Instance.Getx(), Data.Instance.Gety());

            this.parent.fpnlChitiet.Controls.Clear();
            this.parent.fpnlChitiet.Controls.Add(frmspx);
            this.parent.fpnlProduct.Visible = false;
            this.parent.fpnlChitiet.Visible = true;
            //frmspx.Size = new Size(Data.Instance.Getx(), Data.Instance.Gety());
            this.frmspx.Show();
        }
    }
}
