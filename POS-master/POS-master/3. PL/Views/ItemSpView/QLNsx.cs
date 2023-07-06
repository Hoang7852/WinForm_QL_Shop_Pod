using _1._DAL.DBcontext;
using _2._BUS.IServices;
using _2._BUS.Services;
using _2._BUS.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._PL.Views
{
    public partial class QLNsx : UserControl
    {
        INsxService _insxService;
        Guid _id;
        public QLNsx()
        {
            InitializeComponent();
            _insxService = new NsxService();
        }
        public void LoadData()
        {
            int stt = 1;
            dgrid_Nsx.ColumnCount = 6;
            dgrid_Nsx.Columns[0].Name = "STT";
            dgrid_Nsx.Columns[1].Name = "Id";
            dgrid_Nsx.Columns[1].Visible = false;
            dgrid_Nsx.Columns[2].Name = "Mã";
            dgrid_Nsx.Columns[3].Name = "Tên";
            dgrid_Nsx.Columns[4].Name = "SĐT";
            dgrid_Nsx.Columns[5].Name = "Địa chỉ";
            dgrid_Nsx.Rows.Clear();
            var lstMauSac = _insxService.GetAll();
            if (txt_TimKiem.Text != "")
            {
                lstMauSac = lstMauSac.Where(x => x.Ten.ToLower().Contains(txt_TimKiem.Text.ToLower())).ToList();
            }
            foreach (var x in lstMauSac)
            {
                dgrid_Nsx.Rows.Add(stt++, x.Id, x.Ma, x.Ten,"0"+x.SDT,x.DiaChi);
            }
        }
        private void Clear()
        {
            txt_Ma.Text = "";
            txt_TimKiem.Text = "";
            txt_Ten.Text = "";
            txt_SDT.Text = "";
            txt_DiaChi.Text = "";
            _id = Guid.Empty;
        }


        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            int stt = 1;
            dgrid_Nsx.ColumnCount = 6;
            dgrid_Nsx.Columns[0].Name = "STT";
            dgrid_Nsx.Columns[1].Name = "Id";
            dgrid_Nsx.Columns[1].Visible = false;
            dgrid_Nsx.Columns[2].Name = "Mã";
            dgrid_Nsx.Columns[3].Name = "Tên";
            dgrid_Nsx.Columns[4].Name = "SĐT";
            dgrid_Nsx.Columns[5].Name = "Địa chỉ";
            dgrid_Nsx.Rows.Clear();
            var lstMauSac = _insxService.GetAll();
            if (txt_TimKiem.Text != "")
            {
                lstMauSac = lstMauSac.Where(x => x.Ten.ToLower().Contains(txt_TimKiem.Text.ToLower())).ToList();
            }
            foreach (var x in lstMauSac)
            {
                dgrid_Nsx.Rows.Add(stt++, x.Id, x.Ma, x.Ten,x.SDT,x.DiaChi);
            }
        }

        private void dgrid_Nsx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _id = Guid.Parse(dgrid_Nsx.CurrentRow.Cells[1].Value.ToString());
            var x = _insxService.GetAll().FirstOrDefault(x => x.Id == _id);
            txt_Ma.Text = x.Ma;
            txt_Ten.Text = x.Ten;
            txt_SDT.Text ="0"+x.SDT.ToString();
            txt_DiaChi.Text = x.DiaChi;
        }

        private void rbtn_Them_Click_1(object sender, EventArgs e)
        {
            var x = new NsxView()
            {
                Id = Guid.NewGuid(),
                Ma = txt_Ma.Text,
                Ten = txt_Ten.Text,
                SDT=Convert.ToInt32(txt_SDT.Text),
                DiaChi=txt_DiaChi.Text
            };
            if (_insxService.Add(x))
            {
                MessageBox.Show("Thêm thành công");
                Clear();
                LoadData();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void rbtn_Sua_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn sửa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var x = _insxService.GetAll().FirstOrDefault(x => x.Id == _id);
                x.Ten = txt_Ten.Text;
                x.Ma = txt_Ma.Text;
                x.SDT = Convert.ToInt32(txt_SDT.Text);
                x.DiaChi = txt_DiaChi.Text;

                if (_insxService.Update(x))
                {
                    MessageBox.Show("Sửa thành công");
                    LoadData();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
        }

        private void rbtn_Xoa_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //    var x = _insxService.GetAll().FirstOrDefault(x => x.Id == _id);
                //    if (_insxService.Delete(x))
                //    {
                //        MessageBox.Show("Xóa thành công");
                //        LoadData();
                //        Clear();
                //    }
                //    else
                //    {
                //        MessageBox.Show("Xóa thất bại");
                //    }
                //}
                using (var context = new DA1DBContext())
                {
                    var nsx = context.NSXes.Include(s => s.SanPhamChiTiets).SingleOrDefault(s => s.Id == _id);

                    if (nsx != null && nsx.SanPhamChiTiets.Any())
                    {
                        // Nếu đã được sử dụng, hiển thị thông báo cảnh báo
                        MessageBox.Show("Không thể xóa bản ghi này vì đã được sử dụng trong bảng Sản phẩm.");
                    }
                    else if (nsx != null)
                    {
                        // Nếu chưa được sử dụng, thực hiện xóa bản ghi
                        context.NSXes.Remove(nsx);
                        context.SaveChanges();
                        LoadData();
                        Clear();
                    }
                }
            }

        }

        private void rbtn_Clear_Click_1(object sender, EventArgs e)
        {
            txt_Ma.Text = "";
            txt_Ten.Text = "";
            txt_TimKiem.Text = "";
            txt_SDT.Text = "";
            txt_DiaChi.Text = "";
            dgrid_Nsx.Rows.Clear();
        }

        private void rbtn_Show_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txt_TimKiem_Click(object sender, EventArgs e)
        {
            txt_TimKiem.Text = "";
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Tạo biểu thức chính quy để kiểm tra định dạng số điện thoại
            // Biểu thức chính quy này sẽ kiểm tra xem số điện thoại có đúng định dạng 10 hoặc 11 số không
            string regexPattern = @"^(01[2689]|09)[0-9]{8}$";
            Regex regex = new Regex(regexPattern);

            // Kiểm tra xem số điện thoại có trùng khớp với biểu thức chính quy không
            if (regex.IsMatch(phoneNumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void txt_SDT_Leave(object sender, EventArgs e)
        {
            string phoneNumber = txt_SDT.Text;

            // Kiểm tra tính hợp lệ của số điện thoại
            if (IsValidPhoneNumber(phoneNumber))
            {
                // Số điện thoại hợp lệ
            }
            else
            {
                // Số điện thoại không hợp lệ
                MessageBox.Show("Số điện thoại nhập sai định dạng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
