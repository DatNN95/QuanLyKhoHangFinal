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
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }
       

       
        private void btnThem_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(@" Data Source=DESKTOP-H1LP27V;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            try
            {

                conn.Open();

                string sql = "insert into NhanVien Values('" + tbxMaNV.Text + "','" + tbxHoTen.Text + "','" + dtNgaySinh.Text + "','" + cbxGioiTinh.Text + "','" + tbxDiaChi.Text + "','" + tbxSoDienThoai.Text + "')";


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
            if (tbxMaNV.Text != "")
            {
                string sql = "UPDATE NhanVien SET MaNV ='" + tbxMaNV.Text + "', HoTen ='" + tbxHoTen.Text + "',NgaySinh ='" + dtNgaySinh.Text + "',GioiTinh ='" + cbxGioiTinh.Text + "',DiaChi ='" + tbxDiaChi.Text + "',SDT ='" + tbxSoDienThoai.Text + "' WHERE MaNV='" + tbxMaNV.Text + "'";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();



                MessageBox.Show("Cập Nhật Thành Công");

            }
            else
            {
                MessageBox.Show("Nhập sai mã nhân viên!", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(@" Data Source=DESKTOP-H1LP27V;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            accessData acc = new accessData();


            string sql = "delete from NhanVien where MaSP='" + tbxMaNV.Text + "'";

            acc.excuteNonQuery(sql);


            try
            {
                tbxMaNV.Clear();

                tbxHoTen.Clear();
                //tbxNgaySinh.Clear();
                //tbxGioiTinh.Clear();

                tbxDiaChi.Clear();
                tbxSoDienThoai.Clear();
            }
            catch { }
            MessageBox.Show("Xoá thành công !");






            try
            {
                tbxMaNV.Clear();

                tbxHoTen.Clear();
               // dtNgaySinh.Clear();
              // cbxGioiTinh.Clear();

                tbxDiaChi.Clear();
                tbxSoDienThoai.Clear();
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

        private void NhanVien_Load(object sender, EventArgs e)
        {


            SqlConnection conn = new SqlConnection(@" Data Source=DESKTOP-H1LP27V;Initial Catalog=QuanLyKhoHang;Integrated Security=True");
            conn.Open();

            string sql = "select *from NhanVien";
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(sql, conn);
            dap.Fill(ds);

            dgvNhanVien.DataSource = ds.Tables[0];
            dgvNhanVien.Refresh();

        }

        private void tbxHoTen_TextChanged(object sender, EventArgs e)
        {

        }
    }
    /*DialogResult tb = MessageBox.Show("Bạn chắc chắn muốn thoát hay không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
                Application.Exit();
                */
}
