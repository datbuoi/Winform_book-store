using System.Data;
using QuanLyChoThueSach.DAL;
using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.BLL;

public static class SachTruyenBLL
{
    /// <summary>Yêu cầu 5: tìm theo tên sách, lĩnh vực, tác giả, NXB (null = không lọc).</summary>
    public static DataTable Tim(string? tenSach, int? maLinhVuc, int? maTG, int? maNXB) =>
        SachTruyenDAL.Search(tenSach, maLinhVuc, maTG, maNXB);

    /// <summary>Yêu cầu 1: chỉ các sách còn số lượng &gt; 0.</summary>
    public static DataTable LayConTrongKho() => SachTruyenDAL.GetConTrongKho();

    public static int Them(SachTruyenDTO s)
    {
        ChuanHoaVaKiemTra(s);
        return SachTruyenDAL.Insert(s);
    }

    public static void Sua(SachTruyenDTO s)
    {
        if (s.MaSach <= 0) throw new NghiepVuException("Vui lòng chọn sách cần sửa.");
        ChuanHoaVaKiemTra(s);
        SachTruyenDAL.Update(s);
    }

    public static void Xoa(int maSach)
    {
        if (maSach <= 0) throw new NghiepVuException("Vui lòng chọn sách cần xóa.");
        SachTruyenDAL.Delete(maSach);
    }

    private static void ChuanHoaVaKiemTra(SachTruyenDTO s)
    {
        s.TenSach = (s.TenSach ?? "").Trim();
        s.Anh = string.IsNullOrWhiteSpace(s.Anh) ? null : s.Anh.Trim();
        s.GhiChu = string.IsNullOrWhiteSpace(s.GhiChu) ? null : s.GhiChu.Trim();

        if (s.TenSach.Length == 0) throw new NghiepVuException("Vui lòng nhập tên sách.");
        if (s.MaLoaiSach <= 0) throw new NghiepVuException("Vui lòng chọn loại sách.");
        if (s.MaLinhVuc <= 0) throw new NghiepVuException("Vui lòng chọn lĩnh vực.");
        if (s.MaTG <= 0) throw new NghiepVuException("Vui lòng chọn tác giả.");
        if (s.MaNXB <= 0) throw new NghiepVuException("Vui lòng chọn nhà xuất bản.");
        if (s.MaNgonNgu <= 0) throw new NghiepVuException("Vui lòng chọn ngôn ngữ.");
        if (s.MaTinhTrang <= 0) throw new NghiepVuException("Vui lòng chọn tình trạng.");
        if (s.SoTrang is <= 0) throw new NghiepVuException("Số trang phải lớn hơn 0.");
        if (s.GiaSach < 0) throw new NghiepVuException("Giá sách không được âm.");
        if (s.DonGiaThue < 0) throw new NghiepVuException("Đơn giá thuê không được âm.");
        if (s.SoLuong < 0) throw new NghiepVuException("Số lượng không được âm.");
    }
}
