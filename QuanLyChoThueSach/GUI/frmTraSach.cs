using System.Data;
using QuanLyChoThueSach.BLL;
using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.GUI;

public partial class frmTraSach : Form
{
    private const string CotChon = "colChon";
    private const string CotViPham = "colViPham";

    /// <summary>Các dòng sách chưa trả của phiếu thuê đang chọn.</summary>
    private readonly DataTable _dong = new();

    /// <summary>Danh sách vi phạm kèm dòng "(Không vi phạm)" có mã 0.</summary>
    private DataTable _viPham = new();
    private Dictionary<int, decimal> _tienPhat = new();

    private bool _dangNap;

    public frmTraSach()
    {
        InitializeComponent();

        _dong.Columns.Add("Chon", typeof(bool));
        _dong.Columns.Add("MaSach", typeof(int));
        _dong.Columns.Add("TenSach", typeof(string));
        _dong.Columns.Add("SoLuong", typeof(int));
        _dong.Columns.Add("DonGiaThue", typeof(decimal));
        _dong.Columns.Add("MaViPham", typeof(int));
        _dong.Columns.Add("TienPhat", typeof(decimal));
        _dong.Columns.Add("ThanhTien", typeof(decimal));
    }

    private void frmTraSach_Load(object? sender, EventArgs e)
    {
        if (DesignMode) return;
        try
        {
            NapViPham();
            TaoCotLuoi();

            UiHelper.GanCombo(cboNV, NhanVienBLL.LayDanhSachRutGon(), "TenNV", "MaNV");
            if (AppSession.NguoiDung?.MaNV is { } maNV) cboNV.SelectedValue = maNV;

            NapPhieu();
        }
        catch (Exception ex) { UiHelper.BaoLoi(ex); }
    }

    private void NapViPham()
    {
        var dt = DanhMucBLL.LayTatCa(DanhMucs.ViPham).Copy();
        _tienPhat = dt.AsEnumerable().ToDictionary(r => (int)r["MaViPham"], r => (decimal)r["TienPhat"]);

        var khong = dt.NewRow();
        khong["MaViPham"] = 0;
        khong["TenViPham"] = "(Không vi phạm)";
        khong["TienPhat"] = 0m;
        dt.Rows.InsertAt(khong, 0);
        _viPham = dt;
    }

    private void TaoCotLuoi()
    {
        UiHelper.CauHinhLuoi(dgv, chiDoc: false);
        dgv.AutoGenerateColumns = false;
        dgv.Columns.Clear();

        dgv.Columns.Add(new DataGridViewCheckBoxColumn
        {
            Name = CotChon, DataPropertyName = "Chon", HeaderText = "Trả", MinimumWidth = 60
        });
        dgv.Columns.Add(Cot("MaSach", "Mã sách"));
        dgv.Columns.Add(Cot("TenSach", "Tên sách"));
        dgv.Columns.Add(Cot("SoLuong", "Số lượng thuê"));
        dgv.Columns.Add(Cot("DonGiaThue", "Đơn giá thuê", UiHelper.DinhDangTien));
        dgv.Columns.Add(new DataGridViewComboBoxColumn
        {
            Name = CotViPham,
            DataPropertyName = "MaViPham",
            HeaderText = "Vi phạm",
            DataSource = _viPham,
            ValueMember = "MaViPham",
            DisplayMember = "TenViPham",
            FlatStyle = FlatStyle.Flat,
            MinimumWidth = 170
        });
        dgv.Columns.Add(Cot("TienPhat", "Tiền phạt", UiHelper.DinhDangTien));
        dgv.Columns.Add(Cot("ThanhTien", "Thành tiền", UiHelper.DinhDangTien));

        dgv.DataSource = _dong;
        UiHelper.HoanTatLuoi(dgv);
    }

