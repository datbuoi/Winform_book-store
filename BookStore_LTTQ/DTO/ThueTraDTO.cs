using System;
using System.Collections.Generic;

namespace BookStore_LTTQ.DTO
{
    public class PhieuThueDTO
    {
        public string MaThue { get; set; }
        public string MaKH { get; set; }
        public string MaNV { get; set; }
        public string MaCa { get; set; }
        public DateTime NgayThue { get; set; }
        public decimal TienDatCoc { get; set; }
        public List<ChiTietThueDTO> DanhSachChiTiet { get; set; } = new List<ChiTietThueDTO>();
    }

    public class ChiTietThueDTO
    {
        public string MaThue { get; set; }
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGiaThue { get; set; }
        public decimal ThanhTienTamTinh => SoLuong * DonGiaThue;
        public bool DaTra { get; set; }
    }

    public class PhieuTraDTO
    {
        public string MaTra { get; set; }
        public string MaThue { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayTra { get; set; }
        public decimal TongTienThue { get; set; }
        public decimal TongTienPhat { get; set; }
        public decimal TongThanhToan { get; set; }
        public List<ChiTietTraDTO> DanhSachChiTiet { get; set; } = new List<ChiTietTraDTO>();
    }

    public class ChiTietTraDTO
    {
        public string MaTra { get; set; }
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public int SoLuong { get; set; }
        public int SoNgayThue { get; set; }
        public decimal TienThue { get; set; }
        public string MaVP { get; set; }
        public string TenViPham { get; set; }
        public decimal TienPhat { get; set; }
        public decimal ThanhTien { get; set; }
    }
}

