using System;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace QuanLyCafe
{
    [SupportedOSPlatform("windows")]
    public partial class frmChonSoLuong : Form
    {
        public decimal SoLuong { get; private set; } = 1;

        public frmChonSoLuong(string tenDoUong)
        {
            InitializeComponent();
            lblTenDoUong.Text = tenDoUong;
        }

        private void frmChonSoLuong_Load(object sender, EventArgs e)
        {
            // Focus vào numeric up-down và chọn toàn bộ text
            nmSoLuong.Select(0, nmSoLuong.Text.Length);
            nmSoLuong.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.SoLuong = nmSoLuong.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void nmSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            // Cho phép nhấn Enter để thêm
            if (e.KeyCode == Keys.Enter)
            {
                btnThem_Click(sender, e);
                e.SuppressKeyPress = true; // Ngăn tiếng 'beep'
            }
        }
    }
}