using System.Data;
using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.DAL;

public static class ThueSachDAL
{
    /// <summary>
    /// Lưu phiếu thuê, chi tiết, và trừ số lượng sách trong kho trong cùng một giao dịch.
    /// Trả về mã phiếu thuê mới.
    /// </summary>
    public static int Tao(ThueSachDTO phieu)
    {
        return Db.InTransaction(tx =>
        {
            var maThue = Convert.ToInt32(Db.Scalar(tx,
                @"INSERT INTO ThueSach (MaKhach, MaNV, MaCa, NgayThue, TienDatCoc)
                  OUTPUT INSERTED.MaThue
                  VALUES (@kh, @nv, @ca, @ngay, @coc)",
                Db.P("@kh", phieu.MaKhach),
                Db.P("@nv", phieu.MaNV),
                Db.P("@ca", phieu.MaCa),
                Db.P("@ngay", phieu.NgayThue.Date),
                Db.P("@coc", phieu.TienDatCoc)));

            foreach (var ct in phieu.ChiTiet)
            {
                // Chỉ trừ khi còn đủ hàng; nếu không thì 0 dòng bị ảnh hưởng và toàn bộ giao dịch bị hủy.
                var capNhat = Db.Execute(tx,
                    "UPDATE SachTruyen SET SoLuong = SoLuong - @sl WHERE MaSach = @ms AND SoLuong >= @sl",
                    Db.P("@sl", ct.SoLuong), Db.P("@ms", ct.MaSach));
                if (capNhat == 0)
                {
                    var ten = Db.Scalar(tx, "SELECT TenSach FROM SachTruyen WHERE MaSach = @ms", Db.P("@ms", ct.MaSach));
                    throw new NghiepVuException($"Sách \"{ten}\" không đủ số lượng trong kho.");
                }

                Db.Execute(tx,
                    "INSERT INTO ChiTietThueSach (MaThue, MaSach, SoLuong, DaTra) VALUES (@mt, @ms, @sl, 0)",
                    Db.P("@mt", maThue), Db.P("@ms", ct.MaSach), Db.P("@sl", ct.SoLuong));
            }

            return maThue;
        });
    }

    /// <summary>Các phiếu thuê còn ít nhất một sách chưa trả.</summary>
    public static DataTable GetPhieuChuaTra() =>
        Db.Query(
            @"SELECT t.MaThue, t.NgayThue, k.TenKhach,
                     CONCAT(N'Phiếu ', t.MaThue, N' - ', k.TenKhach, N' - ', CONVERT(varchar(10), t.NgayThue, 103)) AS MoTa
              FROM ThueSach t
              JOIN KhachHang k ON k.MaKhach = t.MaKhach
              WHERE EXISTS (SELECT 1 FROM ChiTietThueSach c WHERE c.MaThue = t.MaThue AND c.DaTra = 0)
              ORDER BY t.MaThue DESC");

    /// <summary>Các sách chưa trả của một phiếu thuê.</summary>
    public static DataTable GetChiTietChuaTra(int maThue) =>
        Db.Query(
            @"SELECT c.MaSach, s.TenSach, c.SoLuong, s.DonGiaThue
              FROM ChiTietThueSach c
              JOIN SachTruyen s ON s.MaSach = c.MaSach
              WHERE c.MaThue = @mt AND c.DaTra = 0
              ORDER BY s.TenSach",
            Db.P("@mt", maThue));

    public static DateTime? LayNgayThue(int maThue)
    {
        var v = Db.Scalar("SELECT NgayThue FROM ThueSach WHERE MaThue = @mt", Db.P("@mt", maThue));
        return v is DateTime d ? d : null;
    }
}
