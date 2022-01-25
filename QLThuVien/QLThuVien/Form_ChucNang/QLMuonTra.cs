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
    public partial class QLMuonTra : Form
    {
        public QLMuonTra()
        {
            InitializeComponent();
        }
        QLThuVienDB db = new QLThuVienDB();
        private void QLMuonTra_Load(object sender, EventArgs e)
        {
            initDoiTuong();
            initDocGia();
            initMuonTra();
        }
        private void initDoiTuong()
        {
            dgvDoiTuong.DataSource = (from d in db.DoiTuongs
                                      select new { d.MaDoiTuong, d.TenDoiTuong }).ToList();
        }
        private void initDocGia()
        {
            cmbDoiTuong.DataSource = (from d in db.DoiTuongs
                                      select new { d.MaDoiTuong, d.TenDoiTuong }).ToList();
            cmbDoiTuong.DisplayMember = "TenDoiTuong";
            cmbDoiTuong.ValueMember = "MaDoiTuong";

            dgvDocGia.DataSource = (from dg in db.DocGias
                                    join d in db.DoiTuongs on dg.MaDoiTuong equals d.MaDoiTuong 
                                    select new { dg.MaDocGia,dg.HoTen,dg.GioiTinh,dg.NgaySinh,d.TenDoiTuong,dg.NgayCap,dg.NgayHetHan}).ToList();
        }
        private void initMuonTra()
        {
            cmbTaiLieuChon.DataSource = (from t in db.TaiLieux
                                         select new { t.MaTaiLieu,t.TenTaiLieu}).ToList();
            cmbTaiLieuChon.DisplayMember = "TenTaiLieu";
            cmbTaiLieuChon.ValueMember = "MaTaiLieu";

            dgvTaiLieu.DataSource = (from t in db.TaiLieux 
                                     select new { t.MaTaiLieu, t.TenTaiLieu, t.SoLuong, t.TacGia}).ToList();
            dgvPhieu.DataSource = (from p in db.PhieuMuons 
                                   join ctp in db.PhieuMuonChiTiets on p.MaPhieuMuon equals ctp.MaPhieuMuon 
                                   join nv in db.NhanViens on p.MaNhanVien equals nv.MaNhanVien 
                                   join dg in db.DocGias on p.MaDocGia equals dg.MaDocGia 
                                   group ctp by new { p.MaPhieuMuon, p.NgayMuon, p.NgayTra, dg.HoTen, nv.TaiKhoan, p.TinhTrang} into kq 
                                   select new { MaPhieuMuon = kq.Key.MaPhieuMuon,
                                                NgayMuon = kq.Key.NgayMuon,
                                                NgayTra = kq.Key.NgayTra,
                                                DocGia = kq.Key.HoTen,
                                                NhanVien = kq.Key.TaiKhoan,
                                                TongSach = kq.Sum(s=>s.SoLuongMuon),
                                                TinhTrang = kq.Key.TinhTrang
                                   }).ToList();
        }

        private void dgvDoiTuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvDoiTuong.CurrentRow;
            if (row != null)
            {
                txtMaDT.Text = row.Cells[0].Value.ToString();
                txtTenDT.Text = row.Cells[1].Value.ToString();
            }
        }

        private void dgvDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvDocGia.CurrentRow;
            if (row != null)
            {
                txtMaDG.Text = row.Cells[0].Value.ToString();
                txtHoTenDG.Text = row.Cells[1].Value.ToString();
                if(row.Cells[2].Value.ToString()=="Nam")
                {
                    rbtnNam.Select();
                }
                else
                {
                    rbtnNu.Select();
                }
                dtNgaySinh.Value = DateTime.Parse(row.Cells[3].Value.ToString());
                cmbDoiTuong.Text = row.Cells[4].Value.ToString();
                dtNgayCap.Value = DateTime.Parse(row.Cells[5].Value.ToString());
                dtNgayHetHan.Value = DateTime.Parse(row.Cells[6].Value.ToString());
            }
        }

        private void dgvPhieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvPhieu.CurrentRow;
            if(row != null)
            {
                txtMaPhieu.Text = row.Cells[0].Value.ToString();
                string maDG = db.PhieuMuons.FirstOrDefault(p => p.MaPhieuMuon.Equals(txtMaPhieu.Text)).MaDocGia;
                var dg = db.DocGias.Join(db.DoiTuongs, d => d.MaDoiTuong, dt => dt.MaDoiTuong,
                        (d, dt) => new { d.MaDocGia, d.HoTen, d.GioiTinh, dt.TenDoiTuong }).FirstOrDefault(s => s.MaDocGia.Equals(maDG));
                var tlm = (from ctpm in db.PhieuMuonChiTiets
                           join tl in db.TaiLieux on ctpm.MaTaiLieu equals tl.MaTaiLieu
                           where ctpm.MaPhieuMuon.Equals(txtMaPhieu.Text)
                           select new { tl.MaTaiLieu, tl.TenTaiLieu, ctpm.SoLuongMuon }).ToList();

                dtNgayMuon.Value = DateTime.Parse(row.Cells[1].Value.ToString());
                dtNgayTra.Value = DateTime.Parse(row.Cells[2].Value.ToString());
                txtMaDocGia.Text = dg.MaDocGia;
                txtHoTenDocGia.Text = dg.HoTen;
                txtDoiTuong.Text = dg.TenDoiTuong;
                txtGioiTinh.Text = dg.GioiTinh;

                dgvTaiLieuChon.DataSource = tlm;
            }
        }

        private void btnThemDT_Click(object sender, EventArgs e)
        {
            if (txtMaDT.Text == "" || txtTenDT.Text == "")
            {
                MessageBox.Show("Thông tin không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var dt = db.DoiTuongs.FirstOrDefault(d => d.MaDoiTuong.Equals(txtMaDT.Text));
                if (dt == null)
                {
                    DoiTuong d = new DoiTuong() { 
                           MaDoiTuong = txtMaDT.Text,
                           TenDoiTuong = txtTenDT.Text
                    };
                    db.DoiTuongs.Add(d);
                    db.SaveChanges();
                    initDoiTuong();
                }
                else
                {
                    MessageBox.Show("Mã đối tượng đã tồn tại!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSuaDT_Click(object sender, EventArgs e)
        {
            if (txtMaDT.Text == "" || txtTenDT.Text == "")
            {
                MessageBox.Show("Thông tin không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var dt = db.DoiTuongs.FirstOrDefault(d => d.MaDoiTuong.Equals(txtMaDT.Text));
                if (dt != null)
                {
                    DialogResult dlr = MessageBox.Show("Bạn có chắc muốn sửa không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        dt.TenDoiTuong = txtTenDT.Text;
                        db.SaveChanges();
                        initDoiTuong();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã đối tượng!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXoaDT_Click(object sender, EventArgs e)
        {
            if (txtMaDT.Text == "")
            {
                MessageBox.Show("Mã đối tượng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var dt = db.DoiTuongs.FirstOrDefault(d => d.MaDoiTuong.Equals(txtMaDT.Text));
                if (dt != null)
                {
                    DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        db.DoiTuongs.Remove(dt);
                        db.SaveChanges();
                        initDoiTuong();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã đối tượng!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXoaTrangDT_Click(object sender, EventArgs e)
        {
            txtMaDT.Text = "";
            txtTenDT.Text = "";
        }

        private void btnThemDG_Click(object sender, EventArgs e)
        {
            if (txtMaDG.Text=="" || txtHoTenDG.Text=="")
            {
                MessageBox.Show("Thông tin không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var dg = db.DocGias.FirstOrDefault(d=>d.MaDocGia.Equals(txtMaDG.Text));
                if (dg == null)
                {
                    DocGia d = new DocGia();
                    d.MaDocGia = txtMaDG.Text;
                    d.HoTen = txtHoTenDG.Text;
                    if (rbtnNam.Checked)
                    {
                        d.GioiTinh = "Nam";
                    }
                    else
                    {
                        d.GioiTinh = "Nữ";
                    }
                    d.NgaySinh = dtNgaySinh.Value;
                    d.MaDoiTuong = cmbDoiTuong.SelectedValue.ToString();
                    d.NgayCap = dtNgayCap.Value;
                    d.NgayHetHan = dtNgayHetHan.Value;

                    db.DocGias.Add(d);
                    db.SaveChanges();
                    initDocGia();
                }
                else
                {
                    MessageBox.Show("Mã độc giả đã tồn tại!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSuaDG_Click(object sender, EventArgs e)
        {
            if (txtMaDG.Text == "" || txtHoTenDG.Text == "")
            {
                MessageBox.Show("Thông tin không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var dg = db.DocGias.FirstOrDefault(d => d.MaDocGia.Equals(txtMaDG.Text));
                if (dg != null)
                {
                    DialogResult dlr = MessageBox.Show("Bạn có chắc muốn sửa không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        dg.HoTen = txtHoTenDG.Text;
                        if (rbtnNam.Checked)
                        {
                            dg.GioiTinh = "Nam";
                        }
                        else
                        {
                            dg.GioiTinh = "Nữ";
                        }
                        dg.NgaySinh = dtNgaySinh.Value;
                        dg.MaDoiTuong = cmbDoiTuong.SelectedValue.ToString();
                        dg.NgayCap = dtNgayCap.Value;
                        dg.NgayHetHan = dtNgayHetHan.Value;


                        db.SaveChanges();
                        initDocGia();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã độc giả!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXoaDG_Click(object sender, EventArgs e)
        {
            if (txtMaDG.Text == "")
            {
                MessageBox.Show("Mã độc giả không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var dg = db.DocGias.FirstOrDefault(d => d.MaDocGia.Equals(txtMaDG.Text));
                if (dg != null)
                {
                    DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        db.DocGias.Remove(dg);
                        db.SaveChanges();
                        initDocGia();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã độc giả đã tồn tại!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXoaTrangDG_Click(object sender, EventArgs e)
        {
            txtMaDG.Text = "";
            txtHoTenDG.Text = "";
            dtNgaySinh.Value = DateTime.Now;
            dtNgayCap.Value = DateTime.Now;
            dtNgayHetHan.Value = DateTime.Now;
            rbtnNam.Select();
        }

        private void btnTimKiemDG_Click(object sender, EventArgs e)
        {
            if (txtTimKiemDocGia.Text == "")
            {
                MessageBox.Show("Thông tin tìm kiếm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var kq = (from dg in db.DocGias
                          join d in db.DoiTuongs on dg.MaDoiTuong equals d.MaDoiTuong
                          where dg.HoTen.Contains(txtTimKiemDocGia.Text)
                          select new { dg.MaDocGia, dg.HoTen, dg.GioiTinh, dg.NgaySinh, d.TenDoiTuong, dg.NgayCap, dg.NgayHetHan }).ToList();
                if (kq.Count() > 0)
                {
                    dgvDocGia.DataSource = kq;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void btnXemLaiDG_Click(object sender, EventArgs e)
        {
            initDocGia();
        }

        private void btnTimTaiLieu_Click(object sender, EventArgs e)
        {
            var kq = (from t in db.TaiLieux
                      where t.TenTaiLieu.Contains(txtTimTaiLieu.Text)
                      select new { t.MaTaiLieu, t.TenTaiLieu, t.SoLuong, t.TacGia }).ToList();
            if (kq.Count() > 0)
            {
                dgvTaiLieu.DataSource = kq;
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài liệu cần tìm!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void Reload_Click(object sender, EventArgs e)
        {
            dgvTaiLieu.DataSource = (from t in db.TaiLieux 
                                     select new { t.MaTaiLieu, t.TenTaiLieu, t.SoLuong, t.TacGia }).ToList();
        }

        private void dgvTaiLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvTaiLieu.CurrentRow;
            if (row != null) {
                cmbTaiLieuChon.SelectedValue = row.Cells[0].Value;
            }
        }
        int index = -1;
        private void btnChonSach_Click(object sender, EventArgs e)
        {
            if (dgvTaiLieuChon.DataSource != null)
            {
                MessageBox.Show("Không được sửa danh sách tài liệu đã được lập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            decimal slgCo = decimal.Parse(db.TaiLieux.SingleOrDefault(t => t.MaTaiLieu.Equals(cmbTaiLieuChon.SelectedValue.ToString())).SoLuong.ToString());
            if (numSoLuong.Value > 0 &&   slgCo >= numSoLuong.Value)
            {
                //kiểm tra xem mã tài liệu có chưa, có rồi thì thay đổi số lượng
                for (var i = 0; i <= index; i++)
                {
                    if (dgvTaiLieuChon.Rows[i].Cells[0].Value == cmbTaiLieuChon.SelectedValue)
                    {
                        dgvTaiLieuChon.Rows[i].Cells[2].Value = numSoLuong.Value;
                        return;
                    }
                }
                //thêm dòng cới mã tài liệu mới
                dgvTaiLieuChon.Rows.Add();
                index++;
                dgvTaiLieuChon.Rows[index].Cells[0].Value = cmbTaiLieuChon.SelectedValue;
                dgvTaiLieuChon.Rows[index].Cells[1].Value = cmbTaiLieuChon.Text;
                dgvTaiLieuChon.Rows[index].Cells[2].Value = numSoLuong.Value;
            }
            else
            {
                MessageBox.Show("Số lượng mượn phải lớn hơn 0 và nhỏ hơn số lượng Có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            if (dgvTaiLieuChon.DataSource != null)
            {
                MessageBox.Show("Không được Xóa danh sách tài liệu đã được lập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (index == -1)
            {
                MessageBox.Show("Không có dữ liệu để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                var selectedRow = dgvTaiLieuChon.SelectedRows;
                foreach (DataGridViewRow row in selectedRow)
                {
                    dgvTaiLieuChon.Rows.Remove(row);
                    index--;
                }
            }
        }

        private void dgvTaiLieuChon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvTaiLieuChon.CurrentRow;
            if (row != null && row.Cells[0].Value != null)
            {
                cmbTaiLieuChon.SelectedValue = row.Cells[0].Value;
                numSoLuong.Value = decimal.Parse(row.Cells[2].Value.ToString());
            }
        }

        private void btnXoaTatCa_Click(object sender, EventArgs e)
        {
            if (dgvTaiLieuChon.DataSource != null)
            {
                dgvTaiLieuChon.DataSource = null;
            }
            dgvTaiLieuChon.Columns.Clear();
            dgvTaiLieuChon.Columns.Add("MaTaiLieu","Mã tài liệu");
            dgvTaiLieuChon.Columns[0].DataPropertyName = "MaTaiLieu";
            dgvTaiLieuChon.Columns.Add("TenTaiLieu", "Tên tài liệu");
            dgvTaiLieuChon.Columns[1].DataPropertyName = "TenTaiLieu";
            dgvTaiLieuChon.Columns.Add("SoLuongMuon", "Số lượng mượn");
            dgvTaiLieuChon.Columns[2].DataPropertyName = "SoLuongMuon";

            index = -1;
        }

        private void txtMaDocGia_TextChanged(object sender, EventArgs e)
        {
            var dg = db.DocGias.Join(db.DoiTuongs, d => d.MaDoiTuong, dt => dt.MaDoiTuong,
                        (d, dt) => new { d.MaDocGia, d.HoTen, d.GioiTinh, dt.TenDoiTuong }).FirstOrDefault(s => s.MaDocGia.Equals(txtMaDocGia.Text));
            if (dg != null)
            {
                txtHoTenDocGia.Text = dg.HoTen;
                txtDoiTuong.Text = dg.TenDoiTuong;
                txtGioiTinh.Text = dg.GioiTinh;
            }
            else
            {
                txtHoTenDocGia.Text = "";
                txtDoiTuong.Text = "";
                txtGioiTinh.Text = "";
            }
        }

        private void btnTimPhieu_Click(object sender, EventArgs e)
        {
            if (txtTimPhieu.Text == "")
            {
                MessageBox.Show("Tên độc giả tìm kiếm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var list = dgvPhieu.DataSource = (from p in db.PhieuMuons
                                                join ctp in db.PhieuMuonChiTiets on p.MaPhieuMuon equals ctp.MaPhieuMuon
                                                join nv in db.NhanViens on p.MaNhanVien equals nv.MaNhanVien
                                                join dg in db.DocGias on p.MaDocGia equals dg.MaDocGia
                                                where dg.HoTen.Contains(txtTimPhieu.Text)
                                                group ctp by new { p.MaPhieuMuon, p.NgayMuon, p.NgayTra, dg.HoTen, nv.TaiKhoan, p.TinhTrang } into kq
                                                select new
                                                {
                                                    MaPhieuMuon = kq.Key.MaPhieuMuon,
                                                    NgayMuon = kq.Key.NgayMuon,
                                                    NgayTra = kq.Key.NgayTra,
                                                    DocGia = kq.Key.HoTen,
                                                    NhanVien = kq.Key.TaiKhoan,
                                                    TongSach = kq.Sum(s => s.SoLuongMuon),
                                                    TinhTrang = kq.Key.TinhTrang
                                                }).ToList();
                dgvPhieu.DataSource = list;
            }
        }

        private void btnXemLaiPhieu_Click(object sender, EventArgs e)
        {
            initMuonTra();
        }

        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            string LastPM = db.PhieuMuons.ToList().Last<PhieuMuon>().MaPhieuMuon.Substring(2);//Lấy số của Phiếu mượn cuối cùng
            if (String.IsNullOrEmpty(LastPM))
            {
                LastPM = "1";//sử dụng khi CSDL chưa có phiếu mượn nào
            }
            txtMaPhieu.Text = "PM"+(int.Parse(LastPM)+1).ToString();
            dtNgayMuon.Value = DateTime.Now;
            dtNgayTra.Value = DateTime.Now;
            txtMaDocGia.Text = "";
            txtTimTaiLieu.Text = "";
            txtTimPhieu.Text = "";
            numSoLuong.Value = 1;
            btnXoaTatCa_Click(sender,e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaPhieu.Text == ""||txtMaDocGia.Text==""|| dgvTaiLieuChon.RowCount == 1)
            {
                MessageBox.Show("Thông tin phiếu và danh sách tài liệu chọn không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var pm = db.PhieuMuons.FirstOrDefault(p => p.MaPhieuMuon.Equals(txtMaPhieu.Text));
                if (pm == null)
                {
                    //thêm phiếu mượn
                    PhieuMuon p = new PhieuMuon()
                    {
                        MaPhieuMuon = txtMaPhieu.Text,
                        MaNhanVien = NguoiDung.NguoiDN.MaNhanVien,
                        MaDocGia = txtMaDocGia.Text,
                        NgayMuon = dtNgayMuon.Value,
                        NgayTra = dtNgayTra.Value,
                        TinhTrang = false
                    };
                    db.PhieuMuons.Add(p);
                    db.SaveChanges();

                    //thêm phiếu mượn chi tiết
                    for(var i = 0; i < (dgvTaiLieuChon.RowCount-1); i++)
                    {
                        PhieuMuonChiTiet pmct = new PhieuMuonChiTiet()
                        {
                            MaPhieuMuon = txtMaPhieu.Text,
                            MaTaiLieu = dgvTaiLieuChon.Rows[i].Cells[0].Value.ToString(),
                            SoLuongMuon = short.Parse(dgvTaiLieuChon.Rows[i].Cells[2].Value.ToString())
                        };
                        db.PhieuMuonChiTiets.Add(pmct);
                        //giảm số lượng có 
                        string maTLThayDoi = dgvTaiLieuChon.Rows[i].Cells[0].Value.ToString();
                        var tl = db.TaiLieux.FirstOrDefault(t => t.MaTaiLieu.Equals(maTLThayDoi));
                        tl.SoLuong = (short)(int.Parse(tl.SoLuong.ToString()) - int.Parse(dgvTaiLieuChon.Rows[i].Cells[2].Value.ToString()));
                    }
                    db.SaveChanges();
                    initMuonTra();
                    // thêm xong thì xóa hết các dữ liệu hiển thị trên form
                    btnThemPhieu_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Mã phiếu đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnDanhDau_Click(object sender, EventArgs e)
        {
            if (txtMaPhieu.Text == "")
            {
                MessageBox.Show("Mã phiếu không được để trống!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var pm = db.PhieuMuons.FirstOrDefault(p => p.MaPhieuMuon.Equals(txtMaPhieu.Text));
                if (pm != null)
                {
                    if (pm.TinhTrang == false)
                    {
                        //Tăng số lượng sách có khi đánh dấu hoàn thành
                        for (var i = 0; i < dgvTaiLieuChon.RowCount; i++)
                        {
                            string maTL = dgvTaiLieuChon.Rows[i].Cells[0].Value.ToString();
                            var tl = db.TaiLieux.ToList().SingleOrDefault(t => t.MaTaiLieu.Equals(maTL));
                            tl.SoLuong = (short)(int.Parse(tl.SoLuong.ToString()) + int.Parse(dgvTaiLieuChon.Rows[i].Cells[2].Value.ToString()));
                        }
                        //Đánh dấu hoàn thành
                        pm.TinhTrang = true;
                        db.SaveChanges();
                        initMuonTra();

                    }
                    else
                    {
                        MessageBox.Show("Phiếu đã được hoàn  thành rồi không cần đánh dấu nữa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã phiếu cần Xác nhận hoàn thành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            if (txtMaPhieu.Text == "")
            {
                MessageBox.Show("Mã phiếu không được để trống!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var pm = db.PhieuMuons.FirstOrDefault(p => p.MaPhieuMuon.Equals(txtMaPhieu.Text));
                if (pm != null)
                {
                    DialogResult dlr = MessageBox.Show("Bạn có chắc muốn xóa toàn bộ các dữ liệu của phiếu mượn không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        if (pm.TinhTrang == false)
                        {
                            //Tăng số lượng sách có trước khi xóa nếu phiếu chưa hoàn trả
                            for (var i = 0; i < dgvTaiLieuChon.RowCount; i++)
                            {
                                string maTL = dgvTaiLieuChon.Rows[i].Cells[0].Value.ToString();
                                var tl = db.TaiLieux.ToList().SingleOrDefault(t => t.MaTaiLieu.Equals(maTL));
                                tl.SoLuong = (short)(int.Parse(tl.SoLuong.ToString()) + int.Parse(dgvTaiLieuChon.Rows[i].Cells[2].Value.ToString()));
                            }
                        }
                        //xóa các phiếu mượn chi tiết trước
                        var listPMChiTiet = (from pmct in db.PhieuMuonChiTiets
                                             where pmct.MaPhieuMuon.Equals(txtMaPhieu.Text)
                                             select pmct).ToList();
                        foreach (PhieuMuonChiTiet p in listPMChiTiet)
                        {
                            db.PhieuMuonChiTiets.Remove(p);
                        }
                        //xóa phiếu mượn
                        db.PhieuMuons.Remove(pm);
                        db.SaveChanges();
                        initMuonTra();
                        btnXoaTatCa_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã phiếu cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
