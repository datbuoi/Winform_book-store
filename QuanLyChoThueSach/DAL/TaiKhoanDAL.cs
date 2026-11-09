using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.DAL;

/// <summary>Dữ liệu cần để kiểm tra mật khẩu (chỉ dùng trong BLL, không đưa lên GUI).</summary>
public sealed record ThongTinXacThuc(TaiKhoanDTO TaiKhoan, string MatKhauHash, string? Salt, bool HoatDong);

public static class TaiKhoanDAL
{
    public static ThongTinXacThuc? LayTheoTenDangNhap(string tenDangNhap)
    {
        var dt = Db.Query(
            @"SELECT t.MaTK, t.TenDangNhap, t.MatKhauHash, t.Salt, t.MaNV, t.TrangThai, n.TenNV
              FROM TaiKhoan t
              LEFT JOIN NhanVien n ON n.MaNV = t.MaNV
              WHERE t.TenDangNhap = @u",
            Db.P("@u", tenDangNhap));

        if (dt.Rows.Count == 0) return null;
        var r = dt.Rows[0];

        var tk = new TaiKhoanDTO
        {
            MaTK = (int)r["MaTK"],
            TenDangNhap = (string)r["TenDangNhap"],
            MaNV = r["MaNV"] as int?,
            TenNV = r["TenNV"] as string
        };
        return new ThongTinXacThuc(
            tk,
            (string)r["MatKhauHash"],
            r["Salt"] as string,
            (bool)r["TrangThai"]);
    }
}
