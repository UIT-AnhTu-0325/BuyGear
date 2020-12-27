
namespace BuyGear
{
    partial class Form_XemTruocAddSanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_XemTruocAddSanPham));
            this.fpnlXemTruoc = new FlowPanelDB();
            this.lblhong = new Bunifu.UI.WinForms.BunifuLabel();
            this.flpnl1 = new FlowPanelDB();
            this.SuspendLayout();
            // 
            // fpnlXemTruoc
            // 
            this.fpnlXemTruoc.AutoScroll = true;
            this.fpnlXemTruoc.BackColor = System.Drawing.Color.White;
            this.fpnlXemTruoc.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fpnlXemTruoc.Location = new System.Drawing.Point(0, 0);
            this.fpnlXemTruoc.Name = "fpnlXemTruoc";
            this.fpnlXemTruoc.Size = new System.Drawing.Size(100, 100);
            this.fpnlXemTruoc.TabIndex = 11;
            this.fpnlXemTruoc.WrapContents = false;
            // 
            // lblhong
            // 
            this.lblhong.AutoEllipsis = false;
            this.lblhong.CursorType = null;
            this.lblhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhong.Location = new System.Drawing.Point(3, 3);
            this.lblhong.MaximumSize = new System.Drawing.Size(20, 0);
            this.lblhong.Name = "lblhong";
            this.lblhong.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblhong.Size = new System.Drawing.Size(20, 15);
            this.lblhong.TabIndex = 1;
            this.lblhong.Text = "332";
            this.lblhong.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblhong.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // flpnl1
            // 
            this.flpnl1.AutoScroll = true;
            this.flpnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpnl1.Location = new System.Drawing.Point(0, 0);
            this.flpnl1.Name = "flpnl1";
            this.flpnl1.Size = new System.Drawing.Size(630, 672);
            this.flpnl1.TabIndex = 0;
            // 
            // Form_XemTruocAddSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(630, 672);
            this.Controls.Add(this.flpnl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_XemTruocAddSanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_XemTruocAddSanPham";
            this.ResumeLayout(false);

        }

        #endregion
        private FlowPanelDB fpnlXemTruoc;
        private Bunifu.UI.WinForms.BunifuLabel lblhong;
        private FlowPanelDB flpnl1;
    }
}