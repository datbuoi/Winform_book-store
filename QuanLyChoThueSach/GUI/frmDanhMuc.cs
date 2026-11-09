using System.Data;
using QuanLyChoThueSach.BLL;
using QuanLyChoThueSach.DTO;

namespace QuanLyChoThueSach.GUI;

/// <summary>
/// Form quản lý dùng chung cho các bảng danh mục đơn giản (khách hàng, tác giả, NXB, lĩnh vực...).
/// Phần khung (lưới, nút) nằm trong Designer; các ô nhập được sinh theo <see cref="DanhMucInfo"/>.
/// </summary>
public partial class frmDanhMuc : Form
{
    private static readonly string[] GioiTinhItems = { "", "Nam", "Nữ", "Khác" };

    private readonly DanhMucInfo _info;
    private readonly Dictionary<string, Control> _editors = new();
    private int _idDangChon;   // 0 = chưa chọn dòng nào

    public DanhMucInfo Info => _info;

    /// <summary>Constructor không tham số chỉ để Visual Studio mở được màn hình thiết kế.</summary>
    public frmDanhMuc() : this(DanhMucs.LinhVuc) { }

    public frmDanhMuc(DanhMucInfo info)
    {
        _info = info;
        InitializeComponent();
        Text = "Danh mục - " + info.TieuDe;
        TaoOCapNhat();
    }

    private void frmDanhMuc_Load(object? sender, EventArgs e)
    {
        if (DesignMode) return;
        UiHelper.CauHinhLuoi(dgv);
        NapLuoi();
    }

    // ---- Dựng ô nhập theo mô tả cột ----

    private void TaoOCapNhat()
    {
        tlpFields.Controls.Clear();
        tlpFields.RowStyles.Clear();
        _editors.Clear();
        tlpFields.RowCount = _info.Cot.Count;

        for (var i = 0; i < _info.Cot.Count; i++)
        {
            var cot = _info.Cot[i];
            var label = new Label
            {
                Text = cot.Nhan + (cot.BatBuoc ? " *" : ""),
                AutoSize = true,
                Anchor = AnchorStyles.Left,
                Margin = new Padding(3, 9, 3, 9)
            };
            var editor = TaoEditor(cot);
            editor.Name = "edt" + cot.Ten;
            editor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            editor.Margin = new Padding(3, 6, 3, 6);

            tlpFields.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpFields.Controls.Add(label, 0, i);
            tlpFields.Controls.Add(editor, 1, i);
            _editors[cot.Ten] = editor;
        }
    }

    private static Control TaoEditor(CotInfo cot)
    {
        switch (cot.Kieu)
        {
            case KieuCot.Int:
                return new NumericUpDown { Minimum = 0, Maximum = int.MaxValue };

            case KieuCot.Decimal:
                return new NumericUpDown
                {
                    Minimum = 0, Maximum = 9_999_999_999m, DecimalPlaces = 0, ThousandsSeparator = true
                };

            case KieuCot.Date:
                return new DateTimePicker
                {
                    Format = DateTimePickerFormat.Short,
                    ShowCheckBox = !cot.BatBuoc,
                    MaxDate = DateTime.Today,
                    Value = DateTime.Today,
                    Checked = false
                };

            case KieuCot.GioiTinh:
                var cbo = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
                cbo.Items.AddRange(GioiTinhItems);
                cbo.SelectedIndex = 0;
                return cbo;

            default:
                return new TextBox { MaxLength = cot.DoDai > 0 ? cot.DoDai : 32767 };
        }
    }

    // ---- Đọc / ghi giá trị ô nhập ----

    private Dictionary<string, object?> LayGiaTri()
    {
        var kq = new Dictionary<string, object?>();
        foreach (var cot in _info.Cot)
        {
            var ctl = _editors[cot.Ten];
            kq[cot.Ten] = cot.Kieu switch
            {
                KieuCot.Int => (int)((NumericUpDown)ctl).Value,
                KieuCot.Decimal => ((NumericUpDown)ctl).Value,
                KieuCot.Date => ((DateTimePicker)ctl) is { ShowCheckBox: true, Checked: false }
                    ? null
                    : (object?)((DateTimePicker)ctl).Value.Date,
                KieuCot.GioiTinh => ((ComboBox)ctl).SelectedItem as string,
                _ => ((TextBox)ctl).Text
            };
        }
        return kq;
    }

