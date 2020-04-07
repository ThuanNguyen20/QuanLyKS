using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ThucThiSQL.Ketnoi();
        }

        private void mnuPhong_Click(object sender, EventArgs e)
        {
            Forms.Phong f = new Forms.Phong();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();

        }
    }
}
