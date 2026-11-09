using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BookStore_LTTQ.BLL;
using BookStore_LTTQ.DTO;

namespace BookStore_LTTQ.GUI
{
    public partial class FormSach : Form
    {
        private readonly SachBLL _sachBLL = new SachBLL();
        private bool isThemMoi = false;

        public FormSach()
        {
            InitializeComponent();
        }

        private void FormSach_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadDataSach();
            SetButtonState(true);
            LockInputs(true);
        }

        private void LoadComboBoxes()
        {
            // Loại sách
            cboLoaiSach.DataSource = _sachBLL.GetLoaiSach();
            cboLoaiSach.DisplayMember = "TenLoai";
            cboLoaiSach.ValueMember = "MaLoai";

            // Lĩnh vực
            DataTable dtLV = _sachBLL.GetLinhVuc();
            cboLinhVuc.DataSource = dtLV;
            cboLinhVuc.DisplayMember = "TenLV";
            cboLinhVuc.ValueMember = "MaLV";

            DataTable dtLVTim = dtLV.Copy();
            DataRow rLV = dtLVTim.NewRow();
            rLV["MaLV"] = "";
            rLV["TenLV"] = "-- Tất cả lĩnh vực --";
            dtLVTim.Rows.InsertAt(rLV, 0);
            cboTimLinhVuc.DataSource = dtLVTim;
            cboTimLinhVuc.DisplayMember = "TenLV";
            cboTimLinhVuc.ValueMember = "MaLV";

            // Tác giả
            DataTable dtTG = _sachBLL.GetTacGia();
            cboTacGia.DataSource = dtTG;
            cboTacGia.DisplayMember = "TenTG";
            cboTacGia.ValueMember = "MaTG";

            DataTable dtTGTim = dtTG.Copy();
            DataRow rTG = dtTGTim.NewRow();
            rTG["MaTG"] = "";
            rTG["TenTG"] = "-- Tất cả tác giả --";
            dtTGTim.Rows.InsertAt(rTG, 0);
            cboTimTacGia.DataSource = dtTGTim;
            cboTimTacGia.DisplayMember = "TenTG";
            cboTimTacGia.ValueMember = "MaTG";

            // NXB
            DataTable dtNXB = _sachBLL.GetNXB();
            cboNXB.DataSource = dtNXB;
            cboNXB.DisplayMember = "TenNXB";
            cboNXB.ValueMember = "MaNXB";

            DataTable dtNXBTim = dtNXB.Copy();
            DataRow rNXB = dtNXBTim.NewRow();
            rNXB["MaNXB"] = "";
            rNXB["TenNXB"] = "-- Tất cả NXB --";
            dtNXBTim.Rows.InsertAt(rNXB, 0);
            cboTimNXB.DataSource = dtNXBTim;
            cboTimNXB.DisplayMember = "TenNXB";
            cboTimNXB.ValueMember = "MaNXB";

            // Ngôn ngữ
            cboNgonNgu.DataSource = _sachBLL.GetNgonNgu();
            cboNgonNgu.DisplayMember = "TenNN";
            cboNgonNgu.ValueMember = "MaNN";

            // Tình trạng
            cboTinhTrang.DataSource = _sachBLL.GetTinhTrang();
            cboTinhTrang.DisplayMember = "TenTT";
            cboTinhTrang.ValueMember = "MaTT";
        }

