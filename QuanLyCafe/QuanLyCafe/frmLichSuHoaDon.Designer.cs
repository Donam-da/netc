﻿﻿﻿﻿﻿namespace QuanLyCafe
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    partial class frmLichSuHoaDon
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnLocDuLieu = new System.Windows.Forms.Button();
            this.dtDTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtDFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dtgvHD = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dtgvCTHD = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCTHD)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(233)))), ((int)(((byte)(208)))));
            this.pnlTop.Controls.Add(this.btnLocDuLieu);
            this.pnlTop.Controls.Add(this.dtDTo);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.dtDFrom);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTop.Size = new System.Drawing.Size(1084, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // btnLocDuLieu
            // 
            this.btnLocDuLieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLocDuLieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(59)))), ((int)(((byte)(46)))));
            this.btnLocDuLieu.FlatAppearance.BorderSize = 0;
            this.btnLocDuLieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocDuLieu.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnLocDuLieu.ForeColor = System.Drawing.Color.White;
            this.btnLocDuLieu.Location = new System.Drawing.Point(927, 12);
            this.btnLocDuLieu.Name = "btnLocDuLieu";
            this.btnLocDuLieu.Size = new System.Drawing.Size(145, 36);
            this.btnLocDuLieu.TabIndex = 584;
            this.btnLocDuLieu.Text = "Lọc dữ liệu";
            this.btnLocDuLieu.UseVisualStyleBackColor = false;
            this.btnLocDuLieu.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // dtDTo
            // 
            this.dtDTo.CustomFormat = "dd/MM/yyyy";
            this.dtDTo.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(85)))), ((int)(((byte)(72)))));
            this.dtDTo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtDTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDTo.Location = new System.Drawing.Point(369, 16);
            this.dtDTo.Name = "dtDTo";
            this.dtDTo.Size = new System.Drawing.Size(150, 29);
            this.dtDTo.TabIndex = 582;
            this.dtDTo.ValueChanged += new System.EventHandler(this.dtDTo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.label2.Location = new System.Drawing.Point(280, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 23);
            this.label2.TabIndex = 583;
            this.label2.Text = "Đến ngày";
            // 
            // dtDFrom
            // 
            this.dtDFrom.CustomFormat = "dd/MM/yyyy";
            this.dtDFrom.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(85)))), ((int)(((byte)(72)))));
            this.dtDFrom.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtDFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDFrom.Location = new System.Drawing.Point(99, 16);
            this.dtDFrom.Name = "dtDFrom";
            this.dtDFrom.Size = new System.Drawing.Size(150, 29);
            this.dtDFrom.TabIndex = 580;
            this.dtDFrom.ValueChanged += new System.EventHandler(this.dtDFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 581;
            this.label1.Text = "Từ ngày";
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
            this.splitContainer1.Panel1.Controls.Add(this.dtgvHD);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dtgvCTHD);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.splitContainer1.Size = new System.Drawing.Size(1084, 601);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 1;
            // 
            // dtgvHD
            // 
            this.dtgvHD.AllowUserToAddRows = false;
            this.dtgvHD.AllowUserToDeleteRows = false;
            this.dtgvHD.AllowUserToResizeRows = false;
            this.dtgvHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvHD.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.dtgvHD.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(170)))), ((int)(((byte)(164)))));
            this.dtgvHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvHD.Location = new System.Drawing.Point(10, 28);
            this.dtgvHD.MultiSelect = false;
            this.dtgvHD.Name = "dtgvHD";
            this.dtgvHD.ReadOnly = true;
            this.dtgvHD.RowHeadersVisible = false;
            this.dtgvHD.RowHeadersWidth = 51;
            this.dtgvHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvHD.Size = new System.Drawing.Size(1064, 267);
            this.dtgvHD.TabIndex = 581;
            this.dtgvHD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvHD_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.label3.Location = new System.Drawing.Point(10, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label3.Size = new System.Drawing.Size(163, 28);
            this.label3.TabIndex = 582;
            this.label3.Text = "Danh sách hóa đơn";
            // 
            // dtgvCTHD
            // 
            this.dtgvCTHD.AllowUserToAddRows = false;
            this.dtgvCTHD.AllowUserToDeleteRows = false;
            this.dtgvCTHD.AllowUserToResizeRows = false;
            this.dtgvCTHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvCTHD.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.dtgvCTHD.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(170)))), ((int)(((byte)(164)))));
            this.dtgvCTHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCTHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvCTHD.Location = new System.Drawing.Point(10, 33);
            this.dtgvCTHD.MultiSelect = false;
            this.dtgvCTHD.Name = "dtgvCTHD";
            this.dtgvCTHD.ReadOnly = true;
            this.dtgvCTHD.RowHeadersVisible = false;
            this.dtgvCTHD.RowHeadersWidth = 51;
            this.dtgvCTHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvCTHD.Size = new System.Drawing.Size(1064, 254);
            this.dtgvCTHD.TabIndex = 582;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.label4.Location = new System.Drawing.Point(10, 5);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label4.Size = new System.Drawing.Size(217, 28);
            this.label4.TabIndex = 583;
            this.label4.Text = "Chi tiết hóa đơn đã chọn";
            // 
            // frmLichSuHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(233)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(820, 600);
            this.Name = "frmLichSuHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch sử hóa đơn";
            this.Load += new System.EventHandler(this.frmLichSuHoaDon_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCTHD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnLocDuLieu;
        private System.Windows.Forms.DateTimePicker dtDTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtDFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dtgvHD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dtgvCTHD;
        private System.Windows.Forms.Label label4;
    }
}