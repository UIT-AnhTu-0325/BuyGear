using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyGear.DTO;
using System.Data;

namespace BuyGear.DAO
{
    class Data_NhanXet
    {
        private static Data_NhanXet instance;
        internal static Data_NhanXet Instance
        {
            get
            {
                if (Data_NhanXet.instance == null)
                    instance = new Data_NhanXet();
                return Data_NhanXet.instance;
            }
            set
            {
                Data_NhanXet.instance = value;  
            }
        }
        public List<NhanXet> loadNhanXet(string masp)
        {
            List<NhanXet> listNhanXet = new List<NhanXet>();
            string query = "select * from nhanxetitem where ma_sp= @masp ";
            DataTable dataTable = Data.Instance.ExcuteQuery(query, new object[] {  masp });
            foreach(DataRow row in dataTable.Rows)
            {
                NhanXet nhanxet = new NhanXet(row["name"].ToString(),DateTime.Parse(row["ngaynhanxet"].ToString()), int.Parse(row["vote"].ToString()) ,
                    row["nhanxet_chinh"].ToString(), row["nhanxet_chitiet"].ToString(), row["id"].ToString());
                listNhanXet.Add(nhanxet);
            }
            return listNhanXet;
           
        }
        public List<string> listImage(string masp , string id)
        {
            List<string> listHinh = new List<string>();
            string query = "select * from hinhanhnhanxet where idnguoimua= @id and ma_sp= @masp ";
            DataTable datatable = Data.Instance.ExcuteQuery(query, new object[] { id, masp });
            foreach(DataRow row in datatable.Rows)
            {
                listHinh.Add(row["hinhanh"].ToString());
            }
            return listHinh;
        }
        public void upNhanXet(NhanXet nx , string masp)
        {
            string query = "insert into dbo.nhanxet (idnguoimua , vote, ma_sp, nhanxet_chinh, nhanxet_chitiet) values " +
                " ( @id , @vote , @masp , @nhanxetchinh , @nhanxetchitiet ) ";
            Data.Instance.ExcuteQuery(query, new object[] { Account.Instance.id, nx.Vote, masp, nx.NhanXetChinh, nx.NhanXetChiTiet });

        }
        public void upNhanXet_anh (string masp, List<string> linkImageMoTa)
        {
            for (int i = 0; i < linkImageMoTa.Count; i++)
            {
                Picture.UpPicture(linkImageMoTa[i], masp + "_nx" + i);
                string id = Picture.GetIDPicturebyName(masp + "_nx" + i);
                string query2 = "insert into hinhanhnhanxet values ( @id , @masp , @data ) ";                    
                Data.Instance.ExcuteQuery(query2, new object[] {Account.Instance.id,  masp, id });
            }
        }
        public int Rate1(string masp)
        {
            string query= "select sum(vote)/count(vote) as rate from sanpham sp, nhanxet nx " +
                " where sp.ma_sp = nx.ma_sp and sp.ma_sp = @masp group by sp.ma_sp";
            int r = 0;
            if(Data.Instance.ExcuteQuery(query, new object[] { masp }).Rows.Count>0)
            int.TryParse(Data.Instance.ExcuteQuery(query, new object[] { masp }).Rows[0]["rate"].ToString(), out r);
            return r;
        }  
        public int Rate(string masp)
        {
            string query = "select rating from sanpham where ma_sp= @masp ";
            int r = 0;
            if(Data.Instance.ExcuteQuery(query, new object[] { masp }).Rows.Count>0)
            int.TryParse(Data.Instance.ExcuteQuery(query, new object[] { masp }).Rows[0]["rating"].ToString(), out r);
            return r;
        }
        public int countRate(string masp)
        {
            string query = "select count(vote) as c from sanpham sp, nhanxet nx " +
               " where sp.ma_sp = nx.ma_sp and sp.ma_sp = @masp group by sp.ma_sp";
            if (Data.Instance.ExcuteQuery(query, new object[] { masp }).Rows.Count > 0)
                return int.Parse(Data.Instance.ExcuteQuery(query, new object[] { masp }).Rows[0]["c"].ToString());
            else return 0;
        }
        
        public string Name(string masp)
        {
            string query = "select tensp from sanpham where ma_sp= @masp ";
            return Data.Instance.ExcuteQuery(query, new object[] { masp }).Rows[0]["tensp"].ToString();
        }
        public string IDAnh(string masp)
        {
            string query = "select data from sanpham sp , hinhanh ha where sp.ma_sp= ha.ma_sp and sp.ma_sp= @masp ";
            return Data.Instance.ExcuteQuery(query, new object[] { masp }).Rows[0]["data"].ToString();
        }
    }
}
