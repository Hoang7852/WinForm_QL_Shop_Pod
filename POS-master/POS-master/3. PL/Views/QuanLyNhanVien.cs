using _2._BUS.IServices;
using _2._BUS.Services;
using _2._BUS.ViewModel;
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
	public partial class QuanLyNhanVien : Form
	{
		INhanVienService _nhanVienService;
		ITaiKhoanService _taiKhoanService;
		Guid _id;
		Guid _idTk;
		private string imgLocation;
		public QuanLyNhanVien()
		{
			InitializeComponent();
			label11.Text = "Chức vụ";
			pnlInfo.Controls.Remove(rjButton15);
			_nhanVienService = new NhanVienService();
			_taiKhoanService = new TaiKhoanService();
			LoadData();
		}
		private void LoadData()
		{
			string columnName = "Column9";
			string columnName2 = "Column10";
			string columnName3 = "Column11";
			string columnName4 = "Column12";
			string columnName5 = "Column13";
			string columnName6 = "Column14";
			string columnName7 = "Column15";
			string columnName8 = "Column16";
			if (dgrid.Columns.Contains(columnName))
			{
				dgrid.Columns.Remove(columnName);
			}
			if (dgrid.Columns.Contains(columnName2))
			{
				dgrid.Columns.Remove(columnName2);
			}
			if (dgrid.Columns.Contains(columnName3))
			{
				dgrid.Columns.Remove(columnName3);
			}
			if (dgrid.Columns.Contains(columnName4))
			{
				dgrid.Columns.Remove(columnName4);
			}
			if (dgrid.Columns.Contains(columnName5))
			{
				dgrid.Columns.Remove(columnName5);
			}
			if (dgrid.Columns.Contains(columnName6))
			{
				dgrid.Columns.Remove(columnName6);
			}
			if (dgrid.Columns.Contains(columnName7))
			{
				dgrid.Columns.Remove(columnName7);
			}
			if (dgrid.Columns.Contains(columnName8))
			{
				dgrid.Columns.Remove(columnName8);
			}
			int stt = 1;
			dgrid.ColumnCount = 11;
			dgrid.Columns[0].Name = "STT";
			dgrid.Columns[1].Name = "ID";
			dgrid.Columns[1].Visible = false;
			dgrid.Columns[2].Name = "Mã";
			dgrid.Columns[3].Name = "Tên";
			dgrid.Columns[4].Name = "Số điện thoại";
			dgrid.Columns[5].Name = "Địa chỉ";
			dgrid.Columns[6].Name = "Link ảnh";
			dgrid.Columns[7].Name = "Trạng thái";
			dgrid.Columns[8].Name = "Chức vụ";
			dgrid.Columns[9].Name = "Tài khoản";
			dgrid.Columns[10].Name = "Mật khẩu";
			dgrid.Rows.Clear();

			List<NhanVienView> list = _nhanVienService.GetAllKH();
			List<NhanVienView> listTk = _taiKhoanService.GetAll();

			foreach (var x in list)
			{
				var y = listTk.FirstOrDefault(c=>c.Id_NV==x.ID);
					dgrid.Rows.Add(stt++, x.ID, x.Ma, x.Ten,"0"+x.SDT, x.DiaChi, x.LinkAnh, x.TrangThai == 0 ? "Làm việc" : "Thôi việc", y.ChucVu == 0 ? "Admin" : "Nhân viên", y.TaiKhoan, y.MatKhau);
					
				
			}
		}
		
		private void deleteSelectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				DialogResult dialogResult = MessageBox.Show("Xóa NHÂN VIÊN Đã Chọn", "CẢNH BÁO", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					foreach (object obj in this.dgrid.SelectedRows)
					{
						DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
						this.dgrid.Rows.RemoveAt(dataGridViewRow.Index);
					}
				}
			}
			catch
			{
			}
		}
		public void LoadAnh(ref string imgname)
		{
			OpenFileDialog fileimgname = new OpenFileDialog();
			if (fileimgname.ShowDialog() == DialogResult.OK)
			{
				imgname = fileimgname.FileName;
				imgLocation = fileimgname.FileName;
				picture1.SizeMode = PictureBoxSizeMode.StretchImage;
			}
		}
		private bool CheckMaSpTrung(string maNv)
		{
			// Kiểm tra xem mã sản phẩm đã tồn tại trong cơ sở dữ liệu chưa
			var nv = _nhanVienService.GetAllKH().FirstOrDefault(x => x.Ma == maNv);
			if (nv != null)
			{
				// Nếu tồn tại rồi thì thông báo và trả về false
				MessageBox.Show("Mã Nhân viên đã tồn tại!");
				return false;
			}
			return true;
		}
		private bool CheckTaiKhoanTrung (string taiKhoan)
		{
				// Kiểm tra xem mã sản phẩm đã tồn tại trong cơ sở dữ liệu chưa
				var tk = _taiKhoanService.GetAll().FirstOrDefault(x => x.TaiKhoan == taiKhoan);
				if (tk != null)
				{
					// Nếu tồn tại rồi thì thông báo và trả về false
					MessageBox.Show("Tài khoản đã tồn tại!");
					return false;
				}
				return true;
		}
		public bool check()
		{
			if (string.IsNullOrEmpty(tbx_Ma.Text))
			{
				MessageBox.Show("Mã sản phẩm không được bỏ trống", "Thông báo");
				return false;
			}
			if (string.IsNullOrEmpty(tbx_TenNV.Text))
			{
				MessageBox.Show("Tên sản phẩm không được bỏ trống", "Thông báo");
				return false;
			}

			if (string.IsNullOrEmpty(tbx_SDT.Text))
			{
				MessageBox.Show("Số điện thoại không được bỏ trống", "Thông báo");
				return false;
			}
			if (string.IsNullOrEmpty(txtDiaChi.Text))
			{
				MessageBox.Show("Địa chỉ không được bỏ trống", "Thông báo");
				return false;
			}
			if (string.IsNullOrEmpty(cmbGioiTinh.Text))
			{
				MessageBox.Show("Trạng thái không được bỏ trống", "Thông báo");
				return false;
			}
			if (string.IsNullOrEmpty(tbx_UserLogin.Text))
			{
				MessageBox.Show("Tài khoản không được bỏ trống", "Thông báo");
				return false;
			}
			if (string.IsNullOrEmpty(tbx_Password.Text))
			{
				MessageBox.Show("Mật khẩu không được bỏ trống", "Thông báo");
				return false;
			}
			if (string.IsNullOrEmpty(txtTenKH.Text))
			{
				MessageBox.Show("Chức vụ không được bỏ trống", "Thông báo");
				return false;
			}

			else
			{
				return true;
			}
		}

		private void dgrid_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dgrid.CurrentCell != null && dgrid.CurrentCell.Value != null)
			{
				_id = Guid.Parse(dgrid.CurrentRow.Cells[1].Value.ToString());
				var TC = _nhanVienService.GetAllKH().FirstOrDefault(p => p.ID.Equals(_id));
				var Tk = _taiKhoanService.GetAll().FirstOrDefault(c => c.Id_NV == TC.ID);
				tbx_Ma.Text = TC.Ma;
				tbx_TenNV.Text = TC.Ten;
				tbx_SDT.Text ="0"+TC.SDT.ToString();
				txtDiaChi.Text = TC.DiaChi.ToString();
				cmbGioiTinh.SelectedIndex = TC.TrangThai;
				txtTenKH.Text = Tk.ChucVu.ToString();
				tbx_UserLogin.Text = Tk.TaiKhoan;
				tbx_Password.Text = Tk.MatKhau;
				picture1.Image = Image.FromFile(TC.LinkAnh);
				imgLocation = TC.LinkAnh;
			}
		}

		private void deleteSelectToolStripMenuItem_Click_1(object sender, EventArgs e)
		{

		}

		private void tbx_SDT_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Kiểm tra xem phím vừa nhấn có phải là phím số hay không
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true; // Loại bỏ ký tự vừa nhập nếu không phải số
			}
		}

        private void picture1_Click(object sender, EventArgs e)
        {
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				picture1.Image = new Bitmap(fileDialog.FileName);
				imgLocation = fileDialog.FileName;
			}
		}

        private void rjButton17_Click_1(object sender, EventArgs e)
        {
			if (CheckMaSpTrung(tbx_Ma.Text) == false)
			{
				return;
			}
			if (CheckTaiKhoanTrung(tbx_UserLogin.Text) == false)
			{
				return;
			}
			if (check() == false)
			{
				return;
			}
			else
			{
				var x = new NhanVienView()
				{

					ID = Guid.NewGuid(),
					Ma = tbx_Ma.Text,
					Ten = tbx_TenNV.Text,
					SDT = Convert.ToInt32(tbx_SDT.Text),
					DiaChi = txtDiaChi.Text,
					LinkAnh = imgLocation,
					TrangThai = cmbGioiTinh.SelectedIndex,
				};
				var y = new NhanVienView()
				{
					IdTk = Guid.NewGuid(),
					MaTk = tbx_Ma.Text,
					TaiKhoan = tbx_UserLogin.Text,
					MatKhau=tbx_Password.Text,
					Id_NV=x.ID,
					ChucVu=Convert.ToInt32(txtTenKH.Text),
					TrangThaiTk=cmbGioiTinh.SelectedIndex,

				};
				if (_nhanVienService.Add(x))
				{
					_taiKhoanService.Add(y);
					MessageBox.Show("Thêm thành công");
					LoadData();
				}
				else
				{
					MessageBox.Show("Thêm thất bại");
				}
			}
		}

        private void rjButton1_Click_1(object sender, EventArgs e)
        {
			if (check() == false)
			{
				return;
			}
			else
			{
				var x = _nhanVienService.GetAllKH().FirstOrDefault(p => p.ID.Equals(_id));
				var y = _taiKhoanService.GetAll().FirstOrDefault(c => c.Id_NV == x.ID);
				x.Ma = tbx_Ma.Text;
				y.MaTk = x.Ma;
				x.Ten = tbx_TenNV.Text;
				x.SDT = Convert.ToInt32(tbx_SDT.Text);
				x.DiaChi = txtDiaChi.Text;
				x.TrangThai = cmbGioiTinh.SelectedIndex;
				x.LinkAnh = imgLocation;
				y.ChucVu =Convert.ToInt32(txtTenKH.Text);
				y.TaiKhoan = tbx_UserLogin.Text;
				y.MatKhau = tbx_Password.Text;
				y.TrangThaiTk = cmbGioiTinh.SelectedIndex;

				if (_nhanVienService.Update(x))
				{
					_taiKhoanService.Update(y);
					MessageBox.Show("Sửa thành công");
					LoadData();
				}
				else
				{
					MessageBox.Show("Sửa thất bại");
				}
			}
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
		private void tbx_SDT_Leave(object sender, EventArgs e)
        {
			string phoneNumber = tbx_SDT.Text;

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
