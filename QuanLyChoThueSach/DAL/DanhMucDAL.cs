using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.DAL;

/// <summary>CRUD dùng chung cho các bảng danh mục mô tả bởi <see cref="DanhMucInfo"/>.</summary>
public static class DanhMucDAL
{
    public static DataTable GetAll(DanhMucInfo info) =>
        Db.Query($"SELECT * FROM [{info.Bang}] ORDER BY [{info.KhoaChinh}]");

    public static int Insert(DanhMucInfo info, IReadOnlyDictionary<string, object?> values)
    {
        var cols = string.Join(", ", info.Cot.Select(c => $"[{c.Ten}]"));
        var pars = string.Join(", ", info.Cot.Select(c => "@" + c.Ten));
        var sql = $"INSERT INTO [{info.Bang}] ({cols}) OUTPUT INSERTED.[{info.KhoaChinh}] VALUES ({pars})";
        return Convert.ToInt32(Db.Scalar(sql, ThamSo(info, values)));
    }

    public static void Update(DanhMucInfo info, int id, IReadOnlyDictionary<string, object?> values)
    {
        var sets = string.Join(", ", info.Cot.Select(c => $"[{c.Ten}] = @{c.Ten}"));
        var sql = $"UPDATE [{info.Bang}] SET {sets} WHERE [{info.KhoaChinh}] = @id";
        var ps = ThamSo(info, values).Append(Db.P("@id", id)).ToArray();
        Db.Execute(sql, ps);
    }

    public static void Delete(DanhMucInfo info, int id) =>
        Db.Execute($"DELETE FROM [{info.Bang}] WHERE [{info.KhoaChinh}] = @id", Db.P("@id", id));

    private static SqlParameter[] ThamSo(DanhMucInfo info, IReadOnlyDictionary<string, object?> values) =>
        info.Cot.Select(c => Db.P("@" + c.Ten, values.TryGetValue(c.Ten, out var v) ? v : null)).ToArray();
}
