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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void MuonSachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyMuonTra qlsach = new QuanLyMuonTra();
            this.Hide();
            qlsach.ShowDialog();
            this.Show();

        }
             

        private void DashBoard_Load(object sender, EventArgs e)
        {
            /*string sql = "select LoaiNguoiDung from NguoiDung where TenDangNhap =N'" +
                 "' and MatKhau=N'" + "'";
            string LoaiNguoiDung = TruyXuat.LayMotGiaTri(sql);
            
                // Lấy loại người dùng sau khi đăng nhập            
                if (LoaiNguoiDung == "Quản Lý")
                {
                    // Cho phép truy cập DashBoard và các chức năng phân quyền.
                    this.Visible = true;
                }
                else
                {
                    // Ngăn cản truy cập cho các loại người dùng khác.
                    this.Visible = false;
                    MessageBox.Show("Bạn không có quyền truy cập.");
                }*/          
        }

        private void SachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLySach qlsach = new QuanLySach();
          //  this.Hide();
            qlsach.ShowDialog();
            this.Show();
        }

        private void DocGiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyDocGia qldocgia = new QuanLyDocGia();
           // this.Hide();
            qldocgia.ShowDialog();
            this.Show();
        }

        private void TacGiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TacGia tacgia = new TacGia();
           // this.Hide();
            tacgia.ShowDialog();
            this.Show();
        }

        private void NhaXuatBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNhaXuatBan qlnxb = new QuanLyNhaXuatBan();
           // this.Hide();
            qlnxb.ShowDialog();
            this.Show();
        }

        private void PhieuMuonToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ChiTietPhieuMuonToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void NguoiDungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNguoiDung qlnguoidung = new QuanLyNguoiDung();
            //this.Hide();
            qlnguoidung.ShowDialog();
            this.Show();
        }

        private void NhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien qlnv = new QuanLyNhanVien();
          //  this.Hide();
            qlnv.ShowDialog();
            this.Show();
        }

        private void DoiMatKhauToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  DoiMatKhau doimk = new DoiMatKhau();
           // this.Hide();
           // doimk.ShowDialog();
           // this.Show();
        }

        private void DangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PhanQuyenNguoiDungToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ChucNangToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }
    }
}
