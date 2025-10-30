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
    public partial class frmNhanVien: Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        public static void SetupDataGridView(DataGridView dgvMain)
        {
            dgvMain.AllowUserToAddRows = false;
            dgvMain.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMain.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvMain.ColumnHeadersHeight = 30;
            dgvMain.ReadOnly = true;
            dgvMain.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            dgvMain.EnableHeadersVisualStyles = false;
            dgvMain.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMain.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            dgvMain.BackgroundColor = Color.White;
        }
        private void LoadData()
        {
            string strSQl = $@"SELECT * FROM NhanVien WHERE TenNV LIKE N'%{txtSearch.Text}%'";
            dtgvData.DataSource = ConnectSQL.Load(strSQl);
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
                txtMaNV.Text = drow.Cells[0].Value.ToString();
                txtTenNV.Text = drow.Cells[1].Value.ToString();
                txtMatKhau.Text = drow.Cells[2].Value.ToString();
                txtDiaChi.Text = drow.Cells[3].Value.ToString();
                txtSDT.Text = drow.Cells[4].Value.ToString();
                cboQuyen.Text = drow.Cells[5].Value.ToString();
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
            string strSQL = $@"SELECT * FROM NhanVien WHERE MaNV = '{txtMaNV.Text}'";
            if (ConnectSQL.ExcuteReader_bool(strSQL))
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại, vui lòng tạo mã khác");
                txtMaNV.Focus();
                return;
            }
            strSQL = $@"INSERT INTO NhanVien(MaNV,TenNV,MatKhau,SDT,DiaChi,Quyen)
                        VALUES ('{txtMaNV.Text}',N'{txtTenNV.Text}',N'{txtMatKhau.Text}','{txtSDT.Text}',N'{txtDiaChi.Text}',N'{cboQuyen.Text}')";
            ConnectSQL.RunQuery(strSQL);
            MessageBox.Show("Thêm thành công");
            LoadData();
        }

        private void dtgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgvData.Columns[e.ColumnIndex].Name == "MatKhau" && e.Value != null)
            {
                e.Value = new string('*', e.Value.ToString().Length); 
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
            string strSQL = $@"SELECT * FROM NhanVien WHERE MaNV = '{txtMaNV.Text}'";
            string MaNVSua = dtgvData.CurrentRow.Cells[0].Value.ToString().Trim();
            if (ConnectSQL.ExcuteReader_bool(strSQL) && txtMaNV.Text.Trim() != MaNVSua)
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại, vui lòng tạo mã khác");
                txtMaNV.Focus();
                return;
            }
            strSQL = $@"UPDATE NhanVien SET MaNV = '{txtMaNV.Text}'
                        ,TenNV = N'{txtTenNV.Text}' ,MatKhau = N'{txtMatKhau.Text}',SDT = '{txtSDT.Text}',DiaChi = N'{txtDiaChi.Text}'
                        ,Quyen = N'{cboQuyen.Text}'
                        WHERE MaNV = '{MaNVSua}'";
            ConnectSQL.RunQuery(strSQL);
            MessageBox.Show("Sửa thành công");
            LoadData();
        }

        private void dtgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvData.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtTenNV.Text = row.Cells["TenNV"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                cboQuyen.Text = row.Cells[5].Value.ToString();
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
                string strSQL = $@"DELETE NhanVien WHERE MaNV = '{dtgvData.CurrentRow.Cells[0].Value.ToString().Trim()}'";
                ConnectSQL.RunQuery(strSQL);
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
