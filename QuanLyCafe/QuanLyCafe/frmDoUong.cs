﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class frmDoUong: Form
    {
        public string? SelectedMaDU { get; set; }
        // DataTable để lưu trữ công thức tạm thời trên giao diện
        private DataTable dtCongThuc = new DataTable();

        public frmDoUong()
        {
            InitializeComponent();
            // Khởi tạo các cột cho DataTable công thức chỉ một lần duy nhất ở đây
            dtCongThuc.Columns.Add("MaNL", typeof(string));
            dtCongThuc.Columns.Add("TenNL", typeof(string));
            dtCongThuc.Columns.Add("SoLuong", typeof(decimal));
            dtCongThuc.Columns.Add("DonViTinh", typeof(string));

        }

        // Constructor mới để nhận mã đồ uống từ form chính
        public frmDoUong(string maDU) : this()
        {
            this.SelectedMaDU = maDU;
        }

        private void txtDonGia_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void LoadData()
        {
            // Lấy thêm các cột mới: IsPhaChe, GiaGoc
            string strSQl = "SELECT MaDU, TenDU, MaLoai, DonGia, SoLuongTon, NguongCanhBao, HinhAnh, IsPhaChe, GiaGoc FROM DoUong WHERE TenDU LIKE @TenDU";

            string searchText = txtSearch?.Text ?? string.Empty; // Kiểm tra null cho txtSearch
            var parameters = new Dictionary<string, object>
            {
                { "@TenDU", $"%{searchText}%" }
            };

            dtgvData.DataSource = ConnectSQL.Load(strSQl, parameters);
            frmNhanVien.SetupDataGridView(dtgvData);
            dtgvData.Columns[0].HeaderText = "Mã đồ uống";
            dtgvData.Columns[1].HeaderText = "Tên đồ uống";
            dtgvData.Columns[2].HeaderText = "Mã loại";
            dtgvData.Columns[3].HeaderText = "Đơn giá";
            dtgvData.Columns[4].HeaderText = "Tồn kho";
            dtgvData.Columns[5].Visible = true; // Hiện cột ngưỡng cảnh báo
            dtgvData.Columns[5].HeaderText = "Ngưỡng C.Báo";
            dtgvData.Columns[6].Visible = false; // Ẩn cột HinhAnh
            dtgvData.Columns[7].Visible = false; // Ẩn cột IsPhaChe
            dtgvData.Columns[8].Visible = false; // Ẩn cột GiaGoc
            dtgvData.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dtgvData.Rows.Count == 0)
            {
                txtMaDU.Text = "";
                txtTenDU.Text = "";
                txtDonGia.Text = "";
                txtSoLuongTon.Text = "0";
                nmNguongCanhBao.Value = 0; // Đặt giá trị về 0
                nmNguongCanhBao.Text = "";  // Xóa văn bản hiển thị
                rbPhaChe.Checked = true; // Mặc định là đồ pha chế
                nmGiaGoc.Value = 0;
                dtCongThuc.Clear(); // Xóa bảng công thức tạm

            }
            else if (!string.IsNullOrEmpty(SelectedMaDU))
            {
                // Tìm và chọn dòng có mã đồ uống được truyền vào
                foreach (DataGridViewRow row in dtgvData.Rows)
                {
                    if (row.Cells["MaDU"].Value?.ToString() == SelectedMaDU)
                    {
                        dtgvData.CurrentCell = row.Cells[0]; // Chọn dòng này
                        DisplayRowData(row); // Hiển thị dữ liệu của dòng được chọn
                        break; // Dừng vòng lặp khi đã tìm thấy
                    }
                }
            }
            else
            {
                // Nếu không có mã nào được truyền, chỉ cần chọn dòng đầu tiên.
                // Sự kiện CellClick sẽ tự động được kích hoạt để hiển thị dữ liệu.
                if (dtgvData.Rows.Count > 0)
                {
                    dtgvData.CurrentCell = dtgvData.Rows[0].Cells[0];
                    DisplayRowData(dtgvData.Rows[0]); // Gọi trực tiếp để đảm bảo hiển thị ngay lập tức
                }
            }
        }
        private void DisplayRowData(DataGridViewRow row)
        {
            if (row == null) return;

            txtMaDU.Text = row.Cells["MaDU"].Value?.ToString() ?? string.Empty;
            txtTenDU.Text = row.Cells["TenDU"].Value?.ToString() ?? string.Empty;
            cboMaLoai.SelectedValue = row.Cells["MaLoai"].Value?.ToString() ?? string.Empty;
            txtDonGia.Text = row.Cells["DonGia"].Value?.ToString() ?? string.Empty;
            txtSoLuongTon.Text = row.Cells["SoLuongTon"].Value?.ToString() ?? string.Empty;

            // Lấy ngưỡng cảnh báo, nếu null thì mặc định là 0
            if (row.Cells["NguongCanhBao"].Value != DBNull.Value)
            {
                // Sử dụng Convert.ToDecimal để xử lý chính xác các kiểu số khác nhau
                nmNguongCanhBao.Value = Convert.ToDecimal(row.Cells["NguongCanhBao"].Value);
            }
            else
            {
                nmNguongCanhBao.Value = 0;
                nmNguongCanhBao.Text = ""; // Xóa văn bản nếu giá trị là 0
            }

            // Hiển thị loại đồ uống và các control tương ứng
            bool isPhaChe = false; // Mặc định là false (đồ uống nguyên bản)
            if (row.Cells["IsPhaChe"].Value != DBNull.Value && row.Cells["IsPhaChe"].Value != null)
            {
                isPhaChe = Convert.ToBoolean(row.Cells["IsPhaChe"].Value);
            }

            if (isPhaChe)
            {
                rbPhaChe.Checked = true;
                LoadCongThuc(txtMaDU.Text); // Tải công thức cho đồ uống này
            }
            else
            {
                rbNguyenBan.Checked = true;
                if (dtCongThuc != null) dtCongThuc.Clear(); // Xóa công thức nếu là đồ uống nguyên bản
            }

            // Hiển thị giá gốc
            if (row.Cells["GiaGoc"].Value != DBNull.Value && row.Cells["GiaGoc"].Value != null)
            {
                nmGiaGoc.Value = Convert.ToDecimal(row.Cells["GiaGoc"].Value);
            }
            else
            {
                nmGiaGoc.Value = 0;
            }

            // Tính và hiển thị lợi nhuận
            TinhVaHienThiLoiNhuan();

        }
        private void frmDoUong_Load(object? sender, EventArgs e)
        {
            LoadData();
            LoadComboboxLoaiDoUong();
            LoadComboboxNguyenLieu();
            SetupDtgvCongThuc();
            dtgvData.CellFormatting += dtgvData_CellFormatting;
            rbPhaChe.Checked = true; // Mặc định khi mở form
        }
        private void LoadComboboxLoaiDoUong()
        {
            string strSQL = "SELECT * FROM LoaiDoUong";
            DataTable dt = new DataTable();
            dt = ConnectSQL.Load(strSQL);
            cboMaLoai.DataSource = dt;
            cboMaLoai.DisplayMember = "TenLoai";
            cboMaLoai.ValueMember = "MaLoai";
        }
        private void LoadComboboxNguyenLieu()
        {
            string strSQL = "SELECT MaNL, TenNL FROM NguyenLieu ORDER BY TenNL";
            DataTable dt = ConnectSQL.Load(strSQL);
            cboNguyenLieu.DataSource = dt;
            cboNguyenLieu.DisplayMember = "TenNL";
            cboNguyenLieu.ValueMember = "MaNL";
        }

        private void SetupDtgvCongThuc()
        {
            dtgvCongThuc.DataSource = dtCongThuc;

            // Cấu hình DataGridView
            frmNhanVien.SetupDataGridView(dtgvCongThuc);
            dtgvCongThuc.Columns["MaNL"].Visible = false;
            dtgvCongThuc.Columns["TenNL"].HeaderText = "Tên Nguyên Liệu";
            dtgvCongThuc.Columns["SoLuong"].HeaderText = "Số Lượng";
            dtgvCongThuc.Columns["DonViTinh"].HeaderText = "ĐVT";

            dtgvCongThuc.Columns["TenNL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgvCongThuc.Columns["SoLuong"].Width = 80;
            dtgvCongThuc.Columns["DonViTinh"].Width = 60;
        }

        private void LoadCongThuc(string maDU)
        {
            dtCongThuc.Clear(); // Xóa công thức cũ
            if (string.IsNullOrEmpty(maDU)) return;

            string sql = @"SELECT ct.MaNL, nl.TenNL, ct.SoLuong, nl.DonViTinh 
                           FROM CongThuc ct
                           JOIN NguyenLieu nl ON ct.MaNL = nl.MaNL
                           WHERE ct.MaDU = @MaDU";
            var parameters = new Dictionary<string, object> { { "@MaDU", maDU } };
            DataTable dt = ConnectSQL.Load(sql, parameters);

            // Đổ dữ liệu từ CSDL vào DataTable tạm
            foreach (DataRow row in dt.Rows)
            {
                dtCongThuc.Rows.Add(row["MaNL"], row["TenNL"], row["SoLuong"], row["DonViTinh"]);
            }
        }

        private void TinhVaHienThiLoiNhuan()
        {
            if (!decimal.TryParse(txtDonGia.Text, out decimal giaBan))
            {
                lblLoiNhuan.Text = "Lợi nhuận: (chưa có giá bán)";
                return;
            }

            decimal giaVon = 0;

            // Nếu là đồ uống nguyên bản
            if (rbNguyenBan.Checked)
            {
                giaVon = nmGiaGoc.Value;
            }
            // Nếu là đồ uống pha chế
            else if (rbPhaChe.Checked && !string.IsNullOrEmpty(txtMaDU.Text))
            {
                // Tính giá vốn từ công thức trong CSDL
                string sql = @"SELECT SUM(ct.SoLuong * nl.GiaTien) 
                               FROM CongThuc ct
                               JOIN NguyenLieu nl ON ct.MaNL = nl.MaNL
                               WHERE ct.MaDU = @MaDU";
                var parameters = new Dictionary<string, object> { { "@MaDU", txtMaDU.Text } };
                object? result = ConnectSQL.ExecuteScalar(sql, parameters);

                if (result != DBNull.Value && result != null)
                {
                    giaVon = Convert.ToDecimal(result);
                }
            }

            if (giaVon > 0)
            {
                decimal loiNhuan = giaBan - giaVon;
                lblLoiNhuan.Text = $"Lợi nhuận: {loiNhuan:N0} VNĐ";
                lblLoiNhuan.ForeColor = loiNhuan >= 0 ? Color.Blue : Color.Red; // Đổi màu nếu lỗ
            }
            else
            {
                lblLoiNhuan.Text = "Lợi nhuận: (chưa có giá vốn)";
            }
        }

        private void LoaiDoUong_CheckedChanged(object sender, EventArgs e)
        {
            // Khi chọn "Pha chế" -> Hiện group công thức, ẩn giá gốc
            grbCongThuc.Visible = rbPhaChe.Checked;

            // CẬP NHẬT: Giá gốc luôn ở chế độ chỉ đọc.
            // Nó chỉ được thay đổi từ form "Bảng giá đồ uống nhập".
            nmGiaGoc.ReadOnly = true; // Chuyển sang ReadOnly để người dùng vẫn thấy rõ giá trị
            nmGiaGoc.Increment = 0; // Không cho phép tăng giảm bằng nút
            lblGiaGoc.Enabled = true; // Label thì vẫn hiện

            if (rbPhaChe.Checked) nmGiaGoc.Value = 0; // Reset giá gốc nếu là đồ pha chế
            TinhVaHienThiLoiNhuan(); // Tính lại lợi nhuận khi đổi loại
        }

        private void menuThem_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDU.Text))
            {
                MessageBox.Show("Chưa nhập mã đồ uống");
                txtMaDU.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTenDU.Text))
            {
                MessageBox.Show("Chưa nhập tên đồ uống");
                txtTenDU.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDonGia.Text))
            {
                MessageBox.Show("Chưa nhập đơn giá");
                txtDonGia.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cboMaLoai.Text))
            {
                MessageBox.Show("Chưa nhập mã loại đồ uống");
                cboMaLoai.Focus();
                return;
            }

            string sqlCheck = "SELECT MaDU FROM DoUong WHERE MaDU = @MaDU";
            var paramCheck = new Dictionary<string, object> { { "@MaDU", txtMaDU.Text } };
            if (ConnectSQL.ExcuteReader_bool(sqlCheck, paramCheck))
            {
                MessageBox.Show("Mã đồ uống này đã tồn tại, vui lòng tạo mã khác");
                txtMaDU.Focus();
                return;
            }

            string sqlInsert = "INSERT INTO DoUong(MaDU, TenDU, MaLoai, DonGia, SoLuongTon, NguongCanhBao, IsPhaChe, GiaGoc) VALUES (@MaDU, @TenDU, @MaLoai, @DonGia, @SoLuongTon, @NguongCanhBao, @IsPhaChe, @GiaGoc)";
            var paramInsert = new Dictionary<string, object>
            {
                { "@MaDU", txtMaDU.Text },
                { "@TenDU", txtTenDU.Text },
                { "@MaLoai", cboMaLoai.SelectedValue! },
                { "@DonGia", decimal.Parse(txtDonGia.Text) },
                { "@SoLuongTon", decimal.Parse(txtSoLuongTon.Text) },
                { "@NguongCanhBao", nmNguongCanhBao.Value },
                { "@IsPhaChe", rbPhaChe.Checked },
                { "@GiaGoc", rbNguyenBan.Checked ? (object)nmGiaGoc.Value : DBNull.Value }
            };

            if (ConnectSQL.RunQuery(sqlInsert, paramInsert) > 0)
            {
                // Nếu là đồ uống pha chế, lưu công thức
                if (rbPhaChe.Checked)
                {
                    foreach (DataRow row in dtCongThuc.Rows)
                    {
                        string sqlCongThuc = "INSERT INTO CongThuc(MaDU, MaNL, SoLuong) VALUES (@MaDU, @MaNL, @SoLuong)";
                        var paramCongThuc = new Dictionary<string, object>
                        {
                            { "@MaDU", txtMaDU.Text },
                            { "@MaNL", row["MaNL"] },
                            { "@SoLuong", row["SoLuong"] }
                        };
                        ConnectSQL.RunQuery(sqlCongThuc, paramCongThuc);
                    }
                }
                MessageBox.Show("Thêm thành công");
                LoadData();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuSua_Click(object? sender, EventArgs e)
        {
            if (dtgvData.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đồ uống để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Thêm kiểm tra null cho CurrentRow để khắc phục lỗi CS8602
            if (dtgvData.CurrentRow == null)
            {
                MessageBox.Show("Không có dòng nào được chọn để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtMaDU.Text))
            {
                MessageBox.Show("Chưa nhập mã đồ uống");
                txtMaDU.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTenDU.Text))
            {
                MessageBox.Show("Chưa nhập tên đồ uống");
                txtTenDU.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDonGia.Text))
            {
                MessageBox.Show("Chưa nhập đơn giá");
                txtDonGia.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cboMaLoai.Text))
            {
                MessageBox.Show("Chưa nhập mã loại đồ uống");
                cboMaLoai.Focus();
                return;
            }

            string MaDUSua = dtgvData.CurrentRow.Cells[0].Value.ToString()!.Trim();
            if (txtMaDU.Text.Trim() != MaDUSua)
            {
                string sqlCheck = "SELECT MaDU FROM DoUong WHERE MaDU = @MaDU";
                var paramCheck = new Dictionary<string, object> { { "@MaDU", txtMaDU.Text.Trim() } };
                if (ConnectSQL.ExcuteReader_bool(sqlCheck, paramCheck))
                {
                    MessageBox.Show("Mã đồ uống này đã tồn tại, vui lòng tạo mã khác");
                    txtMaDU.Focus();
                    return;
                }
            }

            string strSQL = "UPDATE DoUong SET MaDU = @MaDU, TenDU = @TenDU, MaLoai = @MaLoai, DonGia = @DonGia, SoLuongTon = @SoLuongTon, NguongCanhBao = @NguongCanhBao, IsPhaChe = @IsPhaChe, GiaGoc = @GiaGoc WHERE MaDU = @MaDUSua";
            var parameters = new Dictionary<string, object> {
                { "@MaDU", txtMaDU.Text }, { "@TenDU", txtTenDU.Text }, { "@MaLoai", cboMaLoai.SelectedValue! },
                { "@DonGia", decimal.Parse(txtDonGia.Text) }, 
                // Sửa lỗi: Lấy giá trị từ ô txtSoLuongTon.Text thay vì txtDonGia.Text
                { "@SoLuongTon", decimal.Parse(txtSoLuongTon.Text) },
                { "@NguongCanhBao", nmNguongCanhBao.Value }, 
                { "@IsPhaChe", rbPhaChe.Checked },
                { "@GiaGoc", rbNguyenBan.Checked ? (object)nmGiaGoc.Value : DBNull.Value },
                { "@MaDUSua", MaDUSua }
            };

            if (ConnectSQL.RunQuery(strSQL, parameters) > 0)
            {
                // --- Cập nhật công thức ---
                // 1. Xóa công thức cũ của đồ uống này
                string sqlDeleteCongThuc = "DELETE FROM CongThuc WHERE MaDU = @MaDU";
                ConnectSQL.RunQuery(sqlDeleteCongThuc, new Dictionary<string, object> { { "@MaDU", txtMaDU.Text } });

                // 2. Nếu là đồ uống pha chế, thêm lại công thức mới từ dtgvCongThuc
                if (rbPhaChe.Checked)
                {
                    foreach (DataRow row in dtCongThuc.Rows)
                    {
                        string sqlInsertCongThuc = "INSERT INTO CongThuc(MaDU, MaNL, SoLuong) VALUES (@MaDU, @MaNL, @SoLuong)";
                        var paramCongThuc = new Dictionary<string, object>
                        {
                            { "@MaDU", txtMaDU.Text },
                            { "@MaNL", row["MaNL"] },
                            { "@SoLuong", row["SoLuong"] }
                        };
                        ConnectSQL.RunQuery(sqlInsertCongThuc, paramCongThuc);
                    }
                }

                MessageBox.Show("Sửa thành công");
                LoadData();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dtgvData_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvData.Rows[e.RowIndex];
                DisplayRowData(row);
            }
        }

        private void dtgvData_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Lấy giá trị tồn kho và ngưỡng cảnh báo một cách an toàn
            object soLuongTonObj = dtgvData.Rows[e.RowIndex].Cells["SoLuongTon"].Value;
            object nguongCanhBaoObj = dtgvData.Rows[e.RowIndex].Cells["NguongCanhBao"].Value;

            int soLuongTon = (soLuongTonObj != DBNull.Value) ? Convert.ToInt32(soLuongTonObj) : 0;
            int nguongCanhBao = (nguongCanhBaoObj != DBNull.Value) ? Convert.ToInt32(nguongCanhBaoObj) : 0;

            // Nếu tồn kho thấp hơn hoặc bằng ngưỡng (và ngưỡng > 0), tô màu đỏ nhạt
            if (nguongCanhBao > 0 && soLuongTon <= nguongCanhBao)
            {
                e.CellStyle.BackColor = Color.LightCoral;
                e.CellStyle.SelectionBackColor = Color.DarkRed;
            }
        }

        private void menuXoa_Click(object? sender, EventArgs e)
        {
            if (dtgvData.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đồ uống để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string maDU = dtgvData.CurrentRow.Cells[0].Value?.ToString()?.Trim() ?? string.Empty;

                // Trước khi xóa đồ uống, phải xóa các bản ghi liên quan trong CongThuc và ChiTietHoaDon
                string sqlDeleteCongThuc = "DELETE FROM CongThuc WHERE MaDU = @MaDU";
                ConnectSQL.RunQuery(sqlDeleteCongThuc, new Dictionary<string, object> { { "@MaDU", maDU } });

                // Lưu ý: Việc xóa ChiTietHoaDon có thể ảnh hưởng đến lịch sử, cân nhắc không cho xóa nếu đã phát sinh giao dịch.
                // string sqlDeleteCTHD = "DELETE FROM ChiTietHoaDon WHERE MaDU = @MaDU";
                // ConnectSQL.RunQuery(sqlDeleteCTHD, new Dictionary<string, object> { { "@MaDU", maDU } });

                string sqlDeleteDoUong = "DELETE FROM DoUong WHERE MaDU = @MaDU";
                if (ConnectSQL.RunQuery(sqlDeleteDoUong, new Dictionary<string, object> { { "@MaDU", maDU } }) > 0)
                {
                    MessageBox.Show("Xóa thành công");
                    LoadData();
                }
            }
        }

        private void menuXoaTrang_Click(object? sender, EventArgs e)
        {
            if (txtMaDU != null) txtMaDU.Text = "";
            if (txtTenDU != null) txtTenDU.Text = "";
            if (txtDonGia != null) txtDonGia.Text = "";
            if (txtSoLuongTon != null) txtSoLuongTon.Text = "0";
            nmNguongCanhBao.Value = 0;
            nmNguongCanhBao.Text = "";
            rbPhaChe.Checked = true;
            nmGiaGoc.Value = 0;
            dtCongThuc.Clear();
        }

        private void menuThoat_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void menuTimKiem_Click(object? sender, EventArgs e)
        {
            LoadData();
        }

        private void nmNguongCanhBao_Enter(object? sender, EventArgs e)
        {
            // Khi người dùng focus vào ô, chọn toàn bộ nội dung
            // để có thể dễ dàng nhập giá trị mới.
            if (sender is NumericUpDown numericUpDown)
            {
                // Nếu ô đang trống, không cần chọn gì cả
                if (!string.IsNullOrEmpty(numericUpDown.Text))
                {
                    numericUpDown.Select(0, numericUpDown.Text.Length);
                }
            }
        }

        private void btnThemNL_Click(object sender, EventArgs e)
        {
            if (cboNguyenLieu.SelectedValue == null || cboNguyenLieu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn một nguyên liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (nmSoLuongNL.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNL = cboNguyenLieu.SelectedValue.ToString()!;
            string tenNL = cboNguyenLieu.Text; // Lấy TenNL trực tiếp từ ComboBox
            decimal soLuong = nmSoLuongNL.Value;

            // --- CẢI TIẾN: KIỂM TRA NGUYÊN LIỆU TRÙNG LẶP ---
            // Tìm xem nguyên liệu này đã có trong dtCongThuc chưa
            DataRow? existingRow = dtCongThuc.AsEnumerable()
                                             .FirstOrDefault(r => r.Field<string>("MaNL") == maNL);

            if (existingRow != null)
            {
                // Nếu đã tồn tại, cộng dồn số lượng
                existingRow["SoLuong"] = existingRow.Field<decimal>("SoLuong") + soLuong;
            }
            else
            {
                // Nếu chưa tồn tại, thêm dòng mới
                // Lấy đơn vị tính từ CSDL để hiển thị
                string sqlDVT = "SELECT DonViTinh FROM NguyenLieu WHERE MaNL = @MaNL";
                string dvt = ConnectSQL.ExecuteScalar(sqlDVT, new Dictionary<string, object> { { "@MaNL", maNL } })?.ToString() ?? "";

                // Thêm vào DataTable tạm
                dtCongThuc.Rows.Add(maNL, tenNL, soLuong, dvt);
            }
            // --- KẾT THÚC CẢI TIẾN ---

            // Reset input
            nmSoLuongNL.Value = 0;
            cboNguyenLieu.Focus();
        }

        // Thêm các sự kiện này để tự động tính lại lợi nhuận khi người dùng thay đổi giá
        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            TinhVaHienThiLoiNhuan();
        }

        private void nmGiaGoc_ValueChanged(object sender, EventArgs e)
        {
            if (rbNguyenBan.Checked) // Chỉ tính lại khi là đồ uống nguyên bản
            {
                TinhVaHienThiLoiNhuan();
            }
        }

        private void dtgvCongThuc_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Cần một cơ chế phức tạp hơn để tính lại giá vốn từ dtgvCongThuc thay vì query lại CSDL
            // Tạm thời, chúng ta sẽ tính lại sau khi lưu.
        }
    }
}
