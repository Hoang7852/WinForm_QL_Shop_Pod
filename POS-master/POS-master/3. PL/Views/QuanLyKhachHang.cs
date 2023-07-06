using _1._DAL.Models;
using _2._BUS.IServices;
using _2._BUS.Services;
using _2._BUS.ViewModel;
using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._PL.Views
{
    public partial class QuanLyKhachHang : Form
    {
        IKhachHangService _khachHangService;
        IHoaDonService _hoaDonService;
        IHoaDonChiTietService _hoaDonChiTietService;
        KhachHang _khachHang;
        List<KhanhHangView> _lstKhachHangs;
        Guid _Id;
        public QuanLyKhachHang()
        {
            InitializeComponent();
            _khachHangService = new KhachHangService();
            _hoaDonService = new HoaDonService();
            _hoaDonChiTietService = new HoaDonChiTietService();
            _lstKhachHangs = new List<KhanhHangView>();
            pnlInfo.Controls.Remove(rjButton15);
            label11.Text = "Mã";
            label2.Text = "Tên";
            label6.Text = "Số Điện Thoại";
            label18.Text = "Điểm tích lũy";
            label14.Text = "Tổng Tiền Đã Mua";
            label5.Text = "Khách Hàng";

            LoadData();
        }
        public void LoadData()
        {
            string col1 = "Column9";
            string col2 = "Column10";
            string col3 = "Column11";
            string col4 = "Column16";
            string col5 = "Column1";
            if (dgrid.Columns.Contains(col1))
            {
                dgrid.Columns.Remove(col1);
            }
            if (dgrid.Columns.Contains(col2))
            {
                dgrid.Columns.Remove(col2);
            }
            if (dgrid.Columns.Contains(col3))
            {
                dgrid.Columns.Remove(col3);
            }
            if (dgrid.Columns.Contains(col4))
            {
                dgrid.Columns.Remove(col4);
            }
            if (dgrid.Columns.Contains(col5))
            {
                dgrid.Columns.Remove(col5);
            }
            var lst = from a in _khachHangService.GetAllKH()
                      join b in _hoaDonService.GetAll() on a.Id equals b.ID_KH
                      join c in _hoaDonChiTietService.GetAll() on b.Id equals c.ID_HD
                      select new
                      {
                          id = a.Id,
                          ma = a.Ma,
                          TenKH = a.TenKH,
                          SDT = a.SDT,
                          Diem = a.DiemTichLuy,
                          TongTien = c.GiaDaGiam,
                      };

            dgrid.ColumnCount = 6;

            dgrid.Columns[0].Name = "ID";
            dgrid.Columns[0].Visible = false;
            dgrid.Columns[1].Name = "Mã";
            dgrid.Columns[2].Name = "Tên";
            dgrid.Columns[3].Name = "SDT";
            dgrid.Columns[4].Name = "Điểm tích lũy";
            dgrid.Columns[5].Name = "Tổng tiền đã mua";
            dgrid.Rows.Clear();


            //List<KhanhHangView> lst = new List<KhanhHangView>();
            foreach (var x in lst)
            {
                dgrid.Rows.Add(x.id, x.ma, x.TenKH, x.SDT, x.Diem, x.TongTien);
            }
        }
        public bool check()
        {
            if (!checkChu(tbx_Ma.Text))
            {
                MessageBox.Show("Yêu cầu Tên không chứa số hoặc ký tự đặc biệt", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txtTenKH.Text))
            {
                MessageBox.Show("Mã khách hàng không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(tbx_Ma.Text))
            {
                MessageBox.Show("Tên khách hàng không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(tbx_TenNV.Text))
            {
                MessageBox.Show("Số điện thoại không được bỏ trống", "Thông báo");
                return false;
            }

            if (string.IsNullOrEmpty(tbx_SDT.Text))
            {
                MessageBox.Show("Điểm tích lũy không được bỏ trống", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Tổng tiền đã mua không được bỏ trống", "Thông báo");
                return false;
            }
            if (Convert.ToInt32(txtDiaChi.Text) < 0)
            {
                MessageBox.Show("Tổng tiền đã mua phải lớn hơn 0", "Thông báo");
                return false;
            }
            if (Convert.ToInt32(tbx_SDT.Text) <= 0)
            {
                MessageBox.Show("Điểm tích lũy phải lớn hơn hoặc bằng 0", "Thông báo");
                return false;
            }
            if (!checkSo(tbx_SDT.Text))
            {
                MessageBox.Show("Điểm tích lũy không nhận chữ cái và ký tự đặc biệt", "Thông báo");
                return false;
            }
            if (!checkSo(txtDiaChi.Text))
            {
                MessageBox.Show("Tổng tiền không nhận chữ cái và ký tự đặc biệt", "Thông báo");
                return false;
            }
            if (!checkKyTu(txtTenKH.Text))
            {
                MessageBox.Show("Mã không nhận ký tự đặc biệt", "Thông báo!");
                return false;
            }
            if (!checkSo(tbx_TenNV.Text))
            {
                MessageBox.Show("Số điện thoại nhận chữ và ký tự đặc biệt", "Thông báo!");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckMaSpTrung(string maKH)
        {
            // Kiểm tra xem mã sản phẩm đã tồn tại trong cơ sở dữ liệu chưa
            var mKh = _khachHangService.GetAllKH().FirstOrDefault(x => x.Ma == maKH);
            if (mKh != null)
            {
                // Nếu tồn tại rồi thì thông báo và trả về false
                MessageBox.Show("Mã khách hàng đã tồn tại!");
                return false;
            }
            return true;
        }
        public bool checkSo(string text)
        {
            return Regex.IsMatch(text, "^[0-9]*$");
            //return Regex.IsMatch(text, "\\d+");
        }
        public bool checkChu(string x)
        {
            return Regex.IsMatch(x, "[a-zA-Z]+");
            //return Regex.IsMatch(text, "\\w+"); // bao gồm cả chữ lẫn số nhưng ko có ký tự
        }

        public bool checkKyTu(string x)
        {
            //return Regex.IsMatch(x, "[a-zA-Z]+");
            return Regex.IsMatch(x, "\\w+"); // bao gồm cả chữ lẫn số nhưng ko có ký tự
        }

        private void dgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgrid.CurrentCell != null && dgrid.CurrentCell.Value != null)
            {
                _Id = Guid.Parse(dgrid.CurrentRow.Cells[0].Value.ToString());
                var kh = _khachHangService.GetAllKH().FirstOrDefault(c => c.Id.Equals(_Id));
                var hd = _hoaDonService.GetAll().FirstOrDefault(c => c.ID_KH == kh.Id);
                var hdct = _hoaDonChiTietService.GetAll().FirstOrDefault(c => c.ID_HD == hd.Id);
                txtTenKH.Text = kh.Ma;
                tbx_Ma.Text = kh.TenKH;
                tbx_TenNV.Text = kh.SDT;
                tbx_SDT.Text = kh.DiemTichLuy.ToString();
                txtDiaChi.Text = hdct.GiaDaGiam.ToString();
            }
        }

        private void rjButton17_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn thêm?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (CheckMaSpTrung(tbx_Ma.Text) == false)
                {
                    return;
                }
                if (check() == false)
                {
                    return;
                }
                else
                {
                    var _kh = new KhanhHangView()

                    {
                        Id = Guid.NewGuid(),
                        Ma = txtTenKH.Text,
                        TenKH = tbx_Ma.Text,
                        SDT = tbx_TenNV.Text,
                        DiemTichLuy = Convert.ToDouble(tbx_SDT.Text),
                        TongTien = Convert.ToDouble(txtDiaChi.Text),


                    };
                    _khachHangService.Add(_kh);
                    MessageBox.Show("Thêm thành công");
                    LoadData();
                }
            }
            if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Thêm thất bại");
                return;
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn sửa?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                if (check() == false)
                {
                    return;
                }
                else
                {
                    var x = _khachHangService.GetAllKH().FirstOrDefault(p => p.Id.Equals(_Id));
                    x.Ma = txtTenKH.Text;
                    x.TenKH = tbx_Ma.Text;
                    x.SDT = tbx_TenNV.Text;
                    x.DiemTichLuy = Convert.ToDouble(tbx_SDT.Text);
                    x.TongTien = Convert.ToDouble(txtDiaChi.Text);
                    _khachHangService.Update(x);
                    MessageBox.Show("Sửa thành công");
                    LoadData();
                }
            }
            if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Sửa thất bại");
                return;
            }
        }
    }
}