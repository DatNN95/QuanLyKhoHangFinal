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
    public partial class CTPhieuNhap : Form
    {
        public CTPhieuNhap()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            GiaoDien menu = new GiaoDien();
            menu.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@" Data Source=DESKTOP-H1LP27V;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            try
            {

                conn.Open();

                string sql = "insert into PhieuNhap Values(N'" + tbxMaPN.Text + "','" + tbxMaSP.Text + "','" + tbxMaHSX.Text + "','" + tbxMaNV.Text + "','" + tbxNgayNhap.Text + "',N'" + tbxSoLuong.Text + "',N'" + tbxDonGia.Text + "')";


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
            if (tbxMaPN.Text != "")
            {
                string sql = "UPDATE PhieuNhap SET MaPN ='" + tbxMaPN.Text + "', MaSP ='" + tbxMaSP.Text + "',MaHSX ='" + tbxMaHSX.Text + "',MaNV ='" + tbxMaNV.Text + "',NgayNhap ='" + tbxNgayNhap.Text + "'SoLuong ='" + tbxSoLuong.Text + "',DonGia ='" + tbxDonGia.Text + "' WHERE MaPN='" + tbxMaPN.Text + "'";

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


            string sql = "delete from PhieuNhap where MaPN='" + tbxMaPN.Text + "'";

            acc.excuteNonQuery(sql);

            try
            {
                tbxMaPN.Clear();
                tbxMaSP.Clear();
                tbxMaHSX.Clear();
                tbxMaNV.Clear();
                tbxNgayNhap.Clear();
                tbxSoLuong.Clear();
                tbxDonGia.Clear();
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

        private void CTPhieuNhap_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@" Data Source=DESKTOP-H1LP27V;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            conn.Open();

            string sql = "select *from PhieuNhap";
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(sql, conn);
            dap.Fill(ds);

            dgvPhieuNhap.DataSource = ds.Tables[0];
            dgvPhieuNhap.Refresh();
        }
    }
}
