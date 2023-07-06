namespace _3._PL.Component
{
    partial class CreateOrderSP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateOrderSP));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.imgImage = new _3._PL.Controls.RJCircularPictureBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImage)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 50;
            this.bunifuElipse1.TargetControl = this;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BorderRadius = 30;
            this.guna2Panel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.guna2Panel1.Controls.Add(this.lblCost);
            this.guna2Panel1.Controls.Add(this.lblTitle);
            this.guna2Panel1.Controls.Add(this.imgImage);
            this.guna2Panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Panel1.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(278, 142);
            this.guna2Panel1.TabIndex = 0;
            this.guna2Panel1.Click += new System.EventHandler(this.guna2Panel1_Click);
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCost.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCost.ForeColor = System.Drawing.Color.Red;
            this.lblCost.Location = new System.Drawing.Point(9, 113);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(83, 25);
            this.lblCost.TabIndex = 6;
            this.lblCost.Text = "350.000";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(9, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(80, 25);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Xtal Pro";
            // 
            // imgImage
            // 
            this.imgImage.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.imgImage.BorderColor = System.Drawing.Color.White;
            this.imgImage.BorderColor2 = System.Drawing.Color.White;
            this.imgImage.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.imgImage.BorderSize = 2;
            this.imgImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgImage.GradientAngle = 50F;
            this.imgImage.Image = ((System.Drawing.Image)(resources.GetObject("imgImage.Image")));
            this.imgImage.Location = new System.Drawing.Point(136, 3);
            this.imgImage.Name = "imgImage";
            this.imgImage.Size = new System.Drawing.Size(133, 133);
            this.imgImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgImage.TabIndex = 4;
            this.imgImage.TabStop = false;
            // 
            // CreateOrderSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "CreateOrderSP";
            this.Size = new System.Drawing.Size(283, 148);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        public System.Windows.Forms.Label lblCost;
        public System.Windows.Forms.Label lblTitle;
        public Controls.RJCircularPictureBox imgImage;
    }
}
