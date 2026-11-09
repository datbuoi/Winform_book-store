namespace QuanLyChoThueSach.DTO;

public sealed class ChiTietTraDTO
{
    public int MaSach { get; set; }
    /// <summary>null nếu không vi phạm.</summary>
    public int? MaViPham { get; set; }
    public decimal ThanhTien { get; set; }
}

public sealed class TraSachDTO
{
    public int MaTra { get; set; }
    public int MaThue { get; set; }
    public int MaNV { get; set; }
    public DateTime NgayTra { get; set; } = DateTime.Today;
    public decimal TongTien { get; set; }
    public List<ChiTietTraDTO> ChiTiet { get; set; } = new();
}
