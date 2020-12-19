using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuyGear.DAO;
using BuyGear.DTO;

namespace BuyGear
{
    public partial class Form_BanHang : Form
    {
        public int _ID_me;
        public Form_BanHang(int ID_me)
        {
            this._ID_me = ID_me;
            InitializeComponent();
        }
        public void LoadDS()
        {
            Page_AddSP.Hide();
            pageDS.Show();
            pageDS.Controls.Clear();
            pageDS.Controls.Add(pnlDS);
            pnlDS.Controls.Clear();
            List<SanPham> lsp = Data.Instance.loadDataSanPham(_ID_me);
            foreach (var s in lsp)
            {
                ucSanPhamDangBan b = new ucSanPhamDangBan(s, this);
                pnlDS.Controls.Add(b);
            }
        }
        private void btnDS_Click(object sender, EventArgs e)
        {
            LoadDS();
        }
        private void btnAddSP_Click(object sender, EventArgs e)
        {
            Page_AddSP.Show();
            Form_AddSanPham frm = new Form_AddSanPham(this)
            {
                TopMost = true,
                TopLevel = false
            };
            this.Page_AddSP.Controls.Clear();
            this.Page_AddSP.Controls.Add(frm);
            frm.Show();
        }
        public void callForm_Sua(Form_AddSanPham f )
        {
            this.pageDS.Controls.Clear();
            this.pageDS.Controls.Add(f);
            f.Show();
        }

        
        public void loadSanPham(string trangthai)
        {
            Page_AddSP.Hide();
            pageDS.Show();
            pageDS.Controls.Clear();
            pageDS.Controls.Add(pnlDS);
            pnlDS.Controls.Clear();
            List<HoaDon> lsp = Data.Instance.loadDataSanPham(_ID_me, trangthai);
            int temp;
            switch (trangthai)
            {
                case "cho xac nhan":
                    {
                        temp = 1;
                        break;
                    }
                case "dang giao hang":
                    {
                        temp = 2;
                        break;
                    }
                default:
                    {
                        temp = 3;
                        break;
                    }

            }
            foreach (var s in lsp)
            {
                ucMuaBan b = new ucMuaBan(temp, s, this);
                pnlDS.Controls.Add(b);
            }
        }

        private void btnDSChoXacNhan_Click(object sender, EventArgs e)
        {
            loadSanPham("cho xac nhan");
        }
        private void btnDSDangGiao_Click(object sender, EventArgs e)
        {
            loadSanPham("dang giao hang");
        }
        private void btndagiao_Click(object sender, EventArgs e)
        {
            loadSanPham("da giao hang");

        }
    }

}
