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
    public partial class QuanLyDocGia : Form
    {
        public QuanLyDocGia()
        {
            InitializeComponent();
        }

        private void pictureBoxNgua_Click(object sender, EventArgs e)
        {

        }

        private void btSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = TruyXuat.TaoKetNoi())
            {
                connection.Open();
                string sql = "UPDATE DocGia " +
                             "SET TenDocGia = @TenDocGia, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh," +
                             " DiaChi = @DiaChi, LopHoc = @LopHoc, NgayTaoThe = @NgayTaoThe," +
                             " MaNhanVienTaoThe = @MaNhanVienTaoThe, TenDangNhap = @TenDangNhap " +
                             "WHERE MaDocGia = @MaDocGia";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@MaDocGia", txtMaDocGia.Text);
                cmd.Parameters.AddWithValue("@TenDocGia", txtTenDocGia.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtNgaySinh.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", txtGioiTinh.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@LopHoc", comboBoxLopHoc.Text);
                cmd.Parameters.AddWithValue("@NgayTaoThe", dtNgayTaoThe.Value);
                cmd.Parameters.AddWithValue("@MaNhanVienTaoThe", txtMaNhanVienTaoThe.Text);
                cmd.Parameters.AddWithValue("@TenDangNhap", txtTenDangNhap.Text);

                try
                {
                    cmd.ExecuteNonQuery();
                    gvDanhSachDocGia.DataSource = TruyXuat.GetTable("select * from DocGia");
                    MessageBox.Show("Đã sửa bản ghi!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message);
                }
            }
        }

        private void btSapXep_Click(object sender, EventArgs e)
        {
            // Sắp xếp dữ liệu trong DataTable dựa trên cột "MaDocGia"
            DataTable table = (DataTable)gvDanhSachDocGia.DataSource;
            DataView view = table.DefaultView;
            view.Sort = "TenDocGia ASC";  // Sắp xếp theo cột "MaDocGia" theo thứ tự tăng dần (ASC)

            // Cập nhật dữ liệu trong DataGridView
            gvDanhSachDocGia.DataSource = view.ToTable();

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn một dòng cụ thể trong DataGridView chưa
            if (gvDanhSachDocGia.SelectedRows.Count > 0)
            {
                // Lấy giá trị trong cột "MaDocGia" của dòng đang được chọn
                string maDocGia = gvDanhSachDocGia.SelectedRows[0].Cells["MaDocGia"].Value.ToString();

                // Xây dựng câu lệnh SQL để xóa dữ liệu dựa trên MaDocGia
                string sql = "DELETE FROM DocGia WHERE MaDocGia = @MaDocGia";

                using (SqlConnection connection = TruyXuat.TaoKetNoi())
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@MaDocGia", maDocGia);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        gvDanhSachDocGia.DataSource = TruyXuat.GetTable("SELECT * FROM DocGia");
                        MessageBox.Show("Đã xóa bản ghi có MaDocGia = " + maDocGia);
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

        private void btThem_Click(object sender, EventArgs e)
        {
            /*string sql = "INSERT INTO DocGia (MaDocGia, TenDocGia, NgaySinh, GioiTinh, DiaChi, LopHoc, NgayTaoThe, MaNhanVienTaoThe, TenDangNhap) " +
                             "VALUES (N'" +
                             txtMaDocGia.Text + "', '" +
                             txtTenDocGia.Text + "', '" +
                             dtNgaySinh.Value.ToString("yyyy-MM-dd") + "', N'" +
                             txtGioiTinh.Text + "', N'" +
                             txtDiaChi.Text + "', N'" +
                             comboBoxLopHoc.Text + "', '" +
                             dtNgayTaoThe.Value.ToString("yyyy-MM-dd") + "', " +
                             txtMaNhanVienTaoThe.Text + ", N'" +
                             txtTenDangNhap.Text + "')";
            TruyXuat.ThemSuaXoa(sql);
            gvDanhSachDocGia.DataSource = TruyXuat.GetTable("select * from DocGia");
            MessageBox.Show("Đã thêm bản ghi!");*/
            using (SqlConnection connection = TruyXuat.TaoKetNoi())
            {
                connection.Open();
                string sql = "INSERT INTO DocGia (MaDocGia, TenDocGia, NgaySinh, GioiTinh, DiaChi, LopHoc, NgayTaoThe, MaNhanVienTaoThe, TenDangNhap) " +
                             "VALUES (@MaDocGia, @TenDocGia, @NgaySinh, @GioiTinh, @DiaChi, @LopHoc, @NgayTaoThe, @MaNhanVienTaoThe, @TenDangNhap)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@MaDocGia", txtMaDocGia.Text);
                cmd.Parameters.AddWithValue("@TenDocGia", txtTenDocGia.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtNgaySinh.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", txtGioiTinh.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@LopHoc", comboBoxLopHoc.Text);
                cmd.Parameters.AddWithValue("@NgayTaoThe", dtNgayTaoThe.Value);
                cmd.Parameters.AddWithValue("@MaNhanVienTaoThe", txtMaNhanVienTaoThe.Text);
                cmd.Parameters.AddWithValue("@TenDangNhap", txtTenDangNhap.Text);

                try
                {
                    cmd.ExecuteNonQuery();
                    gvDanhSachDocGia.DataSource = TruyXuat.GetTable("select * from DocGia");
                    MessageBox.Show("Đã thêm bản ghi!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
                }
            }

        }

        private void gvDanhSachDocGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void groupBoxTieuDe_Enter(object sender, EventArgs e)
        {

        }

        private void groupBoxChinh_Enter(object sender, EventArgs e)
        {

        }

        private void QuanLyDocGia_Load(object sender, EventArgs e)
        {
            gvDanhSachDocGia.DataSource = TruyXuat.GetTable("select * from DocGia");

            gvDanhSachDocGia.Columns[0].HeaderText = "Mã Độc Giả";
            gvDanhSachDocGia.Columns[1].HeaderText = "Tên Độc Giả";
            gvDanhSachDocGia.Columns[2].HeaderText = "Ngày Sinh";
            gvDanhSachDocGia.Columns[3].HeaderText = "Giới Tính";
            gvDanhSachDocGia.Columns[4].HeaderText = "Địa Chỉ";
            gvDanhSachDocGia.Columns[5].HeaderText = "Lớp Học";
            gvDanhSachDocGia.Columns[6].HeaderText = "Ngày Tạo Thẻ";
            gvDanhSachDocGia.Columns[7].HeaderText = "Mã Nhân Viên Tạo Thẻ";
            gvDanhSachDocGia.Columns[8].HeaderText = "Tên Đăng Nhập";

            gvDanhSachDocGia.Columns[0].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            gvDanhSachDocGia.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            gvDanhSachDocGia.Columns[2].AutoSizeMode =
              DataGridViewAutoSizeColumnMode.AllCells;
            gvDanhSachDocGia.Columns[3].AutoSizeMode =
              DataGridViewAutoSizeColumnMode.AllCells;
            gvDanhSachDocGia.Columns[4].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            gvDanhSachDocGia.Columns[5].AutoSizeMode =
            DataGridViewAutoSizeColumnMode.Fill;
            gvDanhSachDocGia.Columns[6].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            gvDanhSachDocGia.Columns[7].AutoSizeMode =
            DataGridViewAutoSizeColumnMode.AllCells;
            gvDanhSachDocGia.Columns[8].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text;
            DataTable table = (DataTable)gvDanhSachDocGia.DataSource;
            DataView view = table.DefaultView;
            view.RowFilter = "MaDocGia = " + keyword + " OR TenDocGia LIKE N'%" + keyword + "%'";
            gvDanhSachDocGia.DataSource = view.ToTable();
        }

        private void btTim_TextChanged(object sender, EventArgs e)
        {         
        }

        private void gvDanhSachDocGia_SelectionChanged(object sender, EventArgs e)
        {
            if (gvDanhSachDocGia.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = gvDanhSachDocGia.SelectedRows[0];

                // Lấy giá trị từ dòng đã chọn và hiển thị trong các điều khiển nhập liệu
                txtMaDocGia.Text = selectedRow.Cells["MaDocGia"].Value.ToString();
                txtTenDocGia.Text = selectedRow.Cells["TenDocGia"].Value.ToString();
                dtNgaySinh.Value = Convert.ToDateTime(selectedRow.Cells["NgaySinh"].Value);
                txtGioiTinh.Text = selectedRow.Cells["GioiTinh"].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells["DiaChi"].Value.ToString();
                comboBoxLopHoc.Text = selectedRow.Cells["LopHoc"].Value.ToString();
                dtNgayTaoThe.Value = Convert.ToDateTime(selectedRow.Cells["NgayTaoThe"].Value);
                txtMaNhanVienTaoThe.Text = selectedRow.Cells["MaNhanVienTaoThe"].Value.ToString();
                txtTenDangNhap.Text = selectedRow.Cells["TenDangNhap"].Value.ToString();
            }
        }

        private void btTaiLai_Click(object sender, EventArgs e)
        {
            gvDanhSachDocGia.DataSource = TruyXuat.GetTable("select * from DocGia");

            gvDanhSachDocGia.Columns[0].HeaderText = "Mã Độc Giả";
            gvDanhSachDocGia.Columns[1].HeaderText = "Tên Độc Giả";
            gvDanhSachDocGia.Columns[2].HeaderText = "Ngày Sinh";
            gvDanhSachDocGia.Columns[3].HeaderText = "Giới Tính";
            gvDanhSachDocGia.Columns[4].HeaderText = "Địa Chỉ";
            gvDanhSachDocGia.Columns[5].HeaderText = "Lớp Học";
            gvDanhSachDocGia.Columns[6].HeaderText = "Ngày Tạo Thẻ";
            gvDanhSachDocGia.Columns[7].HeaderText = "Mã Nhân Viên Tạo Thẻ";
            gvDanhSachDocGia.Columns[8].HeaderText = "Tên Đăng Nhập";
        }
    }
}
