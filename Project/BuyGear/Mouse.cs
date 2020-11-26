using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;

namespace BuyGear
{
    class Mouse : SanPham
    {

        
        
        
        //Phương Thức
        public override void loadData(string masp)
        {
            this._masp = masp;
            string sqlQuery = @"SELECT * FROM dbo.SanPham s INNER JOIN dbo.Chuot c on s.masp = c.masp where s.masp='"+_masp+"'";
            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);
            DataRow row = dataTable.Rows[0];
            this.setData(row["masp"].ToString(), row["tensp"].ToString(), row["dvt"].ToString(), row["xuatxu"].ToString(), row["nhasx"].ToString(),
            Int32.Parse(row["soluong"].ToString()),Int32.Parse(row["gia"].ToString()), Int32.Parse(row["DPI"].ToString()), row["loai"].ToString());
            string sqlQuery1 = @"SELECT * FROM dbo.HinhAnh h INNER JOIN dbo.Chuot c ON h.relation_masp = c.masp where c.masp= '" + _masp + "'";
            DataTable dataTable1 = Data.Instance.ExcuteQuery(sqlQuery1);
            foreach (DataRow rowx in dataTable1.Rows)
            {
                this._link_image.Add(rowx["url"].ToString());
            }
        }
        public override void writeData()
        {
            string sqlQuery= @"INSERT INTO SanPham VALUES ('"+this.MASP + "','" + this.TenSP + "','" + this.LoaiSP + "','" + DVT + "','" + this.XuatXu +
                "','" + this.NhaSX + "'," + this.SoLuong.ToString() + "," + this.Gia.ToString() + ")";
            Data.Instance.ExcuteQuery(sqlQuery);
            string sqlQuery2 = @"INSERT INTO Chuot VALUES ('" + this.MASP + "','" + this.DPI.ToString() + "','" + this.Loai + "')";
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
        public void setData(string masp,string tensp,string dvt,string xuatxu,string nhasx,Int32 soluong, Int32 gia,Int32 dpi, string loai)
        {
            this._masp = masp;
            this._tensp = tensp;
            this._dvt = dvt;
            this._xuatxu = xuatxu;
            this._nhasx = nhasx;
            this._soluong = soluong;
            this._gia = gia;
            this._DPI = dpi;
            this._loai = loai;
        }

        // Phuong thuc load product
        //public new List<Mouse> loadDataMouse()
        //{
        //    List<Mouse> listMouse = new List<Mouse>();
        //    string sqlQuery = @"SELECT * FROM dbo.SanPham s INNER JOIN dbo.Chuot c on s.masp = c.masp ";
        //    DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);
        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        Mouse mouse = new Mouse();
        //        mouse.setData(row["masp"].ToString(), row["tensp"].ToString(), row["dvt"].ToString(), row["xuatxu"].ToString(), row["nhasx"].ToString(),
        //    Int32.Parse(row["soluong"].ToString()), Int32.Parse(row["gia"].ToString()), Int32.Parse(row["DPI"].ToString()), row["loai"].ToString());

        //        listMouse.Add(mouse);
        //    }


        //    //string sqlQuery1 = @"SELECT * FROM dbo.HinhAnh h INNER JOIN dbo.Chuot c ON h.relation_masp = c.masp where c.masp= '" + _masp + "'";
        //    //DataTable dataTable1 = Data.Instance.ExcuteQuery(sqlQuery1);
        //    //DataRow row1 = dataTable1.Rows[0];
        //    //this._link_image.Add(row1["url"].ToString());
        //    return listMouse;
        //}

        //Properties
        public Int32 DPI
        {
            get { return _DPI; }
            set { _DPI = value; }
        }
        public string Loai
        {
            get { return _loai; }
            set { _loai = value; }
        }
        //Thuộc Tính
        private Int32 _DPI;
        private string _loai;
    }
}
