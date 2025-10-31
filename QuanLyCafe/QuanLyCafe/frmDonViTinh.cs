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
    public partial class frmDonViTinh : Form
    {
        public frmDonViTinh()
        {
            InitializeComponent();
        }

        private void frmDonViTinh_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string strSQL = "SELECT * FROM DonViTinh WHERE TenDVT LIKE @TenDVT";
            var parameters = new Dictionary<string, object>
            {
                { "@TenDVT", $"%{txtSearch.Text}%" }
            };

            dtgvData.DataSource = ConnectSQL.Load(strSQL, parameters);
            frmNhanVien.SetupDataGridView(dtgvData);
            dtgvData.Columns["MaDVT"].HeaderText = "Mã Đơn Vị Tính";
            dtgvData.Columns["TenDVT"].HeaderText = "Tên Đơn Vị Tính";

            if (dtgvData.Rows.Count == 0)
            {
                txtMaDVT.Text = "";
                txtTenDVT.Text = "";
            }
            else
            {
                DataGridViewRow drow = dtgvData.Rows[0];
                txtMaDVT.Text = drow.Cells[0].Value.ToString();
                txtTenDVT.Text = drow.Cells[1].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDVT.Text))
            {
                MessageBox.Show("Chưa nhập mã đơn vị tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDVT.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenDVT.Text))
            {
                MessageBox.Show("Chưa nhập tên đơn vị tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDVT.Focus();
                return;
            }

            string sqlCheck = "SELECT MaDVT FROM DonViTinh WHERE MaDVT = @MaDVT";
            var paramCheck = new Dictionary<string, object> { { "@MaDVT", txtMaDVT.Text.Trim() } };
            if (ConnectSQL.ExcuteReader_bool(sqlCheck, paramCheck))
            {
                MessageBox.Show("Mã đơn vị tính này đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDVT.Focus();
                return;
            }

            string sqlInsert = "INSERT INTO DonViTinh(MaDVT, TenDVT) VALUES (@MaDVT, @TenDVT)";
            var paramInsert = new Dictionary<string, object>
            {
                { "@MaDVT", txtMaDVT.Text.Trim() },
                { "@TenDVT", txtTenDVT.Text.Trim() }
            };
            if (ConnectSQL.RunQuery(sqlInsert, paramInsert) > 0)
            {
                MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtgvData.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một mục để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maDVTSua = dtgvData.CurrentRow.Cells["MaDVT"].Value.ToString()!.Trim();
            string strSQL = "UPDATE DonViTinh SET TenDVT = @TenDVT WHERE MaDVT = @MaDVTSua";
            var parameters = new Dictionary<string, object> {
                { "@TenDVT", txtTenDVT.Text.Trim() },
                { "@MaDVTSua", maDVTSua }
            };
            // Không cho phép sửa mã (khóa chính)
            if (ConnectSQL.RunQuery(strSQL, parameters) > 0)
            {
                MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtgvData.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một mục để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string maDVT = dtgvData.CurrentRow.Cells["MaDVT"].Value.ToString()!.Trim();
                // Cần kiểm tra khóa ngoại trong bảng NguyenLieu trước khi xóa
                string sqlCheck = "SELECT MaNL FROM NguyenLieu WHERE DonViTinh = @MaDVT";
                if (ConnectSQL.ExcuteReader_bool(sqlCheck, new Dictionary<string, object> { { "@MaDVT", maDVT } }))
                {
                    MessageBox.Show("Không thể xóa vì đơn vị tính này đang được sử dụng trong bảng Nguyên Liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string strSQL = "DELETE FROM DonViTinh WHERE MaDVT = @MaDVT";
                if (ConnectSQL.RunQuery(strSQL, new Dictionary<string, object> { { "@MaDVT", maDVT } }) > 0)
                {
                    MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
        }

        private void dtgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvData.Rows[e.RowIndex];
                txtMaDVT.Text = row.Cells["MaDVT"].Value.ToString();
                txtTenDVT.Text = row.Cells["TenDVT"].Value.ToString();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}