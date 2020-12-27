using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyGear.DTO
{
    class NhanXet
    {
        public NhanXet(string tenKhachHang, DateTime ngayNhanXet, int vote, string nhanXetChinh, string nhanXetChiTiet, string id)
        {
            this._tenKhachHang = tenKhachHang;
            this._timeNhanXet = ngayNhanXet;
            this._vote = vote;
            this._nhanXetChinh = nhanXetChinh;
            this._nhanXetChiTiet = nhanXetChiTiet;
            this._id = id;
        }
        public NhanXet(int vote, string nhanxetChinh, string nhanxetchitiet)
        {
            this._vote = vote;
            this._nhanXetChinh = nhanxetChinh;
            this._nhanXetChiTiet = nhanxetchitiet;
        }
        //properties
        public string TenKhachHang
        {
            get { return _tenKhachHang; }
            set { value = _tenKhachHang; }
        }
        public DateTime NgayNhanXet
        {
            get { return _timeNhanXet; }
            set { value = _timeNhanXet; }
        }
        public int Vote
        {
            get { return _vote; }
            set { value = _vote; }
        }
        public string NhanXetChinh
        {
            get { return _nhanXetChinh; }
            set { value = _nhanXetChinh; }
        }
        public string NhanXetChiTiet
        {
            get { return _nhanXetChiTiet; }
            set { value = _nhanXetChiTiet; }
        }
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        //thuoctinh
        protected string _id;
        protected string _tenKhachHang;
        protected DateTime _timeNhanXet;
        protected int _vote;
        protected string _nhanXetChinh;
        protected string _nhanXetChiTiet;


    }
}
