using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuyGear.DTO;

namespace BuyGear.DAO
{
    class Data
    {
        private static Data instance;

        internal static Data Instance
        {
            get
            {
                if (Data.instance == null)
                    instance = new Data();
                return Data.instance;
            }
            private set
            {
                Data.instance = value;
            }
        }
        public int x, y;
        public int Getx() { return x; }
        public void Setx(int x) { this.x = x; }
        public int Gety() { return y; }
        public void Sety(int y) { this.y = y; }

        public string giaFix(int gia)
        {
            string giafix = "";
            if (gia / 1000000 > 0)
            {
                if (gia % 1000000 / 1000 > 100)
                    giafix = (gia / 1000000).ToString() + "." + (gia % 1000000 / 1000).ToString() + ".000";
                else if (gia % 1000000 / 1000 > 10)
                    giafix = (gia / 1000000).ToString() + ".0" + (gia % 1000000 / 1000).ToString() + ".000";
                else
                    giafix = (gia / 1000000).ToString() + ".00" + (gia % 1000000 / 1000).ToString() + ".000";

            }

            else
                giafix = (gia / 1000).ToString() + ".000";
            return giafix + " đồng";

        }

        private Data() { }

        protected static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(GetConnectionString());
        private static string GetConnectionString()
        {
            return "Server=buygear-sever.database.windows.net;Database=BuyGear;UID=mini0212;Pwd=gaugau@123";
        }

        public DataTable ExcuteQuery(string query, object[] parameters = null)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    string[] splitPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in splitPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
                connection.Close();
            }

