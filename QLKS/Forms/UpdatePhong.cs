using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS.Forms
{
    public partial class UpdatePhong : Form
    {
        public UpdatePhong()
        {
            InitializeComponent();
        }

        private void UpdatePhong_Load(object sender, EventArgs e)
        {
            txtDonGia.Enabled = true;
            
            txtDonGia.Text = "0";
           

        }

        private void btnCapnhap_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTenPhong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPhong.Focus();
                return;
            }
            sql = "UPDATE tblPhong SET TenPhong=N'" + txtTenPhong.Text.Trim() + "' WHERE MaPhong=N'" + txtMaPhong.Text + "'";
            ThucThiSQL.RunSQL(sql);
            this.Close();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;

        }

    }
}
