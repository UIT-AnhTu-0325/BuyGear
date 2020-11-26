using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyGear
{
    class Keyboard :SanPham
    {
        //Phương Thức
        public override void loadData(string masp)
        {
            this._masp = masp;
            string sqlQuery = @"SELECT * FROM dbo.SanPham s INNER JOIN dbo.BanPhim bp on s.masp = bp.masp where s.masp='" + _masp + "'";
            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);
            DataRow row = dataTable.Rows[0];
            this.setData(row["masp"].ToString(), row["tensp"].ToString(), row["dvt"].ToString(), row["xuatxu"].ToString(), row["nhasx"].ToString(),
            Int32.Parse(row["soluong"].ToString()), Int32.Parse(row["gia"].ToString()), row["loai_kichthuoc"].ToString(), row["loai_banphim"]. ToString(), row["loai_led"].ToString());
            string sqlQuery1 = @"SELECT * FROM dbo.HinhAnh h INNER JOIN dbo.BanPhim bp ON h.relation_masp = bp.masp where bp.masp= '" + _masp + "'";
            DataTable dataTable1 = Data.Instance.ExcuteQuery(sqlQuery1);
            //DataRow row1 = dataTable1.Rows[1];
            //this._link_image.Add(row1["url"].ToString());
            foreach(DataRow rowx in dataTable1.Rows)
            {
                this._link_image.Add(rowx["url"].ToString());
            }

        }
        public override void writeData()
        {
            string sqlQuery = @"INSERT INTO SanPham VALUES ('" + this.MASP + "','" + this.TenSP + "','" + this.LoaiSP + "','" + DVT + "','" + this.XuatXu +
                "','" + this.NhaSX + "'," + this.SoLuong.ToString() + "," + this.Gia.ToString() + ")";
            Data.Instance.ExcuteQuery(sqlQuery);
            string sqlQuery2 = @"INSERT INTO BanPhim VALUES ('" + this.MASP + "','" + this.LoaiKichThuoc.ToString() + "','" + this.LoaiBanPhim + "','"+ this.LoaiLed.ToString() +"')";
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
        public void setData(string masp, string tensp, string dvt, string xuatxu, string nhasx, Int32 soluong, Int32 gia,string loaiBanPhim, string loaiKichThuoc, string loaiLed)
        {
            this._masp = masp;
            this._tensp = tensp;
            this._dvt = dvt;
            this._xuatxu = xuatxu;
            this._nhasx = nhasx;
            this._soluong = soluong;
            this._gia = gia;
            this._loaiKichThuoc = loaiKichThuoc;
            this._loaiBanPhim = loaiBanPhim;
            this._loaiLed = loaiLed;
        }


        //Properties
        public string LoaiKichThuoc
        {
            get { return _loaiKichThuoc; }
            set { _loaiKichThuoc = value; }
        }
        public string LoaiBanPhim
        {
            get { return _loaiBanPhim; }
            set { _loaiBanPhim = value; }
        }
        public string LoaiLed
        {
            get { return _loaiLed; }
            set { _loaiLed = value; }
        }
        
        //Thuộc Tính
        private string _loaiKichThuoc;
        private string _loaiBanPhim;
        private string _loaiLed;
    }
}

