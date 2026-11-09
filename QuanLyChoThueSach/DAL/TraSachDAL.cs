using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.DAL;

public static class TraSachDAL
{
    /// <summary>
    /// Lưu phiếu trả, chi tiết trả, đánh dấu đã trả và cộng lại số lượng sách vào kho
    /// trong cùng một giao dịch. Trả về mã phiếu trả mới.
    /// </summary>
    public static int Tao(TraSachDTO phieu)
    {
        return Db.InTransaction(tx =>
        {
            var maTra = Convert.ToInt32(Db.Scalar(tx,
                @"INSERT INTO TraSach (MaThue, MaNV, NgayTra, TongTien)
                  OUTPUT INSERTED.MaTra
                  VALUES (@mt, @nv, @ngay, @tong)",
                Db.P("@mt", phieu.MaThue),
                Db.P("@nv", phieu.MaNV),
                Db.P("@ngay", phieu.NgayTra.Date),
                Db.P("@tong", phieu.TongTien)));

            foreach (var ct in phieu.ChiTiet)
            {
                // Chỉ đánh dấu khi dòng này còn chưa trả; lấy luôn số lượng đã thuê để cộng lại vào kho.
                var soLuong = Db.Scalar(tx,
                    @"UPDATE ChiTietThueSach SET DaTra = 1
                      OUTPUT INSERTED.SoLuong
                      WHERE MaThue = @mt AND MaSach = @ms AND DaTra = 0",
                    Db.P("@mt", phieu.MaThue), Db.P("@ms", ct.MaSach));
                if (soLuong is null)
                    throw new NghiepVuException("Có sách đã được trả trước đó hoặc không thuộc phiếu thuê này.");

                Db.Execute(tx,
                    "UPDATE SachTruyen SET SoLuong = SoLuong + @sl WHERE MaSach = @ms",
                    Db.P("@sl", Convert.ToInt32(soLuong)), Db.P("@ms", ct.MaSach));

                Db.Execute(tx,
                    @"INSERT INTO ChiTietTraSach (MaTra, MaSach, MaViPham, ThanhTien)
                      VALUES (@mtra, @ms, @vp, @tt)",
                    Db.P("@mtra", maTra), Db.P("@ms", ct.MaSach),
                    Db.P("@vp", ct.MaViPham), Db.P("@tt", ct.ThanhTien));
            }

            return maTra;
        });
    }
}
