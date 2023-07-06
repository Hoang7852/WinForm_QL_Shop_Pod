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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            OpenForm(new BaoCaoDoanhThu());

        }

        private Form currentForm;
        private void OpenForm(Form frmChild)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = frmChild;
            frmChild.TopLevel = false;
            frmChild.Dock = DockStyle.Fill;
            panel_body.Controls.Add(frmChild);
            panel_body.Tag = frmChild;
            frmChild.BringToFront();
            frmChild.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenForm(new QuanLySanPham());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenForm(new BaoCaoDoanhThu());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenForm(new QuanLyKhachHang());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenForm(new QuanLyNhanVien());
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OpenForm(new POS());
        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
        }
    }
}
