﻿namespace QuanLyCafe
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    partial class frmKhachHangThanThiet
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dtgvData = new System.Windows.Forms.DataGridView();
            this.dtgvLichSuMuaHang = new System.Windows.Forms.DataGridView();
            this.lblLichSu = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.grbThemQuyTac = new System.Windows.Forms.GroupBox();
            this.btnThemQuyTac = new System.Windows.Forms.Button();
            this.nmPhanTramGiamGia = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nmNguong = new System.Windows.Forms.NumericUpDown();
            this.rbTongChiTieu = new System.Windows.Forms.RadioButton();
            this.rbSoLanMua = new System.Windows.Forms.RadioButton();
            this.grbQuyTac = new System.Windows.Forms.GroupBox();
            this.dtgvQuyTac = new System.Windows.Forms.DataGridView();
            this.pnlRuleActions = new System.Windows.Forms.Panel();
            this.btnApDungTatCa = new System.Windows.Forms.Button();
            this.btnXoaQuyTac = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLichSuMuaHang)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.grbThemQuyTac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmPhanTramGiamGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmNguong)).BeginInit();
            this.grbQuyTac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvQuyTac)).BeginInit();
            this.pnlRuleActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlBottom);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.splitContainer1.Size = new System.Drawing.Size(999, 554);
            this.splitContainer1.SplitterDistance = 320;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(10, 10);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dtgvData);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dtgvLichSuMuaHang);
            this.splitContainer2.Panel2.Controls.Add(this.lblLichSu);
            this.splitContainer2.Size = new System.Drawing.Size(979, 305);
            this.splitContainer2.SplitterDistance = 550;
            this.splitContainer2.TabIndex = 0;
            // 
            // dtgvData
            // 
            this.dtgvData.AllowUserToAddRows = false;
            this.dtgvData.AllowUserToDeleteRows = false;
            this.dtgvData.AllowUserToResizeRows = false;
            this.dtgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.dtgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvData.Location = new System.Drawing.Point(0, 0);
            this.dtgvData.MultiSelect = false;
            this.dtgvData.Name = "dtgvData";
            this.dtgvData.ReadOnly = true;
            this.dtgvData.RowHeadersVisible = false;
            this.dtgvData.RowHeadersWidth = 51;
            this.dtgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvData.Size = new System.Drawing.Size(550, 305);
            this.dtgvData.TabIndex = 3;
            this.dtgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvData_CellDoubleClick);
            // 
            // dtgvLichSuMuaHang
            // 
            this.dtgvLichSuMuaHang.AllowUserToAddRows = false;
            this.dtgvLichSuMuaHang.AllowUserToDeleteRows = false;
            this.dtgvLichSuMuaHang.AllowUserToResizeRows = false;
            this.dtgvLichSuMuaHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvLichSuMuaHang.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.dtgvLichSuMuaHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvLichSuMuaHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvLichSuMuaHang.Location = new System.Drawing.Point(0, 28);
            this.dtgvLichSuMuaHang.MultiSelect = false;
            this.dtgvLichSuMuaHang.Name = "dtgvLichSuMuaHang";
            this.dtgvLichSuMuaHang.ReadOnly = true;
            this.dtgvLichSuMuaHang.RowHeadersVisible = false;
            this.dtgvLichSuMuaHang.RowHeadersWidth = 51;
            this.dtgvLichSuMuaHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvLichSuMuaHang.Size = new System.Drawing.Size(425, 277);
            this.dtgvLichSuMuaHang.TabIndex = 3;
            // 
            // lblLichSu
            // 
            this.lblLichSu.AutoSize = true;
            this.lblLichSu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLichSu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblLichSu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.lblLichSu.Location = new System.Drawing.Point(0, 0);
            this.lblLichSu.Name = "lblLichSu";
            this.lblLichSu.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lblLichSu.Size = new System.Drawing.Size(155, 28);
            this.lblLichSu.TabIndex = 2;
            this.lblLichSu.Text = "Lịch sử mua hàng:";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.grbQuyTac);
            this.pnlBottom.Controls.Add(this.grbThemQuyTac);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(10, 0);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(979, 220);
            this.pnlBottom.TabIndex = 4;
            // 
            // dtgvData
            // 
            this.dtgvData.AllowUserToAddRows = false;
            this.dtgvData.AllowUserToDeleteRows = false;
            this.dtgvData.AllowUserToResizeRows = false;
            this.dtgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.dtgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            // 
            // grbThemQuyTac
            // 
            this.grbThemQuyTac.Controls.Add(this.btnThemQuyTac);
            this.grbThemQuyTac.Controls.Add(this.nmPhanTramGiamGia);
            this.grbThemQuyTac.Controls.Add(this.label3);
            this.grbThemQuyTac.Controls.Add(this.nmNguong);
            this.grbThemQuyTac.Controls.Add(this.rbTongChiTieu);
            this.grbThemQuyTac.Controls.Add(this.rbSoLanMua);
            this.grbThemQuyTac.Dock = System.Windows.Forms.DockStyle.Left;
            this.grbThemQuyTac.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grbThemQuyTac.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.grbThemQuyTac.Location = new System.Drawing.Point(0, 0);
            this.grbThemQuyTac.Name = "grbThemQuyTac";
            this.grbThemQuyTac.Size = new System.Drawing.Size(400, 220);
            this.grbThemQuyTac.TabIndex = 3;
            this.grbThemQuyTac.TabStop = false;
            this.grbThemQuyTac.Text = "Thêm Quy tắc Mới";
            // 
            // btnThemQuyTac
            // 
            this.btnThemQuyTac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemQuyTac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(59)))), ((int)(((byte)(46)))));
            this.btnThemQuyTac.FlatAppearance.BorderSize = 0;
            this.btnThemQuyTac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemQuyTac.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnThemQuyTac.ForeColor = System.Drawing.Color.White;
            this.btnThemQuyTac.Location = new System.Drawing.Point(290, 160);
            this.btnThemQuyTac.Name = "btnThemQuyTac";
            this.btnThemQuyTac.Size = new System.Drawing.Size(90, 30);
            this.btnThemQuyTac.TabIndex = 5;
            this.btnThemQuyTac.Text = "Thêm";
            this.btnThemQuyTac.UseVisualStyleBackColor = false;
            this.btnThemQuyTac.Click += new System.EventHandler(this.btnThemQuyTac_Click);
            // 
            // nmPhanTramGiamGia
            // 
            this.nmPhanTramGiamGia.DecimalPlaces = 1;
            this.nmPhanTramGiamGia.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.nmPhanTramGiamGia.Location = new System.Drawing.Point(200, 112);
            this.nmPhanTramGiamGia.Name = "nmPhanTramGiamGia";
            this.nmPhanTramGiamGia.Size = new System.Drawing.Size(90, 29);
            this.nmPhanTramGiamGia.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label3.Location = new System.Drawing.Point(10, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "thì giảm giá (%):";
            // 
            // nmNguong
            // 
            this.nmNguong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nmNguong.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.nmNguong.Location = new System.Drawing.Point(190, 50);
            this.nmNguong.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nmNguong.Name = "nmNguong";
            this.nmNguong.Size = new System.Drawing.Size(200, 29);
            this.nmNguong.TabIndex = 2;
            // 
            // rbTongChiTieu
            // 
            this.rbTongChiTieu.AutoSize = true;
            this.rbTongChiTieu.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rbTongChiTieu.Location = new System.Drawing.Point(10, 78);
            this.rbTongChiTieu.Name = "rbTongChiTieu";
            this.rbTongChiTieu.Size = new System.Drawing.Size(130, 27);
            this.rbTongChiTieu.TabIndex = 1;
            this.rbTongChiTieu.Text = "Tổng chi tiêu >=";
            this.rbTongChiTieu.UseVisualStyleBackColor = true;
            // 
            // rbSoLanMua
            // 
            this.rbSoLanMua.AutoSize = true;
            this.rbSoLanMua.Checked = true;
            this.rbSoLanMua.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rbSoLanMua.Location = new System.Drawing.Point(10, 50);
            this.rbSoLanMua.Name = "rbSoLanMua";
            this.rbSoLanMua.Size = new System.Drawing.Size(136, 27);
            this.rbSoLanMua.TabIndex = 0;
            this.rbSoLanMua.TabStop = true;
            this.rbSoLanMua.Text = "Số lần mua >=";
            this.rbSoLanMua.UseVisualStyleBackColor = true;
            //
            // grbQuyTac
            // 
            this.grbQuyTac.Controls.Add(this.dtgvQuyTac);
            this.grbQuyTac.Controls.Add(this.pnlRuleActions);
            this.grbQuyTac.Dock = System.Windows.Forms.DockStyle.Right;
            this.grbQuyTac.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grbQuyTac.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.grbQuyTac.Location = new System.Drawing.Point(406, 0);
            this.grbQuyTac.Name = "grbQuyTac";
            this.grbQuyTac.Size = new System.Drawing.Size(573, 220);
            this.grbQuyTac.TabIndex = 4;
            this.grbQuyTac.TabStop = false;
            this.grbQuyTac.Text = "Danh sách Quy tắc Giảm giá";
            // 
            // dtgvQuyTac
            // 
            this.dtgvQuyTac.AllowUserToAddRows = false;
            this.dtgvQuyTac.AllowUserToDeleteRows = false;
            this.dtgvQuyTac.AllowUserToResizeRows = false;
            this.dtgvQuyTac.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvQuyTac.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.dtgvQuyTac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvQuyTac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvQuyTac.Location = new System.Drawing.Point(3, 23);
            this.dtgvQuyTac.MultiSelect = false;
            this.dtgvQuyTac.Name = "dtgvQuyTac";
            this.dtgvQuyTac.ReadOnly = true;
            this.dtgvQuyTac.RowHeadersVisible = false;
            this.dtgvQuyTac.RowHeadersWidth = 51;
            this.dtgvQuyTac.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvQuyTac.Size = new System.Drawing.Size(567, 151);
            this.dtgvQuyTac.TabIndex = 0;
            // 
            // pnlRuleActions
            // 
            this.pnlRuleActions.Controls.Add(this.btnApDungTatCa);
            this.pnlRuleActions.Controls.Add(this.btnXoaQuyTac);
            this.pnlRuleActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRuleActions.Location = new System.Drawing.Point(3, 174);
            this.pnlRuleActions.Name = "pnlRuleActions";
            this.pnlRuleActions.Size = new System.Drawing.Size(567, 43);
            this.pnlRuleActions.TabIndex = 1;
            // 
            // btnApDungTatCa
            // 
            this.btnApDungTatCa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApDungTatCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(142)))), ((int)(((byte)(65)))));
            this.btnApDungTatCa.FlatAppearance.BorderSize = 0;
            this.btnApDungTatCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApDungTatCa.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnApDungTatCa.ForeColor = System.Drawing.Color.White;
            this.btnApDungTatCa.Location = new System.Drawing.Point(397, 0);
            this.btnApDungTatCa.Name = "btnApDungTatCa";
            this.btnApDungTatCa.Size = new System.Drawing.Size(167, 40);
            this.btnApDungTatCa.TabIndex = 7;
            this.btnApDungTatCa.Text = "Áp dụng tất cả";
            this.btnApDungTatCa.UseVisualStyleBackColor = false;
            this.btnApDungTatCa.Click += new System.EventHandler(this.btnApDungTatCa_Click);
            // 
            // btnXoaQuyTac
            // 
            this.btnXoaQuyTac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnXoaQuyTac.FlatAppearance.BorderSize = 0;
            this.btnXoaQuyTac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaQuyTac.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnXoaQuyTac.ForeColor = System.Drawing.Color.White;
            this.btnXoaQuyTac.Location = new System.Drawing.Point(271, 0);
            this.btnXoaQuyTac.Name = "btnXoaQuyTac";
            this.btnXoaQuyTac.Size = new System.Drawing.Size(120, 40);
            this.btnXoaQuyTac.TabIndex = 6;
            this.btnXoaQuyTac.Text = "Xóa quy tắc";
            this.btnXoaQuyTac.UseVisualStyleBackColor = false;
            this.btnXoaQuyTac.Click += new System.EventHandler(this.btnXoaQuyTac_Click);
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(233)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(999, 554);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(820, 480);
            this.Name = "frmKhachHangThanThiet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê Khách hàng thân thiết";
            this.Load += new System.EventHandler(this.frmKhachHangThanThiet_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLichSuMuaHang)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.grbThemQuyTac.ResumeLayout(false);
            this.grbThemQuyTac.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmPhanTramGiamGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmNguong)).EndInit();
            this.grbQuyTac.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvQuyTac)).EndInit();
            this.pnlRuleActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dtgvData;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dtgvLichSuMuaHang;
        private System.Windows.Forms.Label lblLichSu;
        private System.Windows.Forms.GroupBox grbThemQuyTac;
        private System.Windows.Forms.Button btnThemQuyTac;
        private System.Windows.Forms.NumericUpDown nmPhanTramGiamGia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nmNguong;
        private System.Windows.Forms.RadioButton rbTongChiTieu;
        private System.Windows.Forms.RadioButton rbSoLanMua;
        private System.Windows.Forms.GroupBox grbQuyTac;
        private System.Windows.Forms.DataGridView dtgvQuyTac;
        private System.Windows.Forms.Panel pnlRuleActions;
        private System.Windows.Forms.Button btnApDungTatCa;
        private System.Windows.Forms.Button btnXoaQuyTac;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel pnlBottom;
    }
}