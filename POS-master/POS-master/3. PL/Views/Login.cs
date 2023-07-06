using _2._BUS.IServices;
using _2._BUS.Services;
using _3._PL.Services;
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
    public partial class Login : Form
    {
        ITaiKhoanService _taiKhoanService;
        public Login()
        {
            InitializeComponent();
            _taiKhoanService = new TaiKhoanService();
            
        }

        private Form currentForm;
        private void OpenForm(Form frmNew)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = frmNew;
            frmNew.TopLevel = false;
            frmNew.Dock = DockStyle.Fill;
            pnl10.Controls.Add(frmNew);
            pnl10.Tag = frmNew;
            frmNew.BringToFront();
            frmNew.Show();
        }

        private void btn_Log_Click(object sender, EventArgs e)
        {
            var account = _taiKhoanService.GetAll().Where(x => x.TaiKhoan.Equals(tbx_User.Text, StringComparison.Ordinal) && x.MatKhau.Equals(tbx_PassWord.Text, StringComparison.Ordinal));
            if (account != null && account.Any())
            {
                var firstKhachHang = account.FirstOrDefault();
                if (firstKhachHang != null)
                {
                    Account.user1 = tbx_User.Text;
                    MessageBox.Show("Đăng nhập thành công!");
                    Dashboard frmMain = new Dashboard();
                    frmMain.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Tài khoản mật khẩu không chính xác!");
                tbx_User.Text = "";
                tbx_PassWord.Text = "";
            }
        }

        private void tbx_User_Click(object sender, EventArgs e)
        {
            tbx_User.Text = "";
        }

        private void tbx_PassWord_Click(object sender, EventArgs e)
        {
            tbx_PassWord.Text = "";
        }
    }
}
