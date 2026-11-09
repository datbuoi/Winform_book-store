using QuanLyChoThueSach.DAL;
using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.BLL;

public static class ThueSachBLL
{
    /// <summary>Lưu phiếu thuê; số lượng sách trong kho được trừ tương ứng (yêu cầu 2). Trả về mã phiếu thuê.</summary>
    public static int TaoPhieu(ThueSachDTO phieu)
    {
        if (phieu.MaKhach <= 0) throw new NghiepVuException("Vui lòng chọn khách hàng.");
        if (phieu.MaNV <= 0) throw new NghiepVuException("Vui lòng chọn nhân viên lập phiếu.");
        if (phieu.MaCa <= 0) throw new NghiepVuException("Vui lòng chọn ca làm.");
        if (phieu.TienDatCoc < 0) throw new NghiepVuException("Tiền đặt cọc không được âm.");
        if (phieu.ChiTiet.Count == 0) throw new NghiepVuException("Vui lòng thêm ít nhất một sách vào phiếu thuê.");
        if (phieu.ChiTiet.Any(c => c.SoLuong <= 0)) throw new NghiepVuException("Số lượng thuê phải lớn hơn 0.");
        if (phieu.ChiTiet.GroupBy(c => c.MaSach).Any(g => g.Count() > 1))
            throw new NghiepVuException("Một sách chỉ xuất hiện một lần trong phiếu thuê.");

        return ThueSachDAL.Tao(phieu);
    }
}
