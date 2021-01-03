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
            rateMain.Value = Data_NhanXet.Instance.Rate(masp);
            lblDanhGia.Text = "( " + Data_NhanXet.Instance.countRate(masp).ToString() + " đánh giá )";
            lblTenSanPham.Text = Data_NhanXet.Instance.Name(masp);
            picSanPham.Image = Picture.LoadImage_by_ID(Data_NhanXet.Instance.IDAnh(masp));
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
            Data_NhanXet.Instance.upNhanXet_anh(masp, linkPictureCmt);
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
        private int index = 1;
        List<string> linkPictureCmt = new List<string>();

        private void btnUpHinh_Click(object sender, EventArgs e)
        {
            string link = Picture.getLinkFromDialog();
            if (link == "") 
            {
                return;
            }
            try
            {
                switch(index)
                {
                    case 1:
                        pic1.Visible = true;
                        pic1.Image = Picture.FromFile(link);
                        index++;
                        break;
                    case 2:
                        pic2.Visible = true;
                        pic2.Image = Picture.FromFile(link);
                        index++;
                        break;
                    case 3:
                        pic3.Visible = true;
                        pic3.Image = Picture.FromFile(link);
                        index++;
                        break;
                    case 4:
                        pic4.Visible = true;
                        pic4.Image= Picture.FromFile(link);
                        index++;
                        break;
                    case 5:
                        pic5.Visible = true;
                        pic5.Image= Picture.FromFile(link);
                        index++;
                        break;
                }
                linkPictureCmt.Add(link);
                btnGuiNhanXet.Location = new Point(94, 623);

            }
            catch
            {
                MessageBox.Show("loi");
            }
        }

        private void pnlComplete_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
