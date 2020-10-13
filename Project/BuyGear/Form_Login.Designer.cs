namespace BuyGear
{
    partial class Form_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Login));
            this.pnlUserName = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.pnlTextUserName = new System.Windows.Forms.Panel();
            this.pnlPass = new System.Windows.Forms.Panel();
            this.chkShowPass = new System.Windows.Forms.CheckBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.picPass = new System.Windows.Forms.PictureBox();
            this.pnlTextPass = new System.Windows.Forms.Panel();
            this.pnlSelect = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlUserName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.pnlPass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPass)).BeginInit();
            this.pnlSelect.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlUserName
            // 
            this.pnlUserName.BackColor = System.Drawing.Color.White;
            this.pnlUserName.Controls.Add(this.txtUsername);
            this.pnlUserName.Controls.Add(this.lblUser);
            this.pnlUserName.Controls.Add(this.picUser);
            this.pnlUserName.Controls.Add(this.pnlTextUserName);
            this.pnlUserName.Location = new System.Drawing.Point(12, 281);
            this.pnlUserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlUserName.Name = "pnlUserName";
            this.pnlUserName.Size = new System.Drawing.Size(531, 80);
            this.pnlUserName.TabIndex = 3;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtUsername.Location = new System.Drawing.Point(200, 30);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(240, 27);
            this.txtUsername.TabIndex = 3;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUser.Location = new System.Drawing.Point(81, 34);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(103, 28);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Tài khoản";
            // 
            // picUser
            // 
            this.picUser.ErrorImage = null;
            this.picUser.Image = ((System.Drawing.Image)(resources.GetObject("picUser.Image")));
            this.picUser.Location = new System.Drawing.Point(20, 15);
            this.picUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(55, 48);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUser.TabIndex = 1;
            this.picUser.TabStop = false;
            // 
            // pnlTextUserName
            // 
            this.pnlTextUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlTextUserName.Location = new System.Drawing.Point(200, 62);
            this.pnlTextUserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlTextUserName.Name = "pnlTextUserName";
            this.pnlTextUserName.Size = new System.Drawing.Size(240, 1);
            this.pnlTextUserName.TabIndex = 0;
            // 
            // pnlPass
            // 
            this.pnlPass.BackColor = System.Drawing.Color.White;
            this.pnlPass.Controls.Add(this.chkShowPass);
            this.pnlPass.Controls.Add(this.txtPass);
            this.pnlPass.Controls.Add(this.lblPass);
            this.pnlPass.Controls.Add(this.picPass);
            this.pnlPass.Controls.Add(this.pnlTextPass);
            this.pnlPass.Location = new System.Drawing.Point(12, 366);
            this.pnlPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlPass.Name = "pnlPass";
            this.pnlPass.Size = new System.Drawing.Size(531, 135);
            this.pnlPass.TabIndex = 4;
            // 
            // chkShowPass
            // 
            this.chkShowPass.AutoSize = true;
            this.chkShowPass.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkShowPass.Location = new System.Drawing.Point(296, 91);
            this.chkShowPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkShowPass.Name = "chkShowPass";
            this.chkShowPass.Size = new System.Drawing.Size(144, 27);
            this.chkShowPass.TabIndex = 4;
            this.chkShowPass.Text = "Hiện mật khẩu";
            this.chkShowPass.UseVisualStyleBackColor = true;
            this.chkShowPass.CheckedChanged += new System.EventHandler(this.chkShowPass_CheckedChanged);
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.White;
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPass.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPass.Location = new System.Drawing.Point(200, 30);
            this.txtPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(240, 27);
            this.txtPass.TabIndex = 3;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPass.Location = new System.Drawing.Point(81, 34);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(102, 28);
            this.lblPass.TabIndex = 2;
            this.lblPass.Text = "Mật khẩu";
            // 
            // picPass
            // 
            this.picPass.ErrorImage = null;
            this.picPass.Image = ((System.Drawing.Image)(resources.GetObject("picPass.Image")));
            this.picPass.Location = new System.Drawing.Point(20, 17);
            this.picPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picPass.Name = "picPass";
            this.picPass.Size = new System.Drawing.Size(55, 60);
            this.picPass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPass.TabIndex = 1;
            this.picPass.TabStop = false;
            // 
            // pnlTextPass
            // 
            this.pnlTextPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlTextPass.Location = new System.Drawing.Point(200, 62);
            this.pnlTextPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlTextPass.Name = "pnlTextPass";
            this.pnlTextPass.Size = new System.Drawing.Size(240, 1);
            this.pnlTextPass.TabIndex = 0;
            // 
            // pnlSelect
            // 
            this.pnlSelect.Controls.Add(this.btnExit);
            this.pnlSelect.Controls.Add(this.btnLogin);
            this.pnlSelect.Location = new System.Drawing.Point(12, 508);
            this.pnlSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSelect.Name = "pnlSelect";
            this.pnlSelect.Size = new System.Drawing.Size(531, 149);
            this.pnlSelect.TabIndex = 11;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(329, 38);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(139, 74);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Thoát";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.White;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(86, 38);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(180, 73);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Location = new System.Drawing.Point(12, 14);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(531, 261);
            this.pnlHeader.TabIndex = 12;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Snap ITC", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHeader.Location = new System.Drawing.Point(108, 148);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(304, 55);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "BUY GEAR";
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(561, 670);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSelect);
            this.Controls.Add(this.pnlPass);
            this.Controls.Add(this.pnlUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fLogin";
            this.pnlUserName.ResumeLayout(false);
            this.pnlUserName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.pnlPass.ResumeLayout(false);
            this.pnlPass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPass)).EndInit();
            this.pnlSelect.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUserName;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Panel pnlTextUserName;
        private System.Windows.Forms.Panel pnlPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.PictureBox picPass;
        private System.Windows.Forms.Panel pnlTextPass;
        private System.Windows.Forms.Panel pnlSelect;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        public System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.CheckBox chkShowPass;
    }
}