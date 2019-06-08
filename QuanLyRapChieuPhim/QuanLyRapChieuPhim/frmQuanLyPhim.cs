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
    public partial class frmQuanLyPhim : Form
    {
        QuanLyRapPhim db = new QuanLyRapPhim();

        #region MY FUNCTION
        public void Clear()
        {
            txtMaPhim.Clear();
            txtTen.Clear();
            txtDaoDien.Clear();
            txtDienVien.Clear();
            txtTheLoai.Clear();
            txtThoiLuong.Clear();
            txtPos.Clear();
            txtTrailer.Clear();
            rtbNoiDung.Clear();
        }
        #endregion

        public frmQuanLyPhim()
        {
            InitializeComponent();
            this.MinimumSize = new Size(1090, 710);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Owner.Enabled = true;
            this.Owner.Show();
            this.Dispose();
        }

        #region MY STRUCT - CLASS
        [Table("PHIM")]
        public  class PHIM_struct
        {
            [Key]
            public int MaPhim { get; set; }

            [StringLength(100)]
            public string TenPhim { get; set; }

            [StringLength(100)]
            public string DaoDien { get; set; }

            [StringLength(100)]
            public string DienVien { get; set; }

            [StringLength(100)]
            public string TenLoai { get; set; }

            [StringLength(100)]
            public string NamSX { get; set; }

            [StringLength(100)]
            public string QuocGia { get; set; }

            public int? ThoiLuong { get; set; }

            [StringLength(100)]
            public string Poster { get; set; }

            [StringLength(100)]
            public string Trailer { get; set; }

            [StringLength(100)]
            public string NoiDung { get; set; }
        }
        #endregion

        private void frmQuanLyPhim_Load(object sender, EventArgs e)
        {
            dgvPhim.DataSource = db.Database.SqlQuery<PHIM_struct>("Select * from PHIM").ToList();
            this.Owner.Hide();
        }

        private void txtMaPhim_TextChanged(object sender, EventArgs e)
        {
            if(txtMaPhim.Text.Length >=8 | string.IsNullOrWhiteSpace(txtMaPhim.Text))
            {
                // Properties.Resources.del_48_hot; cái này là địa chỉ hình ảnh mà mình đã thêm nó vào trong resource
                // e biết kiểm tra ảnh trong Properties.Resource chưa?
                picMaPhim.BackgroundImage = Properties.Resources.del_48_hot;
            }
            else
            {
                picMaPhim.BackgroundImage = null;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgvPhim_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPhim.Rows[e.RowIndex].Cells["MaPhim"].Value != null)
                {
                    txtMaPhim.Text = dgvPhim.Rows[e.RowIndex].Cells["MaPhim"].Value.ToString();
                }
                if (dgvPhim.Rows[e.RowIndex].Cells["TenPhim"].Value != null)
                {
                    txtTen.Text = dgvPhim.Rows[e.RowIndex].Cells["TenPhim"].Value.ToString();
                }
                if (dgvPhim.Rows[e.RowIndex].Cells["DaoDien"].Value != null)
                {
                    txtDaoDien.Text = dgvPhim.Rows[e.RowIndex].Cells["DaoDien"].Value.ToString();
                }
                if (dgvPhim.Rows[e.RowIndex].Cells["DienVien"].Value != null)
                {
                    txtDienVien.Text = dgvPhim.Rows[e.RowIndex].Cells["DienVien"].Value.ToString();
                }
                if (dgvPhim.Rows[e.RowIndex].Cells["TenLoai"].Value != null)
                {
                    txtTheLoai.Text = dgvPhim.Rows[e.RowIndex].Cells["TenLoai"].Value.ToString();
                }
                if (dgvPhim.Rows[e.RowIndex].Cells["NamSX"].Value != null)
                {
                    dtpNamSX.Value = DateTime.Parse(dgvPhim.Rows[e.RowIndex].Cells["NamSX"].Value.ToString());
                }
                if (dgvPhim.Rows[e.RowIndex].Cells["QuocGia"].Value != null)
                {
                    cbxQuocGia.Text = dgvPhim.Rows[e.RowIndex].Cells["QuocGia"].Value.ToString();
                }
                if (dgvPhim.Rows[e.RowIndex].Cells["ThoiLuong"].Value != null)
                {
                    txtThoiLuong.Text = dgvPhim.Rows[e.RowIndex].Cells["ThoiLuong"].Value.ToString();
                }
                if (dgvPhim.Rows[e.RowIndex].Cells["Poster"].Value != null)
                {
                    txtPos.Text = dgvPhim.Rows[e.RowIndex].Cells["Poster"].Value.ToString();
                }
                if (dgvPhim.Rows[e.RowIndex].Cells["Trailer"].Value != null)
                {
                    txtTrailer.Text = dgvPhim.Rows[e.RowIndex].Cells["Trailer"].Value.ToString();
                }
                if (dgvPhim.Rows[e.RowIndex].Cells["NoiDung"].Value != null)
                {
                    rtbNoiDung.Text = dgvPhim.Rows[e.RowIndex].Cells["NoiDung"].Value.ToString();
                }

            }
            catch(Exception)
            {
                Clear();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                PHIM_struct p = new PHIM_struct();
                p.MaPhim = int.Parse(txtMaPhim.Text);
                p.TenPhim = txtTen.Text;
                p.DaoDien = txtDaoDien.Text;
                p.DaoDien = txtDaoDien.Text;
                p.DienVien = txtDienVien.Text;
                p.TenLoai = txtTheLoai.Text;

                p.QuocGia = cbxQuocGia.Text;
                p.ThoiLuong = int.Parse(txtThoiLuong.Text);
                p.Poster = txtPos.Text;
                p.Trailer = txtTrailer.Text;
                p.NoiDung = rtbNoiDung.Text;

                //thêm hoặc update bản ghi của nhân viên

                db.PHIMs.AddOrUpdate();
                //db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[NHANVIEN] OFF");
                //lưu thay đổi
                db.SaveChanges();
                MessageBox.Show("Thêm dữ liệu nhân viên thành công!");

                //btnLamMoi_Click(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Một hoặc nhiều thông tin đang để trống!\nXin hãy kiểm tra lại");
                return;
            }
        }
    }
}
