using System;
using System.Data;
using BookStore_LTTQ.DAL;
using BookStore_LTTQ.DTO;

namespace BookStore_LTTQ.BLL
{
    public class NhanVienBLL
    {
        private readonly NhanVienDAL _nhanVienDAL = new NhanVienDAL();

        public DataTable GetAllNhanVien() => _nhanVienDAL.GetAllNhanVien();
        public DataTable GetCaLam() => _nhanVienDAL.GetCaLam();
        public string SinhMaNVMoi() => _nhanVienDAL.GenerateNewMaNV();

        public bool ThemNhanVien(NhanVienDTO nv, out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(nv.TenNV))
            {
                error = "Họ và tên nhân viên không được để trống!";
                return false;
            }
            if (nv.NamSinh.HasValue && (nv.NamSinh.Value < 1900 || nv.NamSinh.Value > DateTime.Now.Year))
            {
                error = "Năm sinh không hợp lệ!";
                return false;
            }
            if (nv.LuongThang.HasValue && nv.LuongThang.Value < 0)
            {
                error = "Lương tháng không được âm!";
                return false;
            }

            if (!_nhanVienDAL.InsertNhanVien(nv))
            {
                error = "Không thể thêm nhân viên vào cơ sở dữ liệu!";
                return false;
            }
            return true;
        }

        public bool SuaNhanVien(NhanVienDTO nv, out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(nv.MaNV))
            {
                error = "Mã nhân viên không hợp lệ!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(nv.TenNV))
            {
                error = "Họ và tên nhân viên không được để trống!";
                return false;
            }
            if (nv.NamSinh.HasValue && (nv.NamSinh.Value < 1900 || nv.NamSinh.Value > DateTime.Now.Year))
            {
                error = "Năm sinh không hợp lệ!";
                return false;
            }
            if (nv.LuongThang.HasValue && nv.LuongThang.Value < 0)
            {
                error = "Lương tháng không được âm!";
                return false;
            }

            if (!_nhanVienDAL.UpdateNhanVien(nv))
            {
                error = "Không thể cập nhật nhân viên!";
                return false;
            }
            return true;
        }

        public bool XoaNhanVien(string maNV, out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(maNV))
            {
                error = "Vui lòng chọn nhân viên cần xóa!";
                return false;
            }

            if (_nhanVienDAL.KiemTraNhanVienDaLapPhieu(maNV))
            {
                error = "Không thể xóa nhân viên này vì đã lập phiếu thuê sách!";
                return false;
            }

            if (!_nhanVienDAL.DeleteNhanVien(maNV))
            {
                error = "Lỗi khi xóa nhân viên khỏi cơ sở dữ liệu!";
                return false;
            }
            return true;
        }

        public DataTable TimKiem(string ten, string maCa, string gt)
        {
            return _nhanVienDAL.TimKiemNhanVien(ten, maCa, gt);
        }
    }
}

