using System;
using System.Data;
using BookStore_LTTQ.DAL;
using BookStore_LTTQ.DTO;

namespace BookStore_LTTQ.BLL
{
    public class SachBLL
    {
        private readonly SachDAL _sachDAL = new SachDAL();

        public DataTable GetAllSach() => _sachDAL.GetAllSach();
        public DataTable GetSachConHang() => _sachDAL.GetSachConHang();

        public DataTable GetLoaiSach() => _sachDAL.GetLoaiSach();
        public DataTable GetLinhVuc() => _sachDAL.GetLinhVuc();
        public DataTable GetTacGia() => _sachDAL.GetTacGia();
        public DataTable GetNXB() => _sachDAL.GetNXB();
        public DataTable GetNgonNgu() => _sachDAL.GetNgonNgu();
        public DataTable GetTinhTrang() => _sachDAL.GetTinhTrang();

        public string SinhMaSachMoi() => _sachDAL.GenerateNewMaSach();

        public bool ThemSach(SachDTO s, out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(s.TenSach))
            {
                error = "Tên sách không được để trống!";
                return false;
            }
            if (s.GiaSach < 0 || s.DonGiaThue < 0 || s.SoLuong < 0)
            {
                error = "Giá sách, đơn giá thuê và số lượng không được âm!";
                return false;
            }

            if (!_sachDAL.InsertSach(s))
            {
                error = "Không thể thêm sách vào cơ sở dữ liệu!";
                return false;
            }
            return true;
        }

        public bool SuaSach(SachDTO s, out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(s.MaSach))
            {
                error = "Mã sách không hợp lệ!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(s.TenSach))
            {
                error = "Tên sách không được để trống!";
                return false;
            }
            if (s.GiaSach < 0 || s.DonGiaThue < 0 || s.SoLuong < 0)
            {
                error = "Giá sách, đơn giá thuê và số lượng không được âm!";
                return false;
            }

            if (!_sachDAL.UpdateSach(s))
            {
                error = "Không thể cập nhật thông tin sách!";
                return false;
            }
            return true;
        }

        public bool XoaSach(string maSach, out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(maSach))
            {
                error = "Vui lòng chọn sách cần xóa!";
                return false;
            }

            if (_sachDAL.KiemTraSachDaThue(maSach))
            {
                error = "Không thể xóa sách này vì đã phát sinh giao dịch thuê sách!";
                return false;
            }

            if (!_sachDAL.DeleteSach(maSach))
            {
                error = "Lỗi khi xóa sách khỏi cơ sở dữ liệu!";
                return false;
            }
            return true;
        }

        public DataTable TimKiem(string ten, string lv, string tg, string nxb)
        {
            return _sachDAL.TimKiemSach(ten, lv, tg, nxb);
        }
    }
}

