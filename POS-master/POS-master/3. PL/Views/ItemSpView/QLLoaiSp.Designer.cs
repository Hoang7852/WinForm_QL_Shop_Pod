namespace _3._PL.Views
{
    partial class QLLoaiSp
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_TimKiem = new System.Windows.Forms.TextBox();
            this.dgrid_LoaiSp = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Ten = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Ma = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtn_Show = new _3._PL.Controls.RJButton();
            this.rbtn_Clear = new _3._PL.Controls.RJButton();
            this.rbtn_Xoa = new _3._PL.Controls.RJButton();
            this.rbtn_Sua = new _3._PL.Controls.RJButton();
            this.rbtn_Them = new _3._PL.Controls.RJButton();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_LoaiSp)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txt_TimKiem);
            this.groupBox4.Controls.Add(this.dgrid_LoaiSp);
            this.groupBox4.Location = new System.Drawing.Point(3, 321);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1240, 470);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Location = new System.Drawing.Point(3, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.TabIndex = 39;
            this.label8.Text = "Tìm kiếm";
            // 
            // txt_TimKiem
            // 
            this.txt_TimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_TimKiem.Location = new System.Drawing.Point(79, 20);
            this.txt_TimKiem.Multiline = true;
            this.txt_TimKiem.Name = "txt_TimKiem";
            this.txt_TimKiem.Size = new System.Drawing.Size(399, 32);
            this.txt_TimKiem.TabIndex = 39;
            this.txt_TimKiem.Text = "Mời bạn nhập loại sản phẩm cần tìm ...";
            this.txt_TimKiem.Click += new System.EventHandler(this.txt_TimKiem_Click);
            this.txt_TimKiem.TextChanged += new System.EventHandler(this.txt_TimKiem_TextChanged);
            // 
            // dgrid_LoaiSp
            // 
            this.dgrid_LoaiSp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrid_LoaiSp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_LoaiSp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgrid_LoaiSp.Location = new System.Drawing.Point(3, 74);
            this.dgrid_LoaiSp.Name = "dgrid_LoaiSp";
            this.dgrid_LoaiSp.RowHeadersWidth = 51;
            this.dgrid_LoaiSp.RowTemplate.Height = 29;
            this.dgrid_LoaiSp.Size = new System.Drawing.Size(1234, 393);
            this.dgrid_LoaiSp.TabIndex = 0;
            this.dgrid_LoaiSp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_LoaiSp_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_Ten);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_Ma);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(616, 312);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập thông tin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tên";
            // 
            // txt_Ten
            // 
            this.txt_Ten.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_Ten.Location = new System.Drawing.Point(157, 188);
            this.txt_Ten.Multiline = true;
            this.txt_Ten.Name = "txt_Ten";
            this.txt_Ten.Size = new System.Drawing.Size(299, 49);
            this.txt_Ten.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mã";
            // 
            // txt_Ma
            // 
            this.txt_Ma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_Ma.Location = new System.Drawing.Point(157, 81);
            this.txt_Ma.Multiline = true;
            this.txt_Ma.Name = "txt_Ma";
            this.txt_Ma.Size = new System.Drawing.Size(299, 48);
            this.txt_Ma.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtn_Show);
            this.groupBox2.Controls.Add(this.rbtn_Clear);
            this.groupBox2.Controls.Add(this.rbtn_Xoa);
            this.groupBox2.Controls.Add(this.rbtn_Sua);
            this.groupBox2.Controls.Add(this.rbtn_Them);
            this.groupBox2.Location = new System.Drawing.Point(625, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(618, 312);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // rbtn_Show
            // 
            this.rbtn_Show.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rbtn_Show.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rbtn_Show.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rbtn_Show.BorderRadius = 20;
            this.rbtn_Show.BorderSize = 0;
            this.rbtn_Show.FlatAppearance.BorderSize = 0;
            this.rbtn_Show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtn_Show.ForeColor = System.Drawing.Color.White;
            this.rbtn_Show.Location = new System.Drawing.Point(177, 250);
            this.rbtn_Show.Name = "rbtn_Show";
            this.rbtn_Show.Size = new System.Drawing.Size(298, 50);
            this.rbtn_Show.TabIndex = 44;
            this.rbtn_Show.Text = "Show";
            this.rbtn_Show.TextColor = System.Drawing.Color.White;
            this.rbtn_Show.UseVisualStyleBackColor = false;
            this.rbtn_Show.Click += new System.EventHandler(this.rbtn_Show_Click_1);
            // 
            // rbtn_Clear
            // 
            this.rbtn_Clear.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rbtn_Clear.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rbtn_Clear.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rbtn_Clear.BorderRadius = 20;
            this.rbtn_Clear.BorderSize = 0;
            this.rbtn_Clear.FlatAppearance.BorderSize = 0;
            this.rbtn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtn_Clear.ForeColor = System.Drawing.Color.White;
            this.rbtn_Clear.Location = new System.Drawing.Point(177, 194);
            this.rbtn_Clear.Name = "rbtn_Clear";
            this.rbtn_Clear.Size = new System.Drawing.Size(298, 50);
            this.rbtn_Clear.TabIndex = 43;
            this.rbtn_Clear.Text = "Clear";
            this.rbtn_Clear.TextColor = System.Drawing.Color.White;
            this.rbtn_Clear.UseVisualStyleBackColor = false;
            this.rbtn_Clear.Click += new System.EventHandler(this.rbtn_Clear_Click_1);
            // 
            // rbtn_Xoa
            // 
            this.rbtn_Xoa.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rbtn_Xoa.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rbtn_Xoa.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rbtn_Xoa.BorderRadius = 20;
            this.rbtn_Xoa.BorderSize = 0;
            this.rbtn_Xoa.FlatAppearance.BorderSize = 0;
            this.rbtn_Xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtn_Xoa.ForeColor = System.Drawing.Color.White;
            this.rbtn_Xoa.Location = new System.Drawing.Point(177, 138);
            this.rbtn_Xoa.Name = "rbtn_Xoa";
            this.rbtn_Xoa.Size = new System.Drawing.Size(298, 50);
            this.rbtn_Xoa.TabIndex = 42;
            this.rbtn_Xoa.Text = "Xóa";
            this.rbtn_Xoa.TextColor = System.Drawing.Color.White;
            this.rbtn_Xoa.UseVisualStyleBackColor = false;
            this.rbtn_Xoa.Click += new System.EventHandler(this.rbtn_Xoa_Click_1);
            // 
            // rbtn_Sua
            // 
            this.rbtn_Sua.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rbtn_Sua.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rbtn_Sua.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rbtn_Sua.BorderRadius = 20;
            this.rbtn_Sua.BorderSize = 0;
            this.rbtn_Sua.FlatAppearance.BorderSize = 0;
            this.rbtn_Sua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtn_Sua.ForeColor = System.Drawing.Color.White;
            this.rbtn_Sua.Location = new System.Drawing.Point(177, 82);
            this.rbtn_Sua.Name = "rbtn_Sua";
            this.rbtn_Sua.Size = new System.Drawing.Size(298, 50);
            this.rbtn_Sua.TabIndex = 41;
            this.rbtn_Sua.Text = "Sửa";
            this.rbtn_Sua.TextColor = System.Drawing.Color.White;
            this.rbtn_Sua.UseVisualStyleBackColor = false;
            this.rbtn_Sua.Click += new System.EventHandler(this.rbtn_Sua_Click_1);
            // 
            // rbtn_Them
            // 
            this.rbtn_Them.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rbtn_Them.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rbtn_Them.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rbtn_Them.BorderRadius = 20;
            this.rbtn_Them.BorderSize = 0;
            this.rbtn_Them.FlatAppearance.BorderSize = 0;
            this.rbtn_Them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtn_Them.ForeColor = System.Drawing.Color.White;
            this.rbtn_Them.Location = new System.Drawing.Point(177, 26);
            this.rbtn_Them.Name = "rbtn_Them";
            this.rbtn_Them.Size = new System.Drawing.Size(298, 50);
            this.rbtn_Them.TabIndex = 40;
            this.rbtn_Them.Text = "Thêm";
            this.rbtn_Them.TextColor = System.Drawing.Color.White;
            this.rbtn_Them.UseVisualStyleBackColor = false;
            this.rbtn_Them.Click += new System.EventHandler(this.rbtn_Them_Click_1);
            // 
            // QLLoaiSp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Name = "QLLoaiSp";
            this.Size = new System.Drawing.Size(1249, 966);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_LoaiSp)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private GroupBox groupBox4;
        private Label label8;
        private TextBox txt_TimKiem;
        private DataGridView dgrid_LoaiSp;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox txt_Ten;
        private Label label1;
        private TextBox txt_Ma;
        private GroupBox groupBox2;
        private Controls.RJButton rbtn_Show;
        private Controls.RJButton rbtn_Clear;
        private Controls.RJButton rbtn_Xoa;
        private Controls.RJButton rbtn_Sua;
        private Controls.RJButton rbtn_Them;
    }
}
