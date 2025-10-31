﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace QuanLyCafe
{
    [SupportedOSPlatform("windows")]
    public partial class frmXoaLichSu : Form
    {
        public frmXoaLichSu()
        {
            InitializeComponent();
        }

        private void frmXoaLichSu_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định cho các DateTimePicker
            dtpNgay.Value = DateTime.Today;
            dtpThang.Value = DateTime.Today;
            dtpTuNgay.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpDenNgay.Value = DateTime.Today;

            // Tự động hiển thị danh sách xem trước cho tab mặc định (Xóa theo ngày)
            PreviewByDay();
        }

        // Hàm xem trước các hóa đơn sẽ bị xóa
        private DataTable PreviewInvoices(string condition, Dictionary<string, object> parameters)
        {
            string sql = $@"SELECT MaHD, NgayLap, TongTien 
                            FROM HoaDon 
                            WHERE {condition}
                            ORDER BY NgayLap DESC";
            DataTable dt = ConnectSQL.Load(sql, parameters);
            dtgvHoaDonToDelete.DataSource = dt;

            // Cấu hình bảng xem trước
            frmNhanVien.SetupDataGridView(dtgvHoaDonToDelete);
            dtgvHoaDonToDelete.Columns["MaHD"].HeaderText = "Mã Hóa Đơn";
            dtgvHoaDonToDelete.Columns["NgayLap"].HeaderText = "Ngày Lập";
            dtgvHoaDonToDelete.Columns["TongTien"].HeaderText = "Tổng Tiền";
            dtgvHoaDonToDelete.Columns["TongTien"].DefaultCellStyle.Format = "N0";

            return dt;
        }

        // Hàm thực hiện xóa chung
        private void ExecuteDelete(string condition, Dictionary<string, object> parameters, string confirmMessage)
        {
            if (dtgvHoaDonToDelete.Rows.Count == 0)
            {
                MessageBox.Show("Không có hóa đơn nào trong khoảng thời gian đã chọn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Bắt đầu giao dịch
                DialogResult result = MessageBox.Show(confirmMessage, "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return;
                }
                string sqlDeleteChiTiet = $"DELETE FROM ChiTietHoaDon WHERE MaHD IN (SELECT MaHD FROM HoaDon WHERE {condition})";
                ConnectSQL.RunQuery(sqlDeleteChiTiet, parameters);

                // 3. Xóa các hóa đơn
                string sqlDeleteHoaDon = $"DELETE FROM HoaDon WHERE {condition}";
                int rowsAffected = ConnectSQL.RunQuery(sqlDeleteHoaDon, parameters);

                // 4. Cập nhật lại trạng thái các bàn có liên quan
                string sqlUpdateBan = "UPDATE Ban SET TrangThai = 0 WHERE MaBan NOT IN (SELECT MaBan FROM HoaDon WHERE TrangThai = 0)";
                ConnectSQL.RunQuery(sqlUpdateBan);

                MessageBox.Show($"Đã xóa thành công {rowsAffected} hóa đơn và các chi tiết liên quan.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Báo cho form chính biết là đã có thay đổi
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaTheoNgay_Click(object sender, EventArgs e)
        {
            string condition = "CAST(NgayLap AS DATE) = @SelectedDate";
            var parameters = new Dictionary<string, object> { { "@SelectedDate", dtpNgay.Value.Date } };
            string message = $"Bạn có chắc chắn muốn xóa toàn bộ lịch sử giao dịch trong ngày {dtpNgay.Value.Date:dd/MM/yyyy} không?";
            ExecuteDelete(condition, parameters, message);
        }

        private void btnXoaTheoThang_Click(object sender, EventArgs e)
        {
            string condition = "NgayLap >= @StartDate AND NgayLap < @EndDate";
            var parameters = GetMonthRangeParameters(dtpThang.Value);
            string message = $"Bạn có chắc chắn muốn xóa toàn bộ lịch sử giao dịch trong tháng {dtpThang.Value:MM/yyyy} không?";
            ExecuteDelete(condition, parameters, message);
        }

        private void btnXoaTheoKhoang_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("'Từ ngày' phải nhỏ hơn 'Đến ngày'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string condition = "NgayLap >= @StartDate AND NgayLap < @EndDate";
            var parameters = new Dictionary<string, object>
            {
                { "@StartDate", dtpTuNgay.Value.Date },
                { "@EndDate", dtpDenNgay.Value.Date.AddDays(1) }
            };
            string message = $"Bạn có chắc chắn muốn xóa toàn bộ lịch sử giao dịch từ ngày {dtpTuNgay.Value.Date:dd/MM/yyyy} đến {dtpDenNgay.Value.Date:dd/MM/yyyy} không?";
            ExecuteDelete(condition, parameters, message);
        }

        private void btnXoaToanBo_Click(object sender, EventArgs e)
        {
            // Xem trước toàn bộ hóa đơn
            string sqlPreviewAll = "SELECT MaHD, NgayLap, TongTien FROM HoaDon WHERE TrangThai = 1 ORDER BY NgayLap DESC";
            if (ConnectSQL.Load(sqlPreviewAll).Rows.Count == 0)
            {
                MessageBox.Show("Không có hóa đơn nào để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string warningMessage = "BẠN CÓ CHẮC CHẮN MUỐN XÓA TOÀN BỘ LỊCH SỬ GIAO DỊCH?\n\n" +
                                    "Hành động này sẽ xóa vĩnh viễn tất cả hóa đơn và chi tiết hóa đơn đã lưu. " +
                                    "Dữ liệu sẽ không thể khôi phục.";

            DialogResult result = MessageBox.Show(warningMessage, "CẢNH BÁO XÓA DỮ LIỆU", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ConnectSQL.RunQuery("DELETE FROM ChiTietHoaDon");
                    ConnectSQL.RunQuery("DELETE FROM HoaDon");
                    ConnectSQL.RunQuery("UPDATE Ban SET TrangThai = 0");

                    MessageBox.Show("Đã xóa toàn bộ lịch sử giao dịch thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- Các hàm hỗ trợ xem trước ---
        private void PreviewByDay()
        {
            string condition = "CAST(NgayLap AS DATE) = @SelectedDate";
            var parameters = new Dictionary<string, object> { { "@SelectedDate", dtpNgay.Value.Date } };
            PreviewInvoices(condition, parameters);
        }

        private void PreviewByMonth()
        {
            string condition = "NgayLap >= @StartDate AND NgayLap < @EndDate";
            var parameters = GetMonthRangeParameters(dtpThang.Value);
            PreviewInvoices(condition, parameters);
        }

        private void PreviewByRange()
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date) return; // Không làm gì nếu ngày không hợp lệ
            string condition = "NgayLap >= @StartDate AND NgayLap < @EndDate";
            var parameters = new Dictionary<string, object>
            {
                { "@StartDate", dtpTuNgay.Value.Date },
                { "@EndDate", dtpDenNgay.Value.Date.AddDays(1) }
            };
            PreviewInvoices(condition, parameters);
        }

        private Dictionary<string, object> GetMonthRangeParameters(DateTime selectedMonth)
        {
            DateTime startDate = new DateTime(selectedMonth.Year, selectedMonth.Month, 1);
            DateTime endDate = startDate.AddMonths(1);
            return new Dictionary<string, object> { { "@StartDate", startDate }, { "@EndDate", endDate } };
        }

        // --- Các sự kiện ValueChanged ---
        private void dtpNgay_ValueChanged(object sender, EventArgs e) => PreviewByDay();
        private void dtpThang_ValueChanged(object sender, EventArgs e) => PreviewByMonth();
        private void dtpTuNgay_ValueChanged(object sender, EventArgs e) => PreviewByRange();
        private void dtpDenNgay_ValueChanged(object sender, EventArgs e) => PreviewByRange();
    }
}