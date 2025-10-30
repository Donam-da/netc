﻿namespace QuanLyCafe
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    partial class frmDoanhThuTheoNhanVien
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnLocDuLieu = new System.Windows.Forms.Button();
            this.dtDTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtDFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgvData = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblTotalCaption = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvData)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.Control;
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
            this.panelTop.TabIndex = 0;
            // 
            // btnLocDuLieu
            // 
            this.btnLocDuLieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLocDuLieu.BackColor = System.Drawing.Color.RoyalBlue;
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
            this.btnLocDuLieu.Click += new System.EventHandler(this.btnThanhToan_Click);
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
            this.label1.Location = new System.Drawing.Point(30, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày";
            // 
            // dtgvData
            // 
            this.dtgvData.AllowUserToAddRows = false;
            this.dtgvData.AllowUserToDeleteRows = false;
            this.dtgvData.AllowUserToResizeRows = false;
            this.dtgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvData.BackgroundColor = System.Drawing.Color.Silver;
            this.dtgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvData.Location = new System.Drawing.Point(0, 60);
            this.dtgvData.MultiSelect = false;
            this.dtgvData.Name = "dtgvData";
            this.dtgvData.ReadOnly = true;
            this.dtgvData.RowHeadersVisible = false;
            this.dtgvData.RowHeadersWidth = 51;
            this.dtgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvData.Size = new System.Drawing.Size(999, 454);
            this.dtgvData.TabIndex = 1;
            this.dtgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvData_CellContentClick);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.SystemColors.Control;
            this.panelBottom.Controls.Add(this.lblTongTien);
            this.panelBottom.Controls.Add(this.lblTotalCaption);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 514);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(999, 40);
            this.panelBottom.TabIndex = 2;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.Red;
            this.lblTongTien.Location = new System.Drawing.Point(881, 6);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(74, 28);
            this.lblTongTien.TabIndex = 1;
            this.lblTongTien.Text = "O VNĐ";
            // 
            // lblTotalCaption
            // 
            this.lblTotalCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCaption.AutoSize = true;
            this.lblTotalCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalCaption.Location = new System.Drawing.Point(792, 6);
            this.lblTotalCaption.Name = "lblTotalCaption";
            this.lblTotalCaption.Size = new System.Drawing.Size(74, 28);
            this.lblTotalCaption.TabIndex = 0;
            this.lblTotalCaption.Text = "TỔNG:";
            // 
            // frmDoanhThuTheoNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(999, 554);
            this.Controls.Add(this.dtgvData);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(820, 480);
            this.Name = "frmDoanhThuTheoNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê doanh thu theo nhân viên";
            this.Load += new System.EventHandler(this.frmDoanhThuTheoNhanVien_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvData)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnLocDuLieu;
        private System.Windows.Forms.DateTimePicker dtDTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgvData;
        private System.Windows.Forms.Panel panelBottom;
        public System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblTotalCaption;
    }
}