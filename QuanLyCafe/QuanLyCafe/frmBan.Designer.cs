﻿namespace QuanLyCafe
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    partial class frmBan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grbThongTin = new System.Windows.Forms.GroupBox();
            this.txtSucChua = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaBan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlChucNang = new System.Windows.Forms.Panel();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.dtgvData = new System.Windows.Forms.DataGridView();
            this.pnlTimKiem = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlLeft.SuspendLayout();
            this.grbThongTin.SuspendLayout();
            this.pnlChucNang.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvData)).BeginInit();
            this.pnlTimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grbThongTin);
            this.pnlLeft.Controls.Add(this.pnlChucNang);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(10);
            this.pnlLeft.Size = new System.Drawing.Size(320, 561);
            this.pnlLeft.TabIndex = 0;
            // 
            // grbThongTin
            // 
            this.grbThongTin.Controls.Add(this.txtSucChua);
            this.grbThongTin.Controls.Add(this.label2);
            this.grbThongTin.Controls.Add(this.txtMaBan);
            this.grbThongTin.Controls.Add(this.label1);
            this.grbThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbThongTin.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.grbThongTin.Location = new System.Drawing.Point(10, 10);
            this.grbThongTin.Name = "grbThongTin";
            this.grbThongTin.Size = new System.Drawing.Size(300, 481);
            this.grbThongTin.TabIndex = 1;
            this.grbThongTin.TabStop = false;
            this.grbThongTin.Text = "Thông tin chi tiết";
            // 
            // txtSucChua
            // 
            this.txtSucChua.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSucChua.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSucChua.Location = new System.Drawing.Point(20, 120);
            this.txtSucChua.Name = "txtSucChua";
            this.txtSucChua.Size = new System.Drawing.Size(260, 29);
            this.txtSucChua.TabIndex = 3;
            this.txtSucChua.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSucChua_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.Location = new System.Drawing.Point(16, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sức chứa:";
            // 
            // txtMaBan
            // 
            this.txtMaBan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaBan.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMaBan.Location = new System.Drawing.Point(20, 58);
            this.txtMaBan.Name = "txtMaBan";
            this.txtMaBan.Size = new System.Drawing.Size(260, 29);
            this.txtMaBan.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã bàn:";
            // 
            // pnlChucNang
            // 
            this.pnlChucNang.Controls.Add(this.btnXoa);
            this.pnlChucNang.Controls.Add(this.btnSua);
            this.pnlChucNang.Controls.Add(this.btnThem);
            this.pnlChucNang.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlChucNang.Location = new System.Drawing.Point(10, 491);
            this.pnlChucNang.Name = "pnlChucNang";
            this.pnlChucNang.Size = new System.Drawing.Size(300, 60);
            this.pnlChucNang.TabIndex = 0;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(203, 10);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 40);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.menuXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.Black;
            this.btnSua.Location = new System.Drawing.Point(107, 10);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 40);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.menuSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(11, 10);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 40);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.menuThem_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.dtgvData);
            this.pnlRight.Controls.Add(this.pnlTimKiem);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(320, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.pnlRight.Size = new System.Drawing.Size(664, 561);
            this.pnlRight.TabIndex = 1;
            // 
            // dtgvData
            // 
            this.dtgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvData.Location = new System.Drawing.Point(0, 60);
            this.dtgvData.Name = "dtgvData";
            this.dtgvData.RowHeadersWidth = 51;
            this.dtgvData.RowTemplate.Height = 24;
            this.dtgvData.Size = new System.Drawing.Size(654, 491);
            this.dtgvData.TabIndex = 1;
            this.dtgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvData_CellClick);
            // 
            // pnlTimKiem
            // 
            this.pnlTimKiem.Controls.Add(this.btnTimKiem);
            this.pnlTimKiem.Controls.Add(this.txtSearch);
            this.pnlTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTimKiem.Location = new System.Drawing.Point(0, 10);
            this.pnlTimKiem.Name = "pnlTimKiem";
            this.pnlTimKiem.Size = new System.Drawing.Size(654, 50);
            this.pnlTimKiem.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(544, 5);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 40);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.menuTimKiem_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSearch.Location = new System.Drawing.Point(10, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(528, 34);
            this.txtSearch.TabIndex = 0;
            // 
            // frmBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục bàn";
            this.Load += new System.EventHandler(this.frmBan_Load);
            this.pnlLeft.ResumeLayout(false);
            this.grbThongTin.ResumeLayout(false);
            this.grbThongTin.PerformLayout();
            this.pnlChucNang.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvData)).EndInit();
            this.pnlTimKiem.ResumeLayout(false);
            this.pnlTimKiem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.GroupBox grbThongTin;
        private System.Windows.Forms.TextBox txtSucChua;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaBan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlChucNang;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dtgvData;
    }
}