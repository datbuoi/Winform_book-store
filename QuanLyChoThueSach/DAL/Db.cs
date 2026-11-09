using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.DAL;

/// <summary>Chuỗi kết nối, được GUI gán một lần khi khởi động.</summary>
public static class DbConfig
{
    public static string ConnectionString { get; set; } = "";
}

/// <summary>Các hàm hỗ trợ truy cập SQL Server. Luôn dùng tham số, không ghép giá trị vào câu lệnh.</summary>
internal static class Db
{
    public static SqlConnection CreateConnection()
    {
        if (string.IsNullOrWhiteSpace(DbConfig.ConnectionString))
            throw new InvalidOperationException("Chưa cấu hình chuỗi kết nối (appsettings.json).");
        return new SqlConnection(DbConfig.ConnectionString);
    }

    public static SqlParameter P(string name, object? value) => new(name, value ?? DBNull.Value);

    /// <summary>Tạo mẫu LIKE '%text%' và escape các ký tự đặc biệt (dùng kèm ESCAPE '\').</summary>
    public static string Like(string text)
    {
        var s = text.Trim()
            .Replace("\\", "\\\\")
            .Replace("%", "\\%")
            .Replace("_", "\\_")
            .Replace("[", "\\[");
        return "%" + s + "%";
    }

    public static DataTable Query(string sql, params SqlParameter[] ps)
    {
        try
        {
            using var conn = CreateConnection();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(ps);
            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        catch (SqlException ex) when (CoTheDich(ex))
        {
            throw Dich(ex);
        }
    }

    public static int Execute(string sql, params SqlParameter[] ps)
    {
        try
        {
            using var conn = CreateConnection();
            conn.Open();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(ps);
            return cmd.ExecuteNonQuery();
        }
        catch (SqlException ex) when (CoTheDich(ex))
        {
            throw Dich(ex);
        }
    }

    public static object? Scalar(string sql, params SqlParameter[] ps)
    {
        try
        {
            using var conn = CreateConnection();
            conn.Open();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(ps);
            var r = cmd.ExecuteScalar();
            return r == DBNull.Value ? null : r;
        }
        catch (SqlException ex) when (CoTheDich(ex))
        {
            throw Dich(ex);
        }
    }

    // ---- Phiên bản chạy trong một giao dịch ----

    public static int Execute(SqlTransaction tx, string sql, params SqlParameter[] ps)
    {
        using var cmd = new SqlCommand(sql, tx.Connection, tx);
        cmd.Parameters.AddRange(ps);
        return cmd.ExecuteNonQuery();
    }

    public static object? Scalar(SqlTransaction tx, string sql, params SqlParameter[] ps)
    {
        using var cmd = new SqlCommand(sql, tx.Connection, tx);
        cmd.Parameters.AddRange(ps);
        var r = cmd.ExecuteScalar();
        return r == DBNull.Value ? null : r;
    }

    /// <summary>Chạy <paramref name="work"/> trong một giao dịch; lỗi thì rollback toàn bộ.</summary>
    public static T InTransaction<T>(Func<SqlTransaction, T> work)
    {
        try
        {
            using var conn = CreateConnection();
            conn.Open();
            using var tx = conn.BeginTransaction();
            try
            {
                var result = work(tx);
                tx.Commit();
                return result;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }
        catch (SqlException ex) when (CoTheDich(ex))
        {
            throw Dich(ex);
        }
    }

    // ---- Dịch lỗi SQL sang thông báo tiếng Việt ----

    private static bool CoTheDich(SqlException ex) => ex.Number is 547 or 2627 or 2601;

    private static NghiepVuException Dich(SqlException ex) => ex.Number switch
    {
        547 => new NghiepVuException(
            "Không thể thực hiện vì dữ liệu đang được sử dụng ở nơi khác hoặc giá trị không hợp lệ.", ex),
        _ => new NghiepVuException("Dữ liệu bị trùng với bản ghi đã có.", ex)
    };
}
