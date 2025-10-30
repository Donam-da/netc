﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QuanLyCafe
{
    [SupportedOSPlatform("windows")]
    public partial class frmInHoaDon: Form
    {
        private DataTable _dtDetail;
        private Dictionary<string, string> _reportParams;

        public frmInHoaDon(DataTable dtDetail, Dictionary<string, string> reportParams)
        {
            InitializeComponent();
            _dtDetail = dtDetail;
            _reportParams = reportParams;
        }

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyCafe.Report1.rdlc";
            ReportDataSource rds = new ReportDataSource("DataSet1", _dtDetail);

            ReportParameter[] parameters = new ReportParameter[4];
            parameters[0] = new ReportParameter("NgayHoaDon", _reportParams["NgayLap"], true);
            parameters[1] = new ReportParameter("MaNV", _reportParams["TenNV"], true);
            parameters[2] = new ReportParameter("MaKH", _reportParams["TenKH"], true);
            parameters[3] = new ReportParameter("TongTien", _reportParams["TongTien"], true);

            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }
    }
}
