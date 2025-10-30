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
    public partial class frmKhachHang: Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            string strSQl = $@"SELECT * FROM KhachHang WHERE TenKH LIKE N'%{txtSearch.Text}%'";
            dtgvData.DataSource = ConnectSQL.Load(strSQl);
            frmNhanVien.SetupDataGridView(dtgvData);
            dtgvData.Columns[0].HeaderText = "Mã KH";
            dtgvData.Columns[1].HeaderText = "Tên KH";
            dtgvData.Columns[2].HeaderText = "SĐT";
            dtgvData.Columns[3].HeaderText = "Địa chỉ";
            if (dtgvData.Rows.Count == 0)
            {
                txtMaKH.Text = "";
                txtTenKH.Text = "";
                txtSDT.Text = "";
                txtDiaChi.Text = "";
            }
            else
            {
                DataGridViewRow drow = dtgvData.Rows[0];
                txtMaKH.Text = drow.Cells[0].Value.ToString();
                txtTenKH.Text = drow.Cells[1].Value.ToString();
                txtSDT.Text = drow.Cells[2].Value.ToString();
                txtDiaChi.Text = drow.Cells[3].Value.ToString();
            }
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void menuThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Chưa nhập mã kh");
                txtMaKH.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTenKH.Text))
            {
                MessageBox.Show("Chưa nhập tên kh");
                txtTenKH.Focus();
                return;
            }
            string strSQL = $@"SELECT * FROM KhachHang WHERE MaKH = '{txtMaKH.Text}'";
            if (ConnectSQL.ExcuteReader_bool(strSQL))
            {
                MessageBox.Show("Mã khách hàng này đã tồn tại, vui lòng tạo mã khác");
                txtMaKH.Focus();
                return;
            }
            strSQL = $@"INSERT INTO KhachHang(MaKH,TenKH,SDT,DiaChi)
                        VALUES ('{txtMaKH.Text}',N'{txtTenKH.Text}','{txtSDT.Text}',N'{txtDiaChi.Text}')";
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
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Chưa nhập mã kh");
                txtMaKH.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTenKH.Text))
            {
                MessageBox.Show("Chưa nhập tên kh");
                txtTenKH.Focus();
                return;
            }
            string strSQL = $@"SELECT * FROM KhachHang WHERE MaKH = '{txtMaKH.Text}'";
            string MaKHSua = dtgvData.CurrentRow.Cells[0].Value.ToString().Trim();
            if (ConnectSQL.ExcuteReader_bool(strSQL) && txtMaKH.Text.Trim() != MaKHSua)
            {
                MessageBox.Show("Mã khách hàng này đã tồn tại, vui lòng tạo mã khác");
                txtMaKH.Focus();
                return;
            }
            strSQL = $@"UPDATE KhachHang SET MaKH = '{txtMaKH.Text}'
                        ,TenKh = N'{txtTenKH.Text}',SDT = '{txtSDT.Text}',DiaChi = N'{txtDiaChi.Text}'
                        WHERE MaKH = '{MaKHSua}'";
            ConnectSQL.RunQuery(strSQL);
            MessageBox.Show("Sửa thành công");
            LoadData();
        }

        private void menuXoa_Click(object sender, EventArgs e)
        {
            if (dtgvData.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để xóa");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string strSQL = $@"DELETE KhachHang WHERE MaKH = '{dtgvData.CurrentRow.Cells[0].Value.ToString().Trim()}'";
                ConnectSQL.RunQuery(strSQL);
                MessageBox.Show("Xóa thành công");
                LoadData();
            }
        }

        private void menuXoaTrang_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
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
                txtMaKH.Text = row.Cells["MaKH"].Value.ToString();
                txtTenKH.Text = row.Cells["TenKH"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
            }
        }
    }
}
