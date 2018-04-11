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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        public static string dangnhaphethong = "";
        
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            
        }
        accessData acc = new accessData();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection(@" Data Source=DESKTOP-H1LP27V;Initial Catalog=QuanLyKhoHang;Integrated Security=True");

            // conn.Open();
          //  acc.getconnection();
                string tk = tbxTenTaiKhoan.Text;
                string mk = tbxMatKhau.Text;
                //string sql = "Select *from DangNhap where TenDangNhap='" + tk + "'and MatKhau='" + mk + "'";
            //SqlConnection conn = new SqlConnection();
               //SqlCommand cmd = new SqlCommand(sql, conn);
               SqlDataReader dta = acc.ExecuteReader("Select *from DangNhap where TenDangNhap='" + tk + "'and MatKhau='" + mk + "'");
            if (tbxMatKhau.Text.Length > 8)
            {
                if (dta.Read() == true)
                {

                    this.Hide();
                    GiaoDien menu = new GiaoDien();
                    menu.ShowDialog();


                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Sai mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }





        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
             DialogResult tb = MessageBox.Show("Bạn chắc chắn muốn thoát hay không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            Application.Exit();
        }

        /*private void btnDangKi_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangKy menu = new DangKy();
            menu.ShowDialog();
        }*/
    }
}
