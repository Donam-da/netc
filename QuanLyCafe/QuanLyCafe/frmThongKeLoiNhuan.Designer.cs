﻿namespace QuanLyCafe
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    partial class frmThongKeLoiNhuan
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnLocDuLieu = new System.Windows.Forms.Button();
            this.dtDTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtDFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTongKet = new System.Windows.Forms.Panel();
            this.lblTongLoiNhuan = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTongGiaVon = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dtgvData = new System.Windows.Forms.DataGridView();
            this.dtgvChiTiet = new System.Windows.Forms.DataGridView();
            this.lblChiTietNgay = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.pnlTongKet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(233)))), ((int)(((byte)(208)))));
            this.panelTop.Controls.Add(this.btnLocDuLieu);
            this.panelTop.Controls.Add(this.dtDTo);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.dtDFrom);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelTop.Size = new System.Drawing.Size(999, 60);
            this.panelTop.TabIndex = 1;
            // 
            // btnLocDuLieu
            // 
            this.btnLocDuLieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLocDuLieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(59)))), ((int)(((byte)(46)))));
            this.btnLocDuLieu.FlatAppearance.BorderSize = 0;
            this.btnLocDuLieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocDuLieu.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnLocDuLieu.ForeColor = System.Drawing.Color.White;
            this.btnLocDuLieu.Location = new System.Drawing.Point(818, 12);
            this.btnLocDuLieu.Name = "btnLocDuLieu";
            this.btnLocDuLieu.Size = new System.Drawing.Size(145, 36);
            this.btnLocDuLieu.TabIndex = 4;
            this.btnLocDuLieu.Text = "Lọc dữ liệu";
            this.btnLocDuLieu.UseVisualStyleBackColor = false;
            this.btnLocDuLieu.Click += new System.EventHandler(this.btnLocDuLieu_Click);
            // 
            // dtDTo
            // 
            this.dtDTo.CustomFormat = "dd/MM/yyyy";
            this.dtDTo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtDTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDTo.Location = new System.Drawing.Point(455, 18);
            this.dtDTo.Name = "dtDTo";
            this.dtDTo.Size = new System.Drawing.Size(150, 29);
            this.dtDTo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.label2.Location = new System.Drawing.Point(385, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến ngày";
            // 
            // dtDFrom
            // 
            this.dtDFrom.CustomFormat = "dd/MM/yyyy";
            this.dtDFrom.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtDFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDFrom.Location = new System.Drawing.Point(95, 18);
            this.dtDFrom.Name = "dtDFrom";
            this.dtDFrom.Size = new System.Drawing.Size(150, 29);
            this.dtDFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.label1.Location = new System.Drawing.Point(30, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày";
            // 
            // pnlTongKet
            // 
            this.pnlTongKet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(213)))), ((int)(((byte)(183)))));
            this.pnlTongKet.Controls.Add(this.lblTongLoiNhuan);
            this.pnlTongKet.Controls.Add(this.label6);
            this.pnlTongKet.Controls.Add(this.lblTongGiaVon);
            this.pnlTongKet.Controls.Add(this.label4);
            this.pnlTongKet.Controls.Add(this.lblTongDoanhThu);
            this.pnlTongKet.Controls.Add(this.label3);
            this.pnlTongKet.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTongKet.Location = new System.Drawing.Point(10, 0);
            this.pnlTongKet.Name = "pnlTongKet";
            this.pnlTongKet.Size = new System.Drawing.Size(979, 40);
            this.pnlTongKet.TabIndex = 1;
            // 
            // lblTongLoiNhuan
            // 
            this.lblTongLoiNhuan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongLoiNhuan.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblTongLoiNhuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblTongLoiNhuan.Location = new System.Drawing.Point(890, 6);
            this.lblTongLoiNhuan.Name = "lblTongLoiNhuan";
            this.lblTongLoiNhuan.Size = new System.Drawing.Size(85, 28);
            this.lblTongLoiNhuan.TabIndex = 5;
            this.lblTongLoiNhuan.Text = "0 VNĐ";
            this.lblTongLoiNhuan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.label6.Location = new System.Drawing.Point(755, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 28);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tổng Lợi Nhuận:";
            // 
            // lblTongGiaVon
            // 
            this.lblTongGiaVon.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblTongGiaVon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblTongGiaVon.Location = new System.Drawing.Point(490, 9);
            this.lblTongGiaVon.Name = "lblTongGiaVon";
            this.lblTongGiaVon.Size = new System.Drawing.Size(85, 21);
            this.lblTongGiaVon.TabIndex = 3;
            this.lblTongGiaVon.Text = "0 VNĐ";
            this.lblTongGiaVon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.label4.Location = new System.Drawing.Point(385, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tổng Giá Vốn:";
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblTongDoanhThu.Location = new System.Drawing.Point(145, 9);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(85, 21);
            this.lblTongDoanhThu.TabIndex = 1;
            this.lblTongDoanhThu.Text = "0 VNĐ";
            this.lblTongDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tổng Doanh Thu:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 60);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dtgvData);
            this.splitContainer1.Panel1.Controls.Add(this.pnlTongKet);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dtgvChiTiet);
            this.splitContainer1.Panel2.Controls.Add(this.lblChiTietNgay);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.splitContainer1.Size = new System.Drawing.Size(999, 494);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 4;
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
            this.dtgvData.Location = new System.Drawing.Point(10, 40);
            this.dtgvData.MultiSelect = false;
            this.dtgvData.Name = "dtgvData";
            this.dtgvData.ReadOnly = true;
            this.dtgvData.RowHeadersVisible = false;
            this.dtgvData.RowHeadersWidth = 51;
            this.dtgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvData.Size = new System.Drawing.Size(979, 175);
            this.dtgvData.TabIndex = 0;
            this.dtgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvData_CellClick);
            // 
            // dtgvChiTiet
            // 
            this.dtgvChiTiet.AllowUserToAddRows = false;
            this.dtgvChiTiet.AllowUserToDeleteRows = false;
            this.dtgvChiTiet.AllowUserToResizeRows = false;
            this.dtgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvChiTiet.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.dtgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvChiTiet.Location = new System.Drawing.Point(10, 33);
            this.dtgvChiTiet.MultiSelect = false;
            this.dtgvChiTiet.Name = "dtgvChiTiet";
            this.dtgvChiTiet.ReadOnly = true;
            this.dtgvChiTiet.RowHeadersVisible = false;
            this.dtgvChiTiet.RowHeadersWidth = 51;
            this.dtgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvChiTiet.Size = new System.Drawing.Size(979, 220);
            this.dtgvChiTiet.TabIndex = 1;
            // 
            // lblChiTietNgay
            // 
            this.lblChiTietNgay.AutoSize = true;
            this.lblChiTietNgay.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChiTietNgay.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblChiTietNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.lblChiTietNgay.Location = new System.Drawing.Point(10, 5);
            this.lblChiTietNgay.Name = "lblChiTietNgay";
            this.lblChiTietNgay.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lblChiTietNgay.Size = new System.Drawing.Size(150, 28);
            this.lblChiTietNgay.TabIndex = 0;
            this.lblChiTietNgay.Text = "Chi tiết hóa đơn:";
            // 
            // frmThongKeLoiNhuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(233)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(999, 554);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(820, 480);
            this.Name = "frmThongKeLoiNhuan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê Lợi nhuận";
            this.Load += new System.EventHandler(this.frmThongKeLoiNhuan_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.pnlTongKet.ResumeLayout(false);
            this.pnlTongKet.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChiTiet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnLocDuLieu;
        private System.Windows.Forms.DateTimePicker dtDTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlTongKet;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTongGiaVon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTongLoiNhuan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dtgvData;
        private System.Windows.Forms.DataGridView dtgvChiTiet;
        private System.Windows.Forms.Label lblChiTietNgay;
    }
}