using System;
using System.Data;
using BookStore_LTTQ.DAL;
using BookStore_LTTQ.DTO;

namespace BookStore_LTTQ.BLL
{
    public class ThueTraBLL
    {
        private readonly ThueTraDAL _thueTraDAL = new ThueTraDAL();

        public DataTable GetKhachHang() => _thueTraDAL.GetKhachHang();
        public DataTable GetNhanVien() => _thueTraDAL.GetNhanVien();
        public DataTable GetCaLam() => _thueTraDAL.GetCaLam();
        public DataTable GetViPham() => _thueTraDAL.GetViPham();

        public string SinhMaThueMoi() => _thueTraDAL.GenerateNewMaThue();
        public string SinhMaTraMoi() => _thueTraDAL.GenerateNewMaTra();

        public DataTable GetDanhSachPhieuThueChuaTra() => _thueTraDAL.GetDanhSachPhieuThueChuaTra();
        public DataTable GetChiTietSachChuaTra(string maThue) => _thueTraDAL.GetChiTietSachChuaTra(maThue);

        public bool LapPhieuThue(PhieuThueDTO phieu, out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(phieu.MaThue))
            {
                error = "Mã thuê không hợp lệ!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(phieu.MaKH) || string.IsNullOrWhiteSpace(phieu.MaNV))
            {
                error = "Vui lòng chọn khách hàng và nhân viên lập phiếu!";
                return false;
            }
            if (phieu.DanhSachChiTiet == null || phieu.DanhSachChiTiet.Count == 0)
            {
                error = "Phiếu thuê chưa có sách nào!";
                return false;
            }
            if (phieu.TienDatCoc < 0)
            {
                error = "Tiền đặt cọc không được âm!";
                return false;
            }

            return _thueTraDAL.LuuPhieuThue(phieu, out error);
        }

        public bool LapPhieuTra(PhieuTraDTO phieu, out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(phieu.MaTra))
            {
                error = "Mã trả không hợp lệ!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(phieu.MaThue) || string.IsNullOrWhiteSpace(phieu.MaNV))
            {
                error = "Vui lòng chọn mã thuê và nhân viên nhận trả!";
                return false;
            }
            if (phieu.DanhSachChiTiet == null || phieu.DanhSachChiTiet.Count == 0)
            {
                error = "Chưa có sách nào được chọn để trả!";
                return false;
            }

            return _thueTraDAL.LuuPhieuTra(phieu, out error);
        }
    }
}
