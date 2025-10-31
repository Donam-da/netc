﻿using System;
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
    public partial class frmLoaiDoUong: Form
    {
        public frmLoaiDoUong()
        {
            InitializeComponent();
        }

        private void frmLoaiDoUong_Load(object sender, EventArgs e)
        {
            LoadData();
            btnXoaTrang_Click(sender, e); // Xóa trắng và chuẩn bị cho lần nhập đầu
        }

        private void LoadData()
        {
            string strSQl = "SELECT MaLoai, TenLoai FROM LoaiDoUong WHERE TenLoai LIKE @TenLoai";
            var parameters = new Dictionary<string, object>
            {
                { "@TenLoai", $"%{txtSearch.Text}%" }
            };

            dtgvData.DataSource = ConnectSQL.Load(strSQl, parameters);

            // Sử dụng lại hàm style chung
            frmNhanVien.SetupDataGridView(dtgvData);

            // Tùy chỉnh header và độ rộng cột
            dtgvData.Columns[0].HeaderText = "Mã loại";
            dtgvData.Columns[1].HeaderText = "Tên loại";

            if (dtgvData.Rows.Count == 0)
            {
                // Nếu không có dữ liệu, xóa trắng các ô nhập
                btnXoaTrang_Click(this, EventArgs.Empty);
            }
            else
            {
                // Tự động chọn dòng đầu tiên và hiển thị dữ liệu
                dtgvData_CellClick(this, new DataGridViewCellEventArgs(0, 0));
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLoai.Text))
            {
                MessageBox.Show("Chưa nhập mã loại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoai.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
            {
                MessageBox.Show("Chưa nhập tên loại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoai.Focus();
                return;
            }

            string sqlCheck = "SELECT MaLoai FROM LoaiDoUong WHERE MaLoai = @MaLoai";
            var paramCheck = new Dictionary<string, object> { { "@MaLoai", txtMaLoai.Text.Trim() } };
            if (ConnectSQL.ExcuteReader_bool(sqlCheck, paramCheck))
            {
                MessageBox.Show("Mã loại đồ uống này đã tồn tại. Vui lòng tạo mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaLoai.Focus();
                return;
            }

            string sqlInsert = "INSERT INTO LoaiDoUong(MaLoai, TenLoai) VALUES (@MaLoai, @TenLoai)";
            var paramInsert = new Dictionary<string, object>
            {
                { "@MaLoai", txtMaLoai.Text.Trim() },
                { "@TenLoai", txtTenLoai.Text.Trim() }
            };

            if (ConnectSQL.RunQuery(sqlInsert, paramInsert) > 0)
            {
                MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                btnXoaTrang_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Thêm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtgvData.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một loại đồ uống để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
            {
                MessageBox.Show("Tên loại không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoai.Focus();
                return;
            }

            string maLoaiSua = dtgvData.CurrentRow.Cells["MaLoai"].Value.ToString()!.Trim();

            string strSQL = "UPDATE LoaiDoUong SET TenLoai = @TenLoai WHERE MaLoai = @MaLoaiSua";
            var parameters = new Dictionary<string, object> {
                { "@TenLoai", txtTenLoai.Text.Trim() },
                { "@MaLoaiSua", maLoaiSua }
            };

            if (ConnectSQL.RunQuery(strSQL, parameters) > 0)
            {
                MessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtgvData.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một loại đồ uống để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maLoai = dtgvData.CurrentRow.Cells["MaLoai"].Value.ToString()!.Trim();

            // Kiểm tra khóa ngoại trong bảng DoUong
            string strCheck = "SELECT MaLoai FROM DoUong WHERE MaLoai = @MaLoai";
            var paramCheck = new Dictionary<string, object> { { "@MaLoai", maLoai } };
            if (ConnectSQL.ExcuteReader_bool(strCheck, paramCheck))
            {
                MessageBox.Show("Không thể xóa vì loại đồ uống này đang được sử dụng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa loại đồ uống này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string strSQL = "DELETE FROM LoaiDoUong WHERE MaLoai = @MaLoai";
                if (ConnectSQL.RunQuery(strSQL, new Dictionary<string, object> { { "@MaLoai", maLoai } }) > 0)
                {
                    MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvData.Rows[e.RowIndex];
                txtMaLoai.Text = row.Cells["MaLoai"].Value?.ToString() ?? "";
                txtTenLoai.Text = row.Cells["TenLoai"].Value?.ToString() ?? "";

                // Khi chọn một dòng, chuyển sang chế độ sửa
                txtMaLoai.ReadOnly = true;
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXoaTrang_Click(object sender, EventArgs e)
        {
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
            txtMaLoai.ReadOnly = false; // Cho phép nhập mã mới
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaLoai.Focus();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtMaLoai_TextChanged(object sender, EventArgs e)
        {
            // Tự động viết hoa khi nhập
            int selectionStart = txtMaLoai.SelectionStart;
            txtMaLoai.Text = txtMaLoai.Text.ToUpper();
            txtMaLoai.SelectionStart = selectionStart;
            txtMaLoai.SelectionLength = 0;
        }
    }
}
