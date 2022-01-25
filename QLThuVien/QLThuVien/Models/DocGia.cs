namespace QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DocGia")]
    public partial class DocGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DocGia()
        {
            PhieuMuons = new HashSet<PhieuMuon>();
        }

        [Key]
        [StringLength(10)]
        public string MaDocGia { get; set; }

        [Required]
        [StringLength(10)]
        public string MaDoiTuong { get; set; }

        [StringLength(20)]
        public string HoTen { get; set; }

        [StringLength(20)]
        public string GioiTinh { get; set; }

        public DateTime? NgaySinh { get; set; }

        public DateTime? NgayCap { get; set; }

        public DateTime? NgayHetHan { get; set; }

        public virtual DoiTuong DoiTuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuMuon> PhieuMuons { get; set; }
    }
}
