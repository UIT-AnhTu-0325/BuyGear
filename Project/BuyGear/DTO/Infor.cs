using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyGear.DTO
{
    class Infor
    {
        protected string _hoten;
        protected string _sdt;
        protected string _diachi;
        public string Hoten { get { return _hoten; } set { _hoten = value; } }
        public string SDT { get { return _sdt; } set { _sdt = value; } }
        public string DiaChi { get { return _diachi; } set { _diachi = value; } }
        public Infor(string hoten, string sdt, string diachi)
        {
            _diachi = diachi;
            _sdt = sdt;
            _hoten = hoten;
        }
    }
}
