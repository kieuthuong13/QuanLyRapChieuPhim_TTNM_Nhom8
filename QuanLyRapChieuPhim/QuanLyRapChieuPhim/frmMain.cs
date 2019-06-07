using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.MinimumSize = new Size(1080, 710);
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin fm = new frmLogin();
            fm.Show();
            this.Hide();
        }

        private void picPhim_Click(object sender, EventArgs e)
        {
            frmQuanLyPhim val = new frmQuanLyPhim();
            val.Owner = this;
            val.Show();
        }

        private void picLichChieu_Click(object sender, EventArgs e)
        {
            frmQuanLyLichChieu val = new frmQuanLyLichChieu();
            val.Owner = this;
            val.Show();
        }

        private void picPhong_Click(object sender, EventArgs e)
        {
            frmQuanLyPhongChieu val = new frmQuanLyPhongChieu();
            val.Owner = this;
            val.Show();
        }

        private void picVe_Click(object sender, EventArgs e)
        {
            frmQuanLyBanVe val = new frmQuanLyBanVe();
            val.Owner = this;
            val.Show();
        }

        private void picThanhVien_Click(object sender, EventArgs e)
        {
            frmQuanLyThanhVien val = new frmQuanLyThanhVien();
            val.Owner = this;
            val.Show();
        }

        private void picDoiMK_Click(object sender, EventArgs e)
        {
            frmChanePasswordChangingForm val = new frmChanePasswordChangingForm();
            val.Owner = this;
            val.Show();
        }

        private void btnDX_Click(object sender, EventArgs e)
        {
            this.Owner.Enabled = true;
            this.Owner.Show();
            this.Dispose();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // viết thêm một đoạn ở đây là lúc bật form này thì sẽ tắt cái form đang login đi
            this.Owner.Hide();

        }
    }
}
