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
    public partial class ucNhanXet : UserControl
    {
        Form_SanPham parent;
        public ucNhanXet(Form_SanPham parent, string name, int vote, string danhGiaChinh, string danhGiaChiTiet,
                List<byte[]> link_image)
        {
            InitializeComponent();
            this.parent = parent;
            lblName.Text=name;
            rating.Value = vote;
            lblDanhGia.Text = danhGiaChinh;
            lblDanhGiaChiTiet.Text = danhGiaChiTiet;
            //hinh de sau
        }

    }
}
