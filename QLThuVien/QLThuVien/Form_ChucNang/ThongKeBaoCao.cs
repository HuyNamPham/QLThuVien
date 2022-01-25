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
    public partial class ThongKeBaoCao : Form
    {
        public ThongKeBaoCao()
        {
            InitializeComponent();
        }
        QLThuVienDB db = new QLThuVienDB();
        private void ThongKeBaoCao_Load(object sender, EventArgs e)
        {
            cmbHienThi.SelectedIndex = 0;
            cmbTinhTrang.SelectedIndex = 0;
            initPhieu();
        }
        private void initPhieu()
        {
            var list = (from p in db.PhieuMuons
                                   join ctp in db.PhieuMuonChiTiets on p.MaPhieuMuon equals ctp.MaPhieuMuon
                                   join nv in db.NhanViens on p.MaNhanVien equals nv.MaNhanVien
                                   join dg in db.DocGias on p.MaDocGia equals dg.MaDocGia 
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
            if (cmbHienThi.SelectedIndex == 1)
            {
                if (cmbTinhTrang.SelectedIndex == 0)
                {
                    list = list.Where(l => l.NgayMuon.Value.Date >= dtNgayBD.Value.Date)
                        .Where(l => l.NgayMuon.Value.Date <= dtNgayKT.Value.Date).ToList();
                }
                if (cmbTinhTrang.SelectedIndex == 1)
                {
                    list = list.Where(l => l.TinhTrang.Value.ToString().Equals("True"))
                        .Where(l => l.NgayMuon.Value.Date >= dtNgayBD.Value.Date)
                        .Where(l => l.NgayMuon.Value.Date <= dtNgayKT.Value.Date).ToList();
                }
                if (cmbTinhTrang.SelectedIndex == 2)
                {
                    list = list.Where(l => l.TinhTrang.Value.ToString().Equals("False"))
                        .Where(l => l.NgayMuon.Value.Date >= dtNgayBD.Value.Date)
                        .Where(l => l.NgayMuon.Value.Date <= dtNgayKT.Value.Date).ToList();
                }
            }
            else
            {
                if (cmbTinhTrang.SelectedIndex == 1)
                {
                    list = list.Where(l => l.TinhTrang.Value.ToString().Equals("True")).ToList();
                }
                if (cmbTinhTrang.SelectedIndex == 2)
                {
                    list = list.Where(l => l.TinhTrang.Value.ToString().Equals("False")).ToList();
                }
            }
            dgvPhieu.DataSource = list;
        }

        private void cmbTinhTrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            initPhieu();
        }

        private void cmbHienThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            initPhieu();
        }

        private void btnQuaHan_Click(object sender, EventArgs e)
        {
            var list = (from p in db.PhieuMuons
                                   join ctp in db.PhieuMuonChiTiets on p.MaPhieuMuon equals ctp.MaPhieuMuon
                                   join nv in db.NhanViens on p.MaNhanVien equals nv.MaNhanVien
                                   join dg in db.DocGias on p.MaDocGia equals dg.MaDocGia 
                                   where p.TinhTrang.Value.ToString().Equals("False")
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
            dgvPhieu.DataSource = list.Where(s=>s.NgayTra.Value.Date < DateTime.Now.Date).ToList();
        }

        private void dgvPhieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvPhieu.CurrentRow;
            if (row != null)
            {
                new TaiLieusDialog(row.Cells[0].Value.ToString().Trim()).ShowDialog();
            }
        }
    }
}
