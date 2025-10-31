﻿﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe
{
    public class ConnectSQL
    {
        // Chuỗi kết nối được định nghĩa ở một nơi duy nhất.
        private static string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyCafe;Integrated Security=True";

        // Phương thức này không còn cần thiết và nên được loại bỏ để tránh nhầm lẫn.
        // private static SqlConnection GetConnection()
        // {
        //     return new SqlConnection(connectionString);
        // }

        // Các biến và phương thức quản lý kết nối thủ công (Open/Close) nên được loại bỏ
        // vì chúng không an toàn. Mỗi phương thức nên tự quản lý kết nối của riêng nó.
        // private static SqlConnection cnn;
        // public static void OpenConnection() { ... }
        // public static void CloseConnection() { ... }

        // Hàm chạy lệnh SQL lấy dữ liệu (SELECT) - Đã được cải tiến để chống SQL Injection.
        public static DataTable Load(string sql, Dictionary<string, object>? parameters = null)
        {
            DataTable dt = new DataTable();
            // 'using' đảm bảo kết nối được đóng ngay cả khi có lỗi.
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // Hàm chạy lệnh SQL (INSERT, UPDATE, DELETE) - Đã được cải tiến để chống SQL Injection.
        public static int RunQuery(string sql, Dictionary<string, object>? parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }
                    return cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                }
            }
        }

        // Phương thức kiểm tra sự tồn tại của dữ liệu - Đã được cải tiến.
        public static bool ExcuteReader_bool(string sql, Dictionary<string, object>? parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        return dr.HasRows; // .HasRows là cách kiểm tra hiệu quả hơn.
                    }
                }
            }
        }

        // Phương thức trả về 1 giá trị duy nhất - Đã được cải tiến.
        public static object? ExecuteScalar(string sql, Dictionary<string, object>? parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static void CapNhatTonKhoKhiGoiMon(string maDU, decimal soLuongBan)
        {
            // Lấy thông tin đồ uống để biết là đồ pha chế hay nguyên bản
            string sqlGetDrinkInfo = "SELECT IsPhaChe FROM DoUong WHERE MaDU = @MaDU";
            var result = ExecuteScalar(sqlGetDrinkInfo, new Dictionary<string, object> { { "@MaDU", maDU } });

            if (result != null && result != DBNull.Value)
            {
                bool isPhaChe = Convert.ToBoolean(result);

                if (isPhaChe)
                {
                    // Nếu là đồ pha chế, trừ tồn kho của các nguyên liệu trong công thức
                    string sqlUpdateNguyenLieu = @"
                        UPDATE NguyenLieu
                        SET SoLuongTon = SoLuongTon - (ct.SoLuong * @SoLuongBan)
                        FROM NguyenLieu
                        INNER JOIN CongThuc ct ON NguyenLieu.MaNL = ct.MaNL
                        WHERE ct.MaDU = @MaDU";

                    RunQuery(sqlUpdateNguyenLieu, new Dictionary<string, object> { { "@SoLuongBan", soLuongBan }, { "@MaDU", maDU } });
                }
                else
                {
                    // Nếu là đồ uống nguyên bản, chỉ trừ tồn kho của chính đồ uống đó
                    string sqlUpdateDoUong = "UPDATE DoUong SET SoLuongTon = SoLuongTon - @SoLuongBan WHERE MaDU = @MaDU AND IsPhaChe = 0";
                    RunQuery(sqlUpdateDoUong, new Dictionary<string, object> { { "@SoLuongBan", soLuongBan }, { "@MaDU", maDU } });
                }
            }
        }

        public static void CapNhatTonKhoKhiXoaMon(string maDU, decimal soLuongHuy)
        {
            // Hàm này hoạt động ngược lại với CapNhatTonKhoKhiGoiMon, tức là cộng trả lại số lượng
            CapNhatTonKhoKhiGoiMon(maDU, -soLuongHuy);
        }

        public static void CapNhatTonKhoKhiSuaSoLuong(string maDU, decimal soLuongCu, decimal soLuongMoi)
        {
            // Tính toán chênh lệch và cập nhật
            decimal chenhLech = soLuongMoi - soLuongCu;
            if (chenhLech != 0)
            {
                CapNhatTonKhoKhiGoiMon(maDU, chenhLech);
            }
        }

        /// <summary>
        /// Cập nhật tồn kho cho đồ uống và nguyên liệu sau khi một hóa đơn được thanh toán.
        /// </summary>
        /// <param name="maHD">Mã hóa đơn vừa được thanh toán.</param>
        // This method is no longer needed as inventory is updated in real-time.
        // public static void CapNhatTonKhoSauThanhToan(string maHD) { ... }
    }
}
