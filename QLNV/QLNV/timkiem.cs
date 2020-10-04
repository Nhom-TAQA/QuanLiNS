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
using System.Diagnostics;
using System.IO;

namespace QLNV
{
    public partial class timkiem : Form
    {
        public timkiem()
        {
            InitializeComponent();
        }
        string chuoiketnoi = @"Data Source = .\SQLEXPRESS; Initial Catalog = QL_NV; Integrated Security = True";
        SqlConnection conn;
        private void button1_Click(object sender, EventArgs e)
        {
            using ( conn = new SqlConnection(chuoiketnoi))
            {
                try
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        loadAll();
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        subsql = " MANV =" + textBox1.Text;
                    }
                    if(comboBox1.SelectedIndex == 2)
                    {
                        subsql = " HOVN like N'%" + textBox1.Text + "%'";
                    }
                    if (comboBox1.SelectedIndex == 3)
                    {
                        subsql = " NGAYSINH like N'%" + textBox1.Text + "%'";
                    }
                    if (comboBox1.SelectedIndex == 4)
                    {
                        subsql = " GT = " + textBox1.Text ;
                    }
                    if (comboBox1.SelectedIndex == 5)
                    {
                        subsql = " LUONG like N'%" + textBox1.Text + "%'";
                    }
                    if (comboBox1.SelectedIndex == 6)
                    {
                        subsql = " MAPHONG = " + textBox1.Text ;
                    }
                    if (comboBox1.SelectedIndex == 7)
                    {
                        subsql = " SDT like N'%" + textBox1.Text + "%'";
                    }
                    if (comboBox1.SelectedIndex == 8)
                    {
                        subsql = " EMAIL like N'%" + textBox1.Text + "%'";
                    }
                    loadSearch();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void timkiem_Load(object sender, EventArgs e)
        {
            string[] dt = { "Tất cả" ,"Mã nhân viên", "Tên nhân viên", "Ngày sinh", "Giới tính (Nam:1/Nữ:0)", "Lương", "Mã phòng", "Sỗ điện thoại", "Email" };
            try
            {
                foreach (string x in dt)
                {
                    comboBox1.DataSource = dt;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            loadAll();
        }
        private void loadAll()
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
        string subsql="";
        private void loadSearch()
        {
            conn = new SqlConnection(chuoiketnoi);
            try
            {
                conn.Open();
                string sql = "select * from NHANVIEN where";  // lay het du lieu trong bang
                sql += subsql;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
