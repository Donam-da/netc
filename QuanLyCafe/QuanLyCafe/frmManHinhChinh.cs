﻿﻿﻿using System;
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
        private void menuNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.ShowDialog();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuThongTinCaNhan_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.ShowDialog();
        }

        private void menuLDU_Click(object sender, EventArgs e)
        {
            frmLoaiDoUong frm = new frmLoaiDoUong();
            frm.ShowDialog();
        }

        private void menuBan_Click(object sender, EventArgs e)
        {
            frmBan frm = new frmBan();
            frm.ShowDialog();
        }

        private void menuDoUong_Click(object sender, EventArgs e)
        {
            frmDoUong frm = new frmDoUong();
            frm.ShowDialog();
        }

        private void menuKH_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.ShowDialog();
        }
        private void LoadTable()
        {
            lstBan.Clear();
            lstBan.View = View.LargeIcon;
            lstBan.LargeImageList = imageList1;

            string strSQL = "SELECT MaBan, TrangThai FROM Ban";
            var parameters = new Dictionary<string, object>();

            if(rbYes.Checked)
            {
                strSQL += " WHERE TrangThai = @TrangThai";
                parameters.Add("@TrangThai", "1");
            }    
            else if (rbNo.Checked)
            {
                strSQL += " WHERE TrangThai = @TrangThai";
                parameters.Add("@TrangThai", "0");
            }    
            DataTable dt = ConnectSQL.Load(strSQL, parameters);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item1 = new ListViewItem(dt.Rows[i]["MaBan"].ToString());
                if(dt.Rows[i]["TrangThai"].ToString() == "0")
                {
                    item1.ImageIndex = 1;
                }  
                else
                {
                    item1.ImageIndex = 0;
                }    
                lstBan.Items.Add(item1);
            }    
        }
        private void LoadMenuDoUong()
        {
            string strSQL = @"SELECT MaDU, TenDU, MaLoai, DonGia FROM DoUong WHERE TenDU LIKE @TenDU";
            var parameters = new Dictionary<string, object>
            {
                { "@TenDU", $"%{txtTenDoUong.Text}%" }
            };

            DataTable dt = ConnectSQL.Load(strSQL, parameters);
            dtgvDoUong.DataSource = dt;
            frmNhanVien.SetupDataGridView(dtgvDoUong);
            dtgvDoUong.Columns[0].HeaderText = "Mã đồ uống";
            dtgvDoUong.Columns[1].HeaderText = "Tên đồ uống";
            dtgvDoUong.Columns[2].HeaderText = "Mã loại";
            dtgvDoUong.Columns[3].HeaderText = "Đơn giá";
        }
        private void frmManHinhChinh_Load(object sender, EventArgs e)
        {
            if (frmDangNhap.Quyen == "Nhân viên")
            {
                menuNhanVien.Enabled = false;
            }
            // Áp dụng renderer tùy chỉnh cho ToolStrip
            toolStrip1.Renderer = new MyMenuRenderer();

            LoadTable();
            LoadMenuDoUong();
        }

        private void rbYes_CheckedChanged(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadMenuDoUong();
        }

        private void lstBan_Click(object sender, EventArgs e)
        {
            btnBanDaChon.Text = lstBan.SelectedItems[0].SubItems[0].Text;
            LoadDoUongDaGoi();
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
            MessageBox.Show("Thêm thành công");
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(btnBanDaChon.Text == "Chưa chọn bàn")
            {
                MessageBox.Show("Bạn hãy chọn bàn trước khi gọi món");
                return;
            }
            //Hóa đơn chưa có món nào cả, thì phải thêm dữ liệu vào bảng HoaDon trước, xong thêm vào bảng
            //Chi tiết hóa đơn.
            if (dtgvDoUong.CurrentRow == null)
            {
                MessageBox.Show("Bạn chưa chọn đồ uống để thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maDU = dtgvDoUong.CurrentRow.Cells[0].Value.ToString()!;
            decimal donGia = Convert.ToDecimal(dtgvDoUong.CurrentRow.Cells[3].Value);
            decimal soLuong = nmSoLuong.Value;
            ThemMon(maDU, donGia, soLuong);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtgvHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để xóa");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string maHD = dtgvHoaDon.CurrentRow.Cells["MaHD"].Value.ToString()!;
                string maDU = dtgvHoaDon.CurrentRow.Cells["MaDU"].Value.ToString()!;
                string strSQL = "DELETE FROM ChiTietHoaDon WHERE MaHD = @MaHD AND MaDU = @MaDU";
                var parameters = new Dictionary<string, object> { { "@MaHD", maHD }, { "@MaDU", maDU } };

                ConnectSQL.RunQuery(strSQL, parameters);
                MessageBox.Show("Xóa thành công");
                LoadDoUongDaGoi();
                LoadTable();
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
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
            LoadTable();
            LoadDoUongDaGoi();
        }

        private void dtgvDoUong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Bỏ qua nếu double click vào header

            if (btnBanDaChon.Text == "Chưa chọn bàn")
            {
                MessageBox.Show("Bạn hãy chọn bàn trước khi gọi món.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenDU = dtgvDoUong.Rows[e.RowIndex].Cells["TenDU"].Value.ToString()!;
            using (var formChonSL = new frmChonSoLuong(tenDU))
            {
                if (formChonSL.ShowDialog() == DialogResult.OK)
                {
                    string maDU = dtgvDoUong.Rows[e.RowIndex].Cells["MaDU"].Value.ToString()!;
                    decimal donGia = Convert.ToDecimal(dtgvDoUong.Rows[e.RowIndex].Cells["DonGia"].Value);
                    decimal soLuong = formChonSL.SoLuong;
                    ThemMon(maDU, donGia, soLuong);
                }
            }
        }

        #region Helper Methods for Adding Items
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

        private void menuDoanhThuNgay_Click(object sender, EventArgs e)
        {
            frmDoanhThuTheoNgay frm = new frmDoanhThuTheoNgay();
            frm.ShowDialog();
        }

        private void menuThongKeDoanhThuNV_Click(object sender, EventArgs e)
        {
            frmDoanhThuTheoNhanVien frm = new frmDoanhThuTheoNhanVien();
            frm.ShowDialog();
        }

        private void menuLichSuHoaDon_Click(object sender, EventArgs e)
        {
            frmLichSuHoaDon frm = new frmLichSuHoaDon();
            frm.ShowDialog();
        }

        private void btnDX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstBan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuHangBanChay_Click(object sender, EventArgs e)
        {
            using (var f = new frmHangBanChay())
            {
                f.ShowDialog();
            }
        }

    }
}
