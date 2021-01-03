namespace BuyGear
{
    partial class Form_DiaChiGiaoHang
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
            this.panelDB1 = new PanelDB();
            this.panelDB2 = new PanelDB();
            this.bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlLeft = new PanelDB();
            this.panelDB3 = new PanelDB();
            this.panelDB4 = new PanelDB();
            this.panelDB1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDB1
            // 
            this.panelDB1.BackColor = System.Drawing.Color.White;
            this.panelDB1.Controls.Add(this.panelDB2);
            this.panelDB1.Controls.Add(this.pictureBox2);
            this.panelDB1.Controls.Add(this.bunifuLabel2);
            this.panelDB1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDB1.Location = new System.Drawing.Point(0, 0);
            this.panelDB1.Name = "panelDB1";
            this.panelDB1.Size = new System.Drawing.Size(1022, 100);
            this.panelDB1.TabIndex = 1;
            // 
            // panelDB2
            // 
            this.panelDB2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelDB2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDB2.Location = new System.Drawing.Point(0, 97);
            this.panelDB2.Name = "panelDB2";
            this.panelDB2.Size = new System.Drawing.Size(1022, 3);
            this.panelDB2.TabIndex = 3;
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AutoEllipsis = false;
            this.bunifuLabel2.CursorType = null;
            this.bunifuLabel2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(129)))), ((int)(((byte)(191)))));
            this.bunifuLabel2.Location = new System.Drawing.Point(169, 34);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel2.Size = new System.Drawing.Size(239, 34);
            this.bunifuLabel2.TabIndex = 0;
            this.bunifuLabel2.Text = "ĐỊA CHỈ GIAO HÀNG";
            this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::BuyGear.Properties.Resources.locationshop1;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(89, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(46, 47);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 100);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(164, 454);
            this.pnlLeft.TabIndex = 2;
            // 
            // panelDB3
            // 
            this.panelDB3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelDB3.Location = new System.Drawing.Point(164, 100);
            this.panelDB3.Name = "panelDB3";
            this.panelDB3.Size = new System.Drawing.Size(194, 454);
            this.panelDB3.TabIndex = 3;
            // 
            // panelDB4
            // 
            this.panelDB4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDB4.Location = new System.Drawing.Point(358, 100);
            this.panelDB4.Name = "panelDB4";
            this.panelDB4.Size = new System.Drawing.Size(664, 454);
            this.panelDB4.TabIndex = 3;
            // 
            // Form_DiaChiGiaoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 554);
            this.Controls.Add(this.panelDB4);
            this.Controls.Add(this.panelDB3);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.panelDB1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_DiaChiGiaoHang";
            this.Text = "Form_DiaChiGiaoHang";
            this.panelDB1.ResumeLayout(false);
            this.panelDB1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PanelDB panelDB1;
        private PanelDB panelDB2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel2;
        private PanelDB pnlLeft;
        private PanelDB panelDB3;
        private PanelDB panelDB4;
    }
}