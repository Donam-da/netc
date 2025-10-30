using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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

        public frmHienThiHoaDon(DataTable dtDetail, Dictionary<string, string> hoaDonInfo)
        {
            InitializeComponent();
            _dtDetail = dtDetail;
            _hoaDonInfo = hoaDonInfo;
        }

        private void frmHienThiHoaDon_Load(object sender, EventArgs e)
        {
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
    }
}