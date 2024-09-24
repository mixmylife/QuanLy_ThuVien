using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLQuanLyThuVien
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        public static class CurrentUser
        {
            public static string TenDangNhap { get; private set; }
            public static string LoaiNguoiDung { get; private set; }

            public static void SetUser(string tenDangNhap, string loaiNguoiDung)
            {
                TenDangNhap = tenDangNhap;
                LoaiNguoiDung = loaiNguoiDung;
            }

            public static void ClearUser()
            {
                TenDangNhap = null;
                LoaiNguoiDung = null;
            }
        }
        private void btDangNhap_Click(object sender, EventArgs e)
        {
            string sql = "select LoaiNguoiDung from NguoiDung where TenDangNhap =N'" +
             txtUserName.Text.Trim() + "' and MatKhau=N'"
             + txtPassword.Text.Trim() + "'";
            string loaiNguoiDung = TruyXuat.LayMotGiaTri(sql);

            if (loaiNguoiDung == "")
            {
                MessageBox.Show("Nhập sai thông tin tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CurrentUser.SetUser(txtUserName.Text.Trim(), loaiNguoiDung);

                this.Hide();
                DashBoard frm = new DashBoard();
                frm.Show();
            }
        }

        private void btDangKy_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
            {
                string insertSql = "INSERT INTO NguoiDung (TenDangNhap, MatKhau, LoaiNguoiDung) VALUES (N'" + userName + "', N'" + password + "', N'Độc Giả')";
                TruyXuat.ThemSuaXoa(insertSql);
                MessageBox.Show("Đăng ký thành công! Người dùng đã được tạo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienThi.Checked)
            {
                txtPassword.PasswordChar = '\0'; // '\0' là để không sử dụng ký tự ẩn điểm
            }
            else
            {
                txtPassword.PasswordChar = '*'; // Đặt lại ký tự ẩn điểm
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
