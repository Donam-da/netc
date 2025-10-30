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
    public partial class frmLichSuHoaDon: Form
    {
        public frmLichSuHoaDon()
        {
            InitializeComponent();
        }
        private void LoadDataHoaDon()
        {
            string strSQl = $@"SELECT a.MaHD,a.NgayLap,b.TenNV,c.TenKH,a.MaBan,a.TongTien,a.TrangThai
                               FROM HoaDon a INNER JOIN NhanVien b ON a.MaNV = b.MaNV
                                             INNER JOIN KhachHang c ON a.MaKH = c.MaKH
                                WHERE NgayLap BETWEEN '{dtDFrom.Value.ToString("yyyyMMdd")}'
                                              AND '{dtDTo.Value.ToString("yyyyMMdd")}'";
            DataTable dt = new DataTable();
            dt = ConnectSQL.Load(strSQl);
            dtgvHD.DataSource = dt;
            frmNhanVien.SetupDataGridView(dtgvHD);
            dtgvHD.Columns[0].HeaderText = "Mã hóa đơn";
            dtgvHD.Columns[1].HeaderText = "Ngày lập";
            dtgvHD.Columns[2].HeaderText = "Tên nhân viên";
            dtgvHD.Columns[3].HeaderText = "Tên khách hàng";
            dtgvHD.Columns[4].HeaderText = "Mã bàn";   
            dtgvHD.Columns[5].HeaderText = "Tổng tiền";
            dtgvHD.Columns[6].HeaderText = "Trạng thái";
            if (dtgvHD.Rows.Count == 0)
            {
                LoadDataChiTietHoaDon("");
            }
            else
            {
                LoadDataChiTietHoaDon(dtgvHD.CurrentRow.Cells[0].Value.ToString().Trim());
            }    
        }
        private void LoadDataChiTietHoaDon(string MaHD)
        {
            string strSQl = $@"SELECT a.MaHD,b.TenDU,a.DonGia,a.SoLuong,a.ThanhTien FROM ChiTietHoaDon a INNER JOIN DoUong b ON a.MaDU = b.MaDU WHERE a.MaHD = '{MaHD}'";
            DataTable dt = new DataTable();
            dt = ConnectSQL.Load(strSQl);
            dtgvCTHD.DataSource = dt;
            frmNhanVien.SetupDataGridView(dtgvCTHD);
            dtgvCTHD.Columns[0].HeaderText = "Mã hóa đơn";
            dtgvCTHD.Columns[1].HeaderText = "Tên đồ uống";
            dtgvCTHD.Columns[2].HeaderText = "Số lượng";
            dtgvCTHD.Columns[3].HeaderText = "Đơn giá";
            dtgvCTHD.Columns[4].HeaderText = "Thành tiền";
        }
        private void frmLichSuHoaDon_Load(object sender, EventArgs e)
        {
            LoadDataHoaDon();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            LoadDataHoaDon();
        }

        private void dtgvHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvHD.Rows[e.RowIndex];
                LoadDataChiTietHoaDon(row.Cells[0].Value.ToString());
            }
        }
    }
}
