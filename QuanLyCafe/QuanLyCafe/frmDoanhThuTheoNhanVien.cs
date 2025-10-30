﻿using System;
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
            string strSQl = @"SELECT b.TenNV, SUM(a.TongTien) AS TongTien 
                                FROM HoaDon a INNER JOIN NhanVien b ON a.MaNV = b.MaNV 
                                WHERE a.NgayLap >= @FromDate AND a.NgayLap < @ToDateNext
                                GROUP BY b.TenNV";

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
            dtgvData.Columns[0].HeaderText = "Tên nhân viên";
            dtgvData.Columns[1].HeaderText = "Tổng tiền";
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
                    total += Convert.ToDecimal(dt.Rows[i]["TongTien"]);
                }
                // Định dạng số với dấu phẩy ngăn cách hàng nghìn và thêm " VNĐ"
                lblTongTien.Text = total.ToString("N0") + " VNĐ";
            }
        }
        private void frmDoanhThuTheoNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
