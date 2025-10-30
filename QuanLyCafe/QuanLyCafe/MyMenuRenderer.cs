﻿using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public class MyMenuRenderer : ToolStripProfessionalRenderer
    {
        public MyMenuRenderer() : base(new MyColors()) { }
    }

    public class MyColors : ProfessionalColorTable
    {
        // Màu nền của menu dropdown
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(203, 165, 126); // Màu be nâu nhạt khi hover
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(203, 165, 126);   // Màu be nâu nhạt khi hover

        // Màu nền của item khi được chọn (hover)
        public override Color MenuItemPressedGradientBegin => Color.FromArgb(245, 233, 208); // Màu kem nền
        public override Color MenuItemPressedGradientEnd => Color.FromArgb(245, 233, 208);   // Màu kem nền

        // Màu nền của toàn bộ menu dropdown
        public override Color ToolStripDropDownBackground => Color.FromArgb(245, 233, 208); // Màu kem nền

        // Màu của vùng chứa icon
        public override Color ImageMarginGradientBegin => Color.FromArgb(245, 233, 208);
        public override Color ImageMarginGradientMiddle => Color.FromArgb(245, 233, 208);
        public override Color ImageMarginGradientEnd => Color.FromArgb(245, 233, 208);

        // Màu viền của item khi hover
        public override Color MenuItemBorder => Color.FromArgb(90, 59, 46); // Màu nâu đậm

        // Bỏ đường kẻ phân cách giữa các item
        public override Color SeparatorLight => Color.Transparent;
        public override Color SeparatorDark => Color.Transparent;
    }
}