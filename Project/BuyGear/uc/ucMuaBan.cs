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
using System.IO;

namespace BuyGear
{
    public partial class ucMuaBan : UserControl
    {
        int _type;
        HoaDon _h;
        Form_BanHang _par;
        public ucMuaBan(int type,HoaDon h,Form_BanHang par)
        {
            _par = par;
            _type = type;
            _h = h;
            InitializeComponent();
            lblID_.Text += _h.ID_ngmua.ToString();
            lbldiachi.Text += _h.Diachi;
            lblName.Text += h.Tensp;
            lblNgaymua.Text += _h.Nghdon;
            lblSoLuong.Text += _h.Soluong.ToString();
            lblTriGia.Text += _h.TongCong.ToString();
            lbltenngmua.Text += _h.Tenngmua;
            picHinhAnh.Image = Picture.LoadImage_by_ID(_h.Image_sp);
            switch (_type)
            {
                case 1:
                    {
                        btnxacnhan.Text = "Xác nhận";
                        break;
                    }
                case 2:
                    {
                        btnxacnhan.Text = "Đã giao hàng";
                        break;
                    }
                default:
                    {
                        btnxacnhan.Visible = false;
                        break;
                    }
            }
        }

        private void btnxacnhan_Click(object sender, EventArgs e)
        {
            switch (_type)
            {
                case 1:
                    {
                        
                        Data.Instance.changetrangthai(_h.Sohd, _h.Masp, "dang giao hang");
                        _par.loadSanPham("cho xac nhan");
                        break;
                    }
                case 2:
                    {
                        
                        Data.Instance.changetrangthai(_h.Sohd, _h.Masp, "da giao hang");
                        _par.loadSanPham("dang giao hang");
                        break;
                    }
                default:
                    {
                        break;
                    }
                   
            }
            _par.pnlThongBao.Visible = true;
            timer1.Start();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Invoice i = new Invoice(_h);
            i.PrintMe();
            /*string hd = "Cua hang BUYGEAR" +
                "\nSố hóa đơn: " + _h.Sohd +
                "\nNgười mua: " + _h.Tenngmua +
                "\nNgày mua: " + _h.Nghdon +
                "\nSố lượng: " + _h.Soluong +
                "\nTổng giá: " + _h.Trigia +
                "\nCảm ơn quý khách!!" ;
            SaveFileDialog svg = new SaveFileDialog();
            svg.FileName = "hoadon";
            svg.ShowDialog();
            File.Create(svg.FileName + ".txt").Close();
            byte[] buffer = Encoding.ASCII.GetBytes(hd);
            File.WriteAllBytes(svg.FileName+".txt", buffer);*/
             
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _par.pnlThongBao.Visible = false;
            timer1.Stop();
        }
    }
}
