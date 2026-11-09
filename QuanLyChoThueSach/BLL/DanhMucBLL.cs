using System.Data;
using QuanLyChoThueSach.DAL;
using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.BLL;

public static class DanhMucBLL
{
    private static readonly string[] GioiTinhHopLe = { "Nam", "Nữ", "Khác" };

    public static DataTable LayTatCa(DanhMucInfo info) => DanhMucDAL.GetAll(info);

    public static int Them(DanhMucInfo info, IReadOnlyDictionary<string, object?> values) =>
        DanhMucDAL.Insert(info, ChuanHoa(info, values));

    public static void Sua(DanhMucInfo info, int id, IReadOnlyDictionary<string, object?> values) =>
        DanhMucDAL.Update(info, id, ChuanHoa(info, values));

    public static void Xoa(DanhMucInfo info, int id) => DanhMucDAL.Delete(info, id);

    /// <summary>Kiểm tra bắt buộc/kiểu dữ liệu, cắt khoảng trắng, đổi chuỗi rỗng thành null.</summary>
    private static Dictionary<string, object?> ChuanHoa(DanhMucInfo info, IReadOnlyDictionary<string, object?> values)
    {
        var kq = new Dictionary<string, object?>();
        foreach (var c in info.Cot)
        {
            values.TryGetValue(c.Ten, out var v);

            if (v is string s)
            {
                s = s.Trim();
                v = s.Length == 0 ? null : s;
            }

            if (v is null)
            {
                if (c.BatBuoc) throw new NghiepVuException($"Vui lòng nhập \"{c.Nhan}\".");
                kq[c.Ten] = null;
                continue;
            }

            if (v is string chuoi && c.DoDai > 0 && chuoi.Length > c.DoDai)
                throw new NghiepVuException($"\"{c.Nhan}\" tối đa {c.DoDai} ký tự.");

            switch (c.Kieu)
            {
                case KieuCot.Decimal when v is decimal d && d < 0:
                    throw new NghiepVuException($"\"{c.Nhan}\" không được âm.");
                case KieuCot.Date when v is DateTime dt && dt.Date > DateTime.Today:
                    throw new NghiepVuException($"\"{c.Nhan}\" không được lớn hơn ngày hôm nay.");
                case KieuCot.GioiTinh when v is string g && !GioiTinhHopLe.Contains(g):
                    throw new NghiepVuException($"\"{c.Nhan}\" không hợp lệ.");
            }
            kq[c.Ten] = v;
        }
        return kq;
    }
}
