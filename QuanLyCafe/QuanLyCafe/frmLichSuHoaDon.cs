﻿﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class frmLichSuHoaDon: Form
    {
        public frmLichSuHoaDon()
        {
            InitializeComponent();
        }
        private void LoadDataHoaDon()
        {
            string strSQl = @"SELECT a.MaHD, a.NgayLap, b.TenNV, c.TenKH, a.MaBan, a.TongTien, a.TrangThai
                              FROM HoaDon a 
                              INNER JOIN NhanVien b ON a.MaNV = b.MaNV
                              INNER JOIN KhachHang c ON a.MaKH = c.MaKH
                              WHERE a.NgayLap >= @FromDate AND a.NgayLap < @ToDateNext
                              ORDER BY a.NgayLap DESC";

            var parameters = new Dictionary<string, object>
            {
                { "@FromDate", dtDFrom.Value.Date },
                { "@ToDateNext", dtDTo.Value.Date.AddDays(1) } // Lấy đến đầu ngày hôm sau để bao gồm cả ngày kết thúc
            };
            DataTable dt = ConnectSQL.Load(strSQl, parameters);

            // Thêm cột STT vào DataTable
            dt.Columns.Add("STT", typeof(int));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
            }

            dtgvHD.DataSource = dt;
            frmNhanVien.SetupDataGridView(dtgvHD);
            dtgvHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Tắt tự động co giãn để tùy chỉnh

            // Đặt lại tên và thứ tự cột
            dtgvHD.Columns["STT"].DisplayIndex = 0;
            dtgvHD.Columns["STT"].HeaderText = "STT";
            dtgvHD.Columns["STT"].Width = 50;

            dtgvHD.Columns["MaHD"].HeaderText = "Mã hóa đơn";
            dtgvHD.Columns["MaHD"].Width = 150;

            dtgvHD.Columns["NgayLap"].HeaderText = "Ngày lập";
            dtgvHD.Columns["NgayLap"].Width = 160; // Tăng độ rộng để hiển thị đủ ngày giờ

            dtgvHD.Columns["TenNV"].HeaderText = "Tên nhân viên";
            dtgvHD.Columns["TenKH"].HeaderText = "Tên khách hàng";
            dtgvHD.Columns["TenKH"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Cho cột này lấp đầy

            dtgvHD.Columns["MaBan"].HeaderText = "Mã bàn";
            dtgvHD.Columns["MaBan"].Width = 80;

            dtgvHD.Columns["TongTien"].HeaderText = "Tổng tiền";
            dtgvHD.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            dtgvHD.Columns["TongTien"].Width = 90;

            dtgvHD.Columns["TrangThai"].HeaderText = "Trạng thái";
            dtgvHD.Columns["TrangThai"].Width = 90; // Giảm độ rộng cột trạng thái

            if (dtgvHD.Rows.Count == 0)
            {
                LoadDataChiTietHoaDon("");
            }
            else
            {
                string? maHD = dtgvHD.CurrentRow?.Cells[0]?.Value?.ToString()?.Trim();
                LoadDataChiTietHoaDon(maHD ?? string.Empty);
            }    
        }
        private void LoadDataChiTietHoaDon(string MaHD)
        {
            string strSQl = $@"SELECT a.MaDU, b.TenDU, a.SoLuong, a.DonGia, a.ThanhTien 
                               FROM ChiTietHoaDon a 
                               INNER JOIN DoUong b ON a.MaDU = b.MaDU 
                               WHERE a.MaHD = '{MaHD}'";
            DataTable dt = new DataTable();
            dt = ConnectSQL.Load(strSQl);
            dtgvCTHD.DataSource = dt;
            frmNhanVien.SetupDataGridView(dtgvCTHD);
            dtgvCTHD.Columns["MaDU"].HeaderText = "Mã Đồ Uống";
            dtgvCTHD.Columns["TenDU"].HeaderText = "Tên Đồ Uống";
            dtgvCTHD.Columns["SoLuong"].HeaderText = "Số Lượng";
            dtgvCTHD.Columns["DonGia"].HeaderText = "Đơn Giá";
            dtgvCTHD.Columns["ThanhTien"].HeaderText = "Thành Tiền";

            dtgvCTHD.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dtgvCTHD.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }
        private void frmLichSuHoaDon_Load(object sender, EventArgs e)
        {
            // Lấy ngày có hóa đơn đầu tiên trong cơ sở dữ liệu
            object firstInvoiceDateObj = ConnectSQL.ExecuteScalar("SELECT MIN(NgayLap) FROM HoaDon");

            DateTime fromDate;
            if (firstInvoiceDateObj != DBNull.Value && firstInvoiceDateObj != null)
            {
                fromDate = Convert.ToDateTime(firstInvoiceDateObj);
            }
            else
            {
                // Nếu không có hóa đơn nào, mặc định là đầu tháng hiện tại
                fromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            }

            dtDFrom.Value = fromDate;
            dtDTo.Value = DateTime.Today;

            // Đảm bảo ngày kết thúc không nhỏ hơn ngày bắt đầu
            dtDTo.MinDate = dtDFrom.Value.Date;
            LoadDataHoaDon();

            // Gán lại sự kiện sau khi đã thiết lập giá trị ban đầu để tránh lỗi
            // This prevents the ValueChanged events from firing during initial setup.
            dtDFrom.ValueChanged += new System.EventHandler(this.dtDFrom_ValueChanged);
            dtDTo.ValueChanged += new System.EventHandler(this.dtDTo_ValueChanged);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            LoadDataHoaDon();
        }

        private void dtgvHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvHD.Rows[e.RowIndex];
                string? maHD = row.Cells[0]?.Value?.ToString();
                LoadDataChiTietHoaDon(maHD ?? string.Empty);
            }
        }

        private void dtDFrom_ValueChanged(object sender, EventArgs e)
        {
            // Khi ngày bắt đầu thay đổi, ngày kết thúc không được nhỏ hơn ngày bắt đầu
            dtDTo.MinDate = dtDFrom.Value.Date;
        }

        private void dtDTo_ValueChanged(object sender, EventArgs e)
        {
            // Khi ngày kết thúc thay đổi, ngày bắt đầu không được lớn hơn ngày kết thúc
            dtDFrom.MaxDate = dtDTo.Value.Date;
        }
    }
}
