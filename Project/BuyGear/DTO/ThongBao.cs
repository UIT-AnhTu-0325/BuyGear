using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyGear.DTO
{
    public class ThongBao
    {
        public ThongBao(string mahd, string masp)
        {
            this._mahd = mahd;
            this._masp = masp;
        }
        public string Mahd
        {
            get { return _mahd; }
            set { _mahd = value; }
        }
        public string Masp
        {
            get { return _masp; }
            set { _masp = value; }
        }
        protected string _mahd;
        protected string _masp;
    }
}
