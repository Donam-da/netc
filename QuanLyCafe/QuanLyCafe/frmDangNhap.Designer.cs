﻿namespace QuanLyCafe
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    partial class frmDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblSlogan = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.btnThoat = new QuanLyCafe.RoundedButton();
            this.btnDangNhap = new QuanLyCafe.RoundedButton();
            this.lblUsernamePrompt = new System.Windows.Forms.Label();
            this.lblPasswordPrompt = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlUsername = new QuanLyCafe.RoundedPanel();
            this.txtMaDangNhap = new System.Windows.Forms.TextBox();
            this.picUsername = new System.Windows.Forms.PictureBox();
            this.pnlPassword = new QuanLyCafe.RoundedPanel();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.picShowPass = new System.Windows.Forms.PictureBox();
            this.picPassword = new System.Windows.Forms.PictureBox();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlUsername.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUsername)).BeginInit();
            this.pnlPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShowPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.pnlLeft.Controls.Add(this.lblSlogan);
            this.pnlLeft.Controls.Add(this.lblAppName);
            this.pnlLeft.Controls.Add(this.picLogo);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(280, 350);
            this.pnlLeft.TabIndex = 0;
            // 
            // lblSlogan
            // 
            this.lblSlogan.AutoSize = true;
            this.lblSlogan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlogan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.lblSlogan.Location = new System.Drawing.Point(57, 230);
            this.lblSlogan.Name = "lblSlogan";
            this.lblSlogan.Size = new System.Drawing.Size(174, 20);
            this.lblSlogan.TabIndex = 2;
            this.lblSlogan.Text = "Nơi khơi nguồn cảm hứng";
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.lblAppName.Location = new System.Drawing.Point(55, 190);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(201, 38);
            this.lblAppName.TabIndex = 1;
            this.lblAppName.Text = "GEMINI CAFE";
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(70, 45);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(140, 140);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FloralWhite;
            this.pnlRight.Controls.Add(this.btnThoat);
            this.pnlRight.Controls.Add(this.lblPasswordPrompt);
            this.pnlRight.Controls.Add(this.lblUsernamePrompt);
            this.pnlRight.Controls.Add(this.btnDangNhap);
            this.pnlRight.Controls.Add(this.pnlPassword);
            this.pnlRight.Controls.Add(this.pnlUsername);
            this.pnlRight.Controls.Add(this.lblTitle);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(280, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(470, 350);
            this.pnlRight.TabIndex = 1;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.btnThoat.CornerRadius = 15;
            this.btnThoat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.btnThoat.Location = new System.Drawing.Point(250, 280);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(150, 45);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.btnDangNhap.CornerRadius = 15;
            this.btnDangNhap.FlatAppearance.BorderSize = 0;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.Location = new System.Drawing.Point(70, 280);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(150, 45);
            this.btnDangNhap.TabIndex = 3;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // lblUsernamePrompt
            // 
            this.lblUsernamePrompt.AutoSize = true;
            this.lblUsernamePrompt.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernamePrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.lblUsernamePrompt.Location = new System.Drawing.Point(41, 115);
            this.lblUsernamePrompt.Name = "lblUsernamePrompt";
            this.lblUsernamePrompt.Size = new System.Drawing.Size(135, 26);
            this.lblUsernamePrompt.TabIndex = 5;
            this.lblUsernamePrompt.Text = "Tên đăng nhập:";
            // 
            // lblPasswordPrompt
            // 
            this.lblPasswordPrompt.AutoSize = true;
            this.lblPasswordPrompt.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.lblPasswordPrompt.Location = new System.Drawing.Point(41, 195);
            this.lblPasswordPrompt.Name = "lblPasswordPrompt";
            this.lblPasswordPrompt.Size = new System.Drawing.Size(93, 26);
            this.lblPasswordPrompt.TabIndex = 6;
            this.lblPasswordPrompt.Text = "Mật khẩu:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Poppins", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.lblTitle.Location = new System.Drawing.Point(125, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(244, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ĐĂNG NHẬP";
            // 
            // pnlUsername
            // 
            this.pnlUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.pnlUsername.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.pnlUsername.BorderThickness = 0;
            this.pnlUsername.Controls.Add(this.txtMaDangNhap);
            this.pnlUsername.Controls.Add(this.picUsername);
            this.pnlUsername.CornerRadius = 15;
            this.pnlUsername.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(84)))), ((int)(((byte)(75)))));
            this.pnlUsername.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.pnlUsername.Location = new System.Drawing.Point(45, 140);
            this.pnlUsername.Name = "pnlUsername";
            this.pnlUsername.Size = new System.Drawing.Size(380, 45);
            this.pnlUsername.TabIndex = 1;
            // 
            // txtMaDangNhap
            // 
            this.txtMaDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.txtMaDangNhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaDangNhap.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDangNhap.ForeColor = System.Drawing.Color.White;
            this.txtMaDangNhap.Location = new System.Drawing.Point(60, 12);
            this.txtMaDangNhap.Name = "txtMaDangNhap";
            this.txtMaDangNhap.Size = new System.Drawing.Size(279, 30);
            this.txtMaDangNhap.TabIndex = 1;
            this.txtMaDangNhap.Text = "ADMIN";
            // 
            // picUsername
            // 
            this.picUsername.BackColor = System.Drawing.Color.Transparent;
            this.picUsername.Image = ((System.Drawing.Image)(resources.GetObject("picUsername.Image")));
            this.picUsername.Location = new System.Drawing.Point(15, 8);
            this.picUsername.Name = "picUsername";
            this.picUsername.Size = new System.Drawing.Size(30, 30);
            this.picUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUsername.TabIndex = 0;
            this.picUsername.TabStop = false;
            // 
            // pnlPassword
            // 
            this.pnlPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.pnlPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.pnlPassword.BorderThickness = 0;
            this.pnlPassword.Controls.Add(this.txtMatKhau);
            this.pnlPassword.Controls.Add(this.picShowPass);
            this.pnlPassword.Controls.Add(this.picPassword);
            this.pnlPassword.CornerRadius = 15;
            this.pnlPassword.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(84)))), ((int)(((byte)(75)))));
            this.pnlPassword.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.pnlPassword.Location = new System.Drawing.Point(45, 220);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(380, 45);
            this.pnlPassword.TabIndex = 2;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatKhau.Font = new System.Drawing.Font("Poppins", 12F);
            this.txtMatKhau.ForeColor = System.Drawing.Color.White;
            this.txtMatKhau.Location = new System.Drawing.Point(60, 12);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '●';
            this.txtMatKhau.Size = new System.Drawing.Size(279, 30);
            this.txtMatKhau.TabIndex = 2;
            this.txtMatKhau.Text = "123";
            // 
            // picShowPass
            // 
            this.picShowPass.BackColor = System.Drawing.Color.Transparent;
            this.picShowPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picShowPass.Image = ((System.Drawing.Image)(resources.GetObject("picShowPass.Image")));
            this.picShowPass.Location = new System.Drawing.Point(345, 8);
            this.picShowPass.Name = "picShowPass";
            this.picShowPass.Size = new System.Drawing.Size(25, 25);
            this.picShowPass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picShowPass.TabIndex = 3;
            this.picShowPass.TabStop = false;
            this.picShowPass.Click += new System.EventHandler(this.picShowPass_Click);
            // 
            // picPassword
            // 
            this.picPassword.BackColor = System.Drawing.Color.Transparent;
            this.picPassword.Image = ((System.Drawing.Image)(resources.GetObject("picPassword.Image")));
            this.picPassword.Location = new System.Drawing.Point(15, 8);
            this.picPassword.Name = "picPassword";
            this.picPassword.Size = new System.Drawing.Size(30, 30);
            this.picPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPassword.TabIndex = 0;
            this.picPassword.TabStop = false;
            // 
            // frmDangNhap
            // 
            this.AcceptButton = this.btnDangNhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 350);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống";
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlUsername.ResumeLayout(false);
            this.pnlUsername.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUsername)).EndInit();
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShowPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblSlogan;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.PictureBox picPassword;
        private System.Windows.Forms.TextBox txtMaDangNhap;
        private RoundedButton btnDangNhap;
        private RoundedButton btnThoat;
        private System.Windows.Forms.Label lblUsernamePrompt;
        private System.Windows.Forms.Label lblPasswordPrompt;
        private RoundedPanel pnlUsername;
        private RoundedPanel pnlPassword;
        private System.Windows.Forms.PictureBox picUsername;
        private System.Windows.Forms.PictureBox picShowPass;
        private float GradientAngle;
        private System.Drawing.Color GradientEndColor;
        private System.Drawing.Color GradientStartColor;
    }
}
