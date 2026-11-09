using QuanLyChoThueSach.DAL;
using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.BLL;

public static class TaiKhoanBLL
{
    private const string SaiThongTin = "Sai tên đăng nhập hoặc mật khẩu.";

    /// <summary>Kiểm tra đăng nhập. Ném <see cref="NghiepVuException"/> nếu không hợp lệ.</summary>
    public static TaiKhoanDTO DangNhap(string tenDangNhap, string matKhau)
    {
        tenDangNhap = (tenDangNhap ?? "").Trim();
        if (tenDangNhap.Length == 0) throw new NghiepVuException("Vui lòng nhập tên đăng nhập.");
        if (string.IsNullOrEmpty(matKhau)) throw new NghiepVuException("Vui lòng nhập mật khẩu.");

        var tt = TaiKhoanDAL.LayTheoTenDangNhap(tenDangNhap);
        if (tt is null)
        {
            // Vẫn băm một lần để thời gian phản hồi không lộ tài khoản có tồn tại hay không.
            MatKhauHelper.Hash("", matKhau);
            throw new NghiepVuException(SaiThongTin);
        }

        var hash = MatKhauHelper.Hash(tt.Salt, matKhau);
        if (!MatKhauHelper.KhopHash(tt.MatKhauHash, hash))
            throw new NghiepVuException(SaiThongTin);

        if (!tt.HoatDong)
            throw new NghiepVuException("Tài khoản đã bị khóa.");

        return tt.TaiKhoan;
    }
}
