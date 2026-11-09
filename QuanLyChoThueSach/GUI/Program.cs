using System.Text.Json;
using QuanLyChoThueSach.BLL;

namespace QuanLyChoThueSach.GUI;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (_, e) => UiHelper.BaoLoi(e.Exception);

        try
        {
            CauHinhBLL.DatChuoiKetNoi(DocChuoiKetNoi());
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không đọc được chuỗi kết nối trong appsettings.json:\n" + ex.Message,
                UiHelper.TieuDe, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Vòng lặp cho phép "Đăng xuất" quay lại màn hình đăng nhập.
        while (true)
        {
            using var login = new frmLogin();
            if (login.ShowDialog() != DialogResult.OK) return;

            using var main = new frmMain();
            Application.Run(main);
            if (!main.DangXuat) return;
        }
    }

    private static string DocChuoiKetNoi()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
        using var doc = JsonDocument.Parse(File.ReadAllText(path));
        return doc.RootElement.GetProperty("ConnectionStrings").GetProperty("Default").GetString()
               ?? throw new InvalidOperationException("ConnectionStrings:Default đang trống.");
    }
}
