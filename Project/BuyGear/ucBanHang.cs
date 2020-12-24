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
    public partial class ucBanHang : UserControl
    {
        public ucBanHang(Form_Admin2 parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        Form_Admin2 parent;

        private void ucBanHang_Click(object sender, EventArgs e)
        {
            Account.Instance.userName = this.lbUser.Text;
            Form_Infor2 f = new Form_Infor2() { TopLevel = false, TopMost = true };
            f.Dock = DockStyle.Fill;
            f.btnUpdate.Visible = f.btnExit.Visible = f.chkChangePass.Visible = false;
            this.parent.panel2.Controls.Clear();
            this.parent.panel2.Controls.Add(f);
            f.Show();
        }

        private void picBan_Click(object sender, EventArgs e)
        {
            Form_DKBH f = new Form_DKBH() { TopLevel = false, TopMost = true };
            f.Dock = DockStyle.Fill;
            f.panel1.Visible = f.btnDangKy.Visible = false;
            f.txtTenCH.Enabled = f.rdoCaNhan.Enabled = f.rdoCongTy.Enabled = f.rdoCo.Enabled = f.rdoKhong.Enabled = f.cboxDiaChi.Enabled = false;
            DataRow row = Account.Instance.ShowTTCH(this.lbID.Text);
            f.txtTenCH.Text = row["tengianhang"].ToString();
            if (row["loaihinh"].ToString() == "Cá nhân")
            {
                f.rdoCaNhan.Checked = true;
            }
            else
                f.rdoCongTy.Checked = true;
            f.rdoCo.Checked = true;
            f.cboxDiaChi.Text = row["diachikho"].ToString();
            this.parent.panel2.Controls.Clear();
            this.parent.panel2.Controls.Add(f);
            f.Show();
        }

        private void picTuChoi_Click(object sender, EventArgs e)
        {
            Account.Instance.userName = lbUser.Text;
            Account.Instance.id = lbID.Text;
            if (MessageBox.Show("Bạn muốn xóa cửa hàng ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Data.Instance.XoaQuyenBH();
                parent.loadYeuCau();
            }
        }

        private void picChapNhan_Click(object sender, EventArgs e)
        {
            Account.Instance.userName = lbUser.Text;
            Account.Instance.id = lbID.Text;
            Data.Instance.CapNhatQuyenBH();
            parent.loadYeuCau();
        }

        private void picBan_MouseHover(object sender, EventArgs e)
        {
            picBan.Size = new Size(picBan.Size.Width + 5, picBan.Size.Height + 5);
        }
    }
}
