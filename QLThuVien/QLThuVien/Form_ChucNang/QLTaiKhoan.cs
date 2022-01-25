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
    public partial class QLTaiKhoan : Form
    {
        QLThuVienDB db = new QLThuVienDB();
        public QLTaiKhoan()
        {
            InitializeComponent();
            initChucVu();
            initNhanVien();
        }
        
        private void initChucVu()
        {
            dgvChucVu.DataSource = (from cv in db.ChucVus
                                    select new {cv.MaChucVu, cv.TenChucVu}).ToList();
        }
        private void initNhanVien()
        {
            cmbChucVu.DataSource = (from cv in db.ChucVus
                                   select cv).ToList();
            cmbChucVu.DisplayMember = "TenChucVu";
            cmbChucVu.ValueMember = "MaChucVu";
            cmbQuen.SelectedIndex = 0;

            dgvNhanVien.DataSource = (from nv in db.NhanViens
                                      join cv in db.ChucVus on nv.MaChucVu equals cv.MaChucVu
                                      select new
                                      {
                                          nv.MaNhanVien,
                                          nv.HoTen,
                                          cv.TenChucVu,
                                          nv.TaiKhoan,
                                          nv.MatKhau,
                                          nv.Quyen
                                      }).ToList();
        }
        private void dgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvChucVu.CurrentRow;
            if (row != null)
            {
                txtMaCV.Text = row.Cells[0].Value.ToString();
                txtTenCV.Text = row.Cells[1].Value.ToString();
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvNhanVien.CurrentRow;
            if (row != null)
            {
                txtMaNV.Text = row.Cells[0].Value.ToString();
                txtHoTen.Text = row.Cells[1].Value.ToString();
                cmbChucVu.Text = row.Cells[2].Value.ToString();
                txtTaiKhoan.Text = row.Cells[3].Value.ToString();
                txtMatKhau.Text = row.Cells[4].Value.ToString();
                cmbQuen.Text = row.Cells[5].Value.ToString();
            }
        }

        private void btnThemCV_Click(object sender, EventArgs e)
        {
            if (txtMaCV.Text == "" || txtTenCV.Text == "")
            {
                MessageBox.Show("Thông tin không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var cv = db.ChucVus.FirstOrDefault(c => c.MaChucVu.Equals(txtMaCV.Text));
                if (cv == null)
                {
                    ChucVu c = new ChucVu()
                    {
                        MaChucVu = txtMaCV.Text,
                        TenChucVu = txtTenCV.Text
                    };
                    db.ChucVus.Add(c);
                    db.SaveChanges();
                    initChucVu();
                }
                else
                {
                    MessageBox.Show("Mã chức vụ đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSuaCV_Click(object sender, EventArgs e)
        {
            if (txtMaCV.Text == "" || txtTenCV.Text == "")
            {
                MessageBox.Show("Thông tin không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var cv = db.ChucVus.FirstOrDefault(c => c.MaChucVu.Equals(txtMaCV.Text));
                if (cv != null)
                {
                    DialogResult dlr = MessageBox.Show("Bạn có chắc muốn Sửa không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        cv.TenChucVu = txtTenCV.Text;
                        db.SaveChanges();
                        initChucVu();
                    }
                }
                else
                {
                    MessageBox.Show("Mã chức vụ không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXoaCV_Click(object sender, EventArgs e)
        {
            if (txtMaCV.Text == "")
            {
                MessageBox.Show("Mã chức vụ không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var cv = db.ChucVus.FirstOrDefault(c => c.MaChucVu.Equals(txtMaCV.Text));
                if (cv != null)
                {
                    DialogResult dlr = MessageBox.Show("Bạn có chắc muốn Sửa không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        db.ChucVus.Remove(cv);
                        db.SaveChanges();
                        initChucVu();
                    }
                }
                else
                {
                    MessageBox.Show("Mã chức vụ không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXoaTrangCV_Click(object sender, EventArgs e)
        {
            txtMaCV.Text = "";
            txtTenCV.Text = "";
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show("tên nhân viên tìm kiếm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var kq = (from nv in db.NhanViens
                          join cv in db.ChucVus on nv.MaChucVu equals cv.MaChucVu
                          where nv.HoTen.Contains(txtTimKiem.Text)
                          select new
                          {
                              nv.MaNhanVien,
                              nv.HoTen,
                              cv.TenChucVu,
                              nv.TaiKhoan,
                              nv.MatKhau,
                              nv.Quyen
                          }).ToList();
                if (kq.Count > 0)
                {
                    dgvNhanVien.DataSource = kq;
                }
                else
                {
                    MessageBox.Show("không tìm thấy nhân viên có tên gần giống vậy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXemLai_Click(object sender, EventArgs e)
        {
            initNhanVien();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "" || txtHoTen.Text == ""||txtTaiKhoan.Text==""||txtMatKhau.Text=="")
            {
                MessageBox.Show("Thông tin không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var nv = db.NhanViens.FirstOrDefault(n=>n.MaNhanVien.Equals(txtMaNV.Text));
                if (nv == null)
                {
                    var tk = db.NhanViens.FirstOrDefault(t => t.TaiKhoan.Equals(txtTaiKhoan.Text));
                    if (tk != null)
                    {
                        MessageBox.Show("Tên tài khoản đã tồn tai! \n vui lòng nhập tên tài khoản khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    NhanVien n = new NhanVien()
                    {
                        MaNhanVien = txtMaNV.Text,
                        HoTen = txtHoTen.Text,
                        MaChucVu = cmbChucVu.SelectedValue.ToString(),
                        TaiKhoan = txtTaiKhoan.Text.Trim(),
                        MatKhau = txtMatKhau.Text.Trim(),
                        Quyen = cmbQuen.Text
                    };
                    db.NhanViens.Add(n);
                    db.SaveChanges();
                    initNhanVien();
                }
                else
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "" || txtHoTen.Text == "" || txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Thông tin không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var nv = db.NhanViens.FirstOrDefault(n => n.MaNhanVien.Equals(txtMaNV.Text));
                if (nv != null)
                {
                    var tk = db.NhanViens.FirstOrDefault(t => t.TaiKhoan.Equals(txtTaiKhoan.Text));
                    if (tk != null && tk.TaiKhoan != nv.TaiKhoan)
                    {
                        MessageBox.Show("Tên tài khoản đã tồn tai! \n vui lòng nhập tên tài khoản khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    DialogResult dlr = MessageBox.Show("Bạn có chắc muốn Sửa không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        nv.HoTen = txtHoTen.Text;
                        nv.MaChucVu = cmbChucVu.SelectedValue.ToString();
                        nv.TaiKhoan = txtTaiKhoan.Text.Trim();
                        nv.MatKhau = txtMatKhau.Text.Trim();
                        nv.Quyen = cmbQuen.Text;
                        db.SaveChanges();
                        initNhanVien();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã nhân viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "" )
            {
                MessageBox.Show("Mã nhân viên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var nv = db.NhanViens.FirstOrDefault(n => n.MaNhanVien.Equals(txtMaNV.Text));
                if (nv != null)
                {
                    DialogResult dlr = MessageBox.Show("Bạn có chắc muốn Xóa không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        db.NhanViens.Remove(nv);
                        db.SaveChanges();
                        initNhanVien();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXoaTrangNV_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            cmbChucVu.SelectedIndex = 0;
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            cmbChucVu.SelectedIndex = 0;
        }
    }
}
