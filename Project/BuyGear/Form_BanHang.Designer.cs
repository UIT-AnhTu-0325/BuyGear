namespace BuyGear
{
    partial class Form_BanHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Utilities.BunifuPages.BunifuAnimatorNS.Animation animation1 = new Utilities.BunifuPages.BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_BanHang));
            this.bunifuPages1 = new Bunifu.UI.WinForms.BunifuPages();
            this.Page_AddSP = new System.Windows.Forms.TabPage();
            this.pageDS = new System.Windows.Forms.TabPage();
            this.btnDSChoXacNhan = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnDSDangGiao = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnAddSP = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnDS = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pnlDS = new FlowPanelDB();
            this.btndagiao = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuPages1.SuspendLayout();
            this.pageDS.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuPages1
            // 
            this.bunifuPages1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.bunifuPages1.AllowTransitions = true;
            this.bunifuPages1.Controls.Add(this.Page_AddSP);
            this.bunifuPages1.Controls.Add(this.pageDS);
            this.bunifuPages1.Location = new System.Drawing.Point(308, 32);
            this.bunifuPages1.Multiline = true;
            this.bunifuPages1.Name = "bunifuPages1";
            this.bunifuPages1.Page = this.pageDS;
            this.bunifuPages1.PageIndex = 1;
            this.bunifuPages1.PageName = "pageDS";
            this.bunifuPages1.PageTitle = "tabPage2";
            this.bunifuPages1.SelectedIndex = 0;
            this.bunifuPages1.Size = new System.Drawing.Size(1062, 671);
            this.bunifuPages1.TabIndex = 2;
            animation1.AnimateOnlyDifferences = false;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.bunifuPages1.Transition = animation1;
            this.bunifuPages1.TransitionType = Utilities.BunifuPages.BunifuAnimatorNS.AnimationType.Custom;
            // 
            // Page_AddSP
            // 
            this.Page_AddSP.Location = new System.Drawing.Point(4, 4);
            this.Page_AddSP.Name = "Page_AddSP";
            this.Page_AddSP.Padding = new System.Windows.Forms.Padding(3);
            this.Page_AddSP.Size = new System.Drawing.Size(1054, 645);
            this.Page_AddSP.TabIndex = 0;
            this.Page_AddSP.Text = "tabPage1";
            this.Page_AddSP.UseVisualStyleBackColor = true;
            // 
            // pageDS
            // 
            this.pageDS.Controls.Add(this.pnlDS);
            this.pageDS.Location = new System.Drawing.Point(4, 4);
            this.pageDS.Name = "pageDS";
            this.pageDS.Padding = new System.Windows.Forms.Padding(3);
            this.pageDS.Size = new System.Drawing.Size(1054, 645);
            this.pageDS.TabIndex = 1;
            this.pageDS.Text = "tabPage2";
            this.pageDS.UseVisualStyleBackColor = true;
            // 
            // btnDSChoXacNhan
            // 
            this.btnDSChoXacNhan.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnDSChoXacNhan.BackColor = System.Drawing.Color.Transparent;
            this.btnDSChoXacNhan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDSChoXacNhan.BorderRadius = 5;
            this.btnDSChoXacNhan.ButtonText = "Danh sách chờ xác nhận";
            this.btnDSChoXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDSChoXacNhan.DisabledColor = System.Drawing.Color.Gray;
            this.btnDSChoXacNhan.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDSChoXacNhan.Iconimage = null;
            this.btnDSChoXacNhan.Iconimage_right = null;
            this.btnDSChoXacNhan.Iconimage_right_Selected = null;
            this.btnDSChoXacNhan.Iconimage_Selected = null;
            this.btnDSChoXacNhan.IconMarginLeft = 0;
            this.btnDSChoXacNhan.IconMarginRight = 0;
            this.btnDSChoXacNhan.IconRightVisible = true;
            this.btnDSChoXacNhan.IconRightZoom = 0D;
            this.btnDSChoXacNhan.IconVisible = true;
            this.btnDSChoXacNhan.IconZoom = 90D;
            this.btnDSChoXacNhan.IsTab = false;
            this.btnDSChoXacNhan.Location = new System.Drawing.Point(12, 146);
            this.btnDSChoXacNhan.Name = "btnDSChoXacNhan";
            this.btnDSChoXacNhan.Normalcolor = System.Drawing.Color.Transparent;
            this.btnDSChoXacNhan.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(56)))), ((int)(((byte)(133)))));
            this.btnDSChoXacNhan.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDSChoXacNhan.selected = false;
            this.btnDSChoXacNhan.Size = new System.Drawing.Size(277, 47);
            this.btnDSChoXacNhan.TabIndex = 8;
            this.btnDSChoXacNhan.Text = "Danh sách chờ xác nhận";
            this.btnDSChoXacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDSChoXacNhan.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(56)))), ((int)(((byte)(133)))));
            this.btnDSChoXacNhan.TextFont = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDSChoXacNhan.Click += new System.EventHandler(this.btnDSChoXacNhan_Click);
            // 
            // btnDSDangGiao
            // 
            this.btnDSDangGiao.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnDSDangGiao.BackColor = System.Drawing.Color.Transparent;
            this.btnDSDangGiao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDSDangGiao.BorderRadius = 5;
            this.btnDSDangGiao.ButtonText = "Danh sách đang giao";
            this.btnDSDangGiao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDSDangGiao.DisabledColor = System.Drawing.Color.Gray;
            this.btnDSDangGiao.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDSDangGiao.Iconimage = null;
            this.btnDSDangGiao.Iconimage_right = null;
            this.btnDSDangGiao.Iconimage_right_Selected = null;
            this.btnDSDangGiao.Iconimage_Selected = null;
            this.btnDSDangGiao.IconMarginLeft = 0;
            this.btnDSDangGiao.IconMarginRight = 0;
            this.btnDSDangGiao.IconRightVisible = true;
            this.btnDSDangGiao.IconRightZoom = 0D;
            this.btnDSDangGiao.IconVisible = true;
            this.btnDSDangGiao.IconZoom = 90D;
            this.btnDSDangGiao.IsTab = false;
            this.btnDSDangGiao.Location = new System.Drawing.Point(12, 199);
            this.btnDSDangGiao.Name = "btnDSDangGiao";
            this.btnDSDangGiao.Normalcolor = System.Drawing.Color.Transparent;
            this.btnDSDangGiao.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(56)))), ((int)(((byte)(133)))));
            this.btnDSDangGiao.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDSDangGiao.selected = false;
            this.btnDSDangGiao.Size = new System.Drawing.Size(261, 47);
            this.btnDSDangGiao.TabIndex = 7;
            this.btnDSDangGiao.Text = "Danh sách đang giao";
            this.btnDSDangGiao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDSDangGiao.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(56)))), ((int)(((byte)(133)))));
            this.btnDSDangGiao.TextFont = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDSDangGiao.Click += new System.EventHandler(this.btnDSDangGiao_Click);
            // 
            // btnAddSP
            // 
            this.btnAddSP.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnAddSP.BackColor = System.Drawing.Color.Transparent;
            this.btnAddSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddSP.BorderRadius = 5;
            this.btnAddSP.ButtonText = "Thêm Sản Phẩm";
            this.btnAddSP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddSP.DisabledColor = System.Drawing.Color.Gray;
            this.btnAddSP.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAddSP.Iconimage = null;
            this.btnAddSP.Iconimage_right = null;
            this.btnAddSP.Iconimage_right_Selected = null;
            this.btnAddSP.Iconimage_Selected = null;
            this.btnAddSP.IconMarginLeft = 0;
            this.btnAddSP.IconMarginRight = 0;
            this.btnAddSP.IconRightVisible = true;
            this.btnAddSP.IconRightZoom = 0D;
            this.btnAddSP.IconVisible = true;
            this.btnAddSP.IconZoom = 90D;
            this.btnAddSP.IsTab = false;
            this.btnAddSP.Location = new System.Drawing.Point(12, 39);
            this.btnAddSP.Name = "btnAddSP";
            this.btnAddSP.Normalcolor = System.Drawing.Color.Transparent;
            this.btnAddSP.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(56)))), ((int)(((byte)(133)))));
            this.btnAddSP.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAddSP.selected = false;
            this.btnAddSP.Size = new System.Drawing.Size(261, 48);
            this.btnAddSP.TabIndex = 6;
            this.btnAddSP.Text = "Thêm Sản Phẩm";
            this.btnAddSP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddSP.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(56)))), ((int)(((byte)(133)))));
            this.btnAddSP.TextFont = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSP.Click += new System.EventHandler(this.btnAddSP_Click);
            // 
            // btnDS
            // 
            this.btnDS.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnDS.BackColor = System.Drawing.Color.Transparent;
            this.btnDS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDS.BorderRadius = 5;
            this.btnDS.ButtonText = "Danh sách đang bán";
            this.btnDS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDS.DisabledColor = System.Drawing.Color.Gray;
            this.btnDS.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDS.Iconimage = null;
            this.btnDS.Iconimage_right = null;
            this.btnDS.Iconimage_right_Selected = null;
            this.btnDS.Iconimage_Selected = null;
            this.btnDS.IconMarginLeft = 0;
            this.btnDS.IconMarginRight = 0;
            this.btnDS.IconRightVisible = true;
            this.btnDS.IconRightZoom = 0D;
            this.btnDS.IconVisible = true;
            this.btnDS.IconZoom = 90D;
            this.btnDS.IsTab = false;
            this.btnDS.Location = new System.Drawing.Point(12, 93);
            this.btnDS.Name = "btnDS";
            this.btnDS.Normalcolor = System.Drawing.Color.Transparent;
            this.btnDS.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(56)))), ((int)(((byte)(133)))));
            this.btnDS.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDS.selected = false;
            this.btnDS.Size = new System.Drawing.Size(261, 47);
            this.btnDS.TabIndex = 5;
            this.btnDS.Text = "Danh sách đang bán";
            this.btnDS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDS.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(56)))), ((int)(((byte)(133)))));
            this.btnDS.TextFont = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDS.Click += new System.EventHandler(this.btnDS_Click);
            // 
            // pnlDS
            // 
            this.pnlDS.AutoScroll = true;
            this.pnlDS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDS.Location = new System.Drawing.Point(3, 3);
            this.pnlDS.Name = "pnlDS";
            this.pnlDS.Size = new System.Drawing.Size(1048, 639);
            this.pnlDS.TabIndex = 0;
            // 
            // btndagiao
            // 
            this.btndagiao.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btndagiao.BackColor = System.Drawing.Color.Transparent;
            this.btndagiao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btndagiao.BorderRadius = 5;
            this.btndagiao.ButtonText = "Danh sách đã giao";
            this.btndagiao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndagiao.DisabledColor = System.Drawing.Color.Gray;
            this.btndagiao.Iconcolor = System.Drawing.Color.Transparent;
            this.btndagiao.Iconimage = null;
            this.btndagiao.Iconimage_right = null;
            this.btndagiao.Iconimage_right_Selected = null;
            this.btndagiao.Iconimage_Selected = null;
            this.btndagiao.IconMarginLeft = 0;
            this.btndagiao.IconMarginRight = 0;
            this.btndagiao.IconRightVisible = true;
            this.btndagiao.IconRightZoom = 0D;
            this.btndagiao.IconVisible = true;
            this.btndagiao.IconZoom = 90D;
            this.btndagiao.IsTab = false;
            this.btndagiao.Location = new System.Drawing.Point(12, 252);
            this.btndagiao.Name = "btndagiao";
            this.btndagiao.Normalcolor = System.Drawing.Color.Transparent;
            this.btndagiao.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(56)))), ((int)(((byte)(133)))));
            this.btndagiao.OnHoverTextColor = System.Drawing.Color.White;
            this.btndagiao.selected = false;
            this.btndagiao.Size = new System.Drawing.Size(261, 47);
            this.btndagiao.TabIndex = 9;
            this.btndagiao.Text = "Danh sách đã giao";
            this.btndagiao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndagiao.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(56)))), ((int)(((byte)(133)))));
            this.btndagiao.TextFont = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndagiao.Click += new System.EventHandler(this.btndagiao_Click);
            // 
            // Form_BanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 715);
            this.Controls.Add(this.btndagiao);
            this.Controls.Add(this.btnDSChoXacNhan);
            this.Controls.Add(this.btnDSDangGiao);
            this.Controls.Add(this.btnAddSP);
            this.Controls.Add(this.btnDS);
            this.Controls.Add(this.bunifuPages1);
            this.Name = "Form_BanHang";
            this.Text = "Form_BanHang";
            this.bunifuPages1.ResumeLayout(false);
            this.pageDS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuPages bunifuPages1;
        private System.Windows.Forms.TabPage Page_AddSP;
        private System.Windows.Forms.TabPage pageDS;
        private Bunifu.Framework.UI.BunifuFlatButton btnDS;
        private Bunifu.Framework.UI.BunifuFlatButton btnAddSP;
        private FlowPanelDB pnlDS;
        private Bunifu.Framework.UI.BunifuFlatButton btnDSDangGiao;
        private Bunifu.Framework.UI.BunifuFlatButton btnDSChoXacNhan;
        private Bunifu.Framework.UI.BunifuFlatButton btndagiao;
    }
}