using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyGear.DTO
{
    class ItemInGioHang
    {

        
        public void SetItem(string masp, string tensp , Int32 soluongtronggio, Int32 gia , bool isselect)
        {
            MASP = masp;
            TenSP = tensp;
            SoLuongTrongGio = soluongtronggio;
            Gia = gia;
            IsSelect = isselect;
            Link_image = new List<string>();
        }

        // properties
        public string MASP
        {
            get { return _masp; }
            set { this._masp = value; }
        }
        public string TenSP
        {
            get { return _tensp; }
            set { this._tensp = value; }
        }
        public Int32 SoLuongTrongGio
        {
            get { return _soluongtronggio; }
            set { this._soluongtronggio = value; }
        }
        public Int32 Gia
        {
            get { return _gia; }
            set { this._gia = value; }
        }
        public List<string> Link_image
        {
            get { return _link_image; }
            set { this._link_image = value; }
        }
        public bool IsSelect
        {
            get { return _isSelect; }
            set { this._isSelect = value; }
        }

        //thuoc tinh
        protected string _masp;
        protected string _tensp;
        protected Int32 _soluongtronggio;
        protected Int32 _gia;
        protected List<string> _link_image;
        protected bool _isSelect;
    }
}
