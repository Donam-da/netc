﻿﻿﻿namespace QuanLyCafe
{
    partial class frmHienThiHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                _watermarkLogo?.Dispose();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
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
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(5, 5);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(432, 551);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
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
            // dtgvDetails
            // 
            this.dtgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvDetails.BackgroundColor = System.Drawing.Color.White;
            this.dtgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDetails.Location = new System.Drawing.Point(20, 225);
            this.dtgvDetails.Name = "dtgvDetails";
            this.dtgvDetails.RowHeadersWidth = 51;
            this.dtgvDetails.Size = new System.Drawing.Size(392, 210);
            this.dtgvDetails.TabIndex = 4;
            this.dtgvDetails.Visible = false;
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
            this.lblShopName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dtgvDetails;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalCaption;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblThanks;
        private System.Windows.Forms.Label lblShopName;
    } // This closing brace might be incorrect depending on the exact state of your file.
}