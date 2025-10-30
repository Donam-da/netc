﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Versioning;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace QuanLyCafe
{
    [SupportedOSPlatform("windows")]
    public partial class frmDangNhap: Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        // Các biến để xử lý việc di chuyển form không viền
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        // Các chuỗi placeholder
        private const string USERNAME_PLACEHOLDER = "Tên đăng nhập";
        private const string PASSWORD_PLACEHOLDER = "Mật khẩu";
        public static string? MatKhau;
        public static string? MaNV;
        public static string? Quyen;
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDangNhap.Text))
            {
                MessageBox.Show("Chưa nhập thông tin mã đăng nhập");
                txtMaDangNhap.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Chưa nhập thông tin mật khẩu");
                txtMaDangNhap.Focus();
                return;
            }
            // Kiểm tra nếu người dùng chưa nhập gì (vẫn là placeholder)
            if (txtMaDangNhap.Text == USERNAME_PLACEHOLDER)
            {
                MessageBox.Show("Chưa nhập thông tin mã đăng nhập");
                txtMaDangNhap.Focus();
                return;
            }

            string strSQL = "SELECT MaNV, MatKhau, Quyen FROM NhanVien WHERE MaNV = @MaNV AND MatKhau = @MatKhau";
            var parameters = new Dictionary<string, object>
            {
                { "@MaNV", txtMaDangNhap.Text.Trim() },
                { "@MatKhau", txtMatKhau.Text }
            };

            DataTable dt = ConnectSQL.Load(strSQL, parameters);

            if (dt.Rows.Count > 0)
            {
                MaNV = txtMaDangNhap.Text.Trim();
                MatKhau = txtMatKhau.Text;
                Quyen = dt.Rows[0]["Quyen"]?.ToString();

                this.Hide(); // Ẩn form đăng nhập
                frmManHinhChinh frm = new frmManHinhChinh();
                frm.FormClosed += (s, args) => this.Close(); // Đóng form đăng nhập khi form chính đóng
                frm.Show(); // Hiển thị form chính
            }
            else
            {
                MessageBox.Show("Sai thông tin mã đăng nhập hoặc mật khẩu");
                txtMaDangNhap.Focus();
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            // Gán sự kiện di chuyển cho các panel
            AddDragEvents(this.pnlLeft);
            AddDragEvents(this.pnlRight);

            // --- BẮT ĐẦU ĐOẠN MÃ CẬP NHẬT ---
            // Tự động tải logo từ thư mục Images của ứng dụng
            try
            {
                // Đường dẫn tương đối đến file logo trong thư mục build (bin/Debug)
                string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "logo.png");

                if (File.Exists(logoPath))
                {
                    // Tải ảnh từ file
                    picLogo.Image = Image.FromFile(logoPath);
                }
                else
                {
                    // (Tùy chọn) Xử lý nếu không tìm thấy file logo
                    // Ví dụ: picLogo.Image = default_image_resource;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra khi tải ảnh logo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // --- KẾT THÚC ĐOẠN MÃ CẬP NHẬT ---

            // Thiết lập placeholder ban đầu
            SetupPlaceholder();

            // --- LÀM TRONG SUỐT NỀN TEXTBOX ---
            // Đặt control cha cho textbox là panel chứa nó
            txtMaDangNhap.Parent = pnlUsername;
            txtMatKhau.Parent = pnlPassword;
        }

        // =================== CÁC HÀM HỖ TRỢ ===================

        private void AddDragEvents(Control control)
        {
            control.MouseDown += Form_MouseDown;
            control.MouseMove += Form_MouseMove;
            control.MouseUp += Form_MouseUp;
            foreach (Control child in control.Controls)
            {
                AddDragEvents(child);
            }
        }

        private void Form_MouseDown(object? sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form_MouseMove(object? sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void Form_MouseUp(object? sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void SetupPlaceholder()
        {
            // Gán sự kiện cho các textbox
            txtMaDangNhap.Enter += TxtMaDangNhap_Enter;
            txtMaDangNhap.Leave += TxtMaDangNhap_Leave;
            txtMatKhau.Enter += TxtMatKhau_Enter;
            txtMatKhau.Leave += TxtMatKhau_Leave;

            // Gọi sự kiện Leave để thiết lập trạng thái ban đầu
            TxtMaDangNhap_Leave(txtMaDangNhap, EventArgs.Empty);
            TxtMatKhau_Leave(txtMatKhau, EventArgs.Empty);
        }

        private void TxtMaDangNhap_Enter(object? sender, EventArgs e)
        {
            if (txtMaDangNhap.Text == USERNAME_PLACEHOLDER)
            {
                txtMaDangNhap.Text = "";
                txtMaDangNhap.ForeColor = SystemColors.WindowText;
            }
        }

        private void TxtMaDangNhap_Leave(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDangNhap.Text))
            {
                txtMaDangNhap.Text = USERNAME_PLACEHOLDER;
                txtMaDangNhap.ForeColor = SystemColors.GrayText;
            }
        }

        private void TxtMatKhau_Enter(object? sender, EventArgs e)
        {
            if (txtMatKhau.Text == PASSWORD_PLACEHOLDER)
            {
                txtMatKhau.Text = "";
                txtMatKhau.ForeColor = SystemColors.WindowText;
                txtMatKhau.PasswordChar = '●';
            }
        }

        private void TxtMatKhau_Leave(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                txtMatKhau.Text = PASSWORD_PLACEHOLDER;
                txtMatKhau.ForeColor = SystemColors.GrayText;
                txtMatKhau.PasswordChar = '\0'; // Hiện chữ placeholder
            }
        }

        private void picShowPass_Click(object? sender, EventArgs e)
        {
            if (txtMatKhau.Text != PASSWORD_PLACEHOLDER)
            {
                // Nếu đang là dạng password, chuyển thành dạng text và ngược lại
                if (txtMatKhau.PasswordChar == '●')
                {
                    txtMatKhau.PasswordChar = '\0'; // '\0' là ký tự null, sẽ hiển thị text bình thường
                }
                else
                {
                    txtMatKhau.PasswordChar = '●';
                }
            }
        }
    }
}
