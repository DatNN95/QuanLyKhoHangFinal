using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace QuanLyKhoHang
{
    public partial class SanPham : Form
    {
        public SanPham()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
           
            SqlConnection conn = new SqlConnection(@" Data Source=DESKTOP-H1LP27V;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            try
            {
                

                conn.Open();

                string sql = "insert into SanPham Values(N'" + tbxMaSP.Text + "','" + tbxTenSP.Text + "','" + tbxMaLSP.Text + "','" + tbxMaHSX.Text + "','" + tbxGiaBan.Text + "',N'" + tbxBaoHanh.Text + "',N'" + tbxTinhNang.Text + "')";


                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();



                MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SanPham_Load(sender, e);



            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }



        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            GiaoDien menu = new GiaoDien();
            menu.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(@" Data Source=DESKTOP-H1LP27V;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            conn.Open();
            if (tbxMaSP.Text != "")
            {
                string sql = "UPDATE SanPham SET MaSP ='" + tbxMaSP.Text + "', TenSP ='" + tbxTenSP.Text + "',MaLSP ='" + tbxMaLSP.Text + "',MaHSX ='" + tbxMaHSX.Text + "',Gia ='" + tbxGiaBan.Text + "',BaoHanh ='" + tbxBaoHanh.Text + "',TinhNang ='" + tbxTinhNang.Text + "' WHERE MaSP='" + tbxMaSP.Text + "'";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();



                MessageBox.Show("Cập Nhật Thành Công");
                SanPham_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Nhập sai mã sản phẩm!", "Thông báo");
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@" Data Source=DESKTOP-H1LP27V;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            accessData acc = new accessData();
            
            
            string sql = "delete from SanPham where MaSP='" + tbxMaSP.Text + "'";

            acc.excuteNonQuery(sql);


            try
            {
                tbxMaSP.Clear();
                tbxTenSP.Clear();
                tbxMaLSP.Clear();
                tbxMaHSX.Clear();
                tbxGiaBan.Clear();
                tbxBaoHanh.Clear();
                tbxTinhNang.Clear();
            }
            catch { }
            MessageBox.Show("Xoá thành công !");
            SanPham_Load(sender, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@" Data Source=DESKTOP-H1LP27V;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            conn.Open();

            string sql = "select *from SanPham";
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(sql, conn);
            dap.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Refresh();

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            
        }
      
        private void btnRefresh_Click(object sender, EventArgs e)
        {
           
        }
    }
}
