using System;
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

            // Hàm trợ giúp để định dạng RichTextBox
            void SetRichText(RichTextBox rtb, string label, string value)
            {
                rtb.Text = $"{label} {value}";
                rtb.Select(0, label.Length);
                rtb.SelectionFont = new Font(rtb.Font, FontStyle.Bold);
                rtb.DeselectAll();
            }

            // Gán thông tin hóa đơn
            SetRichText(rtbCustomer, "Khách hàng:", _hoaDonInfo["TenKH"]);
            SetRichText(rtbStaff, "Người lập:", _hoaDonInfo["NguoiLap"]);
            SetRichText(rtbDate, "Thời gian tạo:", _hoaDonInfo["NgayLap"]);
            SetRichText(rtbPaymentDate, "Thời gian thanh toán:", _hoaDonInfo["NgayThanhToan"]);
            lblTotalAmount.Text = $"{decimal.Parse(_hoaDonInfo["TongTien"]):N0} VNĐ";

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
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            // Vẽ logo chìm vào giữa panel
            if (_watermarkLogo != null)
            {
                int x = (pnlMain.Width - _watermarkLogo.Width) / 2;
                int y = (pnlMain.Height - _watermarkLogo.Height) / 2;
                e.Graphics.DrawImage(_watermarkLogo, x, y, _watermarkLogo.Width, _watermarkLogo.Height);
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