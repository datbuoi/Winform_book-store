using System.Data;
using QuanLyChoThueSach.DAL;
using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.BLL;

public static class BaoCaoBLL
{
    /// <summary>Yêu cầu 7.</summary>
    public static DataTable SachDangThueChuaTra() => BaoCaoDAL.SachDangThueChuaTra();

    /// <summary>Yêu cầu 8.</summary>
    public static DataTable DoanhThu(ThongKeKieu kieu) => BaoCaoDAL.DoanhThu(kieu);

    /// <summary>Yêu cầu 9.</summary>
    public static DataTable Top5SachDoanhThu() => BaoCaoDAL.Top5SachDoanhThu();
}
