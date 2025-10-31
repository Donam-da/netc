﻿﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    [SupportedOSPlatform("windows")]
    public partial class frmDoanhThuTheoNhanVien: Form
    {
        public frmDoanhThuTheoNhanVien()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            // Kiểm tra khoảng ngày hợp lệ
            if (dtDFrom.Value.Date > dtDTo.Value.Date)
            {
                MessageBox.Show("Khoảng ngày không hợp lệ. 'Từ ngày' phải nhỏ hơn hoặc bằng 'Đến ngày'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sử dụng truy vấn tham số để chống SQL Injection
            string strSQl = @"SELECT 
                                  b.TenNV, 
                                  COUNT(a.MaHD) AS SoDonDaBan, 
                                  SUM(a.TongTien) AS DoanhThu 
                              FROM HoaDon a INNER JOIN NhanVien b ON a.MaNV = b.MaNV 
                              WHERE a.TrangThai = 1 AND a.NgayLap >= @FromDate AND a.NgayLap < @ToDateNext
                              GROUP BY b.TenNV
                              ORDER BY DoanhThu DESC";

            // Tạo danh sách tham số
            var parameters = new Dictionary<string, object>
            {
                { "@FromDate", dtDFrom.Value.Date },
                { "@ToDateNext", dtDTo.Value.Date.AddDays(1) } // Lấy đến đầu ngày hôm sau để bao gồm cả ngày kết thúc
            };

            DataTable dt = new DataTable();
            // Gọi phương thức Load đã được cập nhật để nhận tham số
            dt = ConnectSQL.Load(strSQl, parameters);
            dtgvData.DataSource = dt;
            frmNhanVien.SetupDataGridView(dtgvData);

            // Cấu hình các cột
            dtgvData.Columns["TenNV"].HeaderText = "Tên Nhân Viên";
            dtgvData.Columns["SoDonDaBan"].HeaderText = "Số Đơn Đã Bán";
            dtgvData.Columns["DoanhThu"].HeaderText = "Doanh Thu";

            dtgvData.Columns["TenNV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvData.Columns["SoDonDaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvData.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
            dtgvData.Columns["DoanhThu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dtgvData.Rows.Count == 0)
            {
                lblTongTien.Text = "0 VNĐ";
            }
            else
            {
                decimal total = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    // Sử dụng Convert.ToDecimal để xử lý an toàn các giá trị có thể là DBNull
                    total += Convert.ToDecimal(dt.Rows[i]["DoanhThu"]);
                }
                // Định dạng số với dấu phẩy ngăn cách hàng nghìn và thêm " VNĐ"
                lblTongTien.Text = total.ToString("N0") + " VNĐ";
            }
        }
        private void frmDoanhThuTheoNhanVien_Load(object sender, EventArgs e)
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
            if (dtDTo.Value.Date < dtDFrom.Value.Date)
            {
                dtDTo.Value = dtDFrom.Value.Date;
            }
            dtDTo.MinDate = dtDFrom.Value.Date;

            LoadData();

            // Gán lại sự kiện sau khi đã thiết lập giá trị ban đầu để tránh lỗi
            dtDFrom.ValueChanged += new System.EventHandler(this.dtDFrom_ValueChanged);
            dtDTo.ValueChanged += new System.EventHandler(this.dtDTo_ValueChanged);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
