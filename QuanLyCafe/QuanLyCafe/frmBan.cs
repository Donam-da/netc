﻿﻿﻿using System;
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

        private void txtSucChua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
        private void LoadData()
        {
            string strSQl = $@"SELECT MaBan,SucChua, CASE WHEN TrangThai = 0 THEN N'Bàn trống' ELSE N'Bàn có người' END AS TrangThai FROM Ban WHERE MaBan LIKE N'%{txtSearch.Text}%'";
            dtgvData.DataSource = ConnectSQL.Load(strSQl);
            frmNhanVien.SetupDataGridView(dtgvData);
            dtgvData.Columns[0].HeaderText = "Mã bàn";
            dtgvData.Columns[1].HeaderText = "Sức chứa";
            dtgvData.Columns[2].HeaderText = "Trạng thái";
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
                    if (row.Cells["MaBan"].Value?.ToString() == SelectedMaBan)
                    {
                        dtgvData.CurrentCell = row.Cells[0]; // Chọn dòng này
                        // Cập nhật thông tin vào các ô text
                        txtMaBan.Text = row.Cells["MaBan"].Value.ToString();
                        txtSucChua.Text = row.Cells["SucChua"].Value.ToString();
                        break; // Dừng vòng lặp khi đã tìm thấy
                    }
                }
            }
            else // Nếu không có mã bàn nào được truyền, hiển thị dòng đầu tiên
            {
                DataGridViewRow firstRow = dtgvData.Rows[0];
                if (firstRow != null)
                {
                    txtMaBan.Text = firstRow.Cells[0].Value.ToString();
                    txtSucChua.Text = firstRow.Cells[1].Value.ToString();
                }
            }
        }
        private void frmBan_Load(object sender, EventArgs e)
        {
            LoadData();
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
            string strSQL = $@"SELECT * FROM Ban WHERE MaBan = '{txtMaBan.Text}'";
            if (ConnectSQL.ExcuteReader_bool(strSQL))
            {
                MessageBox.Show("Mã bàn này đã tồn tại, vui lòng tạo mã khác");
                txtMaBan.Focus();
                return;
            }
            strSQL = $@"INSERT INTO Ban(MaBan,SucChua,TrangThai)
                        VALUES ('{txtMaBan.Text}',{txtSucChua.Text},'0')"; //0 : Bàn trống, 1: Bàn có người
            ConnectSQL.RunQuery(strSQL);
            MessageBox.Show("Thêm thành công");
            LoadData();
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
            string strSQL = $@"SELECT * FROM Ban WHERE MaBan = '{txtMaBan.Text}'";
            if (dtgvData.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một bàn để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string MaBanSua = dtgvData.CurrentRow.Cells[0].Value?.ToString()?.Trim() ?? string.Empty;

            if (ConnectSQL.ExcuteReader_bool(strSQL) && txtMaBan.Text.Trim() != MaBanSua)
            {
                MessageBox.Show("Mã bàn này đã tồn tại, vui lòng tạo mã khác");
                txtMaBan.Focus();
                return;
            }
            strSQL = $@"UPDATE Ban SET MaBan = '{txtMaBan.Text}'
                        ,SucChua = {txtSucChua.Text}
                        WHERE MaBan = '{MaBanSua}'";
            ConnectSQL.RunQuery(strSQL);
            MessageBox.Show("Sửa thành công");
            LoadData();
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
            string strCheck = $@"SELECT * FROM HoaDon WHERE MaBan = '{maBanXoa}'";
            if (ConnectSQL.ExcuteReader_bool(strCheck))
            {
                MessageBox.Show("Dữ liệu đã phát sinh khóa ngoại trong bảng HoaDon, không xóa được");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string strSQL = $@"DELETE Ban WHERE MaBan = '{maBanXoa}'";
                ConnectSQL.RunQuery(strSQL);
                MessageBox.Show("Xóa thành công");
                LoadData();
            }
        }

        private void menuXoaTrang_Click(object sender, EventArgs e)
        {
            txtMaBan.Text = "";
            txtSucChua.Text = "";
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
