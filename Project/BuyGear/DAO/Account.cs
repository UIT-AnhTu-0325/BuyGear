using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BuyGear.DTO;
using System.Data;
using System.Drawing;
using System.Windows;

namespace BuyGear.DAO
{
    class Account
    {
        private static Account instance;

        internal static Account Instance
        {
            get
            {
                if (Account.instance == null)
                    instance = new Account();
                return Account.instance;
            }
            private set
            {
                Account.instance = value;
            }
        }
        private Account() { }
        public string userName = "";
        public string id = "";
        public string passWord;
        public string Encode(string password)
        {
            string hashPass = "";
            byte[] CharToString = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(CharToString);

            foreach (byte item in hashData)
            {
                hashPass += item;
            }

            return hashPass;
        }
        public Infor loadInfor()
        {
            string sql = "select * from dbo.infor where username = @username ";
            DataRow row = Data.Instance.ExcuteQuery(sql, new object[] { Account.instance.userName }).Rows[0];
            Infor infor = new Infor(row["name"].ToString(), row["numberphone"].ToString(), row["address"].ToString());
            return infor;

        }
        public int Login(string username, string password)
        {
            string hashPass = Account.instance.Encode(password);
            string sqlQuery = "EXEC Pro_CheckLogin @username , @password";
            int count = Data.Instance.ExcuteQuery(sqlQuery, new object[] { username, hashPass }).Rows.Count;
            string sqlQuery1 = "select id from dbo.Account where username= @username";
            id = Data.Instance.ExcuteQuery(sqlQuery1, new object[] { username }).Rows[0]["id"].ToString();
            //id = Data.Instance.ExcuteQuery(sqlQuery1).Rows[0]["id"].ToString();
            return count;
        }
        public void InsertAcc(string username, string password)
        {
            string hassPass = Account.instance.Encode(password);
            string query1 = "INSERT INTO account(username, PASSWORD, type) VALUES(N'" + username + "', N'" + hassPass + "', 0)";
            Data.Instance.ExcuteQuery(query1);
            string query2 = "INSERT INTO infor(username) VALUES(N'" + username + "')";
            Data.Instance.ExcuteQuery(query2);
            string sqlQuery1 = "select id from dbo.Account where username= @username";
            id = Data.Instance.ExcuteQuery(sqlQuery1, new object[] { username }).Rows[0]["id"].ToString();


        }

        public bool Exist(string username)
        {
            if (Data.Instance.ExcuteQuery("EXEC Pro_IsExistUsername @username", new object[] { username }).Rows.Count > 0)
                return true;
            return false;
        }

        public DataTable Load_Info()
        {
            string sqlQuery = @"SELECT * FROM dbo.Infor WHERE username = N'" + Account.Instance.userName + "'";
            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);
            return dataTable;
        }
        public DataTable Update(string name, string address, string email, string sdt)
        {
            string sqlQuery = "UPDATE dbo.Infor SET name = N'" + name + "',address = N'" + address + "',email = N'" + email + "',numberphone = N'" + sdt + "' WHERE username = N'" + Account.Instance.userName + "'";
            return Data.Instance.ExcuteQuery(sqlQuery);
        }

        public DataTable UpdateSexual(string sexual)
        {
            string sqlQuery = "UPDATE dbo.Infor SET sexual = N'" + sexual + "' WHERE username = N'" + Account.Instance.userName + "'";
            return Data.Instance.ExcuteQuery(sqlQuery);
        }

        public DataTable UpdateBirthday(string ngay, string thang, string nam)
        {
            string sqlQuery = "UPDATE dbo.Infor SET birthday = N'" + nam + "-" + thang + "-" + ngay + "' WHERE username = N'" + Account.Instance.userName + "'";
            return Data.Instance.ExcuteQuery(sqlQuery);
        }

        public DataTable UpdatePassword(string newPass)
        {
            Account.Instance.passWord = newPass;
            string sqlQuery = "EXEC Pro_UpdatePass  @password , @username";
            string hashPass = Account.Instance.Encode(newPass);
            return Data.Instance.ExcuteQuery(sqlQuery, new object[] { hashPass, Account.Instance.userName });
        }

        #region HOAI
        public void InsertAccAd(string username, string password)
        {
            string hassPass = Account.instance.Encode(password);
            string query1 = "INSERT INTO account(username, PASSWORD, type) VALUES(N'" + username + "', N'" + hassPass + "', 1)";
            Data.Instance.ExcuteQuery(query1);
            string query2 = "INSERT INTO infor(username) VALUES(N'" + username + "')";
            Data.Instance.ExcuteQuery(query2);
        }
        public string FindUsername(string id)
        {
            string query = "select username from account where id = " + id;
            return Data.Instance.ExcuteQuery(query).Rows[0][0].ToString();
        }

        public string FindID()
        {
            string query = "select id from account where username = N'" + Account.instance.userName + "'";
            return Data.Instance.ExcuteQuery(query).Rows[0][0].ToString();
        }

        public string FindID(string username)
        {
            string query = "select id from account where username = N'" + username + "'";
            return Data.Instance.ExcuteQuery(query).Rows[0][0].ToString();
        }
        public void DKBH(string id, string loaihinh, string diachikho, string tengianhang)
        {
            string query1 = "insert into TTCH (id,loaihinh,diachikho,tengianhang) values (" + id + ",N'" + loaihinh + "',N'" + diachikho + "', N'" + tengianhang + "')";
            Data.Instance.ExcuteQuery(query1);
            string query2 = "update infor set isduocban = N'cho xac nhan' where username = N'" + Account.instance.userName + "'";
            Data.Instance.ExcuteQuery(query2);
        }
        public bool CheckType(string username)
        {
            string query = "select type from account where username = N'" + username + "'";
            if (Data.Instance.ExcuteQuery(query).Rows[0][0].ToString() == "1")
            {
                return true;
            }
            return false;
        }

        public DataRow ShowTTCH(string id)
        {
            string query = "select * from TTCH where id = " + id;
            DataTable dataTable = Data.Instance.ExcuteQuery(query);
            return dataTable.Rows[0];
        }
        #endregion
        #region Tu
        public bool isDangNhap()
        {
            if (id == "")
                return false;
            return true;
        }
        public bool isDuocBan()
        {
            string query = "select * from Infor where username = @username and isduocban = 'co' ";
            if (Data.Instance.ExcuteQuery(query, new Object[] { this.userName }).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool isDaDangKi()
        {
            string query =  "select * from TTCH where id = @id";
            if (Data.Instance.ExcuteQuery(query, new Object[] { this.id }).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public Image getAvatar()
        {
            string query = "select dataAva from Infor where username = @username ";
            DataTable v = Data.Instance.ExcuteQuery(query, new Object[] { this.userName });
            if (v.Rows[0]["dataAva"] == DBNull.Value)
            {
                return Image.FromFile("../../Resources/usericon2.png");
            }
            return Picture.LoadImage_by_ID(v.Rows[0]["dataAva"].ToString());
           
        }
        public void changeAvatar(string path)
        {
            Picture.DeletePicture_by_ID(Picture.GetIDPicturebyName(this.userName));
            Picture.UpPicture(path, userName);
            string ID = Picture.GetIDPicturebyName(userName);
            string query = "update Infor set dataAva = @data where username = @username ";
            Data.Instance.ExcuteQuery(query, new Object[] { ID, this.userName });
        }
        #endregion
    }
}

