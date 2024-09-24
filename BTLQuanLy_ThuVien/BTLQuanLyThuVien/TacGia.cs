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
    public partial class TacGia : Form
    {
        public TacGia()
        {
            InitializeComponent();
        }

        private void TacGia_Load(object sender, EventArgs e)
        {
            gvquanlitacgia.DataSource = TruyXuat.GetTable("select * from TacGia");

            gvquanlitacgia.Columns[0].HeaderText = "Mã Tác Giả";
            gvquanlitacgia.Columns[1].HeaderText = "Tên Tác Giả";
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = TruyXuat.TaoKetNoi())
            {
                connection.Open();
                string sql = "INSERT INTO TacGia (MaTacGia, TenTacGia) " +
                             "VALUES (@MaTacGia, @TenTacGia)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@MaTacGia", txtmatacgia.Text);
                cmd.Parameters.AddWithValue("@TenTacGia", txttentacgia.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                    gvquanlitacgia.DataSource = TruyXuat.GetTable("select * from TacGia");
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
                string sql = "UPDATE TacGia " +
                    "SET MaTacGia= @MaTacGia, TenTacGia= @TenTacGia " +
                             "WHERE MaTacGia = @MaTacGia";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@MaTacGia", txtmatacgia.Text);
                cmd.Parameters.AddWithValue("@TenTacGia", txttentacgia.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                    gvquanlitacgia.DataSource = TruyXuat.GetTable("select * from TacGia");
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
            if (gvquanlitacgia.SelectedRows.Count > 0)
            {

                string maTacGia = gvquanlitacgia.SelectedRows[0].Cells["MaTacGia"].Value.ToString();


                string sql = "DELETE FROM TacGia WHERE MaTacGia = @MaTacGia";

                using (SqlConnection connection = TruyXuat.TaoKetNoi())
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@MaTacGia", maTacGia);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        gvquanlitacgia.DataSource = TruyXuat.GetTable("SELECT * FROM TacGia");
                        MessageBox.Show("Đã xóa bản ghi có MaDocGia = " + maTacGia);
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

        private void gvquanlitacgia_SelectionChanged(object sender, EventArgs e)
        {
            if (gvquanlitacgia.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = gvquanlitacgia.SelectedRows[0];

                // Lấy giá trị từ dòng đã chọn và hiển thị trong các điều khiển nhập liệu
                txtmatacgia.Text = selectedRow.Cells["MaTacGia"].Value.ToString();
                txttentacgia.Text = selectedRow.Cells["TenTacGia"].Value.ToString();
            }
        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
