using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._PL.Views
{
    public partial class ViewSanPham : UserControl
    {
        public ViewSanPham()
        {
            InitializeComponent();
        }
        public delegate void GetTitle(string title);
        public GetTitle Title;

        private void OpenUserControl(UserControl userControl)
        {
            this.pn_ViewSP.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            this.pn_ViewSP.Controls.Add(userControl);
        }
        private void tsmi_MauSac_Click(object sender, EventArgs e)
        {
            
        }

        private void tsmi_Size_Click(object sender, EventArgs e)
        {
            OpenUserControl(new QLSize());
            tsmi_Size.BackColor = Color.BlueViolet;
            tsmi_Size.ForeColor = Color.White;
            tsmi_MauSac.BackColor = SystemColors.Control;
            tsmi_MauSac.ForeColor = Color.Black;
            tsmi_ChatLieu.BackColor = SystemColors.Control;
            tsmi_ChatLieu.ForeColor = Color.Black;
            tsmi_Loai.BackColor = SystemColors.Control;
            tsmi_Loai.ForeColor = Color.Black;
            tsmi_Nsx.BackColor = SystemColors.Control;
            tsmi_Nsx.ForeColor = Color.Black;
            Title(tsmi_Size.Text);
        }

        private void tsmi_ChatLieu_Click(object sender, EventArgs e)
        {
            OpenUserControl(new QLChatLieu());
            tsmi_ChatLieu.BackColor = Color.BlueViolet;
            tsmi_ChatLieu.ForeColor = Color.White;
            tsmi_MauSac.BackColor = SystemColors.Control;
            tsmi_MauSac.ForeColor = Color.Black;
            tsmi_Size.BackColor = SystemColors.Control;
            tsmi_Size.ForeColor = Color.Black;
            tsmi_MauSac.BackColor = SystemColors.Control;
            tsmi_ChatLieu.ForeColor = Color.Black;
            tsmi_Loai.BackColor = SystemColors.Control;
            tsmi_Loai.ForeColor = Color.Black;
            tsmi_Nsx.BackColor = SystemColors.Control;
            tsmi_Nsx.ForeColor = Color.Black;
            Title(tsmi_ChatLieu.Text);
        }

        private void tsmi_Loai_Click(object sender, EventArgs e)
        {
            OpenUserControl(new QLLoaiSp());
            tsmi_Loai.BackColor = Color.BlueViolet;
            tsmi_Loai.ForeColor = Color.White;
            tsmi_Size.BackColor = SystemColors.Control;
            tsmi_Size.ForeColor = Color.Black;
            tsmi_ChatLieu.BackColor = SystemColors.Control;
            tsmi_ChatLieu.ForeColor = Color.Black;
            tsmi_MauSac.BackColor = SystemColors.Control;
            tsmi_MauSac.ForeColor = Color.Black;
            tsmi_Nsx.BackColor = SystemColors.Control;
            tsmi_Nsx.ForeColor = Color.Black;
            Title(tsmi_Loai.Text);
        }

        private void tsmi_Nsx_Click(object sender, EventArgs e)
        {
            OpenUserControl(new QLNsx());
            tsmi_Nsx.BackColor = Color.BlueViolet;
            tsmi_Nsx.ForeColor = Color.White;
            tsmi_Size.BackColor = SystemColors.Control;
            tsmi_Size.ForeColor = Color.Black;
            tsmi_ChatLieu.BackColor = SystemColors.Control;
            tsmi_ChatLieu.ForeColor = Color.Black;
            tsmi_Loai.BackColor = SystemColors.Control;
            tsmi_Loai.ForeColor = Color.Black;
            tsmi_MauSac.BackColor = SystemColors.Control;
            tsmi_MauSac.ForeColor = Color.Black;
            Title(tsmi_Nsx.Text);
        }
        private void tsmi_MauSac_Click_1(object sender, EventArgs e)
        {
            OpenUserControl(new QLMauSac());
            tsmi_MauSac.BackColor = Color.BlueViolet;
            tsmi_MauSac.ForeColor = Color.White;
            tsmi_Size.BackColor = SystemColors.Control;
            tsmi_Size.ForeColor = Color.Black;
            tsmi_ChatLieu.BackColor = SystemColors.Control;
            tsmi_ChatLieu.ForeColor = Color.Black;
            tsmi_Loai.BackColor = SystemColors.Control;
            tsmi_Loai.ForeColor = Color.Black;
            tsmi_Nsx.BackColor = SystemColors.Control;
            tsmi_Nsx.ForeColor = Color.Black;
            Title(tsmi_MauSac.Text);
        }
    }
}
