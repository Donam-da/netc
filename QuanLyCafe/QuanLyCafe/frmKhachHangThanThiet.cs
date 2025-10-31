﻿using System;
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
            LoadQuyTacGiamGia();
        }

        private void LoadData()
        {
            string sql = @"
                SELECT 
                    ROW_NUMBER() OVER (ORDER BY SUM(a.TongTien) DESC) AS STT,
                    c.MaKH,
                    c.TenKH, 
                    c.SDT,
                    c.GiamGia,
                    c.SoLanMua_LuuTru + ISNULL(COUNT(a.MaHD), 0) AS SoLanMua,
                    c.TongChiTieu_LuuTru + ISNULL(SUM(a.TongTien), 0) AS TongChiTieu
                FROM KhachHang c
                LEFT JOIN HoaDon a ON c.MaKH = a.MaKH AND a.TrangThai = 1
                WHERE c.MaKH <> 'KHVL' -- Loại bỏ khách vãng lai mẫu
                GROUP BY c.MaKH, c.TenKH, c.SDT, c.GiamGia, c.SoLanMua_LuuTru, c.TongChiTieu_LuuTru
                ORDER BY TongChiTieu DESC, SoLanMua DESC";

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
            dtgvData.Columns["GiamGia"].HeaderText = "Giảm Giá (%)";

            // Định dạng cột
            dtgvData.Columns["STT"].Width = 60;
            dtgvData.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvData.Columns["SoLanMua"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvData.Columns["TongChiTieu"].DefaultCellStyle.Format = "N0";
            dtgvData.Columns["TongChiTieu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgvData.Columns["GiamGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvData.Columns["GiamGia"].DefaultCellStyle.Format = "N1";
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
        private void LoadQuyTacGiamGia()
        {
            string sql = "SELECT MaQuyTac, LoaiQuyTac, Nguong, PhanTramGiamGia FROM QuyTacGiamGia ORDER BY LoaiQuyTac, Nguong";
            DataTable dt = ConnectSQL.Load(sql);
            dtgvQuyTac.DataSource = dt;

            // Cấu hình DataGridView
            frmNhanVien.SetupDataGridView(dtgvQuyTac);
            dtgvQuyTac.Columns["MaQuyTac"].Visible = false;
            dtgvQuyTac.Columns["LoaiQuyTac"].HeaderText = "Tiêu chí";
            dtgvQuyTac.Columns["Nguong"].HeaderText = "Ngưỡng";
            dtgvQuyTac.Columns["PhanTramGiamGia"].HeaderText = "Giảm giá (%)";

            // Định dạng
            dtgvQuyTac.Columns["Nguong"].DefaultCellStyle.Format = "N0";
            dtgvQuyTac.Columns["PhanTramGiamGia"].DefaultCellStyle.Format = "N1";
        }

        private void btnThemQuyTac_Click(object sender, EventArgs e)
        {
            decimal nguong = nmNguong.Value;
            decimal phanTramGiamGia = nmPhanTramGiamGia.Value;

            if (nguong <= 0 || phanTramGiamGia <= 0)
            {
                MessageBox.Show("Ngưỡng và Phần trăm giảm giá phải lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string loaiQuyTac = rbSoLanMua.Checked ? "SoLanMua" : "TongChiTieu";

            string sql = "INSERT INTO QuyTacGiamGia (LoaiQuyTac, Nguong, PhanTramGiamGia) VALUES (@LoaiQuyTac, @Nguong, @PhanTramGiamGia)";
            var parameters = new Dictionary<string, object>
            {
                { "@LoaiQuyTac", loaiQuyTac },
                { "@Nguong", nguong },
                { "@PhanTramGiamGia", phanTramGiamGia }
            };

            ConnectSQL.RunQuery(sql, parameters);
            MessageBox.Show("Thêm quy tắc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadQuyTacGiamGia();
        }

        private void btnXoaQuyTac_Click(object sender, EventArgs e)
        {
            if (dtgvQuyTac.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một quy tắc để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa quy tắc này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                string maQuyTac = dtgvQuyTac.CurrentRow.Cells["MaQuyTac"].Value.ToString()!;
                string sql = "DELETE FROM QuyTacGiamGia WHERE MaQuyTac = @MaQuyTac";
                ConnectSQL.RunQuery(sql, new Dictionary<string, object> { { "@MaQuyTac", maQuyTac } });
                MessageBox.Show("Xóa quy tắc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadQuyTacGiamGia();
            }
        }

        private void btnApDungTatCa_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Hệ thống sẽ tự động tính toán và cập nhật lại mức giảm giá cho TẤT CẢ khách hàng dựa trên các quy tắc hiện có.\n\nMức giảm giá cao nhất mà khách hàng đạt được sẽ được áp dụng.\n\nBạn có muốn tiếp tục?",
                "Xác nhận Áp dụng Giảm giá",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.No) return;

            // 1. Lấy tất cả quy tắc, sắp xếp để ưu tiên mức cao hơn
            string sqlRules = "SELECT LoaiQuyTac, Nguong, PhanTramGiamGia FROM QuyTacGiamGia ORDER BY PhanTramGiamGia DESC";
            DataTable dtRules = ConnectSQL.Load(sqlRules);

            // 2. Lấy thông tin mua hàng của tất cả khách hàng
            string sqlCustomerStats = @"
                SELECT 
                    c.MaKH,
                    c.SoLanMua_LuuTru + ISNULL(COUNT(a.MaHD), 0) AS SoLanMua,
                    c.TongChiTieu_LuuTru + ISNULL(SUM(a.TongTien), 0) AS TongChiTieu
                FROM KhachHang c
                LEFT JOIN HoaDon a ON c.MaKH = a.MaKH AND a.TrangThai = 1
                WHERE c.MaKH <> 'KHVL' GROUP BY c.MaKH, c.SoLanMua_LuuTru, c.TongChiTieu_LuuTru";
            DataTable dtCustomerStats = ConnectSQL.Load(sqlCustomerStats);

            // 3. Duyệt qua từng khách hàng để xác định mức giảm giá
            foreach (DataRow customerRow in dtCustomerStats.Rows)
            {
                string maKH = customerRow["MaKH"].ToString()!;
                int soLanMua = Convert.ToInt32(customerRow["SoLanMua"]);
                decimal tongChiTieu = Convert.ToDecimal(customerRow["TongChiTieu"]);
                decimal giamGiaCaoNhat = 0;

                // Tìm mức giảm giá cao nhất khách hàng này đạt được
                foreach (DataRow ruleRow in dtRules.Rows)
                {
                    string loaiQuyTac = ruleRow["LoaiQuyTac"].ToString()!;
                    decimal nguong = Convert.ToDecimal(ruleRow["Nguong"]);
                    decimal phanTram = Convert.ToDecimal(ruleRow["PhanTramGiamGia"]);

                    if ((loaiQuyTac == "SoLanMua" && soLanMua >= nguong) || (loaiQuyTac == "TongChiTieu" && tongChiTieu >= nguong))
                    {
                        giamGiaCaoNhat = phanTram;
                        break; // Vì đã sắp xếp giảm dần, quy tắc đầu tiên thỏa mãn là cao nhất
                    }
                }

                // 4. Cập nhật giảm giá cho khách hàng
                string sqlUpdate = "UPDATE KhachHang SET GiamGia = @GiamGia WHERE MaKH = @MaKH";
                ConnectSQL.RunQuery(sqlUpdate, new Dictionary<string, object> { { "@GiamGia", giamGiaCaoNhat }, { "@MaKH", maKH } });
            }

            MessageBox.Show("Đã áp dụng và cập nhật giảm giá cho tất cả khách hàng thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData(); // Tải lại dữ liệu để thấy thay đổi
        }
    }
}