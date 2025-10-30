using System;
using System.Drawing;
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

        #region Hover Effects
        private void btnThem_MouseEnter(object sender, EventArgs e)
        {
            btnThem.BackColor = Color.FromArgb(76, 175, 80); // #4CAF50
        }

        private void btnThem_MouseLeave(object sender, EventArgs e)
        {
            btnThem.BackColor = Color.FromArgb(62, 142, 65); // #3E8E41
        }

        private void btnHuy_MouseEnter(object sender, EventArgs e)
        {
            btnHuy.BackColor = Color.FromArgb(161, 136, 127); // #A1887F
        }

        private void btnHuy_MouseLeave(object sender, EventArgs e)
        {
            btnHuy.BackColor = Color.FromArgb(188, 170, 164); // #BCAAA4
        }
        #endregion
    }
}