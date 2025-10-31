namespace QuanLyCafe
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
            this.dtgvData = new System.Windows.Forms.DataGridView();
            this.dtgvLichSuMuaHang = new System.Windows.Forms.DataGridView();
            this.lblLichSu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLichSuMuaHang)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.dtgvData);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dtgvLichSuMuaHang);
            this.splitContainer1.Panel2.Controls.Add(this.lblLichSu);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.splitContainer1.Size = new System.Drawing.Size(999, 554);
            this.splitContainer1.SplitterDistance = 270;
            this.splitContainer1.TabIndex = 3;
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
            this.dtgvData.Location = new System.Drawing.Point(10, 10);
            this.dtgvData.MultiSelect = false;
            this.dtgvData.Name = "dtgvData";
            this.dtgvData.ReadOnly = true;
            this.dtgvData.RowHeadersVisible = false;
            this.dtgvData.RowHeadersWidth = 51;
            this.dtgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvData.Size = new System.Drawing.Size(979, 255);
            this.dtgvData.TabIndex = 2;
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
            this.dtgvLichSuMuaHang.Location = new System.Drawing.Point(10, 33);
            this.dtgvLichSuMuaHang.MultiSelect = false;
            this.dtgvLichSuMuaHang.Name = "dtgvLichSuMuaHang";
            this.dtgvLichSuMuaHang.ReadOnly = true;
            this.dtgvLichSuMuaHang.RowHeadersVisible = false;
            this.dtgvLichSuMuaHang.RowHeadersWidth = 51;
            this.dtgvLichSuMuaHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvLichSuMuaHang.Size = new System.Drawing.Size(979, 237);
            this.dtgvLichSuMuaHang.TabIndex = 1;
            // 
            // lblLichSu
            // 
            this.lblLichSu.AutoSize = true;
            this.lblLichSu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLichSu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblLichSu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.lblLichSu.Location = new System.Drawing.Point(10, 5);
            this.lblLichSu.Name = "lblLichSu";
            this.lblLichSu.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lblLichSu.Size = new System.Drawing.Size(155, 28);
            this.lblLichSu.TabIndex = 0;
            this.lblLichSu.Text = "Lịch sử mua hàng:";
            // 
            // frmKhachHangThanThiet
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
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLichSuMuaHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dtgvData;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dtgvLichSuMuaHang;
        private System.Windows.Forms.Label lblLichSu;
    }
}