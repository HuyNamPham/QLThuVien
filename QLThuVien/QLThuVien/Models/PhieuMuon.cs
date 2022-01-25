namespace QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuMuon")]
    public partial class PhieuMuon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuMuon()
        {
            PhieuMuonChiTiets = new HashSet<PhieuMuonChiTiet>();
        }

        [Key]
        [StringLength(10)]
        public string MaPhieuMuon { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNhanVien { get; set; }

        [Required]
        [StringLength(10)]
        public string MaDocGia { get; set; }

        public DateTime? NgayMuon { get; set; }
        public DateTime? NgayTra { get; set; }
        public bool? TinhTrang { get; set; }

        public virtual DocGia DocGia { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuMuonChiTiet> PhieuMuonChiTiets { get; set; }
    }
}
