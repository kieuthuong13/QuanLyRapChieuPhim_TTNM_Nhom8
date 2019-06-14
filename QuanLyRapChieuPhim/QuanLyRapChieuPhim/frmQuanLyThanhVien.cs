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
            cbxGioiTinh.Focus();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //hỏi lại có chắc chắn muốn xóa hay không
            if (DialogResult.OK == MessageBox.Show("Xóa bản ghi hiện tại sẽ làm thay đổi hoặc xóa các bản ghi liên kết!\nBạn có muốn tiếp tục không?"
                , "Cảnh báo xóa!", MessageBoxButtons.OKCancel))
            {
                db.Database.ExecuteSqlCommand("DELETE THANHVIEN WHERE MaThanhVien = " + txtMaThanhVien.Text);
                db.SaveChanges();
                MessageBox.Show("Xóa bản ghi thành công!");
            }
        }

        private void dgvThanhVien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvThanhVien.Rows[e.RowIndex].Cells["MaThanhVien"].Value != null)
                {
                    txtMaThanhVien.Text = dgvThanhVien.Rows[e.RowIndex].Cells["MaThanhVien"].Value.ToString();
                }
                if (dgvThanhVien.Rows[e.RowIndex].Cells["HoTen"].Value != null)
                {
                    txtHoTen.Text = dgvThanhVien.Rows[e.RowIndex].Cells["HoTen"].Value.ToString();
                }
                if (dgvThanhVien.Rows[e.RowIndex].Cells["GioiTinh"].Value != null)
                {
                    cbxGioiTinh.Text = dgvThanhVien.Rows[e.RowIndex].Cells["GioiTinh"].Value.ToString();
                }
                if (dgvThanhVien.Rows[e.RowIndex].Cells["DiaChi"].Value != null)
                {
                    txtDiaChi.Text = dgvThanhVien.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
                }
                if (dgvThanhVien.Rows[e.RowIndex].Cells["Email"].Value != null)
                {
                    txtEmail.Text = dgvThanhVien.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                }
                if (dgvThanhVien.Rows[e.RowIndex].Cells["SDT"].Value != null)
                {
                    txtSDT.Text = dgvThanhVien.Rows[e.RowIndex].Cells["SDT"].Value.ToString();
                }
                if (dgvThanhVien.Rows[e.RowIndex].Cells["TenDangNhap"].Value != null)
                {
                    txtTenDangNhap.Text = dgvThanhVien.Rows[e.RowIndex].Cells["TenDangNhap"].Value.ToString();
                }
                if (dgvThanhVien.Rows[e.RowIndex].Cells["MatKhau"].Value != null)
                {
                    txtMatKhau.Text = dgvThanhVien.Rows[e.RowIndex].Cells["MatKhau"].Value.ToString();
                }
                if (dgvThanhVien.Rows[e.RowIndex].Cells["GhiChu"].Value != null)
                {
                    rtbGhiChu.Text = dgvThanhVien.Rows[e.RowIndex].Cells["GhiChu"].Value.ToString();
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
                THANHVIEN p = new THANHVIEN();
                p.MaThanhVien = int.Parse(txtMaThanhVien.Text);
                p.HoTen = txtHoTen.Text;
                p.GioiTinh = cbxGioiTinh.Text;
                p.DiaChi = txtDiaChi.Text;
                p.Email = txtEmail.Text;
                p.SDT = txtSDT.Text;
                p.TenDangNhap = txtTenDangNhap.Text;
                p.MatKhau = txtMatKhau.Text;
                p.GhiChu = rtbGhiChu.Text;

                db.THANHVIENs.AddOrUpdate(p);

                db.SaveChanges();
                MessageBox.Show("Thêm dữ liệu thành công!");
            }
            catch (Exception)
            {
                MessageBox.Show("Một hoặc nhiều thông tin đang để trống!\nXin hãy kiểm tra lại");
                return;
            }
        }

        private void txtMaThanhVien_TextChanged_1(object sender, EventArgs e)
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

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if (txtSDT.Text.Length == 10 | string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                // Properties.Resources.del_48_hot; cái này là địa chỉ hình ảnh mà mình đã thêm nó vào trong resource
                // e biết kiểm tra ảnh trong Properties.Resource chưa?
                picSDT.BackgroundImage = Properties.Resources.del_48_hot;
            }
            else
            {
                picSDT.BackgroundImage = null;
            }
        }
    }
}
