using System;

namespace BookStore_LTTQ.DTO
{
    public class NhanVienDTO
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public int? NamSinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public decimal? LuongThang { get; set; }
        public string MaCa { get; set; }

        public string TenCa { get; set; }
        public string GioiTinhHienThi => GioiTinh == "M" ? "Nam" : "Nữ";
    }
}

