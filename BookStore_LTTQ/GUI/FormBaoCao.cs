using System;
using System.Data;
using System.Windows.Forms;
using BookStore_LTTQ.BLL;

namespace BookStore_LTTQ.GUI
{
    public partial class FormBaoCao : Form
    {
        private readonly BaoCaoBLL _baoCaoBLL = new BaoCaoBLL();

        public FormBaoCao()
        {
            InitializeComponent();
        }

        private void FormBaoCao_Load(object sender, EventArgs e)
        {
            numNamDoanhThu.Value = DateTime.Now.Year;
            dtpTop5TuNgay.Value = new DateTime(DateTime.Now.Year - 1, 1, 1);
            dtpTop5DenNgay.Value = DateTime.Now;

            LoadBaoCaoChuaTra();
            LoadBaoCaoDoanhThu();
            LoadBaoCaoTop5();
        }

        // =========================================================================
        // YÊU CẦU 7: Báo cáo danh sách các sách truyện đang được thuê chưa trả
        // =========================================================================
        private void LoadBaoCaoChuaTra()
        {
            DataTable dt = _baoCaoBLL.GetBaoCaoChuaTra();
            dgvChuaTra.DataSource = dt;

            if (dgvChuaTra.Columns.Contains("MaThue")) dgvChuaTra.Columns["MaThue"].HeaderText = "Mã thuê";
            if (dgvChuaTra.Columns.Contains("TenKH")) dgvChuaTra.Columns["TenKH"].HeaderText = "Khách hàng";
            if (dgvChuaTra.Columns.Contains("MaSach")) dgvChuaTra.Columns["MaSach"].HeaderText = "Mã sách";
            if (dgvChuaTra.Columns.Contains("TenSach")) dgvChuaTra.Columns["TenSach"].HeaderText = "Tên sách";
            if (dgvChuaTra.Columns.Contains("SoLuong")) dgvChuaTra.Columns["SoLuong"].HeaderText = "SL";
            if (dgvChuaTra.Columns.Contains("NgayThue"))
            {
                dgvChuaTra.Columns["NgayThue"].HeaderText = "Ngày thuê";
                dgvChuaTra.Columns["NgayThue"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvChuaTra.Columns.Contains("SoNgayDaThue")) dgvChuaTra.Columns["SoNgayDaThue"].HeaderText = "Số ngày đã thuê";
            if (dgvChuaTra.Columns.Contains("TienThueTamTinh"))
            {
                dgvChuaTra.Columns["TienThueTamTinh"].HeaderText = "Tiền thuê tạm tính";
                dgvChuaTra.Columns["TienThueTamTinh"].DefaultCellStyle.Format = "N0";
            }
            if (dgvChuaTra.Columns.Contains("TienDatCoc"))
            {
                dgvChuaTra.Columns["TienDatCoc"].HeaderText = "Tiền đặt cọc";
                dgvChuaTra.Columns["TienDatCoc"].DefaultCellStyle.Format = "N0";
            }
            if (dgvChuaTra.Columns.Contains("NhanVienLap")) dgvChuaTra.Columns["NhanVienLap"].HeaderText = "NV lập phiếu";

            // Tổng kết
            int tongSL = 0;
            decimal tongTien = 0;
            foreach (DataRow r in dt.Rows)
            {
                tongSL += Convert.ToInt32(r["SoLuong"]);
                tongTien += Convert.ToDecimal(r["TienThueTamTinh"]);
            }

            lblTongChuaTra.Text = "Tổng số sách đang mượn chưa trả: " + tongSL + " cuốn | Tiền thuê tạm tính: " + tongTien.ToString("N0") + " VNĐ";
        }

        private void btnLamMoiTab1_Click(object sender, EventArgs e)
        {
            LoadBaoCaoChuaTra();
        }

        // =========================================================================
        // YÊU CẦU 8: Báo cáo tổng tiền cho thuê thu được theo Tháng, Quý, Năm
        // =========================================================================
        private void LoadBaoCaoDoanhThu()
        {
            string kieu = "THANG";
            if (radQuy.Checked) kieu = "QUY";
            else if (radNam.Checked) kieu = "NAM";

            int nam = (int)numNamDoanhThu.Value;

            DataTable dt = _baoCaoBLL.GetBaoCaoDoanhThu(kieu, nam);
            dgvDoanhThu.DataSource = dt;

            string tenKy = "Tháng";
            if (kieu == "QUY") tenKy = "Quý";
            else if (kieu == "NAM") tenKy = "Năm";

            if (dgvDoanhThu.Columns.Contains("Ky")) dgvDoanhThu.Columns["Ky"].HeaderText = tenKy;
            if (dgvDoanhThu.Columns.Contains("SoPhieuTra")) dgvDoanhThu.Columns["SoPhieuTra"].HeaderText = "Số phiếu đã trả";
            if (dgvDoanhThu.Columns.Contains("DoanhThu"))
            {
                dgvDoanhThu.Columns["DoanhThu"].HeaderText = "Tổng doanh thu (VNĐ)";
                dgvDoanhThu.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
            }

            decimal tong = 0;
            foreach (DataRow r in dt.Rows)
            {
                if (r["DoanhThu"] != DBNull.Value)
                    tong += Convert.ToDecimal(r["DoanhThu"]);
            }

            lblTongDoanhThu.Text = "Tổng doanh thu thu được (" + tenKy + " - Năm " + nam + "): " + tong.ToString("N0") + " VNĐ";
        }

        private void radDoanhThu_CheckedChanged(object sender, EventArgs e)
        {
            numNamDoanhThu.Enabled = !radNam.Checked;
        }

        private void btnXemDoanhThu_Click(object sender, EventArgs e)
        {
            LoadBaoCaoDoanhThu();
        }

        // =========================================================================
        // YÊU CẦU 9: Báo cáo danh sách 5 sách truyện đạt doanh thu nhiều nhất
        // =========================================================================
        private void LoadBaoCaoTop5(bool toanBo = false)
        {
            DateTime? tu = toanBo ? (DateTime?)null : dtpTop5TuNgay.Value.Date;
            DateTime? den = toanBo ? (DateTime?)null : dtpTop5DenNgay.Value.Date;

            DataTable dt = _baoCaoBLL.GetBaoCaoTop5(tu, den);
            dgvTop5.DataSource = dt;

            if (dgvTop5.Columns.Contains("Hang")) dgvTop5.Columns["Hang"].HeaderText = "Hạng";
            if (dgvTop5.Columns.Contains("MaSach")) dgvTop5.Columns["MaSach"].HeaderText = "Mã sách";
            if (dgvTop5.Columns.Contains("TenSach")) dgvTop5.Columns["TenSach"].HeaderText = "Tên sách truyện";
            if (dgvTop5.Columns.Contains("TenTG")) dgvTop5.Columns["TenTG"].HeaderText = "Tác giả";
            if (dgvTop5.Columns.Contains("TenLV")) dgvTop5.Columns["TenLV"].HeaderText = "Lĩnh vực";
            if (dgvTop5.Columns.Contains("SoLanThue")) dgvTop5.Columns["SoLanThue"].HeaderText = "Số lượt thuê";
            if (dgvTop5.Columns.Contains("DoanhThu"))
            {
                dgvTop5.Columns["DoanhThu"].HeaderText = "Doanh thu đạt được (VNĐ)";
                dgvTop5.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
            }
        }

        private void btnXemTop5_Click(object sender, EventArgs e)
        {
            if (dtpTop5TuNgay.Value.Date > dtpTop5DenNgay.Value.Date)
            {
                MessageBox.Show("Từ ngày không thể lớn hơn đến ngày!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadBaoCaoTop5(false);
        }

        private void btnXemTatCaTop5_Click(object sender, EventArgs e)
        {
            LoadBaoCaoTop5(true);
        }
    }
}
