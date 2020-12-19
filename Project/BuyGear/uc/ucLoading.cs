using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuyGear.uc
{
    public partial class ucLoading : UserControl
    {
        public ucLoading()
        {
            InitializeComponent();
            colors.Add(Color.FromArgb(0, 150, 136));
            colors.Add(Color.FromArgb(0, 188,212));
            colors.Add(Color.FromArgb(63, 81, 181));
            colors.Add(Color.FromArgb(156,39,176));
            bunifuCircleProgressbar1.ProgressColor = colors[cur_color];
        }
        int dir = 1;
        List<Color> colors = new List<Color>();
        int cur_color =0;
        private void strecth_Tick(object sender, EventArgs e)
        {
            if (bunifuCircleProgressbar1.Value == 90)
            {
                dir = -1;
                bunifuCircleProgressbar1.animationIterval = 4;
                switch_color();
            }
            else if (bunifuCircleProgressbar1.Value == 10)
            {
                dir = 1;
                bunifuCircleProgressbar1.animationIterval = 2;
                switch_color();
            }
            
            bunifuCircleProgressbar1.Value += dir;
        }
        void switch_color()
        {
            bunifuColorTransition1.Color1 = colors[cur_color];
            if (cur_color < colors.Count - 1)
            {
                cur_color++;
            }
            else
            {
                cur_color = 0;
            }
            bunifuColorTransition1.Color2 = colors[cur_color];
            color_transit.Start();
        }

        private void color_transit_Tick(object sender, EventArgs e)
        {
            if(bunifuColorTransition1.ProgessValue<100)
            {
                bunifuColorTransition1.ProgessValue++;
                bunifuCircleProgressbar1.ProgressColor = bunifuColorTransition1.Value;
            }
            else
            {
                color_transit.Stop();
                bunifuColorTransition1.Color1 = bunifuColorTransition1.Color2;
                bunifuColorTransition1.ProgessValue = 0;
            }
        }
    }
}
