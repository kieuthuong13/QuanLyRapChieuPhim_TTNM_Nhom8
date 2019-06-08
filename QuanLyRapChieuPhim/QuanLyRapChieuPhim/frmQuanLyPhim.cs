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
    public partial class frmQuanLyPhim : Form
    {
        public frmQuanLyPhim()
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

        private void frmQuanLyPhim_Load(object sender, EventArgs e)
        {

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
    }
}
