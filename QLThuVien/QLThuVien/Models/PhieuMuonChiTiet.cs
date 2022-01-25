namespace QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuMuonChiTiet")]
    public partial class PhieuMuonChiTiet
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaPhieuMuon { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaTaiLieu { get; set; }

        public short? SoLuongMuon { get; set; }

        

        public virtual PhieuMuon PhieuMuon { get; set; }

        public virtual TaiLieu TaiLieu { get; set; }
    }
}
