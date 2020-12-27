using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuyGear.DTO;
using System.Configuration;

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
            return System.Configuration.ConfigurationManager.ConnectionStrings["SeverConection"].ConnectionString;
        }

        public DataTable ExcuteQuery (string query, object[] parameters = null)
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
            else if (type == "daxem")
            {
                string query = "select * from dbo.sanpham sp, dbo.sanphamdaxem yt where yt.ma_sp=sp.ma_sp and yt.idnguoimua= @id" +
                    " order by yt.ma_sanphamdaxem desc ";
                dataTable = Data.Instance.ExcuteQuery(query, new object[] { Account.Instance.id });
            }
            else if (type == "recommend")
            {
                string query = "select top 2 sp.ma_sp from sanphamdaxem dx, sanpham sp where idnguoimua= @id and  " +
                    "sp.ma_sp = dx.ma_sp and " +
                    " day(getdate()- thoigian_daxem)< 20 order by solanxem desc";
                dataTable = Data.Instance.ExcuteQuery(query, new object[] { Account.Instance.id });
                foreach (DataRow row in dataTable.Rows)
                {
                    List<SanPhamRecommend> listsp_re = loadRecommend(row["ma_sp"].ToString());
                    string query11 = "select * from sanpham where ma_sp= @masp5 ";
                    DataTable dataTable11 = Data.Instance.ExcuteQuery(query11, new object[] { row["ma_sp"].ToString() });
                    foreach (DataRow row1 in dataTable11.Rows)
                    {
                        SanPham sp = new SanPham();
                        sp.setData(row1["ma_sp"].ToString(), row1["tensp"].ToString(), row1["loaisp"].ToString(), row1["dvt"].ToString(), row1["xuatxu"].ToString(), row1["nhasx"].ToString(),
                        Int32.Parse(row1["soluong"].ToString()), Int32.Parse(row1["gia"].ToString()), row1["chitiet"].ToString(), row1["thoigian"].ToString(),
                        row1["trangthaikiemduyet"].ToString(), Int32.Parse(row1["ID_ngban"].ToString()), Int32.Parse(row1["gia_nhap"].ToString()),
                        Int32.Parse(row1["gia_banbuon"].ToString()), Int32.Parse(row1["VAT"].ToString()));
                        string sqlQuery1 = @"SELECT * FROM dbo.HinhAnh where ma_sp='" + row1["ma_sp"].ToString() + "'";
                        DataTable dataTable2 = Data.Instance.ExcuteQuery(sqlQuery1);
                        foreach (DataRow row2 in dataTable2.Rows)
                        {
                            sp.link_image.Add(row2["data"].ToString());
                        }
                        listSP.Add(sp);
                    }
                    foreach (SanPhamRecommend spre in listsp_re)
                    {
                        string query1 = "select * from sanpham where ma_sp= @masp1 ";
                        DataTable dataTable1 = Data.Instance.ExcuteQuery(query1, new object[] { spre.Masp });
                        foreach (DataRow row1 in dataTable1.Rows)
                        {
                            SanPham sp = new SanPham();
                            sp.setData(row1["ma_sp"].ToString(), row1["tensp"].ToString(), row1["loaisp"].ToString(), row1["dvt"].ToString(), row1["xuatxu"].ToString(), row1["nhasx"].ToString(),
                            Int32.Parse(row1["soluong"].ToString()), Int32.Parse(row1["gia"].ToString()), row1["chitiet"].ToString(), row1["thoigian"].ToString(),
                            row1["trangthaikiemduyet"].ToString(), Int32.Parse(row1["ID_ngban"].ToString()), Int32.Parse(row1["gia_nhap"].ToString()),
                            Int32.Parse(row1["gia_banbuon"].ToString()), Int32.Parse(row1["VAT"].ToString()));
                            string sqlQuery1 = @"SELECT * FROM dbo.HinhAnh where ma_sp='" + row1["ma_sp"].ToString() + "'";
                            DataTable dataTable2 = Data.Instance.ExcuteQuery(sqlQuery1);
                            foreach (DataRow row2 in dataTable2.Rows)
                            {
                                sp.link_image.Add(row2["data"].ToString());
                            }
                            listSP.Add(sp);
                        }
                    }

                }
                return listSP;
            }
            else
            {
                string query = "";
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
                    sp.link_image.Add(row1["data"].ToString());
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
                    sp.link_image.Add(row1["data"].ToString());
                }
                listSP.Add(sp);
            }
            return listSP;
        }

        #region InSanPham,chitiet , thong bao
        public List<SanPhamRecommend> loadRecommend(string masp)
        {
            List<SanPhamRecommend> listSp = new List<SanPhamRecommend>();
            string query = "select tensp, loaisp, gia, ma_sp from sanpham sp where (sp.gia between " +
                "(select 75* sp1.gia/100 from sanpham sp1 where sp1.ma_sp = @masp ) and " +
                "(select sp2.gia * 125 / 100 from sanpham sp2 where sp2.ma_sp = @masp1 ) and " +
                " sp.ma_sp <> @masp2 and sp.loaisp = (select sp3.loaisp from sanpham sp3 " +
                " where sp3.ma_sp = @masp3 )) or(sp.nhasx = (select sp1.nhasx from sanpham " +
                " sp1 where sp1.ma_sp = @masp4 ) and sp.ma_sp <> @masp5 ) order by newid()";
            DataTable dataTable = Data.instance.ExcuteQuery(query, new object[] { masp, masp, masp, masp, masp, masp });
            foreach (DataRow row in dataTable.Rows)
            {
                SanPhamRecommend sp = new SanPhamRecommend(row["ma_sp"].ToString(), row["tensp"].ToString(),
                    row["gia"].ToString());
                string sqlQuery1 = @"SELECT * FROM dbo.HinhAnh where ma_sp='" + row["ma_sp"].ToString() + "'";
                DataTable dataTable1 = Data.Instance.ExcuteQuery(sqlQuery1);
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    sp.Link_Image.Add(row1["data"].ToString());
                }
                listSp.Add(sp);
            }
            return listSp;
        }
        public List<string> listMoTa(string masp)
        {
            string query = "select mota from motachitiet where ma_sp = @masp ";
            DataTable dataTable = this.ExcuteQuery(query, new object[] { masp });
            List<string> listmt = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                listmt.Add(row["mota"].ToString());
            }
            return listmt;
        }
        public List<string> listImageLink(string masp)
        {
            string query = "select dulieu from hinhanhchitiet where ma_sp = @masp ";
            DataTable dataTable = this.ExcuteQuery(query, new object[] { masp });
            List<string> list_iml = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                list_iml.Add(row["dulieu"].ToString());
            }
            return list_iml;
        }
        public void DeleteItemThongBao(string mahd, string masp)
        {
            string query = "update cthd set hienthongbao=1 where masp= @masp and sohd= @mahd ";
            this.ExcuteQuery(query, new object[] { masp, mahd });
        }
        public List<ItemThongBao> listItemThongBao()
        {
            string query = "select ct.trigia, ct.sohd, thoigianxacnhan, trangthai, masp  " +
                " , ct.thongbaoxacnhan_xem , ct.thongbaodagiao_xem " +
                "from cthd ct, hoadon hd where ct.sohd = hd.sohd and id_ngmua = @id and hienthongbao=0 and " +
                " thoigianxacnhan is not null and(ct.trangthai = 'dang giao hang' or " +
                " ct.trangthai = 'da giao hang') order by thoigianxacnhan desc";
            List<ItemThongBao> listThongBao = new List<ItemThongBao>();
            DataTable dataTable = this.ExcuteQuery(query, new object[] { Account.Instance.id });
            foreach(DataRow row in dataTable.Rows)
            {
                int temp = -1;
                if (row["thongbaoxacnhan_xem"].ToString() == "False" || row["thongbaodagiao_xem"].ToString()=="False")
                    temp = 0;
                else temp = 1;
                ItemThongBao item = new ItemThongBao(Int32.Parse(row["trigia"].ToString()),
                    row["sohd"].ToString(), DateTime.Parse(row["thoigianxacnhan"].ToString())
                    , row["trangthai"].ToString(), row["masp"].ToString(), temp);
                listThongBao.Add(item);
            }
            return listThongBao;
        }
        public int CheckThongBao(string type, bool check)
        {
            string loaigiaohang = "";
            if (type == "thongbaoxacnhan" || type=="thongbaoxacnhan_xem")
            {
                loaigiaohang = "dang giao hang";
            }
            else if(type=="thongbaodagiao" || type=="thongbaodagiao_xem")
            {
                loaigiaohang = "da giao hang";
            }
            List<ThongBao> list = new List<ThongBao>();
            string query = "select ct.sohd, masp from cthd ct, hoadon hd " +
                " where hd.sohd = ct.sohd and hd.id_ngmua = @id and " +
                " trangthai = '"+loaigiaohang +"' and "+ type+" = 0";
            DataTable datatable = this.ExcuteQuery(query, new object[] { Account.Instance.id });
            foreach(DataRow row in datatable.Rows)
            {
                ThongBao tb = new ThongBao(row["sohd"].ToString(), row["masp"].ToString());
                list.Add(tb);
            }
            if (list.Count > 0 ) 
            {
                if(type == "thongbaoxacnhan" || type=="thongbaodagiao")
                ChangeListThongBao(list,type);
                if ((type == "thongbaoxacnhan_xem" || type=="thongbaodagiao_xem") && check )
                    ChangeListThongBao(list, type);
                return list.Count;
            }
            else return 0;
        }


        public void ChangeListThongBao(List<ThongBao> listthongbao , string type)
        {
            foreach(ThongBao tb in listthongbao)
            {
                string query = "update cthd set "+type +" = 1 where sohd = @sohd and masp = @masp ";
                this.ExcuteQuery(query, new object[] { tb.Mahd, tb.Masp });
            }
        }

        #endregion 
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
                    sp.link_image.Add(row1["data"].ToString());
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
                s.link_image.Add(rowx["data"].ToString());
            }
            return s;
        }

        public void UpSanPham(SanPham s, List<string> linkimage, List<string> linkImageMoTa, List<string> mota)
        {
            string sqlQuery = "Insert into SanPham(ma_sp,tensp,loaisp,dvt,xuatxu,nhasx,soluong,gia,chitiet,trangthaikiemduyet,ID_ngban,gia_nhap," +
                "gia_banbuon,VAT) values ( @masp , @tensp , @loaisp , @dvt , @xuatxu , @nhasx , @soluong , @gia , @indexmota , @trangthaikiemduyet , "
                + "@ID_ngban , @gia_nhap , @gia_banbuon , @VAT )";
            this.ExcuteQuery(sqlQuery, new object[] {s.MASP,s.TenSP, s.LoaiSP, s.DVT, s.XuatXu, s.NhaSX, s.SoLuong, s.Gia, s.IndexMoTa, s.trangthaikiemduyet,
            s.ID_nguoiban,s.gia_nhap,s.gia_banbuon,s.VAT});
            for (int i = 0; i < 4; i++)
            {
                Picture.UpPicture(linkimage[i], s.MASP + "_" + i);
                string id = Picture.GetIDPicturebyName(s.MASP + "_" + i);
                string sqlQuery1 = "Insert into HinhAnh(name,data,ma_sp) values ( @name , @data , @ma_sp )";
                this.ExcuteQuery(sqlQuery1, new object[] { "demo", id, s.MASP });
            }
            for (int i = 0; i < linkImageMoTa.Count; i++)
            {
                Picture.UpPicture(linkImageMoTa[i], s.MASP + "_mt" + i);
                string id = Picture.GetIDPicturebyName(s.MASP + "_mt" + i);
                string query2 = "insert into hinhanhchitiet (ma_sp, dulieu) values ( @masp , @data )";
                this.ExcuteQuery(query2, new object[] { s.MASP, id });
            }
            for (int i = 0; i < mota.Count; i++)
            {
                string query2 = "insert into motachitiet (ma_sp, mota) values ( @masp , @mota )";
                this.ExcuteQuery(query2, new object[] { s.MASP, mota[i] });
            }

        }


        #region HOAI

        public DataTable GetCTHD()
        {
            return Data.instance.ExcuteQuery("select h.sohd as N'Số hóa đơn', h.id_ngmua as N'ID người mua', s.id_ngban as N'ID người bán', c.masp as N'Mã sản phẩm', c.sl as N'Số lượng', h.nghd as 'Ngày mua hàng', c.trangthai as 'Tình trạng đơn hàng' from sanpham as s, cthd as c, hoadon as h where h.sohd = c.sohd and c.masp = s.ma_sp");
        }

        public DataTable GetTaiKhoan()
        {
            return Data.instance.ExcuteQuery("select a.id , i.username , i.thu , i.chi, i.isduocban, i.isactive from dbo.infor as i, dbo.account as a where a.username = i.username and a.type = 0");
        }

        public DataTable GetKiemDuyet()
        {
            return Data.instance.ExcuteQuery("select ID_ngban, ma_sp, soluong, gia, thoigian, trangthaikiemduyet from sanpham");
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



        public void CapNhatQuyenHD(string username, string isactive)
        {
            Data.instance.ExcuteQuery("update infor set isactive = N'" + isactive + "' where username = N'" + username + "'");
        }
        public void XoaQuyenBH()
        {
            Data.Instance.ExcuteQuery("delete from TTCH where id = " + Account.Instance.id);
            Data.Instance.ExcuteQuery("update infor set isduocban = N'" + "khong" + "' where username = N'" + Account.Instance.userName + "'");
        }
        public void CapNhatQuyenBH()
        {
            Data.Instance.ExcuteQuery("update infor set isduocban = N'" + "co" + "' where username = N'" + Account.Instance.userName + "'");
        }
        public void CapNhatTrangThaiSP(string trangthai, string ma_sp)
        {
            Data.instance.ExcuteQuery("update SanPham set trangthaikiemduyet = N'" + trangthai + "' where ma_sp = N'" + ma_sp + "'");
        }
        public string[] LoadSoLuong()
        {
            string[] str = new string[4];
            str[0] = Data.instance.ExcuteQuery("select count(*) from dbo.infor as i, dbo.account as a where a.username = i.username and a.type = 0").Rows[0][0].ToString();
            str[1] = Data.instance.ExcuteQuery("select count(*) from dbo.infor as i, dbo.account as a where a.username = i.username and a.type = 0 and isduocban = N'cho xac nhan'").Rows[0][0].ToString();
            str[2] = Data.instance.ExcuteQuery("select count(*) from sanpham where trangthaikiemduyet = N'cho xac nhan'").Rows[0][0].ToString();
            str[3] = Data.instance.ExcuteQuery("select count(*) from sanpham as s, cthd as c, hoadon as h where h.sohd = c.sohd and c.masp = s.ma_sp").Rows[0][0].ToString();
            return str;
        }

        public DataTable loadSlLoaiSP(string loai)
        {
            return Data.instance.ExcuteQuery("select sum(ct.sl) from sanpham as sp, CTHD as ct where sp.ma_sp = ct.masp and ct.trangthai = N'da giao hang' and sp.loaisp = N'" + loai + "'");
        }
        public DataTable loadTop(string str)
        {
            return Data.instance.ExcuteQuery("select top(3) with ties a.id,a.username,i.isactive,i.isduocban from infor as i, account as a where a.username = i.username order by i." + str + " desc ");
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
                    sp.link_image.Add(row1["data"].ToString());
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
        public void FixSanPham(SanPham s, List<string> linkimage)
        {
            string sqlQuery = "Update SanPham "
                   + "Set tensp = @tensp , loaisp = @loaisp , dvt = @dvt , xuatxu = @xuatxu , nhasx = @nhasx , " +
                   "soluong = @soluong , gia = @gia , chitiet = @chitiet , trangthaikiemduyet = @trangthaikiemduyet ," +
                   "ID_ngban = @idnguoiban , gia_nhap = @gia_nhap , gia_banbuon = @gia_banbuon , VAT = @VAT " +
                   "where ma_sp = @masp ";
            this.ExcuteQuery(sqlQuery, new object[] { s.TenSP, s.LoaiSP, s.DVT, s.XuatXu, s.NhaSX, s.SoLuong, s.Gia,
            s.IndexMoTa, s.trangthaikiemduyet, s.ID_nguoiban, s.gia_nhap, s.gia_banbuon, s.VAT, s.MASP});
            for (int i = 0; i < 4; i++)
            {
                Picture.UpPicture(linkimage[i], s.MASP + "_" + i);
                string id = Picture.GetIDPicturebyName(s.MASP + "_" + i);
                string sqlQuery1 = "update HinhAnh " +
                    "set data = @data " +
                    "where ma_sp = @masp ";
                this.ExcuteQuery(sqlQuery1, new object[] { id, s.MASP });
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

            string sqlQuerysdt = "select numberphone " +
                 " from account a, infor i where a.id = @id and i.username =a.username";
            string sdtShop = Data.Instance.ExcuteQuery(sqlQuerysdt, new object[] { id_ngban }).Rows[0]["numberphone"].ToString();

            foreach (DataRow row in dataTable.Rows)
            {
                string sqlQuery2 = "select data from hinhanh where ma_image= @ma_image ";
                DataTable dataTable1 = Data.Instance.ExcuteQuery(sqlQuery2, new object[] { row["main_image"].ToString() });
                listSP.Add(new HoaDon(row["name"].ToString(), int.Parse(row["ID"].ToString()), row["nghd"].ToString(),
                    row["tensp"].ToString(), int.Parse(row["sl"].ToString()), long.Parse(row["trigia"].ToString()),
                    row["diachi"].ToString(), dataTable1.Rows[0]["data"].ToString(), int.Parse(row["sohd"].ToString()), row["masp"].ToString(), sdtShop));

            }
            return listSP;
        }
        public HoaDon getHoaDon(string masp, string sohd)
        {
            string query = "select numberphone from account a, infor i where  " +
                " a.id = (select id_ngban from sanpham where ma_sp = @masp ) " +
                " and i.username = a.username";
            string sdt = Data.instance.ExcuteQuery(query, new object[] { masp }).Rows[0]["numberphone"].ToString();
            string query1 = "select tensp from sanpham where ma_sp= @masp ";
            string tensp = Data.instance.ExcuteQuery(query1, new object[] { masp }).Rows[0]["tensp"].ToString();
            string query2 = "select name, address from account a, infor i " +
                " where a.id= @id and i.username =a.username";
            string name = Data.instance.ExcuteQuery(query2, new object[] { Account.Instance.id }).Rows[0]["name"].ToString();
            string diachi = Data.instance.ExcuteQuery(query2, new object[] { Account.Instance.id }).Rows[0]["address"].ToString();
            string query3 = "select * from hoadon hd, cthd ct where hd.sohd = ct.sohd " +
                " and ct.masp = @masp and ct.sohd = @sohd ";
            DataRow row = Data.instance.ExcuteQuery(query3, new object[] { masp, sohd }).Rows[0];

            HoaDon hd = new HoaDon(name, int.Parse(Account.Instance.id), row["nghd"].ToString(), tensp,
                int.Parse(row["sl"].ToString()), long.Parse(row["trigia"].ToString()),
                diachi, "", int.Parse(row["sohd"].ToString()), masp, sdt);
            return hd;
        }
        public void changetrangthai(int sohd, string masp, string trangthai)
        {
            if (trangthai == "dang giao hang")
            {
                DateTime today = DateTime.Now;
                string sqlQuery = "update cthd " +
                     "set trangthai = @trangthai , ngaybatdaugiao = @ngaybd " +
                    "where sohd = @sohd and masp = @masp ";
                Data.Instance.ExcuteQuery(sqlQuery, new object[] { trangthai, today.ToString(), sohd, masp });
            }
            else if (trangthai == "da giao hang")
            {
                DateTime today = DateTime.Now;
                string sqlQuery = "update cthd " +
                     "set trangthai = @trangthai , ngayhoanthanh = @ngayht " +
                    "where sohd = @sohd and masp = @masp ";
                Data.Instance.ExcuteQuery(sqlQuery, new object[] { trangthai, today.ToString(), sohd, masp });
            }
        }
        public int getlastIDSanPham()
        {
            string query = "select count(ma_sp) as mx from sanpham";
            return int.Parse(Data.Instance.ExcuteQuery(query).Rows[0]["mx"].ToString());
        }

        public void choicucsuc()
        {
            string query = "select data from HinhAnh h,(select  min(ma_image) as main_image,ma_sp from hinhanh group by ma_sp) t " +
                " where h.ma_image =t.main_image ";
            DataTable data = Data.Instance.ExcuteQuery(query);
            foreach(DataRow row in data.Rows)
            {
                Picture.LoadImage_by_ID(row["data"].ToString());
            }
        }

        #endregion
    }

}
