namespace BuyGear
{
    partial class ucRecommendSanPham
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
            this.lbName = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.picProduct = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.BackColor = System.Drawing.Color.White;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold);
            this.lbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbName.Location = new System.Drawing.Point(11, 149);
            this.lbName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbName.Name = "lbName";
            this.lbName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbName.Size = new System.Drawing.Size(188, 32);
            this.lbName.TabIndex = 25;
            this.lbName.Text = "Tên sản phẩm nè ";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbName.UseCompatibleTextRendering = true;
            this.lbName.Click += new System.EventHandler(this.picProduct_Click);
            // 
            // lbPrice
            // 
            this.lbPrice.BackColor = System.Drawing.Color.White;
            this.lbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lbPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(56)))), ((int)(((byte)(133)))));
            this.lbPrice.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbPrice.Location = new System.Drawing.Point(22, 180);
            this.lbPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbPrice.Size = new System.Drawing.Size(160, 31);
            this.lbPrice.TabIndex = 24;
            this.lbPrice.Text = "20.000 Đ";
            this.lbPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbPrice.UseCompatibleTextRendering = true;
            this.lbPrice.Click += new System.EventHandler(this.picProduct_Click);
            // 
            // picProduct
            // 
            this.picProduct.BackColor = System.Drawing.Color.White;
            this.picProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picProduct.Image = global::BuyGear.Properties.Resources.mh1;
            this.picProduct.Location = new System.Drawing.Point(26, 2);
            this.picProduct.Margin = new System.Windows.Forms.Padding(2);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(156, 144);
            this.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProduct.TabIndex = 23;
            this.picProduct.TabStop = false;
            this.picProduct.Click += new System.EventHandler(this.picProduct_Click);
            // 
            // ucRecommendSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.picProduct);
            this.Name = "ucRecommendSanPham";
            this.Size = new System.Drawing.Size(217, 214);
            this.Click += new System.EventHandler(this.picProduct_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lbName;
        public System.Windows.Forms.Label lbPrice;
        public System.Windows.Forms.PictureBox picProduct;
    }
}
