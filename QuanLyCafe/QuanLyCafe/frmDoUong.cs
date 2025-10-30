﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class frmDoUong: Form
    {
        public string? SelectedMaDU { get; set; }
        public frmDoUong()
        {
            InitializeComponent();
        }

        // Constructor mới để nhận mã đồ uống từ form chính
        public frmDoUong(string maDU) : this()
        {
            this.SelectedMaDU = maDU;
        }

        private void txtDonGia_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void LoadData()
        {
            string strSQl = "SELECT MaDU, TenDU, MaLoai, DonGia, SoLuongTon, NguongCanhBao, HinhAnh FROM DoUong WHERE TenDU LIKE @TenDU";
            string searchText = txtSearch?.Text ?? string.Empty; // Kiểm tra null cho txtSearch
            var parameters = new Dictionary<string, object>
            {
                { "@TenDU", $"%{searchText}%" }
            };

            dtgvData.DataSource = ConnectSQL.Load(strSQl, parameters);
            frmNhanVien.SetupDataGridView(dtgvData);
            dtgvData.Columns[0].HeaderText = "Mã đồ uống";
            dtgvData.Columns[1].HeaderText = "Tên đồ uống";
            dtgvData.Columns[2].HeaderText = "Mã loại";
            dtgvData.Columns[3].HeaderText = "Đơn giá";
            dtgvData.Columns[4].HeaderText = "Tồn kho";
            dtgvData.Columns[5].Visible = true; // Hiện cột ngưỡng cảnh báo
            dtgvData.Columns[5].HeaderText = "Ngưỡng C.Báo";
            dtgvData.Columns[6].Visible = false; // Ẩn cột hình ảnh
            dtgvData.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dtgvData.Rows.Count == 0)
            {
                txtMaDU.Text = "";
                txtTenDU.Text = "";
                txtDonGia.Text = "";
                picHinhAnh.Image = null;
                txtSoLuongTon.Text = "0";
                nmNguongCanhBao.Value = 0; // Đặt giá trị về 0
                nmNguongCanhBao.Text = "";  // Xóa văn bản hiển thị
            }
            else if (!string.IsNullOrEmpty(SelectedMaDU))
            {
                // Tìm và chọn dòng có mã đồ uống được truyền vào
                foreach (DataGridViewRow row in dtgvData.Rows)
                {
                    if (row.Cells["MaDU"].Value?.ToString() == SelectedMaDU)
                    {
                        dtgvData.CurrentCell = row.Cells[0]; // Chọn dòng này
                        DisplayRowData(row); // Hiển thị dữ liệu của dòng được chọn
                        break; // Dừng vòng lặp khi đã tìm thấy
                    }
                }
            }
            else
            {
                // Nếu không có mã nào được truyền, chỉ cần chọn dòng đầu tiên.
                // Sự kiện CellClick sẽ tự động được kích hoạt để hiển thị dữ liệu.
                if (dtgvData.Rows.Count > 0)
                {
                    dtgvData.CurrentCell = dtgvData.Rows[0].Cells[0];
                    DisplayRowData(dtgvData.Rows[0]); // Gọi trực tiếp để đảm bảo hiển thị ngay lập tức
                }
            }
        }
        private void DisplayRowData(DataGridViewRow row)
        {
            if (row == null) return;

            txtMaDU.Text = row.Cells["MaDU"].Value?.ToString() ?? string.Empty;
            txtTenDU.Text = row.Cells["TenDU"].Value?.ToString() ?? string.Empty;
            cboMaLoai.SelectedValue = row.Cells["MaLoai"].Value?.ToString() ?? string.Empty;
            txtDonGia.Text = row.Cells["DonGia"].Value?.ToString() ?? string.Empty;
            txtSoLuongTon.Text = row.Cells["SoLuongTon"].Value?.ToString() ?? string.Empty;
            // Lấy ngưỡng cảnh báo, nếu null thì mặc định là 0
            if (row.Cells["NguongCanhBao"].Value != DBNull.Value)
            {
                // Sử dụng Convert.ToDecimal để xử lý chính xác các kiểu số khác nhau
                nmNguongCanhBao.Value = Convert.ToDecimal(row.Cells["NguongCanhBao"].Value);
            }
            else
            {
                nmNguongCanhBao.Value = 0;
                nmNguongCanhBao.Text = ""; // Xóa văn bản nếu giá trị là 0
            }

            string? result = row.Cells["HinhAnh"].Value?.ToString();
            if (!string.IsNullOrEmpty(result) && result != DBNull.Value.ToString())
            {
                picHinhAnh.Image = Base64ToImage(result);
            }
            else
            {
                picHinhAnh.Image = null;
            }
        }
        private void frmDoUong_Load(object? sender, EventArgs e)
        {
            LoadData();
            LoadComboboxLoaiDoUong();
            dtgvData.CellFormatting += dtgvData_CellFormatting;
        }
        private void LoadComboboxLoaiDoUong()
        {
            string strSQL = "SELECT * FROM LoaiDoUong";
            DataTable dt = new DataTable();
            dt = ConnectSQL.Load(strSQL);
            cboMaLoai.DataSource = dt;
            cboMaLoai.DisplayMember = "TenLoai";
            cboMaLoai.ValueMember = "MaLoai";
        }

        private void menuThem_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDU.Text))
            {
                MessageBox.Show("Chưa nhập mã đồ uống");
                txtMaDU.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTenDU.Text))
            {
                MessageBox.Show("Chưa nhập tên đồ uống");
                txtTenDU.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDonGia.Text))
            {
                MessageBox.Show("Chưa nhập đơn giá");
                txtDonGia.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cboMaLoai.Text))
            {
                MessageBox.Show("Chưa nhập mã loại đồ uống");
                cboMaLoai.Focus();
                return;
            }

            string sqlCheck = "SELECT MaDU FROM DoUong WHERE MaDU = @MaDU";
            var paramCheck = new Dictionary<string, object> { { "@MaDU", txtMaDU.Text } };
            if (ConnectSQL.ExcuteReader_bool(sqlCheck, paramCheck))
            {
                MessageBox.Show("Mã đồ uống này đã tồn tại, vui lòng tạo mã khác");
                txtMaDU.Focus();
                return;
            }

            string sqlInsert = "INSERT INTO DoUong(MaDU, TenDU, MaLoai, DonGia, SoLuongTon, NguongCanhBao) VALUES (@MaDU, @TenDU, @MaLoai, @DonGia, @SoLuongTon, @NguongCanhBao)";
            var paramInsert = new Dictionary<string, object>
            {
                { "@MaDU", txtMaDU.Text },
                { "@TenDU", txtTenDU.Text },
                { "@MaLoai", cboMaLoai.SelectedValue! },
                { "@DonGia", decimal.Parse(txtDonGia.Text) },
                { "@SoLuongTon", int.Parse(txtSoLuongTon.Text) },
                { "@NguongCanhBao", nmNguongCanhBao.Value }
            };

            ConnectSQL.RunQuery(sqlInsert, paramInsert);
            MessageBox.Show("Thêm thành công");
            LoadData();
        }

        private void menuSua_Click(object? sender, EventArgs e)
        {
            // Buộc control mất focus và xác thực dữ liệu đang chờ xử lý trên DataGridView
            this.Validate();

            if (dtgvData.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đồ uống để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtMaDU.Text))
            {
                MessageBox.Show("Chưa nhập mã đồ uống");
                txtMaDU.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTenDU.Text))
            {
                MessageBox.Show("Chưa nhập tên đồ uống");
                txtTenDU.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDonGia.Text))
            {
                MessageBox.Show("Chưa nhập đơn giá");
                txtDonGia.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cboMaLoai.Text))
            {
                MessageBox.Show("Chưa nhập mã loại đồ uống");
                cboMaLoai.Focus();
                return;
            }

            string MaDUSua = dtgvData.CurrentRow.Cells[0].Value.ToString()!.Trim();
            if (txtMaDU.Text.Trim() != MaDUSua)
            {
                string sqlCheck = "SELECT MaDU FROM DoUong WHERE MaDU = @MaDU";
                var paramCheck = new Dictionary<string, object> { { "@MaDU", txtMaDU.Text.Trim() } };
                if (ConnectSQL.ExcuteReader_bool(sqlCheck, paramCheck))
                {
                    MessageBox.Show("Mã đồ uống này đã tồn tại, vui lòng tạo mã khác");
                    txtMaDU.Focus();
                    return;
                }
            }

            string strSQL = "UPDATE DoUong SET MaDU = @MaDU, TenDU = @TenDU, MaLoai = @MaLoai, DonGia = @DonGia, SoLuongTon = @SoLuongTon, NguongCanhBao = @NguongCanhBao WHERE MaDU = @MaDUSua";
            var parameters = new Dictionary<string, object> {
                { "@MaDU", txtMaDU.Text }, { "@TenDU", txtTenDU.Text }, { "@MaLoai", cboMaLoai.SelectedValue! },
                { "@DonGia", decimal.Parse(txtDonGia.Text) }, 
                // Sửa lỗi: Lấy giá trị từ ô txtSoLuongTon.Text thay vì txtDonGia.Text
                { "@SoLuongTon", int.Parse(txtSoLuongTon.Text) },
                { "@NguongCanhBao", nmNguongCanhBao.Value }, 
                { "@MaDUSua", MaDUSua }
            };
            ConnectSQL.RunQuery(strSQL, parameters);
            MessageBox.Show("Sửa thành công");
            LoadData();
        }

        private void dtgvData_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvData.Rows[e.RowIndex];
                DisplayRowData(row);
            }
        }

        private void dtgvData_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Lấy giá trị tồn kho và ngưỡng cảnh báo một cách an toàn
            object soLuongTonObj = dtgvData.Rows[e.RowIndex].Cells["SoLuongTon"].Value;
            object nguongCanhBaoObj = dtgvData.Rows[e.RowIndex].Cells["NguongCanhBao"].Value;

            int soLuongTon = (soLuongTonObj != DBNull.Value) ? Convert.ToInt32(soLuongTonObj) : 0;
            int nguongCanhBao = (nguongCanhBaoObj != DBNull.Value) ? Convert.ToInt32(nguongCanhBaoObj) : 0;

            // Nếu tồn kho thấp hơn hoặc bằng ngưỡng (và ngưỡng > 0), tô màu đỏ nhạt
            if (nguongCanhBao > 0 && soLuongTon <= nguongCanhBao)
            {
                e.CellStyle.BackColor = Color.LightCoral;
                e.CellStyle.SelectionBackColor = Color.DarkRed;
            }
        }

        public Image Base64ToImage(string base64String)
        {
            // Chuyển chuỗi base64 thành mảng byte
            byte[] imageBytes = Convert.FromBase64String(base64String);

            // Tạo stream từ byte
            using (var ms = new MemoryStream(imageBytes))
            {
                // Chuyển stream thành hình ảnh
                return Image.FromStream(ms);
            }
        }
        private void menuXoa_Click(object? sender, EventArgs e)
        {
            if (dtgvData.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đồ uống để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string maDU = dtgvData.CurrentRow.Cells[0].Value?.ToString()?.Trim() ?? string.Empty;
                string strSQL = "DELETE FROM DoUong WHERE MaDU = @MaDU";
                var parameters = new Dictionary<string, object> { { "@MaDU", maDU! } };
                ConnectSQL.RunQuery(strSQL, parameters);
                MessageBox.Show("Xóa thành công");
                LoadData();
            }
        }

        private void menuXoaTrang_Click(object? sender, EventArgs e)
        {
            if (txtMaDU != null) txtMaDU.Text = "";
            if (txtTenDU != null) txtTenDU.Text = "";
            if (txtDonGia != null) txtDonGia.Text = "";
            if (txtSoLuongTon != null) txtSoLuongTon.Text = "0";
            nmNguongCanhBao.Value = 0;
            nmNguongCanhBao.Text = "";
        }

        private void menuThoat_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void menuTimKiem_Click(object? sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThemHinh_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dtgvData.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đồ uống để thêm hình.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(picHinhAnh.Image == null) //Kiểm tra xem có dữ liệu để thêm hình chưa
            {
                //Mở hộp thoại lên để chọn hình
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Chọn ảnh";
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Lấy tên của hình
                        string imagePath = openFileDialog.FileName;
                        //Hiển thị hinh lên picturebox
                        picHinhAnh.Image = Image.FromFile(imagePath);
                        //convert hình sang base64
                        string base64String = ConvertImageToBase64(picHinhAnh.Image);
                        //Tiến hình cập nhật vào SQL
                        string maDU = dtgvData.CurrentRow.Cells[0].Value.ToString()!.Trim();
                        string strSQL = "UPDATE DoUong SET HinhAnh = @HinhAnh WHERE MaDU = @MaDU";
                        var parameters = new Dictionary<string, object> {
                            { "@HinhAnh", base64String }, { "@MaDU", maDU }
                        };
                        ConnectSQL.RunQuery(strSQL, parameters);
                        MessageBox.Show("Thêm hình thành công");
                        LoadData();
                    }
                }
            }   
            else
            {
                MessageBox.Show("Đồ uống đã có hình, nếu muốn sửa, hãy xóa hình và thêm lại hình khác");
                return;
            }    
        }
        private string ConvertImageToBase64(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }

        private void btnXoaHinh_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dtgvData.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đồ uống để xóa hình.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string maDU = dtgvData.CurrentRow.Cells[0].Value.ToString()!.Trim();
                string strSQL = "UPDATE DoUong SET HinhAnh = NULL WHERE MaDU = @MaDU";
                var parameters = new Dictionary<string, object> { { "@MaDU", maDU } };
                ConnectSQL.RunQuery(strSQL, parameters);
                picHinhAnh.Image = null;
                MessageBox.Show("Xóa thành công");
                LoadData();
            }
        }

        private void nmNguongCanhBao_Enter(object? sender, EventArgs e)
        {
            // Khi người dùng focus vào ô, chọn toàn bộ nội dung
            // để có thể dễ dàng nhập giá trị mới.
            if (sender is NumericUpDown numericUpDown)
            {
                // Nếu ô đang trống, không cần chọn gì cả
                if (!string.IsNullOrEmpty(numericUpDown.Text))
                {
                    numericUpDown.Select(0, numericUpDown.Text.Length);
                }
            }
        }
    }
}
