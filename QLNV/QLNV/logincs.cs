using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace QLNV
{
    public partial class logincs : Form
    {
        public static string ID_USER = "";
        public static string USERNAME = "";
        public static string LEVEL = "";
        Dataconnection da;
        public logincs()
        {
            InitializeComponent();
            da = new Dataconnection();
        }
        SqlConnection conn;
        private void button1_Click(object sender, EventArgs e)
        {
            conn = da.GetSqlConnection();
            string id = "";
            string level = "";
            string username = "";
            try
            {
                using (conn = da.GetSqlConnection())
                {
                    conn.Open();
                    string sql = " SELECT CAPDO , MA_ADMIN , USERNAME FROM ADMIN WHERE USERNAME = '" + textBox1.Text + "' and PASSWORD = '" + textBox2.Text +"'";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            id = dr["MA_ADMIN"].ToString();
                            ID_USER = id;
                            username = dr["USERNAME"].ToString();
                            USERNAME = username;
                            level = dr["CAPDO"].ToString();
                            LEVEL = level;
                        }
                    }

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        this.Hide();
                        Form1 fr1 = new Form1();
                        fr1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Thông tin đăng nhập sai");
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
