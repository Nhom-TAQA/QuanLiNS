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
    public partial class admin : Form
    {
        public admin()
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

                string sql = "select * from ADMIN";  // lay het du lieu trong bang
                SqlCommand com = new SqlCommand(sql, conn); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dt);  // đổ dữ liệu vào kho
                conn.Close();  // đóng kết nối
                dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
                conn.Close();
                button2.Enabled = false;
                tbtendangnhap.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi ket noi: " + ex.Message);
            }
        }

        private void admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qL_NVDataSet1.ADMIN' table. You can move, or remove it, as needed.
            this.aDMINTableAdapter.Fill(this.qL_NVDataSet1.ADMIN);
            load();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.Rows[e.RowIndex];
                tbmaqtv.Text = dr.Cells[0].Value.ToString();
                tbtendangnhap.Text = dr.Cells[1].Value.ToString();
                tbmatkhau.Text = dr.Cells[2].Value.ToString(); 
                tbcapdo.Text = dr.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi:" + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)// sửa
        {
            SqlConnection conn = new SqlConnection(chuoiketnoi);
            try
            {
                //load();
                conn.Open();
                string sql = "update ADMIN set PASSWORD='" + tbmatkhau.Text + "',CAPDO='" + tbcapdo.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int kq = (int)cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Sửa Thành Công");
                    load();
                }
                else
                {
                    MessageBox.Show("Sửa Thất bại");
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)// thêm
        {   
            tbmaqtv.Clear();
            tbmaqtv.Text = "";
            tbmaqtv.Enabled = true;
            tbtendangnhap.Clear();
            tbmatkhau.Clear();
            tbcapdo.Clear();
            tbtendangnhap.Enabled = true;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbmaqtv.Enabled = false;
            try
            {
                if (tbmaqtv.Text != null && tbtendangnhap.Text != null && tbmatkhau.Text != null && tbcapdo.Text != null)
                {
                    SqlConnection conn = new SqlConnection(chuoiketnoi);
                    conn.Open();
                    string sql = "insert into ADMIN(MA_ADMIN,USERNAME, PASSWORD, CAPDO) values('"
                    + Convert.ToInt32(tbmaqtv.Text) + "','" + tbtendangnhap.Text + "','" + tbmatkhau.Text + "','" + Convert.ToInt32( tbcapdo.Text) + "')";
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

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = MessageBox.Show("Bạn có chắc chắn xóa!!", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (thongbao == DialogResult.OK)
            {
                SqlConnection conn = new SqlConnection(chuoiketnoi);
                try
                {
                    conn.Open();
                    string sql = "delete from ADMIN where MA_ADMIN ='" + tbmaqtv.Text + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("XÓA THÀNH CÔNG!");
                    load();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("lỗi kết nối tới CSDL! " + ex.Message);
                }
            }
        }
    }
    
}
