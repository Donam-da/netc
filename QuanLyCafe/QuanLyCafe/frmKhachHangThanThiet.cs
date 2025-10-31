using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace QuanLyCafe
{
    [SupportedOSPlatform("windows")]
    public partial class frmKhachHangThanThiet : Form
    {
        public frmKhachHangThanThiet()
        {
            InitializeComponent();
        }

        private void frmKhachHangThanThiet_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string sql = @"
                SELECT 
                    ROW_NUMBER() OVER (ORDER BY SUM(a.TongTien) DESC) AS STT,
                    c.MaKH,
                    c.TenKH, 
                    c.SDT,
                    COUNT(a.MaHD) AS SoLanMua,
                    SUM(a.TongTien) AS TongChiTieu
                FROM HoaDon a 
                INNER JOIN KhachHang c ON a.MaKH = c.MaKH
                WHERE a.TrangThai = 1
                GROUP BY c.MaKH, c.TenKH, c.SDT
                ORDER BY TongChiTieu DESC";

            DataTable dt = ConnectSQL.Load(sql);
            dtgvData.DataSource = dt;

            // Cấu hình DataGridView
            frmNhanVien.SetupDataGridView(dtgvData);
            dtgvData.Columns["STT"].HeaderText = "Hạng";
            dtgvData.Columns["MaKH"].Visible = false; // Ẩn cột MaKH
            dtgvData.Columns["TenKH"].HeaderText = "Tên Khách Hàng";
            dtgvData.Columns["SDT"].HeaderText = "Số Điện Thoại";
            dtgvData.Columns["SoLanMua"].HeaderText = "Số Lần Mua";
            dtgvData.Columns["TongChiTieu"].HeaderText = "Tổng Chi Tiêu";

            // Định dạng cột
            dtgvData.Columns["STT"].Width = 60;
            dtgvData.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvData.Columns["SoLanMua"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvData.Columns["TongChiTieu"].DefaultCellStyle.Format = "N0";
            dtgvData.Columns["TongChiTieu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void dtgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maKH = dtgvData.Rows[e.RowIndex].Cells["MaKH"].Value.ToString()!;
                string tenKH = dtgvData.Rows[e.RowIndex].Cells["TenKH"].Value.ToString()!;
                LoadLichSuMuaHang(maKH, tenKH);
            }
        }

        private void LoadLichSuMuaHang(string maKH, string tenKH)
        {
            lblLichSu.Text = $"Lịch sử mua hàng của: {tenKH}";

            string sql = @"
                SELECT 
	                ROW_NUMBER() OVER (ORDER BY hd.NgayLap DESC) AS STT,
	                hd.NgayLap,
	                cthd.MaDU,
	                cthd.ThanhTien
                FROM HoaDon hd
                JOIN ChiTietHoaDon cthd ON hd.MaHD = cthd.MaHD
                WHERE hd.TrangThai = 1 AND hd.MaKH = @MaKH
                ORDER BY hd.NgayLap DESC";

            var parameters = new Dictionary<string, object> { { "@MaKH", maKH } };
            DataTable dt = ConnectSQL.Load(sql, parameters);
            dtgvLichSuMuaHang.DataSource = dt;

            // Cấu hình DataGridView
            frmNhanVien.SetupDataGridView(dtgvLichSuMuaHang);
            dtgvLichSuMuaHang.Columns["STT"].HeaderText = "STT";
            dtgvLichSuMuaHang.Columns["NgayLap"].HeaderText = "Ngày Giờ Mua";
            dtgvLichSuMuaHang.Columns["MaDU"].HeaderText = "Mã Đồ Uống";
            dtgvLichSuMuaHang.Columns["ThanhTien"].HeaderText = "Tiền Chi Tiêu";
            dtgvLichSuMuaHang.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }
    }
}