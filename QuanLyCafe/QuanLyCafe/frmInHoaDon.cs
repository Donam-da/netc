using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QuanLyCafe
{
    public partial class frmInHoaDon: Form
    {
        public frmInHoaDon()
        {
            InitializeComponent();
        }

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            string strSQL = $@"SELECT a.NgayLap,a.TongTien,b.TenNV,c.TenKH
                               FROM HoaDon a INNER JOIN NhanVien b ON a.MaNV = b.MaNV
                                             INNER JOIN KhachHang c ON a.MaKH = c.MaKH
                               WHERE MaHD = '{frmManHinhChinh.MaHDThanhToan}'";
            DataTable dtMaster = ConnectSQL.Load(strSQL);
            strSQL = $@"SELECT b.TenDU,a.DonGia,a.SoLuong,a.ThanhTien FROM ChiTietHoaDon a INNER JOIN DoUong b ON a.MaDU = b.MaDU
                                 WHERE MaHD = '{frmManHinhChinh.MaHDThanhToan}'";
            DataTable dtDetail = ConnectSQL.Load(strSQL);
            
            reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyCafe.Report1.rdlc";
            ReportDataSource rds = new ReportDataSource("DataSet1", dtDetail);
            ReportParameter[] parameters = new ReportParameter[4];
            parameters[0] = new ReportParameter("NgayHoaDon", dtMaster.Rows[0]["NgayLap"].ToString(), true);
            parameters[1] = new ReportParameter("MaNV", dtMaster.Rows[0]["TenNV"].ToString(), true);
            parameters[2] = new ReportParameter("MaKH", dtMaster.Rows[0]["TenKH"].ToString(), true);
            parameters[3] = new ReportParameter("TongTien", dtMaster.Rows[0]["TongTien"].ToString(), true);
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
