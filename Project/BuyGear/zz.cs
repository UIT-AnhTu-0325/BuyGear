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
    public partial class zz : Form
    {
        public zz()
        {
            InitializeComponent();
            pictureBox1.Image = Picture.LoadImage_by_ID("19lEOMlm9XnZbDhKj-vbPl3Be_ZI3dHHm");
        }
    }
}
