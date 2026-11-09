using System;

namespace BookStore_LTTQ.DTO
{
    public class SachDTO
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string MaLoai { get; set; }
        public string MaLV { get; set; }
        public string MaTG { get; set; }
        public string MaNXB { get; set; }
        public string MaNN { get; set; }
        public string MaTT { get; set; }
        public int SoTrang { get; set; }
        public decimal GiaSach { get; set; }
        public decimal DonGiaThue { get; set; }
        public int SoLuong { get; set; }
        public string Anh { get; set; }
        public string GhiChu { get; set; }

        // Các thuộc tính liên kết hiển thị
        public string TenLoai { get; set; }
        public string TenLV { get; set; }
        public string TenTG { get; set; }
        public string TenNXB { get; set; }
        public string TenNN { get; set; }
        public string TenTT { get; set; }
    }
}

