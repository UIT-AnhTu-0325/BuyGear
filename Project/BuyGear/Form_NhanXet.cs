using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuyGear.DTO;
using BuyGear.DAO;

namespace BuyGear
{
    public partial class Form_NhanXet : Form
    {
        Form_Main parent;ucSanPhamDaGiao ucparent;
        string masp;
        public Form_NhanXet(Form_Main parent, string masp, ucSanPhamDaGiao ucparent)
        {
            InitializeComponent();
            this.parent = parent;
            this.ucparent = ucparent;
            this.masp = masp;
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuiNhanXet_Click(object sender, EventArgs e)
        {
            if(btnRatingSelect.Value==0)
            {   
                MessageBox.Show("Vui lòng đánh giá sản phẩm trước !!");
                return;
            }
            if(txtNhanXetChiTiet.Text.Length<10)
            {
                MessageBox.Show("Nhập nhận xét hơn 10 kí tự");
                return;
            }    
            NhanXet nx = new NhanXet(btnRatingSelect.Value, txtNhanXetChinh.Text, txtNhanXetChiTiet.Text);
            Data_NhanXet.Instance.upNhanXet(nx,masp );
            pnlComplete.Visible = true;
            pnlNhanXet.Visible = false;
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.parent.fpnlChiTiet.BringToFront();
            this.parent.fpnlChiTiet1.Controls.Clear();
            this.ucparent.btnNhanXet1.Visible = false;
        }

        private void lblTroVe_Click(object sender, EventArgs e)
        {
            this.parent.fpnlChiTiet.BringToFront();
            this.parent.fpnlChiTiet1.Controls.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Size = new Size(this.parent.fpnlChiTiet1.Size.Width-15, this.parent.fpnlChiTiet1.Size.Height-15);
        }
    }
}
