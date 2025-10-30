﻿using System;
using System.Drawing;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace QuanLyCafe
{
    [SupportedOSPlatform("windows")]
    public partial class frmCanhBao : Form
    {
        public frmCanhBao(string message)
        {
            InitializeComponent();
            lblContent.Text = message;
        }

        private void frmCanhBao_Load(object sender, EventArgs e)
        {
            // Vị trí xuất hiện ở góc dưới bên phải màn hình
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - this.Width - 10,
                                      workingArea.Bottom - this.Height - 10);

            // Bắt đầu timer để tự động đóng
            tmrAutoClose.Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmrAutoClose_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}