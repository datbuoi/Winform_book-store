namespace QuanLyChoThueSach.DTO;

/// <summary>Kiểu dữ liệu của một cột trong bảng danh mục.</summary>
public enum KieuCot
{
    Text,
    Int,
    Decimal,
    Date,
    GioiTinh
}

/// <summary>Mô tả một cột (không phải khóa chính) của bảng danh mục. DoDai là độ dài tối đa của cột chữ (0 = không giới hạn).</summary>
public sealed record CotInfo(string Ten, string Nhan, KieuCot Kieu, bool BatBuoc = false, int DoDai = 0);

/// <summary>
/// Mô tả một bảng danh mục đơn giản (khóa chính tự tăng + vài cột) để dùng chung một form quản lý.
/// Tên bảng/cột chỉ lấy từ các hằng trong <see cref="DanhMucs"/>, không bao giờ từ dữ liệu người dùng nhập.
/// </summary>
public sealed class DanhMucInfo
{
    public required string Bang { get; init; }
    public required string TieuDe { get; init; }
    public required string KhoaChinh { get; init; }
    /// <summary>Cột dùng để hiển thị tên trong ComboBox.</summary>
    public required string CotTen { get; init; }
    public required IReadOnlyList<CotInfo> Cot { get; init; }
}

public static class DanhMucs
{
    public static readonly DanhMucInfo LinhVuc = new()
    {
        Bang = "LinhVuc", TieuDe = "Lĩnh vực", KhoaChinh = "MaLinhVuc", CotTen = "TenLinhVuc",
        Cot = new[] { new CotInfo("TenLinhVuc", "Tên lĩnh vực", KieuCot.Text, true, 100) }
    };

    public static readonly DanhMucInfo LoaiSach = new()
    {
        Bang = "LoaiSach", TieuDe = "Loại sách", KhoaChinh = "MaLoaiSach", CotTen = "TenLoai",
        Cot = new[] { new CotInfo("TenLoai", "Tên loại (Mới, cũ...)", KieuCot.Text, true, 100) }
    };

    public static readonly DanhMucInfo TinhTrang = new()
    {
        Bang = "TinhTrang", TieuDe = "Tình trạng", KhoaChinh = "MaTinhTrang", CotTen = "TenTinhTrang",
        Cot = new[] { new CotInfo("TenTinhTrang", "Tên tình trạng", KieuCot.Text, true, 100) }
    };

    public static readonly DanhMucInfo NgonNgu = new()
    {
        Bang = "NgonNgu", TieuDe = "Ngôn ngữ", KhoaChinh = "MaNgonNgu", CotTen = "TenNgonNgu",
        Cot = new[] { new CotInfo("TenNgonNgu", "Tên ngôn ngữ", KieuCot.Text, true, 100) }
    };

    public static readonly DanhMucInfo CaLam = new()
    {
        Bang = "CaLam", TieuDe = "Ca làm", KhoaChinh = "MaCa", CotTen = "TenCa",
        Cot = new[] { new CotInfo("TenCa", "Tên ca", KieuCot.Text, true, 50) }
    };

    public static readonly DanhMucInfo NXB = new()
    {
        Bang = "NXB", TieuDe = "Nhà xuất bản", KhoaChinh = "MaNXB", CotTen = "TenNXB",
        Cot = new[]
        {
            new CotInfo("TenNXB", "Tên NXB", KieuCot.Text, true, 150),
            new CotInfo("DiaChi", "Địa chỉ", KieuCot.Text, false, 255),
            new CotInfo("DienThoai", "Điện thoại", KieuCot.Text, false, 15)
        }
    };

    public static readonly DanhMucInfo TacGia = new()
    {
        Bang = "TacGia", TieuDe = "Tác giả", KhoaChinh = "MaTG", CotTen = "TenTG",
        Cot = new[]
        {
            new CotInfo("TenTG", "Tên tác giả", KieuCot.Text, true, 100),
            new CotInfo("NgaySinh", "Ngày sinh", KieuCot.Date),
            new CotInfo("GioiTinh", "Giới tính", KieuCot.GioiTinh),
            new CotInfo("DiaChi", "Địa chỉ", KieuCot.Text, false, 255)
        }
    };

    public static readonly DanhMucInfo ViPham = new()
    {
        Bang = "ViPham", TieuDe = "Vi phạm", KhoaChinh = "MaViPham", CotTen = "TenViPham",
        Cot = new[]
        {
            new CotInfo("TenViPham", "Tên vi phạm", KieuCot.Text, true, 150),
            new CotInfo("TienPhat", "Tiền phạt", KieuCot.Decimal, true)
        }
    };

    public static readonly DanhMucInfo KhachHang = new()
    {
        Bang = "KhachHang", TieuDe = "Khách hàng", KhoaChinh = "MaKhach", CotTen = "TenKhach",
        Cot = new[]
        {
            new CotInfo("TenKhach", "Tên khách", KieuCot.Text, true, 100),
            new CotInfo("NgaySinh", "Ngày sinh", KieuCot.Date),
            new CotInfo("GioiTinh", "Giới tính", KieuCot.GioiTinh),
            new CotInfo("DiaChi", "Địa chỉ", KieuCot.Text, false, 255)
        }
    };
}
