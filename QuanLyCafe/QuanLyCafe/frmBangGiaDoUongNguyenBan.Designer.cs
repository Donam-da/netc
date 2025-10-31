namespace QuanLyCafe
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    partial class frmBangGiaDoUongNguyenBan
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
            this.btnLuuThayDoi = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dtgvGiaGoc = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvGiaGoc)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(233)))), ((int)(((byte)(208)))));
            this.pnlTop.Controls.Add(this.btnLuuThayDoi);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTop.Size = new System.Drawing.Size(800, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // btnLuuThayDoi
            // 
            this.btnLuuThayDoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuThayDoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(142)))), ((int)(((byte)(65)))));
            this.btnLuuThayDoi.FlatAppearance.BorderSize = 0;
            this.btnLuuThayDoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuThayDoi.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLuuThayDoi.ForeColor = System.Drawing.Color.White;
            this.btnLuuThayDoi.Location = new System.Drawing.Point(640, 10);
            this.btnLuuThayDoi.Name = "btnLuuThayDoi";
            this.btnLuuThayDoi.Size = new System.Drawing.Size(150, 40);
            this.btnLuuThayDoi.TabIndex = 1;
            this.btnLuuThayDoi.Text = "Lưu Thay Đổi";
            this.btnLuuThayDoi.UseVisualStyleBackColor = false;
            this.btnLuuThayDoi.Click += new System.EventHandler(this.btnLuuThayDoi_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSearch.Location = new System.Drawing.Point(13, 13);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(611, 34);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dtgvGiaGoc
            // 
            this.dtgvGiaGoc.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(240)))));
            this.dtgvGiaGoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvGiaGoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvGiaGoc.Location = new System.Drawing.Point(0, 60);
            this.dtgvGiaGoc.Name = "dtgvGiaGoc";
            this.dtgvGiaGoc.RowHeadersWidth = 51;
            this.dtgvGiaGoc.RowTemplate.Height = 24;
            this.dtgvGiaGoc.Size = new System.Drawing.Size(800, 390);
            this.dtgvGiaGoc.TabIndex = 1;
            // 
            // frmBangGiaDoUongNguyenBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtgvGiaGoc);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmBangGiaDoUongNguyenBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng giá Đồ uống Nhập";
            this.Load += new System.EventHandler(this.frmBangGiaDoUongNguyenBan_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvGiaGoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnLuuThayDoi;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dtgvGiaGoc;
    }
}