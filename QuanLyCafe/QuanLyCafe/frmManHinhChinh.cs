﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Versioning;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyCafe
{
    [SupportedOSPlatform("windows")]
    public partial class frmManHinhChinh: Form
    {
        public static string MaHDThanhToan = string.Empty;
        public static string TongTienThanhToan = string.Empty;
        public static string MaBanThanhToan = string.Empty;

        public frmManHinhChinh()
        {
            InitializeComponent();
        }
        private void menuNhanVien_Click(object? sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.ShowDialog();
            RefreshAllData();
        }

        private void hệThốngToolStripMenuItem_Click(object? sender, EventArgs e)
        {

        }
        
        private void menuThongTinCaNhan_Click(object? sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.ShowDialog();
        }
        
        private void menuLDU_Click(object? sender, EventArgs e)
        {
            frmLoaiDoUong frm = new frmLoaiDoUong();
            frm.ShowDialog();
            RefreshAllData();
        }

        private void menuBan_Click(object? sender, EventArgs e)
        {
            frmBan frm = new frmBan();
            frm.ShowDialog();
            RefreshAllData();
        }

        private void menuDoUong_Click(object? sender, EventArgs e)
        {
            string? selectedMaDU = null;
            // Kiểm tra xem có dòng nào đang được chọn trong dtgvDoUong không
            if (dtgvDoUong.CurrentRow != null && dtgvDoUong.CurrentRow.Index >= 0)
            {
                // Lấy MaDU từ dòng đang được chọn
                selectedMaDU = dtgvDoUong.CurrentRow.Cells["MaDU"].Value?.ToString();
            }

            // Mở form DoUong, truyền MaDU đã chọn (hoặc null nếu không có)
            frmDoUong frm = new frmDoUong(selectedMaDU!);
            frm.ShowDialog();
            RefreshAllData();
        }

        private void menuKH_Click(object? sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.ShowDialog();
            RefreshAllData();
        }
        private void RefreshAllData()
        {
            LoadTable();
            LoadMenuDoUong();
            LoadDoUongDaGoi();
            CheckLowStock(); // Thêm kiểm tra tồn kho vào hàm refresh chung
        }

        private void LoadTable()
        {
            string strSQL = "SELECT MaBan, SucChua, TrangThai FROM Ban";
            var parameters = new Dictionary<string, object>();

            if (rbYes.Checked)
            {
                strSQL += " WHERE TrangThai = @TrangThai";
                parameters.Add("@TrangThai", "1");
            }
            else if (rbNo.Checked)
            {
                strSQL += " WHERE TrangThai = @TrangThai";
                parameters.Add("@TrangThai", "0");
            }

            // Thêm sắp xếp theo phần số của MaBan để có thứ tự tự nhiên (BAN1, BAN2, ..., BAN10)
            strSQL += " ORDER BY CAST(SUBSTRING(MaBan, 4, LEN(MaBan)) AS INT)";
            DataTable dt = ConnectSQL.Load(strSQL, parameters);

            // Thêm cột STT vào DataTable
            dt.Columns.Add("STT", typeof(int));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["STT"] = i + 1;
            }

            dtgvBan.DataSource = dt;
            frmNhanVien.SetupDataGridView(dtgvBan);

            // Đặt lại tên và thứ tự cột
            dtgvBan.Columns["STT"].DisplayIndex = 0;
            dtgvBan.Columns["MaBan"].HeaderText = "Mã Bàn";
            dtgvBan.Columns["SucChua"].HeaderText = "Sức chứa";
            dtgvBan.Columns["TrangThai"].HeaderText = "Trạng thái";
            dtgvBan.Columns["MaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvBan.Columns["SucChua"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvBan.Columns["TrangThai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvBan.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvBan.Columns["STT"].Width = 50;
        }
        private void LoadMenuDoUong()
        {
            // Ngăn DataGridView tự động tạo cột, để chúng ta có thể kiểm soát hoàn toàn.
            dtgvDoUong.AutoGenerateColumns = false;

            // Lấy thêm cột NguongCanhBao để kiểm tra và tô màu
            string strSQL = @"SELECT MaDU, TenDU, MaLoai, DonGia, SoLuongTon, NguongCanhBao FROM DoUong WHERE IsHienThi = 1 AND TenDU LIKE @TenDU";
            var parameters = new Dictionary<string, object>
            {
                { "@TenDU", $"%{txtTenDoUong.Text}%" }
            };
            DataTable dt = ConnectSQL.Load(strSQL, parameters);
            dtgvDoUong.DataSource = dt;

            frmNhanVien.SetupDataGridView(dtgvDoUong);
            dtgvDoUong.Columns["MaDU"].DataPropertyName = "MaDU";
            dtgvDoUong.Columns["TenDU"].DataPropertyName = "TenDU";
            dtgvDoUong.Columns["MaLoai"].DataPropertyName = "MaLoai";
            dtgvDoUong.Columns["DonGia"].DataPropertyName = "DonGia";
            dtgvDoUong.Columns["SoLuongTon"].DataPropertyName = "SoLuongTon";
            // Thiết lập độ rộng cho các nút
            dtgvDoUong.Columns["SuaDoUong"].Width = 80;
        }
        private void frmManHinhChinh_Load(object? sender, EventArgs e)
        {
            if (frmDangNhap.Quyen == "Nhân viên")
            {
                menuNhanVien.Enabled = false;
            }
            // Áp dụng renderer tùy chỉnh cho ToolStrip
            toolStrip1.Renderer = new MyMenuRenderer();

            // Thêm sự kiện CellFormatting để tô màu cảnh báo tồn kho
            dtgvDoUong.CellFormatting += dtgvDoUong_CellFormatting;

            LoadTable();
            LoadMenuDoUong();
            CheckLowStock();
        }

        private void rbYes_CheckedChanged(object? sender, EventArgs e)
        {
            LoadTable();
        }

        private void rbNo_CheckedChanged(object? sender, EventArgs e)
        {
            LoadTable();
        }

        private void rbAll_CheckedChanged(object? sender, EventArgs e)
        {
            LoadTable();
        }

        private void btnTim_Click(object? sender, EventArgs e)
        {
            LoadMenuDoUong();
        }

        private void dtgvBan_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu click vào header
            if (e.RowIndex >= 0)
            {
                btnBanDaChon.Text = dtgvBan.Rows[e.RowIndex].Cells["MaBan"].Value?.ToString() ?? string.Empty;
                LoadDoUongDaGoi();
            }
        }

        private void dtgvBan_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu nhấn đúp vào header
            if (e.RowIndex >= 0)
            {
                string maBan = dtgvBan.Rows[e.RowIndex].Cells["MaBan"].Value?.ToString() ?? string.Empty;
                frmBan frm = new frmBan(maBan); // Truyền mã bàn được chọn sang form sửa
                frm.ShowDialog();
                RefreshAllData();
            }
        }

        private void dtgvBan_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            // Tô màu và đổi text cho cột "Trạng thái"
            var trangThaiCol = dtgvBan.Columns["TrangThai"];
            if (trangThaiCol != null && e.RowIndex >= 0 && e.ColumnIndex == trangThaiCol.Index && e.Value != null)
            {
                bool coNguoi = e.Value.ToString() == "1";
                e.Value = coNguoi ? "Chưa thanh toán" : "Bàn trống";
                e.CellStyle.ForeColor = coNguoi ? Color.Red : Color.Green;
            }
        }
        private void LoadDoUongDaGoi()
        {
            if (string.IsNullOrEmpty(btnBanDaChon.Text) || btnBanDaChon.Text == "Chưa chọn bàn") return;

            string strSQL = @"SELECT a.MaDU, c.TenDU, a.SoLuong, a.DonGia, a.ThanhTien, b.MaHD 
                                FROM ChiTietHoaDon a 
                                INNER JOIN HoaDon b ON a.MaHD = b.MaHD 
                                INNER JOIN DoUong c ON a.MaDU = c.MaDU 
                                WHERE b.MaBan = @MaBan AND b.Trangthai = 0";

            var parameters = new Dictionary<string, object>
            {
                { "@MaBan", btnBanDaChon.Text }
            };

            DataTable dt = ConnectSQL.Load(strSQL, parameters);
            dtgvHoaDon.DataSource = dt;
            frmNhanVien.SetupDataGridView(dtgvHoaDon);
            dtgvHoaDon.Columns[0].HeaderText = "Mã đồ uống";
            dtgvHoaDon.Columns[1].HeaderText = "Tên đồ uống";
            dtgvHoaDon.Columns[2].HeaderText = "Số lượng";
            dtgvHoaDon.Columns[3].HeaderText = "Đơn giá";
            dtgvHoaDon.Columns[4].HeaderText = "Thành tiền";
            dtgvHoaDon.Columns[5].Visible = false;

            // Cho phép chỉnh sửa cột số lượng
            dtgvHoaDon.ReadOnly = false;
            foreach (DataGridViewColumn col in dtgvHoaDon.Columns) col.ReadOnly = true;
            dtgvHoaDon.Columns["SoLuong"].ReadOnly = false;
            decimal total = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                total += Convert.ToDecimal(dt.Rows[i]["ThanhTien"]);
            }
            lblTongTien.Text = total.ToString() + " VNĐ";
            TongTienThanhToan = total.ToString();
        }

        private void ThemMon(string maDU, decimal donGia, decimal soLuong)
        {
            string maBan = btnBanDaChon.Text;
            // Hóa đơn chưa có món nào
            if (dtgvHoaDon.Rows.Count == 0)
            {
                string maHD = TaoMaHoaDonMoi(maBan);
                ThemChiTietHoaDon(maHD, maDU, soLuong, donGia);
                CapNhatTrangThaiBan(maBan, 1); // Bàn có người
            }
            // Hóa đơn đã có món
            else
            {
                string maHD = dtgvHoaDon.Rows[0].Cells["MaHD"].Value.ToString()!;
                if (KiemTraMonDaTonTai(maHD, maDU))
                {
                    CapNhatSoLuongMon(maHD, maDU, soLuong, donGia);
                }
                else
                {
                    ThemChiTietHoaDon(maHD, maDU, soLuong, donGia);
                }
            }
            LoadDoUongDaGoi();
            LoadTable();
            ShowStatus("Thêm món thành công!");
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (dtgvHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để xóa");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string maHD = dtgvHoaDon.CurrentRow!.Cells["MaHD"].Value.ToString()!;
                string maDU = dtgvHoaDon.CurrentRow.Cells["MaDU"].Value.ToString()!;
                string strSQL = "DELETE FROM ChiTietHoaDon WHERE MaHD = @MaHD AND MaDU = @MaDU";
                var parameters = new Dictionary<string, object> { { "@MaHD", maHD }, { "@MaDU", maDU } };

                ConnectSQL.RunQuery(strSQL, parameters);
                MessageBox.Show("Xóa thành công");
                LoadDoUongDaGoi();
                LoadTable();
            }
        }

        private void btnThanhToan_Click(object? sender, EventArgs e)
        {
            if(dtgvHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có hóa đơn để thanh toán");
                return;
            }
            if (dtgvHoaDon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một món trong hóa đơn để xác định hóa đơn cần thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MaHDThanhToan = dtgvHoaDon.CurrentRow.Cells["MaHD"].Value?.ToString()?.Trim() ?? string.Empty;
            MaBanThanhToan = btnBanDaChon.Text;
            frmThanhToan frm = new frmThanhToan();
            frm.ShowDialog();
            
            // Sau khi form thanh toán đóng, kiểm tra xem người dùng có thực sự thanh toán không.
            // Bằng cách kiểm tra DialogResult trả về từ frmThanhToan.
            // Giả sử nút "Thanh toán" trong frmThanhToan sẽ set DialogResult = OK.
            if (frm.DialogResult == DialogResult.OK)
            {
                ConnectSQL.CapNhatTonKhoSauThanhToan(MaHDThanhToan);
            }

            RefreshAllData(); // Gọi hàm refresh chung để tải lại mọi thứ và kiểm tra tồn kho
        }

        private void menuBangGiaNL_Click(object sender, EventArgs e)
        {
            // Mở lại form quản lý nguyên liệu đã có
            frmNguyenLieu frm = new frmNguyenLieu();
            frm.ShowDialog();
        }

        private void menuBangGiaDU_Click(object sender, EventArgs e)
        {
            // Mở form mới vừa tạo
            frmBangGiaDoUongNguyenBan frm = new frmBangGiaDoUongNguyenBan();
            frm.ShowDialog();
        }

        private void menuLoiNhuan_Click(object sender, EventArgs e)
        {
            frmThongKeLoiNhuan frm = new frmThongKeLoiNhuan();
            frm.ShowDialog();
        }

        private void menuDonViTinh_Click(object sender, EventArgs e)
        {
            frmDonViTinh frm = new frmDonViTinh();
            frm.ShowDialog();
            // Không cần RefreshAllData() vì không ảnh hưởng trực tiếp đến màn hình chính
        }

        private void dtgvDoUong_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Bỏ qua nếu click vào header

            // Nếu click vào cột nút "Sửa"
            if (e.ColumnIndex == dtgvDoUong.Columns["SuaDoUong"].Index)
            {
                // Lấy MaDU từ dòng được click và mở form DoUong
                string maDU = dtgvDoUong.Rows[e.RowIndex].Cells["MaDU"].Value?.ToString() ?? string.Empty;
                frmDoUong frm = new frmDoUong(maDU);
                frm.ShowDialog();
                RefreshAllData(); // Tải lại dữ liệu sau khi form DoUong đóng
            }
            else // Nếu click vào các cột khác để thêm món
            {
                if (btnBanDaChon.Text == "Chưa chọn bàn")
                {
                    MessageBox.Show("Bạn hãy chọn bàn trước khi gọi món.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int soLuongTon = Convert.ToInt32(dtgvDoUong.Rows[e.RowIndex].Cells["SoLuongTon"].Value);
                if (soLuongTon <= 0)
                {
                    MessageBox.Show("Đồ uống này đã hết hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tenDU = dtgvDoUong.Rows[e.RowIndex].Cells["TenDU"].Value?.ToString() ?? string.Empty;
                using (var formChonSL = new frmChonSoLuong(tenDU))
                {
                    if (formChonSL.ShowDialog() == DialogResult.OK)
                    {
                        if (formChonSL.SoLuong > soLuongTon)
                        {
                            MessageBox.Show($"Số lượng tồn không đủ. Chỉ còn {soLuongTon}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        string maDU = dtgvDoUong.Rows[e.RowIndex].Cells["MaDU"].Value.ToString()!;
                        decimal donGia = Convert.ToDecimal(dtgvDoUong.Rows[e.RowIndex].Cells["DonGia"].Value);
                        decimal soLuong = formChonSL.SoLuong;
                        ThemMon(maDU, donGia, soLuong);
                    }
                }
            }
        }

        private void dtgvDoUong_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            menuDoUong_Click(sender, e); // Gọi lại sự kiện click menu để mở form và tự động refresh
        }

        private void dtgvHoaDon_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu không phải cột "Số lượng" hoặc form đang load
            if (e.RowIndex < 0 || dtgvHoaDon.Columns[e.ColumnIndex].Name != "SoLuong")
            {
                return;
            }

            DataGridViewRow row = dtgvHoaDon.Rows[e.RowIndex];

            // Lấy các giá trị cần thiết từ dòng
            string maHD = row.Cells["MaHD"].Value.ToString()!;
            string maDU = row.Cells["MaDU"].Value.ToString()!;
            decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value);

            // Lấy và kiểm tra số lượng mới
            if (!decimal.TryParse(row.Cells["SoLuong"].Value.ToString(), out decimal newSoLuong) || newSoLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là một số lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Tải lại dữ liệu để hoàn tác thay đổi không hợp lệ
                LoadDoUongDaGoi();
                return;
            }

            // Cập nhật CSDL
            string sqlUpdate = @"UPDATE ChiTietHoaDon 
                                 SET SoLuong = @SoLuong, ThanhTien = @SoLuong * @DonGia 
                                 WHERE MaDU = @MaDU AND MaHD = @MaHD";
            var paramUpdate = new Dictionary<string, object>
            {
                { "@SoLuong", newSoLuong },
                { "@DonGia", donGia },
                { "@MaDU", maDU },
                { "@MaHD", maHD }
            };
            ConnectSQL.RunQuery(sqlUpdate, paramUpdate);

            LoadDoUongDaGoi(); // Tải lại để cập nhật tổng tiền
        }
        #region Helper Methods for Adding Items

        private void dtgvDoUong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Bỏ qua header và các dòng không hợp lệ
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dtgvDoUong.Rows[e.RowIndex].DataBoundItem == null) return;

            // Chỉ áp dụng cho cột "SoLuongTon"
            if (dtgvDoUong.Columns[e.ColumnIndex].Name == "SoLuongTon")
            {
                DataRowView rowView = (DataRowView)dtgvDoUong.Rows[e.RowIndex].DataBoundItem;
                int soLuongTon = Convert.ToInt32(rowView["SoLuongTon"]);
                int nguongCanhBao = (rowView["NguongCanhBao"] != DBNull.Value) ? Convert.ToInt32(rowView["NguongCanhBao"]) : 0;

                // Nếu tồn kho thấp hơn hoặc bằng ngưỡng (và ngưỡng > 0), tô màu đỏ
                if (nguongCanhBao > 0 && soLuongTon <= nguongCanhBao)
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
            }
        }
        private string TaoMaHoaDonMoi(string maBan)
        {
            string maHD = DateTime.Now.ToString("HDssmmhhddMMyyyy");
            string sqlInsertHD = "INSERT INTO HoaDon(MaHD, NgayLap, MaNV, MaBan, TongTien, TrangThai) VALUES (@MaHD, @NgayLap, @MaNV, @MaBan, 0, 0)";
            var paramHD = new Dictionary<string, object>
            {
                { "@MaHD", maHD },
                { "@NgayLap", DateTime.Now },
                { "@MaNV", frmDangNhap.MaNV ?? string.Empty },
                { "@MaBan", maBan }
            };
            ConnectSQL.RunQuery(sqlInsertHD, paramHD);
            return maHD;
        }

        private void ThemChiTietHoaDon(string maHD, string maDU, decimal soLuong, decimal donGia)
        {
            string sqlInsertCTHD = "INSERT INTO ChiTietHoaDon(MaHD, MaDU, SoLuong, DonGia, ThanhTien) VALUES (@MaHD, @MaDU, @SoLuong, @DonGia, @ThanhTien)";
            var paramCTHD = new Dictionary<string, object>
            {
                { "@MaHD", maHD },
                { "@MaDU", maDU },
                { "@SoLuong", soLuong },
                { "@DonGia", donGia },
                { "@ThanhTien", soLuong * donGia }
            };
            ConnectSQL.RunQuery(sqlInsertCTHD, paramCTHD);
        }

        private void CapNhatTrangThaiBan(string maBan, int trangThai)
        {
            string sqlUpdateBan = "UPDATE Ban SET TrangThai = @TrangThai WHERE MaBan = @MaBan";
            ConnectSQL.RunQuery(sqlUpdateBan, new Dictionary<string, object> { { "@TrangThai", trangThai }, { "@MaBan", maBan } });
        }

        private bool KiemTraMonDaTonTai(string maHD, string maDU)
        {
            string sqlCheck = "SELECT MaDU FROM ChiTietHoaDon WHERE MaHD = @MaHD AND MaDU = @MaDU";
            var paramCheck = new Dictionary<string, object> { { "@MaHD", maHD }, { "@MaDU", maDU } };
            return ConnectSQL.ExcuteReader_bool(sqlCheck, paramCheck);
        }

        private void CapNhatSoLuongMon(string maHD, string maDU, decimal soLuong, decimal donGia)
        {
            string sqlUpdate = @"UPDATE ChiTietHoaDon 
                                 SET SoLuong = SoLuong + @SoLuong, ThanhTien = (SoLuong + @SoLuong) * @DonGia 
                                 WHERE MaDU = @MaDU AND MaHD = @MaHD";
            var paramUpdate = new Dictionary<string, object>
            {
                { "@SoLuong", soLuong }, { "@DonGia", donGia }, { "@MaDU", maDU }, { "@MaHD", maHD }
            };
            ConnectSQL.RunQuery(sqlUpdate, paramUpdate);
        }
        #endregion

        private void menuDoanhThuNgay_Click(object? sender, EventArgs e)
        {
            frmDoanhThuTheoNgay frm = new frmDoanhThuTheoNgay();
            frm.ShowDialog();
        }

        private void menuThongKeDoanhThuNV_Click(object? sender, EventArgs e)
        {
            frmDoanhThuTheoNhanVien frm = new frmDoanhThuTheoNhanVien();
            frm.ShowDialog();
        }

        private void menuLichSuHoaDon_Click(object? sender, EventArgs e)
        {
            frmLichSuHoaDon frm = new frmLichSuHoaDon();
            frm.ShowDialog();
        }

        private void btnDX_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void lstBan_SelectedIndexChanged(object? sender, EventArgs e)
        {

        }

        private void menuHangBanChay_Click(object? sender, EventArgs e)
        {
            using (var f = new frmHangBanChay())
            {
                f.ShowDialog();
            }
        }

        private void ShowStatus(string message)
        {
            lblStatus.Text = message;
            tmrStatus.Interval = 3000; // Thông báo sẽ hiển thị trong 3 giây
            tmrStatus.Start();
        }

        private void tmrStatus_Tick(object? sender, EventArgs e)
        {
            // Xóa thông báo và dừng timer
            lblStatus.Text = "";
            tmrStatus.Stop();
        }

        private void btnRefreshDoUong_Click(object? sender, EventArgs e)
        {
            RefreshAllData(); // Thay vì chỉ load menu, refresh tất cả và kiểm tra tồn kho
        }

        private void CheckLowStock()
        {
            string sql = @"SELECT TenDU, SoLuongTon 
                           FROM DoUong 
                           WHERE NguongCanhBao > 0 AND SoLuongTon <= NguongCanhBao";

            DataTable dt = ConnectSQL.Load(sql);

            if (dt.Rows.Count > 0)
            {
                // Đã thay thế bằng việc tô màu trực tiếp trên DataGridView,
                // nên không cần hiển thị form cảnh báo nữa.
                // StringBuilder warningMessage = new StringBuilder();
                // // Thêm tiêu đề phụ để thông báo tổng số lượng sản phẩm sắp hết hàng
                // warningMessage.AppendLine($"Có {dt.Rows.Count} sản phẩm sắp hết hàng:");
                // warningMessage.AppendLine(); // Thêm một dòng trống cho dễ nhìn

                // foreach (DataRow row in dt.Rows)
                // {
                //     string tenDU = row["TenDU"].ToString()!;
                //     int soLuongTon = Convert.ToInt32(row["SoLuongTon"]);
                //     warningMessage.AppendLine($"• {tenDU} (chỉ còn {soLuongTon})");
                // }

                // // Hiển thị form cảnh báo mới
                // frmCanhBao frm = new frmCanhBao(warningMessage.ToString());
                // frm.Show();
            }
            // Không cần xử lý else vì nếu không có gì thì không hiện form
        }

        private void tmrLowStockWarning_Tick(object? sender, EventArgs e)
        {
            lblLowStockWarning.Visible = false;
            tmrLowStockWarning.Stop();
        }

        private void menuXoaLichSuGiaoDich_Click(object sender, EventArgs e)
        {
            frmXoaLichSu frm = new frmXoaLichSu();
            DialogResult result = frm.ShowDialog();

            // Nếu người dùng đã thực hiện một hành động xóa trong form con
            if (result == DialogResult.OK)
            {
                RefreshAllData(); // Tải lại toàn bộ giao diện trên màn hình chính
            }
        }
    }
}
