using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyGear.DTO
{
    public class ItemThongBao
    {
        public ItemThongBao(int tien, string madh , DateTime thoigian, string trangthai, 
            string masp, int checknew )
        {
            _tien = tien;
            _madh = madh;
            _thoigian = thoigian;
            _trangthai = trangthai;
            _masp = masp;
            _checknew = checknew;
        }
        public int Tien
        {
            get { return _tien; }
            set { _tien = value; }
        }
        public string Madh
        {
            get { return _madh; }
            set { _madh = value; }
        }
        public DateTime ThoiGian
        {
            get { return _thoigian; }
            set { _thoigian = value; }
        }
        public string TrangThai
        {
            get { return _trangthai; }
            set { _trangthai = value; }
        }
        public string Masp
        {
            get { return _masp; }
            set { _masp = value; }
        }
        public int Checknew
        {
            get { return _checknew; }
            set { _checknew = value; }
        }
        protected int _checknew;
        protected int _tien;
        protected string _madh;
        protected DateTime _thoigian;
        protected string _trangthai;
        protected string _masp;
    }
}
