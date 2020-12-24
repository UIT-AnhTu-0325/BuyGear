
namespace BuyGear
{
    partial class Form_Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Setting));
            this.pnlName = new System.Windows.Forms.Panel();
            this.picName = new System.Windows.Forms.PictureBox();
            this.txtTenCH = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlTextName = new System.Windows.Forms.Panel();
            this.pnlSelect = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.pnlName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picName)).BeginInit();
            this.pnlSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlName
            // 
            this.pnlName.BackColor = System.Drawing.Color.White;
            this.pnlName.Controls.Add(this.picName);
            this.pnlName.Controls.Add(this.txtTenCH);
            this.pnlName.Controls.Add(this.lblName);
            this.pnlName.Controls.Add(this.pnlTextName);
            this.pnlName.Location = new System.Drawing.Point(54, 11);
            this.pnlName.Margin = new System.Windows.Forms.Padding(2);
            this.pnlName.Name = "pnlName";
            this.pnlName.Size = new System.Drawing.Size(447, 65);
            this.pnlName.TabIndex = 14;
            // 
            // picName
            // 
            this.picName.Image = ((System.Drawing.Image)(resources.GetObject("picName.Image")));
            this.picName.Location = new System.Drawing.Point(4, 14);
            this.picName.Margin = new System.Windows.Forms.Padding(2);
            this.picName.Name = "picName";
            this.picName.Size = new System.Drawing.Size(54, 49);
            this.picName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picName.TabIndex = 4;
            this.picName.TabStop = false;
            // 
            // txtTenCH
            // 
            this.txtTenCH.BackColor = System.Drawing.Color.White;
            this.txtTenCH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTenCH.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenCH.ForeColor = System.Drawing.Color.Navy;
            this.txtTenCH.Location = new System.Drawing.Point(185, 28);
            this.txtTenCH.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenCH.Name = "txtTenCH";
            this.txtTenCH.Size = new System.Drawing.Size(244, 22);
            this.txtTenCH.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblName.ForeColor = System.Drawing.Color.Navy;
            this.lblName.Location = new System.Drawing.Point(61, 28);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(56, 21);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            // 
            // pnlTextName
            // 
            this.pnlTextName.BackColor = System.Drawing.Color.Navy;
            this.pnlTextName.Location = new System.Drawing.Point(185, 50);
            this.pnlTextName.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTextName.Name = "pnlTextName";
            this.pnlTextName.Size = new System.Drawing.Size(244, 1);
            this.pnlTextName.TabIndex = 0;
            // 
            // pnlSelect
            // 
            this.pnlSelect.Controls.Add(this.btnExit);
            this.pnlSelect.Controls.Add(this.btnDangKy);
            this.pnlSelect.Location = new System.Drawing.Point(54, 80);
            this.pnlSelect.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSelect.Name = "pnlSelect";
            this.pnlSelect.Size = new System.Drawing.Size(447, 100);
            this.pnlSelect.TabIndex = 20;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnExit.ForeColor = System.Drawing.Color.Navy;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(254, 23);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(142, 65);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "   Thoát";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.Color.White;
            this.btnDangKy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDangKy.FlatAppearance.BorderSize = 0;
            this.btnDangKy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDangKy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKy.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDangKy.ForeColor = System.Drawing.Color.Navy;
            this.btnDangKy.Image = ((System.Drawing.Image)(resources.GetObject("btnDangKy.Image")));
            this.btnDangKy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangKy.Location = new System.Drawing.Point(28, 15);
            this.btnDangKy.Margin = new System.Windows.Forms.Padding(2);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(143, 73);
            this.btnDangKy.TabIndex = 0;
            this.btnDangKy.Text = "Thay đổi";
            this.btnDangKy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDangKy.UseVisualStyleBackColor = false;
            // 
            // Form_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(602, 189);
            this.Controls.Add(this.pnlSelect);
            this.Controls.Add(this.pnlName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Setting";
            this.pnlName.ResumeLayout(false);
            this.pnlName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picName)).EndInit();
            this.pnlSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlName;
        private System.Windows.Forms.PictureBox picName;
        public System.Windows.Forms.TextBox txtTenCH;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlTextName;
        public System.Windows.Forms.Panel pnlSelect;
        public System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.Button btnDangKy;
    }
}