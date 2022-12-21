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
    public partial class DangKyView : UserControl
    {
        ScheduleManagementEntities model = new ScheduleManagementEntities();
        int status = 0;
        public DangKyView()
        {
            InitializeComponent();
        }

        private void DangKyView_Load(object sender, EventArgs e)
        {
            TextControl.emptyTxt(this);
            try
            {
                ShowGridView.showDataGridView(dataGridThongTin, model.sp_danhSachDangKy());
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu đăng ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ShowCombobox.initCombobox(cbHocPhan, model.sp_getHocPhan4CB());
            ShowCombobox.initCombobox(cbHocKy, model.sp_getHocKy4CB());
            ShowCombobox.initCombobox(cbGiangVien, model.sp_getGiangVien4CB());
            ShowCombobox.initCombobox(cbMaPCGD, model.sp_getPCGD4CB());
        }

        private void dataGridThongTin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rows = dataGridThongTin.Rows[e.RowIndex];
            txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
            cbMaPCGD.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
            cbGiangVien.Text = rows.Cells[2].Value == null ? "" : rows.Cells[2].Value.ToString();
            cbHocPhan.Text = rows.Cells[3].Value == null ? "" : rows.Cells[3].Value.ToString();
            cbHocKy.Text = rows.Cells[4].Value == null ? "" : rows.Cells[4].Value.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (status == 1)
            {
                model.sp_themDangKy(int.Parse(cbMaPCGD.SelectedValue.ToString()), int.Parse(cbHocPhan.SelectedValue.ToString()), int.Parse(cbGiangVien.SelectedValue.ToString()), int.Parse(cbHocKy.SelectedValue.ToString()));
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
    }
}
