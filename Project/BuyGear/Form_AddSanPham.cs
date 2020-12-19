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
using System.Diagnostics;
namespace BuyGear
{
    public partial class Form_AddSanPham : Form
    {
        Form_BanHang parent;
        string toDo = "";
        SanPham _spnow;
        public Form_AddSanPham(Form_BanHang parent)
        {
            toDo = "them";
            this.parent = parent;
            InitializeComponent();
            init();
            unvisibleAllPnl();
            unvisibleALLPicL();
            pnl_ThongTin.Visible = true;
            picL_ThongTin.Visible = true;
            btnExit.Visible = false;

        }
        public Form_AddSanPham(SanPham s,Form_BanHang parent)
        {
            this.parent = parent;
            toDo = "sua";
            _spnow = s;
            InitializeComponent();
            init();
            Loadsp();
            unvisibleAllPnl();
            unvisibleALLPicL();
            pnl_ThongTin.Visible = true;
            picL_ThongTin.Visible = true;
            
            
        }
        public void Loadsp()
        {
            switch (toDo)
            {
                case "them":
                    {
                        break;
                    }
                case "sua":
                    {
                        string temp;
                        switch (_spnow.LoaiSP)
                        {
                            case "ManHinh":
                                {
                                    temp = "Màn Hình";
                                    break;
                                }
                            case "BanPhim":
                                {
                                    temp = "Bàn Phím";
                                    break;
                                }
                            case "OCung":
                                {
                                    temp = "Ổ Cứng";
                                    break;
                                }
                            case "USB":
                                {
                                    temp = "USB";
                                    break;
                                }
                            case "Chuot":
                                {
                                    temp = "Chuột";
                                    break;
                                }
                            case "TanNhiet":
                                {
                                    temp = "Tản Nhiệt";
                                    break;
                                }
                            default:
                                {
                                    temp = "Khác";
                                    break;
                                }
                        }
                        txtLoaiSP.Text = temp;
                        txtMaSP.Text = _spnow.MASP;
                        txtTenSP.Text = _spnow.TenSP;
                        txtDVT.Text = _spnow.DVT;
                        txtXuatXu.Text = _spnow.XuatXu;
                        txtNhaSX.Text = _spnow.NhaSX;
                        txtSoLuong.Text = _spnow.SoLuong.ToString();
                        txtGiaBan.Text = _spnow.Gia.ToString();
                        txtGiaBanBuon.Text = _spnow.gia_banbuon.ToString();
                        txtGiaNhap.Text = _spnow.gia_nhap.ToString();
                        txtVat.Text = _spnow.VAT.ToString();
                        txtChiTiet.Text = _spnow.chitiet;
                        txtMaSP.Enabled = false;

                        image_1.Image = Picture.LoadImage_by_ID(_spnow.link_image[0]);
                        image_2.Image = Picture.LoadImage_by_ID(_spnow.link_image[1]);
                        image_3.Image = Picture.LoadImage_by_ID(_spnow.link_image[2]);
                        image_4.Image = Picture.LoadImage_by_ID(_spnow.link_image[3]);
                        break;

                    }
            }
        }
        void unvisibleAllPnl()
        {
            pnl_HinhAnh.Visible = false;
            pnl_MoTa.Visible = false;
            pnl_ThongTin.Visible = false;
        }
        void unvisibleALLPicL()
        {
            picL_HinhAnh.Visible = false;
            picL_MoTa.Visible = false;
            picL_ThongTin.Visible = false;
        }
        void init()
        {
            this.Controls.Add(pnl_ThongTin);
            this.Controls.Add(pnl_HinhAnh);
            this.Controls.Add(pnl_MoTa);
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.parent.LoadDS();
            this.Close();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            unvisibleAllPnl();
            unvisibleALLPicL();
            pnl_MoTa.Visible = true;
            picL_MoTa.Visible = true;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            unvisibleAllPnl();
            unvisibleALLPicL();
            pnl_ThongTin.Visible = true;
            picL_ThongTin.Visible = true;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            unvisibleAllPnl();
            unvisibleALLPicL();
            pnl_HinhAnh.Visible = true;
            picL_HinhAnh.Visible = true;
        }

