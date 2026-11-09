using System;

namespace BookStore_LTTQ.DTO
{
    public class LoaiSachDTO
    {
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
    }

    public class LinhVucDTO
    {
        public string MaLV { get; set; }
        public string TenLV { get; set; }
    }

    public class TacGiaDTO
    {
        public string MaTG { get; set; }
        public string TenTG { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
    }

    public class NXBDTO
    {
        public string MaNXB { get; set; }
        public string TenNXB { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
    }

    public class TinhTrangDTO
    {
        public string MaTT { get; set; }
        public string TenTT { get; set; }
    }

    public class NgonNguDTO
    {
        public string MaNN { get; set; }
        public string TenNN { get; set; }
    }

    public class CaLamDTO
    {
        public string MaCa { get; set; }
        public string TenCa { get; set; }
    }

    public class ViPhamDTO
    {
        public string MaVP { get; set; }
        public string TenVP { get; set; }
        public decimal TienPhat { get; set; }
    }
}