    private void DatGiaTri(DataRow? dong)
    {
        foreach (var cot in _info.Cot)
        {
            var ctl = _editors[cot.Ten];
            var v = dong is null || dong[cot.Ten] == DBNull.Value ? null : dong[cot.Ten];

            switch (cot.Kieu)
            {
                case KieuCot.Int:
                case KieuCot.Decimal:
                    var num = (NumericUpDown)ctl;
                    var so = v is null ? 0m : Convert.ToDecimal(v);
                    num.Value = Math.Min(Math.Max(so, num.Minimum), num.Maximum);
                    break;

                case KieuCot.Date:
                    var dtp = (DateTimePicker)ctl;
                    if (v is DateTime ngay)
                    {
                        dtp.Value = ngay.Date > dtp.MaxDate ? dtp.MaxDate : ngay.Date;
                        dtp.Checked = true;
                    }
                    else
                    {
                        dtp.Value = DateTime.Today;
                        dtp.Checked = false;
                    }
                    break;

                case KieuCot.GioiTinh:
                    var cbo = (ComboBox)ctl;
                    var idx = v is string g ? Array.IndexOf(GioiTinhItems, g) : 0;
                    cbo.SelectedIndex = idx < 0 ? 0 : idx;
                    break;

                default:
                    ((TextBox)ctl).Text = v as string ?? "";
                    break;
            }
        }
    }

    // ---- Lưới ----

    private void NapLuoi(int? chonId = null)
    {
        dgv.DataSource = DanhMucBLL.LayTatCa(_info);

        UiHelper.Cot(dgv, _info.KhoaChinh, "Mã");
        foreach (var cot in _info.Cot)
        {
            var dinhDang = cot.Kieu switch
            {
                KieuCot.Date => UiHelper.DinhDangNgay,
                KieuCot.Decimal => UiHelper.DinhDangTien,
                _ => null
            };
            UiHelper.Cot(dgv, cot.Ten, cot.Nhan, dinhDang);
        }
        UiHelper.HoanTatLuoi(dgv);

        if (chonId is { } id)
        {
            foreach (DataGridViewRow r in dgv.Rows)
            {
                if (r.DataBoundItem is DataRowView v && Convert.ToInt32(v[_info.KhoaChinh]) == id)
                {
                    r.Selected = true;
                    dgv.FirstDisplayedScrollingRowIndex = r.Index;
                    return;
                }
            }
        }

        dgv.ClearSelection();
        DatGiaTri(null);
        _idDangChon = 0;
    }

    private void dgv_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].DataBoundItem is DataRowView v)
        {
            _idDangChon = Convert.ToInt32(v[_info.KhoaChinh]);
            DatGiaTri(v.Row);
        }
        else
        {
            _idDangChon = 0;
            DatGiaTri(null);
        }
    }

    // ---- Nút ----

    private void btnThem_Click(object? sender, EventArgs e)
    {
        try
        {
            var id = DanhMucBLL.Them(_info, LayGiaTri());
            NapLuoi(id);
        }
        catch (Exception ex) { UiHelper.BaoLoi(ex); }
    }

    private void btnSua_Click(object? sender, EventArgs e)
    {
        if (_idDangChon == 0)
        {
            UiHelper.CanhBao("Vui lòng chọn một dòng để sửa.");
            return;
        }
        try
        {
            DanhMucBLL.Sua(_info, _idDangChon, LayGiaTri());
            NapLuoi(_idDangChon);
        }
        catch (Exception ex) { UiHelper.BaoLoi(ex); }
    }

    private void btnXoa_Click(object? sender, EventArgs e)
    {
        if (_idDangChon == 0)
        {
            UiHelper.CanhBao("Vui lòng chọn một dòng để xóa.");
            return;
        }
        if (!UiHelper.XacNhan("Bạn có chắc muốn xóa dòng đang chọn?")) return;
        try
        {
            DanhMucBLL.Xoa(_info, _idDangChon);
            NapLuoi();
        }
        catch (Exception ex) { UiHelper.BaoLoi(ex); }
    }

    private void btnNhapMoi_Click(object? sender, EventArgs e)
    {
        dgv.ClearSelection();
        DatGiaTri(null);
        _idDangChon = 0;
    }
}
