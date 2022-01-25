using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLThuVien.Models
{
    public partial class QLThuVienDB : DbContext
    {
        public QLThuVienDB()
            : base("name=QLThuVienDB")
        {
        }

        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<DocGia> DocGias { get; set; }
        public virtual DbSet<DoiTuong> DoiTuongs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuMuon> PhieuMuons { get; set; }
        public virtual DbSet<PhieuMuonChiTiet> PhieuMuonChiTiets { get; set; }
        public virtual DbSet<TaiLieu> TaiLieux { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChucVu>()
                .Property(e => e.MaChucVu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChucVu>()
                .HasMany(e => e.NhanViens)
                .WithRequired(e => e.ChucVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DocGia>()
                .Property(e => e.MaDocGia)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DocGia>()
                .Property(e => e.MaDoiTuong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DocGia>()
                .HasMany(e => e.PhieuMuons)
                .WithRequired(e => e.DocGia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DoiTuong>()
                .Property(e => e.MaDoiTuong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DoiTuong>()
                .HasMany(e => e.DocGias)
                .WithRequired(e => e.DoiTuong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNhanVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaChucVu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.TaiKhoan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MatKhau)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Quyen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.PhieuMuons)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuMuon>()
                .Property(e => e.MaPhieuMuon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuMuon>()
                .Property(e => e.MaNhanVien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuMuon>()
                .Property(e => e.MaDocGia)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuMuon>()
                .HasMany(e => e.PhieuMuonChiTiets)
                .WithRequired(e => e.PhieuMuon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuMuonChiTiet>()
                .Property(e => e.MaPhieuMuon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhieuMuonChiTiet>()
                .Property(e => e.MaTaiLieu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaiLieu>()
                .Property(e => e.MaTaiLieu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaiLieu>()
                .Property(e => e.MaTheLoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaiLieu>()
                .HasMany(e => e.PhieuMuonChiTiets)
                .WithRequired(e => e.TaiLieu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TheLoai>()
                .Property(e => e.MaTheLoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TheLoai>()
                .HasMany(e => e.TaiLieux)
                .WithRequired(e => e.TheLoai)
                .WillCascadeOnDelete(false);
        }
    }
}
