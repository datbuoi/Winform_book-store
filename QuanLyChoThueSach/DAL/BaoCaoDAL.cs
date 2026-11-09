using System.Data;
using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.DAL;

public static class BaoCaoDAL
{
    /// <summary>Báo cáo 7: các sách truyện đang được thuê mà chưa trả.</summary>
    public static DataTable SachDangThueChuaTra() =>
        Db.Query(
            @"SELECT t.MaThue, t.NgayThue, k.TenKhach, s.MaSach, s.TenSach,
                     c.SoLuong, s.DonGiaThue, n.TenNV
              FROM ChiTietThueSach c
              JOIN ThueSach  t ON t.MaThue   = c.MaThue
              JOIN KhachHang k ON k.MaKhach  = t.MaKhach
              JOIN SachTruyen s ON s.MaSach  = c.MaSach
              JOIN NhanVien  n ON n.MaNV     = t.MaNV
              WHERE c.DaTra = 0
              ORDER BY t.NgayThue, t.MaThue, s.TenSach");

    /// <summary>Báo cáo 8: tổng tiền thu được (TraSach.TongTien) theo tháng, quý hoặc năm.</summary>
    public static DataTable DoanhThu(ThongKeKieu kieu)
    {
        // Câu lệnh chọn từ các hằng cố định, không ghép dữ liệu người dùng.
        var sql = kieu switch
        {
            ThongKeKieu.Thang =>
                @"SELECT YEAR(NgayTra) AS Nam, MONTH(NgayTra) AS Thang,
                         COUNT(*) AS SoPhieuTra, SUM(TongTien) AS TongTien
                  FROM TraSach
                  GROUP BY YEAR(NgayTra), MONTH(NgayTra)
                  ORDER BY Nam DESC, Thang DESC",
            ThongKeKieu.Quy =>
                @"SELECT YEAR(NgayTra) AS Nam, DATEPART(QUARTER, NgayTra) AS Quy,
                         COUNT(*) AS SoPhieuTra, SUM(TongTien) AS TongTien
                  FROM TraSach
                  GROUP BY YEAR(NgayTra), DATEPART(QUARTER, NgayTra)
                  ORDER BY Nam DESC, Quy DESC",
            _ =>
                @"SELECT YEAR(NgayTra) AS Nam,
                         COUNT(*) AS SoPhieuTra, SUM(TongTien) AS TongTien
                  FROM TraSach
                  GROUP BY YEAR(NgayTra)
                  ORDER BY Nam DESC"
        };
        return Db.Query(sql);
    }

    /// <summary>Báo cáo 9: 5 sách truyện có doanh thu (tổng ThanhTien khi trả) cao nhất.</summary>
    public static DataTable Top5SachDoanhThu() =>
        Db.Query(
            @"SELECT TOP (5) s.MaSach, s.TenSach,
                     COUNT(*) AS SoLanThue,
                     SUM(ct.ThanhTien) AS DoanhThu
              FROM ChiTietTraSach ct
              JOIN SachTruyen s ON s.MaSach = ct.MaSach
              GROUP BY s.MaSach, s.TenSach
              ORDER BY DoanhThu DESC, s.MaSach");
}
