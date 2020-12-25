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
using System.Threading;
using LiveCharts.Wpf;
using LiveCharts;
using LiveCharts.Defaults;
using System.Windows.Media;

namespace BuyGear
{
    public partial class Form_BanHang : Form
    {
        public int _ID_me;
        public Form_BanHang(int ID_me)
        {
            this._ID_me = ID_me;
            InitializeComponent();
            bunifuPages1.PageIndex = 2;
            loadDataHome(); bunifuPages1.PageIndex = 0;
           // this.picAvatar.Image = Account.Instance.getAvatar();
        }
        public void LoadDS()
        {
            bunifuPages1.PageIndex = 2;
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
            bunifuPages1.PageIndex = 1;
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
            bunifuPages1.PageIndex = 2;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            pnlThongBao.Visible = false;
            timer1.Stop();
        }

        //Thống Kê
        Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            //Load Số Sản Phẩm
            bunifuPages1.PageIndex = 3;
            pageDS.Hide();
            LoadThongKe();
            pnlSelectMonth.Visible = false;
            LoadCharDTandSP();
            //Load hình tròn
            //ChartDH
            chartDH.LegendLocation = LegendLocation.Right;
            chartDH.Background = System.Windows.Media.Brushes.White;
            SeriesCollection series = new SeriesCollection();
            var tk = Data_ThongKe.getDataChartDH(_ID_me);
            foreach(var v in tk)
            {
                series.Add(new PieSeries() { Title = v.Key, Values = new ChartValues<int> { v.Value }, DataLabels = true, LabelPoint = labelPoint });
            }    
            chartDH.Series = series;
            //ChartSP
            ChartSP.LegendLocation = LegendLocation.Right;
            ChartSP.Background= System.Windows.Media.Brushes.White;
            SeriesCollection series2 = new SeriesCollection();
            var tk2 = Data_ThongKe.getDataChartSP(_ID_me);
            foreach(var v in tk2)
            {
                series2.Add(new PieSeries() { Title = v.Key, Values = new ChartValues<int> { v.Value }, DataLabels = true, LabelPoint = labelPoint });
            }
            ChartSP.Series = series2;
        }

        DateTime dtFrom = new DateTime(1900,1,1);
        DateTime dtTo = new DateTime(3000,1,1);
        private void LoadThongKe()
        {
            lblSumSP.Text = Data_ThongKe.CountSanPham(_ID_me, dtFrom, dtTo).ToString();
            lblSumDH.Text = Data_ThongKe.CountDonHangHoanThanh(_ID_me, dtFrom, dtTo).ToString();
            lblDHDangGiao.Text= Data_ThongKe.CountDonHangDangGiao(_ID_me, dtFrom, dtTo).ToString();
            lblDHTiepNhan.Text= Data_ThongKe.CountDonHangTiepNhan(_ID_me, dtFrom, dtTo).ToString();
            lblSumDT.Text= Data_ThongKe.CountDoanhThu(_ID_me, dtFrom, dtTo).ToString();
            lblDH_ChoXL.Text= Data_ThongKe.CountDonHangChoXuLy(_ID_me, dtFrom, dtTo).ToString();

        }
        private void rbtnSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnSelectAll.Checked == true)
            {
                dtFrom = new DateTime(1900, 1, 1);
                dtTo = new DateTime(3000, 1, 1);
                pnlSelectMonth.Visible = false;
                pnlTrang_Sort.Visible = false;
            }
            else
            {
                dtFrom = datePickFrom.Value.Date;
                dtTo = datePickTo.Value.Date;
                pnlSelectMonth.Visible = true;
                pnlTrang_Sort.Visible = true;
            }
           
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadThongKe();
        }
        private void datePickFrom_ValueChanged(object sender, EventArgs e)
        {
            dtFrom = datePickFrom.Value.Date;
        }
        private void datePickTo_ValueChanged(object sender, EventArgs e)
        {
            if(datePickTo.Value.Date< datePickFrom.Value.Date)
            {
                datePickTo.Value = datePickFrom.Value.Date;
            }
            dtTo = datePickTo.Value.Date;
        }
        int tempChart = 1;
        private void rbtnChart_DT_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtnChart_DT.Checked==true)
            {
                tempChart = 1;
            }
            else
            {
                tempChart = 2;
            }
            LoadCharDTandSP();
            
        }
        private void LoadCharDTandSP()
        {
            //Load đồ thị
            chartDT.Background = System.Windows.Media.Brushes.WhiteSmoke;
            if (tempChart == 1)
            {
                chartDT.AxisX.Clear();
                chartDT.AxisY.Clear();
                var series = new SeriesCollection();
                var line = new ChartValues<ObservablePoint>();
                int i = 0;
                foreach(var v in Data_ThongKe.getDataChartDT_DT(_ID_me))
                {
                    line.Add(new ObservablePoint(i, v.Value));
                    i++;
                }
                series.Add(new LineSeries { Title = "Doanh thu", Values = line, PointGeometrySize = 15 });
                chartDT.Series = series;
                var labe = new List<string>();
                foreach(var v in Data_ThongKe.getDataChartDT_DT(_ID_me))
                {
                    labe.Add(v.Key);
                }
                chartDT.AxisX.Add(new Axis
                {
                    Labels = labe
                });
                chartDT.AxisY.Add(new Axis
                {
                    Title = "VND",
                    LabelFormatter = value => value.ToString("")
                });
            }
            else
            {
                chartDT.AxisX.Clear();
                chartDT.AxisY.Clear();
                var series = new SeriesCollection();
                var line = new ChartValues<ObservablePoint>();
                int i = 0;
                foreach (var v in Data_ThongKe.getDataChartDT_SP(_ID_me))
                {
                    line.Add(new ObservablePoint(i, v.Value));
                    i++;
                }
                series.Add(new LineSeries { Title = "Số sản phẩm", Values = line, PointGeometrySize = 15 });
                chartDT.Series = series;
                var labe = new List<string>();
                foreach (var v in Data_ThongKe.getDataChartDT_SP(_ID_me))
                {
                    labe.Add(v.Key);
                }
                
                chartDT.AxisX.Add(new Axis
                {
                    Labels = labe,
                    LabelsRotation = 30
                }) ;
                chartDT.AxisY.Add(new Axis
                {
                    
                    Title = "",
                    LabelFormatter = value => value.ToString(),
                    
                }) ;
            }
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            bunifuPages1.PageIndex = 0;
            loadDataHome();
        }
        private void loadDataHome()
        {
            lblDonHangHome.Text = Data_ThongKe.CountDonHangTiepNhanToDay(_ID_me).ToString();
            lblSanPhamHome.Text = Data_ThongKe.CountSoSPDangBan(_ID_me).ToString();
            lblDoanhThuHome.Text = Data_ThongKe.CountDoanhThuToDay(_ID_me).ToString();

            chartDH_today.LegendLocation = LegendLocation.Right;
            chartDH_today.Background = System.Windows.Media.Brushes.White;
            SeriesCollection series = new SeriesCollection();
            var tk = Data_ThongKe.getDataChartDH(_ID_me);
            foreach (var v in tk)
            {
                series.Add(new PieSeries() { Title = v.Key, Values = new ChartValues<int> { v.Value }, DataLabels = true, LabelPoint = labelPoint });
            }
            chartDH_today.Series = series;
        }

        private void btnAD_Click(object sender, EventArgs e)
        {
            pnlInfor.Visible = !pnlInfor.Visible;
        }
    }

}
