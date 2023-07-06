using _1._DAL.DBcontext;
using _1._DAL.Models;
using _2._BUS.IServices;
using _2._BUS.Services;
using _2._BUS.ViewModel;
using System.Globalization;

namespace _3._PL.Views
{
    public partial class BaoCaoDoanhThu : Form
    {
        IHoaDonChiTietService _IHoaDonChiTietService;
        IHoaDonService _IHoaDonService;
        IBaoCaoService _IBaoService;
        ISanPhamChiTietService _ISanPhamCTService;
        DA1DBContext DBContext;
        public BaoCaoDoanhThu()
        {
            _IHoaDonChiTietService = new HoaDonChiTietService();
            _IHoaDonService = new HoaDonService();
            _IBaoService = new BaoCaoService();
            _ISanPhamCTService = new SanPhamChiTietService();
            DBContext = new DA1DBContext();
            InitializeComponent();
            GetAllFromDB();
            UpdateDateTime();
        }
        private void UpdateDateTime()
        {
            //while (true)
            //{
            //    // Cập nhật thời gian hiện tại
            //    DateTime currentTime = DateTime.Now;

            //    // Cập nhật Label với thời gian hiện tại
            //    lbl_Ngay.Invoke((MethodInvoker)delegate
            //    {
            //        lbl_Ngay.Text = currentTime.ToString("hh:mm:ss tt");
            //    });

            //    // Tạm dừng luồng trong 1 giây
            //    Thread.Sleep(1000);
            //}
        }

        private void BaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            Thread timeThread = new Thread(new ThreadStart(UpdateDateTime));
            timeThread.IsBackground = true;
            timeThread.Start();
            BaoCao bc = new BaoCao();
            HoaDon hd = new HoaDon();
            HoaDonChiTiet hdct = new HoaDonChiTiet();
            // Tính tổng doanh thu
            double tongDoanhThu = _IBaoService.GetAllKH().Sum(x => x.DoanhThu);

            // Gán tổng doanh thu vào Label
            lbl_DoanhThuNgay.Text = string.Format(CultureInfo.InvariantCulture, "{0:#,##0.##} VNĐ", tongDoanhThu);
            //tổng đơn hàng(đang fix)
            int count = _IHoaDonService.GetAll().Count();
            lbl_SoDonNgay.Text = count.ToString();
            //số sp đã bán
            int soSP = _IHoaDonChiTietService.GetAll().Sum(x => x.SoLuong);
            lbl_SoSPBan.Text = soSP.ToString();
            //tính tổng lợi nhuận(đang fix)
            //tính tổng chi phí
            //var tongChiPhi = (from a in _IHoaDonChiTietService.GetAll()
            //                  join b in _ISanPhamCTService.GetAll() on hdct.Id equals b.Id
            //                  select a.SoLuong * b.GiaNhap).Sum();
            //double tongChiPhi = _IHoaDonChiTietService.GetAll().Sum(x => x.SoLuong * x.SanPhamChiTiet.GiaNhap);
            //double tongLoiNhuan = tongDoanhThu - tongChiPhi;
            //lbl_LoiNhuanNgay.Text = string.Format(CultureInfo.InvariantCulture, "{0:#,##0.##} VNĐ", tongLoiNhuan);
        }
        private void GetAllFromDB()
        {
            dgrid.ColumnCount = 4;
            dgrid.Columns[0].Name = "Id";
            dgrid.Columns[0].Visible = false;
            dgrid.Columns[1].Name = "Mã";
            dgrid.Columns[2].Name = "Ngày";
            dgrid.Columns[3].Name = "Doanh Thu";
            dgrid.Rows.Clear();
            List<BaoCaoView> lstBaoCao = _IBaoService.GetAllKH();
            foreach (var x in lstBaoCao)
            {
                dgrid.Rows.Add(x.Id, x.Ma, x.Ngay, x.DoanhThu);
            }
        }
        //private void LoadHDTheoKhoangNgay()
        //{
        //    DateTime startDate = dtpPick1.Value.Date;
        //    DateTime endDate = dtpPick2.Value.Date.AddDays(1); // Kết thúc là 1 ngày sau ngày kết thúc
        //    var hd = from a in DBContext.HoaDons
        //             join b in DBContext.HoaDonChiTiets on a.Id equals b.Id
        //             join c in DBContext.SanPhamChiTiets on b.Id equals c.Id
        //             where a.NgayThanhToan >= dtpPick1.Value && a.NgayThanhToan <= dtpPick2.Value
        //             select a;
        //    dgrid.ColumnCount = 4;
        //    dgrid.Columns[0].Name = "Id";
        //    dgrid.Columns[0].Visible = false;
        //    dgrid.Columns[1].Name = "Mã";
        //    dgrid.Columns[2].Name = "Tên khách hàng";
        //    dgrid.Columns[3].Name = "ngày mua hàng";
        //    dgrid.Rows.Clear();
        //    foreach (var x in DBContext.HoaDons)
        //    {
        //        dgrid.Rows.Add(x.Id, x.Ma, x.KhachHang.TenKH, x.NgayMua);
        //    }
        //}

        private void dtpPick1_ValueChanged(object sender, EventArgs e)
        {
            //LoadHDTheoKhoangNgay();
        }

        private void dtpPick2_ValueChanged(object sender, EventArgs e)
        {
            //LoadHDTheoKhoangNgay();
        }
    }
}