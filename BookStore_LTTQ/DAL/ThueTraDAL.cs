using System;
using System.Data;
using System.Data.SqlClient;
using BookStore_LTTQ.DTO;

namespace BookStore_LTTQ.DAL
{
    public class ThueTraDAL
    {
        public DataTable GetKhachHang() => DataProcess.DocBang("SELECT MaKH, TenKH + ' (' + MaKH + ')' AS HienThi FROM tKhachHang");
        public DataTable GetNhanVien() => DataProcess.DocBang("SELECT MaNV, TenNV + ' (' + MaNV + ')' AS HienThi FROM tNhanVien");
        public DataTable GetCaLam() => DataProcess.DocBang("SELECT MaCa, TenCa FROM tCaLam");

        public DataTable GetViPham() => DataProcess.DocBang("SELECT MaVP, TenVP, TienPhat FROM tViPham");

        public string GenerateNewMaThue()
        {
            object newMa = DataProcess.LayGiaTri("DECLARE @Ma CHAR(10); EXEC SP_GenerateNewMaThue @Ma OUTPUT; SELECT @Ma;");
            return newMa != null ? newMa.ToString().Trim() : "TH" + DateTime.Now.ToString("yyMM") + "0001";
        }

        public string GenerateNewMaTra()
        {
            object newMa = DataProcess.LayGiaTri("DECLARE @Ma CHAR(10); EXEC SP_GenerateNewMaTra @Ma OUTPUT; SELECT @Ma;");
            return newMa != null ? newMa.ToString().Trim() : "TR" + DateTime.Now.ToString("yyMM") + "0001";
        }

        public DataTable GetDanhSachPhieuThueChuaTra()
        {
            string sql = @"SELECT DISTINCT t.MaThue, 
                                  t.MaThue + ' - ' + kh.TenKH AS HienThi,
                                  kh.TenKH, t.NgayThue
                           FROM tThueSach t
                           JOIN tKhachHang kh ON kh.MaKH = t.MaKH
                           JOIN tChiTietThueSach ct ON ct.MaThue = t.MaThue
                           WHERE ct.DaTra = 0
                           ORDER BY t.MaThue DESC";
            return DataProcess.DocBang(sql);
        }

        public DataTable GetChiTietSachChuaTra(string maThue)
        {
            SqlParameter[] p = { new SqlParameter("@MaThue", maThue) };
            return DataProcess.ExecProcedure("SP_GetSachChuaTraTheoPhieu", p);
        }

        public bool LuuPhieuThue(PhieuThueDTO phieu, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (SqlConnection conn = DataProcess.GetConnection())
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlThue = @"INSERT INTO tThueSach (MaThue, MaKH, MaNV, MaCa, NgayThue, TienDatCoc)
                                           VALUES (@MaThue, @MaKH, @MaNV, @MaCa, @NgayThue, @TienDatCoc)";
                        using (SqlCommand cmdThue = new SqlCommand(sqlThue, conn, trans))
                        {
                            cmdThue.Parameters.AddWithValue("@MaThue", phieu.MaThue);
                            cmdThue.Parameters.AddWithValue("@MaKH", phieu.MaKH);
                            cmdThue.Parameters.AddWithValue("@MaNV", phieu.MaNV);
                            cmdThue.Parameters.AddWithValue("@MaCa", string.IsNullOrEmpty(phieu.MaCa) ? (object)DBNull.Value : phieu.MaCa);
                            cmdThue.Parameters.AddWithValue("@NgayThue", phieu.NgayThue.Date);
                            cmdThue.Parameters.AddWithValue("@TienDatCoc", phieu.TienDatCoc);
                            cmdThue.ExecuteNonQuery();
                        }

                        string sqlCT = @"INSERT INTO tChiTietThueSach (MaThue, MaSach, SoLuong, DaTra)
                                         VALUES (@MaThue, @MaSach, @SoLuong, 0)";
                        foreach (var item in phieu.DanhSachChiTiet)
                        {
                            using (SqlCommand cmdCT = new SqlCommand(sqlCT, conn, trans))
                            {
                                cmdCT.Parameters.AddWithValue("@MaThue", phieu.MaThue);
                                cmdCT.Parameters.AddWithValue("@MaSach", item.MaSach);
                                cmdCT.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                                cmdCT.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        errorMessage = ex.Message;
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool LuuPhieuTra(PhieuTraDTO phieu, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (SqlConnection conn = DataProcess.GetConnection())
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlTra = @"INSERT INTO tTraSach (MaTra, MaThue, MaNV, NgayTra, TongTien)
                                          VALUES (@MaTra, @MaThue, @MaNV, @NgayTra, @TongTien)";
                        using (SqlCommand cmdTra = new SqlCommand(sqlTra, conn, trans))
                        {
                            cmdTra.Parameters.AddWithValue("@MaTra", phieu.MaTra);
                            cmdTra.Parameters.AddWithValue("@MaThue", phieu.MaThue);
                            cmdTra.Parameters.AddWithValue("@MaNV", phieu.MaNV);
                            cmdTra.Parameters.AddWithValue("@NgayTra", phieu.NgayTra.Date);
                            cmdTra.Parameters.AddWithValue("@TongTien", phieu.TongThanhToan);
                            cmdTra.ExecuteNonQuery();
                        }

                        string sqlCT = @"INSERT INTO tChiTietTraSach (MaTra, MaSach, MaVP, ThanhTien)
                                         VALUES (@MaTra, @MaSach, @MaVP, @ThanhTien)";
                        foreach (var item in phieu.DanhSachChiTiet)
                        {
                            using (SqlCommand cmdCT = new SqlCommand(sqlCT, conn, trans))
                            {
                                cmdCT.Parameters.AddWithValue("@MaTra", phieu.MaTra);
                                cmdCT.Parameters.AddWithValue("@MaSach", item.MaSach);
                                cmdCT.Parameters.AddWithValue("@MaVP", string.IsNullOrEmpty(item.MaVP) ? (object)DBNull.Value : item.MaVP);
                                cmdCT.Parameters.AddWithValue("@ThanhTien", item.ThanhTien);
                                cmdCT.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        errorMessage = ex.Message;
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}

