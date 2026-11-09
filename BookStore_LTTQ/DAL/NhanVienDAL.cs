using System;
using System.Data;
using System.Data.SqlClient;
using BookStore_LTTQ.DTO;

namespace BookStore_LTTQ.DAL
{
    public class NhanVienDAL
    {
        public DataTable GetAllNhanVien()
        {
            string query = @"SELECT MaNV, TenNV, NamSinh, 
                                     CASE WHEN GioiTinh = 'M' THEN N'Nam' ELSE N'Nữ' END AS GioiTinhHienThi,
                                     GioiTinh, DiaChi, DienThoai, LuongThang
                              FROM tNhanVien";
            return DataProcess.DocBang(query);
        }

        public DataTable GetCaLam() => DataProcess.DocBang("SELECT MaCa, TenCa FROM tCaLam");

        public string GenerateNewMaNV()
        {
            object newMa = DataProcess.LayGiaTri("DECLARE @Ma CHAR(6); EXEC SP_GenerateNewMaNV @Ma OUTPUT; SELECT @Ma;");
            return newMa != null ? newMa.ToString().Trim() : "NV0004";
        }

        public bool KiemTraNhanVienDaLapPhieu(string maNV)
        {
            object cnt = DataProcess.LayGiaTri("SELECT COUNT(*) FROM tThueSach WHERE MaNV = @MaNV",
                new SqlParameter[] { new SqlParameter("@MaNV", maNV) });
            return cnt != null && Convert.ToInt32(cnt) > 0;
        }

        public bool InsertNhanVien(NhanVienDTO nv)
        {
            string sql = @"INSERT INTO tNhanVien (MaNV, TenNV, NamSinh, GioiTinh, DiaChi, DienThoai, LuongThang)
                           VALUES (@MaNV, @TenNV, @NamSinh, @GioiTinh, @DiaChi, @DienThoai, @LuongThang)";
            SqlParameter[] p = {
                new SqlParameter("@MaNV", nv.MaNV ?? (object)DBNull.Value),
                new SqlParameter("@TenNV", nv.TenNV ?? (object)DBNull.Value),
                new SqlParameter("@NamSinh", nv.NamSinh.HasValue ? (object)nv.NamSinh.Value : DBNull.Value),
                new SqlParameter("@GioiTinh", nv.GioiTinh ?? (object)DBNull.Value),
                new SqlParameter("@DiaChi", nv.DiaChi ?? (object)DBNull.Value),
                new SqlParameter("@DienThoai", nv.DienThoai ?? (object)DBNull.Value),
                new SqlParameter("@LuongThang", nv.LuongThang.HasValue ? (object)nv.LuongThang.Value : DBNull.Value)
            };
            return DataProcess.ThucThiLenh(sql, p) > 0;
        }

        public bool UpdateNhanVien(NhanVienDTO nv)
        {
            string sql = @"UPDATE tNhanVien 
                           SET TenNV = @TenNV, NamSinh = @NamSinh, GioiTinh = @GioiTinh, 
                               DiaChi = @DiaChi, DienThoai = @DienThoai, LuongThang = @LuongThang
                           WHERE MaNV = @MaNV";
            SqlParameter[] p = {
                new SqlParameter("@MaNV", nv.MaNV ?? (object)DBNull.Value),
                new SqlParameter("@TenNV", nv.TenNV ?? (object)DBNull.Value),
                new SqlParameter("@NamSinh", nv.NamSinh.HasValue ? (object)nv.NamSinh.Value : DBNull.Value),
                new SqlParameter("@GioiTinh", nv.GioiTinh ?? (object)DBNull.Value),
                new SqlParameter("@DiaChi", nv.DiaChi ?? (object)DBNull.Value),
                new SqlParameter("@DienThoai", nv.DienThoai ?? (object)DBNull.Value),
                new SqlParameter("@LuongThang", nv.LuongThang.HasValue ? (object)nv.LuongThang.Value : DBNull.Value)
            };
            return DataProcess.ThucThiLenh(sql, p) > 0;
        }

        public bool DeleteNhanVien(string maNV)
        {
            string sql = "DELETE FROM tNhanVien WHERE MaNV = @MaNV";
            return DataProcess.ThucThiLenh(sql, new SqlParameter[] { new SqlParameter("@MaNV", maNV) }) > 0;
        }

        public DataTable TimKiemNhanVien(string ten, string maCa, string gioiTinh)
        {
            SqlParameter[] p = {
                new SqlParameter("@TenNV", string.IsNullOrEmpty(ten) ? (object)DBNull.Value : ten),
                new SqlParameter("@MaCa", string.IsNullOrEmpty(maCa) ? (object)DBNull.Value : maCa),
                new SqlParameter("@GioiTinh", string.IsNullOrEmpty(gioiTinh) ? (object)DBNull.Value : gioiTinh)
            };
            return DataProcess.ExecProcedure("SP_TimNhanVien", p);
        }
    }
}

