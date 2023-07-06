namespace _3._PL.Views
{
    partial class ViewSanPham
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmi_MauSac = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Size = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ChatLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Loai = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Nsx = new System.Windows.Forms.ToolStripMenuItem();
            this.pn_ViewSP = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_MauSac,
            this.tsmi_Size,
            this.tsmi_ChatLieu,
            this.tsmi_Loai,
            this.tsmi_Nsx});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1249, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmi_MauSac
            // 
            this.tsmi_MauSac.Name = "tsmi_MauSac";
            this.tsmi_MauSac.Size = new System.Drawing.Size(77, 24);
            this.tsmi_MauSac.Text = "Màu sắc";
            this.tsmi_MauSac.Click += new System.EventHandler(this.tsmi_MauSac_Click_1);
            // 
            // tsmi_Size
            // 
            this.tsmi_Size.Name = "tsmi_Size";
            this.tsmi_Size.Size = new System.Drawing.Size(50, 24);
            this.tsmi_Size.Text = "Size";
            this.tsmi_Size.Click += new System.EventHandler(this.tsmi_Size_Click);
            // 
            // tsmi_ChatLieu
            // 
            this.tsmi_ChatLieu.Name = "tsmi_ChatLieu";
            this.tsmi_ChatLieu.Size = new System.Drawing.Size(84, 24);
            this.tsmi_ChatLieu.Text = "Chất Liệu";
            this.tsmi_ChatLieu.Click += new System.EventHandler(this.tsmi_ChatLieu_Click);
            // 
            // tsmi_Loai
            // 
            this.tsmi_Loai.Name = "tsmi_Loai";
            this.tsmi_Loai.Size = new System.Drawing.Size(51, 24);
            this.tsmi_Loai.Text = "Loại";
            this.tsmi_Loai.Click += new System.EventHandler(this.tsmi_Loai_Click);
            // 
            // tsmi_Nsx
            // 
            this.tsmi_Nsx.Name = "tsmi_Nsx";
            this.tsmi_Nsx.Size = new System.Drawing.Size(108, 24);
            this.tsmi_Nsx.Text = "Nhà sản xuất";
            this.tsmi_Nsx.Click += new System.EventHandler(this.tsmi_Nsx_Click);
            // 
            // pn_ViewSP
            // 
            this.pn_ViewSP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pn_ViewSP.Location = new System.Drawing.Point(0, 31);
            this.pn_ViewSP.Name = "pn_ViewSP";
            this.pn_ViewSP.Size = new System.Drawing.Size(1249, 966);
            this.pn_ViewSP.TabIndex = 3;
            // 
            // ViewSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pn_ViewSP);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ViewSanPham";
            this.Size = new System.Drawing.Size(1249, 997);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsmi_MauSac;
        private ToolStripMenuItem tsmi_Size;
        private ToolStripMenuItem tsmi_ChatLieu;
        private ToolStripMenuItem tsmi_Loai;
        private ToolStripMenuItem tsmi_Nsx;
        private Panel pn_ViewSP;
    }
}
