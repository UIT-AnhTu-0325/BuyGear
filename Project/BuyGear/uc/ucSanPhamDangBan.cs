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
using BuyGear.DAO;

namespace BuyGear
{
    public partial class ucSanPhamDangBan : UserControl
    {
        SanPham _sp;
        Form_BanHang _par;
        public ucSanPhamDangBan(SanPham sp,Form_BanHang par)
        {
            this._sp = sp;
            _par = par;
            InitializeComponent();
            this.set();
        }
        void set()
        {
            picHinhAnh.Image = Images.BinaryToImage(_sp.link_image[0]);
            lblName.Text = _sp.TenSP;
            lblSoluongConLai.Text = "Số lượng còn lại: "+_sp.SoLuong.ToString();
            lblSoLuongDaBan.Text = "Số lượng đã bán: "+Data.Instance.countSoLuongDaBan(_sp.MASP).ToString();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Form_AddSanPham frm = new Form_AddSanPham(_sp,_par)
            {
                TopMost = true,
                TopLevel = false
            };
            _par.callForm_Sua(frm);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Data.Instance.DeleteSanPham(_sp);
            MessageBox.Show("Xóa thành công!");
            _par.LoadDS();
        }
    }
}