            return dataTable;
        }
        public List<SanPham> loadSanPhamMain(string type)
        {
            List<SanPham> listSP = new List<SanPham>();
            DataTable dataTable;
            if (type == "top")
            {
                string sqlQuery = @"select * from dbo.sanpham sp, (select top 8 masp from
                dbo.cthd where trangthai='da giao hang' group by masp order by sum(sl) desc) xx
                where sp.ma_sp=xx.masp";
                dataTable = Data.Instance.ExcuteQuery(sqlQuery);
            }
            else//if (type == "daxem")
            {
                string query = "select * from dbo.sanpham sp, dbo.sanphamdaxem yt where yt.ma_sp=sp.ma_sp and yt.idnguoimua= @id ";
                dataTable = Data.Instance.ExcuteQuery(query, new object[] { Account.Instance.id });
            }
            
            foreach (DataRow row in dataTable.Rows)
            {
                SanPham sp = new SanPham();
                sp.setData(row["ma_sp"].ToString(), row["tensp"].ToString(), row["loaisp"].ToString(), row["dvt"].ToString(), row["xuatxu"].ToString(), row["nhasx"].ToString(),
                Int32.Parse(row["soluong"].ToString()), Int32.Parse(row["gia"].ToString()), row["chitiet"].ToString(), row["thoigian"].ToString(),
                row["trangthaikiemduyet"].ToString(), Int32.Parse(row["ID_ngban"].ToString()), Int32.Parse(row["gia_nhap"].ToString()),
                Int32.Parse(row["gia_banbuon"].ToString()), Int32.Parse(row["VAT"].ToString()));
                string sqlQuery1 = @"SELECT * FROM dbo.HinhAnh where ma_sp='" + row["ma_sp"].ToString() + "'";
                DataTable dataTable1 = Data.Instance.ExcuteQuery(sqlQuery1);
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    sp.link_image.Add((byte[])row1["data"]);
                }
                listSP.Add(sp);
            }
            return listSP;
        }
        public List<SanPham> loadDataSanPham()
        {
            List<SanPham> listSP = new List<SanPham>();
            string sqlQuery = @"SELECT * FROM dbo.SanPham where trangthaikiemduyet='da kiem duyet'";

            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);
            foreach (DataRow row in dataTable.Rows)
            {
                SanPham sp = new SanPham();
                sp.setData(row["ma_sp"].ToString(), row["tensp"].ToString(), row["loaisp"].ToString(), row["dvt"].ToString(), row["xuatxu"].ToString(), row["nhasx"].ToString(),
                Int32.Parse(row["soluong"].ToString()), Int32.Parse(row["gia"].ToString()), row["chitiet"].ToString(), row["thoigian"].ToString(),
                row["trangthaikiemduyet"].ToString(), Int32.Parse(row["ID_ngban"].ToString()), Int32.Parse(row["gia_nhap"].ToString()),
                Int32.Parse(row["gia_banbuon"].ToString()), Int32.Parse(row["VAT"].ToString()));
                string sqlQuery1 = @"SELECT * FROM dbo.HinhAnh where ma_sp='" + row["ma_sp"].ToString() + "'";
                DataTable dataTable1 = Data.Instance.ExcuteQuery(sqlQuery1);
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    sp.link_image.Add((byte[])row1["data"]);
                }
                listSP.Add(sp);
            }
            return listSP;
        }

        public List<SanPham> loadDataSanPham(string loaisp)
        {
            List<SanPham> listSP = new List<SanPham>();
            string sqlQuery = @"SELECT * FROM dbo.SanPham where loaisp ='" + loaisp + "' and trangthaikiemduyet='da kiem duyet'";

            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);
            foreach (DataRow row in dataTable.Rows)
            {
                SanPham sp = new SanPham();
                sp.setData(row["ma_sp"].ToString(), row["tensp"].ToString(), row["loaisp"].ToString(), row["dvt"].ToString(), row["xuatxu"].ToString(), row["nhasx"].ToString(),
                Int32.Parse(row["soluong"].ToString()), Int32.Parse(row["gia"].ToString()), row["chitiet"].ToString(), row["thoigian"].ToString(),
                row["trangthaikiemduyet"].ToString(), Int32.Parse(row["ID_ngban"].ToString()), Int32.Parse(row["gia_nhap"].ToString()),
                Int32.Parse(row["gia_banbuon"].ToString()), Int32.Parse(row["VAT"].ToString()));
                string sqlQuery1 = @"SELECT * FROM dbo.HinhAnh where ma_sp='" + row["ma_sp"].ToString() + "'";
                DataTable dataTable1 = Data.Instance.ExcuteQuery(sqlQuery1);
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    sp.link_image.Add((byte[])row1["data"]);
                }
                listSP.Add(sp);

            }
            return listSP;
        }



        public DataTable Load_SP(string _masp)
        {
            string sqlQuery = @"select loaisp from SanPham where ma_sp = '" + _masp + "'";
            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);
            return dataTable;
        }

        public DataTable SelectMaSP()
        {
            string sqlQuery = @"select ma_sp from SanPham order by ma_sp DESC";
            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);
            return dataTable;
        }

        public SanPham Load_SP_byMaSP(string masp)
        {
            SanPham s = new SanPham();
            string sqlQuery = @"SELECT * FROM dbo.SanPham where ma_sp='" + masp + "' and trangthaikiemduyet='da kiem duyet'";
            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);
            DataRow row = dataTable.Rows[0];
            s.setData(row["ma_sp"].ToString(), row["tensp"].ToString(), row["loaisp"].ToString(), row["dvt"].ToString(), row["xuatxu"].ToString(), row["nhasx"].ToString(),
                Int32.Parse(row["soluong"].ToString()), Int32.Parse(row["gia"].ToString()), row["chitiet"].ToString(), row["thoigian"].ToString(),
                row["trangthaikiemduyet"].ToString(), Int32.Parse(row["ID_ngban"].ToString()), Int32.Parse(row["gia_nhap"].ToString()),
                Int32.Parse(row["gia_banbuon"].ToString()), Int32.Parse(row["VAT"].ToString()));
            string sqlQuery1 = @"SELECT * FROM dbo.HinhAnh where ma_sp= '" + masp + "'";
            DataTable dataTable1 = Data.Instance.ExcuteQuery(sqlQuery1);
            foreach (DataRow rowx in dataTable1.Rows)
            {
                s.link_image.Add((byte[])rowx["data"]);
            }
            return s;
        }

        public void UpSanPham(SanPham s)
        {
            string sqlQuery = "Insert into SanPham(ma_sp,tensp,loaisp,dvt,xuatxu,nhasx,soluong,gia,chitiet,trangthaikiemduyet,ID_ngban,gia_nhap," +
                "gia_banbuon,VAT) values ( @masp , @tensp , @loaisp , @dvt , @xuatxu , @nhasx , @soluong , @gia , @chitiet , @trangthaikiemduyet , "
                + "@ID_ngban , @gia_nhap , @gia_banbuon , @VAT )";
            this.ExcuteQuery(sqlQuery, new object[] {s.MASP,s.TenSP, s.LoaiSP, s.DVT, s.XuatXu, s.NhaSX, s.SoLuong, s.Gia, s.chitiet, s.trangthaikiemduyet,
            s.ID_nguoiban,s.gia_nhap,s.gia_banbuon,s.VAT});
            for (int i = 0; i < 4; i++)
            {
                string sqlQuery1 = "Insert into HinhAnh(name,data,ma_sp) values ( @name , @data , @ma_sp )";
                this.ExcuteQuery(sqlQuery1, new object[] { "demo", s.link_image[i], s.MASP });
            }
        }

        #region HOAI

        public DataTable GetCTHD()
        {
            return Data.instance.ExcuteQuery("select h.sohd as N'Số hóa đơn', h.id_ngmua as N'ID người mua', s.id_ngban as N'ID người bán', c.masp as N'Mã sản phẩm', c.sl as N'Số lượng', h.nghd as 'Ngày mua hàng', c.trangthai as 'Tình trạng đơn hàng' from sanpham as s, cthd as c, hoadon as h where h.sohd = c.sohd and c.masp = s.ma_sp");
        }

        public DataTable GetTaiKhoan()
        {
            return Data.instance.ExcuteQuery("select a.id as 'ID', i.username as 'Username', i.thu as N'Thu' , i.chi as N'Chi', i.isduocban as N'Quyền được bán', i.isactive as N'Quyền hoạt động' from dbo.infor as i, dbo.account as a where a.username = i.username and a.type = 0");
        }

        public DataTable GetKiemDuyet()
        {
            return Data.instance.ExcuteQuery("select ID_ngban as N'ID người bán', ma_sp N'Mã sản phẩm', soluong as N'Số lượng', gia as N'Giá', thoigian as N'Thời gian', trangthaikiemduyet as N'Trạng thái' from sanpham");
        }

        public void CapNhatQuyenTaiKhoan(DataGridView d)
        {
            for (int i = 0; i < d.Rows.Count; i++)
            {
                string isduocban = d.Rows[i].Cells[4].Value.ToString();
                string isactive = d.Rows[i].Cells[5].Value.ToString();
                string username = d.Rows[i].Cells[1].Value.ToString();
                Data.instance.ExcuteQuery("update infor set isduocban = N'" + isduocban + "', isactive = N'" + isactive + "' where username = N'" + username + "'");
                if (isduocban == "khong")
                {
                    Data.instance.ExcuteQuery("delete from TTCH where id = " + Account.Instance.FindID(username));
                }
            }
        }

        public void CapNhatKiemDuyet(DataGridView d)
        {
            for (int i = 0; i < d.Rows.Count; i++)
            {
                string trangthai = d.Rows[i].Cells[5].Value.ToString();
                string ma_sp = d.Rows[i].Cells[1].Value.ToString();
                Data.instance.ExcuteQuery("update SanPham set trangthaikiemduyet = N'" + trangthai + "' where ma_sp = N'" + ma_sp + "'");
            }
        }
        #endregion

        #region TU

        public List<SanPham> loadDataSanPham(int ID_ngban)
        {
            List<SanPham> listSP = new List<SanPham>();
            string sqlQuery = @"SELECT * FROM dbo.SanPham where ID_ngban =" + ID_ngban;

            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);
            foreach (DataRow row in dataTable.Rows)
            {
                SanPham sp = new SanPham();
                sp.setData(row["ma_sp"].ToString(), row["tensp"].ToString(), row["loaisp"].ToString(), row["dvt"].ToString(), row["xuatxu"].ToString(), row["nhasx"].ToString(),
                Int32.Parse(row["soluong"].ToString()), Int32.Parse(row["gia"].ToString()), row["chitiet"].ToString(), row["thoigian"].ToString(),
                row["trangthaikiemduyet"].ToString(), Int32.Parse(row["ID_ngban"].ToString()), Int32.Parse(row["gia_nhap"].ToString()),
                Int32.Parse(row["gia_banbuon"].ToString()), Int32.Parse(row["VAT"].ToString()));
                string sqlQuery1 = @"SELECT * FROM dbo.HinhAnh where ma_sp='" + row["ma_sp"].ToString() + "'";
                DataTable dataTable1 = Data.Instance.ExcuteQuery(sqlQuery1);
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    sp.link_image.Add((byte[])row1["data"]);
                }

                listSP.Add(sp);

            }
            return listSP;
        }
        public int countSoLuongDaBan(string masp)
        {
            string sqlQuery = "Select sum(sl) as sl from CTHD where masp = @masp ";
            int soluongdaban = 0;
            int.TryParse(this.ExcuteQuery(sqlQuery, new object[] { masp }).Rows[0]["sl"].ToString(), out soluongdaban);
            return soluongdaban;
        }
        public void FixSanPham(SanPham s)
        {
            string sqlQuery = "Update SanPham "
                   + "Set tensp = @tensp , loaisp = @loaisp , dvt = @dvt , xuatxu = @xuatxu , nhasx = @nhasx , " +
                   "soluong = @soluong , gia = @gia , chitiet = @chitiet , trangthaikiemduyet = @trangthaikiemduyet ," +
                   "ID_ngban = @idnguoiban , gia_nhap = @gia_nhap , gia_banbuon = @gia_banbuon , VAT = @VAT " +
                   "where ma_sp = @masp ";
            this.ExcuteQuery(sqlQuery, new object[] { s.TenSP, s.LoaiSP, s.DVT, s.XuatXu, s.NhaSX, s.SoLuong, s.Gia,
            s.chitiet, s.trangthaikiemduyet, s.ID_nguoiban, s.gia_nhap, s.gia_banbuon, s.VAT, s.MASP});
            for (int i = 0; i < 4; i++)
            {
                string sqlQuery1 = "update HinhAnh " +
                    "set data = @data " +
                    "where ma_sp = @masp ";
                this.ExcuteQuery(sqlQuery1, new object[] { s.link_image[i], s.MASP });
            }
        }
        public void DeleteSanPham(SanPham s)
        {
            string sqlQuery1 = "delete from hinhanh where ma_sp = @masp ";
            this.ExcuteQuery(sqlQuery1, new object[] { s.MASP });
            string sqlQuery = "delete from sanpham where ma_sp = @masp ";
            this.ExcuteQuery(sqlQuery, new object[] { s.MASP });
        }
        public List<HoaDon> loadDataSanPham(int id_ngban, string trangthai)
        {
            List<HoaDon> listSP = new List<HoaDon>();
            string sqlQuery = "select i.name,a.ID, h.nghd, s.tensp, c.sl, c.sl* s.gia as trigia ,h.diachi, t.main_image, c.sohd as sohd, c.masp as masp " +
                "from CTHD c, [dbo].[HoaDon] h, [dbo].[SanPham] s,[dbo].[Infor] i, [dbo].[Account] a, " +
                "(select  min(ma_image) as main_image,ma_sp from hinhanh group by ma_sp) t " +
                "where c.masp = s.ma_sp and h.sohd = c.sohd and s.ID_ngban = @id_ngban and " +
                "c.trangthai = @trangthai and i.username = a.username and a.ID = h.ID_ngmua and t.ma_sp = s.ma_sp";

            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery, new object[] { id_ngban, trangthai });

            foreach (DataRow row in dataTable.Rows)
            {
                string sqlQuery2 = "select data from hinhanh where ma_image= @ma_image ";
                DataTable dataTable1 = Data.Instance.ExcuteQuery(sqlQuery2, new object[] { row["main_image"].ToString() });
                listSP.Add(new HoaDon(row["name"].ToString(), int.Parse(row["ID"].ToString()), row["nghd"].ToString(),
                    row["tensp"].ToString(), int.Parse(row["sl"].ToString()), long.Parse(row["trigia"].ToString()),
                    row["diachi"].ToString(), (byte[])dataTable1.Rows[0]["data"], int.Parse(row["sohd"].ToString()), row["masp"].ToString()));

            }
            return listSP;
        }
        public void changetrangthai(int sohd, string masp, string trangthai)
        {
            string sqlQuery = "update cthd " +
                 "set trangthai = @trangthai " +
                "where sohd = @sohd and masp = @masp ";
            Data.Instance.ExcuteQuery(sqlQuery, new object[] { trangthai, sohd, masp });
        }
        #endregion
    }

}
