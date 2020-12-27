using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuTextbox;
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
    public partial class Form_XemTruocAddSanPham : Form
    {
        List<object> listObject;
        public Form_XemTruocAddSanPham(List<object> l)
        {
            InitializeComponent();
            this.listObject = l;
            xemtruoc();
        }
        private void xemtruoc()
        {
            flpnl1.Controls.Clear();
            foreach (object ob in listObject)
            {

                if (ob is BunifuTextBox)
                {
                    BunifuLabel lblmt = new BunifuLabel();
                    lblmt.Size = new Size(flpnl1.Width - 50, 1000);
                    BunifuTextBox temp = (BunifuTextBox)ob;
                    lblmt.Font = new Font("Arial", 12, FontStyle.Regular);
                    lblmt.Text = temp.Text;
                    this.flpnl1.Controls.Add(lblmt);
                }
                else if (ob is Image)
                {
                    PictureBox pic = new PictureBox();
                    Image img = (Image)ob;
                    pic.Size = new Size((flpnl1.Size.Width - 50), (flpnl1.Size.Width - 50) * img.Size.Height / img.Size.Width);
                    pic.Image = img;
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    this.flpnl1.Controls.Add(pic);
                }
            }
            flpnl1.VerticalScroll.Value = flpnl1.VerticalScroll.Maximum;

        }
    }
}
