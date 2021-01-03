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
    public partial class Invoice : Form
    {
        HoaDon _hd;
        public Invoice(HoaDon hd)
        {
            this._hd = hd;
            InitializeComponent();
            initDataGrid();
        }
        void initDataGrid()
        {
            this.dataGridView1.Rows.Add(_hd.Masp, _hd.Tensp, _hd.Soluong, _hd.Gia, _hd.TongCong);
        }
        public void PrintMe()
        {
            
            this.easyHTMLReports.Clear();
            this.easyHTMLReports.AddString("<h1>BUYGEAR</h1>");
            this.easyHTMLReports.AddString("<h3>Hóa đơn thanh toán</h3>");
            this.easyHTMLReports.AddString(string.Format("</p>Tên: {0}</p>", _hd.Tenngmua));
            this.easyHTMLReports.AddString(string.Format("</p>Địa chỉ: {0}</p>", _hd.Diachi));
            this.easyHTMLReports.AddString(string.Format("<p>Số điện thoại: </p>",_hd.SoDienThoai));
            this.easyHTMLReports.AddString(string.Format("<p>Số hóa đơn: #{0}</p>", _hd.Sohd));
            this.easyHTMLReports.AddString(string.Format("<p>Ngày đặt: {0}</p>", _hd.Nghdon));
            this.easyHTMLReports.AddString("<br>");
            this.easyHTMLReports.AddLineBreak();
            this.easyHTMLReports.AddDatagridView(this.dataGridView1);
            this.easyHTMLReports.AddString("<br>");
            this.easyHTMLReports.AddString(string.Format("<h4>Tổng cộng: {0} VNĐ</h4>", string.Format("{0:n0}", _hd.TongCong)));
            this.easyHTMLReports.AddString("<br>");
            this.easyHTMLReports.AddString("<p>Cảm ơn quý khách đã tin tưởng và đặt hàng tại shop!</p>");
            this.easyHTMLReports.AddString(string.Format("<p>Thắc mắc và phản hồi về sản phẩm vui lòng liên hệ: {0}", _hd.SoDienThoai));
            this.easyHTMLReports.ShowPrintPreviewDialog();
        }
    }
}
