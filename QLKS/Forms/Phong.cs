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
    public partial class Phong : Form
    {
        public Phong()
        {
            InitializeComponent();
        }
        DataTable tblPhong;
        private void Phong_Load(object sender, EventArgs e)
        {
            HienThi_Luoi();
        }
        private void HienThi_Luoi()
        {
            string sql;
            sql = "SELECT MaPhong,TenPhong, DonGia FROM tblPhong";
            tblPhong = ThucThiSQL.Docbang(sql);
            DataGridView.DataSource = tblPhong;
            DataGridView.Columns[0].HeaderText = "Mã Phong";
            DataGridView.Columns[1].HeaderText = "Tên Phong";
            DataGridView.Columns[2].HeaderText = "Don Gia";
            DataGridView.Columns[0].Width = 100;
            DataGridView.Columns[1].Width = 300;
            DataGridView.Columns[2].Width = 100;
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            DataGridView.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            tblPhong.Dispose();


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Forms.AddPhong f = new Forms.AddPhong();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (DataGridView.CurrentRow.Cells["MaPhong"].Value.ToString() == "")
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo");
                return;
            }
            Forms.UpdatePhong f = new Forms.UpdatePhong();
            f.StartPosition = FormStartPosition.CenterScreen;
            txtMaPhong.Text = DataGridView.CurrentRow.Cells["MaPhong"].Value.ToString();
            txtTenPhong.Text = DataGridView.CurrentRow.Cells["TenPhong"].Value.ToString();
            txtDonGia.Text = DataGridView.CurrentRow.Cells["Dongia"].Value.ToString();
            f.Show();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (DataGridView.CurrentRow.Cells["MaPhong"].Value.ToString() == "")
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo");
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblPhong WHERE MaPhong=N'" + DataGridView.CurrentRow.Cells["MaPhong"].Value.ToString() + "'";
                ThucThiSQL.RunSqlDel(sql);
                HienThi_Luoi();

            }

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPhong.Focus();
                return;
            }
            if (tblPhong.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            txtMaPhong.Text = DataGridView.CurrentRow.Cells["MaPhong"].Value.ToString();
            txtTenPhong.Text = DataGridView.CurrentRow.Cells["TenPhong"].Value.ToString();
            txtDonGia.Text = DataGridView.CurrentRow.Cells["DonGia"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            Phong_Load(sender, e);

        }

        

//        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (btnThem.Enabled == false)
//            {
//                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",
//MessageBoxButtons.OK, MessageBoxIcon.Information);
//                txtMaPhong.Focus();
//                return;
//            }
//            if (tblPhong.Rows.Count == 0)
//            {
//                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
//MessageBoxIcon.Information);
//                return;
//            }
//            txtMaPhong.Text = DataGridView.CurrentRow.Cells["MaPhong"].Value.ToString();
//            txtTenPhong.Text = DataGridView.CurrentRow.Cells["TenPhong"].Value.ToString();
//            txtDonGia.Text = DataGridView.CurrentRow.Cells["DonGia"].Value.ToString();

//            btnSua.Enabled = true;
//            btnXoa.Enabled = true;
            
//        }

        
    }
}
