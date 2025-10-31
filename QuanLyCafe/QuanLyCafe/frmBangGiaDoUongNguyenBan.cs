using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class frmBangGiaDoUongNguyenBan : Form
    {
        private DataTable dtOriginalDrinks = new DataTable();

        public frmBangGiaDoUongNguyenBan()
        {
            InitializeComponent();
        }

        private void frmBangGiaDoUongNguyenBan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            // Chỉ lấy những đồ uống là 'Nguyên bản' (IsPhaChe = 0)
            string sql = @"SELECT MaDU, TenDU, GiaGoc 
                           FROM DoUong 
                           WHERE IsPhaChe = 0 AND TenDU LIKE @TenDU";
            var parameters = new Dictionary<string, object>
            {
                { "@TenDU", $"%{txtSearch.Text}%" }
            };

            dtOriginalDrinks = ConnectSQL.Load(sql, parameters);
            dtgvGiaGoc.DataSource = dtOriginalDrinks;

            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            frmNhanVien.SetupDataGridView(dtgvGiaGoc);
            dtgvGiaGoc.ReadOnly = false; // Cho phép sửa

            dtgvGiaGoc.Columns["MaDU"].HeaderText = "Mã Đồ Uống";
            dtgvGiaGoc.Columns["MaDU"].ReadOnly = true; // Không cho sửa Mã

            dtgvGiaGoc.Columns["TenDU"].HeaderText = "Tên Đồ Uống";
            dtgvGiaGoc.Columns["TenDU"].ReadOnly = true; // Không cho sửa Tên

            dtgvGiaGoc.Columns["GiaGoc"].HeaderText = "Giá Nhập Vào";
            dtgvGiaGoc.Columns["GiaGoc"].DefaultCellStyle.Format = "N0"; // Định dạng số
            dtgvGiaGoc.Columns["GiaGoc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy những thay đổi từ DataTable
                DataTable changes = dtOriginalDrinks.GetChanges();
                if (changes == null)
                {
                    MessageBox.Show("Không có thay đổi nào để lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int updatedRows = 0;
                foreach (DataRow row in changes.Rows)
                {
                    // Chỉ xử lý các dòng đã được sửa đổi
                    if (row.RowState == DataRowState.Modified)
                    {
                        string maDU = row["MaDU"]?.ToString() ?? string.Empty;
                        // Lấy giá trị mới, nếu là DBNull thì coi như 0
                        decimal giaGoc = (row["GiaGoc"] == DBNull.Value) ? 0 : Convert.ToDecimal(row["GiaGoc"]);

                        string sqlUpdate = "UPDATE DoUong SET GiaGoc = @GiaGoc WHERE MaDU = @MaDU";
                        var parameters = new Dictionary<string, object>
                        {
                            { "@GiaGoc", giaGoc },
                            { "@MaDU", maDU }
                        };

                        if (ConnectSQL.RunQuery(sqlUpdate, parameters) > 0)
                        {
                            updatedRows++;
                        }
                    }
                }

                // Chấp nhận các thay đổi để dtOriginalDrinks.GetChanges() trả về null ở lần sau
                dtOriginalDrinks.AcceptChanges();
                MessageBox.Show($"Đã cập nhật thành công giá cho {updatedRows} đồ uống.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Tự động lọc khi gõ
            LoadData();
        }
    }
}