    private static DataGridViewTextBoxColumn Cot(string thuocTinh, string tieuDe, string? dinhDang = null)
    {
        var c = new DataGridViewTextBoxColumn
        {
            Name = "col" + thuocTinh, DataPropertyName = thuocTinh, HeaderText = tieuDe, ReadOnly = true
        };
        if (dinhDang is not null)
        {
            c.DefaultCellStyle.Format = dinhDang;
            c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        return c;
    }

    // ---- Phiếu thuê chưa trả ----

    private void NapPhieu()
    {
        _dangNap = true;
        try
        {
            UiHelper.GanCombo(cboPhieu, TraSachBLL.LayPhieuChuaTra(), "MoTa", "MaThue");
        }
        finally
        {
            _dangNap = false;
        }
        NapChiTiet();
    }

    private void cboPhieu_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_dangNap) return;
        try { NapChiTiet(); }
        catch (Exception ex) { UiHelper.BaoLoi(ex); }
    }

    /// <summary>Yêu cầu 3: chỉ nạp các sách chưa trả của phiếu thuê đang chọn.</summary>
    private void NapChiTiet()
    {
        _dong.Rows.Clear();
        if (cboPhieu.SelectedValue is int maThue)
        {
            foreach (DataRow r in TraSachBLL.LayChiTietChuaTra(maThue).Rows)
            {
                var don = (decimal)r["DonGiaThue"];
                var sl = (int)r["SoLuong"];
                _dong.Rows.Add(true, (int)r["MaSach"], (string)r["TenSach"], sl, don,
                    0, 0m, TraSachBLL.TinhThanhTien(don, sl));
            }
        }
        CapNhatTong();
    }

    // ---- Tính tiền ----

    private void dgv_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
    {
        // Ghi nhận ngay khi tick ô "Trả" hoặc chọn vi phạm, không chờ rời ô.
        if (dgv.IsCurrentCellDirty)
            dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }

    private void dgv_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        var ten = dgv.Columns[e.ColumnIndex].Name;
        if (ten != CotChon && ten != CotViPham) return;

        if (dgv.Rows[e.RowIndex].DataBoundItem is DataRowView v)
        {
            if (ten == CotViPham) TinhLaiDong(v.Row);
            CapNhatTong();
        }
    }

    private void dgv_DataError(object? sender, DataGridViewDataErrorEventArgs e) => e.ThrowException = false;

    /// <summary>Yêu cầu 4: Thành tiền = Đơn giá thuê * Số lượng thuê + Tiền phạt (nếu có).</summary>
    private void TinhLaiDong(DataRow r)
    {
        var maViPham = (int)r["MaViPham"];
        var phat = maViPham != 0 && _tienPhat.TryGetValue(maViPham, out var p) ? p : 0m;
        r["TienPhat"] = phat;
        r["ThanhTien"] = TraSachBLL.TinhThanhTien((decimal)r["DonGiaThue"], (int)r["SoLuong"], phat);
    }

    private void CapNhatTong()
    {
        if (_dong.Rows.Count == 0)
        {
            lblTong.Text = cboPhieu.Items.Count == 0
                ? "Không có phiếu thuê nào còn sách chưa trả."
                : "Tổng tiền: 0";
            return;
        }

        var tong = _dong.AsEnumerable().Where(r => (bool)r["Chon"]).Sum(r => (decimal)r["ThanhTien"]);
        lblTong.Text = $"Tổng tiền: {tong:N0}";
    }

    // ---- Lưu / làm mới ----

    private void btnLuu_Click(object? sender, EventArgs e)
    {
        try
        {
            dgv.EndEdit();

            if (cboPhieu.SelectedValue is not int maThue)
            {
                UiHelper.CanhBao("Vui lòng chọn phiếu thuê.");
                return;
            }

            var phieu = new TraSachDTO
            {
                MaThue = maThue,
                MaNV = UiHelper.GiaTriInt(cboNV) ?? 0,
                NgayTra = dtpNgayTra.Value.Date,
                ChiTiet = _dong.AsEnumerable()
                    .Where(r => (bool)r["Chon"])
                    .Select(r => new ChiTietTraDTO
                    {
                        MaSach = (int)r["MaSach"],
                        MaViPham = (int)r["MaViPham"] == 0 ? null : (int)r["MaViPham"]
                    })
                    .ToList()
            };

            var maTra = TraSachBLL.TaoPhieu(phieu);
            UiHelper.ThongBao($"Đã lưu phiếu trả số {maTra}.\nTổng tiền: {phieu.TongTien:N0}");
            dtpNgayTra.Value = DateTime.Today;
            NapPhieu();
        }
        catch (Exception ex)
        {
            UiHelper.BaoLoi(ex);
        }
    }

    private void btnLamMoi_Click(object? sender, EventArgs e)
    {
        try
        {
            dtpNgayTra.Value = DateTime.Today;
            NapPhieu();
        }
        catch (Exception ex) { UiHelper.BaoLoi(ex); }
    }
}
