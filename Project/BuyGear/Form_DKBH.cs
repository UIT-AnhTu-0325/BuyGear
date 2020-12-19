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
    public partial class Form_DKBH : Form
    {
        public Form_DKBH()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = Account.Instance.FindID();
            Account.Instance.DKBH(id, rdoCaNhan.Checked ? "Cá nhân" : "Công ty", cboxDiaChi.Text, txtTenCH.Text);
            if (MessageBox.Show("Đăng ký thành công, hãy chờ admin kiểm duyệt và bán hàng thôi!!", "Thông báo", MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Check()
        {
            if (txtTenCH.Text != "" && rdoCaNhan.Checked != rdoCongTy.Checked && rdoCo.Checked == true && chkDongY.Checked == true && cboxDiaChi.Text != "")
            {
                btnDangKy.Enabled = true;
            }
            else
                btnDangKy.Enabled = false;
        }

        private void txtTenCH_TextChanged(object sender, EventArgs e)
        {
            Check();
        }

        private void rdoCaNhan_CheckedChanged(object sender, EventArgs e)
        {
            Check();
        }

        private void Form_DKBH_Load(object sender, EventArgs e)
        {
            Account.Instance.userName = "meocon123";
        }
    }
}
