﻿﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    [SupportedOSPlatform("windows")]
    public partial class frmDoiMatKhau: Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            //Kiểm tra mật khẩu cũ có trùng khớp không
            if(txtMatKhauCu.Text != frmDangNhap.MatKhau)
            {
                MessageBox.Show("Mật khẩu cũ không trùng khớp");
                txtMatKhauCu.Focus();
                return;
            }    
            //Kiểm tra mật khẩu mới bắt buộc nhập
            if(string.IsNullOrEmpty(txtMatKhauMoi.Text))
            {
                MessageBox.Show("Mật khẩu mới không được trống");
                txtMatKhauMoi.Focus();
                return;
            }    
            //Kiểm tra nhập lại mật khẩu có khớp không
            if(txtMatKhauMoi.Text != txtXacNhanMatKhau.Text)
            {
                MessageBox.Show("Nhập lại mật khẩu không khớp");
                txtXacNhanMatKhau.Focus();
                return;
            }
            string strSQL = "UPDATE NhanVien SET MatKhau = @MatKhauMoi WHERE MaNV = @MaNV";
            var parameters = new Dictionary<string, object>
            {
                { "@MatKhauMoi", txtMatKhauMoi.Text },
                { "@MaNV", frmDangNhap.MaNV! } // Sử dụng ! để báo cho compiler rằng MaNV không null ở đây
            };

            ConnectSQL.RunQuery(strSQL, parameters);
            MessageBox.Show("Đổi mật khẩu thành công");
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Hiệu ứng hover cho nút "Đổi mật khẩu"
        private void btnDoiMatKhau_MouseEnter(object sender, EventArgs e)
        {
            btnDoiMatKhau.BackColor = Color.FromArgb(109, 76, 65); // #6D4C41
        }

        private void btnDoiMatKhau_MouseLeave(object sender, EventArgs e)
        {
            btnDoiMatKhau.BackColor = Color.FromArgb(90, 59, 46); // #5A3B2E
        }

        // Hiệu ứng hover cho nút "Thoát"
        private void btnThoat_MouseEnter(object sender, EventArgs e)
        {
            btnThoat.BackColor = Color.FromArgb(161, 136, 127); // #A1887F
        }

        private void btnThoat_MouseLeave(object sender, EventArgs e)
        {
            btnThoat.BackColor = Color.FromArgb(188, 170, 164); // #BCAAA4
        }
    }
}
