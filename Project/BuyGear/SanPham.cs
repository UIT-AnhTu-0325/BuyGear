using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace BuyGear
{
    public abstract class SanPham
    {
        public SanPham()
        {
            link_image = new List<string>(0);
        }
        //protected string _masp;
        //protected string _tensp;
        //protected string _loaisp;
        //protected string _dvt;
        //protected string _xuatxu;
        //protected string _nhasx;
        //protected Int32 _soluong;
        //protected Int32 _gia;
        //protected List<string> _link_image;
        public void SetData(string masp , string tensp, string loaisp , string dvt, string xuatxu, string nhasx, int soluong, int gia)
        {
            //this._masp = data["masp"].ToString();
            //this._tensp = data["tensp"].ToString();
            //this._loaisp = data["loaisp"].ToString();
            //this._dvt = data["dvt"].ToString();
            //this._xuatxu = data["xuatxu"].ToString();
            //this._nhasx = data["nhasx"].ToString();
            //this._soluong = Int32.Parse(data["soluong"].ToString());
            //this._gia = Int32.Parse(data["gia"].ToString());
            this._masp = masp;
            this._tensp = tensp;
            this._loaisp = loaisp;
            this._dvt = dvt;
            this._xuatxu = xuatxu;
            this._nhasx = nhasx;
            this._soluong = soluong;
            this._gia = gia;
        }
        //Phương Thức
        public abstract void loadData(string masp);
        public abstract void writeData();
        public void setData(string tensp, string dvt, string xuatxu,string nhasx,Int32 soluong, Int32 gia)
        {
            this._tensp = tensp;
            this._dvt = dvt;
            this._xuatxu = xuatxu;
            this._nhasx = nhasx;
            this._soluong = soluong;
            this._gia = gia;
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
    }
}
