using System.Data;
using System.Globalization;
using QuanLyChoThueSach.DTO;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QuanLyChoThueSach.BLL;

/// <summary>Xuất 3 báo cáo ra file PDF (A4 ngang, có tiêu đề, ngày xuất, bảng dữ liệu, số trang).</summary>
public static class BaoCaoPdfBLL
{
    private const string TenCuaHang = "CỬA HÀNG CHO THUÊ SÁCH TRUYỆN";

    /// <param name="TyLe">Độ rộng tương đối của cột.</param>
    /// <param name="DinhDang">"N0" cho tiền/số, "d" cho ngày; null để in nguyên văn.</param>
    private sealed record Cot(string TenCot, string TieuDe, float TyLe, string? DinhDang = null, bool CanPhai = false);

    static BaoCaoPdfBLL()
    {
        // Giấy phép Community: miễn phí cho cá nhân, học tập, doanh nghiệp nhỏ (xem questpdf.com/license).
        QuestPDF.Settings.License = LicenseType.Community;
    }

    // ---- 3 báo cáo ----

    /// <summary>Báo cáo 7: sách đang thuê chưa trả.</summary>
    public static void XuatSachChuaTra(string duongDan)
    {
        var dt = BaoCaoBLL.SachDangThueChuaTra();
        var cot = new[]
        {
            new Cot("MaThue", "Mã thuê", 1),
            new Cot("NgayThue", "Ngày thuê", 1.5f, "d"),
            new Cot("TenKhach", "Khách hàng", 2.5f),
            new Cot("MaSach", "Mã sách", 1),
            new Cot("TenSach", "Tên sách", 3.5f),
            new Cot("SoLuong", "Số lượng", 1, "N0", true),
            new Cot("DonGiaThue", "Đơn giá thuê", 1.5f, "N0", true),
            new Cot("TenNV", "Nhân viên lập phiếu", 2.5f)
        };
        var tongKet = dt.Rows.Count == 0 ? null : $"Tổng số dòng sách chưa trả: {dt.Rows.Count}";
        Tao(duongDan, "BÁO CÁO SÁCH TRUYỆN ĐANG THUÊ CHƯA TRẢ", dt, cot, tongKet);
    }

    /// <summary>Báo cáo 8: tiền thuê thu được theo tháng, quý hoặc năm.</summary>
    public static void XuatDoanhThu(string duongDan, ThongKeKieu kieu)
    {
        var dt = BaoCaoBLL.DoanhThu(kieu);
        var cot = new List<Cot> { new("Nam", "Năm", 1) };
        if (kieu == ThongKeKieu.Thang) cot.Add(new Cot("Thang", "Tháng", 1));
        if (kieu == ThongKeKieu.Quy) cot.Add(new Cot("Quy", "Quý", 1));
        cot.Add(new Cot("SoPhieuTra", "Số phiếu trả", 1.5f, "N0", true));
        cot.Add(new Cot("TongTien", "Tổng tiền", 2, "N0", true));

        var ten = kieu switch { ThongKeKieu.Quy => "QUÝ", ThongKeKieu.Nam => "NĂM", _ => "THÁNG" };
        var tong = dt.AsEnumerable().Sum(r => (decimal)r["TongTien"]);
        var tongKet = dt.Rows.Count == 0 ? null : $"Tổng cộng: {tong.ToString("N0", CultureInfo.CurrentCulture)}";
        Tao(duongDan, $"BÁO CÁO TIỀN THUÊ THU ĐƯỢC THEO {ten}", dt, cot, tongKet);
    }

    /// <summary>Báo cáo 9: 5 sách truyện đạt doanh thu cao nhất.</summary>
    public static void XuatTop5(string duongDan)
    {
        var dt = BaoCaoBLL.Top5SachDoanhThu();
        var cot = new[]
        {
            new Cot("MaSach", "Mã sách", 1),
            new Cot("TenSach", "Tên sách", 4),
            new Cot("SoLanThue", "Số lần thuê", 1.5f, "N0", true),
            new Cot("DoanhThu", "Doanh thu", 2, "N0", true)
        };
        Tao(duongDan, "BÁO CÁO 5 SÁCH TRUYỆN CÓ DOANH THU CAO NHẤT", dt, cot, null);
    }

