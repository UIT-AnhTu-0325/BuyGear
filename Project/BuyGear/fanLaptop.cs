using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyGear
{
    class fanLaptop :SanPham
    {
        //Phương Thức
        public override void loadData(string masp)
        {
            this._masp = masp;
            string sqlQuery = @"SELECT * FROM dbo.SanPham s INNER JOIN dbo.TanNhiet tn on s.masp = tn.masp where s.masp='" + _masp + "'";
            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);
            DataRow row = dataTable.Rows[0];
            this.setData(row["masp"].ToString(), row["tensp"].ToString(), row["dvt"].ToString(), row["xuatxu"].ToString(), row["nhasx"].ToString(),
            Int32.Parse(row["soluong"].ToString()), Int32.Parse(row["gia"].ToString()), Int32.Parse(row["tiengOn"].ToString()), Int32.Parse(row["dienAp"].ToString()),
            row["kichThuoc"].ToString(), Int32.Parse(row["soQuat"].ToString()), Int32.Parse(row["tocDoQuat"].ToString()));
           
            string sqlQuery1 = @"SELECT * FROM dbo.HinhAnh h INNER JOIN dbo.TanNhiet tn ON h.relation_masp = tn.masp where tn.masp= '" + _masp + "'";
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
            string sqlQuery2 = @"INSERT INTO BanPhim VALUES ('" + this.MASP + "','" + this.TiengOn.ToString() + "','" + this.DienAp + "','" + this.KichThuoc.ToString() + "','" + this.TocDoQuat + "')";
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
        public void setData(string masp, string tensp, string dvt, string xuatxu, string nhasx, Int32 soluong, Int32 gia, int tiengon, int dienap , string kichthuoc, int soquat, int tocdoquat)
        {
            this._masp = masp;
            this._tensp = tensp;
            this._dvt = dvt;
            this._xuatxu = xuatxu;
            this._nhasx = nhasx;
            this._soluong = soluong;
            this._gia = gia;
            this._tiengOn = tiengon;
            this._dienAp = dienap;
            this._kichThuoc = kichthuoc;
            this._soQuat = soquat;
            this._tocDoQuat = tocdoquat;
        }


        //Properties
        public int TiengOn
        {
            get { return _tiengOn; }
            set { _tiengOn = value; }
        }
        public int DienAp
        {
            get { return _dienAp; }
            set { _dienAp = value; }
        }
        public string KichThuoc
        {
            get { return _kichThuoc; }
            set { _kichThuoc = value; }
        }
        public int SoQuat
        {
            get { return _soQuat; }
            set { _soQuat = value; }
        }
        public int TocDoQuat
        {
            get { return _tocDoQuat; }
            set { _tocDoQuat = value; }
        }
        //Thuộc Tính
        private int _tiengOn; // db
        private int _dienAp; // VDC
        private string _kichThuoc;
        private int _soQuat;
        private int _tocDoQuat;

    }
}
