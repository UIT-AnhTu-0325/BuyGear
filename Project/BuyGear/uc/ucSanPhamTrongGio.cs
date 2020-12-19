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

namespace BuyGear
{
    public partial class ucSanPhamTrongGio : UserControl
    {
        Form_Main parent;
        Form_GioHang parentgh;
        public ucSanPhamTrongGio()
        {
            InitializeComponent();
        }
        public ucSanPhamTrongGio(Form_Main parent, Form_GioHang parentgh)
        {
            this.parent = parent;
            this.parentgh = parentgh;
            InitializeComponent();
        }
        public string _masp;
        public string _tensp;        
        public Int32 _gia;
        public Int32 _soluongtronggio;
        public bool _isSelect;
        public List<byte[]> _link_image;

        public void set(string masp, string tensp,  int soluong, int gia,  List<byte[]> link_image, bool isSelect)
        {
            _masp = masp;
            _tensp = tensp;          
            _soluongtronggio = soluong;
            _gia = gia;
            _isSelect = isSelect;

            this.lblSoSanPham.Text = _soluongtronggio.ToString();
            this.chkAdd.Checked = isSelect;
            this.lblName.Text = tensp;
            this.lblGia.Text = Data.Instance.giaFix(gia);
            this._link_image = link_image;
            this.picHinhAnh.Image = (Images.BinaryToImage(link_image[0]));
        }
        private void picProduct_Click(object sender, EventArgs e)
        {

            Form_SanPham frmspx = new Form_SanPham(_masp, this.parent) { TopLevel = false, TopMost = true };
            this.parent.fpnlChiTiet.Controls.Clear();
            this.parent.fpnlChiTiet.Controls.Add(frmspx);
            this.parent.fpnlProduct.Visible = false;
            this.parent.fpnlChiTiet.Visible = true;
            

            frmspx.Show();
        }

        private void chkAdd_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            Data_gioHang.Instance.UpdateSelect(chkAdd.Checked, _masp);
            this.parentgh.lblTongTien.Text = Data.Instance.giaFix(Data_gioHang.Instance.loadSoTien());
            this.parent.ThongTinGioHang();
        }
        private void InitiateFunction()
        {
            lblSoSanPham.Text = Data_gioHang.Instance.SoluongSanPham(0, _masp).ToString();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            lblSoSanPham.Text = Data_gioHang.Instance.SoluongSanPham(1, _masp).ToString();
            this.parentgh.lblTongTien.Text = Data.Instance.giaFix(Data_gioHang.Instance.loadSoTien());
            this.parent.ThongTinGioHang();

        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            this.parentgh.lblTongTien.Text = Data.Instance.giaFix(Data_gioHang.Instance.loadSoTien());
            lblSoSanPham.Text = Data_gioHang.Instance.SoluongSanPham(-1, _masp).ToString();
            this.parent.ThongTinGioHang();
        }

        private void lblXoaKhoiGio_Click(object sender, EventArgs e)
        {
            Data_gioHang.Instance.DeleteFromGioHang(_masp, Account.Instance.id);

            this.parent.btnGioHang_click(sender, e);
            this.parent.ThongTinGioHang();
        }

        private void lblThemYeuThich_Click(object sender, EventArgs e)
        {
            Data_gioHang.Instance.AddYeuthich(_masp);
            Data_gioHang.Instance.DeleteFromGioHang(_masp, Account.Instance.id);
            this.parent.btnGioHang_click(sender, e);
            this.parent.ThongTinGioHang();
        }
    }
}
