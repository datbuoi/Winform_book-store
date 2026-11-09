using QuanLyChoThueSach.DAL;

namespace QuanLyChoThueSach.BLL;

/// <summary>Cho phép tầng GUI đặt chuỗi kết nối mà không cần tham chiếu trực tiếp tới DAL.</summary>
public static class CauHinhBLL
{
    public static void DatChuoiKetNoi(string chuoiKetNoi) => DbConfig.ConnectionString = chuoiKetNoi;
}
