using System.Data;
using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.DAL;

public static class NhanVienDAL
{
    /// <summary>
    /// Tìm theo tên nhân viên, ca làm, giới tính. Tham số null/rỗng nghĩa là không lọc.
    /// Bảng NhanVien không có cột ca làm, nên "ca làm" được hiểu là ca mà nhân viên đã lập phiếu thuê (ThueSach.MaCa).
    /// </summary>
    public static DataTable Search(string? tenNV, int? maCa, string? gioiTinh)
    {
        return Db.Query(
            @"SELECT n.MaNV, n.TenNV, n.NamSinh, n.GioiTinh, n.DiaChi, n.DienThoai, n.LuongThang
              FROM NhanVien n
              WHERE (@ten IS NULL OR n.TenNV LIKE @ten ESCAPE '\')
                AND (@gt  IS NULL OR n.GioiTinh = @gt)
                AND (@ca  IS NULL OR EXISTS (SELECT 1 FROM ThueSach t WHERE t.MaNV = n.MaNV AND t.MaCa = @ca))
              ORDER BY n.MaNV",
            Db.P("@ten", string.IsNullOrWhiteSpace(tenNV) ? null : Db.Like(tenNV)),
            Db.P("@gt", string.IsNullOrWhiteSpace(gioiTinh) ? null : gioiTinh),
            Db.P("@ca", maCa));
    }

    /// <summary>Danh sách rút gọn (MaNV, TenNV) cho ComboBox.</summary>
    public static DataTable GetDanhSachRutGon() =>
        Db.Query("SELECT MaNV, TenNV FROM NhanVien ORDER BY TenNV");

    public static int Insert(NhanVienDTO n) =>
        Convert.ToInt32(Db.Scalar(
            @"INSERT INTO NhanVien (TenNV, NamSinh, GioiTinh, DiaChi, DienThoai, LuongThang)
              OUTPUT INSERTED.MaNV
              VALUES (@ten, @nam, @gt, @dc, @dt, @luong)",
            ThamSo(n)));

    public static void Update(NhanVienDTO n)
    {
        var ps = ThamSo(n).Append(Db.P("@id", n.MaNV)).ToArray();
        Db.Execute(
            @"UPDATE NhanVien SET TenNV = @ten, NamSinh = @nam, GioiTinh = @gt,
                                  DiaChi = @dc, DienThoai = @dt, LuongThang = @luong
              WHERE MaNV = @id", ps);
    }

    public static void Delete(int maNV) =>
        Db.Execute("DELETE FROM NhanVien WHERE MaNV = @id", Db.P("@id", maNV));

    private static Microsoft.Data.SqlClient.SqlParameter[] ThamSo(NhanVienDTO n) => new[]
    {
        Db.P("@ten", n.TenNV),
        Db.P("@nam", n.NamSinh),
        Db.P("@gt", n.GioiTinh),
        Db.P("@dc", n.DiaChi),
        Db.P("@dt", n.DienThoai),
        Db.P("@luong", n.LuongThang)
    };
}
