using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLThuVien.Models;
using QLThuVien.Form_ChucNang;

namespace QLThuVien
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            txtHoTen.Text = NguoiDung.NguoiDN.HoTen;
            txtTenDN.Text = NguoiDung.NguoiDN.TaiKhoan;
            txtQuyen.Text = NguoiDung.NguoiDN.Quyen;
            if(NguoiDung.NguoiDN.Quyen.Trim().Equals("ADMIN"))
            {
                btnQLSach.Enabled = true;
                btnQLTaiKhoan.Enabled = true;
            }
            else
            {
                btnQLSach.Enabled = false;
                btnQLTaiKhoan.Enabled = false;
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            NguoiDung.NguoiDN = null;
            new Login().ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQLSach_Click(object sender, EventArgs e)
        {
            new QLSach().ShowDialog();
        }

        private void btnQLMuonTra_Click(object sender, EventArgs e)
        {
            new QLMuonTra().ShowDialog();
        }

        private void btnQLTaiKhoan_Click(object sender, EventArgs e)
        {
            new QLTaiKhoan().ShowDialog();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            new ThongKeBaoCao().ShowDialog();
        }

        private void btnHoSo_Click(object sender, EventArgs e)
        {
            new HoSo().ShowDialog();
        }
    }
}
