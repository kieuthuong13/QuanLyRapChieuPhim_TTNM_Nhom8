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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.MinimumSize = new Size(1150, 700);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmMain val = new frmMain();
            val.Owner = this;
            val.Show();
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LbThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
