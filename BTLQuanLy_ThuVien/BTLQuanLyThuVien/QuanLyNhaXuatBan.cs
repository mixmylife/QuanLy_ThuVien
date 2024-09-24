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
    public partial class QuanLyNhaXuatBan : Form
    {
        public QuanLyNhaXuatBan()
        {
            InitializeComponent();
        }

        private void QuanLyNhaXuatBan_Load(object sender, EventArgs e)
        {
            gvnhaxuatban.DataSource = TruyXuat.GetTable("select * from NhaXuatBan");

            gvnhaxuatban.Columns[0].HeaderText = "Mã Nhà Xuất Bản";
            gvnhaxuatban.Columns[1].HeaderText = "Tên Nhà Xuất Bản";
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = TruyXuat.TaoKetNoi())
            {
                connection.Open();
                string sql = "INSERT INTO NhaXuatBan  (MaNhaXuatBan, TenNhaXuatBan) " +
                             "VALUES (@MaNhaXuatBan, @TenNhaXuatBan)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@MaNhaXuatBan", txtmanhaxuatban.Text);
                cmd.Parameters.AddWithValue("@TenNhaXuatBan", txttennhaxuatban.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                    gvnhaxuatban.DataSource = TruyXuat.GetTable("select * from NhaXuatBan");
                    MessageBox.Show("Đã thêm bản ghi!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
                }
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = TruyXuat.TaoKetNoi())
            {
                connection.Open();
                string sql = "UPDATE NhaXuatBan " +
                    "SET MaNhaXuatBan= @MaNhaXuatBan, TenNhaXuatBan= @TenNhaXuatBan " +
                             "WHERE MaNhaXuatBan = @MaNhaXuatBan";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@MaNhaXuatBan", txtmanhaxuatban.Text);
                cmd.Parameters.AddWithValue("@TenNhaXuatBan", txttennhaxuatban.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                    gvnhaxuatban.DataSource = TruyXuat.GetTable("select * from NhaXuatBan");
                    MessageBox.Show("Đã sửa bản ghi!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message);
                }
            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (gvnhaxuatban.SelectedRows.Count > 0)
            {

                string maNhaXuatBan = gvnhaxuatban.SelectedRows[0].Cells["MaNhaXuatBan"].Value.ToString();


                string sql = "DELETE FROM NhaXuatBan WHERE MaNhaXuatBan = @MaNhaXuatBan";

                using (SqlConnection connection = TruyXuat.TaoKetNoi())
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@MaNhaXuatBan", maNhaXuatBan);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        gvnhaxuatban.DataSource = TruyXuat.GetTable("SELECT * FROM NhaXuatBan");
                        MessageBox.Show("Đã xóa bản ghi có MaNhaXuatBan = " + maNhaXuatBan);
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

        private void btthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
