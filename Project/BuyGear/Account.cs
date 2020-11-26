using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BuyGear
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
        public int Login(string username, string password)
        {
            string hashPass = Account.instance.Encode(password);
            string sqlQuery = "EXEC Pro_CheckLogin @username , @password";
            int count = Data.Instance.ExcuteQuery(sqlQuery, new object[] { username, hashPass }).Rows.Count;
            return count;
        }
        public void InsertAcc(string username, string password)
        {
            string hassPass = Account.instance.Encode(password);
            string query1 = "INSERT INTO account(username, PASSWORD, type) VALUES(N'" + username + "', N'" + hassPass + "', 0)";
            Data.Instance.ExcuteQuery(query1);
            string query2 = "INSERT INTO infor(username) VALUES(N'" + username + "')";
            Data.Instance.ExcuteQuery(query2);
        }
    }
}

