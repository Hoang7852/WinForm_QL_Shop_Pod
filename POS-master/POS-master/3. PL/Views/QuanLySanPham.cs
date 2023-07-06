using _1._DAL.DBcontext;
using _2._BUS.IServices;
using _2._BUS.Services;
using _2._BUS.ViewModel;
using _3._PL.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._PL.Views
{
	public partial class QuanLySanPham : Form
	{
		ISanPhamChiTietService _iSanPhamchiTietService;
		ISanPhamService _iSanPhamService;
		IMauSacService _iMauSacService;
		ISizeService _iSizeService;
		INsxService _iNsxService;
		IChatLieuService _iChatLieuService;
		ILoaiService _iLoaiService;
		IKhachHangService khachHangService;
		Guid _id;
		private string imgLocation;
		private string barcodeLocation;
		private string fileImg = "";
		public QuanLySanPham()
		{
			InitializeComponent();
			_iSanPhamchiTietService = new SanPhamChiTietService();
			_iSanPhamService = new SanPhamService();
			_iMauSacService = new MauSacService();
			_iSizeService = new SizeService();
			_iChatLieuService = new ChatLieuService();
			_iLoaiService = new LoaiService();
			_iNsxService = new NsxService();
			khachHangService = new KhachHangService();
			LoadData();
			LoadToCombobox();
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
			pnl_sP.Controls.Add(frmChild);
			pnl_sP.Tag = frmChild;
			frmChild.BringToFront();
			frmChild.Show();
		}

		private void btn_Add_Click(object sender, EventArgs e)
		{
			ViewSanPham viewSanPham = new ViewSanPham();
			viewSanPham.Title = new ViewSanPham.GetTitle(GetTitle);
			OpenUserControl(viewSanPham);
		}
		private void GetTitle(string title)
		{
			label1.Text = title;
		}

		private void OpenUserControl(UserControl userControl)
		{
			this.pnl_sP.Controls.Clear();
			userControl.Dock = DockStyle.Fill;
			this.pnl_sP.Controls.Add(userControl);
		}
		private void LoadData()
		{
			string columnName = "Column1";
			string columnName2 = "Column2";
			string columnName3 = "Column3";
			string columnName4 = "Column4";
			if (guna2DataGridView1.Columns.Contains(columnName))
			{
				guna2DataGridView1.Columns.Remove(columnName);
			}
			if (guna2DataGridView1.Columns.Contains(columnName2))
			{
				guna2DataGridView1.Columns.Remove(columnName2);
			}
			if (guna2DataGridView1.Columns.Contains(columnName3))
			{
				guna2DataGridView1.Columns.Remove(columnName3);
			}
			if (guna2DataGridView1.Columns.Contains(columnName4))
			{
				guna2DataGridView1.Columns.Remove(columnName4);
			}
			int stt = 1;
			guna2DataGridView1.ColumnCount = 14;
			guna2DataGridView1.Columns[0].Name = "STT";
			guna2DataGridView1.Columns[1].Name = "ID";
			guna2DataGridView1.Columns[1].Visible = false;
			guna2DataGridView1.Columns[2].Name = "Mã";
			guna2DataGridView1.Columns[3].Name = "Tên";
			guna2DataGridView1.Columns[4].Name = "Số lượng tồn";
			guna2DataGridView1.Columns[5].Name = "Giá nhập";
			guna2DataGridView1.Columns[6].Name = "Giá bán";
			guna2DataGridView1.Columns[7].Name = "Màu sắc";
			guna2DataGridView1.Columns[8].Name = "Chất liệu";
			guna2DataGridView1.Columns[9].Name = "Loại sản phẩm";
			guna2DataGridView1.Columns[10].Name = "Size";
			guna2DataGridView1.Columns[11].Name = "Nhà sản xuất";
			guna2DataGridView1.Columns[12].Name = "Trạng thái";
			guna2DataGridView1.Columns[13].Name = "Mô tả";
			guna2DataGridView1.Rows.Clear();

			List<SanPhamChiTietView> list = _iSanPhamchiTietService.GetAll();

			foreach (var x in list)
			{
				guna2DataGridView1.Rows.Add(stt++, x.Id, x.Ma, x.TenSp, x.SoLuongTon, x.GiaNhap, x.Gia,
									x.TenMauSac, x.TenChatLieu, x.TenLoai, x.TenSize, x.TenNsx, x.TrangThai == 0 ? "Còn hàng" : "Hết hàng", x.MoTa);
			}
		}
		private void LoadToCombobox()
		{
			foreach (var x in _iMauSacService.GetAll())
			{
				cmb_MauSac.Items.Add(x.Ten);
			}
			foreach (var x in _iChatLieuService.GetAll())
			{
				cmb_ChatLieu.Items.Add(x.Ten);
			}
			foreach (var x in _iLoaiService.GetAll())
			{
				cmb_LoaiSP.Items.Add(x.Ten);
			}
			foreach (var x in _iSizeService.GetAll())
			{
				cmb_Size.Items.Add(x.Ten);
			}
			foreach (var x in _iNsxService.GetAll())
			{
				cmb_NSX.Items.Add(x.Ten);
			}
		}
		public void LoadAnh(ref string imgname)
		{
			OpenFileDialog fileimgname = new OpenFileDialog();
			if (fileimgname.ShowDialog() == DialogResult.OK)
			{
				imgname = fileimgname.FileName;
				imgLocation = fileimgname.FileName;
				btn_Anh.SizeMode = PictureBoxSizeMode.StretchImage;
			}
		}
		public bool check()
		{
			if (string.IsNullOrEmpty(txtMa.Text))
			{
				MessageBox.Show("Mã sản phẩm không được bỏ trống", "Thông báo");
				return false;
			}
			if (string.IsNullOrEmpty(txtTenSP.Text))
			{
				MessageBox.Show("Tên sản phẩm không được bỏ trống", "Thông báo");
				return false;
			}

			if (string.IsNullOrEmpty(txtGiaNhap.Text))
			{
				MessageBox.Show("Giá nhập không được bỏ trống", "Thông báo");
				return false;
			}
			if (string.IsNullOrEmpty(txtGiaBan.Text))
			{
				MessageBox.Show("Giá bán không được bỏ trống", "Thông báo");
				return false;
			}

			if (string.IsNullOrEmpty(txtSLTon.Text))
			{
				MessageBox.Show("Số lượng không được bỏ trống", "Thông báo");
				return false;
			}

			if (string.IsNullOrEmpty(cmb_NSX.Text))
			{
				MessageBox.Show("Nhà sản xuất không được bỏ trống", "Thông báo");
				return false;
			}
			if (string.IsNullOrEmpty(cmb_MauSac.Text))
			{
				MessageBox.Show("Màu sắc không được bỏ trống", "Thông báo");
				return false;
			}
			if (string.IsNullOrEmpty(cmb_ChatLieu.Text))
			{
				MessageBox.Show("Chất liệu không được bỏ trống", "Thông báo");
				return false;
			}
			if (string.IsNullOrEmpty(cmb_LoaiSP.Text))
			{
				MessageBox.Show("Loại sản phẩn không được bỏ trống", "Thông báo");
				return false;
			}
			if (string.IsNullOrEmpty(cmb_Size.Text))
			{
				MessageBox.Show("Size sản phẩm không được bỏ trống", "Thông báo");
				return false;
			}
			if (string.IsNullOrEmpty(cmb_TrangThai.Text))
			{
				MessageBox.Show("Trạng thái không được bỏ trống", "Thông báo");
				return false;
			}

			else
			{
				return true;
			}
		}
		private bool CheckMaSpTrung(string maSp)
		{
			// Kiểm tra xem mã sản phẩm đã tồn tại trong cơ sở dữ liệu chưa
			var sp = _iSanPhamchiTietService.GetAll().FirstOrDefault(x => x.Ma == maSp);
			if (sp != null)
			{
				// Nếu tồn tại rồi thì thông báo và trả về false
				MessageBox.Show("Mã sản phẩm đã tồn tại!");
				return false;
			}
			return true;
		}

		private void rjButton16_Click(object sender, EventArgs e)
		{
			if (CheckMaSpTrung(txtMa.Text) == false)
			{
				return;
			}
			if (check() == false)
			{
				return;
			}
			else
			{
				var x = new SanPhamChiTietView()
				{

					Id = Guid.NewGuid(),
					ID_SP = Guid.NewGuid(),
					ID_MauSac = _iMauSacService.GetAll().FirstOrDefault(x => x.Ten == cmb_MauSac.Text).Id,
					ID_CL = _iChatLieuService.GetAll().FirstOrDefault(x => x.Ten == cmb_ChatLieu.Text).Id,
					ID_Loai = _iLoaiService.GetAll().FirstOrDefault(x => x.Ten == cmb_LoaiSP.Text).Id,
					ID_Size = _iSizeService.GetAll().FirstOrDefault(x => x.Ten == cmb_Size.Text).Id,
					ID_NSX = _iNsxService.GetAll().FirstOrDefault(x => x.Ten == cmb_NSX.Text).Id,
					Ma = txtMa.Text,
					TenSp = txtTenSP.Text,
					Gia = Convert.ToDouble(txtGiaBan.Text),
					GiaNhap = float.Parse(txtGiaNhap.Text),
					TenMauSac = cmb_MauSac.Text,
					TenChatLieu = cmb_ChatLieu.Text,
					TenLoai = cmb_ChatLieu.Text,
					TenSize = cmb_Size.Text,
					TenNsx = cmb_NSX.Text,
					SoLuongTon = Convert.ToInt32(txtSLTon.Text),
					MoTa = txtMoTa.Text,
					TrangThai = cmb_TrangThai.SelectedIndex,
					LinkAnh = imgLocation,
					MaVach = barcodeLocation,
				};
				if (_iSanPhamchiTietService.Add(x))
				{
					MessageBox.Show("Thêm thành công");
					LoadData();
				}
				else
				{
					MessageBox.Show("Thêm thất bại");
				}
			}
		}

		private void rjButton2_Click(object sender, EventArgs e)
		{
			if (check() == false)
			{
				return;
			}
			else
			{
				var x = _iSanPhamchiTietService.GetAll().FirstOrDefault(p => p.Id.Equals(_id));
				x.ID_MauSac = _iMauSacService.GetAll().FirstOrDefault(x => x.Ten == cmb_MauSac.Text).Id;
				x.ID_CL = _iChatLieuService.GetAll().FirstOrDefault(x => x.Ten == cmb_ChatLieu.Text).Id;
				x.ID_Loai = _iLoaiService.GetAll().FirstOrDefault(x => x.Ten == cmb_LoaiSP.Text).Id;
				x.ID_Size = _iSizeService.GetAll().FirstOrDefault(x => x.Ten == cmb_Size.Text).Id;
				x.ID_NSX = _iNsxService.GetAll().FirstOrDefault(x => x.Ten == cmb_NSX.Text).Id;
				x.Ma = txtMa.Text;
				x.TenSp = txtTenSP.Text;
				x.Gia = Convert.ToDouble(txtGiaBan.Text);
				x.GiaNhap = float.Parse(txtGiaNhap.Text);
				x.TenMauSac = cmb_MauSac.Text;
				x.TenChatLieu = cmb_ChatLieu.Text;
				x.TenLoai = cmb_LoaiSP.Text;
				x.TenSize = cmb_Size.Text;
				x.TenNsx = cmb_NSX.Text;
				x.SoLuongTon = Convert.ToInt32(txtSLTon.Text);
				x.MoTa = txtMoTa.Text;
				x.TrangThai = cmb_TrangThai.SelectedIndex;
				x.LinkAnh = imgLocation;
				x.MaVach = barcodeLocation;

				if (_iSanPhamchiTietService.Update(x))
				{
					MessageBox.Show("Sửa thành công");
					LoadData();
				}
				else
				{
					MessageBox.Show("Sửa thất bại");
				}
			}
		}

		private void xóaĐãChọnToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				using (var context = new DA1DBContext())
				{
					var sanPhamChiTiet = context.SanPhamChiTiets.Include(s => s.HoaDonChiTiets).SingleOrDefault(s => s.Id == _id);

					if (sanPhamChiTiet != null && sanPhamChiTiet.HoaDonChiTiets.Any())
					{
						// Nếu đã được sử dụng, hiển thị thông báo cảnh báo
						MessageBox.Show("Không thể xóa bản ghi này vì đã được sử dụng trong bảng Sản phẩm.");
					}
					else if (sanPhamChiTiet != null)
					{
						// Nếu chưa được sử dụng, thực hiện xóa bản ghi
						context.SanPhamChiTiets.Remove(sanPhamChiTiet);
						context.SaveChanges();
						LoadData();
					}
				}
			}
		}

		private void xóaTấtCảToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				List<Guid> selectedIds = new List<Guid>();
				foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
				{
					Guid id = (Guid)row.Cells["Id"].Value;
					selectedIds.Add(id);
				}

				// Tạo một đối tượng DbContext của Entity Framework
				using (var context = new DA1DBContext())
				{
					// Lặp qua danh sách các bản ghi đã chọn và kiểm tra xem sản phẩm có bị liên kết với bất kỳ hóa đơn chi tiết nào hay không
					foreach (Guid id in selectedIds)
					{
						// Tìm kiếm bản ghi với Id tương ứng
						var record = context.SanPhamChiTiets.FirstOrDefault(x => x.Id == id);

						if (record != null)
						{
							// Kiểm tra xem sản phẩm có bị liên kết với bất kỳ hóa đơn chi tiết nào hay không
							var relatedRecords = context.HoaDonChiTiets.Where(x => x.Id == id);

							if (relatedRecords.Any())
							{
								// Nếu sản phẩm đã được sử dụng trong một hoặc nhiều hóa đơn, hiển thị một hộp thoại cảnh báo và không cho phép người dùng xóa sản phẩm
								MessageBox.Show("Sản phẩm đang được sử dụng trong một hoặc nhiều hóa đơn. Không thể xóa sản phẩm này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								return;
							}
							else
							{
								// Nếu sản phẩm chưa được sử dụng trong bất kỳ hóa đơn nào, tiếp tục thực hiện xóa sản phẩm
								context.SanPhamChiTiets.Remove(record);
							}
						}
					}

					// Lưu các thay đổi vào cơ sở dữ liệu
					context.SaveChanges();
				}

				// Refresh lại dữ liệu trên DataGridView
				LoadData();

			}
		}

		private void btn_Anh_Click(object sender, EventArgs e)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				btn_Anh.Image = new Bitmap(fileDialog.FileName);
				imgLocation = fileDialog.FileName;
			}
		}

		private void guna2PictureBox2_Click(object sender, EventArgs e)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp, *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				guna2PictureBox2.Image = Image.FromFile(fileDialog.FileName);
				barcodeLocation = fileDialog.FileName;
			}
		}

		private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (guna2DataGridView1.CurrentCell != null && guna2DataGridView1.CurrentCell.Value != null)
			{
				_id = Guid.Parse(guna2DataGridView1.CurrentRow.Cells[1].Value.ToString());
				var TC = _iSanPhamchiTietService.GetAll().FirstOrDefault(p => p.Id.Equals(_id));
				txtMa.Text = TC.Ma;
				txtTenSP.Text = TC.TenSp;
				txtSLTon.Text = TC.SoLuongTon.ToString();
				txtGiaNhap.Text = TC.GiaNhap.ToString();
				txtGiaBan.Text = TC.Gia.ToString();
				cmb_MauSac.Text = TC.TenMauSac;
				cmb_ChatLieu.Text = TC.TenChatLieu;
				cmb_LoaiSP.Text = TC.TenLoai;
				cmb_Size.Text = TC.TenSize;
				cmb_NSX.Text = TC.TenNsx;
				cmb_TrangThai.SelectedIndex = TC.TrangThai;
				txtMoTa.Text = TC.MoTa;
				btn_Anh.Image = Image.FromFile(TC.LinkAnh);
				guna2PictureBox2.Image = Image.FromFile(TC.MaVach);
				imgLocation = TC.LinkAnh;
				barcodeLocation = TC.MaVach;
			}
		}

		private void txtSLTon_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Kiểm tra xem phím vừa nhấn có phải là phím số hay không
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true; // Loại bỏ ký tự vừa nhập nếu không phải số
			}
		}

		private void txtSLTon_Leave(object sender, EventArgs e)
		{
			// Kiểm tra giá trị nhập vào có phải là số nguyên dương hay không
			int value;
			if (!int.TryParse(((TextBox)sender).Text, out value) || value <= 0)
			{
				if (((TextBox)sender).Focused)
				{
					MessageBox.Show("Vui lòng nhập số nguyên dương!", "Lỗi",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					((TextBox)sender).Focus();
				}
				((TextBox)sender).Text = ""; // Xóa giá trị nhập vào nếu không phải số nguyên dương
			}
		}

		private void txtMa_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Kiểm tra nếu ký tự được nhập là ký tự đặc biệt và không phải phím điều hướng hoặc phím backspace, loại bỏ nó.
			if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
			{
				e.Handled = true;
			}
			// Kiểm tra nếu ký tự được nhập là phím backspace hoặc phím điều hướng, chấp nhận nó.
			else if (char.IsControl(e.KeyChar))
			{
				e.Handled = false;
			}
		}

		private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Nếu ký tự được nhập là số, phím backspace hoặc dấu chấm thập phân thì cho phép
			if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.')
			{
				// Nếu ký tự là dấu chấm thập phân và TextBox đã chứa một dấu chấm thập phân, không cho phép
				if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains('.'))
				{
					e.Handled = true;
					MessageBox.Show("Vui lòng chỉ nhập số!", "Lỗi",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					// Nếu giá trị đang trống và ký tự nhập vào là số 0, không cho phép
					if (((TextBox)sender).Text == "" && e.KeyChar == '0')
					{
						e.Handled = true;
						MessageBox.Show("Giá bán phải lớn hơn 0!", "Lỗi",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else
					{
						e.Handled = false;
					}
				}
			}
			// Ngược lại, thông báo lỗi và không cho phép
			else
			{
				MessageBox.Show("Vui lòng chỉ nhập số!", "Lỗi",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				e.Handled = true;
			}
		}

		private void txtGiaNhap_Leave(object sender, EventArgs e)
		{
			// Kiểm tra giá trị nhập vào có phải là số thực hay không
			decimal value;
			if (!decimal.TryParse(((TextBox)sender).Text, out value))
			{
				if (((TextBox)sender).Focused)
				{
					MessageBox.Show("Vui lòng nhập số thực!", "Lỗi",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					((TextBox)sender).Focus();
				}
			}


			decimal giaNhap, giaBan;
			if (decimal.TryParse(txtGiaBan.Text, out giaBan) && decimal.TryParse(txtGiaNhap.Text, out giaNhap))
			{
				if (giaNhap > giaBan)
				{
					var result = MessageBox.Show("Giá bán đang thấp hơn giá nhập, bạn có chắc chắn với lựa chọn của mình không?", "Thông báo",
						MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (result == DialogResult.Yes)
					{

					}
					else
					{
						// Xóa giá bán và yêu cầu nhập lại
						MessageBox.Show("Vui lòng nhập lại giá bán lớn hơn giá nhập!", "Thông báo",
							MessageBoxButtons.OK, MessageBoxIcon.Warning);
						txtGiaNhap.Text = "";
						txtGiaNhap.Focus();
					}
				}
			}
		}

		private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Nếu ký tự được nhập là số, phím backspace hoặc dấu chấm thập phân thì cho phép
			if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.')
			{
				// Nếu ký tự là dấu chấm thập phân và TextBox đã chứa một dấu chấm thập phân, không cho phép
				if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains('.'))
				{
					e.Handled = true;
					MessageBox.Show("Vui lòng chỉ nhập số!", "Lỗi",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					// Nếu giá trị đang trống và ký tự nhập vào là số 0, không cho phép
					if (((TextBox)sender).Text == "" && e.KeyChar == '0')
					{
						e.Handled = true;
						MessageBox.Show("Giá bán phải lớn hơn 0!", "Lỗi",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else
					{
						e.Handled = false;
					}
				}
			}
			// Ngược lại, thông báo lỗi và không cho phép
			else
			{
				MessageBox.Show("Vui lòng chỉ nhập số!", "Lỗi",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				e.Handled = true;
			}
		}

		private void txtGiaBan_Leave(object sender, EventArgs e)
		{
			// Kiểm tra giá trị nhập vào có phải là số thực hay không
			decimal value;
			if (!decimal.TryParse(((TextBox)sender).Text, out value))
			{
				if (((TextBox)sender).Focused)
				{
					MessageBox.Show("Vui lòng nhập số thực!", "Lỗi",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					((TextBox)sender).Focus();
				}
			}


			decimal giaNhap, giaBan;
			if (decimal.TryParse(txtGiaNhap.Text, out giaNhap) && decimal.TryParse(txtGiaBan.Text, out giaBan))
			{
				if (giaNhap > giaBan)
				{
					var result = MessageBox.Show("Giá bán đang thấp hơn giá nhập, bạn có chắc chắn với lựa chọn của mình không?", "Thông báo",
						MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (result == DialogResult.Yes)
					{

					}
					else
					{
						// Xóa giá bán và yêu cầu nhập lại
						MessageBox.Show("Vui lòng nhập lại giá bán lớn hơn giá nhập!", "Thông báo",
							MessageBoxButtons.OK, MessageBoxIcon.Warning);
						txtGiaBan.Text = "";
						txtGiaBan.Focus();
					}
				}
			}
		}

		private void txtSearchSP_TextChanged(object sender, EventArgs e)
		{
			//guna2DataGridView1.Rows.Clear();
			//int stt = 1;
			//guna2DataGridView1.Rows.Clear();
			//guna2DataGridView1.ColumnCount = 14;
			//guna2DataGridView1.Columns[0].Name = "STT";
			//guna2DataGridView1.Columns[1].Name = "ID";
			//guna2DataGridView1.Columns[1].Visible = false;
			//guna2DataGridView1.Columns[2].Name = "Mã";
			//guna2DataGridView1.Columns[3].Name = "Tên";
			//guna2DataGridView1.Columns[4].Name = "Số lượng tồn";
			//guna2DataGridView1.Columns[5].Name = "Giá nhập";
			//guna2DataGridView1.Columns[6].Name = "Giá bán";
			//guna2DataGridView1.Columns[7].Name = "Màu sắc";
			//guna2DataGridView1.Columns[8].Name = "Chất liệu";
			//guna2DataGridView1.Columns[9].Name = "Loại sản phẩm";
			//guna2DataGridView1.Columns[10].Name = "Size";
			//guna2DataGridView1.Columns[11].Name = "Nhà sản xuất";
			//guna2DataGridView1.Columns[12].Name = "Trạng thái";
			//guna2DataGridView1.Columns[13].Name = "Mô tả";
			//var list = _iSanPhamchiTietService.GetAll();
			//if (txtSearchSP.Text != "")
			//{
			//	list = _iSanPhamchiTietService.GetAll().Where(x => x.TenSp.ToLower().Contains(txtSearchSP.Text.ToLower())).ToList();
			//}
			//foreach (var x in list)
			//{
			//	guna2DataGridView1.Rows.Add(stt++, x.Id, x.Ma, x.TenSp, x.SoLuongTon, x.GiaNhap, x.Gia,
			//						x.TenMauSac, x.TenChatLieu, x.TenLoai, x.TenSize, x.TenNsx, x.TrangThai == 0 ? "Còn hàng" : "Hết hàng", x.MoTa);
			//}
			var lstKhachHang = khachHangService.GetAllKH().Where(x => x.SDT.ToLower().Contains(txtSearchSP.Text.ToLower())).ToList();
			if (lstKhachHang != null && lstKhachHang.Any())
			{
				var firstKhachHang = lstKhachHang.FirstOrDefault();
				if (firstKhachHang != null)
				{
					label1.Text = firstKhachHang.DiemTichLuy.ToString();
				}
			}

		}

        private void thêmMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMa.Text = "";
            txtTenSP.Text = "";
            txtGiaNhap.Text = "";
            txtGiaBan.Text = "";
            txtSLTon.Text = "";
            txtMoTa.Text = "";
            cmb_ChatLieu.SelectedIndex = -1;
            cmb_LoaiSP.SelectedIndex = -1;
            cmb_MauSac.SelectedIndex = -1;
            cmb_NSX.SelectedIndex = -1;
            cmb_Size.SelectedIndex = -1;
            cmb_TrangThai.SelectedIndex = -1;
			btn_Anh.Image = null;
			guna2PictureBox2.Image = null;
		}
    }
}
