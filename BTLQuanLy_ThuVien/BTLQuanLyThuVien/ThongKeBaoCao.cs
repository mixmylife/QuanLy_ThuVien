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
    public partial class ThongKeBaoCao : Form
    {
        public ThongKeBaoCao()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
           
                this.Hide();
            XuatDanhSachCuaMotDocGiaQuaHan a = new XuatDanhSachCuaMotDocGiaQuaHan();
            a.ShowDialog();
            this.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Hide();
            XuatDanhSachMotNgayCuaNhanVien a = new XuatDanhSachMotNgayCuaNhanVien();
            a.ShowDialog();
            this.Show();
        }

        private void xuấtDanhSáchCủa1NXBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            XuatDanhSachCuaMotNXB a = new XuatDanhSachCuaMotNXB();
            a.ShowDialog();
            this.Show();
        }

        private void xuấtDanhSáchNhữngSáchCủa1ĐộcGiảĐangMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                this.Hide();
            XuatDanhSachNhungDocGiaMuon a = new XuatDanhSachNhungDocGiaMuon();
            a.ShowDialog();
            this.Show();
        }
    }
}
