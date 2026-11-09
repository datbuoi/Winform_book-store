namespace QuanLyChoThueSach.DTO;

public sealed class NhanVienDTO
{
    public int MaNV { get; set; }
    public string TenNV { get; set; } = "";
    public int? NamSinh { get; set; }
    public string? GioiTinh { get; set; }
    public string? DiaChi { get; set; }
    public string? DienThoai { get; set; }
    public decimal? LuongThang { get; set; }
}
