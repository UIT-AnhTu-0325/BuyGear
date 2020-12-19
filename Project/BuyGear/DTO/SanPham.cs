using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using BuyGear.DAO;
namespace BuyGear.DTO
{
    public class SanPham
    {
        //Phương Thức
        public SanPham()
        {
            link_image = new List<string>();
        }

        //Phương Thức
        public void setData(string masp, string tensp, string loaisp, string dvt, string xuatxu, string nhasx, Int32 soluong, Int32 gia, string chitiet,
            string thoigian, string trangthaikiemduyet, Int32 ID_ngban, Int32 gia_nhap, Int32 gia_banbuon, Int32 VAT)
        {
            this._masp = masp;
            this._tensp = tensp;
            this._loaisp = loaisp;
            this._dvt = dvt;
            this._xuatxu = xuatxu;
            this._nhasx = nhasx;
            this._soluong = soluong;
            this._gia = gia;
            this._chitiet = chitiet;
            this._thoigiandangban = thoigian;
            this._trangthaikiemduyet = trangthaikiemduyet;
            this._ID_nguoiban = ID_ngban;
            this._gia_nhap = gia_nhap;
            this._gia_banbuon = gia_banbuon;
            this._VAT = VAT;

        }

        //Properties
        public string MASP
        {
            get { return _masp; }
            set { _masp = value; }
        }
        public string TenSP
        {
            get { return _tensp; }
            set { _tensp = value; }
        }
        public string LoaiSP
        {
            get { return _loaisp; }
            set { _loaisp = value; }
        }
        public string DVT
        {
            get { return _dvt; }
            set { _dvt = value; }
        }
        public string XuatXu
        {
            get { return _xuatxu; }
            set { _xuatxu = value; }
        }
        public string NhaSX
        {
            get { return _nhasx; }
            set { _nhasx = value; }
        }
        public Int32 SoLuong
        {
            get { return _soluong; }
            set { _soluong = value; }
        }
        public Int32 Gia
        {
            get { return _gia; }
            set { _gia = value; }
        }
        public List<string> link_image
        {
            get { return _link_image; }
            set { _link_image = value; }
        }
        public string chitiet
        {
            get { return _chitiet; }
            set { _chitiet = value; }
        }
        public Int32 gia_nhap
        {
            get { return _gia_nhap; }
            set { _gia_nhap = value; }
        }
        public Int32 gia_banbuon
        {
            get { return _gia_banbuon; }
            set { _gia_banbuon = value; }
        }
        public Int32 VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }
        public string thoigiandangban
        {
            get { return _thoigiandangban; }
            set { _thoigiandangban = value; }
        }
        public string trangthaikiemduyet
        {
            get { return _trangthaikiemduyet; }
            set { _trangthaikiemduyet = value; }
        }
        public Int32 ID_nguoiban
        {
            get { return _ID_nguoiban; }
            set { _ID_nguoiban = value; }
        }

        //Thuộc Tính
        protected string _masp;
        protected string _tensp;
        protected string _loaisp;
        protected string _dvt;
        protected string _xuatxu;
        protected string _nhasx;
        protected Int32 _soluong;
        protected Int32 _gia;
        protected List<string> _link_image;
        protected string _chitiet;
        protected Int32 _gia_nhap;
        protected Int32 _gia_banbuon;
        protected Int32 _VAT;
        protected string _thoigiandangban;
        protected string _trangthaikiemduyet;
        protected Int32 _ID_nguoiban;

    }
}
