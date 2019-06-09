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
    public partial class frmQuanLyPhongChieu : Form
    {
        QuanLyRapPhim db = new QuanLyRapPhim();


        public frmQuanLyPhongChieu()
        {
            InitializeComponent();
            this.MinimumSize = new Size(1080, 710);
        }

        #region MY FUNCTION
        public void Clear()
        {
            txtMaPhong.Clear();
            txtTenPhong.Clear();
            txtLoaiPhong.Clear();
            txtSoGhe.Clear();
            txtThietBi.Clear();
            txtTinhTrang.Clear();
            txtDienTich.Clear();
            rtbGhiChu.Clear();
        }
        #endregion

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Owner.Enabled = true;
            this.Owner.Show();
            this.Dispose();
        }

        private void txtMaPhong_TextChanged(object sender, EventArgs e)
        {
            if (txtMaPhong.Text.Length >= 8 | string.IsNullOrWhiteSpace(txtMaPhong.Text))
            {
                // Properties.Resources.del_48_hot; cái này là địa chỉ hình ảnh mà mình đã thêm nó vào trong resource
                // e biết kiểm tra ảnh trong Properties.Resource chưa?
                picMaPhong.BackgroundImage = Properties.Resources.del_48_hot;
            }
            else
            {
                picMaPhong.BackgroundImage = null;
            }
        }

        #region MY STRUCT - CLASS
        [Table("PHONGCHIEU")]
        public partial class PHONGCHIEU_STRUCT
        {

            [Key]
            public int MaPhongChieu { get; set; }

            [StringLength(100)]
            public string TenPhongChieu { get; set; }

            public int? MaLoai { get; set; }

            [StringLength(100)]
            public string TenLoai { get; set; }

            public int? SoGhe { get; set; }

            [StringLength(100)]
            public string ThietBi { get; set; }

            [StringLength(100)]
            public string TinhTrang { get; set; }

            [StringLength(100)]
            public string DienTich { get; set; }

            [StringLength(100)]
            public string GhiChu { get; set; }

        }
        #endregion

        private void frmQuanLyPhongChieu_Load(object sender, EventArgs e)
        {
            dgvPhongChieu.DataSource = db.Database.SqlQuery<PHONGCHIEU_STRUCT>("Select * from PHONGCHIEU").ToList();
            this.Owner.Hide();
        }

        private void dgvPhongChieu_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPhongChieu.Rows[e.RowIndex].Cells["MaPhongChieu"].Value != null)
                {
                    txtMaPhong.Text = dgvPhongChieu.Rows[e.RowIndex].Cells["MaPhongChieu"].Value.ToString();
                }
                if (dgvPhongChieu.Rows[e.RowIndex].Cells["TenPhongChieu"].Value != null)
                {
                    txtTenPhong.Text = dgvPhongChieu.Rows[e.RowIndex].Cells["TenPhongChieu"].Value.ToString();
                }
                if (dgvPhongChieu.Rows[e.RowIndex].Cells["MaLoai"].Value != null)
                {
                    txtLoaiPhong.Text = dgvPhongChieu.Rows[e.RowIndex].Cells["MaLoai"].Value.ToString();
                }
                if (dgvPhongChieu.Rows[e.RowIndex].Cells["SoGhe"].Value != null)
                {
                    txtSoGhe.Text = dgvPhongChieu.Rows[e.RowIndex].Cells["SoGhe"].Value.ToString();
                }
                if (dgvPhongChieu.Rows[e.RowIndex].Cells["ThietBi"].Value != null)
                {
                    txtThietBi.Text = dgvPhongChieu.Rows[e.RowIndex].Cells["ThietBi"].Value.ToString();
                }
                if (dgvPhongChieu.Rows[e.RowIndex].Cells["TinhTrang"].Value != null)
                {
                    txtTinhTrang.Text = dgvPhongChieu.Rows[e.RowIndex].Cells["TinhTrang"].Value.ToString();
                }
                if (dgvPhongChieu.Rows[e.RowIndex].Cells["DienTich"].Value != null)
                {
                    txtDienTich.Text = dgvPhongChieu.Rows[e.RowIndex].Cells["DienTich"].Value.ToString();
                }
                if (dgvPhongChieu.Rows[e.RowIndex].Cells["GhiChu"].Value != null)
                {
                    rtbGhiChu.Text = dgvPhongChieu.Rows[e.RowIndex].Cells["GhiChu"].Value.ToString();
                }
            }
            catch (Exception)
            {
                Clear();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                PHONGCHIEU p = new PHONGCHIEU();
                p.MaPhongChieu = int.Parse(txtMaPhong.Text);
                p.TenPhongChieu = txtTenPhong.Text;
                p.MaLoai = int.Parse(txtLoaiPhong.Text);
                p.SoGhe = int.Parse(txtSoGhe.Text);
                p.ThietBi = txtThietBi.Text;
                p.TinhTrang = txtTinhTrang.Text;
                p.DienTich = txtDienTich.Text;
                p.GhiChu = rtbGhiChu.Text;

                db.PHONGCHIEUx.AddOrUpdate(p);

                db.SaveChanges();
                MessageBox.Show("Thêm dữ liệu thành công!");
            }
            catch (Exception)
            {
                MessageBox.Show("Một hoặc nhiều thông tin đang để trống!\nXin hãy kiểm tra lại");
                return;
            }
        }
        
    }
}
