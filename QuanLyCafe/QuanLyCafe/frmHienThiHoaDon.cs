﻿﻿﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace QuanLyCafe
{
    [SupportedOSPlatform("windows")]
    public partial class frmHienThiHoaDon : Form
    {
        private readonly DataTable _dtDetail;
        private readonly Dictionary<string, string> _hoaDonInfo;
        private Image? _watermarkLogo = null;
        private int _firstDisplayedRow = 0;
        private const int MaxVisibleRows = 5; // Số dòng tối đa hiển thị trước khi có thanh cuộn


        public frmHienThiHoaDon(DataTable dtDetail, Dictionary<string, string> hoaDonInfo)
        {
            InitializeComponent();
            _dtDetail = dtDetail;
            _hoaDonInfo = hoaDonInfo;
        }

        private void frmHienThiHoaDon_Load(object sender, EventArgs e)
        {
            // Tải logo và chuẩn bị để vẽ
            try
            {
                string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "logo.png");
                if (File.Exists(logoPath))
                {
                    _watermarkLogo = SetImageOpacity(Image.FromFile(logoPath), 0.1f); // 10% độ mờ
                }
            }
            catch { /* Bỏ qua nếu có lỗi tải logo */ }

            // Gán dữ liệu chi tiết
            dtgvDetails.DataSource = _dtDetail;

            // Tùy chỉnh DataGridView
            frmNhanVien.SetupDataGridView(dtgvDetails);
            
            dtgvDetails.Columns["TenDU"].HeaderText = "Tên đồ uống";
            dtgvDetails.Columns["SoLuong"].HeaderText = "SL";
            dtgvDetails.Columns["DonGia"].HeaderText = "Đơn giá";
            dtgvDetails.Columns["ThanhTien"].HeaderText = "Thành tiền";

            // Tùy chỉnh độ rộng cột
            dtgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dtgvDetails.Columns["TenDU"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgvDetails.Columns["SoLuong"].Width = 40;
            dtgvDetails.Columns["DonGia"].Width = 80;
            dtgvDetails.Columns["ThanhTien"].Width = 110;

            dtgvDetails.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvDetails.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvDetails.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dtgvDetails.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

            // Cấu hình thanh cuộn nếu cần
            if (dtgvDetails.Rows.Count > MaxVisibleRows)
            {
                vScrollBar.Visible = true;
                vScrollBar.Minimum = 0;
                // Maximum là chỉ số dòng đầu tiên có thể cuộn tới
                vScrollBar.Maximum = dtgvDetails.Rows.Count - MaxVisibleRows;
                vScrollBar.LargeChange = 1; // Cuộn một lần một dòng
            }
            else
            {
                vScrollBar.Visible = false;
            }
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; // Lấy đối tượng Graphics để vẽ
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; // Bật khử răng cưa

            // Vẽ logo chìm vào giữa panel
            if (_watermarkLogo != null)
            {
                // --- BẠN CÓ THỂ CHỈNH SỬA KÍCH THƯỚC LOGO Ở ĐÂY ---
                int logoWidth = 470; // Chiều rộng mong muốn
                int logoHeight = 470; // Chiều cao mong muốn

                int x = (pnlMain.Width - logoWidth) / 2;
                int y = (pnlMain.Height - logoHeight) / 2;
                g.DrawImage(_watermarkLogo, x, y, logoWidth, logoHeight);
            }

            // Vẽ một lớp nền trắng mờ cho header để chữ không bị logo đè
            using (SolidBrush headerBrush = new SolidBrush(Color.FromArgb(200, 255, 255, 255))) // Màu trắng với độ trong suốt
            {
                g.FillRectangle(headerBrush, new Rectangle(0, 0, pnlMain.Width, 85));
            }
            // --- Vẽ thông tin hóa đơn ---
            Font boldFont = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            Font regularFont = new Font("Segoe UI", 9.75F, FontStyle.Regular);
            Brush textBrush = new SolidBrush(Color.FromArgb(90, 59, 46));
            int startY = 115; // Vị trí bắt đầu vẽ
            int lineSpacing = 25; // Khoảng cách giữa các dòng

            // Hàm trợ giúp để vẽ một dòng thông tin
            void DrawInfoLine(string label, string value, int yPos)
            {
                g.DrawString(label, boldFont, textBrush, new PointF(17, yPos));
                // Đo kích thước của label để vẽ value ngay sau đó
                SizeF labelSize = g.MeasureString(label, boldFont);
                g.DrawString(value, regularFont, textBrush, new PointF(17 + labelSize.Width, yPos));
            }

            DrawInfoLine("Khách hàng: ", _hoaDonInfo["TenKH"], startY);
            DrawInfoLine("Người lập: ", _hoaDonInfo["NguoiLap"], startY + lineSpacing);
            DrawInfoLine("Thời gian tạo: ", _hoaDonInfo["NgayLap"], startY + lineSpacing * 2);
            DrawInfoLine("Thời gian thanh toán: ", _hoaDonInfo["NgayThanhToan"], startY + lineSpacing * 3);

            // --- Vẽ bảng chi tiết hóa đơn ---
            int tableY = 225; // Vị trí bắt đầu của bảng
            int headerHeight = 30;
            int rowHeight = 25;

            // Vẽ header
            g.FillRectangle(new SolidBrush(dtgvDetails.ColumnHeadersDefaultCellStyle.BackColor), 17, tableY, dtgvDetails.Width, headerHeight);
            int currentX = 17;
            for (int i = 0; i < dtgvDetails.Columns.Count; i++)
            {
                TextRenderer.DrawText(g, dtgvDetails.Columns[i].HeaderText, dtgvDetails.ColumnHeadersDefaultCellStyle.Font,
                    new Rectangle(currentX, tableY, dtgvDetails.Columns[i].Width, headerHeight), // Corrected from dtgvDetails.Columns[i].Width
                    dtgvDetails.ColumnHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                currentX += dtgvDetails.Columns[i].Width;
            }

            // Vẽ các dòng dữ liệu
            int currentY = tableY + headerHeight;
            int rowsToDraw = Math.Min(dtgvDetails.Rows.Count - _firstDisplayedRow, MaxVisibleRows);

            for (int rowIndex = 0; rowIndex < rowsToDraw; rowIndex++)
            {
                DataGridViewRow row = dtgvDetails.Rows[_firstDisplayedRow + rowIndex];
                currentX = 17;
                for (int i = 0; i < dtgvDetails.Columns.Count; i++)
                {
                    string cellValue = row.Cells[i].FormattedValue.ToString() ?? "";
                    TextRenderer.DrawText(g, cellValue, dtgvDetails.DefaultCellStyle.Font,
                        new Rectangle(currentX, currentY + (rowIndex * rowHeight), dtgvDetails.Columns[i].Width, rowHeight),
                        dtgvDetails.DefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                    currentX += dtgvDetails.Columns[i].Width;
                }
            }

            // Tính toán vị trí cuối cùng của bảng
            int tableEndY = tableY + headerHeight + (rowsToDraw * rowHeight);

            // --- Vẽ phần tổng tiền ---
            int summaryY = tableEndY + 15; // Vị trí bắt đầu của phần tổng kết
            Font totalFont = new Font("Segoe UI", 12F, FontStyle.Bold);
            Font summaryFont = new Font("Segoe UI", 9.75F, FontStyle.Regular);

            // Hàm trợ giúp để vẽ các dòng trong phần tổng kết
            void DrawSummaryLine(string label, string value, int yPos, Font font, Color color)
            {
                TextRenderer.DrawText(g, label, font, new Rectangle(17, yPos, 100, 30), ((SolidBrush)textBrush).Color, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
                TextRenderer.DrawText(g, value, font, new Rectangle(220, yPos, 110, 30), color, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
            }

            DrawSummaryLine("Tổng tiền hàng:", $"{_hoaDonInfo["TongTienHang"]} VNĐ", summaryY, summaryFont, ((SolidBrush)textBrush).Color);

            // Chỉ vẽ dòng giảm giá nếu có
            if (decimal.Parse(_hoaDonInfo["GiamGia"]) > 0)
            {
                summaryY += 25;
                DrawSummaryLine($"Giảm giá ({_hoaDonInfo["PhanTramGiamGia"]}%):", $"- {_hoaDonInfo["GiamGia"]} VNĐ", summaryY, summaryFont, Color.Green);
            }

            // Vẽ đường kẻ ngang
            summaryY += 30;
            g.DrawLine(new Pen(Color.Gray, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash }, 17, summaryY, pnlMain.Width - 17, summaryY);

            summaryY += 5;
            DrawSummaryLine("TỔNG CỘNG:", $"{_hoaDonInfo["TongCong"]} VNĐ", summaryY, totalFont, Color.FromArgb(192, 57, 43));

            // --- Vẽ lời cảm ơn ---
            using (StringFormat sfRight = new StringFormat())
            {
                sfRight.Alignment = StringAlignment.Center;
                sfRight.LineAlignment = StringAlignment.Center;
                g.DrawString("Cảm ơn quý khách!", new Font("Segoe UI", 9.75F, FontStyle.Italic), textBrush, new Rectangle(0, summaryY + 40, pnlMain.Width, 30), sfRight);
            }
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            _firstDisplayedRow = e.NewValue;
            pnlMain.Invalidate(); // Yêu cầu vẽ lại panel
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận thanh toán hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Lấy thông tin cần thiết từ dictionary
                    string maHD = _hoaDonInfo["MaHD"];
                    string maKH = _hoaDonInfo["MaKH"];
                    string maBan = _hoaDonInfo["MaBan"];
                    decimal finalTotal = decimal.Parse(_hoaDonInfo["FinalTotal"]);
                    decimal discountAmount = decimal.Parse(_hoaDonInfo["DiscountAmount"]);

                    // Cập nhật hóa đơn
                    string sqlUpdateHD = "UPDATE HoaDon SET TrangThai = 1, MaKH = @MaKH, TongTien = @TongTien, GiamGia = @GiamGia WHERE MaHD = @MaHD";
                    var paramUpdateHD = new Dictionary<string, object>
                    {
                        { "@MaKH", maKH }, { "@TongTien", finalTotal }, { "@GiamGia", discountAmount }, { "@MaHD", maHD }
                    };
                    ConnectSQL.RunQuery(sqlUpdateHD, paramUpdateHD);

                    // Cập nhật bàn
                    string sqlUpdateBan = "UPDATE Ban SET TrangThai = 0 WHERE MaBan = @MaBan";
                    ConnectSQL.RunQuery(sqlUpdateBan, new Dictionary<string, object> { { "@MaBan", maBan } });

                    this.DialogResult = DialogResult.OK; // Báo hiệu thanh toán thành công
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        /// <summary>
        /// Tạo một bản sao của hình ảnh với độ mờ được chỉ định.
        /// </summary>
        /// <param name="image">Hình ảnh gốc.</param>
        /// <param name="opacity">Độ mờ, từ 0.0 (trong suốt) đến 1.0 (rõ nét).</param>
        /// <returns>Một hình ảnh mới đã được làm mờ.</returns>
        private Image SetImageOpacity(Image image, float opacity)
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity; // Thiết lập độ mờ

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                g.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height),
                                   0, 0, image.Width, image.Height,
                                   GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }
    }
}