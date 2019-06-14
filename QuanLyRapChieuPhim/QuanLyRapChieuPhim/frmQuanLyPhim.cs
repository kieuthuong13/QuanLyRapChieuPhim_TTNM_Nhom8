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
        #region MY PARAMETER
        QuanLyRapPhim db = new QuanLyRapPhim();
        List<string> lQuocGia = new List<string>();
        List<string> lTheLoai = new List<string>();
        #endregion

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
            txtQuocGia.Clear();
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
        public  class PHIM_STRUCT
        {
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

            [StringLength(100)]
            public string TenLoai { get; set; }
        }
        #endregion

        private void frmQuanLyPhim_Load(object sender, EventArgs e)
        {
            btnLamMoi_Click(sender, e);
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
                Clear();
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
                if (dgvPhim.Rows[e.RowIndex].Cells["MaLoai"].Value != null)
                {
                    txtTheLoai.Text = dgvPhim.Rows[e.RowIndex].Cells["MaLoai"].Value.ToString();
                }
                if (dgvPhim.Rows[e.RowIndex].Cells["NamSX"].Value != null)
                {
                    dtpNanSX.Value = DateTime.Parse(dgvPhim.Rows[e.RowIndex].Cells["NamSX"].Value.ToString());
                }
                if (dgvPhim.Rows[e.RowIndex].Cells["QuocGia"].Value != null)
                {
                    txtQuocGia.Text = dgvPhim.Rows[e.RowIndex].Cells["QuocGia"].Value.ToString();
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
                PHIM p = new PHIM();
                p.MaPhim = int.Parse(txtMaPhim.Text);
                p.TenPhim = txtTen.Text;
                p.DaoDien = txtDaoDien.Text;
                p.DienVien = txtDienVien.Text;
                p.MaLoai = int.Parse(txtTheLoai.Text);
                p.NamSX = dtpNanSX.Value;
                p.QuocGia = txtQuocGia.Text;
                p.ThoiLuong = int.Parse(txtThoiLuong.Text);
                p.Poster = txtPos.Text;
                p.Trailer = txtTrailer.Text;
                p.NoiDung = rtbNoiDung.Text;

                db.PHIMs.AddOrUpdate(p);

                db.SaveChanges();
                MessageBox.Show("Thêm dữ liệu thành công!");
            }
            catch (Exception)
            {
                MessageBox.Show("Một hoặc nhiều thông tin đang để trống!\nXin hãy kiểm tra lại");
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //hỏi lại có chắc chắn muốn xóa hay không
            if (DialogResult.OK == MessageBox.Show("Xóa bản ghi hiện tại sẽ làm thay đổi hoặc xóa các bản ghi liên kết!\nBạn có muốn tiếp tục không?"
                , "Cảnh báo xóa!", MessageBoxButtons.OKCancel))
            {
                db.Database.ExecuteSqlCommand("DELETE PHIM WHERE MaPhim = " + txtMaPhim.Text);
                db.SaveChanges();
                MessageBox.Show("Xóa bản ghi thành công!");
                btnLamMoi_Click(sender, e);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvPhim.DataSource = db.Database.SqlQuery<PHIM_STRUCT>("SELECT p.MaPhim, p.TenPhim, p.DaoDien, p.DienVien, l.TenLoai, p.NoiDung, p.NamSX, p.QuocGia, p.ThoiLuong, p.Poster, p.Trailer FROM PHIM p, LOAIPHIM l WHERE p.MaLoai = l.MaLoai").Cast<PHIM_STRUCT>().ToList();
            lTheLoai = db.Database.SqlQuery<string>("SELECT TenLoai FROM LOAIPHIM").ToList();
            lQuocGia = db.Database.SqlQuery<string>("SELECT QuocGia FROM PHIM").ToList();
            for (int i = 0; i < lTheLoai.Count; i++)
            {
                for (int j = lTheLoai.Count - 1; j > i; j--)
                {
                    if (lTheLoai[i] == lTheLoai[j])
                    {
                        lTheLoai.RemoveAt(j);
                    }
                }
            }

            for (int i = 0; i < lQuocGia.Count; i++)
            {
                for (int j = lQuocGia.Count - 1; j > i; j--)
                {
                    if (lQuocGia[i] == lQuocGia[j])
                    {
                        lQuocGia.RemoveAt(j);
                    }
                }
            }
        }

        private void cbbThongKeMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loaiThongKe = cbbThongKeMuc.Text;
            int i = 0;
            switch (loaiThongKe)
            {
                case "Quốc gia":
                    cbbNoiDung.Items.Clear();
                    for (i = 0; i < lQuocGia.Count; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(lQuocGia[i]))
                        {
                            cbbNoiDung.Items.Add(lQuocGia[i]);
                        }
                    }
                    break;

                case "Thể loại":
                    cbbNoiDung.Items.Clear();
                    for (i = 0; i < lTheLoai.Count; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(lTheLoai[i]))
                        {
                            cbbNoiDung.Items.Add(lTheLoai[i]);
                        }
                    }
                    break;

                default:
                    return;
            }
            cbbNoiDung.Text = null;
        }

        private void cbbNoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cbbNoiDung.Text))
            {
                int i = 0;
                dgvPhim.DataSource = null;
                dgvPhim.Refresh();
                switch (cbbThongKeMuc.Text)
                {
                    case "Quốc gia":
                        dgvPhim.DataSource = db.Database.SqlQuery<PHIM_STRUCT>("SELECT p.MaPhim, p.TenPhim, p.DaoDien, p.DienVien, l.TenLoai, p.NoiDung, p.NamSX, p.QuocGia, p.ThoiLuong, p.Poster, p.Trailer FROM PHIM p, LOAIPHIM l WHERE p.MaLoai = l.MaLoai AND p.QuocGia = N'" + cbbNoiDung.Text + "'").Cast<PHIM_STRUCT>().ToList();
                        break;

                    case "Thể loại":
                        dgvPhim.DataSource = db.Database.SqlQuery<PHIM_STRUCT>("SELECT p.MaPhim, p.TenPhim, p.DaoDien, p.DienVien, l.TenLoai, p.NoiDung, p.NamSX, p.QuocGia, p.ThoiLuong, p.Poster, p.Trailer FROM PHIM p, LOAIPHIM l WHERE p.MaLoai = l.MaLoai AND l.TenLoai = N'" + cbbNoiDung.Text + "'").Cast<PHIM_STRUCT>().ToList();
                        break;

                    default:
                        return;
                }
            }
        }
    }
}
