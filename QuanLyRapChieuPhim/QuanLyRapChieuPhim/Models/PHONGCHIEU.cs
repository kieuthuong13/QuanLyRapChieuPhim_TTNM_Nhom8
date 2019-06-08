namespace QuanLyRapChieuPhim.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHONGCHIEU")]
    public partial class PHONGCHIEU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHONGCHIEU()
        {
            LICHCHIEUx = new HashSet<LICHCHIEU>();
        }

        [Key]
        public int MaPhongChieu { get; set; }

        [StringLength(100)]
        public string TenPhongChieu { get; set; }

        public int? MaLoai { get; set; }

        public int? SoGhe { get; set; }

        [StringLength(100)]
        public string ThietBi { get; set; }

        [StringLength(100)]
        public string TinhTrang { get; set; }

        [StringLength(100)]
        public string DienTich { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICHCHIEU> LICHCHIEUx { get; set; }

        public virtual LOAIPHONG LOAIPHONG { get; set; }
    }
}
