using System;
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
    public partial class frmNguyenLieu : Form
    {
        public frmNguyenLieu()
        {
            InitializeComponent();
        }

        private void frmNguyenLieu_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string strSQL = "SELECT MaNL, TenNL, DonViTinh, GiaTien, SoLuongTon FROM NguyenLieu WHERE TenNL LIKE @TenNL";
            var parameters = new Dictionary<string, object>
            {
                { "@TenNL", $"%{txtSearch.Text}%" }
            };

            dtgvData.DataSource = ConnectSQL.Load(strSQL, parameters);
            // Sử dụng lại hàm style chung từ frmNhanVien
            frmNhanVien.SetupDataGridView(dtgvData);

            // Tùy chỉnh header text
            dtgvData.Columns["MaNL"].HeaderText = "Mã Nguyên liệu";
            dtgvData.Columns["TenNL"].HeaderText = "Tên Nguyên liệu";
            dtgvData.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
            dtgvData.Columns["GiaTien"].HeaderText = "Giá tiền";
            dtgvData.Columns["SoLuongTon"].HeaderText = "Tồn kho";

            // Định dạng cột số
            dtgvData.Columns["GiaTien"].DefaultCellStyle.Format = "N0";
            dtgvData.Columns["SoLuongTon"].DefaultCellStyle.Format = "N2";
            dtgvData.Columns["GiaTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgvData.Columns["SoLuongTon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            if (dtgvData.Rows.Count == 0)
            {
                ClearInputs();
            }
            else
            {
                // Hiển thị dữ liệu của dòng đầu tiên lên các control
                DisplayRowData(dtgvData.Rows[0]);
            }
        }

        private void DisplayRowData(DataGridViewRow row)
        {
            if (row == null) return;

            txtMaNL.Text = row.Cells["MaNL"].Value?.ToString() ?? string.Empty;
            txtTenNL.Text = row.Cells["TenNL"].Value?.ToString() ?? string.Empty;
            txtDonViTinh.Text = row.Cells["DonViTinh"].Value?.ToString() ?? string.Empty;
            nmGiaTien.Value = Convert.ToDecimal(row.Cells["GiaTien"].Value ?? 0);
            nmSoLuongTon.Value = Convert.ToDecimal(row.Cells["SoLuongTon"].Value ?? 0);
        }

        private void ClearInputs()
        {
            txtMaNL.Text = "";
            txtTenNL.Text = "";
            txtDonViTinh.Text = "";
            nmGiaTien.Value = 0;
            nmSoLuongTon.Value = 0;
        }

        private void dtgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DisplayRowData(dtgvData.Rows[e.RowIndex]);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // --- Kiểm tra dữ liệu đầu vào ---
            if (string.IsNullOrWhiteSpace(txtMaNL.Text))
            {
                MessageBox.Show("Chưa nhập mã nguyên liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNL.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenNL.Text))
            {
                MessageBox.Show("Chưa nhập tên nguyên liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNL.Focus();
                return;
            }

            // --- Kiểm tra mã trùng ---
            string sqlCheck = "SELECT MaNL FROM NguyenLieu WHERE MaNL = @MaNL";
            var paramCheck = new Dictionary<string, object> { { "@MaNL", txtMaNL.Text.Trim() } };
            if (ConnectSQL.ExcuteReader_bool(sqlCheck, paramCheck))
            {
                MessageBox.Show("Mã nguyên liệu này đã tồn tại. Vui lòng tạo mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNL.Focus();
                return;
            }

            // --- Thêm vào CSDL ---
            string sqlInsert = "INSERT INTO NguyenLieu(MaNL, TenNL, DonViTinh, GiaTien, SoLuongTon) VALUES (@MaNL, @TenNL, @DonViTinh, @GiaTien, @SoLuongTon)";
            var paramInsert = new Dictionary<string, object>
            {
                { "@MaNL", txtMaNL.Text.Trim() },
                { "@TenNL", txtTenNL.Text.Trim() },
                { "@DonViTinh", txtDonViTinh.Text.Trim() },
                { "@GiaTien", nmGiaTien.Value },
                { "@SoLuongTon", nmSoLuongTon.Value }
            };

            if (ConnectSQL.RunQuery(sqlInsert, paramInsert) > 0)
            {
                MessageBox.Show("Thêm nguyên liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Thêm nguyên liệu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtgvData.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một nguyên liệu để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNLSua = dtgvData.CurrentRow.Cells["MaNL"].Value.ToString()!.Trim();

            // --- Cập nhật CSDL ---
            string strSQL = "UPDATE NguyenLieu SET TenNL = @TenNL, DonViTinh = @DonViTinh, GiaTien = @GiaTien, SoLuongTon = @SoLuongTon WHERE MaNL = @MaNLSua";
            var parameters = new Dictionary<string, object> {
                { "@TenNL", txtTenNL.Text.Trim() },
                { "@DonViTinh", txtDonViTinh.Text.Trim() },
                { "@GiaTien", nmGiaTien.Value },
                { "@SoLuongTon", nmSoLuongTon.Value },
                { "@MaNLSua", maNLSua }
            };

            // Lưu ý: Mã nguyên liệu (khóa chính) thường không nên cho sửa. Nếu muốn sửa, bạn cần xử lý phức tạp hơn.
            // Ở đây, chúng ta chỉ cho sửa các thông tin khác.

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
                MessageBox.Show("Vui lòng chọn một nguyên liệu để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nguyên liệu này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string maNLXoa = dtgvData.CurrentRow.Cells["MaNL"].Value.ToString()!.Trim();
                string strSQL = "DELETE FROM NguyenLieu WHERE MaNL = @MaNL";
                var parameters = new Dictionary<string, object> { { "@MaNL", maNLXoa } };

                // TODO: Trước khi xóa, nên kiểm tra xem nguyên liệu này có đang được sử dụng trong bảng CongThuc không.
                // Nếu có, không cho xóa hoặc hỏi người dùng có muốn xóa cả công thức liên quan.

                if (ConnectSQL.RunQuery(strSQL, parameters) > 0)
                {
                    MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại. Có thể do nguyên liệu đang được sử dụng trong công thức.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}