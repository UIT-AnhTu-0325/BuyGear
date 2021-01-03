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
using System.IO;
using Bunifu.UI.WinForms.BunifuTextbox;
using Bunifu.UI.WinForms;
using BuyGear.Something;

namespace BuyGear
{
    public partial class Form_AddSanPham : Form
    {
        Form_BanHang parent;
        string toDo = "";
        SanPham _spnow;
        List<string> linkPicture = new List<string>(0);
        List<string> linkPictureMoTa = new List<string>();
        public Form_AddSanPham(Form_BanHang parent)
        {
            toDo = "them";
            this.parent = parent;
            InitializeComponent();
            Page.PageIndex = 0;
            pnl_ThongTin.Visible = true;
            addtxt();
            btnExit.Visible = false;
            linkPicture.Add("");
            linkPicture.Add("");
            linkPicture.Add("");
            linkPicture.Add("");
            THongTin_click();
        }
        public Form_AddSanPham(SanPham s,Form_BanHang parent)
        {
            

            this.parent = parent;
            toDo = "sua";
            _spnow = s;
            InitializeComponent();
            Loadsp();
            Page.PageIndex = 0;

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
                        txtMaSP.Enabled = false;
                        
                        image_1.Image = Picture.LoadImage_by_ID(_spnow.link_image[0]);
                        image_2.Image = Picture.LoadImage_by_ID(_spnow.link_image[1]);
                        image_3.Image = Picture.LoadImage_by_ID(_spnow.link_image[2]);
                        image_4.Image = Picture.LoadImage_by_ID(_spnow.link_image[3]);

                        //load mo ta
                        List<string> listmota = new List<string>();
                        List<string> listHinhAnh = new List<string>();
                        listmota = Data.Instance.listMoTa(_spnow.MASP);
                        listHinhAnh = Data.Instance.listImageLink(_spnow.MASP);
                        int index = 0, i = 0, j = 0;
                        int.TryParse(_spnow.IndexMoTa, out index);
                        while (index != 0)
                        {
                            if (index % 10 == 1)
                            {
                                index = index / 10;

                                PanelDB pnl = new PanelDB();
                                pnl.Size = new Size(820, 210);
                                BunifuTextBox txtChiTietAdd = new BunifuTextBox();
                                #region itemTxt
                                txtChiTietAdd.AcceptsReturn = false;
                                txtChiTietAdd.AcceptsTab = false;
                                txtChiTietAdd.AnimationSpeed = 150;
                                txtChiTietAdd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
                                txtChiTietAdd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
                                txtChiTietAdd.BackColor = System.Drawing.Color.Transparent;
                                txtChiTietAdd.BorderColorActive = System.Drawing.Color.DodgerBlue;
                                txtChiTietAdd.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
                                txtChiTietAdd.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
                                txtChiTietAdd.BorderColorIdle = System.Drawing.Color.White;
                                txtChiTietAdd.BorderRadius = 1;
                                txtChiTietAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                txtChiTietAdd.BorderThickness = 2;
                                txtChiTietAdd.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
                                txtChiTietAdd.Cursor = System.Windows.Forms.Cursors.IBeam;
                                txtChiTietAdd.DefaultFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                txtChiTietAdd.DefaultText = "";
                                txtChiTietAdd.FillColor = System.Drawing.Color.White;
                                txtChiTietAdd.HideSelection = true;
                                txtChiTietAdd.IconLeft = null;
                                txtChiTietAdd.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
                                txtChiTietAdd.IconPadding = 10;
                                txtChiTietAdd.IconRight = null;
                                txtChiTietAdd.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
                                txtChiTietAdd.Lines = new string[0];
                                txtChiTietAdd.Location = new System.Drawing.Point(10, 10);
                                txtChiTietAdd.MaxLength = 32767;
                                txtChiTietAdd.MinimumSize = new System.Drawing.Size(100, 35);
                                txtChiTietAdd.Modified = false;
                                txtChiTietAdd.Multiline = true;
                                txtChiTietAdd.Name = "txtChiTiet";
                                txtChiTietAdd.PasswordChar = '\0';
                                txtChiTietAdd.PlaceholderForeColor = System.Drawing.Color.Silver;
                                txtChiTietAdd.PlaceholderText = "Nhập dữ liệu";
                                txtChiTietAdd.ReadOnly = false;
                                txtChiTietAdd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                                txtChiTietAdd.SelectedText = "";
                                txtChiTietAdd.SelectionLength = 0;
                                txtChiTietAdd.SelectionStart = 0;
                                txtChiTietAdd.ShortcutsEnabled = true;
                                txtChiTietAdd.Size = new System.Drawing.Size(690, 181);
                                txtChiTietAdd.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
                                txtChiTietAdd.TabIndex = 0;
                                txtChiTietAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
                                txtChiTietAdd.TextMarginBottom = 0;
                                txtChiTietAdd.TextMarginLeft = 5;
                                txtChiTietAdd.TextMarginTop = 0;
                                txtChiTietAdd.TextPlaceholder = "Enter text";
                                txtChiTietAdd.UseSystemPasswordChar = false;
                                txtChiTietAdd.WordWrap = true;
                                #endregion
                                this.fpnlTxt.Controls.Add(pnl);
                                txtChiTietAdd.Text = listmota[i++];
                                pnl.Controls.Add(txtChiTietAdd);
                                listTxtBox.Add(txtChiTietAdd);
                                listObject.Add(txtChiTietAdd);                       

                               
                            }
                            else if (index % 10 == 2)
                            {
                                index = index / 10;
                                PictureBox pic = new PictureBox();
                                pic.SizeMode = PictureBoxSizeMode.Zoom;
                                Image picLink = Picture.LoadImage_by_ID(listHinhAnh[j++]);
                                listObject.Add(picLink);
                                if (picLink.Width > fpnlTxt.Size.Width - 40)
                                {
                                    pic.Size = new Size(fpnlTxt.Size.Width - 40, (fpnlTxt.Size.Width - 40)
                                        * picLink.Size.Height / (picLink.Size.Width - 40));
                                }
                                else
                                {
                                    pic.Size = new Size(fpnlTxt.Size.Width - 40, fpnlTxt.Size.Height - 40);
                                }
                                pic.Image = picLink;
                                fpnlTxt.Controls.Add(pic);
                                listImage.Add(picLink);      
                                //linkPictureMoTa.Add(link);
                            }
                        }
                        this.indexMota = _spnow.IndexMoTa;
                        fpnlTxt.Controls.Remove(pnlAdd);
                        fpnlTxt.Controls.Add(pnlAdd);
                        fpnlTxt.VerticalScroll.Value = fpnlTxt.VerticalScroll.Maximum;
                        break;

                    }
            }
        }
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.parent.LoadDS();
            this.Close();
        }
        private void THongTin_click()
        {
            Page.PageIndex = 0;
            picThongTin.Image = BuyGear.Properties.Resources.B_loading;
            picThongTin.BackColor = Color.White;
            picHinhAnh.Image = BuyGear.Properties.Resources.B_watingg;
            picHinhAnh.BackColor = Color.DarkGray;
            picMoTa.Image = BuyGear.Properties.Resources.B_watingg;
            picMoTa.BackColor = Color.DarkGray;
            pnl1.BackColor = Color.Gray;
            pnl2.BackColor = Color.Gray;
            btnOK.Text = "Tiếp tục";
        }
        private void MoTa_click()
        {
            Page.PageIndex = 1;
            picMoTa.Image = BuyGear.Properties.Resources.B_loading;
            picMoTa.BackColor = Color.White;
            picThongTin.Image = BuyGear.Properties.Resources.B_checkk;
            picThongTin.BackColor = Color.White;
            picHinhAnh.Image = BuyGear.Properties.Resources.B_watingg;
            picHinhAnh.BackColor = Color.DarkGray;
            pnl1.BackColor = Color.White;
            pnl2.BackColor = Color.Gray;
            btnOK.Text = "Tiếp tục";
        }
        private void HinhAnh_click()
        {
            Page.PageIndex = 2;
            picHinhAnh.Image = BuyGear.Properties.Resources.B_loading;
            picHinhAnh.BackColor = Color.White;
            picThongTin.Image = BuyGear.Properties.Resources.B_checkk;
            picThongTin.BackColor = Color.White;
            picMoTa.Image = BuyGear.Properties.Resources.B_checkk;
            picMoTa.BackColor = Color.White;
            pnl2.BackColor = Color.White;
            pnl1.BackColor = Color.White;
            btnOK.Text = "Đăng";
        }
        private int index = 0;
        

        void addPicture(int i)
        {
            string link = Picture.getLinkFromDialog();
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
                            image_1.Image = Picture.FromFile(link);
                            linkPicture[0] = link;
                            break;
                        }
                    case 2:
                        {
                            image_2.Image = Picture.FromFile(link);
                            linkPicture[1] = link;
                            break;
                        }
                    case 3:
                        {
                            image_3.Image = Picture.FromFile(link);
                            linkPicture[2] = link;
                            break;
                        }
                    case 4:
                        {
                            image_4.Image = Picture.FromFile(link);
                            linkPicture[3] = link;
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
        bool checkFill()
        {
            if (txtLoaiSP.Text == "") return false;
            if (txtMaSP.Text == "") return false;
            if (txtTenSP.Text == "") return false;
            if (txtDVT.Text == "") return false;
            if (txtNhaSX.Text == "") return false;
            if (txtXuatXu.Text == "") return false;
            if (txtSoLuong.Text == "") return false;
            if (txtGiaBan.Text == "") return false;
            if (txtGiaNhap.Text == "") return false;
            if (txtGiaBanBuon.Text == "") return false;
            if (txtVat.Text == "") return false;
            if (linkPicture.Count != 4) return false;
            if (listObject.Count <= 0) return false;
            return true;
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            if(toDo=="sua")
            {
                MessageBox.Show("Sua thanh cong!");
                return;
            }    
            if(index==0)
            {
                MoTa_click();
                index++;
                return;
            }
            else if(index==1)
            {
                HinhAnh_click();
                index++;
                return;
            }
            if(!checkFill())
            {
                MessageBox.Show("Bạn cần điền đủ thông tin!");
                return;
            }
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
                Int32.Parse(this.txtSoLuong.Text), Int32.Parse(this.txtGiaBan.Text), this.indexMota, "0:0:0",
                "chua kiem duyet", parent._ID_me, 0, 0, 0);
            List<string> listmota = new List<string>();
            foreach (object ob in listObject)
            {
                if (ob is BunifuTextBox)
                {
                    BunifuTextBox txt = (BunifuTextBox)ob;
                    listmota.Add(txt.Text);
                }
            }
            if (toDo == "them")
            {
                Data.Instance.UpSanPham(s,linkPicture , linkPictureMoTa, listmota );
                MessageBox.Show("Đăng bán sản phẩm thành công!!\n " +
                         "Sản phẩm sẽ được duyệt và bán!!");
            }
            
            if(toDo=="sua")
            {
                MessageBox.Show("Sửa thành công !!");
                foreach (var v in s.link_image)
                {
                    Picture.DeletePicture_by_ID(v);
                }
                Data.Instance.FixSanPham(s, linkPicture);
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
        
        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Something.Utilities.isValid_forNumbertext(e.KeyChar);   
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Something.Utilities.isValid_forNumbertext(e.KeyChar);
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Something.Utilities.isValid_forNumbertext(e.KeyChar);
        }

        private void txtGiaBanBuon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Something.Utilities.isValid_forNumbertext(e.KeyChar);
        }

        private void txtVat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Something.Utilities.isValid_forNumbertext(e.KeyChar);
        }

        private void txtLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string masp = "";
            switch (txtLoaiSP.Text)
            {
                case "Màn Hình":
                    {
                        masp = "MH";
                        break;
                    }
                case "Bàn Phím":
                    {
                        masp = "BP";
                        break;
                    }
                case "Ổ Cứng":
                    {
                        masp = "OC";
                        break;
                    }
                case "USB":
                    {
                        masp = "USB";
                        break;
                    }
                case "Chuột":
                    {
                        masp = "C";
                        break;
                    }
                case "Tản Nhiệt":
                    {
                        masp = "TN";
                        break;
                    }
                default:
                    {
                        masp = "K";
                        break;
                    }
            }
            txtMaSP.Text = masp + Data.Instance.getlastIDSanPham().ToString();
        }
        private string indexMota;
        private List<BunifuTextBox> listTxtBox = new List<BunifuTextBox>();

        private void Form_AddSanPham_Load(object sender, EventArgs e)
        {
            btnAddtxb.PerformClick();

        }
        List<object> listObject = new List<object>();
        List<Image> listImage = new List<Image>();


        private void btnXemTruoc_Click(object sender, EventArgs e)
        {
            Form_XemTruocAddSanPham f = new Form_XemTruocAddSanPham(listObject);
            f.ShowDialog();
        }
        void addtxt()
        {
            indexMota = "1" + indexMota;
            PanelDB pnl = new PanelDB();
            pnl.Size = new Size(765, 210);
            /* BunifuImageButton btn = new BunifuImageButton();
             btn.ImageSize = new Size(50, 50);
             btn.Zoom = 10;
             btn.ImageZoomSize = new Size(60, 60);
             //btn.BackgroundImage = BuyGear.Properties.Resources.tick4;
             btn.Image = BuyGear.Properties.Resources.tick4;
             btn.Location = new Point(720, 35);*/
            BunifuTextBox txtChiTietAdd = new BunifuTextBox();
            #region itemTxt
            txtChiTietAdd.AcceptsReturn = false;
            txtChiTietAdd.AcceptsTab = false;
            txtChiTietAdd.AnimationSpeed = 150;
            txtChiTietAdd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            txtChiTietAdd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            txtChiTietAdd.BackColor = System.Drawing.Color.Transparent;
            txtChiTietAdd.BorderColorActive = System.Drawing.Color.DodgerBlue;
            txtChiTietAdd.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            txtChiTietAdd.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            txtChiTietAdd.BorderColorIdle = System.Drawing.Color.White;
            txtChiTietAdd.BorderRadius = 1;
            txtChiTietAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtChiTietAdd.BorderThickness = 2;
            txtChiTietAdd.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            txtChiTietAdd.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtChiTietAdd.DefaultFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtChiTietAdd.DefaultText = "";
            txtChiTietAdd.FillColor = System.Drawing.Color.White;
            txtChiTietAdd.HideSelection = true;
            txtChiTietAdd.IconLeft = null;
            txtChiTietAdd.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            txtChiTietAdd.IconPadding = 10;
            txtChiTietAdd.IconRight = null;
            txtChiTietAdd.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            txtChiTietAdd.Lines = new string[0];
            txtChiTietAdd.Location = new System.Drawing.Point(3, 3);
            txtChiTietAdd.MaxLength = 32767;
            txtChiTietAdd.MinimumSize = new System.Drawing.Size(100, 35);
            txtChiTietAdd.Modified = false;
            txtChiTietAdd.Multiline = true;
            txtChiTietAdd.Name = "txtChiTiet";
            txtChiTietAdd.PasswordChar = '\0';
            txtChiTietAdd.PlaceholderForeColor = System.Drawing.Color.Silver;
            txtChiTietAdd.PlaceholderText = "Nhập dữ liệu";
            txtChiTietAdd.ReadOnly = false;
            txtChiTietAdd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtChiTietAdd.SelectedText = "";
            txtChiTietAdd.SelectionLength = 0;
            txtChiTietAdd.SelectionStart = 0;
            txtChiTietAdd.ShortcutsEnabled = true;
            txtChiTietAdd.Size = new System.Drawing.Size(759, 185);
            txtChiTietAdd.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            txtChiTietAdd.TabIndex = 0;
            txtChiTietAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            txtChiTietAdd.TextMarginBottom = 0;
            txtChiTietAdd.TextMarginLeft = 5;
            txtChiTietAdd.TextMarginTop = 0;
            txtChiTietAdd.TextPlaceholder = "Nhập dữ liệu";
            txtChiTietAdd.UseSystemPasswordChar = false;
            txtChiTietAdd.WordWrap = true;
            #endregion
            this.fpnlTxt.Controls.Add(pnl);
            pnl.Controls.Add(txtChiTietAdd);
            listTxtBox.Add(txtChiTietAdd);
            listObject.Add(txtChiTietAdd);
            fpnlTxt.Controls.Remove(pnlAdd);
            fpnlTxt.Controls.Add(pnlAdd);
            fpnlTxt.VerticalScroll.Value = fpnlTxt.VerticalScroll.Maximum;
        }
        private void xemtruoc()
        {
            fpnlXemTruoc.Controls.Clear();
            foreach (object ob in listObject)
            {

                if (ob is BunifuTextBox)
                {
                    BunifuLabel lblmt = new BunifuLabel();
                    lblmt.Size = new Size(fpnlXemTruoc.Width - 50, 1000);
                    BunifuTextBox temp = (BunifuTextBox)ob;
                    lblmt.Font = new Font("Arial", 12, FontStyle.Regular);
                    lblmt.Text = temp.Text;
                    this.fpnlXemTruoc.Controls.Add(lblmt);
                }
                else if (ob is Image)
                {
                    PictureBox pic = new PictureBox();
                    Image img = (Image)ob;
                    pic.Size = new Size((fpnlXemTruoc.Size.Width - 50), (fpnlXemTruoc.Size.Width - 50) * img.Size.Height / img.Size.Width);
                    pic.Image = img;
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    this.fpnlXemTruoc.Controls.Add(pic);
                }
            }
            fpnlXemTruoc.VerticalScroll.Value = fpnlXemTruoc.VerticalScroll.Maximum;

        }
        private void btnAddtxb_Click_1(object sender, EventArgs e)
        {
            addtxt();
            xemtruoc();
        }

        private void btnAddPicture_Click_1(object sender, EventArgs e)
        {
            string link = Picture.getLinkFromDialog();
            if (link == "")
            {
                return;
            }
            try
            {
                PictureBox pic = new PictureBox();
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                Image picLink = Picture.FromFile(link);
                if (picLink.Width > fpnlTxt.Size.Width - 40)
                {
                    pic.Size = new Size(fpnlTxt.Size.Width - 40, (fpnlTxt.Size.Width - 40)
                        * picLink.Size.Height / (picLink.Size.Width - 40));
                }
                else
                {
                    pic.Size = new Size(fpnlTxt.Size.Width - 40, fpnlTxt.Size.Height - 40);
                }
                pic.Image = picLink;
                fpnlTxt.Controls.Add(pic);
                listImage.Add(picLink);
                listObject.Add(picLink);
                fpnlTxt.Controls.Remove(pnlAdd);
                fpnlTxt.Controls.Add(pnlAdd);
                fpnlTxt.VerticalScroll.Value = fpnlTxt.VerticalScroll.Maximum;
                indexMota = "2" + indexMota;
                linkPictureMoTa.Add(link);
                xemtruoc();

            }
            catch
            {
                MessageBox.Show("loi");
            }
        }
        
        private void picThongTin_Click(object sender, EventArgs e)
        {
            if(index==1)
            {
                THongTin_click();
                index = 0;
            }
        }

        private void picMoTa_Click(object sender, EventArgs e)
        {
            if(index==2)
            {
                MoTa_click();
                index = 1;
            }
        }

        private void picHinhAnh_Click(object sender, EventArgs e)
        {
            if(index==2)
            {
                index++;
                HinhAnh_click();
            }
        }

        private void txtTenSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLoaiSP.Focus();
            }
        }

        private void txtNhaSX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtXuatXu.Focus();
            }
        }

        private void txtGiaNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtGiaBan.Focus();
            }
        }

        private void txtXuatXu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtGiaNhap.Focus();
            }
        }

        private void txtGiaBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtGiaBanBuon.Focus();
            }
        }

        private void txtGiaBanBuon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtVat.Focus();
            }
        }
    }
}
