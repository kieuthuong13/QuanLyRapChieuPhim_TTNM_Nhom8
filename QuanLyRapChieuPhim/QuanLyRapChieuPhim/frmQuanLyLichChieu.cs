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
    public partial class frmQuanLyLichChieu : Form
    {
        QuanLyRapPhim db = new QuanLyRapPhim();

        public frmQuanLyLichChieu()
        {
            InitializeComponent();
            this.MinimumSize = new Size(1080, 710);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Owner.Enabled = true;
            this.Owner.Show();
            this.Dispose();
        }

        #region MY FUNCTION
        public void Clear()
        {
            //txtMaChieu.Clear();
            txtLoaiPhim.Clear();
            txtPhong.Clear();
            txtCa.Clear();
            rtbGhiChu.Clear();
        }
        #endregion

        #region My_STRUCT
        [Table("LICHCHIEU")]
        public partial class LICHCHIEU_STRUCT
        {
            [Key]
            //public int MaChieu { get; set; }


            public DateTime? TuNgay { get; set; }

            public DateTime? NgayKetThuc { get; set; }

            public int? MaPhim { get; set; }

            [StringLength(100)]
            public string TenPhim { get; set; }

            public int? MaPhongChieu { get; set; }

            [StringLength(100)]
            public string TenPhong { get; set; }

            [StringLength(100)]
            public string CaChieu { get; set; }

            [StringLength(100)]
            public string GhiChu { get; set; }

        }
        #endregion

        //private void txtMaChieu_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtMaChieu.Text.Length >= 8 | string.IsNullOrWhiteSpace(txtMaChieu.Text))
        //    {
        //        // Properties.Resources.del_48_hot; cái này là địa chỉ hình ảnh mà mình đã thêm nó vào trong resource
        //        // e biết kiểm tra ảnh trong Properties.Resource chưa?
        //        picMaLich.BackgroundImage = Properties.Resources.del_48_hot;
        //    }
        //    else
        //    {
        //        picMaLich.BackgroundImage = null;
        //    }
        //}

        private void frmQuanLyLichChieu_Load(object sender, EventArgs e)
        {
            dgvLichChieu.DataSource = db.Database.SqlQuery<LICHCHIEU_STRUCT>("Select * from LICHCHIEU").ToList();
            this.Owner.Hide();
        }

        private void dgvLichChieu_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (dgvLichChieu.Rows[e.RowIndex].Cells["MaChieu"].Value != null)
                //{
                //    txtMaChieu.Text = dgvLichChieu.Rows[e.RowIndex].Cells["MaChieu"].Value.ToString();
                //}
                if (dgvLichChieu.Rows[e.RowIndex].Cells["MaPhim"].Value != null)
                {
                    txtLoaiPhim.Text = dgvLichChieu.Rows[e.RowIndex].Cells["MaPhim"].Value.ToString();
                }
                if (dgvLichChieu.Rows[e.RowIndex].Cells["MaPhong"].Value != null)
                {
                    txtPhong.Text = dgvLichChieu.Rows[e.RowIndex].Cells["MaPhong"].Value.ToString();
                }
                if (dgvLichChieu.Rows[e.RowIndex].Cells["CaChieu"].Value != null)
                {
                    txtCa.Text = dgvLichChieu.Rows[e.RowIndex].Cells["CaChieu"].Value.ToString();
                }
                if (dgvLichChieu.Rows[e.RowIndex].Cells["TuNgay"].Value != null)
                {
                    dtpNgayNhap.Value = DateTime.Parse(dgvLichChieu.Rows[e.RowIndex].Cells["TuNgay"].Value.ToString());
                }
                if (dgvLichChieu.Rows[e.RowIndex].Cells["NgayKetThuc"].Value != null)
                {
                    dtpNgayKetThuc.Value = DateTime.Parse(dgvLichChieu.Rows[e.RowIndex].Cells["NgayKetThuc"].Value.ToString());
                }
                if (dgvLichChieu.Rows[e.RowIndex].Cells["GhiChu"].Value != null)
                {
                    rtbGhiChu.Text = dgvLichChieu.Rows[e.RowIndex].Cells["GhiChu"].Value.ToString();
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
                LICHCHIEU lc = new LICHCHIEU();
                lc.MaPhim = int.Parse(txtLoaiPhim.Text);
                lc.MaPhongChieu = int.Parse(txtPhong.Text);
                lc.CaChieu = txtCa.Text;
                lc.GhiChu = rtbGhiChu.Text;
                lc.CaChieu = txtCa.Text;
                lc.TuNgay = dtpNgayNhap.Value;
                lc.NgayKetThuc = dtpNgayKetThuc.Value;

                db.LICHCHIEUx.AddOrUpdate(lc);

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
