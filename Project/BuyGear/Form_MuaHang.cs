using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuyGear.DAO;
using BuyGear.DTO;

namespace BuyGear
{
    public partial class Form_MuaHang : Form
    {
        Form_Main parent;
        public Form_MuaHang()
        {
            InitializeComponent();
            loadSanPham();
        }
        public Form_MuaHang(Form_Main parent)
        {
            this.parent = parent;
            InitializeComponent();
            loadSanPham();
            InitiateFunction();
        }
        private void loadSanPham()
        {
            List<ItemInGioHang> listSP_byBtn = Data_gioHang.Instance.loadDataSanPhamTrongGioNoPic();
            foreach (ItemInGioHang sp in listSP_byBtn)
            {
                ucSanPhamTrongGio_DatHang ucSanPham = new ucSanPhamTrongGio_DatHang();
                ucSanPham.SetThongTin(sp.SoLuongTrongGio, sp.TenSP, sp.Gia);
                this.fpnlMatHang.Controls.Add(ucSanPham);
            }
            Infor infor = Account.Instance.loadInfor();
            lblTenInDiaChi.Text = infor.Hoten;
            lblSDT.Text = infor.SDT;
            lblDiaChi.Text = infor.DiaChi;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Size = new Size(this.parent.fpnlChiTiet.Size.Width, this.parent.fpnlChiTiet.Size.Height);

            //426, 366    form size: 1096, 650
            if (this.Size.Width > 426 * 2)
            {
                this.pnlRightDatMua.Size = new Size(this.Size.Width * 2 / 5, this.pnlRightDatMua.Size.Height);
            }
            else
            {
                this.pnlRightDatMua.Size = new Size(426, this.pnlRightDatMua.Size.Height);

            }
        }
        private void InitiateFunction()
        {
            lblTongTien.Text = Data.Instance.giaFix(Data_gioHang.Instance.loadSoTien());
        }
        private void btnDatMua_Click(object sender, EventArgs e)
        {
            Data_gioHang.Instance.MakeInvoice_HoaDon(Data_gioHang.Instance.loadSoTien(), lblDiaChi.Text);
            List<ItemInGioHang> listItem = new List<ItemInGioHang>();
            listItem = Data_gioHang.Instance.loadDataSanPhamTrongGioNoPic();
            foreach (ItemInGioHang item in listItem)
            {
                Data_gioHang.Instance.MakeInvoice_cthd(item.MASP, item.SoLuongTrongGio);
                // Data_gioHang.Instance.Insert_dangGiao(Account.Instance.id,item.MASP);
            }
            //ui function
            Form_ThanhToanThanhCong frm = new Form_ThanhToanThanhCong(this.parent)
            { TopMost = true, TopLevel = false };
            this.parent.fpnlChiTiet.Controls.Clear();
            this.parent.fpnlChiTiet.Controls.Add(frm);
            frm.Show();
            Data_gioHang.Instance.DeleteFromGioHang();
            this.parent.ThongTinGioHang();
        }

        private void ckbPhuongThuc1_Click(object sender, EventArgs e)
        {
            if (!ckbPhuongThuc1.Checked)
            {
                ckbPhuongThuc1.Checked = true;
            }
            if (ckbPhuongThuc2.Checked)
                ckbPhuongThuc2.Checked = false;
        }

        private void ckbPhuongThuc2_Click(object sender, EventArgs e)
        {
            if (!ckbPhuongThuc2.Checked)
            {
                ckbPhuongThuc2.Checked = true;
            }
            if (ckbPhuongThuc1.Checked)
                ckbPhuongThuc1.Checked = false;
        }

        private void btnThayDoiDiaChi_Click(object sender, EventArgs e)
        {
            lblDiaChi.Visible = false;
            txtDiaChi.Visible = true;
            btnThayDoiDiaChi.Visible = false;
            btnOk.Visible = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            lblDiaChi.Visible = true;
            lblDiaChi.Text = txtDiaChi.Text;
            txtDiaChi.Visible = false;
            btnThayDoiDiaChi.Visible = true;
            btnOk.Visible = false;
        }
    }

}
