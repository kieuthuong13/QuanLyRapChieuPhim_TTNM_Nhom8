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
    public partial class frmQuanLyPhongChieu : Form
    {
        public frmQuanLyPhongChieu()
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
        
    }
}
