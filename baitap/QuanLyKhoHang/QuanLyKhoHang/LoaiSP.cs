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
    public partial class LoaiSP : Form
    {
        public LoaiSP()
        {
            InitializeComponent();
        }

        private void LoaiSP_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@" Data Source=DESKTOP-H1LP27V;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            conn.Open();

            string sql = "select *from LoaiSP";
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(sql, conn);
            dap.Fill(ds);

            dgvLoaiSP.DataSource = ds.Tables[0];
            dgvLoaiSP.Refresh();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {


            SqlConnection conn = new SqlConnection(@" Data Source=DESKTOP-H1LP27V;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            try
            {

                conn.Open();

                string sql = "insert into LoaiSP Values(N'" + tbxMaLSP.Text + "','" + tbxTenLSP.Text + "')";


                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();



                MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@" Data Source=DESKTOP-H1LP27V;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            conn.Open();
            if (tbxMaLSP.Text != "")
            {
                string sql = "UPDATE LoaiSP SET MaLSP ='" + tbxMaLSP.Text + "', TenLoai ='" + tbxTenLSP.Text + "' WHERE MaLSP='" + tbxMaLSP.Text + "'";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();



                MessageBox.Show("Cập Nhật Thành Công");

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


            string sql = "delete from LoaiSP where MaSP='" + tbxMaLSP.Text + "'";

            acc.excuteNonQuery(sql);


            try
            {
                tbxMaLSP.Clear();

                tbxTenLSP.Clear();

                
            }
            catch { }
            MessageBox.Show("Xoá thành công !");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            this.Hide();
            GiaoDien menu = new GiaoDien();
            menu.ShowDialog();
        }
    }
}
