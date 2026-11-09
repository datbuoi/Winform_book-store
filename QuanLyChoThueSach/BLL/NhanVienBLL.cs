using System.Data;
using QuanLyChoThueSach.DAL;
using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.BLL;

public static class NhanVienBLL
{
    private static readonly string[] GioiTinhHopLe = { "Nam", "Nữ", "Khác" };

    /// <summary>Yêu cầu 6: tìm theo tên nhân viên, ca làm, giới tính (null/rỗng = không lọc).</summary>
    public static DataTable Tim(string? tenNV, int? maCa, string? gioiTinh) =>
        NhanVienDAL.Search(tenNV, maCa, gioiTinh);

    public static DataTable LayDanhSachRutGon() => NhanVienDAL.GetDanhSachRutGon();

    public static int Them(NhanVienDTO n)
    {
        ChuanHoaVaKiemTra(n);
        return NhanVienDAL.Insert(n);
    }

    public static void Sua(NhanVienDTO n)
    {
        if (n.MaNV <= 0) throw new NghiepVuException("Vui lòng chọn nhân viên cần sửa.");
        ChuanHoaVaKiemTra(n);
        NhanVienDAL.Update(n);
    }

    public static void Xoa(int maNV)
    {
        if (maNV <= 0) throw new NghiepVuException("Vui lòng chọn nhân viên cần xóa.");
        NhanVienDAL.Delete(maNV);
    }

    private static void ChuanHoaVaKiemTra(NhanVienDTO n)
    {
        n.TenNV = (n.TenNV ?? "").Trim();
        n.DiaChi = string.IsNullOrWhiteSpace(n.DiaChi) ? null : n.DiaChi.Trim();
        n.DienThoai = string.IsNullOrWhiteSpace(n.DienThoai) ? null : n.DienThoai.Trim();
        n.GioiTinh = string.IsNullOrWhiteSpace(n.GioiTinh) ? null : n.GioiTinh.Trim();

        if (n.TenNV.Length == 0) throw new NghiepVuException("Vui lòng nhập tên nhân viên.");
        if (n.GioiTinh is not null && !GioiTinhHopLe.Contains(n.GioiTinh))
            throw new NghiepVuException("Giới tính không hợp lệ.");
        if (n.NamSinh is { } nam && (nam < 1900 || nam > DateTime.Today.Year))
            throw new NghiepVuException("Năm sinh không hợp lệ.");
        if (n.LuongThang is < 0) throw new NghiepVuException("Lương tháng không được âm.");
    }
}
