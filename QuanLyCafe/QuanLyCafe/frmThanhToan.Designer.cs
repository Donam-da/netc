namespace QuanLyCafe
{
    partial class frmThanhToan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThanhToan));
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.menuTimKiem = new System.Windows.Forms.Button();
            this.dtgvData = new System.Windows.Forms.DataGridView();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Location = new System.Drawing.Point(131, 38);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(484, 21);
            this.txtDiaChi.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 54;
            this.label3.Text = "Địa chỉ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(363, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 16);
            this.label4.TabIndex = 52;
            this.label4.Text = "Số điện thoại";
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(465, 11);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(150, 21);
            this.txtSDT.TabIndex = 53;
            // 
            // menuTimKiem
            // 
            this.menuTimKiem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("menuTimKiem.Image")));
            this.menuTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuTimKiem.Location = new System.Drawing.Point(305, 75);
            this.menuTimKiem.Name = "menuTimKiem";
            this.menuTimKiem.Size = new System.Drawing.Size(105, 34);
            this.menuTimKiem.TabIndex = 50;
            this.menuTimKiem.Text = "Tìm kiếm";
            this.menuTimKiem.UseVisualStyleBackColor = true;
            this.menuTimKiem.Click += new System.EventHandler(this.menuTimKiem_Click);
            // 
            // dtgvData
            // 
            this.dtgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvData.Location = new System.Drawing.Point(1, 120);
            this.dtgvData.Name = "dtgvData";
            this.dtgvData.Size = new System.Drawing.Size(636, 289);
            this.dtgvData.TabIndex = 47;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKH.Location = new System.Drawing.Point(131, 11);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(150, 21);
            this.txtTenKH.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 45;
            this.label2.Text = "Tên khách hàng";
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemMoi.Location = new System.Drawing.Point(198, 75);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(105, 34);
            this.btnThemMoi.TabIndex = 56;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(491, 415);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(146, 30);
            this.btnThanhToan.TabIndex = 573;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // frmThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(637, 450);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.btnThemMoi);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.menuTimKiem);
            this.Controls.Add(this.dtgvData);
            this.Controls.Add(this.txtTenKH);
            this.Controls.Add(this.label2);
            this.Name = "frmThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh toán hóa đơn";
            this.Load += new System.EventHandler(this.frmThanhToan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Button menuTimKiem;
        private System.Windows.Forms.DataGridView dtgvData;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Button btnThanhToan;
    }
}