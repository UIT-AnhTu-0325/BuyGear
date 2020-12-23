using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BuyGear.DTO;
using System.Windows.Forms;
namespace BuyGear.DAO
{
    class Data_ThongKe
    {
        public static int CountSanPham(int ID, DateTime from, DateTime to)
        {
            string sqlQuery = "Select sum (sl) as sl from CTHD where trangthai = 'da giao hang' and ngayhoanthanh <= @dateto and ngayhoanthanh >= @datefrom " +
                "and masp in(select ma_sp from sanpham  where ID_ngban = @id )";
            int sl = 0;
            int.TryParse(Data.Instance.ExcuteQuery(sqlQuery, new object[] { to.ToString(), from.ToString(), ID }).Rows[0]["sl"].ToString(), out sl);
            return sl;
        }
        public static int CountDonHangHoanThanh(int ID, DateTime from, DateTime to)
        {
            string sqlQuery = "Select count (masp) as sl from CTHD where trangthai = 'da giao hang' and ngayhoanthanh <= @dateto and ngayhoanthanh >= @datefrom " +
                "and masp in(select ma_sp from sanpham  where ID_ngban = @id )";
            int sl = 0;
            int.TryParse(Data.Instance.ExcuteQuery(sqlQuery, new object[] { to.ToString(), from.ToString(), ID }).Rows[0]["sl"].ToString(), out sl);
            return sl;
        }
        public static int CountDonHangDangGiao(int ID, DateTime from, DateTime to)
        {
            string sqlQuery = "Select count (masp) as sl from CTHD where trangthai = 'dang giao hang' and ngaybatdaugiao <= @dateto and ngayhoanthanh is NULL " +
                "and masp in(select ma_sp from sanpham  where ID_ngban = @id )";
            int sl = 0;
            int.TryParse(Data.Instance.ExcuteQuery(sqlQuery, new object[] { to.ToString(), ID }).Rows[0]["sl"].ToString(), out sl);
            return sl;
        }
        public static int CountDonHangTiepNhan(int ID, DateTime from, DateTime to)
        {
            string sqlQuery = "Select count (masp) as sl from CTHD C, hoadon H where H.nghd <= @dateto and nghd >= @datefrom " +
                "and C.masp in(select ma_sp from sanpham  where ID_ngban = @id ) and C.sohd = H.sohd ";
            int sl = 0;
            int.TryParse(Data.Instance.ExcuteQuery(sqlQuery, new object[] { to.ToString(), from.ToString(), ID }).Rows[0]["sl"].ToString(), out sl);
            return sl;
        }
        public static int CountDoanhThu(int ID, DateTime from, DateTime to)
        {
            string sqlQuery = "Select sum (trigia) as sl from CTHD where trangthai = 'da giao hang' and ngayhoanthanh <= @dateto and ngayhoanthanh >= @datefrom " +
                "and masp in(select ma_sp from sanpham  where ID_ngban = @id )";
            int sl = 0;
            int.TryParse(Data.Instance.ExcuteQuery(sqlQuery, new object[] { to.ToString(), from.ToString(), ID }).Rows[0]["sl"].ToString(), out sl);
            return sl;
        }
        public static int CountDonHangChoXuLy(int ID, DateTime from, DateTime to)
        {
            string sqlQuery = "Select count (masp) as sl from CTHD C, hoadon H where trangthai = 'cho xac nhan' and H.nghd <= @dateto and nghd >= @datefrom " +
                "and C.masp in(select ma_sp from sanpham  where ID_ngban = @id ) and C.sohd=H.sohd";
            int sl = 0;
            int.TryParse(Data.Instance.ExcuteQuery(sqlQuery, new object[] { to.ToString(), from.ToString(), ID }).Rows[0]["sl"].ToString(), out sl);
            return sl;
        }
        private static DateTime getNowMonth()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
        }
        private static DateTime get6MonthAgo()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            if (month < 6)
            {
                month = month + 7;
                year -= 1;
            }
            else
            {
                month = month - 5;
            }
            return new DateTime(year, month, 1);
        }
        public static Dictionary<string, int> getDataChartDH(int ID)
        {
            var v = new Dictionary<string, int>();
            //==
            string sqlQuery1 = "Select count (masp) as sl from CTHD C, hoadon H where trangthai = 'cho xac nhan' and H.nghd <= @dateto and nghd >= @datefrom " +
                "and C.masp in(select ma_sp from sanpham  where ID_ngban = @id ) and C.sohd=H.sohd";
            int sl1 = 0;
            int.TryParse(Data.Instance.ExcuteQuery(sqlQuery1, new object[] { getNowMonth().ToString(), get6MonthAgo().ToString(), ID }).Rows[0]["sl"].ToString(), out sl1);
            v.Add("Chờ xác nhận", sl1);
            //==
            string sqlQuery2 = "Select count (masp) as sl from CTHD where trangthai = 'dang giao hang' and ngaybatdaugiao <= @dateto and ngayhoanthanh is NULL " +
                "and masp in(select ma_sp from sanpham  where ID_ngban = @id )";
            int sl2 = 0;
            int.TryParse(Data.Instance.ExcuteQuery(sqlQuery2, new object[] { getNowMonth().ToString(), ID }).Rows[0]["sl"].ToString(), out sl2);
            v.Add("Đang giao", sl2);
            //==
            string sqlQuery3 = "Select count (masp) as sl from CTHD where trangthai = 'da giao hang' and ngayhoanthanh <= @dateto and ngayhoanthanh >= @datefrom " +
                "and masp in(select ma_sp from sanpham  where ID_ngban = @id )";
            int sl3 = 0;
            int.TryParse(Data.Instance.ExcuteQuery(sqlQuery3, new object[] { getNowMonth().ToString(), get6MonthAgo().ToString(), ID }).Rows[0]["sl"].ToString(), out sl3);
            v.Add("Đã giao hàng", sl3);
            v.Add("Hủy bỏ", 0);
            return v;
        }
        public static string GetVietNameseSP(string eng)
        {
            string temp = "";
            switch(eng)
            {
                case "ManHinh":
                    {
                        temp = "Màn Hình";
                        break;
                    }
                case "BanPhim":
                    {
                        temp = "Bàn Phím";
                        break;
                    }
                case "OCung":
                    {
                        temp = "Ổ Cứng";
                        break;
                    }
                case "USB":
                    {
                        temp = "USB";
                        break;
                    }
                case "Chuot":
                    {
                        temp = "Chuột";
                        break;
                    }
                case "TanNhiet":
                    {
                        temp = "Tản Nhiệt";
                        break;
                    }
                default:
                    {
                        temp = "Khác";
                        break;
                    }
            }
            return temp;
        }
        public static Dictionary<string,int>getDataChartSP(int ID)
        {
            var dic = new Dictionary<string, int>();
            string sqlQuery = "select count(c.masp) as con, s.loaisp from cthd C inner join sanpham s on c.masp=s.ma_sp " +
                "where ID_ngban= @ID group by s.loaisp";
            var data = Data.Instance.ExcuteQuery(sqlQuery, new object[] { ID });
            for(int i=0;i<data.Rows.Count;i++)
            {
                dic.Add(GetVietNameseSP(data.Rows[i]["loaisp"].ToString()), int.Parse(data.Rows[i]["con"].ToString()));
            }
            return dic;
        }
        public static Dictionary<string,int>getDataChartDT_DT(int ID)
        {
            var dic = new Dictionary<string, int>();
            string sqlQuery = "select sum(trigia) as dt, format(ngayhoanthanh,'MM/yyyy') " +
                "as my from cthd where masp in(select ma_sp from sanpham  where ID_ngban = @ID ) " +
                "and ngayhoanthanh is not NULL and ngayhoanthanh <= @dateto and ngayhoanthanh >= @datefrom " +
                "group by format(ngayhoanthanh,'MM/yyyy')";
            var data = Data.Instance.ExcuteQuery(sqlQuery, new object[] { ID, getNowMonth().ToString(), get6MonthAgo().ToString() });
           

            int temp_y = get6MonthAgo().Year;
            int temp_m = get6MonthAgo().Month;
            int temp_mnow = getNowMonth().Month;
            if (getNowMonth().Month < 5)
            {

                for (int i = temp_m; i <= 12; i++)
                {
                    dic.Add(i + "/" + temp_y, 0);
                }

                temp_y++;
                for (int i = 1; i <= temp_mnow; i++)
                {
                    dic.Add(i + "/" + temp_y, 0);
                }
            }
            else
            {
                for (int i = temp_m; i <= temp_mnow; i++)
                {
                    dic.Add(i + "/" + temp_y, 0);
                }
            }
            for (int i = 0; i < data.Rows.Count; i++)
            {
                for(int j=0;j<dic.Count;j++)
                {
                    var item = dic.ElementAt(j);
                    if (data.Rows[i]["my"].ToString().Contains(item.Key))
                    {
                        dic[item.Key] = int.Parse(data.Rows[i]["dt"].ToString());
                    }
                }
            }
            return dic;
        }
        public static Dictionary<string, int> getDataChartDT_SP(int ID)
        {
            var dic = new Dictionary<string, int>();
            string sqlQuery = "select sum(sl) as sumsp, format(ngayhoanthanh,'MM/yyyy') " +
                "as my from cthd where masp in(select ma_sp from sanpham  where ID_ngban = @ID ) " +
                "and ngayhoanthanh is not NULL and ngayhoanthanh <= @dateto and ngayhoanthanh >= @datefrom " +
                "group by format(ngayhoanthanh,'MM/yyyy')";
            var data = Data.Instance.ExcuteQuery(sqlQuery, new object[] { ID, getNowMonth().ToString(), get6MonthAgo().ToString() });


            int temp_y = get6MonthAgo().Year;
            int temp_m = get6MonthAgo().Month;
            int temp_mnow = getNowMonth().Month;
            if (getNowMonth().Month < 5)
            {

                for (int i = temp_m; i <= 12; i++)
                {
                    dic.Add(i + "/" + temp_y, 0);
                }

                temp_y++;
                for (int i = 1; i <= temp_mnow; i++)
                {
                    dic.Add(i + "/" + temp_y, 0);
                }
            }
            else
            {
                for (int i = temp_m; i <= temp_mnow; i++)
                {
                    dic.Add(i + "/" + temp_y, 0);
                }
            }
            for (int i = 0; i < data.Rows.Count; i++)
            {
                for (int j = 0; j < dic.Count; j++)
                {
                    var item = dic.ElementAt(j);
                    if (data.Rows[i]["my"].ToString().Contains(item.Key))
                    {
                        dic[item.Key] = int.Parse(data.Rows[i]["sumsp"].ToString());
                    }
                }
            }
            return dic;
        }
        public static int CountDonHangTiepNhanToDay(int ID)
        {
            DateTime to = DateTime.Now.Date; ;
            DateTime from = DateTime.Today.Date;
            string sqlQuery = "Select count (masp) as sl from CTHD C, hoadon H where H.nghd <= @dateto and nghd >= @datefrom " +
                "and C.masp in(select ma_sp from sanpham  where ID_ngban = @id ) and C.sohd = H.sohd ";
            int sl = 0;
           // int.TryParse(Data.Instance.ExcuteQuery(sqlQuery, new object[] { to.ToString(), from.ToString(), ID }).Rows[0]["sl"].ToString(), out sl);
            return sl;
        }
        public static int CountSoSPDangBan(int ID)
        {
            string sqlQuery = "Select count (ma_sp) as sl from SanPham where ID_ngban= @id  ";
            int sl = 0;
            int.TryParse(Data.Instance.ExcuteQuery(sqlQuery, new object[] { ID }).Rows[0]["sl"].ToString(), out sl);
            return sl;
        }
        public static int CountDoanhThuToDay(int ID)
        {
            DateTime to = DateTime.Now.Date; ;
            DateTime from = DateTime.Today.Date;
            string sqlQuery = "Select sum (trigia) as sl from CTHD where trangthai = 'da giao hang' and ngayhoanthanh <= @dateto and ngayhoanthanh >= @datefrom " +
                "and masp in(select ma_sp from sanpham  where ID_ngban = @id )";
            int sl = 0;
            //int.TryParse(Data.Instance.ExcuteQuery(sqlQuery, new object[] { to.ToString(), from.ToString(), ID }).Rows[0]["sl"].ToString(), out sl);
            return sl;
        }

    }
}
