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
    public partial class frmThanhToan: Form
    {
        public frmThanhToan()
        {
            InitializeComponent();

        }
        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string strSQl = $@"SELECT * FROM KhachHang WHERE TenKH LIKE N'%{txtTenKH.Text}%'
                                AND SDT LIKE N'%{txtSDT.Text}%' AND DiaChi LIKE N'%{txtDiaChi.Text}%'";
            dtgvData.DataSource = ConnectSQL.Load(strSQl);
            frmNhanVien.SetupDataGridView(dtgvData);
            dtgvData.Columns[0].HeaderText = "Mã KH";
            dtgvData.Columns[1].HeaderText = "Tên KH";
            dtgvData.Columns[2].HeaderText = "SĐT";
            dtgvData.Columns[3].HeaderText = "Địa chỉ";
        }

        private void menuTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenKH.Text))
            {
                MessageBox.Show("Chưa nhập tên kh");
                txtTenKH.Focus();
                return;
            }
            string MaKH = DateTime.Now.ToString("mmsshhddMMyyyy");
            string strSQL = $@"INSERT INTO KhachHang(MaKH,TenKH,SDT,DiaChi)
                        VALUES ('{MaKH}',N'{txtTenKH.Text}','{txtSDT.Text}',N'{txtDiaChi.Text}')";
            ConnectSQL.RunQuery(strSQL);
            MessageBox.Show("Thêm thành công");
            LoadData();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dtgvData.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để thanh toán");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn thanh toán hay không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string strSQL = $@"UPDATE HoaDon SET TrangThai = 1
                                                    ,MaKH = '{dtgvData.CurrentRow.Cells["MaKH"].Value.ToString().Trim()}' 
                                                    ,TongTien = {frmManHinhChinh.TongTienThanhToan}
                                                    WHERE MaHD = '{frmManHinhChinh.MaHDThanhToan}'";
                strSQL += $@" UPDATE Ban SET TrangThai = 0 WHERE MaBan = '{frmManHinhChinh.MaBanThanhToan}'";
                ConnectSQL.RunQuery(strSQL);
                MessageBox.Show("Thanh toán thành công");
                frmInHoaDon frm = new frmInHoaDon();
                frm.ShowDialog();
            }
            this.Close();
        }
    }
}
