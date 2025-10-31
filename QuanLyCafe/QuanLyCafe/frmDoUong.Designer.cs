﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿namespace QuanLyCafe
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    partial class frmDoUong
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
            this.grbCongThuc = new System.Windows.Forms.GroupBox();
            this.dtgvCongThuc = new System.Windows.Forms.DataGridView();
            this.btnThemNL = new System.Windows.Forms.Button();
            this.nmSoLuongNL = new System.Windows.Forms.NumericUpDown();
            this.btnXoaNL = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cboNguyenLieu = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nmGiaGoc = new System.Windows.Forms.NumericUpDown();
            this.lblGiaGoc = new System.Windows.Forms.Label();
            this.lblLoiNhuan = new System.Windows.Forms.Label();
            this.rbNguyenBan = new System.Windows.Forms.RadioButton();
            this.rbPhaChe = new System.Windows.Forms.RadioButton();
            this.nmNguongCanhBao = new System.Windows.Forms.NumericUpDown();
            this.chkHienThi = new System.Windows.Forms.CheckBox();
            this.txtSoLuongTon = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMaLoai = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenDU = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaDU = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlChucNang = new System.Windows.Forms.Panel();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoaTrang = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.dtgvData = new System.Windows.Forms.DataGridView();
            this.pnlTimKiem = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlLeft.SuspendLayout();
            this.grbThongTin.SuspendLayout();
            this.grbCongThuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCongThuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuongNL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmGiaGoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmNguongCanhBao)).BeginInit();
            this.pnlChucNang.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvData)).BeginInit();
            this.pnlTimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(213)))), ((int)(((byte)(183)))));
            this.pnlLeft.Controls.Add(this.grbThongTin);
            this.pnlLeft.Controls.Add(this.pnlChucNang);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(5);
            this.pnlLeft.Size = new System.Drawing.Size(380, 661);
            this.pnlLeft.TabIndex = 0;
            // 
            // grbThongTin
            // 
            this.grbThongTin.Controls.Add(this.btnXoaTrang);
            this.grbThongTin.Controls.Add(this.nmNguongCanhBao);
            this.grbThongTin.Controls.Add(this.nmGiaGoc);
            this.grbThongTin.Controls.Add(this.lblGiaGoc);
            this.grbThongTin.Controls.Add(this.lblLoiNhuan);
            this.grbThongTin.Controls.Add(this.rbNguyenBan);
            this.grbThongTin.Controls.Add(this.rbPhaChe);
            this.grbThongTin.Controls.Add(this.chkHienThi);
            this.grbThongTin.Controls.Add(this.txtSoLuongTon);
            this.grbThongTin.Controls.Add(this.label5);
            this.grbThongTin.Controls.Add(this.txtDonGia);
            this.grbThongTin.Controls.Add(this.label4);
            this.grbThongTin.Controls.Add(this.cboMaLoai);
            this.grbThongTin.Controls.Add(this.label3);
            this.grbThongTin.Controls.Add(this.txtTenDU);
            this.grbThongTin.Controls.Add(this.label2);
            this.grbThongTin.Controls.Add(this.txtMaDU);
            this.grbThongTin.Controls.Add(this.label1);
            this.grbThongTin.Controls.Add(this.label6);
            this.grbThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbThongTin.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.grbThongTin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.grbThongTin.Location = new System.Drawing.Point(5, 5);
            this.grbThongTin.Name = "grbThongTin";
            this.grbThongTin.Size = new System.Drawing.Size(370, 415);
            this.grbThongTin.TabIndex = 1;
            this.grbThongTin.TabStop = false;
            this.grbThongTin.Text = "Thông tin chi tiết";
            // 
            // grbCongThuc
            // 
            this.grbCongThuc.Controls.Add(this.dtgvCongThuc);
            this.grbCongThuc.Controls.Add(this.btnThemNL);
            this.grbCongThuc.Controls.Add(this.btnXoaNL);
            this.grbCongThuc.Controls.Add(this.nmSoLuongNL);
            this.grbCongThuc.Controls.Add(this.label8);
            this.grbCongThuc.Controls.Add(this.cboNguyenLieu);
            this.grbCongThuc.Controls.Add(this.label7);
            this.grbCongThuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grbCongThuc.Location = new System.Drawing.Point(10, 410); // Giữ nguyên vị trí
            this.grbCongThuc.Name = "grbCongThuc";
            this.grbCongThuc.Size = new System.Drawing.Size(470, 240);
            this.grbCongThuc.TabIndex = 17;
            this.grbCongThuc.TabStop = false;
            this.grbCongThuc.Text = "Công thức pha chế";
            // 
            // dtgvCongThuc
            // 
            this.dtgvCongThuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCongThuc.Location = new System.Drawing.Point(9, 120);
            this.dtgvCongThuc.Name = "dtgvCongThuc";
            this.dtgvCongThuc.RowHeadersWidth = 51;
            this.dtgvCongThuc.RowTemplate.Height = 24;
            this.dtgvCongThuc.Size = new System.Drawing.Size(460, 110);
            this.dtgvCongThuc.TabIndex = 6;
            // 
            // btnThemNL
            // 
            this.btnThemNL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(59)))), ((int)(((byte)(46)))));
            this.btnThemNL.FlatAppearance.BorderSize = 0;
            this.btnThemNL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemNL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThemNL.ForeColor = System.Drawing.Color.White;
            this.btnThemNL.Location = new System.Drawing.Point(154, 80);
            this.btnThemNL.Name = "btnThemNL";
            this.btnThemNL.Size = new System.Drawing.Size(80, 30);
            this.btnThemNL.TabIndex = 5;
            this.btnThemNL.Text = "Thêm NL";
            this.btnThemNL.UseVisualStyleBackColor = false;
            this.btnThemNL.Click += new System.EventHandler(this.btnThemNL_Click);
            // 
            // nmSoLuongNL
            // 
            this.nmSoLuongNL.DecimalPlaces = 2;
            this.nmSoLuongNL.Location = new System.Drawing.Point(154, 47);
            this.nmSoLuongNL.Name = "nmSoLuongNL";
            this.nmSoLuongNL.Size = new System.Drawing.Size(114, 27);
            this.nmSoLuongNL.TabIndex = 4;
            // 
            // btnXoaNL
            // 
            this.btnXoaNL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaNL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnXoaNL.FlatAppearance.BorderSize = 0;
            this.btnXoaNL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaNL.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaNL.ForeColor = System.Drawing.Color.White;
            this.btnXoaNL.Location = new System.Drawing.Point(245, 80);
            this.btnXoaNL.Name = "btnXoaNL";
            this.btnXoaNL.Size = new System.Drawing.Size(80, 30);
            this.btnXoaNL.TabIndex = 6;
            this.btnXoaNL.Text = "Xóa NL";
            this.btnXoaNL.UseVisualStyleBackColor = false;
            this.btnXoaNL.Click += new System.EventHandler(this.btnXoaNL_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(150, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "Số lượng:";
            // 
            // cboNguyenLieu
            // 
            this.cboNguyenLieu.FormattingEnabled = true;
            this.cboNguyenLieu.Location = new System.Drawing.Point(9, 46);
            this.cboNguyenLieu.Name = "cboNguyenLieu";
            this.cboNguyenLieu.Size = new System.Drawing.Size(139, 28);
            this.cboNguyenLieu.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Nguyên liệu:";
            // 
            // nmGiaGoc
            // 
            this.nmGiaGoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.nmGiaGoc.DecimalPlaces = 2;
            this.nmGiaGoc.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.nmGiaGoc.Location = new System.Drawing.Point(167, 515);
            this.nmGiaGoc.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nmGiaGoc.Name = "nmGiaGoc";
            this.nmGiaGoc.Size = new System.Drawing.Size(173, 29);
            this.nmGiaGoc.TabIndex = 16;
            this.nmGiaGoc.Enter += new System.EventHandler(this.nmGiaGoc_Enter);
            // 
            // lblGiaGoc
            // 
            this.lblGiaGoc.AutoSize = true;
            this.lblGiaGoc.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblGiaGoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.lblGiaGoc.Location = new System.Drawing.Point(16, 517);
            this.lblGiaGoc.Name = "lblGiaGoc";
            this.lblGiaGoc.Size = new System.Drawing.Size(154, 23);
            this.lblGiaGoc.TabIndex = 15;
            this.lblGiaGoc.Text = "Giá gốc (chai/lon):";
            // 
            // lblLoiNhuan
            // 
            this.lblLoiNhuan.AutoSize = true;
            this.lblLoiNhuan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic);
            this.lblLoiNhuan.ForeColor = System.Drawing.Color.Blue;
            this.lblLoiNhuan.Location = new System.Drawing.Point(16, 208);
            this.lblLoiNhuan.Name = "lblLoiNhuan";
            this.lblLoiNhuan.Size = new System.Drawing.Size(124, 23);
            this.lblLoiNhuan.TabIndex = 18;
            this.lblLoiNhuan.Text = "Lợi nhuận: 0 VNĐ";
            this.lblLoiNhuan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbNguyenBan
            // 
            this.rbNguyenBan.AutoSize = true;
            this.rbNguyenBan.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rbNguyenBan.Location = new System.Drawing.Point(20, 338);
            this.rbNguyenBan.Name = "rbNguyenBan";
            this.rbNguyenBan.Size = new System.Drawing.Size(176, 27);
            this.rbNguyenBan.TabIndex = 14;
            this.rbNguyenBan.TabStop = true;
            this.rbNguyenBan.Text = "Đồ uống nguyên bản";
            this.rbNguyenBan.UseVisualStyleBackColor = true;
            this.rbNguyenBan.CheckedChanged += new System.EventHandler(this.LoaiDoUong_CheckedChanged);
            // 
            // rbPhaChe
            // 
            this.rbPhaChe.AutoSize = true;
            this.rbPhaChe.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rbPhaChe.Location = new System.Drawing.Point(20, 308);
            this.rbPhaChe.Name = "rbPhaChe";
            this.rbPhaChe.Size = new System.Drawing.Size(154, 27);
            this.rbPhaChe.TabIndex = 13;
            this.rbPhaChe.TabStop = true;
            this.rbPhaChe.Text = "Đồ uống pha chế";
            this.rbPhaChe.UseVisualStyleBackColor = true;
            this.rbPhaChe.CheckedChanged += new System.EventHandler(this.LoaiDoUong_CheckedChanged);
            // 
            // txtSoLuongTon
            // 
            this.txtSoLuongTon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.txtSoLuongTon.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSoLuongTon.Location = new System.Drawing.Point(20, 480);
            this.txtSoLuongTon.Name = "txtSoLuongTon";
            this.txtSoLuongTon.Size = new System.Drawing.Size(320, 29);
            this.txtSoLuongTon.TabIndex = 8;
            this.txtSoLuongTon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonGia_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.label5.Location = new System.Drawing.Point(16, 450);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Số lượng tồn:";
            // 
            // txtDonGia
            // 
            this.txtDonGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.txtDonGia.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDonGia.Location = new System.Drawing.Point(20, 174);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(320, 29);
            this.txtDonGia.TabIndex = 7;
            this.txtDonGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonGia_KeyPress);
            this.txtDonGia.TextChanged += new System.EventHandler(this.txtDonGia_TextChanged);
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.label4.Location = new System.Drawing.Point(16, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Đơn giá:";
            // 
            // cboMaLoai
            // 
            this.cboMaLoai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.cboMaLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaLoai.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cboMaLoai.FormattingEnabled = true;
            this.cboMaLoai.Location = new System.Drawing.Point(20, 259);
            this.cboMaLoai.Name = "cboMaLoai";
            this.cboMaLoai.Size = new System.Drawing.Size(320, 29);
            this.cboMaLoai.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.label3.Location = new System.Drawing.Point(16, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loại đồ uống:";
            // 
            // txtTenDU
            // 
            this.txtTenDU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.txtTenDU.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTenDU.Location = new System.Drawing.Point(20, 114);
            this.txtTenDU.Name = "txtTenDU";
            this.txtTenDU.Size = new System.Drawing.Size(320, 29);
            this.txtTenDU.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.label2.Location = new System.Drawing.Point(16, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên đồ uống:";
            // 
            // txtMaDU
            // 
            this.txtMaDU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.txtMaDU.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMaDU.Location = new System.Drawing.Point(20, 54);
            this.txtMaDU.Name = "txtMaDU";
            this.txtMaDU.Size = new System.Drawing.Size(320, 29);
            this.txtMaDU.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã đồ uống:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.label6.Location = new System.Drawing.Point(16, 374);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "Ngưỡng cảnh báo:";
            // 
            // nmNguongCanhBao
            // 
            this.nmNguongCanhBao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.nmNguongCanhBao.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.nmNguongCanhBao.Location = new System.Drawing.Point(20, 410);
            this.nmNguongCanhBao.Name = "nmNguongCanhBao";
            this.nmNguongCanhBao.Size = new System.Drawing.Size(141, 29);
            this.nmNguongCanhBao.TabIndex = 9;
            this.nmNguongCanhBao.Enter += new System.EventHandler(this.nmNguongCanhBao_Enter);
            // 
            // chkHienThi
            // 
            this.chkHienThi.AutoSize = true;
            this.chkHienThi.Checked = true;
            this.chkHienThi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHienThi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkHienThi.Location = new System.Drawing.Point(170, 308);
            this.chkHienThi.Name = "chkHienThi";
            this.chkHienThi.Size = new System.Drawing.Size(167, 27);
            this.chkHienThi.TabIndex = 10;
            this.chkHienThi.Text = "Hiển thị trên menu";
            this.chkHienThi.UseVisualStyleBackColor = true;
            // 
            // pnlChucNang
            // 
            this.pnlChucNang.Controls.Add(this.btnXoa);
            this.pnlChucNang.Controls.Add(this.btnSua);
            this.pnlChucNang.Controls.Add(this.btnThem);
            this.pnlChucNang.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlChucNang.Location = new System.Drawing.Point(5, 596);
            this.pnlChucNang.Name = "pnlChucNang";
            this.pnlChucNang.Size = new System.Drawing.Size(370, 60);
            this.pnlChucNang.TabIndex = 0;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(263, 10);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 40);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.menuXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(137, 10);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 40);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Lưu";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.menuSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(142)))), ((int)(((byte)(65)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(11, 10);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 40);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.menuThem_Click);
            // 
            // btnXoaTrang
            // 
            this.btnXoaTrang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaTrang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(85)))), ((int)(((byte)(72)))));
            this.btnXoaTrang.FlatAppearance.BorderSize = 0;
            this.btnXoaTrang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTrang.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnXoaTrang.ForeColor = System.Drawing.Color.White;
            this.btnXoaTrang.Location = new System.Drawing.Point(263, 0);
            this.btnXoaTrang.Name = "btnXoaTrang";
            this.btnXoaTrang.Size = new System.Drawing.Size(100, 32);
            this.btnXoaTrang.TabIndex = 3;
            this.btnXoaTrang.Text = "Làm mới";
            this.btnXoaTrang.UseVisualStyleBackColor = false;
            this.btnXoaTrang.Click += new System.EventHandler(this.menuXoaTrang_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.grbCongThuc);
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(233)))), ((int)(((byte)(208)))));
            this.pnlRight.Controls.Add(this.dtgvData);
            this.pnlRight.Controls.Add(this.pnlTimKiem);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(380, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.pnlRight.Size = new System.Drawing.Size(900, 661);
            this.pnlRight.TabIndex = 1;
            // 
            // dtgvData
            // 
            this.dtgvData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.dtgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvData.Location = new System.Drawing.Point(0, 60);
            this.dtgvData.Name = "dtgvData";
            this.dtgvData.RowHeadersWidth = 51;
            this.dtgvData.RowTemplate.Height = 24;
            this.dtgvData.Size = new System.Drawing.Size(890, 415);
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
            this.pnlTimKiem.Size = new System.Drawing.Size(890, 50);
            this.pnlTimKiem.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(59)))), ((int)(((byte)(46)))));
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(780, 5);
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
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSearch.Location = new System.Drawing.Point(10, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(764, 34);
            this.txtSearch.TabIndex = 0;
            // 
            // frmDoUong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(233)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(1280, 700);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "frmDoUong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục đồ uống";
            this.Load += new System.EventHandler(this.frmDoUong_Load);
            this.pnlLeft.ResumeLayout(false);
            this.grbThongTin.ResumeLayout(false);
            this.grbThongTin.PerformLayout();
            this.grbCongThuc.ResumeLayout(false);
            this.grbCongThuc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCongThuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuongNL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmGiaGoc)).EndInit();
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
        private System.Windows.Forms.TextBox txtTenDU;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaDU;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlChucNang;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoaTrang;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dtgvData;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMaLoai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoLuongTon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nmNguongCanhBao;
        private System.Windows.Forms.CheckBox chkHienThi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grbCongThuc;
        private System.Windows.Forms.NumericUpDown nmGiaGoc;
        private System.Windows.Forms.Label lblGiaGoc;
        private System.Windows.Forms.RadioButton rbNguyenBan;
        private System.Windows.Forms.RadioButton rbPhaChe;
        private System.Windows.Forms.DataGridView dtgvCongThuc;
        private System.Windows.Forms.Button btnThemNL;
        private System.Windows.Forms.NumericUpDown nmSoLuongNL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnXoaNL;
        private System.Windows.Forms.ComboBox cboNguyenLieu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblLoiNhuan;
    }
}