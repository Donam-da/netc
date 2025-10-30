﻿using System;
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
    public partial class frmLoaiDoUong: Form
    {
        public frmLoaiDoUong()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            string strSQl = "SELECT * FROM LoaiDoUong WHERE TenLoai LIKE @TenLoai";
            var parameters = new Dictionary<string, object>
            {
                { "@TenLoai", $"%{txtSearch.Text}%" }
            };

            dtgvData.DataSource = ConnectSQL.Load(strSQl, parameters);
            frmNhanVien.SetupDataGridView(dtgvData);
            dtgvData.Columns[0].HeaderText = "Mã loại";
            dtgvData.Columns[1].HeaderText = "Tên loại";
            if (dtgvData.Rows.Count == 0)
            {
                txtMaLoai.Text = "";
                txtTenLoai.Text = "";
            }
            else
            {
                DataGridViewRow drow = dtgvData.Rows[0];
                txtMaLoai.Text = drow.Cells[0].Value.ToString();
                txtTenLoai.Text = drow.Cells[1].Value.ToString();
            }
        }

        private void frmLoaiDoUong_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void menuThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLoai.Text))
            {
                MessageBox.Show("Chưa nhập mã loại");
                txtMaLoai.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTenLoai.Text))
            {
                MessageBox.Show("Chưa nhập tên loại");
                txtTenLoai.Focus();
                return;
            }

            string sqlCheck = "SELECT MaLoai FROM LoaiDoUong WHERE MaLoai = @MaLoai";
            var paramCheck = new Dictionary<string, object> { { "@MaLoai", txtMaLoai.Text } };
            if (ConnectSQL.ExcuteReader_bool(sqlCheck, paramCheck))
            {
                MessageBox.Show("Mã loại đồ uống này đã tồn tại, vui lòng tạo mã khác");
                txtMaLoai.Focus();
                return;
            }

            string sqlInsert = "INSERT INTO LoaiDoUong(MaLoai, TenLoai) VALUES (@MaLoai, @TenLoai)";
            var paramInsert = new Dictionary<string, object>
            {
                { "@MaLoai", txtMaLoai.Text },
                { "@TenLoai", txtTenLoai.Text }
            };
            ConnectSQL.RunQuery(sqlInsert, paramInsert);
            MessageBox.Show("Thêm thành công");
            LoadData();
        }

        private void menuXoaTrang_Click(object sender, EventArgs e)
        {
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
        }

        private void menuSua_Click(object sender, EventArgs e)
        {
            if (dtgvData.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một loại đồ uống để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtMaLoai.Text))
            {
                MessageBox.Show("Chưa nhập mã loại");
                txtMaLoai.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTenLoai.Text))
            {
                MessageBox.Show("Chưa nhập tên loại");
                txtTenLoai.Focus();
                return;
            }

            string MaLoaiSua = dtgvData.CurrentRow.Cells[0].Value.ToString()!.Trim();
            if (txtMaLoai.Text.Trim() != MaLoaiSua)
            {
                string sqlCheck = "SELECT MaLoai FROM LoaiDoUong WHERE MaLoai = @MaLoai";
                var paramCheck = new Dictionary<string, object> { { "@MaLoai", txtMaLoai.Text.Trim() } };
                if (ConnectSQL.ExcuteReader_bool(sqlCheck, paramCheck))
                {
                    MessageBox.Show("Mã loại đồ uống này đã tồn tại, vui lòng tạo mã khác");
                    txtMaLoai.Focus();
                    return;
                }
            }

            string strSQL = "UPDATE LoaiDoUong SET MaLoai = @MaLoai, TenLoai = @TenLoai WHERE MaLoai = @MaLoaiSua";
            var parameters = new Dictionary<string, object> {
                { "@MaLoai", txtMaLoai.Text }, { "@TenLoai", txtTenLoai.Text }, { "@MaLoaiSua", MaLoaiSua }
            };
            ConnectSQL.RunQuery(strSQL, parameters);
            MessageBox.Show("Sửa thành công");
            LoadData();
        }

        private void dtgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvData.Rows[e.RowIndex];
                txtMaLoai.Text = row.Cells["MaLoai"].Value.ToString();
                txtTenLoai.Text = row.Cells["TenLoai"].Value.ToString();
            }
        }

        private void menuXoa_Click(object sender, EventArgs e)
        {
            if (dtgvData.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một loại đồ uống để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maLoai = dtgvData.CurrentRow.Cells["MaLoai"].Value.ToString()!.Trim();
            string strCheck = "SELECT MaLoai FROM DoUong WHERE MaLoai = @MaLoai";
            var paramCheck = new Dictionary<string, object> { { "@MaLoai", maLoai } };
            if(ConnectSQL.ExcuteReader_bool(strCheck, paramCheck))
            {
                MessageBox.Show("Dữ liệu đã phát sinh khóa ngoại trong bảng DoUong, không xóa được");
                return;
            }    
            DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string strSQL = "DELETE FROM LoaiDoUong WHERE MaLoai = @MaLoai";
                ConnectSQL.RunQuery(strSQL, new Dictionary<string, object> { { "@MaLoai", maLoai } });
                MessageBox.Show("Xóa thành công");
                LoadData();
            }
        }

        private void menuTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
