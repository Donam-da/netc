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
    public partial class frmDoanhThuTheoNgay: Form
    {
        public frmDoanhThuTheoNgay()
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
            string strSQl = @"SELECT CAST(NgayLap AS DATE) AS Ngay, SUM(TongTien) AS TongTien 
                        FROM HoaDon 
                        WHERE NgayLap >= @FromDate AND NgayLap < @ToDateNext
                        GROUP BY CAST(NgayLap AS DATE)
                        ORDER BY Ngay";

            // Tạo danh sách tham số
            var parameters = new Dictionary<string, object>
            {
                { "@FromDate", dtDFrom.Value.Date },
                { "@ToDateNext", dtDTo.Value.Date.AddDays(1) } // Lấy đến đầu ngày hôm sau để bao gồm cả ngày kết thúc
            };

            DataTable dt = new DataTable();
            dt = ConnectSQL.Load(strSQl, parameters);
            dtgvData.DataSource = dt;
            frmNhanVien.SetupDataGridView(dtgvData);
            dtgvData.Columns[0].HeaderText = "Ngày";
            dtgvData.Columns[1].HeaderText = "Tổng tiền";
            dtgvData.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dtgvData.Rows.Count == 0)
            {
                lblTongTien.Text = "0 VNĐ";
            }
            else
            {
                decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("TongTien"));
                lblTongTien.Text = total.ToString("N0") + " VNĐ";
            }
        }
        private void frmDoanhThuTheoNgay_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLocDuLieu_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
