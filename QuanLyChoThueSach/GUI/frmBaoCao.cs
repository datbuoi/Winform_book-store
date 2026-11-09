using System.Data;
using QuanLyChoThueSach.BLL;
using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.GUI;

public partial class frmBaoCao : Form
{
    public frmBaoCao()
    {
        InitializeComponent();
    }

    private void frmBaoCao_Load(object? sender, EventArgs e)
    {
        if (DesignMode) return;
        UiHelper.CauHinhLuoi(dgvChuaTra);
        UiHelper.CauHinhLuoi(dgvDoanhThu);
        UiHelper.CauHinhLuoi(dgvTop5);
        cboKieu.SelectedIndex = 0;
        LamMoiTabHienTai();
    }

    /// <summary>Nạp lại dữ liệu mỗi khi chuyển tab, vì dữ liệu có thể đã thay đổi từ các form khác.</summary>
    private void tabControl1_SelectedIndexChanged(object? sender, EventArgs e) => LamMoiTabHienTai();

    private void LamMoiTabHienTai()
    {
        try
        {
            if (tabControl1.SelectedTab == tabChuaTra) NapChuaTra();
            else if (tabControl1.SelectedTab == tabDoanhThu) NapDoanhThu();
            else if (tabControl1.SelectedTab == tabTop5) NapTop5();
        }
        catch (Exception ex) { UiHelper.BaoLoi(ex); }
    }

    // ---- Báo cáo 7: sách đang thuê chưa trả ----

    private void NapChuaTra()
    {
        var dt = BaoCaoBLL.SachDangThueChuaTra();
        dgvChuaTra.DataSource = dt;

        UiHelper.Cot(dgvChuaTra, "MaThue", "Mã thuê");
        UiHelper.Cot(dgvChuaTra, "NgayThue", "Ngày thuê", UiHelper.DinhDangNgay);
        UiHelper.Cot(dgvChuaTra, "TenKhach", "Khách hàng");
        UiHelper.Cot(dgvChuaTra, "MaSach", "Mã sách");
        UiHelper.Cot(dgvChuaTra, "TenSach", "Tên sách");
        UiHelper.Cot(dgvChuaTra, "SoLuong", "Số lượng");
        UiHelper.Cot(dgvChuaTra, "DonGiaThue", "Đơn giá thuê", UiHelper.DinhDangTien);
        UiHelper.Cot(dgvChuaTra, "TenNV", "Nhân viên lập phiếu");
        UiHelper.HoanTatLuoi(dgvChuaTra);

        lblSoChuaTra.Text = dt.Rows.Count == 0
            ? "Không có sách nào đang được thuê."
            : $"Có {dt.Rows.Count} dòng sách đang được thuê chưa trả.";
    }

    private void btnXemChuaTra_Click(object? sender, EventArgs e) => LamMoiTabHienTai();

    // ---- Báo cáo 8: tiền thuê theo tháng / quý / năm ----

    private void NapDoanhThu()
    {
        var kieu = cboKieu.SelectedIndex switch
        {
            1 => ThongKeKieu.Quy,
            2 => ThongKeKieu.Nam,
            _ => ThongKeKieu.Thang
        };

        var dt = BaoCaoBLL.DoanhThu(kieu);
        dgvDoanhThu.DataSource = dt;

        UiHelper.Cot(dgvDoanhThu, "Nam", "Năm");
        UiHelper.Cot(dgvDoanhThu, "Thang", "Tháng");
        UiHelper.Cot(dgvDoanhThu, "Quy", "Quý");
        UiHelper.Cot(dgvDoanhThu, "SoPhieuTra", "Số phiếu trả");
        UiHelper.Cot(dgvDoanhThu, "TongTien", "Tổng tiền", UiHelper.DinhDangTien);
        UiHelper.HoanTatLuoi(dgvDoanhThu);

        var tong = dt.AsEnumerable().Sum(r => (decimal)r["TongTien"]);
        lblTongDoanhThu.Text = dt.Rows.Count == 0 ? "Chưa có phiếu trả nào." : $"Tổng cộng: {tong:N0}";
    }

    private void btnXemDoanhThu_Click(object? sender, EventArgs e) => LamMoiTabHienTai();

    // ---- Báo cáo 9: 5 sách doanh thu cao nhất ----

    private void NapTop5()
    {
        dgvTop5.DataSource = BaoCaoBLL.Top5SachDoanhThu();

        UiHelper.Cot(dgvTop5, "MaSach", "Mã sách");
        UiHelper.Cot(dgvTop5, "TenSach", "Tên sách");
        UiHelper.Cot(dgvTop5, "SoLanThue", "Số lần thuê");
        UiHelper.Cot(dgvTop5, "DoanhThu", "Doanh thu", UiHelper.DinhDangTien);
        UiHelper.HoanTatLuoi(dgvTop5);
    }

    private void btnXemTop5_Click(object? sender, EventArgs e) => LamMoiTabHienTai();
}
