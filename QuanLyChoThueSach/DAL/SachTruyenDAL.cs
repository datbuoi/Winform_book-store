using System.Data;
using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.DAL;

public static class SachTruyenDAL
{
    private const string SelectChinh = @"
        SELECT s.MaSach, s.TenSach,
               lv.TenLinhVuc, tg.TenTG, nxb.TenNXB, ls.TenLoai, nn.TenNgonNgu,
               s.SoTrang, s.GiaSach, s.DonGiaThue, tt.TenTinhTrang, s.SoLuong, s.Anh, s.GhiChu,
               s.MaLoaiSach, s.MaLinhVuc, s.MaTG, s.MaNXB, s.MaNgonNgu, s.MaTinhTrang
        FROM SachTruyen s
        JOIN LinhVuc  lv  ON lv.MaLinhVuc   = s.MaLinhVuc
        JOIN TacGia   tg  ON tg.MaTG        = s.MaTG
        JOIN NXB      nxb ON nxb.MaNXB      = s.MaNXB
        JOIN LoaiSach ls  ON ls.MaLoaiSach  = s.MaLoaiSach
        JOIN NgonNgu  nn  ON nn.MaNgonNgu   = s.MaNgonNgu
        JOIN TinhTrang tt ON tt.MaTinhTrang = s.MaTinhTrang";

    /// <summary>Tìm theo tên sách, lĩnh vực, tác giả, NXB. Tham số null nghĩa là không lọc.</summary>
    public static DataTable Search(string? tenSach, int? maLinhVuc, int? maTG, int? maNXB)
    {
        var sql = SelectChinh + @"
        WHERE (@ten IS NULL OR s.TenSach LIKE @ten ESCAPE '\')
          AND (@lv  IS NULL OR s.MaLinhVuc = @lv)
          AND (@tg  IS NULL OR s.MaTG      = @tg)
          AND (@nxb IS NULL OR s.MaNXB     = @nxb)
        ORDER BY s.MaSach";

        return Db.Query(sql,
            Db.P("@ten", string.IsNullOrWhiteSpace(tenSach) ? null : Db.Like(tenSach)),
            Db.P("@lv", maLinhVuc),
            Db.P("@tg", maTG),
            Db.P("@nxb", maNXB));
    }

    /// <summary>Các sách còn trong kho (SoLuong &gt; 0) để chọn khi lập phiếu thuê.</summary>
    public static DataTable GetConTrongKho() =>
        Db.Query(@"SELECT MaSach, TenSach, SoLuong, DonGiaThue
                   FROM SachTruyen
                   WHERE SoLuong > 0
                   ORDER BY TenSach");

    public static int Insert(SachTruyenDTO s) =>
        Convert.ToInt32(Db.Scalar(
            @"INSERT INTO SachTruyen
                (TenSach, MaLoaiSach, MaLinhVuc, MaTG, MaNXB, MaNgonNgu, SoTrang,
                 GiaSach, DonGiaThue, MaTinhTrang, SoLuong, Anh, GhiChu)
              OUTPUT INSERTED.MaSach
              VALUES (@ten, @loai, @lv, @tg, @nxb, @nn, @trang, @gia, @thue, @tt, @sl, @anh, @ghichu)",
            ThamSo(s)));

    public static void Update(SachTruyenDTO s)
    {
        var ps = ThamSo(s).Append(Db.P("@id", s.MaSach)).ToArray();
        Db.Execute(
            @"UPDATE SachTruyen SET
                TenSach = @ten, MaLoaiSach = @loai, MaLinhVuc = @lv, MaTG = @tg, MaNXB = @nxb,
                MaNgonNgu = @nn, SoTrang = @trang, GiaSach = @gia, DonGiaThue = @thue,
                MaTinhTrang = @tt, SoLuong = @sl, Anh = @anh, GhiChu = @ghichu
              WHERE MaSach = @id", ps);
    }

    public static void Delete(int maSach) =>
        Db.Execute("DELETE FROM SachTruyen WHERE MaSach = @id", Db.P("@id", maSach));

    private static Microsoft.Data.SqlClient.SqlParameter[] ThamSo(SachTruyenDTO s) => new[]
    {
        Db.P("@ten", s.TenSach),
        Db.P("@loai", s.MaLoaiSach),
        Db.P("@lv", s.MaLinhVuc),
        Db.P("@tg", s.MaTG),
        Db.P("@nxb", s.MaNXB),
        Db.P("@nn", s.MaNgonNgu),
        Db.P("@trang", s.SoTrang),
        Db.P("@gia", s.GiaSach),
        Db.P("@thue", s.DonGiaThue),
        Db.P("@tt", s.MaTinhTrang),
        Db.P("@sl", s.SoLuong),
        Db.P("@anh", s.Anh),
        Db.P("@ghichu", s.GhiChu)
    };
}
