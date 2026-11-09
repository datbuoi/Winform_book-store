namespace QuanLyChoThueSach.DTO;

/// <summary>Thông tin người dùng đang đăng nhập.</summary>
public sealed class TaiKhoanDTO
{
    public int MaTK { get; set; }
    public string TenDangNhap { get; set; } = "";
    public int? MaNV { get; set; }
    public string? TenNV { get; set; }

    public string TenHienThi => string.IsNullOrWhiteSpace(TenNV) ? TenDangNhap : TenNV;
}
