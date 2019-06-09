using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyRapChieuPhim.Models;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyRapChieuPhim
{
    public partial class frmQuanLyThanhVien : Form
    {
        QuanLyRapPhim db = new QuanLyRapPhim();

        public frmQuanLyThanhVien()
        {
            InitializeComponent();
            this.MinimumSize = new Size(1080, 710);
        }

        #region MY FUNCTION
        public void Clear()
        {
            txtMaThanhVien.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            rtbGhiChu.Clear();
        }
        #endregion

        #region My_STRUCT
        [Table("THANHVIEN")]
        public partial class THANHVIEN_STRUCT
        {
            [Key]
            [Display]
            public int MaThanhVien { get; set; }

            [StringLength(100)]
            public string HoTen { get; set; }

            [StringLength(100)]
            public string GioiTinh { get; set; }

            [StringLength(100)]
            public string DiaChi { get; set; }

            [StringLength(100)]
            public string Email { get; set; }

            [StringLength(100)]
            public string SDT { get; set; }

            [StringLength(100)]
            public string TenDangNhap { get; set; }

            [StringLength(100)]
            public string MatKhau { get; set; }

            [StringLength(100)]
            public string GhiChu { get; set; }
        }
        #endregion

        private void frmQuanLyThanhVien_Load(object sender, EventArgs e)
        {
            dgvThanhVien.DataSource = db.Database.SqlQuery<THANHVIEN_STRUCT>("Select * from THANHVIEN").ToList();
            this.Owner.Hide();
        }

        private void txtMaThanhVien_TextChanged(object sender, EventArgs e)
        {
            if (txtMaThanhVien.Text.Length >= 8 | string.IsNullOrWhiteSpace(txtMaThanhVien.Text))
            {
                // Properties.Resources.del_48_hot; cái này là địa chỉ hình ảnh mà mình đã thêm nó vào trong resource
                // e biết kiểm tra ảnh trong Properties.Resource chưa?
                picMaTV.BackgroundImage = Properties.Resources.del_48_hot;
            }
            else
            {
                picMaTV.BackgroundImage = null;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Owner.Enabled = true;
            this.Owner.Show();
            this.Dispose();
        }
    }
}
