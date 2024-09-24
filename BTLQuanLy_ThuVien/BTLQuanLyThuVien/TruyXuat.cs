using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLQuanLyThuVien
{
    internal class TruyXuat
    {
        private static string DuongDan = @"Data Source=HUYPHUNG-95;Initial Catalog=dbqlthuvien;Integrated Security=True";
        public static SqlConnection TaoKetNoi()
        {
            return new SqlConnection(DuongDan);
        }
        public static DataTable GetTable(string sql)
        {
            SqlConnection con = TaoKetNoi();
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            DataTable b = new DataTable();
            ad.Fill(b);
            con.Close();
            ad.Dispose();
            return b;
        }
        public static void ThemSuaXoa(string sql)
        {
            SqlConnection con = TaoKetNoi();
            con.Open();
            SqlCommand Lenh = new SqlCommand(sql, con);
            Lenh.ExecuteNonQuery();
            con.Close();
            Lenh.Dispose();
        }

        public static string LayMotGiaTri(string sql)
        {
            SqlConnection KetNoi = TaoKetNoi();
            KetNoi.Open();
            SqlCommand lenh = new SqlCommand(sql, KetNoi);
            object KetQua = lenh.ExecuteScalar();
            KetNoi.Close();
            lenh.Dispose();
            if
                (KetQua == null)
                return "";
            else return KetQua.ToString();
        }
    }
}
