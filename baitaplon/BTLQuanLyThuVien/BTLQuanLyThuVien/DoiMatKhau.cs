using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLQuanLyThuVien
{
    public partial class DoiMatKhau : Form
    {
        private string tenDangNhap;
        public DoiMatKhau(string tenDangNhap)
        {
            InitializeComponent();
            this.tenDangNhap = tenDangNhap;
        }

        private void btcapnhat_Click(object sender, EventArgs e)
        {
            string matKhauCu = txtmatkhaucu.Text;
            string matKhauMoi = txtmatkhaumoi.Text;
            string nhapLaiMatKhauMoi = txtnhaplai.Text;

            if (string.IsNullOrEmpty(matKhauCu) || string.IsNullOrEmpty(matKhauMoi) || string.IsNullOrEmpty(nhapLaiMatKhauMoi))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!KiemTraMatKhauCu(matKhauCu))
            {
                MessageBox.Show("Mật khẩu cũ không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (matKhauMoi != nhapLaiMatKhauMoi)
            {
                MessageBox.Show("Mật khẩu mới và nhập lại mật khẩu mới không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DoiMatKhauu(matKhauMoi))
            {
                MessageBox.Show("Đổi mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form sau khi đổi mật khẩu thành công
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi đổi mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool KiemTraMatKhauCu(string matKhauCu)
        {
            string matKhauDatabase = TruyXuat.LayMotGiaTri($"SELECT MatKhau FROM NguoiDung WHERE TenDangNhap = '{tenDangNhap}'");
            return matKhauCu == matKhauDatabase;
        }

        private bool DoiMatKhauu(string matKhauMoi)
        {
            try
            {
                TruyXuat.ThemSuaXoa($"UPDATE NguoiDung SET MatKhau = '{matKhauMoi}' WHERE TenDangNhap = '{tenDangNhap}'");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
