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
    public partial class CTPhieuBH : Form
    {
        public CTPhieuBH()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            GiaoDien menu = new GiaoDien();
            menu.ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@" Data Source=DESKTOP-H1LP27V;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            try
            {

                conn.Open();

                string sql = "insert into PhieuBH Values(N'" + tbxMaPBH.Text + "','" + tbxMaSP.Text + "','" + tbxMaNV.Text + "','" + tbxNgayLap.Text + "',N'" + tbxTGBH.Text + "')";


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
            if (tbxMaPBH.Text != "")
            {
                string sql = "UPDATE PhieuBH SET MaPBH ='" + tbxMaPBH.Text + "', MaSP ='" + tbxMaSP.Text + "',MaNV ='" + tbxMaNV.Text + "',NgayLap ='" + tbxNgayLap.Text + "',TGBH ='" + tbxTGBH.Text + "' WHERE MaPBH='" + tbxMaPBH.Text + "'";

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


            string sql = "delete from PhieuBH where MaPX='" + tbxMaPBH.Text + "'";

            acc.excuteNonQuery(sql);


            try
            {
                tbxMaPBH.Clear();
                tbxMaSP.Clear();

                tbxMaNV.Clear();
                tbxNgayLap.Clear();
                tbxTGBH.Clear();
                
            }
            catch { }
            MessageBox.Show("Xoá thành công !");
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            GiaoDien menu = new GiaoDien();
            menu.ShowDialog();
        }

        private void CTPhieuBH_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@" Data Source=DESKTOP-H1LP27V;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            conn.Open();

            string sql = "select *from PhieuBH";
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(sql, conn);
            dap.Fill(ds);

            dgvPhieuBH.DataSource = ds.Tables[0];
            dgvPhieuBH.Refresh();
        }
    }
}
