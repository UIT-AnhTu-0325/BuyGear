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
    public partial class Form_GioHang : Form
    {
        Form_Main parent;
        public Form_GioHang()
        {
            InitializeComponent();
            LoadSanPhamTrongGio();
        }
        public Form_GioHang(Form_Main parent,int type=1)
        {
            this.parent = parent;
            InitializeComponent();
            if (type == 1)
            {
                LoadSanPhamTrongGio();
            }
            else
            {
                pageTab.SetPage(1);
                UnsetPaVisible();
                paDangGiao.Visible = true;
                loadSanPhamDangGiao();
            }
            InitiateFunction();
            LoadInfor();
        }

        private void LoadInfor()
        {
            Infor infor = Account.Instance.loadInfor();
            lblname.Text = infor.Hoten;
            lblsdt.Text = infor.SDT;
            lbldiachi.Text = infor.DiaChi;
        }
        private void LoadSanPhamTrongGio()
        {
            List<ItemInGioHang> listSP_byBtn = Data_gioHang.Instance.loadDataSanPhamTrongGio();
            this.fpnlGioHang.Controls.Clear();
            foreach (ItemInGioHang sp in listSP_byBtn)
            {
                ucSanPhamTrongGio ucSanPham = new ucSanPhamTrongGio(this.parent, this);
                ucSanPham.set(sp.MASP, sp.TenSP, sp.SoLuongTrongGio, sp.Gia, sp.Link_image, sp.IsSelect);

                this.fpnlGioHang.Controls.Add(ucSanPham);
            }
        }
        public void loadSanPhamDangGiao()
        {
            List<ItemInGioHang> listSP_byBtn = Data_gioHang.Instance.loadSanPhamDangGiao("dang giao hang");
            this.fpnlDangGiao.Controls.Clear();
            foreach (ItemInGioHang sp in listSP_byBtn)
            {
                ucSanPhamDangGiao ucSanPham = new ucSanPhamDangGiao(this.parent);
                ucSanPham.SetData(sp.MASP, sp.TenSP, sp.Gia, sp.Link_image);

                this.fpnlDangGiao.Controls.Add(ucSanPham);
            }
        }
        public void LoadSanPhamYeuThich()
        {
            List<ItemInGioHang> listSp = Data_gioHang.Instance.loadSanPhamYeuThichDaXem("yeuthich");
            this.fpnlYeuThich.Controls.Clear();
            foreach(ItemInGioHang sp in listSp)
            {
                ucDaXemYeuThich ucyeuthich = new ucDaXemYeuThich(this.parent,this);
                ucyeuthich.SetData(sp.MASP, sp.TenSP, sp.Gia, sp.Link_image);
                this.fpnlYeuThich.Controls.Add(ucyeuthich);
            }
        }
        
        public void LoadSanPhamDaGiao()
        {
            List<ItemInGioHang> listSP_byBtn = Data_gioHang.Instance.loadSanPhamDangGiao("da giao hang");
            this.fpnlDaMua.Controls.Clear();
            foreach (ItemInGioHang sp in listSP_byBtn)
            {
                ucSanPhamDaGiao ucSanPham = new ucSanPhamDaGiao(this.parent , this);
                ucSanPham.SetData(sp.MASP, sp.TenSP, sp.Gia, sp.Link_image);

                this.fpnlDaMua.Controls.Add(ucSanPham);
            }
        }
        public void LoadSanPhamDaXem()
        {
            List<ItemInGioHang> listSp = Data_gioHang.Instance.loadSanPhamYeuThichDaXem("daxem");
            this.fpnlDaXem.Controls.Clear();
            foreach (ItemInGioHang sp in listSp)
            {
                ucSanPhamdaxem ucdaxem = new ucSanPhamdaxem(this.parent, this);
                ucdaxem.SetData(sp.MASP, sp.TenSP, sp.Gia, sp.Link_image);
                this.fpnlDaXem.Controls.Add(ucdaxem);
            }
        }
        public void AddSanPham(string masp)
        {
            this.parent.AddSanPham(masp);
            pageTab.SetPage(0);
            UnsetPaVisible();
            paTrongGio.Visible = true;
            LoadSanPhamTrongGio();
        }
        private void InitiateFunction()
        {
            lblTongTien.Text = Data.Instance.giaFix(Data_gioHang.Instance.loadSoTien());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblSosanpham.Text = this.parent.btnSoSp.Text;
            this.Size = new Size(this.parent.fpnlChiTiet.Size.Width, this.parent.fpnlChiTiet.Size.Height);
        }


        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            Form_MuaHang frmmuahang = new Form_MuaHang(this.parent)
            {
                TopLevel = false,
                TopMost = true
            };
            this.parent.fpnlChiTiet.Controls.Clear();
            this.parent.fpnlChiTiet.Visible = true;
            this.parent.fpnlProduct.Visible = false;
            this.parent.fpnlChiTiet.Controls.Add(frmmuahang);
            frmmuahang.Show();
        }
        private void UnsetPaVisible()
        {
            paTrongGio.Visible = false;
            paDangGiao.Visible = false;
            paYeuThich.Visible = false;
            paDaMua.Visible = false;
            paDaXem.Visible = false;
        }
        private void lblTrongGio_Click(object sender, EventArgs e)
        {
            pageTab.SetPage(0);
            UnsetPaVisible();
            paTrongGio.Visible = true;

        }

        private void lblDangGiao_Click(object sender, EventArgs e)
        {
            pageTab.SetPage(1);
            UnsetPaVisible();
            paDangGiao.Visible = true;
            loadSanPhamDangGiao();
        }
        private void panelDB6_Paint(object sender, PaintEventArgs e)
        {

        }
        public void lblYeuthich_Click(object sender, EventArgs e)
        {
            YeuThichclick();
        }
        public void YeuThichclick()
        {
            pageTab.SetPage(2);
            UnsetPaVisible();
            paYeuThich.Visible = true;
            LoadSanPhamYeuThich();
        }

        private void lblDaMua_Click(object sender, EventArgs e)
        {
            pageTab.SetPage(3);
            UnsetPaVisible();
            paDaMua.Visible = true;
            LoadSanPhamDaGiao();
        }

        private void lblDaXem_Click(object sender, EventArgs e)
        {
            pageTab.SetPage(4);
            UnsetPaVisible();
            paDaXem.Visible = true;
            LoadSanPhamDaXem();
        }
    }


}
