using System.Data;
using QuanLyChoThueSach.BLL;
using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.GUI;

public partial class frmThueSach : Form
{
    /// <summary>Sách còn trong kho (SoLuong &gt; 0).</summary>
    private DataTable _kho = new();

    /// <summary>Các sách đã thêm vào phiếu thuê đang lập (chưa lưu).</summary>
    private readonly DataTable _gio = new();

    public frmThueSach()
    {
        InitializeComponent();

        _gio.Columns.Add("MaSach", typeof(int));
        _gio.Columns.Add("TenSach", typeof(string));
        _gio.Columns.Add("SoLuong", typeof(int));
        _gio.Columns.Add("DonGiaThue", typeof(decimal));
        _gio.Columns.Add("ThanhTien", typeof(decimal));
    }

    private void frmThueSach_Load(object? sender, EventArgs e)
    {
        if (DesignMode) return;
        try
        {
            UiHelper.CauHinhLuoi(dgv);
            dgv.DataSource = _gio;
            UiHelper.Cot(dgv, "MaSach", "Mã sách");
            UiHelper.Cot(dgv, "TenSach", "Tên sách");
            UiHelper.Cot(dgv, "SoLuong", "Số lượng");
            UiHelper.Cot(dgv, "DonGiaThue", "Đơn giá thuê", UiHelper.DinhDangTien);
            UiHelper.Cot(dgv, "ThanhTien", "Thành tiền (tạm tính)", UiHelper.DinhDangTien);
            UiHelper.HoanTatLuoi(dgv);

            UiHelper.GanCombo(cboKhach, DanhMucBLL.LayTatCa(DanhMucs.KhachHang), "TenKhach", "MaKhach");
            UiHelper.GanCombo(cboNV, NhanVienBLL.LayDanhSachRutGon(), "TenNV", "MaNV");
            UiHelper.GanCombo(cboCa, DanhMucBLL.LayTatCa(DanhMucs.CaLam), "TenCa", "MaCa");

            // Mặc định là nhân viên đang đăng nhập (nếu tài khoản có gắn nhân viên).
            if (AppSession.NguoiDung?.MaNV is { } maNV) cboNV.SelectedValue = maNV;

            NapKho();
            CapNhatTong();
        }
        catch (Exception ex) { UiHelper.BaoLoi(ex); }
    }

    // ---- Sách trong kho ----

    private void NapKho()
    {
        _kho = SachTruyenBLL.LayConTrongKho();   // Yêu cầu 1: chỉ sách có số lượng > 0
        UiHelper.GanCombo(cboSach, _kho, "TenSach", "MaSach");
        CapNhatConLai();
    }

    private int TonKho(int maSach)
    {
        var dong = _kho.AsEnumerable().FirstOrDefault(r => (int)r["MaSach"] == maSach);
        return dong is null ? 0 : (int)dong["SoLuong"];
    }

    private DataRow? DongTrongGio(int maSach) =>
        _gio.AsEnumerable().FirstOrDefault(r => (int)r["MaSach"] == maSach);

    /// <summary>Số cuốn còn có thể thêm = tồn kho trừ số đã thêm vào phiếu này.</summary>
    private int ConLai(int maSach) =>
        TonKho(maSach) - (DongTrongGio(maSach) is { } d ? (int)d["SoLuong"] : 0);

    private void CapNhatConLai()
    {
        var con = cboSach.SelectedValue is int ma ? ConLai(ma) : 0;
        lblCon.Text = "Còn: " + con;
        nudSoLuong.Maximum = Math.Max(con, 1);
        nudSoLuong.Value = 1;
    }

    private void cboSach_SelectedIndexChanged(object? sender, EventArgs e) => CapNhatConLai();

    // ---- Giỏ (chi tiết phiếu) ----

    private void btnThemSach_Click(object? sender, EventArgs e)
    {
        if (cboSach.SelectedValue is not int maSach)
        {
            UiHelper.CanhBao("Vui lòng chọn sách.");
            return;
        }

        var soLuong = (int)nudSoLuong.Value;
        var con = ConLai(maSach);
        if (con <= 0 || soLuong > con)
        {
            UiHelper.CanhBao($"Sách này chỉ còn {Math.Max(con, 0)} cuốn có thể thêm vào phiếu.");
            return;
        }

        var kho = _kho.AsEnumerable().First(r => (int)r["MaSach"] == maSach);
        var donGia = (decimal)kho["DonGiaThue"];

        var dong = DongTrongGio(maSach);
        if (dong is null)
        {
            _gio.Rows.Add(maSach, (string)kho["TenSach"], soLuong, donGia,
                TraSachBLL.TinhThanhTien(donGia, soLuong));
        }
        else
        {
            var moi = (int)dong["SoLuong"] + soLuong;
            dong["SoLuong"] = moi;
            dong["ThanhTien"] = TraSachBLL.TinhThanhTien(donGia, moi);
        }

        CapNhatConLai();
        CapNhatTong();
    }

    private void btnBoSach_Click(object? sender, EventArgs e)
    {
        if (dgv.SelectedRows.Count == 0 || dgv.SelectedRows[0].DataBoundItem is not DataRowView v)
        {
            UiHelper.CanhBao("Vui lòng chọn một sách trong phiếu để bỏ.");
            return;
        }
        _gio.Rows.Remove(v.Row);
        CapNhatConLai();
        CapNhatTong();
    }

    private void CapNhatTong()
    {
        var tongSL = _gio.AsEnumerable().Sum(r => (int)r["SoLuong"]);
        var tamTinh = _gio.AsEnumerable().Sum(r => (decimal)r["ThanhTien"]);
        lblTong.Text = $"Tổng số lượng: {tongSL}     Tạm tính: {tamTinh:N0}";
    }

    // ---- Lưu / làm mới ----

    private void btnLuu_Click(object? sender, EventArgs e)
    {
        try
        {
            var phieu = new ThueSachDTO
            {
                MaKhach = UiHelper.GiaTriInt(cboKhach) ?? 0,
                MaNV = UiHelper.GiaTriInt(cboNV) ?? 0,
                MaCa = UiHelper.GiaTriInt(cboCa) ?? 0,
                NgayThue = dtpNgayThue.Value.Date,
                TienDatCoc = nudCoc.Value,
                ChiTiet = _gio.AsEnumerable()
                    .Select(r => new ChiTietThueDTO { MaSach = (int)r["MaSach"], SoLuong = (int)r["SoLuong"] })
                    .ToList()
            };

            var maThue = ThueSachBLL.TaoPhieu(phieu);
            UiHelper.ThongBao($"Đã lưu phiếu thuê số {maThue}.");
            LamMoi();
        }
        catch (Exception ex)
        {
            UiHelper.BaoLoi(ex);
            // Kho có thể đã thay đổi (ví dụ máy khác vừa cho thuê) nên nạp lại.
            try { NapKho(); } catch (Exception) { /* giữ nguyên danh sách hiện tại */ }
        }
    }

    private void btnLamMoi_Click(object? sender, EventArgs e)
    {
        try { LamMoi(); }
        catch (Exception ex) { UiHelper.BaoLoi(ex); }
    }

    private void LamMoi()
    {
        _gio.Rows.Clear();
        nudCoc.Value = 0;
        dtpNgayThue.Value = DateTime.Today;
        NapKho();
        CapNhatTong();
    }
}
