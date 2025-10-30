﻿// frmHangBanChay.Designer.cs
namespace QuanLyCafe
{
    partial class frmHangBanChay
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnThanhToan = new System.Windows.Forms.Button();
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
            this.panelTop.Controls.Add(this.btnThanhToan);
            this.panelTop.Controls.Add(this.dtDTo);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.dtDFrom);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelTop.Size = new System.Drawing.Size(1000, 60);
            this.panelTop.TabIndex = 0;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThanhToan.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(835, 12);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(145, 36);
            this.btnThanhToan.TabIndex = 4;
            this.btnThanhToan.Text = "Lọc dữ liệu";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // dtDTo
            // 
            this.dtDTo.CustomFormat = "dd/MM/yyyy";
            this.dtDTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDTo.Location = new System.Drawing.Point(455, 18);
            this.dtDTo.Name = "dtDTo";
            this.dtDTo.Size = new System.Drawing.Size(150, 29);
            this.dtDTo.TabIndex = 3;
            this.dtDTo.ValueChanged += new System.EventHandler(this.dtDTo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(385, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến ngày";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dtDFrom
            // 
            this.dtDFrom.CustomFormat = "dd/MM/yyyy";
            this.dtDFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDFrom.Location = new System.Drawing.Point(95, 18);
            this.dtDFrom.Name = "dtDFrom";
            this.dtDFrom.Size = new System.Drawing.Size(150, 29);
            this.dtDFrom.TabIndex = 1;
            this.dtDFrom.ValueChanged += new System.EventHandler(this.dtDFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày";
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            this.dtgvData.Size = new System.Drawing.Size(1000, 470);
            this.dtgvData.TabIndex = 1;
            this.dtgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvData_CellContentClick);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.SystemColors.Control;
            this.panelBottom.Controls.Add(this.lblTongTien);
            this.panelBottom.Controls.Add(this.lblTotalCaption);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 530);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1000, 40);
            this.panelBottom.TabIndex = 2;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.Red;
            this.lblTongTien.Location = new System.Drawing.Point(782, 6);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(74, 28);
            this.lblTongTien.TabIndex = 1;
            this.lblTongTien.Text = "0 VNĐ";
            this.lblTongTien.Click += new System.EventHandler(this.lblTongTien_Click);
            // 
            // lblTotalCaption
            // 
            this.lblTotalCaption.AutoSize = true;
            this.lblTotalCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalCaption.Location = new System.Drawing.Point(693, 6);
            this.lblTotalCaption.Name = "lblTotalCaption";
            this.lblTotalCaption.Size = new System.Drawing.Size(74, 28);
            this.lblTotalCaption.TabIndex = 0;
            this.lblTotalCaption.Text = "TỔNG:";
            // 
            // frmHangBanChay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 570);
            this.Controls.Add(this.dtgvData);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.MinimumSize = new System.Drawing.Size(820, 480);
            this.Name = "frmHangBanChay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Top hàng bán chạy";
            this.Load += new System.EventHandler(this.frmHangBanChay_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvData)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnThanhToan;
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
