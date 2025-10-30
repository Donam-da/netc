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
    public partial class frmThanhToan: Form
    {
        public frmThanhToan()
        {
            InitializeComponent();

        }
        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string strSQl = $@"SELECT * FROM KhachHang WHERE TenKH LIKE N'%{txtTenKH.Text}%'
                                AND SDT LIKE N'%{txtSDT.Text}%' AND DiaChi LIKE N'%{txtDiaChi.Text}%'";
            dtgvData.DataSource = ConnectSQL.Load(strSQl);
            frmNhanVien.SetupDataGridView(dtgvData);
            dtgvData.Columns[0].HeaderText = "Mã KH";
            dtgvData.Columns[1].HeaderText = "Tên KH";
            dtgvData.Columns[2].HeaderText = "SĐT";
            dtgvData.Columns[3].HeaderText = "Địa chỉ";
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
            string MaKH = DateTime.Now.ToString("mmsshhddMMyyyy");
            string strSQL = $@"INSERT INTO KhachHang(MaKH,TenKH,SDT,DiaChi)
                        VALUES ('{MaKH}',N'{txtTenKH.Text}','{txtSDT.Text}',N'{txtDiaChi.Text}')";
            ConnectSQL.RunQuery(strSQL);
            MessageBox.Show("Thêm thành công");
            LoadData();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dtgvData.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để thanh toán");
                return;
            }
            if (dtgvData.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn thanh toán hay không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 1. Lấy thông tin cần thiết cho hóa đơn
                string maKH = dtgvData.CurrentRow.Cells["MaKH"].Value.ToString()!.Trim();
                string tenKH = dtgvData.CurrentRow.Cells["TenKH"].Value.ToString()!.Trim();
                string maHD = frmManHinhChinh.MaHDThanhToan;

                // 2. Lấy dữ liệu chi tiết hóa đơn và thông tin chung để in
                string sqlDetail = "SELECT b.TenDU, a.DonGia, a.SoLuong, a.ThanhTien FROM ChiTietHoaDon a INNER JOIN DoUong b ON a.MaDU = b.MaDU WHERE a.MaHD = @MaHD";
                DataTable dtDetail = ConnectSQL.Load(sqlDetail, new Dictionary<string, object> { { "@MaHD", maHD } });

                string sqlMaster = "SELECT a.NgayLap, b.TenNV FROM HoaDon a INNER JOIN NhanVien b ON a.MaNV = b.MaNV WHERE a.MaHD = @MaHD";
                DataTable dtMaster = ConnectSQL.Load(sqlMaster, new Dictionary<string, object> { { "@MaHD", maHD } });

                var hoaDonInfo = new Dictionary<string, string>
                {
                    { "TenKH", tenKH },
                    { "NguoiLap", dtMaster.Rows[0]["TenNV"].ToString()! },
                    { "NgayLap", Convert.ToDateTime(dtMaster.Rows[0]["NgayLap"]).ToString("dd/MM/yyyy HH:mm") },
                    { "TongTien", frmManHinhChinh.TongTienThanhToan },
                    { "NgayThanhToan", DateTime.Now.ToString("dd/MM/yyyy HH:mm") }
                };

                // 3. Hiển thị form hóa đơn
                using (var frm = new frmHienThiHoaDon(dtDetail, hoaDonInfo))
                {
                    frm.ShowDialog();
                }

                // 4. Sau khi xem xong, mới cập nhật CSDL
                string sqlUpdateHD = "UPDATE HoaDon SET TrangThai = 1, MaKH = @MaKH, TongTien = @TongTien WHERE MaHD = @MaHD";
                var paramUpdateHD = new Dictionary<string, object>
                {
                    { "@MaKH", maKH },
                    { "@TongTien", decimal.Parse(frmManHinhChinh.TongTienThanhToan) },
                    { "@MaHD", maHD }
                };
                ConnectSQL.RunQuery(sqlUpdateHD, paramUpdateHD);

                string sqlUpdateBan = "UPDATE Ban SET TrangThai = 0 WHERE MaBan = @MaBan";
                ConnectSQL.RunQuery(sqlUpdateBan, new Dictionary<string, object> { { "@MaBan", frmManHinhChinh.MaBanThanhToan } });
            }
            this.Close();
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
