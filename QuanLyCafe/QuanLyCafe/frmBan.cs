﻿﻿﻿﻿﻿using System;
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
        private bool _isSettingMaBanText = false; // Cờ để tránh vòng lặp vô hạn trong TextChanged
        private const string PREFIX = "BAN"; // Tiền tố cố định cho mã bàn

        public frmBan()
        {
            InitializeComponent();
        }

        // Constructor mới để nhận mã bàn từ form chính
        public frmBan(string maBan) : this()
        {
            this.SelectedMaBan = maBan;
        }

        private void txtSucChua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
        private void LoadData()
        {
            string strSql = "SELECT MaBan, SucChua, CASE WHEN TrangThai = 0 THEN N'Bàn trống' ELSE N'Bàn có người' END AS TrangThai FROM Ban WHERE MaBan LIKE @SearchText";
            var parameters = new Dictionary<string, object>
            {
                { "@SearchText", $"%{txtSearch.Text}%" }
            };
            dtgvData.DataSource = ConnectSQL.Load(strSql, parameters);
            frmNhanVien.SetupDataGridView(dtgvData);

            // Tạm thời tắt sự kiện TextChanged để tránh lỗi khi gán giá trị bằng code
            _isSettingMaBanText = true;

            dtgvData.Columns[0].HeaderText = "Mã bàn";
            dtgvData.Columns[1].HeaderText = "Sức chứa";
            dtgvData.Columns[2].HeaderText = "Trạng thái";
            if (dtgvData.Rows.Count == 0)
            {
                txtMaBan.Text = PREFIX; // Đặt mặc định là "BAN"
                txtSucChua.Text = "";
            }
            else if (!string.IsNullOrEmpty(SelectedMaBan))
            {
                // Tìm và chọn dòng có mã bàn được truyền vào
                foreach (DataGridViewRow row in dtgvData.Rows)
                {
                    string? maBanValue = row.Cells["MaBan"].Value?.ToString();
                    if (maBanValue == SelectedMaBan)
                    {
                        dtgvData.CurrentCell = row.Cells[0]; // Chọn dòng này
                        // Cập nhật thông tin vào các ô text
                        txtMaBan.Text = maBanValue;
                        txtSucChua.Text = row.Cells["SucChua"].Value.ToString();
                        break; // Dừng vòng lặp khi đã tìm thấy
                    }
                }
            }
            else // Nếu không có mã bàn nào được truyền, hiển thị dòng đầu tiên
            {
                if (dtgvData.Rows.Count > 0)
                {
                    DataGridViewRow firstRow = dtgvData.Rows[0];
                    if (firstRow != null)
                    {
                        txtMaBan.Text = firstRow.Cells[0].Value.ToString();
                        txtSucChua.Text = firstRow.Cells[1].Value.ToString();
                    }
                }
            }
            _isSettingMaBanText = false; // Bật lại sự kiện TextChanged
            txtMaBan.SelectionStart = txtMaBan.Text.Length; // Đặt con trỏ ở cuối
        }
        private void frmBan_Load(object sender, EventArgs e)
        {
            LoadData(); // LoadData sẽ tự động đặt txtMaBan.Text và gọi menuXoaTrang_Click nếu không có dữ liệu
            // Không cần gọi menuXoaTrang_Click ở đây nữa vì LoadData đã xử lý
        }

        private void menuThem_Click(object sender, EventArgs e)
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
            if (txtMaBan.Text.Length <= 3)
            {
                MessageBox.Show("Bạn phải nhập thêm số cho mã bàn.");
                txtMaBan.Focus();
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

        private void menuSua_Click(object sender, EventArgs e)
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

        private void dtgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

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
        private void menuXoa_Click(object sender, EventArgs e)
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

        private void menuXoaTrang_Click(object sender, EventArgs e)
        {
            _isSettingMaBanText = true; // Tắt TextChanged tạm thời
            txtMaBan.Text = PREFIX;
            _isSettingMaBanText = false; // Bật lại TextChanged
            txtSucChua.Text = "";
            txtMaBan.Focus();
            txtMaBan.SelectionStart = txtMaBan.Text.Length; // Đưa con trỏ đến cuối
        }

        private void menuTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvData.Rows[e.RowIndex];
                txtMaBan.Text = row.Cells["MaBan"].Value.ToString();
                txtSucChua.Text = row.Cells["SucChua"].Value.ToString();
            }
        }

        // Sự kiện KeyDown để chặn Backspace/Delete/Left Arrow trong phần tiền tố
        private void txtMaBan_KeyDown(object sender, KeyEventArgs e)
        {
            // Nếu con trỏ nằm trong hoặc ngay sau tiền tố (ví dụ: BAN|)
            if (txtMaBan.SelectionStart <= PREFIX.Length)
            {
                // Chặn Backspace, Delete, Left Arrow để không xóa/di chuyển vào tiền tố
                if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Left)
                {
                    e.SuppressKeyPress = true;
                }
            }
        }

        // Sự kiện KeyPress để chỉ cho phép nhập số sau tiền tố
        private void txtMaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Nếu con trỏ nằm trong phần tiền tố (ví dụ: B|AN)
            if (txtMaBan.SelectionStart < PREFIX.Length)
            {
                // Chặn nhập bất kỳ ký tự nào
                e.Handled = true;
            }
            // Nếu con trỏ ở sau tiền tố, chỉ cho phép nhập số
            else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Sự kiện TextChanged để xử lý các trường hợp dán (paste) hoặc thay đổi không mong muốn
        private void txtMaBan_TextChanged(object sender, EventArgs e)
        {
            if (_isSettingMaBanText) return; // Tránh vòng lặp vô hạn

            string currentText = txtMaBan.Text;
            int selectionStart = txtMaBan.SelectionStart;
            string newText = currentText;
            bool changed = false;

            // 1. Đảm bảo chuỗi luôn bắt đầu bằng PREFIX
            if (!currentText.StartsWith(PREFIX))
            {
                string numericPart = System.Text.RegularExpressions.Regex.Replace(currentText, @"[^\d]", "");
                newText = PREFIX + numericPart;
                changed = true;
            }
            // 2. Đảm bảo chỉ có ký tự số sau PREFIX
            else if (currentText.Length > PREFIX.Length)
            {
                string numericPart = currentText.Substring(PREFIX.Length);
                string cleanedNumericPart = System.Text.RegularExpressions.Regex.Replace(numericPart, @"[^\d]", "");
                if (numericPart != cleanedNumericPart)
                {
                    newText = PREFIX + cleanedNumericPart;
                    changed = true;
                }
            }
            // 3. Nếu người dùng xóa mất một phần của PREFIX (mặc dù KeyDown đã chặn)
            else if (currentText.Length < PREFIX.Length)
            {
                newText = PREFIX;
                changed = true;
            }

            if (changed)
            {
                _isSettingMaBanText = true; // Tắt TextChanged tạm thời
                txtMaBan.Text = newText;
                _isSettingMaBanText = false; // Bật lại TextChanged
                txtMaBan.SelectionStart = txtMaBan.Text.Length; // Đặt con trỏ ở cuối
            }
            // Nếu không có thay đổi nào từ code, nhưng con trỏ đang ở trong vùng PREFIX, di chuyển nó ra sau
            else if (selectionStart < PREFIX.Length)
            {
                txtMaBan.SelectionStart = PREFIX.Length;
            }
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
