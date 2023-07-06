﻿using _1._DAL.DBcontext;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._PL.Views
{
    public partial class QLLoaiSp : UserControl
    {
        ILoaiService _iloaiService;
        Guid _id;
        public QLLoaiSp()
        {
            InitializeComponent();
            _iloaiService = new LoaiService();
        }
        public void LoadData()
        {
            int stt = 1;
            dgrid_LoaiSp.ColumnCount = 4;
            dgrid_LoaiSp.Columns[0].Name = "STT";
            dgrid_LoaiSp.Columns[1].Name = "Id";
            dgrid_LoaiSp.Columns[1].Visible = false;
            dgrid_LoaiSp.Columns[2].Name = "Mã";
            dgrid_LoaiSp.Columns[3].Name = "Tên";
            dgrid_LoaiSp.Rows.Clear();
            var lstMauSac = _iloaiService.GetAll();
            if (txt_TimKiem.Text != "")
            {
                lstMauSac = lstMauSac.Where(x => x.Ten.ToLower().Contains(txt_TimKiem.Text.ToLower())).ToList();
            }
            foreach (var x in lstMauSac)
            {
                dgrid_LoaiSp.Rows.Add(stt++, x.Id, x.Ma, x.Ten);
            }
        }
        private void Clear()
        {
            txt_Ma.Text = "";
            txt_TimKiem.Text = "";
            txt_Ten.Text = "";
            _id = Guid.Empty;
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            int stt = 1;
            dgrid_LoaiSp.ColumnCount = 4;
            dgrid_LoaiSp.Columns[0].Name = "STT";
            dgrid_LoaiSp.Columns[1].Name = "Id";
            dgrid_LoaiSp.Columns[1].Visible = false;
            dgrid_LoaiSp.Columns[2].Name = "Mã";
            dgrid_LoaiSp.Columns[3].Name = "Tên";
            dgrid_LoaiSp.Rows.Clear();
            var lstMauSac = _iloaiService.GetAll();
            if (txt_TimKiem.Text != "")
            {
                lstMauSac = lstMauSac.Where(x => x.Ten.ToLower().Contains(txt_TimKiem.Text.ToLower())).ToList();
            }
            foreach (var x in lstMauSac)
            {
                dgrid_LoaiSp.Rows.Add(stt++, x.Id, x.Ma, x.Ten);
            }
        }

        private void dgrid_LoaiSp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _id = Guid.Parse(dgrid_LoaiSp.CurrentRow.Cells[1].Value.ToString());
            var x = _iloaiService.GetAll().FirstOrDefault(x => x.Id == _id);
            txt_Ma.Text = x.Ma;
            txt_Ten.Text = x.Ten;
        }

        private void rbtn_Them_Click_1(object sender, EventArgs e)
        {
            var x = new LoaiView()
            {
                Id = Guid.NewGuid(),
                Ma = txt_Ma.Text,
                Ten = txt_Ten.Text
            };
            if (_iloaiService.Add(x))
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
                var x = _iloaiService.GetAll().FirstOrDefault(x => x.Id == _id);
                x.Ten = txt_Ten.Text;
                x.Ma = txt_Ma.Text;

                if (_iloaiService.Update(x))
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
                            //    var x = _iloaiService.GetAll().FirstOrDefault(x => x.Id == _id);
                //    if (_iloaiService.Delete(x))
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
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (var context = new DA1DBContext())
                {
                var loaiSp = context.Loais.Include(s => s.SanPhamChiTiets).SingleOrDefault(s => s.Id == _id);

                    if (loaiSp != null && loaiSp.SanPhamChiTiets.Any())
                    {
                        // Nếu đã được sử dụng, hiển thị thông báo cảnh báo
                        MessageBox.Show("Không thể xóa bản ghi này vì đã được sử dụng trong bảng Sản phẩm.");
                    }
                    else if (loaiSp != null)
                    {
                        // Nếu chưa được sử dụng, thực hiện xóa bản ghi
                        context.Loais.Remove(loaiSp);
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
            dgrid_LoaiSp.Rows.Clear();
        }

        private void rbtn_Show_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txt_TimKiem_Click(object sender, EventArgs e)
        {
            txt_TimKiem.Text = "";
        }
    }
}
