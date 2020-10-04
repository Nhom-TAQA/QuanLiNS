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
    public partial class nhanvien : Form
    {
        public nhanvien()
        {
            InitializeComponent();
        }

        private void nhanvien_Load(object sender, EventArgs e)
        {

            load();

        }
        string chuoiketnoi = @"Data Source = .\SQLEXPRESS; Initial Catalog = QL_NV; Integrated Security = True";
        SqlConnection conn;
        private void load()
        {
            conn = new SqlConnection(chuoiketnoi);
            try
            {
                //this.nHANVIENTableAdapter.Fill(this.qL_NVDataSet_nhanvien.NHANVIEN);
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
            catch(Exception ex)
            {
                MessageBox.Show("loi ket noi: " + ex.Message);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            them them1 = new them();
            them1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.Rows[e.RowIndex];
                tbmanv.Text = dr.Cells[0].Value.ToString();
                tbtennv.Text = dr.Cells[1].Value.ToString();
                tbngaysinh.Text = dr.Cells[2].Value.ToString(); // Convert.ToDateTime(dr.Cells[2].Value.ToString());
                tbgioitinh.Text = dr.Cells[3].Value.ToString();
                tbtienluong.Text = dr.Cells[4].Value.ToString();
                tbmaphong.Text = dr.Cells[5].Value.ToString();
                tbsdt.Text = dr.Cells[6].Value.ToString();
                tbemail.Text = dr.Cells[7].Value.ToString();
            }catch( Exception ex)
            {
                MessageBox.Show("loi:" + ex.Message);
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(chuoiketnoi);
            try
            {
                conn.Open();
                string sql = "update NHANVIEN set HOVN=N'"+ tbtennv.Text +"',NGAYSINH='" +tbngaysinh.Text +"',GT='"+ tbgioitinh.Text + "', LUONG='" + tbtienluong.Text
                    +"',MAPHONG='"+tbmaphong.Text +"',SDT='"+ tbsdt.Text + "', EMAIL='"+ tbemail.Text + "'where MANV='"+ tbmanv.Text+"'";
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
            } catch(Exception ex)
            {
                MessageBox.Show("loi: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = MessageBox.Show("Bạn có chắc chắn xóa!!","thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(thongbao ==DialogResult.OK)
            {
                SqlConnection conn = new SqlConnection(chuoiketnoi);
                try
                {
                    conn.Open();
                    string sql = "delete from NHANVIEN where MANV ='" + tbmanv.Text + "'";
                    SqlCommand cmd = new SqlCommand(sql,conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("XÓA THÀNH CÔNG!");
                    load();
                    conn.Close();
                }catch(Exception ex)
                {
                    MessageBox.Show("lỗi kết nối tới CSDL! " + ex.Message);
                }
            }    
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timkiem tk1 = new timkiem();
            tk1.ShowDialog();
        }
    }
}
