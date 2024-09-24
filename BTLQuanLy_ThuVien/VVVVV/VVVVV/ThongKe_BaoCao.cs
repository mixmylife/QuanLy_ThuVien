using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VVVVV
{
    public partial class ThongKe_BaoCao : Form
    {
        public ThongKe_BaoCao()
        {
            InitializeComponent();
        }

        private void xuấtDanhSáchCủa1NXBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            XuatDanhSachCua1NXB a = new XuatDanhSachCua1NXB();
            a.ShowDialog();
            this.Show();
        }

        private void ThongKe_BaoCao_Load(object sender, EventArgs e)
        {
            
        }

        private void xuấtDanhSáchNhữngSáchCủa1ĐộcGiảĐangMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            XuatDanhSachNhungSachDocGiaMuon a = new XuatDanhSachNhungSachDocGiaMuon();
            a.ShowDialog();
            this.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Hide();
            XuatDanhSachDocGiaQuaHan a = new XuatDanhSachDocGiaQuaHan();
            a.ShowDialog();
            this.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Hide();
            XuatDanhSach1NgayCuaNhanVien a = new XuatDanhSach1NgayCuaNhanVien();
            a.ShowDialog();
            this.Show();
        }
    }
}
