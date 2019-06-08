namespace QuanLyRapChieuPhim.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LICHCHIEU")]
    public partial class LICHCHIEU
    {
        [Key]
        public int MaChieu { get; set; }

        public int? MaPhim { get; set; }

        public int? MaPhongChieu { get; set; }

        [StringLength(100)]
        public string CaChieu { get; set; }

        public DateTime? TuNgay { get; set; }

        public DateTime? NgayKetThuc { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        public virtual PHIM PHIM { get; set; }

        public virtual PHONGCHIEU PHONGCHIEU { get; set; }
    }
}
