namespace QuanLyChoThueSach.DTO;

public sealed class SachTruyenDTO
{
    public int MaSach { get; set; }
    public string TenSach { get; set; } = "";
    public int MaLoaiSach { get; set; }
    public int MaLinhVuc { get; set; }
    public int MaTG { get; set; }
    public int MaNXB { get; set; }
    public int MaNgonNgu { get; set; }
    public int? SoTrang { get; set; }
    public decimal GiaSach { get; set; }
    public decimal DonGiaThue { get; set; }
    public int MaTinhTrang { get; set; }
    public int SoLuong { get; set; }
    public string? Anh { get; set; }
    public string? GhiChu { get; set; }
}
