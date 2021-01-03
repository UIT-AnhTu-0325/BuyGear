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
using BuyGear.DTO;

namespace BuyGear
{
    public partial class ucTabSanPham : UserControl
    {
        Form_Main parent;
        public ucTabSanPham(Form_Main parent, string title,string type)
        {
            InitializeComponent();  
            this.parent = parent;
            loadTopTrading(type);
            Color[] col = new Color[6];
            col[0] = Color.FromArgb(255, 87, 51);
            col[1] = Color.FromArgb(46, 204, 113);
            col[2] = Color.FromArgb(136, 78, 160);
            col[3] = Color.FromArgb(36, 113, 163);
            col[4] = Color.FromArgb(231, 76, 60);
            col[5] = Color.FromArgb(203, 67, 53);  
            Random rand = new Random();
            int x = rand.Next(0, 4);
            pnlTotal.GradientBottomLeft = col[3];
            pnlTotal.GradientTopLeft = col[3];
            lblTitle.Text = title;
        }
        private void loadTopTrading(string type)
        {
            List<SanPham> listSP_byBtn = Data.Instance.loadSanPhamMain(type);
            foreach (SanPham sp in listSP_byBtn)
            {
                ucSanPham userControl = new ucSanPham(this.parent);
                userControl.set(sp.MASP, sp.TenSP, sp.LoaiSP, sp.DVT, sp.XuatXu,
                sp.NhaSX, sp.SoLuong, sp.Gia, Data.Instance.giaFix(sp.Gia), sp.link_image);
                fpnlSanPhamBanChay.Controls.Add(userControl);
            }
        }
        
    }
}
