using System;
using System.Data;
using System.Data.SqlClient;
using BookStore_LTTQ.DTO;

namespace BookStore_LTTQ.DAL
{
    public class SachDAL
    {
        public DataTable GetAllSach()
        {
            string query = @"SELECT s.MaSach, s.TenSach, l.TenLoai, lv.TenLV, tg.TenTG, nxb.TenNXB, 
                                  nn.TenNN, tt.TenTT, s.SoTrang, s.GiaSach, s.DonGiaThue, 
                                  s.SoLuong, s.Anh, s.GhiChu,
                                  s.MaLoai, s.MaLV, s.MaTG, s.MaNXB, s.MaNN, s.MaTT
                           FROM tSachTruyen s
                           JOIN tLoaiSach l ON s.MaLoai = l.MaLoai
                           JOIN tLinhVuc lv ON s.MaLV = lv.MaLV
                           JOIN tTacGia tg ON s.MaTG = tg.MaTG
                           JOIN tNXB nxb ON s.MaNXB = nxb.MaNXB
                           JOIN tNgonNgu nn ON s.MaNN = nn.MaNN
                           JOIN tTinhTrang tt ON s.MaTT = tt.MaTT";
            return DataProcess.DocBang(query);
        }

        public DataTable GetSachConHang()
        {
            return DataProcess.DocBang("SELECT MaSach, TenSach, SoLuong, DonGiaThue FROM tSachTruyen WHERE SoLuong > 0 ORDER BY TenSach");
        }

        public DataTable GetLoaiSach() => DataProcess.DocBang("SELECT MaLoai, TenLoai FROM tLoaiSach");
        public DataTable GetLinhVuc() => DataProcess.DocBang("SELECT MaLV, TenLV FROM tLinhVuc");
        public DataTable GetTacGia() => DataProcess.DocBang("SELECT MaTG, TenTG FROM tTacGia");
        public DataTable GetNXB() => DataProcess.DocBang("SELECT MaNXB, TenNXB FROM tNXB");
        public DataTable GetNgonNgu() => DataProcess.DocBang("SELECT MaNN, TenNN FROM tNgonNgu");
        public DataTable GetTinhTrang() => DataProcess.DocBang("SELECT MaTT, TenTT FROM tTinhTrang");

        public string GenerateNewMaSach()
        {
            object newMa = DataProcess.LayGiaTri("DECLARE @Ma CHAR(8); EXEC SP_GenerateNewMaSach @Ma OUTPUT; SELECT @Ma;");
            return newMa != null ? newMa.ToString().Trim() : "S_000011";
        }

        public bool KiemTraSachDaThue(string maSach)
        {
            object cnt = DataProcess.LayGiaTri("SELECT COUNT(*) FROM tChiTietThueSach WHERE MaSach = @MaSach",
                new SqlParameter[] { new SqlParameter("@MaSach", maSach) });
            return cnt != null && Convert.ToInt32(cnt) > 0;
        }

        public bool InsertSach(SachDTO s)
        {
            string sql = @"INSERT INTO tSachTruyen (MaSach, TenSach, MaLoai, MaLV, MaTG, MaNXB, MaNN, 
                                                   SoTrang, GiaSach, DonGiaThue, MaTT, SoLuong, Anh, GhiChu)
                           VALUES (@MaSach, @TenSach, @MaLoai, @MaLV, @MaTG, @MaNXB, @MaNN, 
                                   @SoTrang, @GiaSach, @DonGiaThue, @MaTT, @SoLuong, @Anh, @GhiChu)";
            SqlParameter[] p = {
                new SqlParameter("@MaSach", s.MaSach ?? (object)DBNull.Value),
                new SqlParameter("@TenSach", s.TenSach ?? (object)DBNull.Value),
                new SqlParameter("@MaLoai", s.MaLoai ?? (object)DBNull.Value),
                new SqlParameter("@MaLV", s.MaLV ?? (object)DBNull.Value),
                new SqlParameter("@MaTG", s.MaTG ?? (object)DBNull.Value),
                new SqlParameter("@MaNXB", s.MaNXB ?? (object)DBNull.Value),
                new SqlParameter("@MaNN", s.MaNN ?? (object)DBNull.Value),
                new SqlParameter("@SoTrang", s.SoTrang),
                new SqlParameter("@GiaSach", s.GiaSach),
                new SqlParameter("@DonGiaThue", s.DonGiaThue),
                new SqlParameter("@MaTT", s.MaTT ?? (object)DBNull.Value),
                new SqlParameter("@SoLuong", s.SoLuong),
                new SqlParameter("@Anh", s.Anh ?? (object)DBNull.Value),
                new SqlParameter("@GhiChu", s.GhiChu ?? (object)DBNull.Value)
            };
            return DataProcess.ThucThiLenh(sql, p) > 0;
        }

        public bool UpdateSach(SachDTO s)
        {
            string sql = @"UPDATE tSachTruyen 
                           SET TenSach = @TenSach, MaLoai = @MaLoai, MaLV = @MaLV, MaTG = @MaTG, 
                               MaNXB = @MaNXB, MaNN = @MaNN, SoTrang = @SoTrang, GiaSach = @GiaSach, 
                               DonGiaThue = @DonGiaThue, MaTT = @MaTT, SoLuong = @SoLuong, 
                               Anh = @Anh, GhiChu = @GhiChu
                           WHERE MaSach = @MaSach";
            SqlParameter[] p = {
                new SqlParameter("@MaSach", s.MaSach ?? (object)DBNull.Value),
                new SqlParameter("@TenSach", s.TenSach ?? (object)DBNull.Value),
                new SqlParameter("@MaLoai", s.MaLoai ?? (object)DBNull.Value),
                new SqlParameter("@MaLV", s.MaLV ?? (object)DBNull.Value),
                new SqlParameter("@MaTG", s.MaTG ?? (object)DBNull.Value),
                new SqlParameter("@MaNXB", s.MaNXB ?? (object)DBNull.Value),
                new SqlParameter("@MaNN", s.MaNN ?? (object)DBNull.Value),
                new SqlParameter("@SoTrang", s.SoTrang),
                new SqlParameter("@GiaSach", s.GiaSach),
                new SqlParameter("@DonGiaThue", s.DonGiaThue),
                new SqlParameter("@MaTT", s.MaTT ?? (object)DBNull.Value),
                new SqlParameter("@SoLuong", s.SoLuong),
                new SqlParameter("@Anh", s.Anh ?? (object)DBNull.Value),
                new SqlParameter("@GhiChu", s.GhiChu ?? (object)DBNull.Value)
            };
            return DataProcess.ThucThiLenh(sql, p) > 0;
        }

        public bool DeleteSach(string maSach)
        {
            string sql = "DELETE FROM tSachTruyen WHERE MaSach = @MaSach";
            return DataProcess.ThucThiLenh(sql, new SqlParameter[] { new SqlParameter("@MaSach", maSach) }) > 0;
        }

        public DataTable TimKiemSach(string ten, string lv, string tg, string nxb)
        {
            SqlParameter[] p = {
                new SqlParameter("@TenSach", string.IsNullOrEmpty(ten) ? (object)DBNull.Value : ten),
                new SqlParameter("@MaLV", string.IsNullOrEmpty(lv) ? (object)DBNull.Value : lv),
                new SqlParameter("@MaTG", string.IsNullOrEmpty(tg) ? (object)DBNull.Value : tg),
                new SqlParameter("@MaNXB", string.IsNullOrEmpty(nxb) ? (object)DBNull.Value : nxb)
            };
            return DataProcess.ExecProcedure("SP_TimSach", p);
        }
    }
}

