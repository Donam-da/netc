﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCafe
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class frmThongKeLoiNhuan : Form
    {
        public frmThongKeLoiNhuan()
        {
            InitializeComponent();
        }

        private void frmThongKeLoiNhuan_Load(object sender, EventArgs e)
        {
            // Đặt khoảng thời gian mặc định là tháng hiện tại
            dtDFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtDTo.Value = DateTime.Today;
            LoadData();
        }

        private void btnLocDuLieu_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (dtDFrom.Value.Date > dtDTo.Value.Date)
            {
                MessageBox.Show("Khoảng ngày không hợp lệ. 'Từ ngày' phải nhỏ hơn hoặc bằng 'Đến ngày'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Câu SQL tính toán Doanh thu, Giá vốn và Lợi nhuận theo từng ngày
            string sql = @"
WITH DailySales AS (
    SELECT
        CAST(hd.NgayLap AS DATE) AS Ngay,
        cthd.ThanhTien AS DoanhThu,
        -- Tính giá vốn cho từng món trong chi tiết hóa đơn
        CASE
            WHEN du.IsPhaChe = 1 THEN -- Đồ uống pha chế
                ISNULL((SELECT SUM(ct.SoLuong * nl.GiaTien) FROM CongThuc ct JOIN NguyenLieu nl ON ct.MaNL = nl.MaNL WHERE ct.MaDU = cthd.MaDU), 0) * cthd.SoLuong
            ELSE -- Đồ uống nguyên bản
                ISNULL(du.GiaGoc, 0) * cthd.SoLuong
        END AS GiaVon
    FROM
        HoaDon hd
    JOIN
        ChiTietHoaDon cthd ON hd.MaHD = cthd.MaHD
    JOIN
        DoUong du ON cthd.MaDU = du.MaDU
    WHERE
        hd.TrangThai = 1 -- Chỉ tính các hóa đơn đã thanh toán
        AND hd.NgayLap >= @FromDate 
        AND hd.NgayLap < @ToDateNext
)
SELECT
    Ngay,
    SUM(DoanhThu) AS DoanhThu,
    SUM(GiaVon) AS GiaVon,
    SUM(DoanhThu - GiaVon) AS LoiNhuan
FROM
    DailySales
GROUP BY
    Ngay
ORDER BY
    Ngay DESC;
";

            var parameters = new Dictionary<string, object>
            {
                { "@FromDate", dtDFrom.Value.Date },
                { "@ToDateNext", dtDTo.Value.Date.AddDays(1) } // Lấy đến đầu ngày hôm sau để bao gồm cả ngày kết thúc
            };

            DataTable dt = ConnectSQL.Load(sql, parameters);
            dtgvData.DataSource = dt;

            // Cấu hình DataGridView
            frmNhanVien.SetupDataGridView(dtgvData);
            dtgvData.Columns["Ngay"].HeaderText = "Ngày";
            dtgvData.Columns["DoanhThu"].HeaderText = "Doanh Thu";
            dtgvData.Columns["GiaVon"].HeaderText = "Giá Vốn";
            dtgvData.Columns["LoiNhuan"].HeaderText = "Lợi Nhuận";

            // Định dạng số và căn lề
            string[] numericColumns = { "DoanhThu", "GiaVon", "LoiNhuan" };
            foreach (string colName in numericColumns)
            {
                dtgvData.Columns[colName].DefaultCellStyle.Format = "N0";
                dtgvData.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Tính tổng
            decimal totalRevenue = dt.AsEnumerable().Sum(row => row.Field<decimal?>("DoanhThu") ?? 0);
            decimal totalCost = dt.AsEnumerable().Sum(row => row.Field<decimal?>("GiaVon") ?? 0);
            decimal totalProfit = dt.AsEnumerable().Sum(row => row.Field<decimal?>("LoiNhuan") ?? 0);

            lblTongDoanhThu.Text = totalRevenue.ToString("N0") + " VNĐ";
            lblTongGiaVon.Text = totalCost.ToString("N0") + " VNĐ";
            lblTongLoiNhuan.Text = totalProfit.ToString("N0") + " VNĐ";

            // Sau khi tải xong, tự động hiển thị chi tiết của ngày đầu tiên (nếu có)
            if (dtgvData.Rows.Count > 0)
            {
                DateTime firstDate = Convert.ToDateTime(dtgvData.Rows[0].Cells["Ngay"].Value);
                LoadChiTietHoaDon(firstDate);
            }
            else
            {
                // Nếu không có dữ liệu, xóa trắng bảng chi tiết
                dtgvChiTiet.DataSource = null;
                lblChiTietNgay.Text = "Chi tiết hóa đơn:";
            }
        }

        private void dtgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DateTime selectedDate = Convert.ToDateTime(dtgvData.Rows[e.RowIndex].Cells["Ngay"].Value);
                LoadChiTietHoaDon(selectedDate);
            }
        }

        private void LoadChiTietHoaDon(DateTime selectedDate)
        {
            lblChiTietNgay.Text = $"Chi tiết hóa đơn ngày: {selectedDate:dd/MM/yyyy}";

            string sql = @"
WITH ItemCost AS (
    SELECT
        cthd.MaHD,
        cthd.MaDU,
        -- Tính giá vốn cho từng món trong chi tiết hóa đơn
        CASE
            WHEN du.IsPhaChe = 1 THEN ISNULL((SELECT SUM(ct.SoLuong * nl.GiaTien) FROM CongThuc ct JOIN NguyenLieu nl ON ct.MaNL = nl.MaNL WHERE ct.MaDU = cthd.MaDU), 0) * cthd.SoLuong
            ELSE ISNULL(du.GiaGoc, 0) * cthd.SoLuong
        END AS GiaVonTungMon
    FROM ChiTietHoaDon cthd
    JOIN DoUong du ON cthd.MaDU = du.MaDU
)
SELECT 
    hd.MaHD,
    hd.NgayLap,
    hd.TongTien AS DoanhThu,
    ISNULL(SUM(ic.GiaVonTungMon), 0) AS GiaVon,
    (hd.TongTien - ISNULL(SUM(ic.GiaVonTungMon), 0)) AS LoiNhuan
FROM HoaDon hd
LEFT JOIN ItemCost ic ON hd.MaHD = ic.MaHD
WHERE hd.TrangThai = 1 AND CAST(hd.NgayLap AS DATE) = @SelectedDate
GROUP BY hd.MaHD, hd.TongTien, hd.NgayLap
ORDER BY hd.NgayLap ASC;
";

            var parameters = new Dictionary<string, object>
            {
                { "@SelectedDate", selectedDate.Date }
            };

            DataTable dt = ConnectSQL.Load(sql, parameters);
            dtgvChiTiet.DataSource = dt;

            // Cấu hình DataGridView chi tiết
            frmNhanVien.SetupDataGridView(dtgvChiTiet);
            dtgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Tắt tự động co giãn để tùy chỉnh

            dtgvChiTiet.Columns["MaHD"].HeaderText = "Mã Hóa Đơn";
            dtgvChiTiet.Columns["MaHD"].Width = 150;

            dtgvChiTiet.Columns["NgayLap"].HeaderText = "Ngày Giờ Lập";
            dtgvChiTiet.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dtgvChiTiet.Columns["NgayLap"].Width = 160;

            dtgvChiTiet.Columns["DoanhThu"].HeaderText = "Doanh Thu";
            dtgvChiTiet.Columns["GiaVon"].HeaderText = "Giá Vốn";
            dtgvChiTiet.Columns["LoiNhuan"].HeaderText = "Lợi Nhuận";
            // Cho cột lợi nhuận tự lấp đầy không gian còn lại
            dtgvChiTiet.Columns["LoiNhuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Định dạng số và căn lề
            string[] numericColumns = { "DoanhThu", "GiaVon", "LoiNhuan" };
            foreach (string colName in numericColumns)
            {
                dtgvChiTiet.Columns[colName].DefaultCellStyle.Format = "N0";
                dtgvChiTiet.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
    }
}