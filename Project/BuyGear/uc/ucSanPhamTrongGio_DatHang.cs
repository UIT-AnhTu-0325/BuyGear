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
    public partial class ucSanPhamTrongGio_DatHang : UserControl
    {
        public ucSanPhamTrongGio_DatHang()
        {
            InitializeComponent();
        }
        public int _soluong;
        public string _ten;
        public int _gia; 
        public void SetThongTin(int soluong, string ten, int gia)
        {
            this._soluong = soluong;
            this._ten = ten;
            this._gia = gia;

            this.lblSoSanPham.Text = soluong.ToString();
            this.lblName.Text = ten;
            this.lblGia.Text = BuyGear.DAO.Data.Instance.giaFix(gia);
        }
       
    }
}
