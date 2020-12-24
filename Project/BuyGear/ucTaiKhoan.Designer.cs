namespace BuyGear.uc
{
    partial class ucTaiKhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTaiKhoan));
            Bunifu.ToggleSwitch.ToggleState toggleState1 = new Bunifu.ToggleSwitch.ToggleState();
            Bunifu.ToggleSwitch.ToggleState toggleState2 = new Bunifu.ToggleSwitch.ToggleState();
            Bunifu.ToggleSwitch.ToggleState toggleState3 = new Bunifu.ToggleSwitch.ToggleState();
            this.lbID = new System.Windows.Forms.Label();
            this.lbUser = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picHuy = new System.Windows.Forms.PictureBox();
            this.picBan = new System.Windows.Forms.PictureBox();
            this.bunifuToggleSwitch1 = new Bunifu.ToggleSwitch.BunifuToggleSwitch();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picHuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbID.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbID.Location = new System.Drawing.Point(130, 3);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(85, 32);
            this.lbID.TabIndex = 1;
            this.lbID.Text = "12345";
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbUser.Location = new System.Drawing.Point(179, 35);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(69, 21);
            this.lbUser.TabIndex = 2;
            this.lbUser.Text = "tanhoai";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Indigo;
            this.label3.Location = new System.Drawing.Point(111, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hoạt động";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(93, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 21);
            this.label1.TabIndex = 22;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(92, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 32);
            this.label2.TabIndex = 21;
            this.label2.Text = "ID:";
            // 
            // picHuy
            // 
            this.picHuy.Image = ((System.Drawing.Image)(resources.GetObject("picHuy.Image")));
            this.picHuy.Location = new System.Drawing.Point(271, 13);
            this.picHuy.Name = "picHuy";
            this.picHuy.Size = new System.Drawing.Size(26, 28);
            this.picHuy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHuy.TabIndex = 6;
            this.picHuy.TabStop = false;
            this.picHuy.Visible = false;
            this.picHuy.Click += new System.EventHandler(this.picHuy_Click);
            // 
            // picBan
            // 
            this.picBan.Image = ((System.Drawing.Image)(resources.GetObject("picBan.Image")));
            this.picBan.Location = new System.Drawing.Point(280, 22);
            this.picBan.Name = "picBan";
            this.picBan.Size = new System.Drawing.Size(47, 46);
            this.picBan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBan.TabIndex = 5;
            this.picBan.TabStop = false;
            this.picBan.Visible = false;
            this.picBan.Click += new System.EventHandler(this.picBan_Click);
            this.picBan.MouseLeave += new System.EventHandler(this.picBan_MouseLeave);
            this.picBan.MouseHover += new System.EventHandler(this.picBan_MouseHover);
            // 
            // bunifuToggleSwitch1
            // 
            this.bunifuToggleSwitch1.Animation = 5;
            this.bunifuToggleSwitch1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuToggleSwitch1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuToggleSwitch1.BackgroundImage")));
            this.bunifuToggleSwitch1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuToggleSwitch1.Location = new System.Drawing.Point(213, 65);
            this.bunifuToggleSwitch1.Name = "bunifuToggleSwitch1";
            this.bunifuToggleSwitch1.Size = new System.Drawing.Size(35, 20);
            this.bunifuToggleSwitch1.TabIndex = 4;
            toggleState1.BackColor = System.Drawing.Color.Empty;
            toggleState1.BackColorInner = System.Drawing.Color.Empty;
            toggleState1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(0)))), ((int)(((byte)(140)))));
            toggleState1.BorderColorInner = System.Drawing.Color.Empty;
            toggleState1.BorderRadius = 1;
            toggleState1.BorderRadiusInner = 1;
            toggleState1.BorderThickness = 1;
            toggleState1.BorderThicknessInner = 1;
            this.bunifuToggleSwitch1.ToggleStateDisabled = toggleState1;
            toggleState2.BackColor = System.Drawing.Color.Empty;
            toggleState2.BackColorInner = System.Drawing.Color.Empty;
            toggleState2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(0)))), ((int)(((byte)(140)))));
            toggleState2.BorderColorInner = System.Drawing.Color.Empty;
            toggleState2.BorderRadius = 1;
            toggleState2.BorderRadiusInner = 1;
            toggleState2.BorderThickness = 1;
            toggleState2.BorderThicknessInner = 1;
            this.bunifuToggleSwitch1.ToggleStateOff = toggleState2;
            toggleState3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(45)))), ((int)(((byte)(145)))));
            toggleState3.BackColorInner = System.Drawing.Color.White;
            toggleState3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(45)))), ((int)(((byte)(145)))));
            toggleState3.BorderColorInner = System.Drawing.Color.White;
            toggleState3.BorderRadius = 17;
            toggleState3.BorderRadiusInner = 15;
            toggleState3.BorderThickness = 1;
            toggleState3.BorderThicknessInner = 1;
            this.bunifuToggleSwitch1.ToggleStateOn = toggleState3;
            this.bunifuToggleSwitch1.Value = true;
            this.bunifuToggleSwitch1.OnValuechange += new System.EventHandler(this.bunifuToggleSwitch1_OnValuechange);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ucTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picHuy);
            this.Controls.Add(this.picBan);
            this.Controls.Add(this.bunifuToggleSwitch1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.lbID);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ucTaiKhoan";
            this.Size = new System.Drawing.Size(335, 87);
            this.Click += new System.EventHandler(this.ucTaiKhoan_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picHuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbID;
        public System.Windows.Forms.Label lbUser;
        public System.Windows.Forms.Label label3;
        public Bunifu.ToggleSwitch.BunifuToggleSwitch bunifuToggleSwitch1;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.PictureBox picBan;
        public System.Windows.Forms.PictureBox picHuy;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
    }
}