        string getLink()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                return open.FileName;
            }
            else
            {
                return "";
            } 
        }

        void addPicture(int i)
        {
            string link = this.getLink();
            if (link == "")
            {
                return;
            }
            try
            {
                switch (i)
                {
                    case 1:
                        {
                            image_1.Image = new Bitmap(link);
                            break;
                        }
                    case 2:
                        {
                            image_2.Image = new Bitmap(link);
                            break;
                        }
                    case 3:
                        {
                            image_3.Image = new Bitmap(link);
                            break;
                        }
                    case 4:
                        {
                            image_4.Image = new Bitmap(link);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            catch
            {
                MessageBox.Show("Can't open this picture");
            }
        }
        SanPham s = new SanPham();
        private void btn_Pic1_Click(object sender, EventArgs e)
        {
            addPicture(1);
            
        }

        private void btn_Pic2_Click(object sender, EventArgs e)
        {
            addPicture(2);
        }

        private void btn_Pic3_Click(object sender, EventArgs e)
        {
            addPicture(3);
        }

        private void btn_Pic4_Click(object sender, EventArgs e)
        {
            addPicture(4);
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            
            string _loaisp;
            switch(txtLoaiSP.Text)
            {
                case "Màn Hình":
                    {
                        _loaisp = "ManHinh";
                        break;
                    }
                case "Bàn Phím":
                    {
                        _loaisp = "BanPhim";
                        break;
                    }
                case "Ổ Cứng":
                    {
                        _loaisp = "OCung";
                        break;
                    }
                case "USB":
                    {
                        _loaisp = "USB";
                        break;
                    }
                case "Chuột":
                    {
                        _loaisp = "Chuot";
                        break;
                    }
                case "Tản Nhiệt":
                    {
                        _loaisp = "TanNhiet";
                        break;
                    }
                default:
                    {
                        _loaisp = "Khac";
                        break;
                    }
            }
            s.setData(this.txtMaSP.Text, this.txtTenSP.Text, _loaisp, this.txtDVT.Text, this.txtXuatXu.Text, this.txtNhaSX.Text,
                Int32.Parse(this.txtSoLuong.Text), Int32.Parse(this.txtGiaBan.Text), this.txtChiTiet.Text, "0:0:0",
                "chua kiem duyet", parent._ID_me, 0, 0, 0);
            /*s.link_image.Add(Images.ImageToBinary(this.image_1.Image));
            s.link_image.Add(Images.ImageToBinary(this.image_2.Image));
            s.link_image.Add(Images.ImageToBinary(this.image_3.Image));
            s.link_image.Add(Images.ImageToBinary(this.image_4.Image));*/
            if (toDo == "them")
            {
                Data.Instance.UpSanPham(s);
                MessageBox.Show("Đăng bán sản phẩm thành công!!\n " +
                         "Sản phẩm sẽ được duyệt và bán!!");
            }
            
            if(toDo=="sua")
            {
                MessageBox.Show("Sửa thành công !!");
                Data.Instance.FixSanPham(s);
                parent.LoadDS();          
                this.Close();
            }
            foreach(Control c in this.Controls)
            {
                if(c is TextBox)
                {
                    c.Text = "";
                }    
            }    
        }
        bool isValid(char c)
        {
            int i;
            if (int.TryParse(c.ToString(), out i))
            {
                return true;
            }
            if (c == Convert.ToChar(8))
            {
                return true;
            }
            return false;
        }
        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !isValid(e.KeyChar);   
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !isValid(e.KeyChar);
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !isValid(e.KeyChar);
        }

        private void txtGiaBanBuon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !isValid(e.KeyChar);
        }

        private void txtVat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !isValid(e.KeyChar);
        }
        
    }
}
