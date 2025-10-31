using System;
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
        }

        // Hàm thực hiện xóa chung
        private void ExecuteDelete(string condition, Dictionary<string, object> parameters, string confirmMessage)
        {
            DialogResult result = MessageBox.Show(confirmMessage, "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                // Bắt đầu giao dịch
                // 1. Lấy danh sách các hóa đơn sẽ bị xóa
                string sqlGetHoaDon = $"SELECT MaHD FROM HoaDon WHERE {condition}";
                DataTable dtHoaDonToDelete = ConnectSQL.Load(sqlGetHoaDon, parameters);

                if (dtHoaDonToDelete.Rows.Count == 0)
                {
                    MessageBox.Show("Không có hóa đơn nào trong khoảng thời gian đã chọn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 2. Xóa các chi tiết hóa đơn liên quan
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
            DateTime selectedDate = dtpNgay.Value.Date;
            string condition = "CAST(NgayLap AS DATE) = @SelectedDate";
            var parameters = new Dictionary<string, object> { { "@SelectedDate", selectedDate } };
            string message = $"Bạn có chắc chắn muốn xóa toàn bộ lịch sử giao dịch trong ngày {selectedDate:dd/MM/yyyy} không?";
            ExecuteDelete(condition, parameters, message);
        }

        private void btnXoaTheoThang_Click(object sender, EventArgs e)
        {
            DateTime selectedMonth = dtpThang.Value;
            DateTime startDate = new DateTime(selectedMonth.Year, selectedMonth.Month, 1);
            DateTime endDate = startDate.AddMonths(1);

            string condition = "NgayLap >= @StartDate AND NgayLap < @EndDate";
            var parameters = new Dictionary<string, object>
            {
                { "@StartDate", startDate },
                { "@EndDate", endDate }
            };
            string message = $"Bạn có chắc chắn muốn xóa toàn bộ lịch sử giao dịch trong tháng {startDate:MM/yyyy} không?";
            ExecuteDelete(condition, parameters, message);
        }

        private void btnXoaTheoKhoang_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpTuNgay.Value.Date;
            DateTime endDate = dtpDenNgay.Value.Date.AddDays(1);

            if (startDate >= endDate)
            {
                MessageBox.Show("'Từ ngày' phải nhỏ hơn 'Đến ngày'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string condition = "NgayLap >= @StartDate AND NgayLap < @EndDate";
            var parameters = new Dictionary<string, object>
            {
                { "@StartDate", startDate },
                { "@EndDate", endDate }
            };
            string message = $"Bạn có chắc chắn muốn xóa toàn bộ lịch sử giao dịch từ ngày {startDate:dd/MM/yyyy} đến {dtpDenNgay.Value.Date:dd/MM/yyyy} không?";
            ExecuteDelete(condition, parameters, message);
        }

        private void btnXoaToanBo_Click(object sender, EventArgs e)
        {
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
    }
}