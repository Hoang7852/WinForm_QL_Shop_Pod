using _2._BUS.IServices;
using _2._BUS.Services;
using _3._PL.Component;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Image = System.Drawing.Image;
using System.Text.RegularExpressions;
using _2._BUS.ViewModel;
using System.Security.Principal;
using _1._DAL.Models;
using _3._PL.Services;

namespace _3._PL.Views
{
    public partial class POS : Form
    {
        private ISanPhamChiTietService _spSer;
        private IKhachHangService _khachHangService;
        private IHoaDonService _hoaDonService;
        private IHoaDonChiTietService _hoaDonCTService;
        private INhanVienService _nhanVienService;
        private ITaiKhoanService _taiKhoanService;

        List<HoaDonChiTietView> hdct;

        public POS()
        {
            InitializeComponent();
            _spSer = new SanPhamChiTietService();
            _khachHangService = new KhachHangService();
            _hoaDonCTService = new HoaDonChiTietService();
            _hoaDonService = new HoaDonService();
            _nhanVienService = new NhanVienService();
            _taiKhoanService = new TaiKhoanService();
        }


        #region
        public void AddItem(string name, double cost, string icon)
        {
            var w = new CreateOrderSP()
            {
                Title = name,
                Cost = cost,
                Icon = Image.FromFile(/*"D:\\PodShop\\PodShop\\3. PL\\icons\\Pod\\" + */icon),
            };
            pnl.Controls.Add(w);

            w.OnSelect += (ss, ee) =>
            {
                var wdg = (CreateOrderSP)ss;
                foreach (DataGridViewRow item in grid.Rows)
                {
                    if (item.Cells[0].Value.ToString() == wdg.lblTitle.Text)
                    {
                        item.Cells[1].Value = wdg.lblCost.Text;
                        item.Cells[2].Value = int.Parse(item.Cells[2].Value.ToString()) + 1;
                        item.Cells[3].Value = (int.Parse(item.Cells[2].Value.ToString()) * double.Parse(wdg.lblCost.Text.Replace("$", ""))).ToString("C2");
                        CalculateTotal();
                        return;
                    }
                }
                grid.Rows.Add(new object[] { wdg.lblTitle.Text, wdg.lblCost.Text, 1, wdg.lblCost.Text });
                CalculateTotal();
            };


        }

        public void AddKH(string name, string phone, string icon, string rank)
        {
            var w = new KhachHangSearch()
            {
                Name = name,
                Phone = phone,
                Icon = Image.FromFile("D:\\Backup\\3. PL\\icons\\" + icon),
                Rank = rank
            };
            pnl.Controls.Add(w);
            //tbx_TenKH.Text = Account.tenKH;
        }


        void CalculateTotal()
        {
            double tot = 0;
            foreach (DataGridViewRow item in grid.Rows)
            {
                tot += double.Parse(item.Cells[3].Value.ToString().Replace("$", ""));
            }

            lblTong.Text = tot.ToString("C2");
        }


        string path = "All Item";
        private void menu_OnItemSelected(object sender, string _path, EventArgs e)
        {
            path = _path;
            foreach (var item in pnl.Controls)
            {
                var wdg = (CreateOrderSP)item;
                wdg.Visible = wdg.lblTitle.Text.ToLower().Contains(txtSearchSP.Text.Trim().ToLower())
                    &&
                  (wdg.Tag.ToString() == path.Replace(" ", "") || path.Replace(" ", "") == "AllItems");
            }

        }
        #endregion

