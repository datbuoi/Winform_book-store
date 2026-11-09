using System.Security.Cryptography;
using System.Text;

namespace QuanLyChoThueSach.BLL;

/// <summary>
/// Băm mật khẩu: hash = SHA-256(salt + mật khẩu), viết hoa hex (64 ký tự).
/// Khớp với cách tạo tài khoản mẫu trong file SQL: HASHBYTES('SHA2_256', @salt + 'matkhau').
/// </summary>
public static class MatKhauHelper
{
    public static string TaoSalt() => Convert.ToHexString(RandomNumberGenerator.GetBytes(16));

    public static string Hash(string? salt, string matKhau)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes((salt ?? "") + matKhau));
        return Convert.ToHexString(bytes);
    }

    /// <summary>So sánh hash với thời gian không phụ thuộc vào vị trí ký tự khác nhau.</summary>
    public static bool KhopHash(string hashDaLuu, string hashTinhDuoc) =>
        CryptographicOperations.FixedTimeEquals(
            Encoding.ASCII.GetBytes(hashDaLuu.Trim().ToUpperInvariant()),
            Encoding.ASCII.GetBytes(hashTinhDuoc.ToUpperInvariant()));
}
