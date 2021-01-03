using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuyGear.DTO;
using BuyGear.uc;
using BuyGear.DAO;

namespace BuyGear
{
    public partial class ucNhanXet : UserControl
    {
        Form_SanPham parent;
        public ucNhanXet(Form_SanPham parent,string id,  string name, int vote, string danhGiaChinh, string danhGiaChiTiet,
                List<string> link_image)
        {
            InitializeComponent();
            this.parent = parent;
            lblName.Text=name;
            rating.Value = vote;
            lblDanhGia.Text = danhGiaChinh;
            lblDanhGiaChiTiet.Text = danhGiaChiTiet;
            string idAvar = Data.Instance.loadImageAvarFromID(id);
            if (idAvar != "")
                picAnhDaiDien.Image = Picture.LoadImage_by_ID(idAvar);
            switch (link_image.Count)
            {
                case 0:
                    this.Size = new Size(1231, 237);
                    break;
                case 1:
                    pic1.Visible = true;
                    pic1.Image = Picture.LoadImage_by_ID(link_image[0]);
                    break;
                case 2:
                    pic1.Visible = true;
                    pic1.Image = Picture.LoadImage_by_ID(link_image[0]);
                    pic2.Visible = true;
                    pic2.Image = Picture.LoadImage_by_ID(link_image[1]);
                    break;
                case 3:
                    pic1.Visible = true;
                    pic1.Image = Picture.LoadImage_by_ID(link_image[0]);
                    pic2.Visible = true;
                    pic2.Image = Picture.LoadImage_by_ID(link_image[1]);
                    pic3.Visible = true;
                    pic3.Image = Picture.LoadImage_by_ID(link_image[2]);
                    break;
                case 4:
                    pic1.Visible = true;
                    pic1.Image = Picture.LoadImage_by_ID(link_image[0]);
                    pic2.Visible = true;
                    pic2.Image = Picture.LoadImage_by_ID(link_image[1]);
                    pic3.Visible = true;
                    pic3.Image = Picture.LoadImage_by_ID(link_image[2]);
                    pic4.Visible = true;
                    pic4.Image = Picture.LoadImage_by_ID(link_image[3]);
                    break;
                case 5:
                    pic1.Visible = true;
                    pic1.Image = Picture.LoadImage_by_ID(link_image[0]);
                    pic2.Visible = true;
                    pic2.Image = Picture.LoadImage_by_ID(link_image[1]);
                    pic3.Visible = true;
                    pic3.Image = Picture.LoadImage_by_ID(link_image[2]);
                    pic4.Visible = true;
                    pic4.Image = Picture.LoadImage_by_ID(link_image[3]);
                    pic5.Visible = true;
                    pic5.Image = Picture.LoadImage_by_ID(link_image[4]);
                    break;
            }
            //hinh de sau
        }

    }
}