    // ---- Dựng tài liệu ----

    private static void Tao(string duongDan, string tieuDe, DataTable dt, IReadOnlyList<Cot> cot, string? tongKet)
    {
        if (string.IsNullOrWhiteSpace(duongDan))
            throw new NghiepVuException("Chưa chọn nơi lưu file PDF.");

        try
        {
            DungTaiLieu(tieuDe, dt, cot, tongKet).GeneratePdf(duongDan);
        }
        catch (IOException ex)
        {
            throw new NghiepVuException("Không ghi được file PDF. Hãy đóng file nếu đang mở và thử lại.", ex);
        }
        catch (UnauthorizedAccessException ex)
        {
            throw new NghiepVuException("Không có quyền ghi vào thư mục đã chọn. Hãy chọn nơi lưu khác.", ex);
        }
    }

    private static Document DungTaiLieu(string tieuDe, DataTable dt, IReadOnlyList<Cot> cot, string? tongKet)
    {
        return Document.Create(doc => doc.Page(page =>
        {
            page.Size(PageSizes.A4.Landscape());
            page.Margin(30);
            // Dùng font Lato đi kèm thư viện (không phụ thuộc font cài trên máy).
            page.DefaultTextStyle(x => x.FontSize(10));

            page.Header().Column(c =>
            {
                c.Item().Text(TenCuaHang).FontSize(11).SemiBold();
                c.Item().PaddingTop(6).AlignCenter().Text(tieuDe).FontSize(16).Bold();
                c.Item().PaddingTop(2).AlignCenter()
                    .Text($"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(9).FontColor(Colors.Grey.Darken1);
            });

            page.Content().PaddingVertical(12).Column(c =>
            {
                if (dt.Rows.Count == 0)
                {
                    c.Item().PaddingTop(20).AlignCenter().Text("Không có dữ liệu.").Italic();
                    return;
                }

                c.Item().Table(t =>
                {
                    t.ColumnsDefinition(cd =>
                    {
                        foreach (var x in cot) cd.RelativeColumn(x.TyLe);
                    });

                    t.Header(h =>
                    {
                        foreach (var x in cot)
                        {
                            var o = h.Cell().Background(Colors.Grey.Lighten3)
                                .BorderBottom(1).BorderColor(Colors.Grey.Darken2).Padding(5);
                            (x.CanPhai ? o.AlignRight() : o.AlignLeft()).Text(x.TieuDe).Bold();
                        }
                    });

                    foreach (DataRow r in dt.Rows)
                    {
                        foreach (var x in cot)
                        {
                            var o = t.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten1).Padding(5);
                            (x.CanPhai ? o.AlignRight() : o.AlignLeft()).Text(DinhDang(r[x.TenCot], x.DinhDang));
                        }
                    }
                });

                if (tongKet is not null)
                    c.Item().PaddingTop(12).AlignRight().Text(tongKet).Bold().FontSize(11);
            });

            page.Footer().AlignCenter().Text(x =>
            {
                x.Span("Trang ");
                x.CurrentPageNumber();
                x.Span(" / ");
                x.TotalPages();
            });
        }));
    }

    private static string DinhDang(object giaTri, string? dinhDang)
    {
        if (giaTri is DBNull) return "";
        return giaTri switch
        {
            DateTime d => d.ToString("dd/MM/yyyy"),
            IFormattable f when dinhDang is not null && dinhDang != "d" => f.ToString(dinhDang, CultureInfo.CurrentCulture),
            _ => Convert.ToString(giaTri, CultureInfo.CurrentCulture) ?? ""
        };
    }
}
