﻿﻿﻿﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class frmBan: Form
    {
        public string? SelectedMaBan { get; set; }

        public frmBan()
        {
            InitializeComponent();
        }

        // Constructor mới để nhận mã bàn từ form chính
        public frmBan(string maBan) : this()
        {
            this.SelectedMaBan = maBan;
        }

        private void txtSucChua_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
        private void LoadData()
        {
            string strSql = "SELECT MaBan, SucChua, CASE WHEN TrangThai = 0 THEN N'Bàn trống' ELSE N'Bàn có người' END AS TrangThai FROM Ban WHERE MaBan LIKE @SearchText";
            string searchText = txtSearch?.Text ?? string.Empty; // Kiểm tra null cho txtSearch
            var parameters = new Dictionary<string, object>
            {
                { "@SearchText", $"%{searchText}%" }
            };
            dtgvData.DataSource = ConnectSQL.Load(strSql, parameters);
            frmNhanVien.SetupDataGridView(dtgvData);

            // Đảm bảo các cột tồn tại trước khi thiết lập HeaderText
            if (dtgvData.Columns.Count > 0)
            {
                dtgvData.Columns[0].HeaderText = "Mã bàn";
            }
            if (dtgvData.Columns.Count > 1)
            {
                dtgvData.Columns[1].HeaderText = "Sức chứa";
            }
            if (dtgvData.Columns.Count > 2)
            {
                dtgvData.Columns[2].HeaderText = "Trạng thái";
            }
            if (dtgvData.Rows.Count == 0)
            {
                txtMaBan.Text = "";
                txtSucChua.Text = "";
            }
            else if (!string.IsNullOrEmpty(SelectedMaBan))
            {
                // Tìm và chọn dòng có mã bàn được truyền vào
                foreach (DataGridViewRow row in dtgvData.Rows)
                {
                    string? maBanValue = row.Cells["MaBan"].Value?.ToString();
                    // Kiểm tra an toàn trước khi gán CurrentCell
                    if (maBanValue == SelectedMaBan && row.Cells.Count > 0 && row.Cells[0] != null)
                    {
                        dtgvData.CurrentCell = row.Cells[0]; // Chọn dòng này
                        // Cập nhật thông tin vào các ô text
                        txtMaBan.Text = maBanValue ?? string.Empty;
                        txtSucChua.Text = row.Cells["SucChua"].Value?.ToString() ?? string.Empty;
                        break; // Dừng vòng lặp khi đã tìm thấy
                    }
                }
            }
            else // Nếu không có mã bàn nào được truyền, hiển thị dòng đầu tiên
            {
                if (dtgvData.Rows.Count > 0)
                {
                    DataGridViewRow firstRow = dtgvData.Rows[0];
                    // Kiểm tra an toàn trước khi gán CurrentCell
                    // firstRow sẽ không null nếu dtgvData.Rows.Count > 0
                    if (firstRow.Cells.Count > 0 && firstRow.Cells[0] != null)
                    {
                        txtMaBan.Text = firstRow.Cells[0].Value?.ToString() ?? string.Empty;
                        txtSucChua.Text = firstRow.Cells[1].Value?.ToString() ?? string.Empty;
                    }
                }
            }
        }
        private void frmBan_Load(object? sender, EventArgs e)
        {
            // Gán sự kiện Shown để đảm bảo tất cả controls đã được khởi tạo
            this.Shown += new System.EventHandler(this.frmBan_Shown);
        }

        private void frmBan_Shown(object? sender, EventArgs e)
        {
            LoadData();
            menuXoaTrang_Click(sender, e);
        }

        private void menuThem_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaBan.Text))
            {
                MessageBox.Show("Chưa nhập mã bàn");
                txtMaBan.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSucChua.Text))
            {
                MessageBox.Show("Chưa nhập sức chứa");
                txtSucChua.Focus();
                return;
            }
            string strSQL = "SELECT MaBan FROM Ban WHERE MaBan = @MaBan";
            var paramCheck = new Dictionary<string, object> { { "@MaBan", txtMaBan.Text } };
            if (ConnectSQL.ExcuteReader_bool(strSQL, paramCheck))
            {
                MessageBox.Show("Mã bàn này đã tồn tại, vui lòng tạo mã khác");
                txtMaBan.Focus();
                return;
            }
            strSQL = "INSERT INTO Ban(MaBan, SucChua, TrangThai) VALUES (@MaBan, @SucChua, 0)"; //0 : Bàn trống, 1: Bàn có người
            var parameters = new Dictionary<string, object> { { "@MaBan", txtMaBan.Text }, { "@SucChua", txtSucChua.Text } };

            ConnectSQL.RunQuery(strSQL, parameters);
            MessageBox.Show("Thêm thành công");
            LoadData();
            menuXoaTrang_Click(sender, e); // Xóa trắng các ô để chuẩn bị thêm mới
        }

        private void menuSua_Click(object? sender, EventArgs e)
        {
            if (dtgvData.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để sửa");
                return;
            }
            if (string.IsNullOrEmpty(txtMaBan.Text))
            {
                MessageBox.Show("Chưa nhập mã bàn");
                txtMaBan.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSucChua.Text))
            {
                MessageBox.Show("Chưa nhập sức chứa");
                txtSucChua.Focus();
                return;
            }
            if (dtgvData.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một bàn để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string MaBanSua = dtgvData.CurrentRow.Cells[0].Value?.ToString()?.Trim() ?? string.Empty;
            string maBanMoi = txtMaBan.Text.Trim();

            if (maBanMoi != MaBanSua)
            {
                string strSQLCheck = "SELECT MaBan FROM Ban WHERE MaBan = @MaBan";
                if (ConnectSQL.ExcuteReader_bool(strSQLCheck, new Dictionary<string, object> { { "@MaBan", maBanMoi } }))
                {
                    MessageBox.Show("Mã bàn này đã tồn tại, vui lòng tạo mã khác");
                    txtMaBan.Focus();
                    return;
                }
            }
            string strSQL = "UPDATE Ban SET MaBan = @MaBan, SucChua = @SucChua WHERE MaBan = @MaBanSua";
            var parameters = new Dictionary<string, object> { { "@MaBan", maBanMoi }, { "@SucChua", txtSucChua.Text }, { "@MaBanSua", MaBanSua } };
            ConnectSQL.RunQuery(strSQL, parameters);
            MessageBox.Show("Sửa thành công");
            LoadData();
            menuXoaTrang_Click(sender, e); // Xóa trắng các ô sau khi sửa
        }

        private void dtgvData_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Đảm bảo dtgvData.Columns không null và có đủ cột
            if (dtgvData.Columns == null || dtgvData.Columns.Count <= e.ColumnIndex) return;

            // Kiểm tra nếu đây là cột "Trạng thái" và cell style không null
            if (dtgvData.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null && e.CellStyle != null)
            {
                if (e.Value.ToString() == "Bàn có người")
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 171, 145); // #FFAB91
                }
                else if (e.Value.ToString() == "Bàn trống")
                {
                    e.CellStyle.BackColor = Color.FromArgb(165, 214, 167); // #A5D6A7
                }
            }
        }
        private void menuXoa_Click(object? sender, EventArgs e)
        {
            if (dtgvData.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để xóa");
                return;
            }
            if (dtgvData.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một bàn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string maBanXoa = dtgvData.CurrentRow.Cells["MaBan"].Value?.ToString()?.Trim() ?? string.Empty;
            string strCheck = "SELECT MaBan FROM HoaDon WHERE MaBan = @MaBan";
            var paramCheck = new Dictionary<string, object> { { "@MaBan", maBanXoa } };
            if (ConnectSQL.ExcuteReader_bool(strCheck, paramCheck))
            {
                MessageBox.Show("Dữ liệu đã phát sinh khóa ngoại trong bảng HoaDon, không xóa được");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string strSQL = "DELETE FROM Ban WHERE MaBan = @MaBan";
                ConnectSQL.RunQuery(strSQL, new Dictionary<string, object> { { "@MaBan", maBanXoa } });
                MessageBox.Show("Xóa thành công");
                LoadData();
                menuXoaTrang_Click(sender, e); // Xóa trắng các ô sau khi xóa
            }
        }

        private void menuXoaTrang_Click(object? sender, EventArgs e)
        {
            if (txtMaBan != null) txtMaBan.Text = "";
            if (txtSucChua != null) txtSucChua.Text = "";
            if (txtMaBan != null)
            {
                txtMaBan.Focus();
            }
        }

        private void menuTimKiem_Click(object? sender, EventArgs e)
        {
            LoadData();
        }

        private void dtgvData_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvData.Rows[e.RowIndex];
                txtMaBan.Text = row.Cells["MaBan"].Value?.ToString() ?? string.Empty;
                txtSucChua.Text = row.Cells["SucChua"].Value?.ToString() ?? string.Empty;
            }
        }

        // Sự kiện TextChanged để tự động viết hoa
        private void txtMaBan_TextChanged(object? sender, EventArgs e)
        {
            // Lưu vị trí con trỏ hiện tại
            int selectionStart = txtMaBan.SelectionStart;
            // Chuyển đổi văn bản thành chữ hoa
            txtMaBan.Text = txtMaBan.Text.ToUpper();
            // Đặt lại vị trí con trỏ
            txtMaBan.SelectionStart = selectionStart;
        }

        private void menuThoat_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
