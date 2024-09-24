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
        public partial class QuanLyMuonTra : Form
        {
            public QuanLyMuonTra()
            {
                InitializeComponent();
                LoadDataIntoComboBoxes();
            }

            private void btMuonSach_Click(object sender, EventArgs e)
            {

            }

            private void cbDanhSach_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            private void tabPagePhieuMuon_Click(object sender, EventArgs e)
            {

            }

            private void gvChiTietPhieuMuon_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

            private void LoadDataIntoComboBoxes()
            {
                // Load dữ liệu vào ComboBox MaSach từ bảng Sach
                string sqlMaSach = "SELECT MaSach FROM Sach";
                DataTable dtMaSach = TruyXuat.GetTable(sqlMaSach);
                cbMaSach.DataSource = dtMaSach;
                cbMaSach.DisplayMember = "MaSach";
                cbMaSach.ValueMember = "MaSach";

                // Load dữ liệu vào ComboBox MaDocGia từ bảng DocGia
                string sqlMaDocGia = "SELECT MaDocGia FROM DocGia";
                DataTable dtMaDocGia = TruyXuat.GetTable(sqlMaDocGia);
                cbMaDocGia.DataSource = dtMaDocGia;
                cbMaDocGia.DisplayMember = "MaDocGia";
                cbMaDocGia.ValueMember = "MaDocGia";
        }
        private void QuanLyMuonTra_Load(object sender, EventArgs e)

        {

            txtmadocgia.Enabled = false;
            txttendocgia.Enabled = false;
            txtTenSach.Enabled = false;
            txtSoLuongSach.Enabled = false;
            txtMaPhieuMuon.Enabled = false;
            cbMaDocGia.Enabled = false;
            cbMaSach.Enabled = false;
            txtSoLuongMuon.Enabled = false;
            dateTimePickerNgayLap.Enabled = false;
            txtMaNV.Enabled = false;

            gvphieumuon.DataSource = TruyXuat.GetTable("select * from PhieuMuon");
            gvphieumuon.Columns[0].HeaderText = "Mã Phiếu Mượn";
            gvphieumuon.Columns[1].HeaderText = "Mã Nhân Viên Lập Phiếu";
            gvphieumuon.Columns[2].HeaderText = "Ngày Lập Phiếu";
            gvphieumuon.Columns[3].HeaderText = "Mã Độc Giả";
            gvphieumuon.Columns[4].HeaderText = "Mã Sách";
            gvphieumuon.Columns[5].HeaderText = "Số Lượng Mượn";
            gvphieumuon.Columns[0].AutoSizeMode =
               DataGridViewAutoSizeColumnMode.AllCells;
            gvphieumuon.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            gvphieumuon.Columns[2].AutoSizeMode =
              DataGridViewAutoSizeColumnMode.AllCells;
            gvphieumuon.Columns[3].AutoSizeMode =
              DataGridViewAutoSizeColumnMode.AllCells;
            gvphieumuon.Columns[4].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            gvphieumuon.Columns[5].AutoSizeMode =
               DataGridViewAutoSizeColumnMode.Fill;




            txtMaPhieu.Enabled = false;
            ngaytra.Enabled = false;
            txtMaSachh.Enabled = false;
            txtTienPhat.Enabled = false;
            txtMaNV.Enabled = false;           
            gvChiTietPhieuMuon.DataSource = TruyXuat.GetTable("select * from ChiTietPhieuMuon");
            gvChiTietPhieuMuon.Columns[0].HeaderText = "Mã Phiếu Mượn";
            gvChiTietPhieuMuon.Columns[1].HeaderText = "Mã Sách";
            gvChiTietPhieuMuon.Columns[2].HeaderText = "Tình Trạng";
            gvChiTietPhieuMuon.Columns[3].HeaderText = "Ngày Trả Sách";
            gvChiTietPhieuMuon.Columns[4].HeaderText = "Tiền Phạt";
            gvChiTietPhieuMuon.Columns[5].HeaderText = "Mã Nhân Viên Nhận Trả Sách";
            gvChiTietPhieuMuon.Columns[0].AutoSizeMode =
               DataGridViewAutoSizeColumnMode.AllCells;
            gvChiTietPhieuMuon.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            gvChiTietPhieuMuon.Columns[2].AutoSizeMode =
              DataGridViewAutoSizeColumnMode.AllCells;
            gvChiTietPhieuMuon.Columns[3].AutoSizeMode =
              DataGridViewAutoSizeColumnMode.AllCells;
            gvChiTietPhieuMuon.Columns[4].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            gvChiTietPhieuMuon.Columns[5].AutoSizeMode =
               DataGridViewAutoSizeColumnMode.Fill;
        }

        private void cbMaSach_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cbMaSach.SelectedValue != null && cbMaSach.SelectedValue != DBNull.Value)
                {
                    string maSach = cbMaSach.SelectedValue.ToString();

                    // Thực hiện truy vấn thông tin từ bảng Sach
                   string sqlSach = $"SELECT TenSach, SoLuong FROM Sach WHERE MaSach = {maSach}";
                   DataTable dtSach = TruyXuat.GetTable(sqlSach);

                    // Hiển thị thông tin trên giao diện
                   if (dtSach.Rows.Count > 0)
                    {
                       txtTenSach.Text = dtSach.Rows[0]["TenSach"].ToString();
                        txtSoLuongSach.Text = dtSach.Rows[0]["SoLuong"].ToString();
                    }
               }
            }

            private void cbMaDocGia_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cbMaDocGia.SelectedValue != null && cbMaDocGia.SelectedValue != DBNull.Value)
                {
                    string maDocGia = cbMaDocGia.SelectedValue.ToString();

                    // Thực hiện truy vấn thông tin từ bảng DocGia
                    string sqlDocGia = $"SELECT TenDocGia FROM DocGia WHERE MaDocGia = {maDocGia}";
                    DataTable dtDocGia = TruyXuat.GetTable(sqlDocGia);

                    // Hiển thị thông tin trên giao diện
                    if (dtDocGia.Rows.Count > 0)
                    {
                        txtmadocgia.Text = maDocGia; // Hiển thị MaDocGia
                        txttendocgia.Text = dtDocGia.Rows[0]["TenDocGia"].ToString();
                    }
                }
            }

            private void btPhieuMuon_Click(object sender, EventArgs e)
            {
                txtmadocgia.Enabled = false;
                txttendocgia.Enabled = false;
                txtTenSach.Enabled = false;
                txtSoLuongSach.Enabled = false;
                txtMaPhieuMuon.Enabled = true;
                cbMaDocGia.Enabled = true;
                cbMaSach.Enabled = true;
                txtSoLuongMuon.Enabled = true;
                dateTimePickerNgayLap.Enabled = true;
            txtMaNV.Enabled = true;

        }

        private void txtSoLuongMuon_TextChanged(object sender, EventArgs e)
            {
                // Kiểm tra xem giá trị nhập vào có phải là số không
                if (int.TryParse(txtSoLuongMuon.Text, out int soLuongMuon))
                {
                    // Kiểm tra xem đã chọn một sách từ ComboBox chưa
                    if (cbMaSach.SelectedValue != null && cbMaSach.SelectedValue != DBNull.Value)
                    {
                        string maSach = cbMaSach.SelectedValue.ToString();

                        // Truy vấn số lượng hiện tại của sách từ bảng Sach
                        string sqlSach = $"SELECT SoLuong FROM Sach WHERE MaSach = {maSach}";
                        DataTable dtSach = TruyXuat.GetTable(sqlSach);

                        // Kiểm tra xem có dữ liệu trả về không
                        if (dtSach.Rows.Count > 0)
                        {
                            int soLuongHienTai = Convert.ToInt32(dtSach.Rows[0]["SoLuong"]);

                            // Kiểm tra xem có đủ sách để mượn không
                            if (soLuongMuon <= soLuongHienTai)
                            {
                                // Hiển thị số lượng sách còn lại sau khi mượn
                                int soLuongConLai = soLuongHienTai - soLuongMuon;

                                // Kiểm tra xem số lượng còn lại có là 0 không
                                if (soLuongConLai == 0)
                                {
                                    MessageBox.Show("Không còn đủ sách để mượn.");
                                    txtSoLuongMuon.Text = string.Empty;
                                    txtSoLuongSach.Text = string.Empty;
                                }
                                else
                                {
                                    txtSoLuongSach.Text = soLuongConLai.ToString();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Số lượng mượn vượt quá số lượng hiện có.");
                                txtSoLuongMuon.Text = string.Empty;
                            }
                        }
                    }
                }
                else
                {
                    // Nếu người dùng nhập không phải là số, có thể hiển thị thông báo hoặc xử lý theo yêu cầu của bạn
                    MessageBox.Show("Vui lòng nhập một số nguyên.");
                    txtSoLuongMuon.Text = string.Empty;
            }
        }

        private void btLapPHieuMuon_Click(object sender, EventArgs e)
        {  // Kiểm tra xem đã nhập đầy đủ thông tin hay chưa
            if (IsValidInput())
            {
                // Lấy giá trị từ các controls trên form
                string maPhieuMuon = txtMaPhieuMuon.Text;
                string maNhanVien = txtMaNV.Text;
                DateTime ngayLapPhieu = dateTimePickerNgayLap.Value;
                string maDocGia = cbMaDocGia.SelectedValue.ToString();
                string maSach = cbMaSach.SelectedValue.ToString();
                int soLuongMuon = int.Parse(txtSoLuongMuon.Text);

                // Kiểm tra số lượng mượn của MaDocGia có vượt quá 5 quyển sách không
                if (CheckMaxBookLimit(maDocGia))
                {
                    MessageBox.Show("Chỉ được mượn tối đa 5 quyển sách.");
                    return;
                }

                // Thực hiện thêm dữ liệu vào bảng PhieuMuon
                string insertPhieuMuon = $"INSERT INTO PhieuMuon (MaPhieuMuon, MaNhanVienLapPhieu, NgayLapPhieu, MaDocGia, MaSach, SoLuongMuon) VALUES ('{maPhieuMuon}', '{maNhanVien}', '{ngayLapPhieu.ToString("yyyy-MM-dd")}', '{maDocGia}', '{maSach}', {soLuongMuon})";
                TruyXuat.ThemSuaXoa(insertPhieuMuon);

                // Cập nhật số lượng sách trong bảng Sach
                UpdateSoLuongSach(maSach, soLuongMuon);

                // Hiển thị dữ liệu mới trên DataGridView gvphieumuon
                RefreshDataGridView("SELECT * FROM PhieuMuon", gvphieumuon);

                // Hiển thị dữ liệu mới trên DataGridView gvPhieuMuonChiTiet
                // Lấy thời gian 1 tháng kể từ NgayLapPhieu
                DateTime ngayTraSach = ngayLapPhieu.AddMonths(1);

                // Thêm dữ liệu vào bảng ChiTietPhieuMuon
                string insertChiTietPhieuMuon = $"INSERT INTO ChiTietPhieuMuon (MaPhieuMuon, MaSach, MaNhanVienNhanSachTra, TinhTrang, NgayTraSach, TienPhat) VALUES ('{maPhieuMuon}', '{maSach}',Null, '1', '{ngayTraSach.ToString("yyyy-MM-dd")}', 0)";
                TruyXuat.ThemSuaXoa(insertChiTietPhieuMuon);

                // Hiển thị dữ liệu mới trên DataGridView gvPhieuMuonChiTiet
                RefreshDataGridView($"SELECT * FROM ChiTietPhieuMuon WHERE MaPhieuMuon = '{maPhieuMuon}'", gvChiTietPhieuMuon);
            }
        }
        private bool CheckMaxBookLimit(string maDocGia)
        {
            // Kiểm tra số lượng sách đã mượn của MaDocGia
            string sqlCountBooks = $"SELECT COUNT(*) FROM PhieuMuon WHERE MaDocGia = '{maDocGia}'";
            int soLuongMuon = int.Parse(TruyXuat.LayMotGiaTri(sqlCountBooks));

            return soLuongMuon >= 5;
        }
        private void UpdateSoLuongSach(string maSach, int soLuongMuon)
        {
            // Lấy số lượng hiện tại của sách từ bảng Sach
            string sqlSach = $"SELECT SoLuong FROM Sach WHERE MaSach = '{maSach}'";
            int soLuongHienTai = int.Parse(TruyXuat.LayMotGiaTri(sqlSach));

            // Kiểm tra xem có đủ sách để mượn không
            if (soLuongMuon <= soLuongHienTai)
            {
                // Tính toán số lượng còn lại sau khi mượn
                int soLuongConLai = soLuongHienTai - soLuongMuon;

                // Update số lượng sách trong bảng Sach
                string updateSach = $"UPDATE Sach SET SoLuong = {soLuongConLai} WHERE MaSach = '{maSach}'";
                TruyXuat.ThemSuaXoa(updateSach);

                MessageBox.Show("Lập phiếu mượn thành công.");
            }
            else
            {
                MessageBox.Show("Số lượng mượn vượt quá số lượng hiện có.");
            }
        }
        private void RefreshDataGridView(string sql, DataGridView dataGridView)
        {
            // Lấy dữ liệu từ bảng PhieuMuon hoặc ChiTietPhieuMuon
            DataTable dt = TruyXuat.GetTable(sql);

            // Hiển thị dữ liệu trên DataGridView
            dataGridView.DataSource = dt;
        }

        private bool IsValidInput()
        {
            // Thực hiện kiểm tra các điều kiện hợp lệ trước khi thêm dữ liệu mới
            // Bạn có thể thêm các kiểm tra khác tùy vào yêu cầu của ứng dụng
            if (string.IsNullOrEmpty(txtMaPhieuMuon.Text) || string.IsNullOrEmpty(txtMaNV.Text) || string.IsNullOrEmpty(txtSoLuongMuon.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return false;
            }

            return true;
        }


        private void btSua_Click(object sender, EventArgs e)
        {
            txtmadocgia.Enabled = false;
            txttendocgia.Enabled = false;
            txtTenSach.Enabled = false;
            txtSoLuongSach.Enabled = false;
            txtMaPhieuMuon.Enabled = false;
            cbMaDocGia.Enabled = true;
            cbMaSach.Enabled = true;
            txtSoLuongMuon.Enabled = true;
            dateTimePickerNgayLap.Enabled = true;
            txtMaNV.Enabled = true;
            // Kiểm tra xem đã chọn dòng nào trên DataGridView chưa
           
            if (gvphieumuon.SelectedRows.Count > 0)
            {
                // Lấy giá trị từ dòng được chọn
                DataGridViewRow selectedRow = gvphieumuon.SelectedRows[0];

                // Lấy các giá trị cần thiết
                string maPhieuMuon = selectedRow.Cells["MaPhieuMuon"].Value.ToString();
                string maNhanVien = selectedRow.Cells["MaNhanVienLapPhieu"].Value.ToString();
                DateTime ngayLapPhieu = Convert.ToDateTime(selectedRow.Cells["NgayLapPhieu"].Value);
                string maDocGia = selectedRow.Cells["MaDocGia"].Value.ToString();
                string maSach = selectedRow.Cells["MaSach"].Value.ToString();
                int soLuongMuon = Convert.ToInt32(selectedRow.Cells["SoLuongMuon"].Value);

                // Hiển thị thông tin cần sửa lên các controls
                txtMaPhieuMuon.Text = maPhieuMuon;
                txtMaNV.Text = maNhanVien;
                dateTimePickerNgayLap.Value = ngayLapPhieu;
                cbMaDocGia.SelectedValue = maDocGia;
                cbMaSach.SelectedValue = maSach;
                txtSoLuongMuon.Text = soLuongMuon.ToString();

                // Hiển thị thông báo hướng dẫn
                MessageBox.Show("Bạn đang ở chế độ sửa. Hãy chỉnh sửa thông tin cần thiết và nhấn Lưu để hoàn tất.", "Hướng dẫn sửa thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu mượn cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
      

        private void gvphieumuon_SelectionChanged(object sender, EventArgs e)
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (gvphieumuon.SelectedRows.Count > 0)
                {
                    // Lấy dòng được chọn
                    DataGridViewRow selectedRow = gvphieumuon.SelectedRows[0];

                    // Lấy giá trị từ các ô trong dòng
                    string maPhieuMuon = selectedRow.Cells["MaPhieuMuon"].Value.ToString();
                    string maNV = selectedRow.Cells["MaNhanVienLapPhieu"].Value.ToString();
                    DateTime ngayLap = Convert.ToDateTime(selectedRow.Cells["NgayLapPhieu"].Value);
                    string maDocGia = selectedRow.Cells["MaDocGia"].Value.ToString();
                    string maSach = selectedRow.Cells["MaSach"].Value.ToString();
                    int soLuongMuon = Convert.ToInt32(selectedRow.Cells["SoLuongMuon"].Value);

                    // Hiển thị giá trị lên các controls tương ứng
                    txtMaPhieuMuon.Text = maPhieuMuon;
                    txtMaNV.Text = maNV;
                    dateTimePickerNgayLap.Value = ngayLap;
                    cbMaDocGia.SelectedValue = maDocGia;
                    cbMaSach.SelectedValue = maSach;
                    txtSoLuongMuon.Text = soLuongMuon.ToString();
                
                
                }
            }

        private void btLuu_Click_1(object sender, EventArgs e)
        {
            // Thực hiện lưu thông tin đã sửa
            if (IsValidInput())
            {
                // Lấy giá trị từ các controls trên form
                string maPhieuMuon = txtMaPhieuMuon.Text;
                DateTime ngayLapPhieu = dateTimePickerNgayLap.Value;
                string maDocGia = cbMaDocGia.SelectedValue.ToString();
                string maSach = cbMaSach.SelectedValue.ToString();
                int soLuongMuon = int.Parse(txtSoLuongMuon.Text);

                // Thực hiện cập nhật thông tin vào bảng PhieuMuon
                string updatePhieuMuon = $"UPDATE PhieuMuon SET NgayLapPhieu = '{ngayLapPhieu.ToString("yyyy-MM-dd")}', MaDocGia = '{maDocGia}', MaSach = '{maSach}', SoLuongMuon = {soLuongMuon} WHERE MaPhieuMuon = '{maPhieuMuon}'";
                TruyXuat.ThemSuaXoa(updatePhieuMuon);

                // Cập nhật số lượng sách trong bảng Sach
                UpdateSoLuongSach(maSach, soLuongMuon);

                // Hiển thị dữ liệu mới trên DataGridView gvphieumuon
                RefreshDataGridView("SELECT * FROM PhieuMuon", gvphieumuon);

                // Enable lại các controls sau khi đã lưu
                txtmadocgia.Enabled = true;
                txttendocgia.Enabled = true;
                txtTenSach.Enabled = true;
                txtSoLuongSach.Enabled = true;
                txtMaPhieuMuon.Enabled = true;
                cbMaDocGia.Enabled = false;
                cbMaSach.Enabled = false;
                txtSoLuongMuon.Enabled = false;
                dateTimePickerNgayLap.Enabled = false;
                txtMaNV.Enabled = false;

                // Xóa nội dung trên các controls
                txtMaPhieuMuon.Text = string.Empty;
                txtMaNV.Text = string.Empty;
                dateTimePickerNgayLap.Value = DateTime.Now;
                cbMaDocGia.SelectedIndex = -1;
                cbMaSach.SelectedIndex = -1;
                txtSoLuongMuon.Text = string.Empty;

                // Hiển thị thông báo thành công
                MessageBox.Show("Đã lưu thông tin phiếu mượn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn dòng nào trên DataGridView chưa
            if (gvphieumuon.SelectedRows.Count > 0)
            {
                // Lấy giá trị từ dòng được chọn
                DataGridViewRow selectedRow = gvphieumuon.SelectedRows[0];

                // Lấy các giá trị cần thiết
                string maPhieuMuon = selectedRow.Cells["MaPhieuMuon"].Value.ToString();
                string maSach = selectedRow.Cells["MaSach"].Value.ToString();
                int soLuongMuon = Convert.ToInt32(selectedRow.Cells["SoLuongMuon"].Value);

                // Hiển thị hộp thoại xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu mượn này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Thực hiện xóa dữ liệu từ bảng PhieuMuon
                    string deletePhieuMuon = $"DELETE FROM PhieuMuon WHERE MaPhieuMuon = '{maPhieuMuon}'";
                    TruyXuat.ThemSuaXoa(deletePhieuMuon);

                    // Cộng dồn số lượng vào bảng Sach
                    UpdateSoLuongSach(maSach, soLuongMuon, true);

                    // Hiển thị dữ liệu mới trên DataGridView gvphieumuon
                    RefreshDataGridView("SELECT * FROM PhieuMuon", gvphieumuon);

                    // Hiển thị thông báo xóa thành công
                    MessageBox.Show("Đã xóa phiếu mượn và cập nhật số lượng sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu mượn cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void UpdateSoLuongSach(string maSach, int soLuong, bool increase)
        {
            // Lấy số lượng hiện tại của sách từ bảng Sach
            string sqlSach = $"SELECT SoLuong FROM Sach WHERE MaSach = '{maSach}'";
            int soLuongHienTai = int.Parse(TruyXuat.LayMotGiaTri(sqlSach));

            // Cộng dồn hoặc giảm số lượng sách tùy thuộc vào biến increase
            int soLuongMoi = increase ? soLuongHienTai + soLuong : soLuongHienTai - soLuong;

            // Update số lượng sách trong bảng Sach
            string updateSach = $"UPDATE Sach SET SoLuong = {soLuongMoi} WHERE MaSach = '{maSach}'";
            TruyXuat.ThemSuaXoa(updateSach);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbNgayTra_Click(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            // Lấy giá trị từ TextBox txtTimKiem
            string tuKhoa = txtTimKiem.Text.Trim();

            // Kiểm tra xem người dùng đã nhập từ khóa tìm kiếm hay chưa
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                // Tạo câu truy vấn SQL với điều kiện LIKE cho MaPhieuMuon hoặc MaSach
                string sqlQuery = $"SELECT * FROM ChiTietPhieuMuon WHERE MaPhieuMuon LIKE '%{tuKhoa}%' OR MaSach LIKE '%{tuKhoa}%'";

                // Hiển thị kết quả trên DataGridView
                RefreshDataGridView(sqlQuery, gvChiTietPhieuMuon);
            }
            else
            {
                // Nếu từ khóa tìm kiếm trống, hiển thị toàn bộ dữ liệu
                RefreshDataGridView("SELECT * FROM ChiTietPhieuMuon", gvChiTietPhieuMuon);
            }
        }

        private void gvphieumuon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gvChiTietPhieuMuon_SelectionChanged(object sender, EventArgs e)
        {

            if (gvChiTietPhieuMuon.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = gvChiTietPhieuMuon.SelectedRows[0];

                // Lấy giá trị từ các ô trong dòng
                txtMaPhieuMuon.Text = selectedRow.Cells["MaPhieuMuon"].Value.ToString();
                txtMaNV.Text = selectedRow.Cells["MaNhanVienNhanSachTra"].Value.ToString();
                ngaytra.Value = Convert.ToDateTime(selectedRow.Cells["NgayTraSach"].Value);
                txtTienPhat.Text = selectedRow.Cells["TienPhat"].Value.ToString();
                txtMaSachh.Text = selectedRow.Cells["MaSach"].Value.ToString();
                rdChuaTra.Checked = Convert.ToBoolean(selectedRow.Cells["TinhTrang"].Value);
                rdDaTra.Checked = Convert.ToBoolean(selectedRow.Cells["TinhTrang"].Value);
            }

        }

        private void btTraSach_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng được chọn không
            if (gvChiTietPhieuMuon.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = gvChiTietPhieuMuon.SelectedRows[0];

                // Lấy giá trị từ các ô trong dòng
                string maPhieuMuon = selectedRow.Cells["MaPhieuMuon"].Value.ToString();
                string maSach = selectedRow.Cells["MaSach"].Value.ToString();
                DateTime ngayTraSach = Convert.ToDateTime(selectedRow.Cells["NgayTraSach"].Value);
                bool tinhTrang = Convert.ToBoolean(selectedRow.Cells["TinhTrang"].Value);

                // Kiểm tra tình trạng của sách
                if (tinhTrang)
                {
                    MessageBox.Show("Sách đã được trả trước đó.");
                    return;
                }

                // Kiểm tra ngày trả so với ngày mượn
                DateTime ngayMuon = ngayTraSach.AddMonths(-1); // Ngày mượn là ngày trả trước 1 tháng
                if (DateTime.Now > ngayMuon)
                {
                    // Số ngày quá hạn
                    int soNgayQuaHan = (int)(DateTime.Now - ngayMuon).TotalDays;

                    // Tính phạt
                    int tienPhat = soNgayQuaHan * 2000;

                    // Hiển thị thông báo phạt
                    MessageBox.Show($"Quá hạn {soNgayQuaHan} ngày");
                    txtTienPhat.Text = tienPhat.ToString();

                    // Cập nhật thông tin sách đã trả vào bảng ChiTietPhieuMuon
                    string updateChiTietPhieuMuon = $"UPDATE ChiTietPhieuMuon SET TinhTrang = 0, NgayTraSach = '{DateTime.Now.ToString("yyyy-MM-dd")}', TienPhat = {tienPhat} WHERE MaPhieuMuon = '{maPhieuMuon}' AND MaSach = '{maSach}'";
                    TruyXuat.ThemSuaXoa(updateChiTietPhieuMuon);

                    // Tăng số lượng sách trong bảng Sach
                    string updateSoLuongSach = $"UPDATE Sach SET SoLuong = SoLuong + 1 WHERE MaSach = '{maSach}'";
                    TruyXuat.ThemSuaXoa(updateSoLuongSach);

                    // Hiển thị dữ liệu mới trên DataGridView gvChiTietPhieuMuon
                    RefreshDataGridView($"SELECT * FROM ChiTietPhieuMuon WHERE MaPhieuMuon = '{maPhieuMuon}'", gvChiTietPhieuMuon);
                }
                else
                {
                    // Nếu không quá hạn, thông báo trả sách thành công
                    MessageBox.Show("Trả sách thành công.");
                }
            }
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            gvChiTietPhieuMuon.DataSource = TruyXuat.GetTable("select * from ChiTietPhieuMuon");
            gvChiTietPhieuMuon.Columns[0].HeaderText = "Mã Phiếu Mượn";
            gvChiTietPhieuMuon.Columns[1].HeaderText = "Mã Sách";
            gvChiTietPhieuMuon.Columns[2].HeaderText = "Tình Trạng";
            gvChiTietPhieuMuon.Columns[3].HeaderText = "Ngày Trả Sách";
            gvChiTietPhieuMuon.Columns[4].HeaderText = "Tiền Phạt";
            gvChiTietPhieuMuon.Columns[5].HeaderText = "Mã Nhân Viên Nhận Trả Sách";
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
