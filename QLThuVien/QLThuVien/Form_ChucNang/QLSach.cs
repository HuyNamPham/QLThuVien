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
    public partial class QLSach : Form
    {
        QLThuVienDB db = new QLThuVienDB();
        public QLSach()
        {
            InitializeComponent();
            initDgvTaiLieu();
            initDgvTheLoai();
        }
        private void initDgvTaiLieu()
        {
            cmbTheLoai.DataSource = db.TheLoais.ToList();
            cmbTheLoai.DisplayMember = "TenTheLoai";
            cmbTheLoai.ValueMember = "MaTheLoai";
            dgvTaiLieu.DataSource = (from t in db.TaiLieux
                                     join tl in db.TheLoais on t.MaTheLoai equals tl.MaTheLoai
                                     select new
                                     {
                                         t.MaTaiLieu,
                                         t.TenTaiLieu,
                                         tl.TenTheLoai,
                                         t.SoLuong,
                                         t.NhaXuatBan,
                                         t.NamXuatBan,
                                         t.TacGia
                                     }).ToList();

            cmbLocTL.DataSource = db.TheLoais.ToList();
            cmbLocTL.DisplayMember = "TenTheLoai";
            cmbLocTL.ValueMember = "MaTheLoai";
        }
        private void initDgvTheLoai()
        {
            dgvTheLoai.DataSource = (from tl in db.TheLoais 
                                    select new {tl.MaTheLoai,tl.TenTheLoai,tl.GhiChu}).ToList();
        }

        private void dgvTaiLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = dgvTaiLieu.CurrentRow;
                txtMaTaiLieu.Text = row.Cells[0].Value.ToString();
                txtTenTaiLieu.Text = row.Cells[1].Value.ToString();
                cmbTheLoai.Text = row.Cells[2].Value.ToString();
                numSoLuong.Value = int.Parse(row.Cells[3].Value.ToString());
                txtNhaXuatBan.Text = row.Cells[4].Value.ToString();
                numNamXuatBan.Value = int.Parse(row.Cells[5].Value.ToString());
                txtTacGia.Text = row.Cells[6].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi cellclick: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = dgvTheLoai.CurrentRow;
                txtMaTL.Text = row.Cells[0].Value.ToString();
                txtTenTL.Text = row.Cells[1].Value.ToString();
                txtGhiChu.Text = row.Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cellclick: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaTL.Text == "" || txtTenTL.Text == "" || txtGhiChu.Text == "")
            {
                MessageBox.Show("Không được để trống dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var tl = db.TheLoais.FirstOrDefault(t => t.MaTheLoai.Equals(txtMaTL.Text));
                if (tl == null)
                {
                    TheLoai t = new TheLoai() { 
                        MaTheLoai = txtMaTL.Text,
                        TenTheLoai = txtTenTL.Text,
                        GhiChu = txtGhiChu.Text
                    };
                    db.TheLoais.Add(t);
                    db.SaveChanges();
                    initDgvTheLoai();
                }
                else
                {
                    MessageBox.Show("Mã thể loại bị trùng không thể thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaTL.Text == "" || txtTenTL.Text == "" || txtGhiChu.Text == "")
            {
                MessageBox.Show("Không được để trống dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var tl = db.TheLoais.FirstOrDefault(t => t.MaTheLoai.Equals(txtMaTL.Text));
                if (tl != null)
                {
                    DialogResult dlr = MessageBox.Show("Bạn có chắc muốn sửa không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        tl.TenTheLoai = txtTenTL.Text;
                        tl.GhiChu = txtGhiChu.Text;
                        db.SaveChanges();
                        initDgvTheLoai();
                    }
                }
                else
                {
                    MessageBox.Show("Mã thể loại không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaTL.Text == "")
            {
                MessageBox.Show("Không được để trống mã thể loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var tl = db.TheLoais.FirstOrDefault(t => t.MaTheLoai.Equals(txtMaTL.Text));
                if (tl != null)
                {
                    DialogResult dlr = MessageBox.Show("Bạn có chắc muốn Xóa không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        db.TheLoais.Remove(tl);
                        db.SaveChanges();
                        initDgvTheLoai();
                    }
                }
                else
                {
                    MessageBox.Show("Mã thể loại không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (txtTheLoaiCanTim.Text == "")
            {
                MessageBox.Show("Thể loại cần tìm không được để trông!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                var kq = (from tl in db.TheLoais
                          where tl.TenTheLoai.Contains(txtTheLoaiCanTim.Text)
                          select new { tl.MaTheLoai, tl.TenTheLoai, tl.GhiChu }).ToList();
                if (kq.Count() > 0)
                {
                    dgvTheLoai.DataSource = kq;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thể loại cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }

        private void btnXemLai_Click(object sender, EventArgs e)
        {
            initDgvTheLoai();
        }

        private void btnXoaTrang_Click(object sender, EventArgs e)
        {
            txtMaTL.Text = "";
            txtTenTL.Text = "";
            txtGhiChu.Text = "";
            txtTheLoaiCanTim.Text = "";
        }

        private void btnThemTL_Click(object sender, EventArgs e)
        {
            if (txtMaTaiLieu.Text == "" || txtTenTaiLieu.Text == "" || numSoLuong.Value == 0 || txtNhaXuatBan.Text == "" || numNamXuatBan.Value == 0 || txtTacGia.Text == "")
            {
                MessageBox.Show("Không được để trống dữ liệu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var tl = db.TaiLieux.FirstOrDefault(t => t.MaTaiLieu.Equals(txtMaTaiLieu.Text));
                if (tl == null)
                {
                    TaiLieu t = new TaiLieu() {
                        MaTaiLieu = txtMaTaiLieu.Text,
                        TenTaiLieu = txtTenTaiLieu.Text,
                        MaTheLoai = cmbTheLoai.SelectedValue.ToString(),
                        SoLuong = short.Parse(numSoLuong.Value.ToString()),
                        NhaXuatBan = txtNhaXuatBan.Text,
                        NamXuatBan = short.Parse(numNamXuatBan.Value.ToString()),
                        TacGia = txtTacGia.Text
                    };
                    db.TaiLieux.Add(t);
                    db.SaveChanges();
                    initDgvTaiLieu();
                }
                else
                {
                    MessageBox.Show("Tài liệu đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }

        private void btnSuaTL_Click(object sender, EventArgs e)
        {
            if (txtMaTaiLieu.Text == "" || txtTenTaiLieu.Text == "" || numSoLuong.Value == 0 || txtNhaXuatBan.Text == "" || numNamXuatBan.Value == 0 || txtTacGia.Text == "")
            {
                MessageBox.Show("Không được để trống dữ liệu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var tl = db.TaiLieux.FirstOrDefault(t => t.MaTaiLieu.Equals(txtMaTaiLieu.Text));
                if (tl != null)
                {
                    DialogResult dlr = MessageBox.Show("Bạn có chắc muốn sửa không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        tl.TenTaiLieu = txtTenTaiLieu.Text;
                        tl.MaTheLoai = cmbTheLoai.SelectedValue.ToString();
                        tl.SoLuong = short.Parse(numSoLuong.Value.ToString());
                        tl.NhaXuatBan = txtNhaXuatBan.Text;
                        tl.NamXuatBan = short.Parse(numNamXuatBan.Value.ToString());
                        tl.TacGia = txtTacGia.Text;
                        db.SaveChanges();
                        initDgvTaiLieu();
                    }
                }
                else
                {
                    MessageBox.Show("Tài liệu không tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }

        private void btnXoaTL_Click(object sender, EventArgs e)
        {
            if (txtMaTaiLieu.Text == "" )
            {
                MessageBox.Show("Không được để trống mã tài liệu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var tl = db.TaiLieux.FirstOrDefault(t => t.MaTaiLieu.Equals(txtMaTaiLieu.Text));
                if (tl != null)
                {
                    DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        db.TaiLieux.Remove(tl);
                        db.SaveChanges();
                        initDgvTaiLieu();
                    }
                }
                else
                {
                    MessageBox.Show("Tài liệu không tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }

        private void btnTimKiemTL_Click(object sender, EventArgs e)
        {
            if (txtTaiLieuCanTim.Text == "")
            {
                MessageBox.Show("Không được để trống ô tìm kiếm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                var kq = (from t in db.TaiLieux
                          join tl in db.TheLoais on t.MaTheLoai equals tl.MaTheLoai 
                          where t.TenTaiLieu.Contains(txtTaiLieuCanTim.Text)
                          select new
                          {
                              t.MaTaiLieu,
                              t.TenTaiLieu,
                              tl.TenTheLoai,
                              t.SoLuong,
                              t.NhaXuatBan,
                              t.NamXuatBan,
                              t.TacGia
                          }).ToList();
                if (kq.Count() > 0)
                {
                    dgvTaiLieu.DataSource = kq;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài liệu cần tìm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void btnXemLaiTL_Click(object sender, EventArgs e)
        {
            initDgvTaiLieu();
        }

        private void btnXoaTrangTL_Click(object sender, EventArgs e)
        {
            txtMaTaiLieu.Text = "";
            txtTenTaiLieu.Text = "";
            cmbTheLoai.SelectedIndex = 0;
            numSoLuong.Value = 0;
            txtNhaXuatBan.Text = "";
            numNamXuatBan.Value = 0;
            txtTacGia.Text = "";
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            dgvTaiLieu.DataSource = (from t in db.TaiLieux
                                     join tl in db.TheLoais on t.MaTheLoai equals tl.MaTheLoai 
                                     where tl.TenTheLoai.Equals(cmbLocTL.Text) 
                                     select new
                                     {
                                         t.MaTaiLieu,
                                         t.TenTaiLieu,
                                         tl.TenTheLoai,
                                         t.SoLuong,
                                         t.NhaXuatBan,
                                         t.NamXuatBan,
                                         t.TacGia
                                     }).ToList();
        }
    }
}
