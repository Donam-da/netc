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
    public partial class frmNhanVien: Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        public static void SetupDataGridView(DataGridView dgvMain)
        {
            dgvMain.AllowUserToAddRows = false;
            dgvMain.ReadOnly = true;
            dgvMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMain.RowHeadersVisible = false;
            dgvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Styling
            dgvMain.BackgroundColor = Color.FromArgb(240, 228, 215); // #F0E4D7
            dgvMain.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 248, 240); // #FFF8F0
            dgvMain.DefaultCellStyle.BackColor = Color.FromArgb(240, 228, 215); // #F0E4D7
            dgvMain.DefaultCellStyle.SelectionBackColor = Color.FromArgb(203, 165, 126); // #CBA57E
            dgvMain.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvMain.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMain.ColumnHeadersHeight = 30;
            dgvMain.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(90, 59, 46); // #5A3B2E
            dgvMain.EnableHeadersVisualStyles = false;
            dgvMain.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMain.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
        }
        private void LoadData()
        {
            string strSQl = "SELECT * FROM NhanVien WHERE TenNV LIKE @TenNV";
            var parameters = new Dictionary<string, object>
            {
                { "@TenNV", $"%{txtSearch.Text}%" }
            };
            dtgvData.DataSource = ConnectSQL.Load(strSQl, parameters);
            SetupDataGridView(dtgvData);
            dtgvData.Columns[0].HeaderText = "Mã người dùng";
            dtgvData.Columns[1].HeaderText = "Tên người dùng";
            dtgvData.Columns[2].HeaderText = "Mật khẩu";
            dtgvData.Columns[3].HeaderText = "Số điện thoại";
            dtgvData.Columns[4].HeaderText = "Địa chỉ";
            dtgvData.Columns[5].HeaderText = "Quyền";
            if (dtgvData.Rows.Count == 0)
            {
                txtMaNV.Text = "";
                txtTenNV.Text = "";
                txtMatKhau.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
            }
            else
            {
                DataGridViewRow drow = dtgvData.Rows[0];
                txtMaNV.Text = drow.Cells[0].Value?.ToString() ?? string.Empty;
                txtTenNV.Text = drow.Cells[1].Value?.ToString() ?? string.Empty;
                txtMatKhau.Text = drow.Cells[2].Value?.ToString() ?? string.Empty;
                txtDiaChi.Text = drow.Cells[3].Value?.ToString() ?? string.Empty;
                txtSDT.Text = drow.Cells[4].Value?.ToString() ?? string.Empty;
                cboQuyen.Text = drow.Cells[5].Value?.ToString() ?? string.Empty;
            }
        }
        private void DanhSachQuyen()
        {
            DataTable dataTable = new DataTable();
            cboQuyen.Items.Clear();
            dataTable.Columns.Add("Quyen", typeof(string));
            dataTable.Rows.Add("Chủ cửa hàng");
            dataTable.Rows.Add("Nhân viên");
            cboQuyen.DataSource = dataTable;
            cboQuyen.DisplayMember = "Quyen";
            cboQuyen.ValueMember = "Quyen";
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            DanhSachQuyen();
            LoadData();
        }

        private void menuThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Chưa nhập mã nhân viên");
                txtMaNV.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTenNV.Text))
            {
                MessageBox.Show("Chưa nhập tên nhân viên");
                txtTenNV.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Chưa nhập mã mật khẩu");
                txtMaNV.Focus();
                return;
            }
            string strSQL = "SELECT MaNV FROM NhanVien WHERE MaNV = @MaNV";
            if (ConnectSQL.ExcuteReader_bool(strSQL, new Dictionary<string, object> { { "@MaNV", txtMaNV.Text } }))
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại, vui lòng tạo mã khác");
                txtMaNV.Focus();
                return;
            }
            strSQL = "INSERT INTO NhanVien(MaNV,TenNV,MatKhau,SDT,DiaChi,Quyen) VALUES (@MaNV, @TenNV, @MatKhau, @SDT, @DiaChi, @Quyen)";
            var parameters = new Dictionary<string, object>
            {
                { "@MaNV", txtMaNV.Text }, { "@TenNV", txtTenNV.Text }, { "@MatKhau", txtMatKhau.Text },
                { "@SDT", txtSDT.Text }, { "@DiaChi", txtDiaChi.Text }, { "@Quyen", cboQuyen.Text }
            };
            ConnectSQL.RunQuery(strSQL, parameters);
            MessageBox.Show("Thêm thành công");
            LoadData();
        }

        private void dtgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgvData.Columns[e.ColumnIndex].Name == "MatKhau" && e.Value != null)
            {
                e.Value = new string('*', e.Value.ToString()!.Length); 
                e.FormattingApplied = true;
            }
        }

        private void menuXoaTrang_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtMatKhau.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }

        private void menuSua_Click(object sender, EventArgs e)
        {
            if (dtgvData.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để sửa");
                return;
            }
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Chưa nhập mã nhân viên");
                txtMaNV.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTenNV.Text))
            {
                MessageBox.Show("Chưa nhập tên nhân viên");
                txtTenNV.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Chưa nhập mã mật khẩu");
                txtMaNV.Focus();
                return;
            }
            if (dtgvData.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string MaNVSua = dtgvData.CurrentRow.Cells[0].Value?.ToString()?.Trim() ?? string.Empty;
            string maNVMoi = txtMaNV.Text.Trim();

            if (maNVMoi != MaNVSua)
            {
                string strSQLCheck = "SELECT MaNV FROM NhanVien WHERE MaNV = @MaNV";
                if (ConnectSQL.ExcuteReader_bool(strSQLCheck, new Dictionary<string, object> { { "@MaNV", maNVMoi } }))
                {
                    MessageBox.Show("Mã nhân viên này đã tồn tại, vui lòng tạo mã khác");
                    txtMaNV.Focus();
                    return;
                }
            }
            string strSQL = "UPDATE NhanVien SET MaNV = @MaNV, TenNV = @TenNV, MatKhau = @MatKhau, SDT = @SDT, DiaChi = @DiaChi, Quyen = @Quyen WHERE MaNV = @MaNVSua";
            var parameters = new Dictionary<string, object>
            {
                { "@MaNV", maNVMoi }, { "@TenNV", txtTenNV.Text }, { "@MatKhau", txtMatKhau.Text }, { "@SDT", txtSDT.Text },
                { "@DiaChi", txtDiaChi.Text }, { "@Quyen", cboQuyen.Text }, { "@MaNVSua", MaNVSua }
            };
            ConnectSQL.RunQuery(strSQL, parameters);
            MessageBox.Show("Sửa thành công");
            LoadData();
        }

        private void dtgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvData.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNV"].Value?.ToString() ?? string.Empty;
                txtTenNV.Text = row.Cells["TenNV"].Value?.ToString() ?? string.Empty;
                txtMatKhau.Text = row.Cells["MatKhau"].Value?.ToString() ?? string.Empty;
                txtSDT.Text = row.Cells["SDT"].Value?.ToString() ?? string.Empty;
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString() ?? string.Empty;
                cboQuyen.Text = row.Cells[5].Value?.ToString() ?? string.Empty;
            }
        }

        private void menuXoa_Click(object sender, EventArgs e)
        {
            if(dtgvData.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để xóa");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (dtgvData.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string maNVXoa = dtgvData.CurrentRow.Cells[0].Value?.ToString()?.Trim() ?? string.Empty;
                string strSQL = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                ConnectSQL.RunQuery(strSQL, new Dictionary<string, object> { { "@MaNV", maNVXoa } });
                MessageBox.Show("Xóa thành công");
                LoadData();
            }
        }

        private void menuTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
