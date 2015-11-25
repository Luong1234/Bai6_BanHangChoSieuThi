using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace BusinessLogic
{
    public class NhanVien
    {
        KetNoiDB da = new KetNoiDB();

        public DataTable HienThiNhanVien()
        {
            string sql = "SELECT * FROM NHANVIEN";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            return dt;
        }

        public void ThemNhanVien(string TenDn, string MatKhau, string TenNV, string GT, string DiaChi, string SDT)
        {
            string sql = "ADDNhanVien";
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TenDn",TenDn);
            cmd.Parameters.AddWithValue("@MatKhau", MatKhau);
            cmd.Parameters.AddWithValue("@TenNV", TenNV);
            cmd.Parameters.AddWithValue("@GT",GT);
            cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
            cmd.Parameters.AddWithValue("@SDT", SDT);
           
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void SuaNhanVien(string MaNV,string TenDn, string MatKhau, string TenNV, string GT, string DiaChi, string SDT)
        {
            string sql = "SuaNhanVien";
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaNV", MaNV);
            cmd.Parameters.AddWithValue("@TenDn", TenDn);
            cmd.Parameters.AddWithValue("@MatKhau", MatKhau);
            cmd.Parameters.AddWithValue("@TenNV", TenNV);
            cmd.Parameters.AddWithValue("@GT", GT);
            cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
            cmd.Parameters.AddWithValue("@SDT", SDT);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void XoaNhanVien(string MaNV)
        {
            string sql = "Xoa_NV";
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaNV", MaNV);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
    }
}
