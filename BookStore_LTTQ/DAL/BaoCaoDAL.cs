using System;
using System.Data;
using System.Data.SqlClient;

namespace BookStore_LTTQ.DAL
{
    public class BaoCaoDAL
    {
        public DataTable GetBaoCaoChuaTra()
        {
            string sql = @"SELECT MaThue, TenKH, MaSach, TenSach, SoLuong, NgayThue, 
                                  SoNgayDaThue, TienThueTamTinh, TienDatCoc, NhanVienLap
                           FROM vw_SachDangThueChuaTra
                           ORDER BY NgayThue DESC";
            return DataProcess.DocBang(sql);
        }

        public DataTable GetBaoCaoDoanhThu(string kieu, int nam)
        {
            SqlParameter[] p = {
                new SqlParameter("@Kieu", kieu),
                new SqlParameter("@Nam", nam)
            };
            return DataProcess.ExecProcedure("SP_DoanhThu", p);
        }

        public DataTable GetBaoCaoTop5(DateTime? tuNgay, DateTime? denNgay)
        {
            SqlParameter[] p = {
                new SqlParameter("@TuNgay", tuNgay.HasValue ? (object)tuNgay.Value.Date : DBNull.Value),
                new SqlParameter("@DenNgay", denNgay.HasValue ? (object)denNgay.Value.Date : DBNull.Value)
            };
            return DataProcess.ExecProcedure("SP_Top5SachDoanhThu", p);
        }
    }
}

