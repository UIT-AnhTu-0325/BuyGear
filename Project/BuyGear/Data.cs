using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private string connectionStr = @"Data Source=DESKTOP-QLAVT38;Initial Catalog=BuyGear;Integrated Security=True"; //LAPTOP-414NHSFG\SQLEXPRESS

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


        public List<Mouse> loadDataMouse()
        {
            List<Mouse> listMouse = new List<Mouse>();
            string sqlQuery = @"SELECT * FROM dbo.SanPham s INNER JOIN dbo.Chuot c on s.masp = c.masp ";
            
            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);
          
            foreach (DataRow row in dataTable.Rows)
            {
                Mouse mouse = new Mouse();
                mouse.setData(row["masp"].ToString(), row["tensp"].ToString(), row["dvt"].ToString(), row["xuatxu"].ToString(), row["nhasx"].ToString(),
             Int32.Parse(row["soluong"].ToString()), Int32.Parse(row["gia"].ToString()), Int32.Parse(row["DPI"].ToString()), row["loai"].ToString());

                string sqlQuery1 = @"SELECT * FROM dbo.HinhAnh h INNER JOIN dbo.Chuot c ON h.relation_masp = c.masp where c.masp='" + row["masp"].ToString() + "'";
                DataTable dataTable1 = Data.Instance.ExcuteQuery(sqlQuery1);
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    mouse.link_image.Add(row1["url"].ToString());
                }
                listMouse.Add(mouse);
              
                
            }
           
            return listMouse;
        }

        public List<Monitor> loadDataMonitor()
        {
            List<Monitor> listMonitor = new List<Monitor>();
            string sqlQuery = @"SELECT * FROM dbo.SanPham s INNER JOIN dbo.ManHinh c on s.masp = c.masp ";
           
            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);
            foreach (DataRow row in dataTable.Rows)
            {
                Monitor monitor = new Monitor();
                // Mouse mouse = new Mouse();
                monitor.setData(row["masp"].ToString(), row["tensp"].ToString(), row["dvt"].ToString(), row["xuatxu"].ToString(), row["nhasx"].ToString(),
            Int32.Parse(row["soluong"].ToString()), Int32.Parse(row["gia"].ToString()), row["loai_manhinh"].ToString(), row["doPhanGiai"].ToString(), row["kichThuoc"].ToString(), Int32.Parse(row["tocDoLamTuoi"].ToString()));


                string sqlQuery1 = @"SELECT * FROM dbo.HinhAnh h INNER JOIN dbo.ManHinh c ON h.relation_masp = c.masp where c.masp='"+ row["masp"].ToString()+"'";
                DataTable dataTable1 = Data.Instance.ExcuteQuery(sqlQuery1);
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    monitor.link_image.Add(row1["url"].ToString());
                }
                listMonitor.Add(monitor);


            }
          

            return listMonitor;
        }

        public List<Keyboard> loadDataKeyboard()
        {
            List<Keyboard> listKeyBoard = new List<Keyboard>();
            string sqlQuery = @"SELECT * FROM dbo.SanPham s INNER JOIN dbo.BanPhim bp on s.masp = bp.masp ";
            
            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);
        
            foreach (DataRow row in dataTable.Rows)
            {
                Keyboard keyboard = new Keyboard();
                keyboard.setData(row["masp"].ToString(), row["tensp"].ToString(), row["dvt"].ToString(), row["xuatxu"].ToString(), row["nhasx"].ToString(),
            Int32.Parse(row["soluong"].ToString()), Int32.Parse(row["gia"].ToString()), row["loai_kichthuoc"].ToString(), row["loai_banphim"].ToString(), row["loai_led"].ToString());
                string sqlQuery1 = @"SELECT * FROM dbo.HinhAnh h INNER JOIN dbo.BanPhim bp ON h.relation_masp = bp.masp where bp.masp='" + row["masp"].ToString() + "'";
                DataTable dataTable1 = Data.Instance.ExcuteQuery(sqlQuery1);

                foreach (DataRow row1 in dataTable1.Rows)
                {
                    keyboard.link_image.Add(row1["url"].ToString());
                }
                listKeyBoard.Add(keyboard);


            }
           
            return listKeyBoard;
        }

        public List<Storage> loadDataStorage()
        {
            List<Storage> listStorage = new List<Storage>();
            string sqlQuery = @"SELECT * FROM dbo.SanPham s INNER JOIN dbo.oCung o on s.masp = o.masp ";

            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);

            foreach (DataRow row in dataTable.Rows)
            {
                Storage storage = new Storage();
                storage.setData(row["masp"].ToString(), row["tensp"].ToString(), row["dvt"].ToString(), row["xuatxu"].ToString(), row["nhasx"].ToString(),
            Int32.Parse(row["soluong"].ToString()), Int32.Parse(row["gia"].ToString()), row["loai_ocung"].ToString(), Int32.Parse(row["dungluong"].ToString()));
                string sqlQuery1 = @"SELECT * FROM dbo.HinhAnh h INNER JOIN dbo.oCung o ON h.relation_masp = o.masp where o.masp='" + row["masp"].ToString() + "'";
                DataTable dataTable1 = Data.Instance.ExcuteQuery(sqlQuery1);

                foreach (DataRow row1 in dataTable1.Rows)
                {
                    storage.link_image.Add(row1["url"].ToString());
                }
                listStorage.Add(storage);


            }

            return listStorage;
        }



        public List<USB> loadDataUSB()
        {
            List<USB> listMouse = new List<USB>();
            string sqlQuery = @"SELECT * FROM dbo.SanPham s INNER JOIN dbo.USB c on s.masp = c.masp ";

            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);

            foreach (DataRow row in dataTable.Rows)
            {
                USB usb = new USB();
                usb.setData(row["masp"].ToString(), row["tensp"].ToString(), row["dvt"].ToString(), row["xuatxu"].ToString(), row["nhasx"].ToString(),
          Int32.Parse(row["soluong"].ToString()), Int32.Parse(row["gia"].ToString()), row["loaiUSB"].ToString(), Int32.Parse(row["dungLuong"].ToString()),
          row["chatLieu"].ToString(), Int32.Parse(row["tocDoDoc"].ToString()));

                string sqlQuery1 = @"SELECT * FROM dbo.HinhAnh h INNER JOIN dbo.USB c ON h.relation_masp = c.masp where c.masp='" + row["masp"].ToString() + "'";
                DataTable dataTable1 = Data.Instance.ExcuteQuery(sqlQuery1);
                foreach (DataRow row1 in dataTable1.Rows)
                {
                    usb.link_image.Add(row1["url"].ToString());
                }
                listMouse.Add(usb);


            }

            return listMouse;
        }



        public List<fanLaptop> loadDatafanLaptop()
        {
            List<fanLaptop> listfanLaptop = new List<fanLaptop>();
            string sqlQuery = @"SELECT * FROM dbo.SanPham s INNER JOIN dbo.TanNhiet tn on s.masp = tn.masp ";

            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);

            foreach (DataRow row in dataTable.Rows)
            {
                fanLaptop fanlaptop = new fanLaptop();
                fanlaptop.setData(row["masp"].ToString(), row["tensp"].ToString(), row["dvt"].ToString(), row["xuatxu"].ToString(), row["nhasx"].ToString(),
            Int32.Parse(row["soluong"].ToString()), Int32.Parse(row["gia"].ToString()), Int32.Parse(row["tiengOn"].ToString()), Int32.Parse(row["dienAp"].ToString()),
            row["kichThuoc"].ToString(), Int32.Parse(row["soQuat"].ToString()), Int32.Parse(row["tocDoQuat"].ToString()));
                string sqlQuery1 = @"SELECT * FROM dbo.HinhAnh h INNER JOIN dbo.TanNhiet tn ON h.relation_masp = tn.masp where tn.masp='" + row["masp"].ToString() + "'";
                DataTable dataTable1 = Data.Instance.ExcuteQuery(sqlQuery1);

                foreach (DataRow row1 in dataTable1.Rows)
                {
                    fanlaptop.link_image.Add(row1["url"].ToString());
                }
                listfanLaptop.Add(fanlaptop);


            }

            return listfanLaptop;
        }

        public int x, y;
    
        // load product in main
        public int Getx()
        {
            return x;
        }
        public void Setx(int x)
        {
            this.x = x;
        }
        public int Gety() { return y; }
        public void Sety(int y) { this.y = y; }

        //public List<SanPham> loadDatasanpham()
        //{
        //    List<SanPham> listProduct = new List<SanPham>();
        //    DataTable dataTable = Data.instance.ExcuteQuery("SELECT * FROM dbo.SanPham");

        //    foreach (DataRow item in dataTable.Rows)
        //    {
        //        SanPham product = new SanPham();

        //        listProduct.Add(product);
        //    }
        //    return listProduct;
        //}
    }
}
