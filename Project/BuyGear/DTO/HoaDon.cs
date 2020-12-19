using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyGear
{
    public class HoaDon
    {
       public HoaDon(string tenngmua, int id_ngmua, string nghdon, string tensp, int soluong, long trigia, string diachi , string image, int sohd, string masp)
        {
            ID_ngmua = id_ngmua;
            Nghdon = nghdon;
            Tenngmua = tenngmua;
            Tensp = tensp;
            Soluong = soluong;
            Trigia = trigia;
            Diachi = diachi;
            Image_sp = image;
            Sohd = sohd;
            Masp = masp;
        }

        protected string tenngmua;
        protected int iD_ngmua;
        protected string nghdon;
        protected string tensp;
        protected int soluong;
        protected long trigia;
        protected string diachi;
        protected string image_sp;
        protected int sohd;
        protected string masp;

        public string Tenngmua { get => tenngmua; set => tenngmua = value; }
        public int ID_ngmua { get => iD_ngmua; set => iD_ngmua = value; }
        public string Nghdon { get => nghdon; set => nghdon = value; }
        public string Tensp { get => tensp; set => tensp = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public long Trigia { get => trigia; set => trigia = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Image_sp { get => image_sp; set => image_sp = value; }
        public int Sohd { get => sohd; set => sohd = value; }
        public string Masp { get => masp; set => masp = value; }
    }
}
