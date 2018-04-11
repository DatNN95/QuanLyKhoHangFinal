using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoHang
{
    public partial class GiaoDien : Form
    {
        public GiaoDien()
        {
            InitializeComponent();
        }

        private void btn_baohanh_Click(object sender, EventArgs e)
        {
            this.Hide();
            CTPhieuBH menu = new CTPhieuBH();
            menu.ShowDialog();
        }

        private void btn_nhanvien_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhanVien menu = new NhanVien();
            menu.ShowDialog();
        }

        private void btn_khachhang_Click(object sender, EventArgs e)
        {

        }

        private void btn_hangsanxuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            HangSanXuat menu = new HangSanXuat();
            menu.ShowDialog();
        }

        private void btn_xuathang_Click(object sender, EventArgs e)
        {
            this.Hide();
            CTPhieuXuat menu = new CTPhieuXuat();
            menu.ShowDialog();
        }

        private void btn_nhaphang_Click(object sender, EventArgs e)
        {
            this.Hide();
            CTPhieuNhap menu = new CTPhieuNhap();
            menu.ShowDialog();
        }

        private void btn_sanpham_Click(object sender, EventArgs e)
        {
            this.Hide();
            SanPham menu = new SanPham();
            menu.ShowDialog();
        }

        private void GiaoDien_Load(object sender, EventArgs e)
        {

        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            this.Hide();
            TimKiem menu = new TimKiem();
            menu.ShowDialog();
        }

        private void btn_tonkho_Click(object sender, EventArgs e)
        {
            this.Hide();
            TonKho menu = new TonKho();
            menu.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoaiSP menu = new LoaiSP();
            menu.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn chắc chắn muốn đăng xuất hay không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            this.Hide();
            DangNhap Menu = new DangNhap();
            Menu.ShowDialog();
            
             
        }
    }
}
