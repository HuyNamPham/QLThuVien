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

namespace QLThuVien
{
    public partial class Login : Form
    {
        QLThuVienDB db = new QLThuVienDB();

        public Login()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTenDN.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống!","Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                var nv = db.NhanViens.FirstOrDefault(s => s.TaiKhoan.Equals(txtTenDN.Text) && s.MatKhau.Equals(txtMatKhau.Text));
                if (nv != null)
                {
                    NguoiDung.NguoiDN = nv;
                    new Main().ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập và mật khẩu không chính xác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
