namespace QuanLyRapChieuPhim.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanLyRapPhim : DbContext
    {
        public QuanLyRapPhim()
            : base("name=QuanLyRapPhim")
        {
        }

        public virtual DbSet<LICHCHIEU> LICHCHIEUx { get; set; }
        public virtual DbSet<LOAIPHIM> LOAIPHIMs { get; set; }
        public virtual DbSet<LOAIPHONG> LOAIPHONGs { get; set; }
        public virtual DbSet<PHIM> PHIMs { get; set; }
        public virtual DbSet<PHONGCHIEU> PHONGCHIEUx { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.TaiKhoan1)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);
        }
    }
}