        private void LoadDataSach(DataTable dt = null)
        {
            if (dt == null)
            {
                dt = _sachBLL.GetAllSach();
            }

            dgvSach.DataSource = dt;

            // Đặt tên cột tiếng Việt đẹp mắt
            if (dgvSach.Columns.Contains("MaSach")) dgvSach.Columns["MaSach"].HeaderText = "Mã sách";
            if (dgvSach.Columns.Contains("TenSach")) dgvSach.Columns["TenSach"].HeaderText = "Tên sách";
            if (dgvSach.Columns.Contains("TenLoai")) dgvSach.Columns["TenLoai"].HeaderText = "Loại";
            if (dgvSach.Columns.Contains("TenLV")) dgvSach.Columns["TenLV"].HeaderText = "Lĩnh vực";
            if (dgvSach.Columns.Contains("TenTG")) dgvSach.Columns["TenTG"].HeaderText = "Tác giả";
            if (dgvSach.Columns.Contains("TenNXB")) dgvSach.Columns["TenNXB"].HeaderText = "NXB";
            if (dgvSach.Columns.Contains("SoLuong")) dgvSach.Columns["SoLuong"].HeaderText = "Tồn kho";
            if (dgvSach.Columns.Contains("DonGiaThue"))
            {
                dgvSach.Columns["DonGiaThue"].HeaderText = "Đơn giá thuê";
                dgvSach.Columns["DonGiaThue"].DefaultCellStyle.Format = "N0";
            }
            if (dgvSach.Columns.Contains("GiaSach"))
            {
                dgvSach.Columns["GiaSach"].HeaderText = "Giá sách";
                dgvSach.Columns["GiaSach"].DefaultCellStyle.Format = "N0";
            }

            // Ẩn các cột mã khóa ngoại không cần hiển thị trực tiếp
            string[] hideCols = { "MaLoai", "MaLV", "MaTG", "MaNXB", "MaNN", "MaTT", "Anh", "GhiChu", "TenNN", "TenTT", "SoTrang" };
            foreach (string col in hideCols)
            {
                if (dgvSach.Columns.Contains(col))
                {
                    dgvSach.Columns[col].Visible = false;
                }
            }
        }

        private void SetButtonState(bool normal)
        {
            btnThem.Enabled = normal;
            btnSua.Enabled = normal && dgvSach.Rows.Count > 0;
            btnXoa.Enabled = normal && dgvSach.Rows.Count > 0;
            btnLuu.Enabled = !normal;
            btnBoQua.Enabled = !normal;
        }

        private void LockInputs(bool locked)
        {
            txtMaSach.ReadOnly = true; // Luôn readonly vì sinh tự động hoặc chọn từ bảng
            txtTenSach.ReadOnly = locked;
            cboLoaiSach.Enabled = !locked;
            cboLinhVuc.Enabled = !locked;
            cboTacGia.Enabled = !locked;
            cboNXB.Enabled = !locked;
            cboNgonNgu.Enabled = !locked;
            cboTinhTrang.Enabled = !locked;
            numSoTrang.Enabled = !locked;
            numGiaSach.Enabled = !locked;
            numDonGiaThue.Enabled = !locked;
            numSoLuong.Enabled = !locked;
            txtGhiChu.ReadOnly = locked;
            btnChonAnh.Enabled = !locked;
        }

        private void ClearInputs()
        {
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtAnh.Clear();
            txtGhiChu.Clear();
            numSoTrang.Value = 0;
            numGiaSach.Value = 0;
            numDonGiaThue.Value = 0;
            numSoLuong.Value = 0;
            picAnh.Image = null;
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvSach.Rows.Count) return;

            DataGridViewRow r = dgvSach.Rows[e.RowIndex];
            txtMaSach.Text = r.Cells["MaSach"].Value?.ToString().Trim();
            txtTenSach.Text = r.Cells["TenSach"].Value?.ToString();

            if (r.Cells["MaLoai"].Value != null) cboLoaiSach.SelectedValue = r.Cells["MaLoai"].Value.ToString().Trim();
            if (r.Cells["MaLV"].Value != null) cboLinhVuc.SelectedValue = r.Cells["MaLV"].Value.ToString().Trim();
            if (r.Cells["MaTG"].Value != null) cboTacGia.SelectedValue = r.Cells["MaTG"].Value.ToString().Trim();
            if (r.Cells["MaNXB"].Value != null) cboNXB.SelectedValue = r.Cells["MaNXB"].Value.ToString().Trim();
            if (r.Cells["MaNN"].Value != null) cboNgonNgu.SelectedValue = r.Cells["MaNN"].Value.ToString().Trim();
            if (r.Cells["MaTT"].Value != null) cboTinhTrang.SelectedValue = r.Cells["MaTT"].Value.ToString().Trim();

            numSoTrang.Value = Convert.ToDecimal(r.Cells["SoTrang"].Value ?? 0);
            numGiaSach.Value = Convert.ToDecimal(r.Cells["GiaSach"].Value ?? 0);
            numDonGiaThue.Value = Convert.ToDecimal(r.Cells["DonGiaThue"].Value ?? 0);
            numSoLuong.Value = Convert.ToDecimal(r.Cells["SoLuong"].Value ?? 0);

