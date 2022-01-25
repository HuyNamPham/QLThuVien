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

namespace QLThuVien.Form_ChucNang
{
    
    public partial class HoSo : Form
    {
        public HoSo()
        {
            InitializeComponent();
        }
        QLThuVienDB db = new QLThuVienDB();
        private void HoSo_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = NguoiDung.NguoiDN.MaNhanVien;
            txtHoTen.Text= NguoiDung.NguoiDN.HoTen;
            txtChucVu.Text = db.ChucVus.SingleOrDefault(c=>c.MaChucVu.Equals(NguoiDung.NguoiDN.MaChucVu)).TenChucVu;
            txtQuyen.Text = NguoiDung.NguoiDN.Quyen;
            txtTaiKhoan.Text = NguoiDung.NguoiDN.TaiKhoan;
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            if (NguoiDung.NguoiDN.MatKhau.Equals(txtMatKhauCu.Text))
            {
                if(txtMatKhauMoi.Text == "" || txtNhapLaiMK.Text == "" || txtMatKhauMoi.Text != txtNhapLaiMK.Text)
                {
                    MessageBox.Show("Mật khẩu phải mới phải giống nhau và không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    NhanVien nv = db.NhanViens.SingleOrDefault(n => n.MaNhanVien.Equals(txtMaNV.Text));
                    nv.MatKhau = txtMatKhauMoi.Text;
                    db.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
