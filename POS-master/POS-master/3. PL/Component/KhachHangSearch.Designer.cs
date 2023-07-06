namespace _3._PL.Component
{
    partial class KhachHangSearch
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
            this.components = new System.ComponentModel.Container();
            this.imgImage = new _3._PL.Controls.RJCircularPictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRank = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imgImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgImage
            // 
            this.imgImage.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.imgImage.BorderColor = System.Drawing.Color.RoyalBlue;
            this.imgImage.BorderColor2 = System.Drawing.Color.HotPink;
            this.imgImage.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.imgImage.BorderSize = 2;
            this.imgImage.GradientAngle = 50F;
            this.imgImage.Location = new System.Drawing.Point(54, 4);
            this.imgImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.imgImage.Name = "imgImage";
            this.imgImage.Size = new System.Drawing.Size(121, 121);
            this.imgImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgImage.TabIndex = 0;
            this.imgImage.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(18, 167);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(212, 32);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Nguyễn Minh Đức";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblRank);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblPhone);
            this.panel1.Controls.Add(this.imgImage);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 263);
            this.panel1.TabIndex = 2;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblRank
            // 
            this.lblRank.AutoSize = true;
            this.lblRank.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRank.Location = new System.Drawing.Point(158, 216);
            this.lblRank.Name = "lblRank";
            this.lblRank.Size = new System.Drawing.Size(48, 28);
            this.lblRank.TabIndex = 4;
            this.lblRank.Text = "15%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(144, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "-";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPhone.Location = new System.Drawing.Point(35, 216);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(119, 28);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "0338210398";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 30;
            this.bunifuElipse1.TargetControl = this;
            // 
            // KhachHangSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "KhachHangSearch";
            this.Size = new System.Drawing.Size(240, 273);
            ((System.ComponentModel.ISupportInitialize)(this.imgImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRank;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        public Controls.RJCircularPictureBox imgImage;
        public System.Windows.Forms.Label lblName;
        public System.Windows.Forms.Label lblPhone;
    }
}
