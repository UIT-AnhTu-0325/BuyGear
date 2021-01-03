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
    public partial class ucThongBaoDonHang : UserControl
    {
        Form_Infor parent;
        public ucThongBaoDonHang(ItemThongBao thongbao, Form_Infor parent)
        {
            InitializeComponent();
            this.parent = parent;
            _masp = thongbao.Masp;
            _mahd = thongbao.Madh;
            if(thongbao.Checknew==1)
            {
                picNew.Visible = false;
            }
            this.lblTime.Text = thongbao.ThoiGian.ToString("dd/MM/yyyy");
            if(thongbao.TrangThai=="dang giao hang")
            {
                lblTitle.Text = "Đơn hàng #" + thongbao.Madh + " đang được giao đến bạn, " +
                    "chuẩn bị số tiền " + Data.Instance.giaFix(thongbao.Tien)+" để thanh toán";
                picTrangThai.Image = BuyGear.Properties.Resources.B_danggiao;
            }
            else
            {
                lblTitle.Text = "Đơn hàng #" + thongbao.Madh + " đã hoàn tất giao đến bạn, " +
                     "tổng giá trị đơn hàng " + Data.Instance.giaFix(thongbao.Tien);
                picTrangThai.Image = BuyGear.Properties.Resources.B_dagiao;
            }

        }
        private string _masp, _mahd;

        private void lblXemChiTiet_Click(object sender, EventArgs e)
        {
            HoaDon hd = Data.Instance.getHoaDon(_masp, _mahd);
            Invoice i = new Invoice(hd);
            i.PrintMe();
        }

        private void lblXoa_Click(object sender, EventArgs e)
        {
            Data.Instance.DeleteItemThongBao(_mahd, _masp);
            this.parent.btnThongBao.PerformClick();
        }
    }
}
