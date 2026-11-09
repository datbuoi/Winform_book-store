using QuanLyChoThueSach.BLL;

namespace QuanLyChoThueSach.GUI;

public partial class frmLogin : Form
{
    public frmLogin()
    {
        InitializeComponent();
    }

    private void btnDangNhap_Click(object? sender, EventArgs e)
    {
        try
        {
            Cursor = Cursors.WaitCursor;
            AppSession.NguoiDung = TaiKhoanBLL.DangNhap(txtTenDN.Text, txtMatKhau.Text);
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            UiHelper.BaoLoi(ex);
            txtMatKhau.Clear();
            txtMatKhau.Focus();
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }
}
