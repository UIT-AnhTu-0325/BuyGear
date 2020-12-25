using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BuyGear.DTO;
namespace BuyGear.DAO
{
    class Data_gioHang
    {
        private static Data_gioHang instance;
        internal static Data_gioHang Instance
        {
            get
            {
                if (Data_gioHang.instance == null)
                    instance = new Data_gioHang();
                return Data_gioHang.instance;
            }
            set
            {
                Data_gioHang.instance = value;
            }
        }

        public int loadSoTien()
        {
            int tongTien = 0;
            string sqlQuery = @"select sum(gia *soluong_giohang) as tongtien from dbo.sanpham sp inner join dbo.sanphamgiohang gh
            on sp.ma_sp =gh.ma_sp where idnguoimua=( select id from dbo.account where username ='"
            + Account.Instance.userName + "') and isSelect =1";
            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);
            if (dataTable != null)
                foreach (DataRow row in dataTable.Rows)
                {
                    int.TryParse(row["tongtien"].ToString(), out tongTien);

                }

            return tongTien;
        }
        public DataTable UpdateSelect(bool check, string masp)
        {
            string sqlQuery = @"UPDATE dbo.SanPhamGioHang SET isSelect =" + (check ? "1" : "0") + @"WHERE ma_sp=
            '" + masp.ToString() + "' and" + @"
            idnguoimua='" + Account.Instance.id + "'";

            return Data.Instance.ExcuteQuery(sqlQuery);
        }
        //public DataTable UpdateSoluongSanPham()
        public int SoluongSanPham(int index, string masp)
        {
            int sl = 1;
            string plusOrMinus = (index == 1 ? "+1" : "-1");
            string sqlQuery = "update dbo.SanPhamGioHang set soluong_giohang= (select soluong_giohang "
            + "from dbo.SanPhamGioHang where ma_sp= @masp and idnguoimua= @id )" + plusOrMinus + "where idnguoimua= @id1 and ma_sp= @masp1";
            DataTable datatable = Data.Instance.ExcuteQuery(sqlQuery, new object[] { masp, Account.Instance.id, Account.Instance.id, masp });
            string sqlQuery2 = @"select soluong_giohang from dbo.SanPhamGioHang WHERE ma_sp =
            '" + masp.ToString() + "' and" + @"
            idnguoimua = (select id from dbo.account where username = '" + Account.Instance.userName +
            "')";

            DataTable datatable2 = Data.Instance.ExcuteQuery(sqlQuery2);

            foreach (DataRow row in datatable2.Rows)
            {
                int.TryParse(row["soluong_giohang"].ToString(), out sl);
            }
            return sl;

        }
        public void InsertToGioHang(string idnguoimua, string masp)
        {
            string query_masp = "select * from dbo.SanPhamGioHang where idnguoimua = @id and ma_sp= @masp ";
            if (Data.Instance.ExcuteQuery(query_masp, new object[] { idnguoimua, masp }).Rows.Count != 0)
            {
                string query = "update dbo.SanPhamGioHang set soluong_giohang = (select soluong_giohang from dbo.SanPhamGioHang where "
                + "idnguoimua = @id1 and ma_sp = @masp1 )+1 where idnguoimua = @id2 and ma_sp= @masp ";
                Data.Instance.ExcuteQuery(query, new object[] { idnguoimua, masp, idnguoimua, masp });

            }
            else
            {
                string query = "insert into dbo.SanPhamGioHang (idnguoimua,ma_sp) values ( @id , @masp )";
                Data.Instance.ExcuteQuery(query, new object[] { idnguoimua, masp });

            }

        }
        public void Insert_dangGiao(string idnguoimua, string masp)
        {
            string query = "update dbo.sanphamgiohang " +
            " set danggiao = 1 where idnguoimua = @id and ma_sp = @masp ";
            Data.Instance.ExcuteQuery(query, new object[] { idnguoimua, masp, idnguoimua, masp });

        }


        public void MakeInvoice_HoaDon(int tongtien, string diachi)
        {
            string query = "insert into dbo.hoadon (id_ngmua, nghd, trigia , diachi) values ( @id , getdate(), @tongtien , @diachi )";
            Data.Instance.ExcuteQuery(query, new object[] { Account.Instance.id, tongtien, diachi, Account.Instance.id });

        }
        public void DeleteFromGioHang()
        {
            string query = " delete from dbo.sanphamgiohang where idnguoimua= @id1 and isSelect=1";
            Data.Instance.ExcuteQuery(query, new object[] { Account.Instance.id, Account.Instance.id });
        }
        public void DeleteFromGioHang(string masp, string id)
        {
            string query = "delete from dbo.sanphamgiohang where idnguoimua= @id and ma_sp= @masp ";
            Data.Instance.ExcuteQuery(query, new object[] { id, masp });
        }
        public void AddYeuthich(string masp)
        {
            string query = "insert into dbo.sanphamyeuthich (idnguoimua , ma_sp) " +
                " values ( @id , @masp ) ";
            Data.Instance.ExcuteQuery(query, new object[] { Account.Instance.id, masp });
        }
        public void AddDaXem(string masp)
        {
            string query1 = "select sum(solanxem) as c from dbo.sanphamdaxem where " +
                " idnguoimua= @id and ma_sp= @masp ";
            int c = 0;
            int.TryParse(Data.Instance.ExcuteQuery(query1, new object[] { Account.Instance.id, masp }).Rows[0]["c"].ToString(), out c);
            if (c == 0)
            {
                string query = "insert into dbo.sanphamdaxem (idnguoimua, ma_sp) " +
                    " values ( @id , @masp ) ";
                Data.Instance.ExcuteQuery(query, new object[] { Account.Instance.id, masp });
            }
            else
            {
                string query2 = "delete from dbo.sanphamdaxem " +
                " where idnguoimua = @id and ma_sp =  @masp ";
                string query = "insert into dbo.sanphamdaxem (idnguoimua, ma_sp , solanxem) " +
                    " values ( @id , @masp , @slx ) ";
                Data.Instance.ExcuteQuery(query2, new object[] { Account.Instance.id, masp });
                Data.Instance.ExcuteQuery(query, new object[] { Account.Instance.id, masp, c + 1 });
            }
        }
        public void DeleteFromYeuThich(string masp)
        {
            string query = "delete from dbo.sanphamyeuthich where idnguoimua= @id and ma_sp = @masp ";
            Data.Instance.ExcuteQuery(query, new object[] { Account.Instance.id, masp });
        }
        public bool checkYeuThich(string masp)
        {
            string query = "select count(*) as c from dbo.sanphamyeuthich where ma_sp= @masp and idnguoimua= @id ";
            int c = 0;
            int.TryParse(Data.Instance.ExcuteQuery(query, new object[] { masp, Account.Instance.id }).Rows[0]["c"].ToString(), out c);
            if (c > 0) return true;
            else return false;
        }
        public void DeleteFromDaXem(string masp)
        {
            string query = "delete from dbo.sanphamdaxem where idnguoimua= @id and ma_sp = @masp ";
            Data.Instance.ExcuteQuery(query, new object[] { Account.Instance.id, masp });
        }
        public void MakeInvoice_cthd(string masp, int soluong)
        {
            string query = "insert into dbo.cthd ( masp , sohd, sl, trangthai) values ( @masp , (select top 1 sohd from "
                + "dbo.hoadon order by sohd desc), @sl , N'cho xac nhan')";
            Data.Instance.ExcuteQuery(query, new object[] { masp, soluong });

        }

        public int SoSanPhamTrongGio()
        {
            int x = 0;
            string query = "select sum(soluong_giohang) as sl from dbo.sanphamgiohang where idnguoimua= @id and isSelect=1";
            int.TryParse(Data.Instance.ExcuteQuery(query, new object[] { Account.Instance.id }).Rows[0]["sl"].ToString(), out x);
            return x;
        }

        public List<ItemInGioHang> loadDataSanPhamTrongGio()
        {
            List<ItemInGioHang> listSPTrongGio = new List<ItemInGioHang>();
            string sqlQuery = @"select * from dbo.sanpham sp left join dbo.sanphamgiohang gh on sp.ma_sp = gh.ma_sp
            where idnguoimua=(
            select id from dbo.account where username='" + Account.Instance.userName + "')";
            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);
            foreach (DataRow row in dataTable.Rows)
            {
                ItemInGioHang item = new ItemInGioHang();
                item.SetItem(row["ma_sp"].ToString(), row["tensp"].ToString(),
                    Int32.Parse(row["soluong_giohang"].ToString()), Int32.Parse(row["gia"].ToString()),
                    bool.Parse(row["isSelect"].ToString()));
                string sqlQuery1 = @"SELECT * FROM dbo.HinhAnh where ma_sp='" + row["ma_sp"].ToString() + "'";
                DataTable dataTable1 = Data.Instance.ExcuteQuery(sqlQuery1);
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    item.Link_image.Add(row1["data"].ToString());
                }
                listSPTrongGio.Add(item);
            }
            return listSPTrongGio;
        }
        public List<ItemInGioHang> loadSanPhamDangGiao(string trangthai)
        {
            List<ItemInGioHang> listSPTrongGio = new List<ItemInGioHang>();
            string sqlQuery = "select distinct ma_sp, tensp, gia from dbo.cthd ct , dbo.hoadon hd, dbo.sanpham sp where ct.sohd=hd.sohd "
           + "and ct.trangthai= @trangthai and hd.id_ngmua= @id and sp.ma_sp = ct.masp";
            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery, new object[] { trangthai, Account.Instance.id });
            foreach (DataRow row in dataTable.Rows)
            {
                ItemInGioHang item = new ItemInGioHang();
                item.SetItem(row["ma_sp"].ToString(), row["tensp"].ToString(),
                   1, Int32.Parse(row["gia"].ToString()),
                    true);
                string sqlQuery1 = @"SELECT * FROM dbo.HinhAnh where ma_sp='" + row["ma_sp"].ToString() + "'";
                DataTable dataTable1 = Data.Instance.ExcuteQuery(sqlQuery1);
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    item.Link_image.Add(row1["data"].ToString());
                }
                listSPTrongGio.Add(item);
            }
            return listSPTrongGio;
        }
        public List<ItemInGioHang> loadSanPhamYeuThichDaXem(string function)
        {
            List<ItemInGioHang> listSP = new List<ItemInGioHang>();
            string query = "";
            if (function == "yeuthich")
                query = "select sp.ma_sp, tensp, gia from dbo.sanpham sp, dbo.sanphamyeuthich yt where yt.ma_sp=sp.ma_sp and yt.idnguoimua= @id ";
            else if (function == "daxem")
            {
                query = "select sp.ma_sp, tensp, gia from dbo.sanpham sp, dbo.sanphamdaxem yt " +
                    "where yt.ma_sp=sp.ma_sp and yt.idnguoimua= @id  order by yt.ma_sanphamdaxem desc ";
            }
            DataTable dataTable = Data.Instance.ExcuteQuery(query, new object[] { Account.Instance.id });
            foreach (DataRow row in dataTable.Rows)
            {
                ItemInGioHang item = new ItemInGioHang();
                item.SetItem(row["ma_sp"].ToString(), row["tensp"].ToString(),
                    1, Int32.Parse(row["gia"].ToString()),
                     true);
                string sqlQuery1 = @"SELECT * FROM dbo.HinhAnh where ma_sp='" + row["ma_sp"].ToString() + "'";
                DataTable dataTable1 = Data.Instance.ExcuteQuery(sqlQuery1);
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    item.Link_image.Add(row1["data"].ToString());
                }
                listSP.Add(item);
            }
            return listSP;
        }

        public List<ItemInGioHang> loadDataSanPhamTrongGioNoPic()
        {
            List<ItemInGioHang> listSPTrongGio = new List<ItemInGioHang>();
            string sqlQuery = "select * from dbo.sanpham sp left join dbo.sanphamgiohang gh on sp.ma_sp = gh.ma_sp"
            + " where idnguoimua= @id and gh.isSelect=1 ";
            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery, new object[] { Account.Instance.id });
            foreach (DataRow row in dataTable.Rows)
            {
                ItemInGioHang item = new ItemInGioHang();
                item.SetItem(row["ma_sp"].ToString(), row["tensp"].ToString(),
                    Int32.Parse(row["soluong_giohang"].ToString()), Int32.Parse(row["gia"].ToString()),
                    bool.Parse(row["isSelect"].ToString()));
                listSPTrongGio.Add(item);
            }
            return listSPTrongGio;
        }
        public bool CheckComment(string masp)
        {
            string query = "select count(*) as kt from dbo.account ac inner join dbo.nhanxet nx on ac.id= nx.idnguoimua where " +
                " ac.id= @id and nx.ma_sp = @masp ";
            DataTable dataTable = Data.Instance.ExcuteQuery(query, new object[] { Account.Instance.id, masp });
            int count = 0;
            int.TryParse(dataTable.Rows[0]["kt"].ToString(), out count);
            if (count > 0)
                return true;
            else return false;
        }
    }
}
