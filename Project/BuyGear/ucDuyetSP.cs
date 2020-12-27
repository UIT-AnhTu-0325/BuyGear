using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuyGear.DAO;
using BuyGear.DTO;

namespace BuyGear.uc
{
    public partial class ucDuyetSP : UserControl
    {
        public ucDuyetSP(Form_Admin2 parent)
        {
            this.parent = parent;
            InitializeComponent();
        }
        Form_Admin2 parent;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Account.Instance.userName = Account.Instance.FindUsername(lbID.Text);
            Form_Infor2 f = new Form_Infor2() { TopLevel = false, TopMost = true };
            f.Dock = DockStyle.Fill;
            this.parent.panel2.Controls.Clear();
            this.parent.panel2.Controls.Add(f);
            f.Show();
        }

        private void picBan_Click(object sender, EventArgs e)
        {
            Form_SanPham f = new Form_SanPham(this.lbMaSP.Text, parent,1) { TopLevel = false, TopMost = true };
            f.Dock = DockStyle.Fill;
            f.bunifuButton1.Visible = f.bunifuButton2.Visible = false;
            this.parent.panel2.Controls.Clear();
            this.parent.panel2.Controls.Add(f);
            f.Show();
        }

        private void picChapNhan_Click(object sender, EventArgs e)
        {
            Data.Instance.CapNhatTrangThaiSP("da kiem duyet", lbMaSP.Text);
            parent.loadDuyetSP();
        }

        private void picTuChoi_Click(object sender, EventArgs e)
        {
            Data.Instance.CapNhatTrangThaiSP("tu choi kiem duyet", lbMaSP.Text);
            parent.loadDuyetSP();
        }
    }
}
