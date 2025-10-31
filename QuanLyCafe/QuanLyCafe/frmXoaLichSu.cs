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

            // Lấy ngày có hóa đơn đầu tiên để làm mốc, xử lý trường hợp không có hóa đơn
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

            dtpTuNgay.Value = fromDate;
            dtpDenNgay.Value = DateTime.Today;

            // Tự động hiển thị danh sách xem trước cho tab mặc định (Xóa theo ngày)
            PreviewByDay();

            // Gán sự kiện ValueChanged sau khi đã thiết lập giá trị ban đầu
            dtpNgay.ValueChanged += new System.EventHandler(this.dtpNgay_ValueChanged);
            dtpTuNgay.ValueChanged += new System.EventHandler(this.dtpTuNgay_ValueChanged);
            dtpDenNgay.ValueChanged += new System.EventHandler(this.dtpDenNgay_ValueChanged);
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

            // Áp dụng style chung trước
            frmNhanVien.SetupDataGridView(dtgvHoaDonToDelete);

            // Quan trọng: Ghi đè thuộc tính ReadOnly của toàn bộ grid thành false
            dtgvHoaDonToDelete.ReadOnly = false;

            // Cấu hình bảng xem trước
            if (dtgvHoaDonToDelete.Columns.Contains("Select"))
            {
                dtgvHoaDonToDelete.Columns.Remove("Select");
            }

            // Thêm cột checkbox
            DataGridViewCheckBoxColumn chkCol = new DataGridViewCheckBoxColumn
            {
                Name = "Select",
                HeaderText = "Chọn",
                Width = 50,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                ReadOnly = false // Quan trọng: Cho phép tương tác với cột này
            };
            dtgvHoaDonToDelete.Columns.Insert(0, chkCol);

            dtgvHoaDonToDelete.Columns["MaHD"].HeaderText = "Mã Hóa Đơn";
            dtgvHoaDonToDelete.Columns["NgayLap"].HeaderText = "Ngày Lập";
            dtgvHoaDonToDelete.Columns["TongTien"].HeaderText = "Tổng Tiền";
            dtgvHoaDonToDelete.Columns["TongTien"].DefaultCellStyle.Format = "N0";

            // Sau khi thêm cột, đặt các cột dữ liệu thành ReadOnly, trừ cột "Select"
            foreach (DataGridViewColumn column in dtgvHoaDonToDelete.Columns)
            {
                if (column.Name != "Select")
                    column.ReadOnly = true;
            }

            return dt;
        }

        // Hàm thực hiện xóa chung
        private void ExecuteDelete()
        {
            List<string> selectedMaHDs = new List<string>();
            foreach (DataGridViewRow row in dtgvHoaDonToDelete.Rows)
            {
                // Kiểm tra giá trị của checkbox một cách an toàn
                if (row.Cells["Select"].Value != null && Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    selectedMaHDs.Add(row.Cells["MaHD"].Value.ToString()!);
                }
            }

            if (selectedMaHDs.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một hóa đơn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var parameters = new Dictionary<string, object>();
            var paramNames = new List<string>();
            for (int i = 0; i < selectedMaHDs.Count; i++)
            {
                string paramName = $"@MaHD{i}";
                parameters.Add(paramName, selectedMaHDs[i]);
                paramNames.Add(paramName);
            }

            string condition = $"MaHD IN ({string.Join(", ", paramNames)})";
            string confirmMessage = $"Bạn có chắc chắn muốn xóa {selectedMaHDs.Count} hóa đơn đã chọn không?";

            DialogResult result = MessageBox.Show(confirmMessage, "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                // Bắt đầu giao dịch
                string sqlDeleteChiTiet = $"DELETE FROM ChiTietHoaDon WHERE MaHD IN (SELECT MaHD FROM HoaDon WHERE {condition})";
                ConnectSQL.RunQuery(sqlDeleteChiTiet, parameters);

                // 3. Xóa các hóa đơn
                string sqlDeleteHoaDon = $"DELETE FROM HoaDon WHERE {condition}";
                int rowsAffected = ConnectSQL.RunQuery(sqlDeleteHoaDon, parameters);

                // 4. Cập nhật lại trạng thái các bàn có liên quan
                string sqlUpdateBan = "UPDATE Ban SET TrangThai = 0 WHERE MaBan NOT IN (SELECT MaBan FROM HoaDon WHERE TrangThai = 0)";
                ConnectSQL.RunQuery(sqlUpdateBan);

                MessageBox.Show($"Đã xóa thành công {rowsAffected} hóa đơn và các chi tiết liên quan.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaTheoNgay_Click(object sender, EventArgs e)
        {
            ExecuteDelete();
            PreviewByDay(); // Tải lại danh sách sau khi xóa
        }

        private void btnXoaTheoKhoang_Click(object sender, EventArgs e)
        {
            ExecuteDelete();
            PreviewByRange(); // Tải lại danh sách sau khi xóa
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

        // --- Các sự kiện ValueChanged ---
        private void dtpNgay_ValueChanged(object? sender, EventArgs e) { PreviewByDay(); }
        private void dtpTuNgay_ValueChanged(object? sender, EventArgs e)
        {
            dtpDenNgay.MinDate = dtpTuNgay.Value.Date;
            PreviewByRange();
        }
        private void dtpDenNgay_ValueChanged(object? sender, EventArgs e)
        {
            dtpTuNgay.MaxDate = dtpDenNgay.Value.Date;
            PreviewByRange();
        }
    }
}