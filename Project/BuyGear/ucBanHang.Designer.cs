namespace BuyGear.uc
{
    partial class ucBanHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBanHang));
            this.lbUser = new System.Windows.Forms.Label();
            this.lbID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picTuChoi = new System.Windows.Forms.PictureBox();
            this.picChapNhan = new System.Windows.Forms.PictureBox();
            this.picBan = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picTuChoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChapNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbUser.Location = new System.Drawing.Point(183, 35);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(69, 21);
            this.lbUser.TabIndex = 11;
            this.lbUser.Text = "tanhoai";
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbID.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbID.Location = new System.Drawing.Point(135, 3);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(85, 32);
            this.lbID.TabIndex = 10;
            this.lbID.Text = "12345";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(95, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 32);
            this.label2.TabIndex = 19;
            this.label2.Text = "ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(96, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "Username:";
            // 
            // picTuChoi
            // 
            this.picTuChoi.Image = ((System.Drawing.Image)(resources.GetObject("picTuChoi.Image")));
            this.picTuChoi.Location = new System.Drawing.Point(231, 60);
            this.picTuChoi.Name = "picTuChoi";
            this.picTuChoi.Size = new System.Drawing.Size(36, 28);
            this.picTuChoi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTuChoi.TabIndex = 17;
            this.picTuChoi.TabStop = false;
            this.picTuChoi.Click += new System.EventHandler(this.picTuChoi_Click);
            // 
            // picChapNhan
            // 
            this.picChapNhan.Image = ((System.Drawing.Image)(resources.GetObject("picChapNhan.Image")));
            this.picChapNhan.Location = new System.Drawing.Point(173, 57);
            this.picChapNhan.Name = "picChapNhan";
            this.picChapNhan.Size = new System.Drawing.Size(37, 32);
            this.picChapNhan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picChapNhan.TabIndex = 16;
            this.picChapNhan.TabStop = false;
            this.picChapNhan.Click += new System.EventHandler(this.picChapNhan_Click);
            // 
            // picBan
            // 
            this.picBan.Image = ((System.Drawing.Image)(resources.GetObject("picBan.Image")));
            this.picBan.Location = new System.Drawing.Point(287, 19);
            this.picBan.Name = "picBan";
            this.picBan.Size = new System.Drawing.Size(40, 40);
            this.picBan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBan.TabIndex = 14;
            this.picBan.TabStop = false;
            this.picBan.Click += new System.EventHandler(this.picBan_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // ucBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picTuChoi);
            this.Controls.Add(this.picChapNhan);
            this.Controls.Add(this.picBan);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.lbID);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ucBanHang";
            this.Size = new System.Drawing.Size(340, 90);
            this.Click += new System.EventHandler(this.ucBanHang_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picTuChoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChapNhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox picTuChoi;
        public System.Windows.Forms.PictureBox picChapNhan;
        public System.Windows.Forms.PictureBox picBan;
        public System.Windows.Forms.Label lbUser;
        public System.Windows.Forms.Label lbID;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
    }
}