        private void LoadData()
        {
            if (Convert.ToInt32(lblTichLuy.Text) < 100)
            {

                lblTong.Text = lblTong.Text;

            }
            else if (Convert.ToInt32(lblTichLuy.Text) > 100 && Convert.ToInt32(lblTichLuy.Text) < 200)
            {
                double tong = double.Parse(lblTong.Text) * 0.1;
                lblTong.Text = tong.ToString();

            }
            else if (Convert.ToInt32(lblTichLuy.Text) >= 200 && Convert.ToInt32(lblTichLuy.Text) < 500)
            {
                decimal tong = Convert.ToDecimal(lblTong.Text) * 0.2m;
                lblTong.Text = tong.ToString();
            }
            else
            {
                decimal tong = Convert.ToDecimal(lblTong.Text) * 0.3m;
                lblTong.Text = tong.ToString();
            }
        }
        private void POS_Shown(object sender, EventArgs e)
        {

            //Fetch items from db here
            //pod
            AddItem("Ares Pod", 7.75/*, categories.Pod*/, "E:\\DA1\\POS\\3. PL\\Resource\\AnhSP\\anh1.jfif");
            AddItem("Flame Pod", 7.75/*, categories.Pod,*/, "E:\\DA1\\POS\\3. PL\\Resource\\AnhSP\\anh10.jfif");
            AddItem("Minican Pod", 10.78/*, categories.Pod*/, "E:\\DA1\\POS\\3. PL\\Resource\\AnhSP\\anh11.jfif");
            AddItem("Tance Pod", 6.78/*, categories.Pod*/, "E:\\DA1\\POS\\3. PL\\Resource\\AnhSP\\anh12.jfif");


            //vape
            AddItem("Caliburn", 10.78/*, categories.Vape*/, "E:\\DA1\\POS\\3. PL\\Resource\\AnhSP\\anh13.jfif");
            AddItem("Wenax K1", 11.78/*, categories.Vape*/, "E:\\DA1\\POS\\3. PL\\Resource\\AnhSP\\anh14.jfif");
            AddItem("Prana S", 51.78/*, categories.Vape*/, "E:\\DA1\\POS\\3. PL\\Resource\\AnhSP\\anh15.jfif");
            AddItem("Palse", 55.78/*, categories.Vape*/, "E:\\DA1\\POS\\3. PL\\Resource\\AnhSP\\anh16.jfif");


            //juice
            AddItem("Feelin Pod", 1.78/*, categories.Juice*/, "E:\\DA1\\POS\\3. PL\\Resource\\AnhSP\\anh17.jfif");
            AddItem("Veego 30", 1.78/*, categories.Juice*/, "E:\\DA1\\POS\\3. PL\\Resource\\AnhSP\\anh18.jfif");
            AddItem("Marvel 40", 1.78/*, categories.Juice*/, "E:\\DA1\\POS\\3. PL\\Resource\\AnhSP\\anh19.jfif");
            AddItem("Caliburn G", 1.78/*, categories.Juice*/, "E:\\DA1\\POS\\3. PL\\Resource\\AnhSP\\anh2.jfif");
            AddItem("Iflex Pod", 1.78/*, categories.Juice*/, "E:\\DA1\\POS\\3. PL\\Resource\\AnhSP\\anh20.jfif");
            AddItem("Relx Pod", 1.78/*, categories.Juice*/, "E:\\DA1\\POS\\3. PL\\Resource\\AnhSP\\anh3.jfif");
            AddItem("Argus 40w", 1.78/*, categories.Juice*/, "E:\\DA1\\POS\\3. PL\\Resource\\AnhSP\\anh4.jfif");
            AddItem("Oxva Origin", 1.78/*, categories.Juice*/, "E:\\DA1\\POS\\3. PL\\Resource\\AnhSP\\anh5.jfif");
            AddItem("Origin X ", 1.78/*, categories.Juice*/, "E:\\DA1\\POS\\3. PL\\Resource\\AnhSP\\anh6.jfif");


            foreach (var x in _spSer.GetAll())
            {
                AddItem(x.TenSp, x.Gia, x.LinkAnh);
            }

        }

