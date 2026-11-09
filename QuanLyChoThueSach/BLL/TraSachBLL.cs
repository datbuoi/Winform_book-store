using System.Data;
using QuanLyChoThueSach.DAL;
using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.BLL;

public static class TraSachBLL
{
    /// <summary>Các phiếu thuê còn sách chưa trả.</summary>
    public static DataTable LayPhieuChuaTra() => ThueSachDAL.GetPhieuChuaTra();

    /// <summary>Yêu cầu 3: chỉ các sách chưa trả của phiếu thuê được chọn.</summary>
    public static DataTable LayChiTietChuaTra(int maThue) => ThueSachDAL.GetChiTietChuaTra(maThue);

    /// <summary>Yêu cầu 4: Thành tiền = Đơn giá thuê * Số lượng thuê + Tiền phạt (nếu có).</summary>
    public static decimal TinhThanhTien(decimal donGiaThue, int soLuongThue, decimal tienPhat = 0) =>
        donGiaThue * soLuongThue + tienPhat;

    /// <summary>
    /// Lưu phiếu trả. Thành tiền và tổng tiền được tính lại ở đây từ dữ liệu trong CSDL
    /// (giá trị ThanhTien gửi từ giao diện bị bỏ qua). Số lượng sách được cộng lại vào kho (yêu cầu 2).
    /// </summary>
    public static int TaoPhieu(TraSachDTO phieu)
    {
        if (phieu.MaThue <= 0) throw new NghiepVuException("Vui lòng chọn phiếu thuê.");
        if (phieu.MaNV <= 0) throw new NghiepVuException("Vui lòng chọn nhân viên lập phiếu.");
        if (phieu.ChiTiet.Count == 0) throw new NghiepVuException("Vui lòng chọn ít nhất một sách để trả.");
        if (phieu.ChiTiet.GroupBy(c => c.MaSach).Any(g => g.Count() > 1))
            throw new NghiepVuException("Một sách chỉ xuất hiện một lần trong phiếu trả.");

        var ngayThue = ThueSachDAL.LayNgayThue(phieu.MaThue)
                       ?? throw new NghiepVuException("Không tìm thấy phiếu thuê.");
        if (phieu.NgayTra.Date < ngayThue.Date)
            throw new NghiepVuException("Ngày trả không được nhỏ hơn ngày thuê.");

        var chuaTra = ThueSachDAL.GetChiTietChuaTra(phieu.MaThue).AsEnumerable()
            .ToDictionary(r => (int)r["MaSach"]);
        var tienPhatTheoVP = DanhMucDAL.GetAll(DanhMucs.ViPham).AsEnumerable()
            .ToDictionary(r => (int)r["MaViPham"], r => (decimal)r["TienPhat"]);

        decimal tong = 0;
        foreach (var ct in phieu.ChiTiet)
        {
            if (!chuaTra.TryGetValue(ct.MaSach, out var dong))
                throw new NghiepVuException("Có sách đã được trả trước đó hoặc không thuộc phiếu thuê này.");

            decimal phat = 0;
            if (ct.MaViPham is { } mvp)
            {
                if (!tienPhatTheoVP.TryGetValue(mvp, out phat))
                    throw new NghiepVuException("Loại vi phạm không hợp lệ.");
            }

            ct.ThanhTien = TinhThanhTien((decimal)dong["DonGiaThue"], (int)dong["SoLuong"], phat);
            tong += ct.ThanhTien;
        }
        phieu.TongTien = tong;

        return TraSachDAL.Tao(phieu);
    }
}
