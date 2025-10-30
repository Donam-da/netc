﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
            // Gán thông tin hóa đơn
            lblCustomer.Text = "Khách hàng: " + _hoaDonInfo["TenKH"];
            lblStaff.Text = "Người lập: " + _hoaDonInfo["NguoiLap"];
            lblDate.Text = "Thời gian tạo: " + _hoaDonInfo["NgayLap"];
            lblPaymentDate.Text = "Thời gian thanh toán: " + _hoaDonInfo["NgayThanhToan"];
            lblTotalAmount.Text = $"{decimal.Parse(_hoaDonInfo["TongTien"]):N0} VNĐ";

            // Gán dữ liệu chi tiết
            dtgvDetails.DataSource = _dtDetail;

            // Tùy chỉnh DataGridView
            frmNhanVien.SetupDataGridView(dtgvDetails);
            dtgvDetails.Columns["TenDU"].HeaderText = "Tên đồ uống";
            dtgvDetails.Columns["SoLuong"].HeaderText = "SL";
            dtgvDetails.Columns["DonGia"].HeaderText = "Đơn giá";
            dtgvDetails.Columns["ThanhTien"].HeaderText = "Thành tiền";

            dtgvDetails.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvDetails.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dtgvDetails.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }
    }
}