using System;
using System.Data;
using BookStore_LTTQ.DAL;

namespace BookStore_LTTQ.BLL
{
    public class BaoCaoBLL
    {
        private readonly BaoCaoDAL _baoCaoDAL = new BaoCaoDAL();

        public DataTable GetBaoCaoChuaTra() => _baoCaoDAL.GetBaoCaoChuaTra();

        public DataTable GetBaoCaoDoanhThu(string kieu, int nam)
        {
            if (string.IsNullOrEmpty(kieu)) kieu = "THANG";
            if (nam <= 0) nam = DateTime.Now.Year;
            return _baoCaoDAL.GetBaoCaoDoanhThu(kieu, nam);
        }

        public DataTable GetBaoCaoTop5(DateTime? tuNgay, DateTime? denNgay)
        {
            return _baoCaoDAL.GetBaoCaoTop5(tuNgay, denNgay);
        }
    }
}

