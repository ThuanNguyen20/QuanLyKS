using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading.Tasks;


namespace QLKS
{
    class ThucThiSQL
    {
        public static SqlConnection Conn;
        public static string connString = @"Data Source=.;Initial Catalog=QuanlyKS;Integrated Security=True";
        public static void Ketnoi()
        {
            Conn = new SqlConnection();
            Conn.ConnectionString = connString;
            Conn.Open();
        }
        public static void Dongketnoi()
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
                Conn.Dispose();
                Conn = null;
            }

        }
        public static DataTable Docbang(String sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter();
            Mydata.SelectCommand = new SqlCommand();
            Mydata.SelectCommand.Connection = ThucThiSQL.Conn;
            Mydata.SelectCommand.CommandText = sql;
            DataTable table = new DataTable();
            Mydata.Fill(table);
            return table;

        }
        public static void RunSQL(string sql)
        {
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection = ThucThiSQL.Conn;
            cmd.CommandText = sql;
            
                cmd.ExecuteNonQuery();
           
            cmd.Dispose();
            cmd = null;

        }
        

        public static void RunSqlDel(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ThucThiSQL.Conn;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                MessageBox.Show("Dữ liệu đang được dùng, không thể xóa...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            cmd.Dispose();
            cmd = null;
        }
    }


    }
