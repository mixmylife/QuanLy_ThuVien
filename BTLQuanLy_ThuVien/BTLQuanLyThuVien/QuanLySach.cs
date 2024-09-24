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
    public partial class QuanLySach : Form
    {
        public QuanLySach()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void QuanLySach_Load(object sender, EventArgs e)
        {

            gvQuanLySach.DataSource = TruyXuat.GetTable("select * from Sach");

            gvQuanLySach.Columns[0].HeaderText = "Mã Sách";
            gvQuanLySach.Columns[1].HeaderText = "Tên Sách";
            gvQuanLySach.Columns[2].HeaderText = "Loại Sách";
            gvQuanLySach.Columns[3].HeaderText = "Mã Tác Giả";
            gvQuanLySach.Columns[4].HeaderText = "Mã Nhà Xuất Bản";
            gvQuanLySach.Columns[5].HeaderText = "Ngày Xuất Bản";
            gvQuanLySach.Columns[6].HeaderText = "Số Lượng";

            gvQuanLySach.Columns[0].AutoSizeMode =
              DataGridViewAutoSizeColumnMode.Fill;
            gvQuanLySach.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            gvQuanLySach.Columns[2].AutoSizeMode =
              DataGridViewAutoSizeColumnMode.Fill;
            gvQuanLySach.Columns[3].AutoSizeMode =
              DataGridViewAutoSizeColumnMode.Fill;
            gvQuanLySach.Columns[4].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            gvQuanLySach.Columns[5].AutoSizeMode =
            DataGridViewAutoSizeColumnMode.Fill;
            gvQuanLySach.Columns[6].AutoSizeMode =
           DataGridViewAutoSizeColumnMode.Fill;


        }

        private void btThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = TruyXuat.TaoKetNoi())
            {
                connection.Open();
                string sql = "INSERT INTO Sach (MaSach, TenSach, LoaiSach, MaTacGia, MaNhaXuatBan, NgayXuatBan, SoLuong) " +
                             "VALUES (@MaSach, @TenSach, @LoaiSach, @MaTacGia, @MaNhaXuatBan, @NgayXuatBan, @SoLuong)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@MaSach", txtMaSach.Text);
                cmd.Parameters.AddWithValue("@TenSach", txtTenSach.Text);
                cmd.Parameters.AddWithValue("@LoaiSach", txtLoaiSach.Text);
                cmd.Parameters.AddWithValue("@MaTacGia", txtMaTacGia.Text);
                cmd.Parameters.AddWithValue("@MaNhaXuatBan", txtMaNXB.Text);
                cmd.Parameters.AddWithValue("@NgayXuatBan", dtNgayXB.Value);
                cmd.Parameters.AddWithValue("@SoLuong", txtSoLuong.Text);

                try
                {
                    cmd.ExecuteNonQuery();
                    gvQuanLySach.DataSource = TruyXuat.GetTable("select * from Sach");
                    MessageBox.Show("Đã thêm bản ghi!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
                }
            }
        }

        private void gvQuanLySach_SelectionChanged(object sender, EventArgs e)
        {
            if (gvQuanLySach.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = gvQuanLySach.SelectedRows[0];

                txtMaSach.Text = selectedRow.Cells["MaSach"].Value.ToString();
                txtTenSach.Text = selectedRow.Cells["TenSach"].Value.ToString();
                txtLoaiSach.Text = selectedRow.Cells["LoaiSach"].Value.ToString();
                txtMaTacGia.Text = selectedRow.Cells["MaTacGia"].Value.ToString();
                txtMaNXB.Text = selectedRow.Cells["MaNhaXuatBan"].Value.ToString();
                dtNgayXB.Value = Convert.ToDateTime(selectedRow.Cells["NgayXuatBan"].Value);
                txtSoLuong.Text = selectedRow.Cells["SoLuong"].Value.ToString();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = TruyXuat.TaoKetNoi())
            {
                connection.Open();
                string sql = "UPDATE Sach " +
                 "SET TenSach = @TenSach, LoaiSach = @LoaiSach, MaTacGia = @MaTacGia," +
                 " MaNhaXuatBan = @MaNhaXuatBan, NgayXuatBan = @NgayXuatBan, SoLuong = @SoLuong " +
                 "WHERE MaSach = @MaSach";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@MaSach", txtMaSach.Text);
                cmd.Parameters.AddWithValue("@TenSach", txtTenSach.Text);
                cmd.Parameters.AddWithValue("@LoaiSach", txtLoaiSach.Text);
                cmd.Parameters.AddWithValue("@MaTacGia", txtMaTacGia.Text);
                cmd.Parameters.AddWithValue("@MaNhaXuatBan", txtMaNXB.Text);
                cmd.Parameters.AddWithValue("@NgayXuatBan", dtNgayXB.Value);
                cmd.Parameters.AddWithValue("@SoLuong", txtSoLuong.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                    gvQuanLySach.DataSource = TruyXuat.GetTable("select * from DocGia");
                    MessageBox.Show("Đã sửa bản ghi!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message);
                }
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (gvQuanLySach.SelectedRows.Count > 0)
            {

                string maDocGia = gvQuanLySach.SelectedRows[0].Cells["MaSach"].Value.ToString();

                string sql = "DELETE FROM Sach WHERE MaSach = @MaSach";

                using (SqlConnection connection = TruyXuat.TaoKetNoi())
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@MaSach", maDocGia);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        gvQuanLySach.DataSource = TruyXuat.GetTable("SELECT * FROM Sach");
                        MessageBox.Show("Đã xóa bản ghi có MaSach = " + maDocGia);
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


        private void btSapXep_Click_1(object sender, EventArgs e)
        {
            DataTable table = (DataTable)gvQuanLySach.DataSource;
            DataView view = table.DefaultView;
            view.Sort = "TenSach ASC";

            gvQuanLySach.DataSource = view.ToTable();
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text;
            DataTable table = (DataTable)gvQuanLySach.DataSource;
            DataView view = table.DefaultView;
            view.RowFilter = "MaSach = " + keyword + " OR TenSach LIKE '%" + keyword + "%'";
            gvQuanLySach.DataSource = view.ToTable();
        }

        private void btTaiLai_Click(object sender, EventArgs e)
        {
            gvQuanLySach.DataSource = TruyXuat.GetTable("select * from Sach");

            gvQuanLySach.Columns[0].HeaderText = "Mã Sách";
            gvQuanLySach.Columns[1].HeaderText = "Tên Sách";
            gvQuanLySach.Columns[2].HeaderText = "Loại Sách";
            gvQuanLySach.Columns[3].HeaderText = "Mã Tác Giả";
            gvQuanLySach.Columns[4].HeaderText = "Mã Nhà Xuất Bản";
            gvQuanLySach.Columns[5].HeaderText = "Ngày Xuất Bản";
            gvQuanLySach.Columns[6].HeaderText = "Số Lượng";
        }
        private string loaiNguoiDung; // Biến lưu trữ loại người dùng

        public QuanLySach(string loaiNguoiDung)
        {
            InitializeComponent();
            this.loaiNguoiDung = loaiNguoiDung;
            PhanQuyen(loaiNguoiDung);
        }
        private void PhanQuyen(string loaiNguoiDung)
        {
            switch (loaiNguoiDung)
            {
                case "Quản Lý":
                    // Hiển thị tất cả các chức năng cho quản lý
                    btThem.Enabled = true;
                    btSua.Enabled = true;
                    btXoa.Enabled = true;
                    btSapXep.Enabled = true;
                    btThoat.Enabled = true;
                    break;

                case "Thủ Thư":
                    // Hiển thị chức năng thêm, sửa, xóa
                    btThem.Enabled = true;
                    btSua.Enabled = true;
                    btXoa.Enabled = true;
                    btSapXep.Enabled = true;
                    btThoat.Enabled = true;
                    break;

                case "Độc Giả":
                    // Ẩn các chức năng thêm, sửa, xóa
                    btThem.Enabled = false;
                    btSua.Enabled = false;
                    btXoa.Enabled = false;
                    btSapXep.Enabled = true;
                    btThoat.Enabled = true;
                    break;
            }
        }
    }

}
