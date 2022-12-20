using QuanLyThoiKhoaBieu.Model;
using QuanLyThoiKhoaBieu.Services;
using QuanLyThoiKhoaBieu.UserControlsView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThoiKhoaBieu
{
    public partial class ThoiKhoaBieu : Form
    {
        ScheduleManagementEntities model = new ScheduleManagementEntities();
        int status = 0;
        int button = 0;
        ComboBox cbGioiTinh;
        ComboBox cbMaPCGD;
        ComboBox cbHocPhan;
        ComboBox cbGiangVien;
        ComboBox cbHocKy;
        DateTimePicker dtngaySinh;

        public ThoiKhoaBieu()
        {
            InitializeComponent();
        }

        private void tabHeThong_Click(object sender, EventArgs e)
        {

        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            PhongView uc = new PhongView();
            uc.Location = new Point(247, 39);
            this.Controls.Add(uc);
            //hideLabelTextbox();
            //emptyTxt();
            //button = 1;
            //label1.Visible = true;
            //label1.Text = "Mã phòng";
            //txt1.Visible = true;
            //label2.Visible = true;
            //label2.Text = "Tên phòng";
            //txt2.Visible = true;
            //try 
            //{
            //    ShowGridView.showDataGridView(dataGridThongTin, model.sp_danhSachPhong());
            //}
            //catch
            //{
            //    MessageBox.Show("Không load được dữ liệu phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            status = 1;
            DisableButton();
            emptyTxt();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (button)
            {
                case 1:
                    if (status == 1)
                    {
                        model.sp_themPhong(txt2.Text);
                        MessageBox.Show("Thêm phòng thành công");
                        EnableButton();
                    }

                    if (status == 2)
                    {
                        model.sp_suaPhong(int.Parse(txt1.Text), txt2.Text);
                        MessageBox.Show("Sửa phòng thành công");
                        EnableButton();
                    }

                    if (status == 3)
                    {
                        model.sp_xoaPhong(int.Parse(txt1.Text));
                        MessageBox.Show("Xóa phòng thành công");
                        EnableButton();
                    }
                    dataGridThongTin.DataSource = model.sp_danhSachPhong();
                    break;
                case 2:
                    if (status == 1)
                    {
                        DateTime ngaySinh = dtngaySinh.Value;
                        model.sp_themGiangVien(txt2.Text, ngaySinh,(bool)cbGioiTinh.SelectedValue, txt5.Text,
                            txt6.Text);
                        MessageBox.Show("Thêm giảng viên thành công");
                        EnableButton();
                    }

                    if (status == 2)
                    {
                        model.sp_suaGiangVien(int.Parse(txt1.Text), txt2.Text, dtngaySinh.Value, (bool)cbGioiTinh.SelectedValue, txt5.Text,
                            txt6.Text);
                        MessageBox.Show("Sửa giảng viên thành công");
                        EnableButton();
                    }

                    if (status == 3)
                    {
                        model.sp_xoaGiangVien(int.Parse(txt1.Text));
                        MessageBox.Show("Xóa giảng viên thành công");
                        EnableButton();
                    }
                    dataGridThongTin.DataSource = model.sp_danhSachGiangVienFixSecond();
                    break;
                case 3:
                    if (status == 1)
                    {
                        model.sp_themKhoa(txt2.Text);
                        MessageBox.Show("Thêm khoa thành công");
                        EnableButton();
                    }

                    if (status == 2)
                    {
                        model.sp_suaKhoa(int.Parse(txt1.Text), txt2.Text);
                        MessageBox.Show("Sửa khoa thành công");
                        EnableButton();
                    }

                    if (status == 3)
                    {
                        model.sp_xoaKhoa(int.Parse(txt1.Text));
                        MessageBox.Show("Xóa khoa thành công");
                        EnableButton();
                    }
                    dataGridThongTin.DataSource = model.sp_danhSanhKhoa();
                    break;
                case 4:
                    if (status == 1)
                    {
                        model.sp_themHocKy(txt2.Text, txt3.Text);
                        MessageBox.Show("Thêm học kỳ thành công");
                        EnableButton();
                    }

                    if (status == 2)
                    {
                        model.sp_suaHocKy(int.Parse(txt1.Text), txt2.Text, txt3.Text);
                        MessageBox.Show("Sửa học kỳ thành công");
                        EnableButton();
                    }

                    if (status == 3)
                    {
                        model.sp_xoaHocKy(int.Parse(txt1.Text));
                        MessageBox.Show("Xóa học kỳ thành công");
                        EnableButton();
                    }
                    dataGridThongTin.DataSource = model.sp_danhSachHocKy();
                    break;
                case 5:
                    if (status == 1)
                    {
                        model.sp_themDangKy((int)cbMaPCGD.SelectedValue, (int)cbHocPhan.SelectedValue, (int)cbGiangVien.SelectedValue, (int)cbHocKy.SelectedValue);
                        MessageBox.Show("Thêm đăng ký thành công");
                        EnableButton();
                    }

                    if (status == 2)
                    {
                        model.sp_suaDangKy(int.Parse(txt1.Text), (int)cbMaPCGD.SelectedValue, (int)cbHocPhan.SelectedValue, (int)cbGiangVien.SelectedValue, (int)cbHocKy.SelectedValue);
                        MessageBox.Show("Sửa đăng ký thành công");
                        EnableButton();
                    }

                    if (status == 3)
                    {
                        model.sp_xoaDangKy(int.Parse(txt1.Text));
                        MessageBox.Show("Xóa đăng ký thành công");
                        EnableButton();
                    }
                    dataGridThongTin.DataSource = model.sp_danhSachHocKy();
                    break;
            }
        }

        private void DisableButton()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void EnableButton()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void cellGridView(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rows = dataGridThongTin.Rows[e.RowIndex];
            switch (button)
            {
                case 1:
                        txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
                        txt2.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
                    break;
                case 2:
                    txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
                    txt2.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
                    dtngaySinh.Text = rows.Cells[2].Value == null ? "" : rows.Cells[2].Value.ToString();
                    cbGioiTinh.Text = rows.Cells[3].Value == null ? "" : (rows.Cells[3].Value.ToString() == "True" ? "Nam" : "Nữ");
                    txt5.Text = rows.Cells[4].Value == null ? "" : rows.Cells[4].Value.ToString();
                    txt6.Text = rows.Cells[5].Value == null ? "" : rows.Cells[5].Value.ToString();
                    break;
                case 3:
                    txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
                    txt2.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
                    break;
                case 4:
                    txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
                    txt2.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
                    txt3.Text = rows.Cells[2].Value == null ? "" : rows.Cells[2].Value.ToString();
                    break;
                case 5:
                    txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
                    cbMaPCGD.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
                    cbGiangVien.Text = rows.Cells[2].Value == null ? "" : rows.Cells[2].Value.ToString();txt2.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
                    cbHocPhan.Text = rows.Cells[3].Value == null ? "" : rows.Cells[3].Value.ToString();txt2.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
                    cbHocKy.Text = rows.Cells[4].Value == null ? "" : rows.Cells[4].Value.ToString();
                    break;
            }

            //txt3.Text = rows.Cells[2].Value == null ? "" : rows.Cells[2].Value.ToString();
            //txt4.Text = rows.Cells[3].Value == null ? "" : rows.Cells[3].Value.ToString();
            //txt5.Text = rows.Cells[4].Value == null ? "" : rows.Cells[4].Value.ToString();
            //txt6.Text = rows.Cells[5].Value == null ? "" : rows.Cells[5].Value.ToString();
            //txt7.Text = rows.Cells[6].Value == null ? "" : rows.Cells[6].Value.ToString();
            //txt8.Text = rows.Cells[7].Value == null ? "" : rows.Cells[7].Value.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            emptyTxt();
            EnableButton();
        }

        private void emptyTxt()
        {
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            txt7.Text = "";
            txt8.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            status = 2;
            DisableButton();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            status = 3;
            DisableButton();
        }

        private void groupThongTin_Enter(object sender, EventArgs e)
        {

        }

        private static List<Object> gioiTinh = new List<Object>() {
            new {id= true, name = "Nam" }, 
            new {id= false, name = "Nữ" }
        };

        private void btnGiangVien_Click(object sender, EventArgs e)
        {
            hideLabelTextbox();
            emptyTxt();
            try
            {
                List< sp_danhSachGiangVienFixSecond_Result> data = model.sp_danhSachGiangVienFixSecond().ToList<sp_danhSachGiangVienFixSecond_Result>();
                ShowGridView.showDataGridView(dataGridThongTin, data);
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu giảng viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            button = 2;
            string[] label = { "Mã giảng viên", "Tên giảng viên", "Ngày sinh", "Giới tính", "Email", "Điện thoại"};
            display(6, label);
            cbGioiTinh = new ComboBox();
            dtngaySinh = new DateTimePicker();
            ConvertTextBoxToDatePicker(txt3, dtngaySinh);
            ConvertTextBoxToCBB(txt4, cbGioiTinh);
            ShowCombobox.initCombobox(cbGioiTinh, gioiTinh);
        }

        private void hideLabelTextbox()
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            txt1.Visible = false;
            txt2.Visible = false;
            txt3.Visible = false;
            txt4.Visible = false;
            txt5.Visible = false;
            txt6.Visible = false;
            txt7.Visible = false;
            txt8.Visible = false;
            if (cbGioiTinh != null)
            {
                cbGioiTinh.Visible = false;
            }            
            if (cbGiangVien != null)
            {
                cbGiangVien.Visible = false;
            }            
            if (cbHocPhan != null)
            {
                cbHocPhan.Visible = false;
            }            
            if (cbHocKy != null)
            {
                cbHocKy.Visible = false;
            }            
            if (cbMaPCGD != null)
            {
                cbMaPCGD.Visible = false;
            }
            if (dtngaySinh != null)
            {
                dtngaySinh.Visible = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private List<Object> renderGridPhong()
        {
            List<Model.Phong> render = model.Phongs.ToList();
            if (txtSearch.Text != "")
            {
                string key = txtSearch.Text;
                render = render.Where(u => u.tenPhong.Contains(key)).ToList();
            }
            List<Object> list = render.Select(u => new
            {
                maPhong = u.maPhong,
                tenPhong = u.tenPhong,
            }).ToList<Object>();
            return list;
        }           
        private List<Object> renderGridHocKy()
        {
            List<Model.HocKy_NienKhoa> render = model.HocKy_NienKhoa.ToList();
            if (txtSearch.Text != "")
            {
                string key = txtSearch.Text;
                render = render.Where(u => u.hocKy.Contains(key) || u.nienKhoa.Contains(key)).ToList();
            }
            List<Object> list = render.Select(u => new
            {
                maHK = u.maHK,
                hocKy = u.hocKy,
                nienKhoa = u.nienKhoa
            }).ToList<Object>();
            return list;
        }                
        private List<Object> renderGridKhoa()
        {
            List<Model.Khoa> render = model.Khoas.ToList();
            if (txtSearch.Text != "")
            {
                string key = txtSearch.Text;
                render = render.Where(u => u.tenKhoa.Contains(key)).ToList();
            }
            List<Object> list = render.Select(u => new
            {
                maKhoa = u.maKhoa,
                tenKhoa = u.tenKhoa,
            }).ToList<Object>();
            return list;
        }        
        private List<Object> renderGridGiangVien()
        {
            List<Model.GiangVien> render = model.GiangViens.ToList();
            if (txtSearch.Text != "")
            {
                string key = txtSearch.Text;
                render = render.Where(u => u.tenGV.Contains(key) || u.email.Contains(key) || u.dienThoai.Contains(key)).ToList();
            }
            List<Object> list = render.Select(u => new
            {
                maGV = u.maGV,
                tenGV = u.tenGV,
                ngaySinh = u.ngaySinh,
                gioiTinh = u.gioiTinh,
                email = u.email,
                dienThoai = u.dienThoai
            }).ToList<Object>();
            return list;
        }

        private void search(object sender, EventArgs e)
        {
            switch (button)
            {
                case 1:
                    ShowGridView.showDataGridView(dataGridThongTin, renderGridPhong());
                        break;                
                case 2:
                    ShowGridView.showDataGridView(dataGridThongTin, renderGridGiangVien());
                        break;
                case 3:
                    ShowGridView.showDataGridView(dataGridThongTin, renderGridKhoa());
                    break;                
                case 4:
                    ShowGridView.showDataGridView(dataGridThongTin, renderGridHocKy());
                    break;
            }
        }

        private void display(int number, dynamic label)
        {
            switch (number)
            {
                case 2:
                    txt1.Visible = true;
                    txt2.Visible = true;
                    label1.Visible = true;
                    label1.Text = label[0];
                    label2.Visible = true;
                    label2.Text = label[1];
                    break;
                case 3:
                    txt1.Visible = true;
                    txt2.Visible = true;
                    txt3.Visible = true;
                    label1.Visible = true;
                    label1.Text = label[0];
                    label2.Visible = true;
                    label2.Text = label[1];
                    label3.Visible = true;
                    label3.Text = label[2];
                    break;                
                case 4:
                    txt1.Visible = true;
                    txt2.Visible = true;
                    txt3.Visible = true;
                    txt4.Visible = true;
                    label1.Visible = true;
                    label1.Text = label[0];
                    label2.Visible = true;
                    label2.Text = label[1];
                    label3.Visible = true;
                    label3.Text = label[2];
                    label4.Visible = true;
                    label4.Text = label[3];
                    break;                
                case 5:
                    txt1.Visible = true;
                    txt2.Visible = true;
                    txt3.Visible = true;
                    txt4.Visible = true;
                    txt5.Visible = true;
                    label1.Visible = true;
                    label1.Text = label[0];
                    label2.Visible = true;
                    label2.Text = label[1];
                    label3.Visible = true;
                    label3.Text = label[2];
                    label4.Visible = true;
                    label4.Text = label[3];
                    label5.Visible = true;
                    label5.Text = label[4];
                    break;             
                case 6:
                    txt1.Visible = true;
                    txt2.Visible = true;
                    txt3.Visible = true;
                    txt4.Visible = true;
                    txt5.Visible = true;
                    txt6.Visible = true;
                    label1.Visible = true;
                    label1.Text = label[0];
                    label2.Visible = true;
                    label2.Text = label[1];
                    label3.Visible = true;
                    label3.Text = label[2];
                    label4.Visible = true;
                    label4.Text = label[3];
                    label5.Visible = true;
                    label5.Text = label[4];
                    label6.Visible = true;
                    label6.Text = label[5];
                    break;             
                case 7:
                    txt1.Visible = true;
                    txt2.Visible = true;
                    txt3.Visible = true;
                    txt4.Visible = true;
                    txt5.Visible = true;
                    txt6.Visible = true;
                    label1.Visible = true;
                    label1.Text = label[0];
                    label2.Visible = true;
                    label2.Text = label[1];
                    label3.Visible = true;
                    label3.Text = label[2];
                    label4.Visible = true;
                    label4.Text = label[3];
                    label5.Visible = true;
                    label5.Text = label[4];
                    label6.Visible = true;
                    label6.Text = label[5];
                    label7.Visible = true;
                    label7.Text = label[6];
                    break;                
                case 8:
                    txt1.Visible = true;
                    txt2.Visible = true;
                    txt3.Visible = true;
                    txt4.Visible = true;
                    txt5.Visible = true;
                    txt6.Visible = true;
                    label1.Visible = true;
                    label1.Text = label[0];
                    label2.Visible = true;
                    label2.Text = label[1];
                    label3.Visible = true;
                    label3.Text = label[2];
                    label4.Visible = true;
                    label4.Text = label[3];
                    label5.Visible = true;
                    label5.Text = label[4];
                    label6.Visible = true;
                    label6.Text = label[5];
                    label7.Visible = true;
                    label7.Text = label[6];
                    label8.Visible = true;
                    label8.Text = label[7];
                    break;                
            }
        }

        private void ConvertTextBoxToCBB(dynamic textBox, ComboBox cbb)
        {
            int x = textBox.Location.X;
            int y = textBox.Location.Y;
            textBox.Visible = false;
            cbb.Location = new Point(x, y);
            cbb.Size = new Size(188, 26);
            groupThongTin.Controls.Add(cbb);
        }        
        private void ConvertTextBoxToDatePicker(dynamic textBox, DateTimePicker cbb)
        {
            int x = textBox.Location.X;
            int y = textBox.Location.Y;
            textBox.Visible = false;
            cbb.Location = new Point(x, y);
            cbb.Size = new Size(188, 26);
            cbb.Format = DateTimePickerFormat.Short;
            cbb.Font = new Font("Microsoft Sans Serif", 11);
            groupThongTin.Controls.Add(cbb);
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            button = 3;
            hideLabelTextbox();
            emptyTxt();
            try
            {
                ShowGridView.showDataGridView(dataGridThongTin, model.sp_danhSanhKhoa());
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string[] label = { "Mã khoa", "Tên khoa" };
            display(2, label);
        }

        private void btnHKNK_Click(object sender, EventArgs e)
        {
            button = 4;
            hideLabelTextbox();
            emptyTxt();
            try
            {
                ShowGridView.showDataGridView(dataGridThongTin, model.sp_danhSachHocKy());
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu học kỳ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string[] label = { "Mã học kỳ", "Học kỳ", "Niên khóa" };
            display(3, label);
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            button = 5;
            hideLabelTextbox();
            emptyTxt();
            try
            {
                ShowGridView.showDataGridView(dataGridThongTin, model.sp_danhSachDangKy());
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu đăng ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string[] label = { "Mã đăng kí", "Mã phân công giảng dạy", "Tên giảng viên", "Tên học phần","Học kỳ" };
            display(5, label);
            cbMaPCGD = new ComboBox();
            ConvertTextBoxToCBB(txt2, cbMaPCGD);
            ShowCombobox.initCombobox(cbMaPCGD, model.sp_getPCGD4CB());
            cbGiangVien = new ComboBox();
            ConvertTextBoxToCBB(txt3, cbGiangVien);
            ShowCombobox.initCombobox(cbGiangVien, model.sp_getGiangVien4CB());
            cbHocKy = new ComboBox();
            ConvertTextBoxToCBB(txt5, cbHocKy);
            ShowCombobox.initCombobox(cbHocKy, model.sp_getHocKy4CB());
            cbHocPhan = new ComboBox();
            ConvertTextBoxToCBB(txt4, cbHocPhan);
            ShowCombobox.initCombobox(cbHocPhan, model.sp_getHocPhan4CB());
        }
    }
}
