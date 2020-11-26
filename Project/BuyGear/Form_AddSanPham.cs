using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuyGear
{
    public partial class Form_AddSanPham : Form
    {
        public Form_AddSanPham()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string getMaSP(string start_MaSP)
        {
            string sqlQuery = @"select masp from SanPham order by masp DESC";
            DataTable dataTable = Data.Instance.ExcuteQuery(sqlQuery);
            DataRow row = dataTable.Rows[0];
            string masp_now = row["masp"].ToString();
            int sosp_now = int.Parse(masp_now.Remove(0, 1));
            sosp_now += 1;
            return start_MaSP + sosp_now.ToString();
        }
        private void btn_hoantat_Click(object sender, EventArgs e)
        {
            switch (cbo_LoaiSP.Text)
            {
                case "Chuột":
                    {
                        Mouse add = new Mouse();
                        add.MASP = getMaSP("M");
                        add.LoaiSP = "Chuot";
                        add.DPI = 3000;
                        add.Loai = "Quang";
                        add.setData(txb_tensanpham.Text, "Cai", txb_xuatxu.Text, txt_nhasx.Text, int.Parse(cbo_soluong.Text), int.Parse(txt_gia.Text));
                        add.link_image.Add(txtURL_Image.Text);
                        add.writeData();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            this.Close();
        }
        //
        //Thuộc tính
        //
    }
}
