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
                    row["nhanxet_chinh"].ToString(), row["nhanxet_chitiet"].ToString());
                listNhanXet.Add(nhanxet);
            }
            return listNhanXet;
           
        }
        public void upNhanXet(NhanXet nx , string masp)
        {
            string query = "insert into dbo.nhanxet (idnguoimua , vote, ma_sp, nhanxet_chinh, nhanxet_chitiet) values " +
                " ( @id , @vote , @masp , @nhanxetchinh , @nhanxetchitiet ) ";
            Data.Instance.ExcuteQuery(query, new object[] { Account.Instance.id, nx.Vote, masp, nx.NhanXetChinh, nx.NhanXetChiTiet });

        }
    }
}
