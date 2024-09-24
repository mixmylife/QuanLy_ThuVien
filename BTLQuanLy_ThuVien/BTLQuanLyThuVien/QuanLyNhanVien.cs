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
    public partial class QuanLyNhanVien : Form
    {
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            gvnhanvien.DataSource = TruyXuat.GetTable("select * from NhanVien");

            gvnhanvien.Columns[0].HeaderText = "Mã Nhân Viên";
            gvnhanvien.Columns[1].HeaderText = "Tên Nhân Viên";
            gvnhanvien.Columns[2].HeaderText = "Ngày Sinh";
            gvnhanvien.Columns[3].HeaderText = "Giới Tính";
            gvnhanvien.Columns[4].HeaderText = "Số Điện Thoại";
            gvnhanvien.Columns[5].HeaderText = "Tên Đăng Nhập";

            gvnhanvien.Columns[0].AutoSizeMode =
               DataGridViewAutoSizeColumnMode.AllCells;
            gvnhanvien.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            gvnhanvien.Columns[2].AutoSizeMode =
              DataGridViewAutoSizeColumnMode.AllCells;
            gvnhanvien.Columns[3].AutoSizeMode =
              DataGridViewAutoSizeColumnMode.Fill;
            gvnhanvien.Columns[4].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            gvnhanvien.Columns[5].AutoSizeMode =
            DataGridViewAutoSizeColumnMode.Fill;
           
        }

        private void gvnhanvien_SelectionChanged(object sender, EventArgs e)
        {
            if (gvnhanvien.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = gvnhanvien.SelectedRows[0];

                // Lấy giá trị từ dòng đã chọn và hiển thị trong các điều khiển nhập liệu
                txtmanhanvien.Text = selectedRow.Cells["MaNhanVien"].Value.ToString();
                txttennhanvien.Text = selectedRow.Cells["TenNhanVien"].Value.ToString();
                dtngaysinh.Value = Convert.ToDateTime(selectedRow.Cells["NgaySinh"].Value);
                cbgioitinh.Text = selectedRow.Cells["GioiTinh"].Value.ToString();
                txtdienthoai.Text = selectedRow.Cells["SoDienThoai"].Value.ToString();
                txttendangnhap.Text = selectedRow.Cells["TenDangNhap"].Value.ToString();
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = TruyXuat.TaoKetNoi())
            {
                connection.Open();
                string sql = "INSERT INTO NhanVien (MaNhanVien, TenNhanVien, NgaySinh, GioiTinh, SoDienThoai, TenDangNhap) " +
                             "VALUES (@MaNhanVien, @TenNhanVien, @NgaySinh, @GioiTinh, @SoDienThoai, @TenDangNhap)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@MaNhanVien", txtmanhanvien.Text);
                cmd.Parameters.AddWithValue("@TenNhanVien", txttendangnhap.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtngaysinh.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", cbgioitinh.Text);
                cmd.Parameters.AddWithValue("@SoDienThoai", txtdienthoai.Text);
                cmd.Parameters.AddWithValue("@TenDangNhap", txttendangnhap.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                    gvnhanvien.DataSource = TruyXuat.GetTable("select * from NhanVien");
                    MessageBox.Show("Đã thêm bản ghi!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = TruyXuat.TaoKetNoi())
            {
                connection.Open();
                string sql = "UPDATE NhanVien " +
                             "SET TenNhanVien = @TenNhanVien, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh," +
                             " SoDienThoai = @SoDienThoai, TenDangNhap = @TenDangNhap" +
                             "WHERE MaNhanVien = @MaNhanVien";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@MaNhanVien", txtmanhanvien.Text);
                cmd.Parameters.AddWithValue("@TenNhanVien", txttendangnhap.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtngaysinh.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", cbgioitinh.Text);
                cmd.Parameters.AddWithValue("@SoDienThoai", txtdienthoai.Text);
                cmd.Parameters.AddWithValue("@TenDangNhap", txttendangnhap.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                    gvnhanvien.DataSource = TruyXuat.GetTable("select * from DocGia");
                    MessageBox.Show("Đã sửa bản ghi!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message);
                }
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn một dòng cụ thể trong DataGridView chưa
            if (gvnhanvien.SelectedRows.Count > 0)
            {
                // Lấy giá trị trong cột "MaDocGia" của dòng đang được chọn
                string MaNhanVien = gvnhanvien.SelectedRows[0].Cells["MaNhanVien"].Value.ToString();

                // Xây dựng câu lệnh SQL để xóa dữ liệu dựa trên MaDocGia
                string sql = "DELETE FROM NhanVien WHERE MaNhanVien = @MaNhanVien";

                using (SqlConnection connection = TruyXuat.TaoKetNoi())
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        gvnhanvien.DataSource = TruyXuat.GetTable("SELECT * FROM MaNhanVien");
                        MessageBox.Show("Đã xóa bản ghi có MaNhanVien = " + MaNhanVien);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bản ghi để xóa.");
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
