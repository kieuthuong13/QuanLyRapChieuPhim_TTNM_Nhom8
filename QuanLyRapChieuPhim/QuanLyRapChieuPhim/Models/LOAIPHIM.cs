namespace QuanLyRapChieuPhim.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAIPHIM")]
    public partial class LOAIPHIM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIPHIM()
        {
            PHIMs = new HashSet<PHIM>();
        }

        [Key]
        public int MaLoai { get; set; }

        [StringLength(100)]
        public string TenLoai { get; set; }

        [StringLength(100)]
        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIM> PHIMs { get; set; }
    }
}
