namespace QuanLyChoThueSach.DTO;

public sealed class ChiTietThueDTO
{
    public int MaSach { get; set; }
    public int SoLuong { get; set; }
}

public sealed class ThueSachDTO
{
    public int MaThue { get; set; }
    public int MaKhach { get; set; }
    public int MaNV { get; set; }
    public int MaCa { get; set; }
    public DateTime NgayThue { get; set; } = DateTime.Today;
    public decimal TienDatCoc { get; set; }
    public List<ChiTietThueDTO> ChiTiet { get; set; } = new();
}
