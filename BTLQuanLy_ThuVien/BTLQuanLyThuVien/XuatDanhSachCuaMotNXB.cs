using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace BTLQuanLyThuVien
{
    public partial class XuatDanhSachCuaMotNXB : Form
    {
        public XuatDanhSachCuaMotNXB()
        {
            InitializeComponent();
            LoadTenNhaXuatBan();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbNXB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy dòng được chọn từ ComboBox
            DataRowView selectedRow = (DataRowView)cbNXB.SelectedItem;

            // Lấy mã nhà xuất bản từ dòng được chọn
            int maNhaXuatBan = Convert.ToInt32(selectedRow["MaNhaXuatBan"]);

            // Gọi phương thức để load dữ liệu vào DataGridView
            LoadDataToDataGridView(maNhaXuatBan);
        }

        private void LoadDataToDataGridView(int maNhaXuatBan)
        {
            try
            {
                // Viết truy vấn SQL để lấy dữ liệu từ bảng Sach theo mã nhà xuất bản
                string query = $"SELECT NhaXuatBan.MaNhaXuatBan, NhaXuatBan.TenNhaXuatBan, Sach.MaSach, Sach.TenSach " +
                               $"FROM Sach " +
                               $"JOIN NhaXuatBan ON Sach.MaNhaXuatBan = NhaXuatBan.MaNhaXuatBan " +
                               $"WHERE NhaXuatBan.MaNhaXuatBan = {maNhaXuatBan}";

                // Lấy DataTable từ câu truy vấn
                DataTable sachDataTable = TruyXuat.GetTable(query);

                // Kiểm tra xem có dữ liệu không trước khi đặt nguồn dữ liệu cho DataGridView
                if (sachDataTable.Rows.Count > 0)
                {
                    // Đặt nguồn dữ liệu cho DataGridView
                    dataGridView1.DataSource = sachDataTable;
                }
                else
                {
                    MessageBox.Show("Không có sách nào từ nhà xuất bản này.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void XuatDanhSachCuaMotNXB_Load(object sender, EventArgs e)
        {
           
        }
        private void LoadTenNhaXuatBan()
        {
            // Sử dụng câu truy vấn để lấy dữ liệu từ bảng NhaXuatBan
            string query = "SELECT * FROM NhaXuatBan";

            // Lấy DataTable từ câu truy vấn
            DataTable nxbDataTable = TruyXuat.GetTable(query);

            // Gán nguồn dữ liệu cho ComboBox
            cbNXB.DataSource = nxbDataTable;
            cbNXB.DisplayMember = "TenNhaXuatBan"; // Hiển thị tên nhà xuất bản
            cbNXB.ValueMember = "MaNhaXuatBan"; // Giá trị thực tế là mã nhà xuất bản
        }

        private void btXuatDanhSach_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo một đối tượng Excel
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true;

                // Tạo một Workbook mới
                Excel.Workbook workbook = excelApp.Workbooks.Add();

                // Tạo một Worksheet mới
                Excel.Worksheet worksheet = workbook.Worksheets[1];

                // Ghi dữ liệu từ DataGridView vào Worksheet
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        // Kiểm tra giá trị có tồn tại hay không
                        if (dataGridView1[j, i].Value != null)
                        {
                            worksheet.Cells[i + 1, j + 1] = dataGridView1[j, i].Value.ToString();
                        }
                        else
                        {
                            // Nếu giá trị là null, bạn có thể thay thế bằng  //
                            worksheet.Cells[i + 1, j + 1] = "//";
                        }
                    }
                }

                // Lưu Workbook vào đường dẫn cụ thể
                string filePath = "duongdan\tenfile.xlsx"; // Thay đổi đường dẫn và tên file Excel theo yêu cầu
                workbook.SaveAs(filePath);

                // Đóng Workbook và Excel Application
                workbook.Close();
                excelApp.Quit();

                MessageBox.Show("Xuất danh sách thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
