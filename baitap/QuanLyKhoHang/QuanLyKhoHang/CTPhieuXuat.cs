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
    public partial class CTPhieuXuat : Form
    {
        public CTPhieuXuat()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            GiaoDien menu = new GiaoDien();
            menu.ShowDialog();
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

                string sql = "insert into PhieuXuat Values(N'" + tbxMaPX.Text + "','" + tbxMaSP.Text + "','" + tbxMaNV.Text + "','" + tbxNgayXuat.Text + "',N'" + tbxSoLuong.Text + "',N'" + tbxDonGia.Text + "')";


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
            if (tbxMaPX.Text != "")
            {
                string sql = "UPDATE PhieuXuat SET MaPN ='" + tbxMaPX.Text + "', MaSP ='" + tbxMaSP.Text + "',MaNV ='" + tbxMaNV.Text + "',NgayXuat ='" + tbxNgayXuat.Text + "'SoLuong ='" + tbxSoLuong.Text + "',DonGia ='" + tbxDonGia.Text + "' WHERE MaPX='" + tbxMaPX.Text + "'";

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


            string sql = "delete from PhieuXuat where MaPX='" + tbxMaPX.Text + "'";

            acc.excuteNonQuery(sql);


            try
            {
                tbxMaPX.Clear();
                tbxMaSP.Clear();
               
                tbxMaNV.Clear();
                tbxNgayXuat.Clear();
                tbxSoLuong.Clear();
                tbxDonGia.Clear();
            }
            catch { }
            MessageBox.Show("Xoá thành công !");
        }

        private void CTPhieuXuat_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@" Data Source=DESKTOP-H1LP27V;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            conn.Open();

            string sql = "select *from PhieuXuat";
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(sql, conn);
            dap.Fill(ds);

            dgvPhieuXuat.DataSource = ds.Tables[0];
            dgvPhieuXuat.Refresh();
        }
    }
}
