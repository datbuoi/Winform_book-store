using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using BookStore_LTTQ.DAL;

namespace BookStore_LTTQ.GUI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            KiemTraKetNoi();
        }

        private void KiemTraKetNoi()
        {
            try
            {
                using (SqlConnection conn = DataProcess.GetConnection())
                {
                    statusLabelCSDL.Text = " | CSDL: QLChoThueSach (Kết nối thành công)";
                    statusLabelTrangThai.Text = "Hệ thống: Sẵn sàng phục vụ";
                }
            }
            catch (Exception ex)
            {
                statusLabelCSDL.Text = " | CSDL: Mất kết nối!";
                statusLabelTrangThai.Text = "Lỗi kết nối CSDL";
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu QLChoThueSach:\n" + ex.Message,
                    "Thông báo kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void menuItemKetNoi_Click(object sender, EventArgs e)
        {
            KiemTraKetNoi();
            MessageBox.Show("Kiểm tra kết nối CSDL thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            FormSach f = new FormSach();
            f.ShowDialog(); 
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            FormNhanVien f = new FormNhanVien();
            f.ShowDialog();
        }

        private void btnThueSach_Click(object sender, EventArgs e)
        {
            FormThueSach f = new FormThueSach();
            f.ShowDialog();
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            FormTraSach f = new FormTraSach();
            f.ShowDialog();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            FormBaoCao f = new FormBaoCao();
            f.ShowDialog();
        }

        private void menuItemThongTin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CHƯƠNG TRÌNH QUẢN LÝ CỬA HÀNG CHO THUÊ SÁCH TRUYỆN\n" +
                            "Môn học: Lập trình trực quan (C# WinForms + SQL Server)\n" +
                            "Kiến trúc chuẩn 3 lớp: GUI - BLL - DAL - DTO\n" +
                            "Hỗ trợ đầy đủ 9 yêu cầu đề bài.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void groupBoxNav_Enter(object sender, EventArgs e)
        {

        }

        private void statusLabelTrangThai_Click(object sender, EventArgs e)
        {

        }
    }
}
