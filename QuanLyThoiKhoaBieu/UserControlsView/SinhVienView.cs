using QuanLyThoiKhoaBieu.Model;
using QuanLyThoiKhoaBieu.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThoiKhoaBieu.UserControlsView
{
    public partial class SinhVienView : UserControl
    {
        ScheduleManagementEntities model = new ScheduleManagementEntities();
        int status = 0;
        public SinhVienView()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Chọn ảnh...";
            dialog.Filter = "bitmap file (*.bmp)|*.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pbAvatar.Image = new Bitmap(dialog.FileName);
            }
        }

        public Image byteArratToImage(byte[] Arr)
        {
            if (Arr != null)
            {
                Image bmp = (Bitmap)((new ImageConverter()).ConvertFrom(Arr));
                return bmp;
            }
            return null;

        }

        public byte[] imageToByteArr(Image img)
        {
            if (img != null)
            {
                ImageConverter image = new ImageConverter();
                byte[] xbyte = (byte[])image.ConvertTo(img, typeof(byte[]));
                return xbyte;
            }
            return null;
        }

        private static List<Object> gioiTinh = new List<Object>() {
            new {id= true, name = "Nam" },
            new {id= false, name = "Nữ" }
        };
        private void SinhVienView_Load(object sender, EventArgs e)
        {
            TextControl.emptyTxt(this);
            try
            {
                ShowGridView.showDataGridView(dataGridThongTin, model.sp_danhSachSinhVienFouth(), false);
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ShowCombobox.initCombobox(cbGioiTinh, gioiTinh);
            ShowCombobox.initCombobox(cbLop, model.sp_getLop4CB());
            ShowCombobox.initCombobox(cbMaDangKi, model.sp_getDangKy4CB());
            ShowCombobox.initCombobox(cbHocKy, model.sp_getHocKy4CB());
            ShowCombobox.initCombobox(cbHocPhan, model.sp_getHocPhan4CB());
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void dataGridThongTin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow rows = dataGridThongTin.Rows[e.RowIndex];
                txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
                if (rows.Cells[1].Value != null)
                {
                    pbAvatar.Image = byteArratToImage((Byte[])rows.Cells[1].Value);
                }
                else
                {
                    pbAvatar.Image = null;
                }
                txtTenSinhVien.Text = rows.Cells[2].Value == null ? "" : rows.Cells[2].Value.ToString();
                cbLop.Text = rows.Cells[3].Value == null ? "" : rows.Cells[3].Value.ToString();
                dtNgaySinh.Text = rows.Cells[4].Value == null ? "" : rows.Cells[4].Value.ToString();
                cbGioiTinh.Text = rows.Cells[5].Value == null ? "" : rows.Cells[5].Value.ToString();
                txtDiaChi.Text = rows.Cells[6].Value == null ? "" : rows.Cells[6].Value.ToString();
                txtEmail.Text = rows.Cells[7].Value == null ? "" : rows.Cells[7].Value.ToString();
                txtDienThoai.Text = rows.Cells[8].Value == null ? "" : rows.Cells[8].Value.ToString();
                txtTenDangNhap.Text = rows.Cells[9].Value == null ? "" : rows.Cells[9].Value.ToString();
                txtMatKhau.Text = rows.Cells[10].Value == null ? "" : rows.Cells[10].Value.ToString();
                cbMaDangKi.Text = rows.Cells[11].Value == null ? "" : rows.Cells[11].Value.ToString();
                cbHocPhan.Text = rows.Cells[12].Value == null ? "" : rows.Cells[12].Value.ToString();
                cbHocKy.Text = rows.Cells[13].Value == null ? "" : rows.Cells[13].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Cột không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowGridView.showDataGridView(dataGridThongTin, renderGridSinhVien());

        }

        private List<Object> renderGridSinhVien()
        {
            List<Model.SinhVien> render = model.SinhViens.ToList();
            if (txtSearch.Text != "")
            {
                string key = txtSearch.Text;
                render = render.Where(u => u.tenSV.Contains(key) || u.tenDangNhap.Contains(key) || u.Lop_QL.tenLop.Contains(key)).ToList();
            }
            List<Object> list = render.Select(u => new
            {
                maSV = u.maSV,
                avatar = u.avatar,
                tenSV = u.tenSV,
                tenLop = u.Lop_QL.tenLop,
                ngaySinh = u.ngaySinh,
                gioiTinh = u.gioiTinh == true ? "Nam" : "Nữ",
                diaChi = u.diaChi,
                email = u.email,
                dienThoai = u.dienThoai,
                tenDangNhap = u.tenDangNhap,
                matKhau = u.matKhau,
                maDangKy = u.maDangKy,
                tenHP = u.HocPhan.tenHP,
                hocKy = u.HocKy_NienKhoa.hocKy,
            }).ToList<Object>();
            return list;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (status == 1)
            {
                model.sp_themSinhVien(txtTenSinhVien.Text, (int)cbLop.SelectedValue, dtNgaySinh.Value, (bool)cbGioiTinh.SelectedValue,
                    txtDiaChi.Text, txtEmail.Text, txtDienThoai.Text, (int)cbMaDangKi.SelectedValue,
                    (int)cbHocPhan.SelectedValue, (int)cbHocKy.SelectedValue, txtTenDangNhap.Text, txtMatKhau.Text, imageToByteArr(pbAvatar.Image));
                MessageBox.Show("Thêm sinh viên thành công");
                EnableButton();
            }

            if (status == 2)
            {
                model.sp_suaSinhVien(int.Parse(txt1.Text), txtTenSinhVien.Text, (int)cbLop.SelectedValue, dtNgaySinh.Value, (bool)cbGioiTinh.SelectedValue,
                    txtDiaChi.Text, txtEmail.Text, txtDienThoai.Text, (int)cbMaDangKi.SelectedValue,
                    (int)cbHocPhan.SelectedValue, (int)cbHocKy.SelectedValue, txtTenDangNhap.Text, txtMatKhau.Text, imageToByteArr(pbAvatar.Image));
                MessageBox.Show("Sửa sinh viên thành công");
                EnableButton();
            }

            if (status == 3)
            {
                model.sp_xoaSinhVien(int.Parse(txt1.Text));
                MessageBox.Show("Xóa sinh viên thành công");
                EnableButton();
            }
            dataGridThongTin.DataSource = model.sp_danhSachSinhVienFouth();
        }

        private void EnableButton(bool type = true)
        {
            btnThem.Enabled = type;
            btnSua.Enabled = type;
            btnXoa.Enabled = type;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            status = 1;
            EnableButton(false);
            TextControl.emptyTxt(this);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            status = 2;
            EnableButton(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            status = 3;
            EnableButton(false);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            TextControl.emptyTxt(this);
            EnableButton();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridThongTin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow rows = dataGridThongTin.Rows[e.RowIndex];
                txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
                if (rows.Cells[1].Value != null)
                {
                    pbAvatar.Image = byteArratToImage((Byte[])rows.Cells[1].Value);
                }
                else
                {
                    pbAvatar.Image = null;
                }
                txtTenSinhVien.Text = rows.Cells[2].Value == null ? "" : rows.Cells[2].Value.ToString();
                cbLop.Text = rows.Cells[3].Value == null ? "" : rows.Cells[3].Value.ToString();
                dtNgaySinh.Text = rows.Cells[4].Value == null ? "" : rows.Cells[4].Value.ToString();
                cbGioiTinh.Text = rows.Cells[3].Value == null ? "" : rows.Cells[3].Value.ToString();
                txtDiaChi.Text = rows.Cells[6].Value == null ? "" : rows.Cells[6].Value.ToString();
                txtEmail.Text = rows.Cells[7].Value == null ? "" : rows.Cells[7].Value.ToString();
                txtDienThoai.Text = rows.Cells[8].Value == null ? "" : rows.Cells[8].Value.ToString();
                txtTenDangNhap.Text = rows.Cells[9].Value == null ? "" : rows.Cells[9].Value.ToString();
                txtMatKhau.Text = rows.Cells[10].Value == null ? "" : rows.Cells[10].Value.ToString();
                cbMaDangKi.Text = rows.Cells[11].Value == null ? "" : rows.Cells[11].Value.ToString();
                cbHocPhan.Text = rows.Cells[12].Value == null ? "" : rows.Cells[12].Value.ToString();
                cbHocKy.Text = rows.Cells[13].Value == null ? "" : rows.Cells[13].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Cột không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
