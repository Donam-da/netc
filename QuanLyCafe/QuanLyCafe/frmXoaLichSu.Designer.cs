namespace QuanLyCafe
{
    partial class frmXoaLichSu
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabNgay = new System.Windows.Forms.TabPage();
            this.btnXoaTheoNgay = new System.Windows.Forms.Button();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tabThang = new System.Windows.Forms.TabPage();
            this.btnXoaTheoThang = new System.Windows.Forms.Button();
            this.dtpThang = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tabKhoang = new System.Windows.Forms.TabPage();
            this.btnXoaTheoKhoang = new System.Windows.Forms.Button();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXoaToanBo = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabNgay.SuspendLayout();
            this.tabThang.SuspendLayout();
            this.tabKhoang.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabNgay);
            this.tabControl1.Controls.Add(this.tabThang);
            this.tabControl1.Controls.Add(this.tabKhoang);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(10, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(464, 150);
            this.tabControl1.TabIndex = 0;
            // 
            // tabNgay
            // 
            this.tabNgay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(233)))), ((int)(((byte)(208)))));
            this.tabNgay.Controls.Add(this.btnXoaTheoNgay);
            this.tabNgay.Controls.Add(this.dtpNgay);
            this.tabNgay.Controls.Add(this.label1);
            this.tabNgay.Location = new System.Drawing.Point(4, 30);
            this.tabNgay.Name = "tabNgay";
            this.tabNgay.Padding = new System.Windows.Forms.Padding(3);
            this.tabNgay.Size = new System.Drawing.Size(456, 116);
            this.tabNgay.TabIndex = 0;
            this.tabNgay.Text = "Xóa theo Ngày";
            // 
            // btnXoaTheoNgay
            // 
            this.btnXoaTheoNgay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnXoaTheoNgay.FlatAppearance.BorderSize = 0;
            this.btnXoaTheoNgay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTheoNgay.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnXoaTheoNgay.ForeColor = System.Drawing.Color.White;
            this.btnXoaTheoNgay.Location = new System.Drawing.Point(320, 38);
            this.btnXoaTheoNgay.Name = "btnXoaTheoNgay";
            this.btnXoaTheoNgay.Size = new System.Drawing.Size(110, 40);
            this.btnXoaTheoNgay.TabIndex = 2;
            this.btnXoaTheoNgay.Text = "Xóa";
            this.btnXoaTheoNgay.UseVisualStyleBackColor = false;
            this.btnXoaTheoNgay.Click += new System.EventHandler(this.btnXoaTheoNgay_Click);
            // 
            // dtpNgay
            // 
            this.dtpNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgay.Location = new System.Drawing.Point(110, 45);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(180, 29);
            this.dtpNgay.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn ngày:";
            // 
            // tabThang
            // 
            this.tabThang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(233)))), ((int)(((byte)(208)))));
            this.tabThang.Controls.Add(this.btnXoaTheoThang);
            this.tabThang.Controls.Add(this.dtpThang);
            this.tabThang.Controls.Add(this.label3);
            this.tabThang.Location = new System.Drawing.Point(4, 30);
            this.tabThang.Name = "tabThang";
            this.tabThang.Padding = new System.Windows.Forms.Padding(3);
            this.tabThang.Size = new System.Drawing.Size(456, 116);
            this.tabThang.TabIndex = 1;
            this.tabThang.Text = "Xóa theo Tháng";
            // 
            // btnXoaTheoThang
            // 
            this.btnXoaTheoThang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnXoaTheoThang.FlatAppearance.BorderSize = 0;
            this.btnXoaTheoThang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTheoThang.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnXoaTheoThang.ForeColor = System.Drawing.Color.White;
            this.btnXoaTheoThang.Location = new System.Drawing.Point(320, 38);
            this.btnXoaTheoThang.Name = "btnXoaTheoThang";
            this.btnXoaTheoThang.Size = new System.Drawing.Size(110, 40);
            this.btnXoaTheoThang.TabIndex = 5;
            this.btnXoaTheoThang.Text = "Xóa";
            this.btnXoaTheoThang.UseVisualStyleBackColor = false;
            this.btnXoaTheoThang.Click += new System.EventHandler(this.btnXoaTheoThang_Click);
            // 
            // dtpThang
            // 
            this.dtpThang.CustomFormat = "MM/yyyy";
            this.dtpThang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThang.Location = new System.Drawing.Point(125, 45);
            this.dtpThang.Name = "dtpThang";
            this.dtpThang.ShowUpDown = true;
            this.dtpThang.Size = new System.Drawing.Size(165, 29);
            this.dtpThang.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Chọn tháng:";
            // 
            // tabKhoang
            // 
            this.tabKhoang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(233)))), ((int)(((byte)(208)))));
            this.tabKhoang.Controls.Add(this.btnXoaTheoKhoang);
            this.tabKhoang.Controls.Add(this.dtpDenNgay);
            this.tabKhoang.Controls.Add(this.label5);
            this.tabKhoang.Controls.Add(this.dtpTuNgay);
            this.tabKhoang.Controls.Add(this.label4);
            this.tabKhoang.Location = new System.Drawing.Point(4, 30);
            this.tabKhoang.Name = "tabKhoang";
            this.tabKhoang.Size = new System.Drawing.Size(456, 116);
            this.tabKhoang.TabIndex = 2;
            this.tabKhoang.Text = "Xóa theo Khoảng thời gian";
            // 
            // btnXoaTheoKhoang
            // 
            this.btnXoaTheoKhoang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnXoaTheoKhoang.FlatAppearance.BorderSize = 0;
            this.btnXoaTheoKhoang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTheoKhoang.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnXoaTheoKhoang.ForeColor = System.Drawing.Color.White;
            this.btnXoaTheoKhoang.Location = new System.Drawing.Point(320, 38);
            this.btnXoaTheoKhoang.Name = "btnXoaTheoKhoang";
            this.btnXoaTheoKhoang.Size = new System.Drawing.Size(110, 40);
            this.btnXoaTheoKhoang.TabIndex = 6;
            this.btnXoaTheoKhoang.Text = "Xóa";
            this.btnXoaTheoKhoang.UseVisualStyleBackColor = false;
            this.btnXoaTheoKhoang.Click += new System.EventHandler(this.btnXoaTheoKhoang_Click);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(100, 65);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(180, 29);
            this.dtpDenNgay.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Đến ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(100, 20);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(180, 29);
            this.dtpTuNgay.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Từ ngày:";
            // 
            // btnXoaToanBo
            // 
            this.btnXoaToanBo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnXoaToanBo.FlatAppearance.BorderSize = 0;
            this.btnXoaToanBo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaToanBo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaToanBo.ForeColor = System.Drawing.Color.White;
            this.btnXoaToanBo.Location = new System.Drawing.Point(14, 175);
            this.btnXoaToanBo.Name = "btnXoaToanBo";
            this.btnXoaToanBo.Size = new System.Drawing.Size(220, 45);
            this.btnXoaToanBo.TabIndex = 1;
            this.btnXoaToanBo.Text = "Xóa Toàn Bộ Lịch Sử";
            this.btnXoaToanBo.UseVisualStyleBackColor = false;
            this.btnXoaToanBo.Click += new System.EventHandler(this.btnXoaToanBo_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(85)))), ((int)(((byte)(72)))));
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(354, 178);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(110, 40);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmXoaLichSu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(213)))), ((int)(((byte)(183)))));
            this.ClientSize = new System.Drawing.Size(484, 236);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoaToanBo);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmXoaLichSu";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tùy chọn Xóa Lịch sử Giao dịch";
            this.Load += new System.EventHandler(this.frmXoaLichSu_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabNgay.ResumeLayout(false);
            this.tabNgay.PerformLayout();
            this.tabThang.ResumeLayout(false);
            this.tabThang.PerformLayout();
            this.tabKhoang.ResumeLayout(false);
            this.tabKhoang.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabNgay;
        private System.Windows.Forms.TabPage tabThang;
        private System.Windows.Forms.TabPage tabKhoang;
        private System.Windows.Forms.Button btnXoaToanBo;
        private System.Windows.Forms.Button btnXoaTheoNgay;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXoaTheoThang;
        private System.Windows.Forms.DateTimePicker dtpThang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXoaTheoKhoang;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnThoat;
    }
}