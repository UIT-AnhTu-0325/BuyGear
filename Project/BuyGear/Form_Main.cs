using System;
using System.Windows.Forms;

namespace BuyGear
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        //
        //Các hàm đặc trưng
        //

        //
        //Các Event của Control
        //

        private void btnMyInfor_Click(object sender, EventArgs e)
        {
            Form_Infor f = new Form_Infor();
            f.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát ứng dụng ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                this.Close();
        }


    }
}
