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
    public partial class frmQuanLyLichChieu : Form
    {
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
    }
}
