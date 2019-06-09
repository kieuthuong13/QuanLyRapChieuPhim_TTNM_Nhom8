namespace QuanLyRapChieuPhim.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIM")]
    public partial class PHIM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIM()
        {
            LICHCHIEUx = new HashSet<LICHCHIEU>();
        }

        [Key]
        public int MaPhim { get; set; }

        [StringLength(100)]
        public string TenPhim { get; set; }

        [StringLength(100)]
        public string DaoDien { get; set; }

        [StringLength(100)]
        public string DienVien { get; set; }

        public int? MaLoai { get; set; }

        [StringLength(100)]
        public string NoiDung { get; set; }

        public DateTime? NamSX { get; set; }

        [StringLength(100)]
        public string QuocGia { get; set; }

        public int? ThoiLuong { get; set; }

        [StringLength(100)]
        public string Poster { get; set; }

        [StringLength(100)]
        public string Trailer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICHCHIEU> LICHCHIEUx { get; set; }

        public virtual LOAIPHIM LOAIPHIM { get; set; }
    }
}
