using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyCafe
{
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
            try
            {
                dtDFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                dtDTo.Value = DateTime.Today;
            }
            catch { /* ignore */ }

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
            // LoadData();
        }

        private void dtDTo_ValueChanged(object sender, EventArgs e)
        {
            // LoadData();
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
            string from = dtDFrom.Value.ToString("yyyyMMdd");              // ví dụ 20251007 00:00
            string toNext = dtDTo.Value.AddDays(1).ToString("yyyyMMdd");   // ngày hôm sau của "Đến ngày"

            // TOP hàng bán chạy theo Số lượng (nếu bằng nhau, theo Doanh thu)
            string sqlTop = $@"
        SELECT d.TenDU AS [Đồ uống],                  -- Tên đồ uống hiển thị
               SUM(ct.SoLuong)   AS [Số lượng],       -- Tổng số lượng đã bán
               SUM(ct.ThanhTien) AS [Doanh thu]       -- Tổng doanh thu (đã tính sẵn ở chi tiết)
        FROM HoaDon hd
        JOIN ChiTietHoaDon ct ON ct.MaHD = hd.MaHD
        JOIN DoUong d        ON d.MaDU = ct.MaDU
        WHERE hd.NgayLap >= '{from}' AND hd.NgayLap < '{toNext}' -- lọc theo khoảng ngày [from, toNext)
        GROUP BY d.TenDU
        ORDER BY SUM(ct.SoLuong) DESC, SUM(ct.ThanhTien) DESC";    // sắp xếp: SL giảm dần, rồi DT giảm dần

            DataTable dt = ConnectSQL.Load(sqlTop);   // Thực thi SQL và lấy bảng dữ liệu
            dtgvData.DataSource = dt;                 // Đổ vào DataGridView

            // Căn lề & định dạng cột số
            if (dtgvData.Columns.Count >= 3)
            {
                dtgvData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Canh phải cột "Số lượng"
                dtgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Canh phải cột "Doanh thu"
                dtgvData.Columns[2].DefaultCellStyle.Format = "N0";                                        // Định dạng tiền N0 (1.234.567)
            }

            // Tính tổng doanh thu
            decimal tong = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    if (decimal.TryParse(r["Doanh thu"].ToString(), out decimal v))
                        tong += v; // Cộng dồn doanh thu
                }

                lblTongTien.Text = tong.ToString("N0") + " VNĐ"; // Hiển thị tổng doanh thu ở dưới

                // Cập nhật tiêu đề form với Top 1 (dòng đầu tiên sau khi ORDER BY)
                string tenTop1 = dt.Rows[0]["Đồ uống"].ToString();
                string slTop1 = dt.Rows[0]["Số lượng"].ToString();
                string dtTop1 = Convert.ToDecimal(dt.Rows[0]["Doanh thu"]).ToString("N0");
                this.Text = $"Top hàng bán chạy (Top 1: {tenTop1} - SL: {slTop1}, DT: {dtTop1} VNĐ)";
            }
            else
            {
                lblTongTien.Text = "0 VNĐ";           // Không có dữ liệu: tổng = 0
                this.Text = "Top hàng bán chạy";      // Tiêu đề mặc định
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
