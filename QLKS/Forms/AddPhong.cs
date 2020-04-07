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
    public partial class AddPhong : Form
    {
        public AddPhong()
        {
            InitializeComponent();
        }
       
        private void AddPhong_Load(object sender, EventArgs e)
        {
            txtDonGia.Enabled = true;
            txtDonGia.Text = "0";
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaPhong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPhong.Focus();
                return;
            }
            if (txtTenPhong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPhong.Focus();
                return;
            }

            sql = "SELECT MaPhong FROM tblPhong WHERE MaPhong=N'" + txtMaPhong.Text.Trim() + "'";
            DataTable tblPhong = ThucThiSQL.Docbang(sql);
            if (tblPhong.Rows.Count > 0)
            {
                MessageBox.Show("Mã phòng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPhong.Focus();
                txtMaPhong.Text = "";
                return;
            }

            sql = "INSERT INTO tblPhong(MaPhong,TenPhong,Dongia) VALUES(N'" +
                txtMaPhong.Text.Trim() + "',N'" + txtTenPhong.Text.Trim() + "'," +
                txtDonGia.Text.Trim() + ")";
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