            txtAnh.Text = r.Cells["Anh"].Value?.ToString();
            txtGhiChu.Text = r.Cells["GhiChu"].Value?.ToString();

            HienThiAnh(txtAnh.Text);
            SetButtonState(true);
        }

        private void HienThiAnh(string fileName)
        {
            try
            {
                if (!string.IsNullOrEmpty(fileName))
                {
                    string path = Path.Combine(Application.StartupPath, "Images", fileName);
                    if (File.Exists(path))
                    {
                        picAnh.Image = Image.FromFile(path);
                        return;
                    }
                }
                picAnh.Image = null;
            }
            catch
            {
                picAnh.Image = null;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isThemMoi = true;
            ClearInputs();
            LockInputs(false);
            SetButtonState(false);

            txtMaSach.Text = _sachBLL.SinhMaSachMoi();
            txtTenSach.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSach.Text))
            {
                MessageBox.Show("Vui lòng chọn sách cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            isThemMoi = false;
            LockInputs(false);
            SetButtonState(false);
            txtTenSach.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSach.Text))
            {
                MessageBox.Show("Vui lòng chọn sách cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa cuốn sách '" + txtTenSach.Text + "' không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (_sachBLL.XoaSach(txtMaSach.Text.Trim(), out string error))
                {
                    MessageBox.Show("Đã xóa sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataSach();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show(error, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SachDTO s = new SachDTO
            {
                MaSach = txtMaSach.Text.Trim(),
                TenSach = txtTenSach.Text.Trim(),
                MaLoai = cboLoaiSach.SelectedValue?.ToString(),
                MaLV = cboLinhVuc.SelectedValue?.ToString(),
                MaTG = cboTacGia.SelectedValue?.ToString(),
                MaNXB = cboNXB.SelectedValue?.ToString(),
                MaNN = cboNgonNgu.SelectedValue?.ToString(),
                SoTrang = (int)numSoTrang.Value,
                GiaSach = numGiaSach.Value,
                DonGiaThue = numDonGiaThue.Value,
                MaTT = cboTinhTrang.SelectedValue?.ToString(),
                SoLuong = (int)numSoLuong.Value,
                Anh = txtAnh.Text.Trim(),
                GhiChu = txtGhiChu.Text.Trim()
            };

            if (isThemMoi)
            {
                if (_sachBLL.ThemSach(s, out string error))
                {
                    MessageBox.Show("Thêm mới sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataSach();
                    LockInputs(true);
                    SetButtonState(true);
                }
                else
                {
                    MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (_sachBLL.SuaSach(s, out string error))
                {
                    MessageBox.Show("Cập nhật thông tin sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataSach();
                    LockInputs(true);
                    SetButtonState(true);
                }
                else
                {
                    MessageBox.Show(error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            LockInputs(true);
            SetButtonState(true);
            if (dgvSach.CurrentRow != null)
            {
                dgvSach_CellClick(dgvSach, new DataGridViewCellEventArgs(0, dgvSach.CurrentRow.Index));
            }
            else
            {
                ClearInputs();
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Title = "Chọn ảnh bìa sách truyện";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtAnh.Text = Path.GetFileName(ofd.FileName);
                    picAnh.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        // YÊU CẦU 5: Tìm kiếm Sách truyện theo tiêu chí: Tên sách, Lĩnh vực, Tác giả, NXB
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string ten = txtTimTenSach.Text.Trim();
            string lv = cboTimLinhVuc.SelectedValue?.ToString().Trim();
            string tg = cboTimTacGia.SelectedValue?.ToString().Trim();
            string nxb = cboTimNXB.SelectedValue?.ToString().Trim();

            DataTable dt = _sachBLL.TimKiem(ten, lv, tg, nxb);
            LoadDataSach(dt);

            MessageBox.Show("Tìm thấy " + dt.Rows.Count + " sách truyện thỏa mãn tiêu chí!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLamMoiTim_Click(object sender, EventArgs e)
        {
            txtTimTenSach.Clear();
            cboTimLinhVuc.SelectedIndex = 0;
            cboTimTacGia.SelectedIndex = 0;
            cboTimNXB.SelectedIndex = 0;
            LoadDataSach();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
