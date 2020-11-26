using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyGear
{
    class USB : SanPham
    {
        //Phương Thức
        public override void loadData(string masp)
        {
            this._masp = masp;
            string sqlQuery = @"SELECT * FROM dbo.SanPham s INNER JOIN dbo.USB u on s.masp = u.masp where s.masp='" + _masp + "'";
            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);
            DataRow row = dataTable.Rows[0];
            this.setData(row["masp"].ToString(), row["tensp"].ToString(), row["dvt"].ToString(), row["xuatxu"].ToString(), row["nhasx"].ToString(),
            Int32.Parse(row["soluong"].ToString()), Int32.Parse(row["gia"].ToString()), row["loaiUSB"].ToString(),Int32.Parse( row["dungLuong"].ToString()), row["chatLieu"].ToString(), Int32.Parse(row["tocDoDoc"].ToString()));
            string sqlQuery1 = @"SELECT * FROM dbo.HinhAnh h INNER JOIN dbo.USB u ON h.relation_masp = u.masp where u.masp= '" + _masp + "'";
            DataTable dataTable1 = Data.Instance.ExcuteQuery(sqlQuery1);
            //DataRow row1 = dataTable1.Rows[1];
            //this._link_image.Add(row1["url"].ToString());
            foreach (DataRow rowx in dataTable1.Rows)
            {
                this._link_image.Add(rowx["url"].ToString());
            }

        }
        public override void writeData()
        {
            string sqlQuery = @"INSERT INTO SanPham VALUES ('" + this.MASP + "','" + this.TenSP + "','" + this.LoaiSP + "','" + DVT + "','" + this.XuatXu +
                "','" + this.NhaSX + "'," + this.SoLuong.ToString() + "," + this.Gia.ToString() + ")";
            Data.Instance.ExcuteQuery(sqlQuery);
            string sqlQuery2 = @"INSERT INTO BanPhim VALUES ('" + this.MASP + "','" + this.LoaiUSB.ToString() + "','" + this._dungLuong + "','" + this._chatLieu.ToString() + "','" + this._tocDoDoc + "')";
            Data.Instance.ExcuteQuery(sqlQuery2);
            string sqlQuery3 = @"select id from HinhAnh order by id DESC";
            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery3);
            DataRow row = dataTable.Rows[0];
            int id_new = int.Parse(row["id"].ToString());
            id_new += 1;
            string sqlQuery4 = @"INSERT INTO HinhAnh VALUES(" + id_new.ToString() + ",'temp','"
                + this.link_image[0] + "', '" + this.MASP + "', '" + this.LoaiSP + "')";
            Data.Instance.ExcuteQuery(sqlQuery4);
        }
        public void setData(string masp, string tensp, string dvt, string xuatxu, string nhasx, Int32 soluong, Int32 gia, string loaiUSB , int dungluong, string chatlieu, int tocdo)
        {
            this._masp = masp;
            this._tensp = tensp;
            this._dvt = dvt;
            this._xuatxu = xuatxu;
            this._nhasx = nhasx;
            this._soluong = soluong;
            this._gia = gia;
            this._loaiUSB = loaiUSB;
            this._dungLuong = dungluong;
            this._chatLieu = chatlieu;
            this._tocDoDoc = tocdo;
        }


        //Properties
        public string LoaiUSB
        {
            get { return _loaisp; }
            set {  }
        }
        //Thuộc Tính
        private string _loaiUSB;
        private int _dungLuong; //GB
        private string _chatLieu; // sat nhua
        private int _tocDoDoc;
    }
}
