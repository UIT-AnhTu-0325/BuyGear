namespace BuyGear
{
    partial class ucThongBaoDonHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblXemChiTiet = new System.Windows.Forms.Label();
            this.lblXoa = new System.Windows.Forms.Label();
            this.picNew = new System.Windows.Forms.PictureBox();
            this.picTrangThai = new System.Windows.Forms.PictureBox();
            this.panelDB1 = new PanelDB();
            this.panelDB2 = new PanelDB();
            this.panelDB4 = new PanelDB();
            this.panelDB3 = new PanelDB();
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTrangThai)).BeginInit();
            this.panelDB1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblTime.Location = new System.Drawing.Point(31, 44);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(91, 20);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "20/12/2020";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblTitle.Location = new System.Drawing.Point(246, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(792, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Đơn hàng #35 đang được giao đến bạn, chuẩn bị số tiền 253.000 đồng để thanh toán " +
    "đồng để thanh toán d\r\n";
            // 
            // lblXemChiTiet
            // 
            this.lblXemChiTiet.AutoSize = true;
            this.lblXemChiTiet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblXemChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblXemChiTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblXemChiTiet.Location = new System.Drawing.Point(246, 55);
            this.lblXemChiTiet.Name = "lblXemChiTiet";
            this.lblXemChiTiet.Size = new System.Drawing.Size(107, 20);
            this.lblXemChiTiet.TabIndex = 0;
            this.lblXemChiTiet.Text = "Xem hóa đơn";
            this.lblXemChiTiet.Click += new System.EventHandler(this.lblXemChiTiet_Click);
            // 
            // lblXoa
            // 
            this.lblXoa.AutoSize = true;
            this.lblXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblXoa.Location = new System.Drawing.Point(370, 55);
            this.lblXoa.Name = "lblXoa";
            this.lblXoa.Size = new System.Drawing.Size(38, 20);
            this.lblXoa.TabIndex = 0;
            this.lblXoa.Text = "Xóa";
            this.lblXoa.Click += new System.EventHandler(this.lblXoa_Click);
            // 
            // picNew
            // 
            this.picNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picNew.Image = global::BuyGear.Properties.Resources.UI_new;
            this.picNew.Location = new System.Drawing.Point(0, 3);
            this.picNew.Name = "picNew";
            this.picNew.Size = new System.Drawing.Size(42, 38);
            this.picNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picNew.TabIndex = 1;
            this.picNew.TabStop = false;
            // 
            // picTrangThai
            // 
            this.picTrangThai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picTrangThai.Image = global::BuyGear.Properties.Resources.B_danggiao;
            this.picTrangThai.Location = new System.Drawing.Point(164, 23);
            this.picTrangThai.Name = "picTrangThai";
            this.picTrangThai.Size = new System.Drawing.Size(52, 52);
            this.picTrangThai.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTrangThai.TabIndex = 1;
            this.picTrangThai.TabStop = false;
            // 
            // panelDB1
            // 
            this.panelDB1.BackColor = System.Drawing.Color.White;
            this.panelDB1.Controls.Add(this.panelDB2);
            this.panelDB1.Controls.Add(this.panelDB4);
            this.panelDB1.Controls.Add(this.panelDB3);
            this.panelDB1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDB1.Location = new System.Drawing.Point(0, 108);
            this.panelDB1.Name = "panelDB1";
            this.panelDB1.Size = new System.Drawing.Size(1211, 4);
            this.panelDB1.TabIndex = 2;
            // 
            // panelDB2
            // 
            this.panelDB2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelDB2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDB2.Location = new System.Drawing.Point(84, 0);
            this.panelDB2.Name = "panelDB2";
            this.panelDB2.Size = new System.Drawing.Size(1020, 4);
            this.panelDB2.TabIndex = 0;
            // 
            // panelDB4
            // 
            this.panelDB4.BackColor = System.Drawing.Color.White;
            this.panelDB4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDB4.Location = new System.Drawing.Point(1104, 0);
            this.panelDB4.Name = "panelDB4";
            this.panelDB4.Size = new System.Drawing.Size(107, 4);
            this.panelDB4.TabIndex = 0;
            // 
            // panelDB3
            // 
            this.panelDB3.BackColor = System.Drawing.Color.White;
            this.panelDB3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelDB3.Location = new System.Drawing.Point(0, 0);
            this.panelDB3.Name = "panelDB3";
            this.panelDB3.Size = new System.Drawing.Size(84, 4);
            this.panelDB3.TabIndex = 0;
            // 
            // ucThongBaoDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelDB1);
            this.Controls.Add(this.picNew);
            this.Controls.Add(this.picTrangThai);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblXoa);
            this.Controls.Add(this.lblXemChiTiet);
            this.Controls.Add(this.lblTime);
            this.Name = "ucThongBaoDonHang";
            this.Size = new System.Drawing.Size(1211, 112);
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTrangThai)).EndInit();
            this.panelDB1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.PictureBox picTrangThai;
        private System.Windows.Forms.Label lblXemChiTiet;
        private System.Windows.Forms.Label lblXoa;
        private PanelDB panelDB1;
        private PanelDB panelDB2;
        private PanelDB panelDB4;
        private PanelDB panelDB3;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picNew;
    }
}