        private void txtSearchSP_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in pnl.Controls)
            {
                var wdg = (CreateOrderSP)item;
                wdg.Visible = wdg.lblTitle.Text.ToLower().Contains(txtSearchSP.Text.Trim().ToLower());
                //  &&
                //(wdg.Tag.ToString() == path.Replace(" ", "") || path.Replace(" ", "") == "AllItems");
                //item+= 
            }
        }

        private void btn_TraTien_Click(object sender, EventArgs e)
        {

            var lstKhachHang1 = _khachHangService.GetAllKH().Where(x => x.SDT == lblPhone.ToString()).ToList();
            //var idKh
            string userLogin = Account.user1;
            var idNv = _nhanVienService.GetAllKH().Where(x => x.TaiKhoan == Account.user1.ToString()).ToList();
            if (idNv.Count != null && idNv.Any() && lstKhachHang1.Count != null && lstKhachHang1.Any())
            {
                var nhanVien = idNv.First();
                var firstNhanVien = idNv.FirstOrDefault();

                var khachHang = lstKhachHang1.First();
                var firstKhachHang = lstKhachHang1.FirstOrDefault();
                var khvl = lblPhone.Text != "" ? _khachHangService.GetAllKH().FirstOrDefault(x => x.SDT == lblPhone.Text) : _khachHangService.GetAllKH().FirstOrDefault(x => x.Ma == "KH01");
                if (hdct != null)
                {
                    var x = new HoaDonView()
                    {
                        Id = Guid.NewGuid(),
                        Ma = CreateKey(),
                        NgayMua = DateTime.Now,
                        NgayThanhToan = DateTime.Now,
                        TenKh = khvl.TenKH,
                        ID_KH = khvl.Id,
                        ID_NV = firstNhanVien.Id_NV,
                        TrangThai = 0,
                        Sdt = khvl.SDT,
                        DiemTichLuy = 0
                    };
                    if (_hoaDonService.Add(x))
                    {
                        foreach (var i in hdct)
                        {
                            if (i != null)
                            {
                                if (_spSer.GetAll().FirstOrDefault(x => x.Id == i.ID_SPCT) != null)
                                {
                                    i.ID_HD = x.Id;
                                    _hoaDonCTService.Add(i);
                                    var z = _spSer.GetAll().FirstOrDefault(x => x.Id == i.ID_SPCT);
                                    z.SoLuongTon -= i.SoLuong;
                                    _spSer.Update(z);
                                }

                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Chưa có sản phẩm");
                }
            }

            if (grid.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "Result.pdf";
                bool ErrorMessage = false;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage = true;
                            MessageBox.Show("Unable to wride data in disk" + ex.Message);
                        }
                    }
                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable pTable = new PdfPTable(grid.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            foreach (DataGridViewColumn col in grid.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }
                            foreach (DataGridViewRow viewRow in grid.Rows)
                            {
                                foreach (DataGridViewCell dcell in viewRow.Cells)
                                {
                                    pTable.AddCell(dcell.Value.ToString());
                                }
                            }
                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter.GetInstance(document, fileStream);
                                document.Open();
                                document.Add(pTable);
                                document.Close();
                                fileStream.Close();
                            }
                            MessageBox.Show("In hóa đơn thành công!", "Sự Cô Đơn Team");
                            grid.Rows.Clear();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Xuất hóa đơn không thành công" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record Found", "Info");
            }
        }




        public string CreateKey()
        {
            string ma = "HD";
            DateTime dateTime = DateTime.Now;
            string d = String.Format($"{dateTime.Day}{dateTime.Month}{dateTime.Year}_{dateTime.Hour}{dateTime.Minute}{dateTime.Second}");
            ma = ma + d;
            return ma;
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            grid.Rows.Clear();
        }

        private void lblTot_Click(object sender, EventArgs e)
        {
        }

        private void label15_Click(object sender, EventArgs e)
        {
        }



        private void lblPhone_TextChanged(object sender, EventArgs e)
        {

            var lstKhachHang = _khachHangService.GetAllKH().Where(x => x.SDT == lblPhone.Text).ToList();
            if (lstKhachHang.Count != null && lstKhachHang.Any())
            {
                var khachHang = lstKhachHang.First();
                var firstKhachHang = lstKhachHang.FirstOrDefault();
                if (firstKhachHang != null)
                {
                    lblTichLuy.Text = firstKhachHang.DiemTichLuy.ToString();
                }
            }
            else
            {
                MessageBox.Show("Số điện thoại không tồn tại");
            }
        }

        public bool checkSo(string text)
        {
            return Regex.IsMatch(text, "\\d+");
        }
        private void tbx_tienKhachTra_TextChanged(object sender, EventArgs e)
        {
            if (tbx_tienKhachTra.Text == "" || tbx_tienKhachTra.Text == "0" || !checkSo(tbx_tienKhachTra.Text)) return;
            double number;
            number = double.Parse(tbx_tienKhachTra.Text, System.Globalization.NumberStyles.Currency);
            tbx_tienKhachTra.Text = number.ToString("#,#");
            tbx_tienKhachTra.SelectionStart = tbx_tienKhachTra.Text.Length;
        }
    }
}
