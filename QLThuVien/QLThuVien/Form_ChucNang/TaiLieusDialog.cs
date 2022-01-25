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
    public partial class TaiLieusDialog : Form
    {
        QLThuVienDB db = new QLThuVienDB();
        public TaiLieusDialog()
        {
            InitializeComponent();
        }
        public TaiLieusDialog(String maPhieu)
        {
            InitializeComponent();
            dgvTaiLieus.DataSource = (from ctpm in db.PhieuMuonChiTiets
                                      join tl in db.TaiLieux on ctpm.MaTaiLieu equals tl.MaTaiLieu
                                      where ctpm.MaPhieuMuon.Equals(maPhieu)
                                      select new { tl.MaTaiLieu, tl.TenTaiLieu, ctpm.SoLuongMuon, tl.NhaXuatBan, tl.TacGia }).ToList();
        }
    }
}
