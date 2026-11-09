using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.GUI;

/// <summary>Người dùng đang đăng nhập.</summary>
internal static class AppSession
{
    public static TaiKhoanDTO? NguoiDung { get; set; }
}
