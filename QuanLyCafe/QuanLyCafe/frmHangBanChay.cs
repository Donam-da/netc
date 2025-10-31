﻿﻿﻿using System;
using System.Data;
using System.Drawing;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace QuanLyCafe
{
    [SupportedOSPlatform("windows")]
    public partial class frmHangBanChay : Form
    {
        public frmHangBanChay()
        {
            InitializeComponent();
        }

        // ====== FORM LOAD ======================================================
        private void frmHangBanChay_Load(object sender, EventArgs e)
        {
            // Khoảng mặc định: từ đầu tháng đến hôm nay
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

            LoadData();
        }

        // ====== NÚT LỌC DỮ LIỆU ===============================================
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        // ====== LỌC KHI ĐỔI NGÀY (tuỳ chọn bật) ================================
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

        // ====== HÀM CHÍNH: TẢI DỮ LIỆU ========================================
        private void LoadData()
        {
            // Kiểm tra khoảng ngày hợp lệ
            if (dtDFrom.Value.Date > dtDTo.Value.Date)
            {
                MessageBox.Show("Khoảng ngày không hợp lệ. 'Từ ngày' phải nhỏ hơn hoặc bằng 'Đến ngày'.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại nếu ngày không hợp lệ
            }

            // Lấy mốc ngày: [from, toNext) để không bỏ sót hóa đơn trong "Đến ngày"
            var parameters = new System.Collections.Generic.Dictionary<string, object>
            {
                { "@FromDate", dtDFrom.Value.Date },
                { "@ToDateNext", dtDTo.Value.Date.AddDays(1) }
            };

            // TOP hàng bán chạy theo Số lượng (nếu bằng nhau, theo Doanh thu)
            string sqlTop = @"
        SELECT d.MaDU,
               d.TenDU,
               SUM(ct.SoLuong)   AS SoLuong,
               SUM(ct.ThanhTien) AS DoanhThu
        FROM HoaDon hd
        JOIN ChiTietHoaDon ct ON ct.MaHD = hd.MaHD
        JOIN DoUong d        ON d.MaDU = ct.MaDU
        WHERE hd.TrangThai = 1 AND hd.NgayLap >= @FromDate AND hd.NgayLap < @ToDateNext
        GROUP BY d.MaDU, d.TenDU
        ORDER BY SoLuong DESC, DoanhThu DESC";

            DataTable dt = ConnectSQL.Load(sqlTop, parameters);   // Thực thi SQL và lấy bảng dữ liệu
            dtgvData.DataSource = dt;                 // Đổ vào DataGridView

            // Căn lề & định dạng cột số
            dtgvData.Columns["MaDU"].HeaderText = "Mã Đồ Uống";
            dtgvData.Columns["TenDU"].HeaderText = "Tên Đồ Uống";
            dtgvData.Columns["SoLuong"].HeaderText = "Số Lượng Bán";
            dtgvData.Columns["DoanhThu"].HeaderText = "Doanh Thu";

            dtgvData.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvData.Columns["DoanhThu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgvData.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";

            // Tính tổng doanh thu
            decimal tong = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    if (decimal.TryParse(r["DoanhThu"].ToString(), out decimal v))
                        tong += v; // Cộng dồn doanh thu
                }

                lblTongTien.Text = tong.ToString("N0") + " VNĐ"; // Hiển thị tổng doanh thu ở dưới

                // Cập nhật tiêu đề form với Top 1 (dòng đầu tiên sau khi ORDER BY)
                string tenTop1 = dt.Rows[0]["TenDU"]?.ToString() ?? "";
                string slTop1 = dt.Rows[0]["SoLuong"]?.ToString() ?? "";
                string dtTop1 = Convert.ToDecimal(dt.Rows[0]["DoanhThu"] ?? 0).ToString("N0");
                this.Text = $"Top hàng bán chạy (Top 1: {tenTop1} - SL: {slTop1}, DT: {dtTop1} VNĐ)";
            }
            else
            {
                lblTongTien.Text = "0 VNĐ";           // Không có dữ liệu: tổng = 0
                this.Text = "Top hàng bán chạy";      // Tiêu đề mặc định
            }
        }

        private void dtgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Tô màu cho hàng đầu tiên (Top 1)
            if (e.RowIndex == 0 && e.CellStyle != null)
            {
                e.CellStyle.BackColor = Color.FromArgb(215, 204, 200); // #D7CCC8
            }
        }


        // ====== HANDLERS KHÁC (theo Designer, để trống cũng được) =============
        private void dtgvData_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void lblTongTien_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}
