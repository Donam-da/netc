﻿﻿﻿﻿﻿﻿﻿﻿﻿using System;
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
    public partial class frmThanhToan: Form
    {
        private decimal _originalTotal = 0;
        private decimal _discountAmount = 0;
        private decimal _finalTotal = 0;
        private decimal _discountPercent = 0;

        public frmThanhToan()
        {
            InitializeComponent();

        }
        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            LoadData();
            // Lấy tổng tiền gốc từ màn hình chính
            _originalTotal = decimal.TryParse(frmManHinhChinh.TongTienThanhToan, out var total) ? total : 0;
            _finalTotal = _originalTotal;

            // Hiển thị thông tin ban đầu
            UpdateSummary();

            // Thêm sự kiện CellClick để xử lý khi chọn khách hàng
            dtgvData.CellClick += dtgvData_CellClick;

            // Bỏ chọn dòng mặc định để tránh lỗi logic
            dtgvData.ClearSelection();
        }
        private void LoadData()
        {
            // Thêm điều kiện để loại trừ khách vãng lai (MaKH = TenKH)
            string strSQl = "SELECT MaKH, TenKH, SDT, DiaChi, GiamGia FROM KhachHang WHERE TenKH LIKE @TenKH AND SDT LIKE @SDT AND DiaChi LIKE @DiaChi AND MaKH <> 'KHVL'";
            var parameters = new Dictionary<string, object>
            {
                { "@TenKH", $"%{txtTenKH.Text}%" }, { "@SDT", $"%{txtSDT.Text}%" }, { "@DiaChi", $"%{txtDiaChi.Text}%" }
            };
            dtgvData.DataSource = ConnectSQL.Load(strSQl, parameters); // Tải dữ liệu đã lọc
            frmNhanVien.SetupDataGridView(dtgvData);
            dtgvData.Columns[0].HeaderText = "Mã KH";
            dtgvData.Columns[1].HeaderText = "Tên KH";
            dtgvData.Columns[2].HeaderText = "SĐT";
            dtgvData.Columns[3].HeaderText = "Địa chỉ";
            dtgvData.Columns["GiamGia"].Visible = false; // Ẩn cột giảm giá
        }

        private void dtgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvData.Rows[e.RowIndex];
                _discountPercent = Convert.ToDecimal(row.Cells["GiamGia"].Value ?? 0);

                // Tính toán lại giảm giá
                _discountAmount = _originalTotal * (_discountPercent / 100);
                _finalTotal = _originalTotal - _discountAmount;

                UpdateSummary();
            }
        }

        /// <summary>
        /// Cập nhật các label hiển thị tổng tiền, giảm giá và thành tiền.
        /// </summary>
        private void UpdateSummary()
        {
            lblTongTienHang.Text = _originalTotal.ToString("N0") + " VNĐ";
            lblGiamGia.Text = $"- {_discountAmount:N0} VNĐ ({_discountPercent}%)";
            lblThanhTien.Text = _finalTotal.ToString("N0") + " VNĐ";

            // Thay đổi màu sắc để làm nổi bật
            lblGiamGia.ForeColor = _discountAmount > 0 ? Color.Green : Color.FromArgb(62, 39, 35);
            lblThanhTien.ForeColor = _discountAmount > 0 ? Color.Red : Color.FromArgb(62, 39, 35);
        }

        private void menuTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenKH.Text))
            {
                MessageBox.Show("Chưa nhập tên kh");
                txtTenKH.Focus();
                return;
            }
            // Tạo mã khách hàng duy nhất
            string maKH = "KH" + DateTime.Now.ToString("hhmmddMM");

            string strSQL = "INSERT INTO KhachHang(MaKH,TenKH,SDT,DiaChi) VALUES (@MaKH, @TenKH, @SDT, @DiaChi)";
            var parameters = new Dictionary<string, object>
            {
                { "@MaKH", maKH }, { "@TenKH", txtTenKH.Text }, { "@SDT", txtSDT.Text }, { "@DiaChi", txtDiaChi.Text }
            };

            if (ConnectSQL.RunQuery(strSQL, parameters) > 0)
            {
                MessageBox.Show("Thêm khách hàng mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Tải lại danh sách

                // Tự động tìm và chọn khách hàng vừa thêm
                foreach (DataGridViewRow row in dtgvData.Rows)
                {
                    if (row.Cells["MaKH"].Value.ToString() == maKH)
                    {
                        row.Selected = true;
                        dtgvData.CurrentCell = row.Cells[0]; // Focus vào dòng đó
                        // Kích hoạt sự kiện CellClick để cập nhật giảm giá
                        dtgvData_CellClick(dtgvData, new DataGridViewCellEventArgs(0, row.Index));
                        break;
                    }
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string maKH;
            string tenKH;

            // Kiểm tra xem có khách hàng nào được chọn không
            if (dtgvData.CurrentRow == null || dtgvData.SelectedRows.Count == 0)
            {
                // Nếu không, tự động tạo khách hàng vãng lai
                // Sử dụng mã khách hàng vãng lai cố định 'KHVL' để lưu vào CSDL
                maKH = "KHVL"; 
                // Tạo tên hiển thị trên hóa đơn theo định dạng yêu cầu
                tenKH = "KH" + DateTime.Now.ToString("hhmmssddMM");
                
                // Đảm bảo khách vãng lai không có giảm giá
                _discountPercent = 0;
                _discountAmount = 0;
                _finalTotal = _originalTotal;
                UpdateSummary();
            }
            else
            {
                // Nếu có, lấy thông tin khách hàng đã chọn
                maKH = dtgvData.CurrentRow.Cells["MaKH"].Value.ToString()!.Trim();
                tenKH = dtgvData.CurrentRow.Cells["TenKH"].Value.ToString()!.Trim();
            }

            string maHD = frmManHinhChinh.MaHDThanhToan;
            string maBan = frmManHinhChinh.MaBanThanhToan;

            // 2. Lấy dữ liệu chi tiết hóa đơn và thông tin chung để hiển thị
            string sqlDetail = "SELECT b.TenDU, a.DonGia, a.SoLuong, a.ThanhTien FROM ChiTietHoaDon a INNER JOIN DoUong b ON a.MaDU = b.MaDU WHERE a.MaHD = @MaHD";
            DataTable dtDetail = ConnectSQL.Load(sqlDetail, new Dictionary<string, object> { { "@MaHD", maHD } });

            string sqlMaster = "SELECT a.NgayLap, b.TenNV FROM HoaDon a INNER JOIN NhanVien b ON a.MaNV = b.MaNV WHERE a.MaHD = @MaHD";
            DataTable dtMaster = ConnectSQL.Load(sqlMaster, new Dictionary<string, object> { { "@MaHD", maHD } });

            // Tạo dictionary chứa thông tin hóa đơn để truyền đi
            var hoaDonInfo = new Dictionary<string, string>
            {
                // Thông tin để hiển thị
                { "TenKH", tenKH },
                { "NguoiLap", dtMaster.Rows[0]["TenNV"].ToString()! },
                { "NgayLap", Convert.ToDateTime(dtMaster.Rows[0]["NgayLap"]).ToString("dd/MM/yyyy HH:mm") },
                { "NgayThanhToan", DateTime.Now.ToString("dd/MM/yyyy HH:mm") },
                { "TongTienHang", _originalTotal.ToString("N0") },
                { "GiamGia", _discountAmount.ToString("N0") },
                { "TongCong", _finalTotal.ToString("N0") },
                { "PhanTramGiamGia", _discountPercent.ToString("G29") },

                // Thông tin để cập nhật CSDL
                { "MaHD", maHD },
                { "MaBan", maBan },
                { "MaKH", maKH },
                { "FinalTotal", _finalTotal.ToString() },
                { "DiscountAmount", _discountAmount.ToString() }
            };

            // 3. Hiển thị form xem trước hóa đơn
            using (var frm = new frmHienThiHoaDon(dtDetail, hoaDonInfo))
            {
                // Nếu người dùng nhấn "Thanh toán" trên form xem trước
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK; // Báo cho form chính biết là đã thanh toán thành công
                    this.Close();
                }
            }
        }

        #region Hover Effects
        private void btnThemMoi_MouseEnter(object sender, EventArgs e)
        {
            btnThemMoi.BackColor = Color.FromArgb(76, 175, 80); // #4CAF50
        }

        private void btnThemMoi_MouseLeave(object sender, EventArgs e)
        {
            btnThemMoi.BackColor = Color.FromArgb(62, 142, 65); // #3E8E41
        }

        private void menuTimKiem_MouseEnter(object sender, EventArgs e)
        {
            menuTimKiem.BackColor = Color.FromArgb(109, 76, 65); // #6D4C41
        }

        private void menuTimKiem_MouseLeave(object sender, EventArgs e)
        {
            menuTimKiem.BackColor = Color.FromArgb(90, 59, 46); // #5A3B2E
        }

        private void btnThanhToan_MouseEnter(object sender, EventArgs e)
        {
            btnThanhToan.BackColor = Color.FromArgb(56, 142, 60); // #388E3C
        }

        private void btnThanhToan_MouseLeave(object sender, EventArgs e)
        {
            btnThanhToan.BackColor = Color.FromArgb(46, 125, 50); // #2E7D32
        }
        #endregion
    }
}
