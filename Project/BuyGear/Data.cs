using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyGear
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

        private Data() { }

        private string connectionStr = @"Data Source=DESKTOP-QLAVT38;Initial Catalog=BuyGearDemo;Integrated Security=True";

        public DataTable ExcuteQuery(string query, object[] parameters = null)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionStr))
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
    }
}
