using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyGear
{
    public class SanPhamRecommend
    {
        public SanPhamRecommend(string masp, string ten, string gia)
        {
            this._masp = masp;
            this._ten = ten;
            this._gia = gia;
            this._link_image = new List<string>();
        }
        //properties
        public string Masp
        {
            get { return _masp; }
            set { this._masp = value; }
        }
        public string Ten
        {
            get { return _ten; }
            set { this._ten = value; }
        }
        public string Gia
        {
            get { return _gia; }
            set { this._gia = value; }
        }
        public List<string> Link_Image
        {
            get { return _link_image; }
            set { this._link_image = value; }
        }
        //thuoctinh
        protected string _masp;
        protected string _ten;
        protected string _gia;
        protected List<string> _link_image;
    }
}
