﻿namespace QuanLyCafe
{
    partial class frmHienThiHoaDon
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.rtbCustomer = new System.Windows.Forms.RichTextBox();
            this.rtbStaff = new System.Windows.Forms.RichTextBox();
            this.rtbDate = new System.Windows.Forms.RichTextBox();
            this.rtbPaymentDate = new System.Windows.Forms.RichTextBox();
            this.dtgvDetails = new System.Windows.Forms.DataGridView();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalCaption = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblThanks = new System.Windows.Forms.Label();
            this.lblShopName = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDetails)).BeginInit();
            this.pnlTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.lblThanks);
            this.pnlMain.Controls.Add(this.btnClose);
            this.pnlMain.Controls.Add(this.pnlTotal);
            this.pnlMain.Controls.Add(this.dtgvDetails);
            this.pnlMain.Controls.Add(this.lblShopName);
            this.pnlMain.Controls.Add(this.rtbDate);
            this.pnlMain.Controls.Add(this.rtbPaymentDate);
            this.pnlMain.Controls.Add(this.rtbStaff);
            this.pnlMain.Controls.Add(this.rtbCustomer);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(5, 5);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(432, 551);
            this.pnlMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.lblTitle.Size = new System.Drawing.Size(432, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HÓA ĐƠN THANH TOÁN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtbCustomer
            // 
            this.rtbCustomer.BackColor = System.Drawing.Color.White;
            this.rtbCustomer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rtbCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(59)))), ((int)(((byte)(46)))));
            this.rtbCustomer.Location = new System.Drawing.Point(20, 100);
            this.rtbCustomer.Name = "rtbCustomer";
            this.rtbCustomer.ReadOnly = true;
            this.rtbCustomer.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbCustomer.Size = new System.Drawing.Size(392, 24);
            this.rtbCustomer.TabIndex = 11;
            this.rtbCustomer.Text = "Khách hàng:";
            // 
            // rtbStaff
            // 
            this.rtbStaff.BackColor = System.Drawing.Color.White;
            this.rtbStaff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbStaff.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rtbStaff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(59)))), ((int)(((byte)(46)))));
            this.rtbStaff.Location = new System.Drawing.Point(20, 125);
            this.rtbStaff.Name = "rtbStaff";
            this.rtbStaff.ReadOnly = true;
            this.rtbStaff.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbStaff.Size = new System.Drawing.Size(392, 24);
            this.rtbStaff.TabIndex = 12;
            this.rtbStaff.Text = "Người lập:";
            // 
            // rtbDate
            // 
            this.rtbDate.BackColor = System.Drawing.Color.White;
            this.rtbDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rtbDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(59)))), ((int)(((byte)(46)))));
            this.rtbDate.Location = new System.Drawing.Point(20, 150);
            this.rtbDate.Name = "rtbDate";
            this.rtbDate.ReadOnly = true;
            this.rtbDate.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbDate.Size = new System.Drawing.Size(392, 24);
            this.rtbDate.TabIndex = 13;
            this.rtbDate.Text = "Thời gian tạo:";
            // 
            // rtbPaymentDate
            // 
            this.rtbPaymentDate.BackColor = System.Drawing.Color.White;
            this.rtbPaymentDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbPaymentDate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rtbPaymentDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(59)))), ((int)(((byte)(46)))));
            this.rtbPaymentDate.Location = new System.Drawing.Point(20, 175);
            this.rtbPaymentDate.Name = "rtbPaymentDate";
            this.rtbPaymentDate.ReadOnly = true;
            this.rtbPaymentDate.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbPaymentDate.Size = new System.Drawing.Size(392, 24);
            this.rtbPaymentDate.TabIndex = 14;
            this.rtbPaymentDate.Text = "Thời gian thanh toán:";
            // 
            // dtgvDetails
            // 
            this.dtgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDetails.Location = new System.Drawing.Point(20, 210);
            this.dtgvDetails.Name = "dtgvDetails";
            this.dtgvDetails.RowHeadersWidth = 51;
            this.dtgvDetails.Size = new System.Drawing.Size(392, 210);
            this.dtgvDetails.TabIndex = 4;
            // 
            // pnlTotal
            // 
            this.pnlTotal.Controls.Add(this.lblTotalAmount);
            this.pnlTotal.Controls.Add(this.lblTotalCaption);
            this.pnlTotal.Location = new System.Drawing.Point(20, 430);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(392, 40);
            this.pnlTotal.TabIndex = 5;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(120, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(272, 40);
            this.lblTotalAmount.TabIndex = 1;
            this.lblTotalAmount.Text = "0 VNĐ";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalCaption
            // 
            this.lblTotalCaption.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTotalCaption.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.lblTotalCaption.Location = new System.Drawing.Point(0, 0);
            this.lblTotalCaption.Name = "lblTotalCaption";
            this.lblTotalCaption.Size = new System.Drawing.Size(120, 40);
            this.lblTotalCaption.TabIndex = 0;
            this.lblTotalCaption.Text = "TỔNG CỘNG:";
            this.lblTotalCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(59)))), ((int)(((byte)(46)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(166, 500);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // lblThanks
            // 
            this.lblThanks.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic);
            this.lblThanks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(59)))), ((int)(((byte)(46)))));
            this.lblThanks.Location = new System.Drawing.Point(20, 473);
            this.lblThanks.Name = "lblThanks";
            this.lblThanks.Size = new System.Drawing.Size(392, 23);
            this.lblThanks.TabIndex = 7;
            this.lblThanks.Text = "Cảm ơn quý khách!";
            this.lblThanks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShopName
            // 
            this.lblShopName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblShopName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblShopName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.lblShopName.Location = new System.Drawing.Point(0, 60);
            this.lblShopName.Name = "lblShopName";
            this.lblShopName.Size = new System.Drawing.Size(432, 30);
            this.lblShopName.TabIndex = 10;
            this.lblShopName.Text = "GEMINI CAFE";
            this.lblShopName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmHienThiHoaDon
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.ClientSize = new System.Drawing.Size(442, 561);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHienThiHoaDon";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hóa Đơn";
            this.Load += new System.EventHandler(this.frmHienThiHoaDon_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDetails)).EndInit();
            this.pnlTotal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RichTextBox rtbCustomer;
        private System.Windows.Forms.RichTextBox rtbStaff;
        private System.Windows.Forms.RichTextBox rtbDate;
        private System.Windows.Forms.RichTextBox rtbPaymentDate;
        private System.Windows.Forms.DataGridView dtgvDetails;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalCaption;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblThanks;
        private System.Windows.Forms.Label lblShopName;
    }
}