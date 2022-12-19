using QuanLyThoiKhoaBieu.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThoiKhoaBieu
{
    public partial class Form1 : Form
    {
        ScheduleManagementEntities model = new ScheduleManagementEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void showPass_CheckedChanged(object sender, EventArgs e)
        {
            if (showPass.Checked == true)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }    
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text;
            string pass = txtMatKhau.Text;
            if (model.SinhViens.Any(u => u.tenDangNhap == username && u.matKhau == pass))
            {
                MessageBox.Show("Đăng nhập thành công");
                Program.userLogged = model.SinhViens.FirstOrDefault(u => u.tenDangNhap == username && u.matKhau == pass);
                ThoiKhoaBieu tkb = new ThoiKhoaBieu();
                tkb.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
            }
        }
    }
}
