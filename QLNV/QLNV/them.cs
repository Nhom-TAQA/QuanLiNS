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
    public partial class them : Form
    {
        public them()
        {
            InitializeComponent();
        }
        string chuoiketnoi = @"Data Source = .\SQLEXPRESS; Initial Catalog = QL_NV; Integrated Security = True";
        SqlConnection conn;
        private void load()
        {
            conn = new SqlConnection(chuoiketnoi);
            try
            {
                conn.Open();
                string sql = "select * from NHANVIEN";  // lay het du lieu trong bang
                SqlCommand com = new SqlCommand(sql, conn); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dt);  // đổ dữ liệu vào kho
                conn.Close();  // đóng kết nối
                dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi ket noi: " + ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)// reset
        {
            tbmanv.Clear();
            tbtennv.Clear();
            tbemail.Clear();
            tbgioitinh.Clear();
            tbmaphong.Clear();
            tbngaysinh.Clear();
            tbsdt.Clear();
            tbtienluong.Clear();
            button1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbtennv.Text != null && tbngaysinh.Text != null && tbgioitinh.Text != null && tbtienluong.Text != null &&
                    tbmaphong.Text != null && tbsdt.Text != null && tbemail.Text != null)
                {
                    SqlConnection conn = new SqlConnection(chuoiketnoi);
                    conn.Open();
                    string sql = "insert into NHANVIEN(HOVN, NGAYSINH,GT,LUONG, MAPHONG, SDT, EMAIL) values('"
                    + tbtennv.Text + "','" + tbngaysinh.Text + "','" + tbgioitinh.Text + "','" + tbtienluong.Text + "','"
                    + tbmaphong.Text + "','" + tbsdt.Text + "','" + tbemail.Text + "')";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    int kq = (int)cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Them Thanh cong");
                        load();
                    }
                    else
                    {
                        MessageBox.Show("them that bai");
                        conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("nhap chua du thong tin");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi:" + ex.Message);
            }
        }

        private void them_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
