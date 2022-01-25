namespace QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiLieu")]
    public partial class TaiLieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiLieu()
        {
            PhieuMuonChiTiets = new HashSet<PhieuMuonChiTiet>();
        }

        [Key]
        [StringLength(10)]
        public string MaTaiLieu { get; set; }

        [Required]
        [StringLength(10)]
        public string MaTheLoai { get; set; }

        [StringLength(20)]
        public string TenTaiLieu { get; set; }

        public short? SoLuong { get; set; }

        [StringLength(20)]
        public string NhaXuatBan { get; set; }

        public short? NamXuatBan { get; set; }

        [StringLength(20)]
        public string TacGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuMuonChiTiet> PhieuMuonChiTiets { get; set; }

        public virtual TheLoai TheLoai { get; set; }
    }
}
