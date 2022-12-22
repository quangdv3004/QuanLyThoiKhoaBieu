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
    public partial class PCGDView : UserControl
    {
        ScheduleManagementEntities model = new ScheduleManagementEntities();
        int status = 0;
        public PCGDView()
        {
            InitializeComponent();
        }

        private void PCGDView_Load(object sender, EventArgs e)
        {
            TextControl.emptyTxt(this);
            try
            {
                ShowGridView.showDataGridView(dataGridThongTin, model.sp_danhSachDangKy());
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu phân công giảng dạy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ShowCombobox.initCombobox(cbHocPhan1, model.sp_getHocPhan4CB());
            ShowCombobox.initCombobox(cbHocKy, model.sp_getHocKy4CB());
            ShowCombobox.initCombobox(cbGiangVien, model.sp_getGiangVien4CB());
        }

        private void dataGridThongTin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rows = dataGridThongTin.Rows[e.RowIndex];
            txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
            cbHocPhan1.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
            cbGiangVien.Text = rows.Cells[2].Value == null ? "" : rows.Cells[2].Value.ToString();
            cbHocKy.Text = rows.Cells[3].Value == null ? "" : rows.Cells[3].Value.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (status == 1)
            {
                model.sp_themPCGD((int)cbHocPhan1.SelectedValue, (int)cbGiangVien.SelectedValue, (int)cbHocKy.SelectedValue);
                MessageBox.Show("Thêm phân công giảng dạy thành công");
                EnableButton();
            }

            if (status == 2)
            {
                model.sp_suaPCGD(int.Parse(txt1.Text), (int)cbHocPhan1.SelectedValue, (int)cbGiangVien.SelectedValue, (int)cbHocKy.SelectedValue);
                MessageBox.Show("Sửa phân công giảng dạy thành công");
                EnableButton();
            }

            if (status == 3)
            {
                model.sp_xoaPCGD(int.Parse(txt1.Text));
                MessageBox.Show("Xóa phân công giảng dạy thành công");
                EnableButton();
            }
            dataGridThongTin.DataSource = model.sp_danhSachPCGD();
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

        private List<Object> renderGridPCGD()
        {
            List<Model.PhanCongGiangDay> render = model.PhanCongGiangDays.ToList();
            if (txtSearch.Text != "")
            {
                string key = txtSearch.Text;
                render = render.Where(u => u.GiangVien.tenGV.Contains(key) || u.HocPhan.tenHP.Contains(key) || u.HocKy_NienKhoa.hocKy.Contains(key)).ToList();
            }
            List<Object> list = render.Select(u => new
            {
                maPCGD = u.maPCGD,
                tenGV = u.GiangVien.tenGV,
                tenHP = u.HocPhan.tenHP,
                hocKy = u.HocKy_NienKhoa.hocKy
            }).ToList<Object>();
            return list;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowGridView.showDataGridView(dataGridThongTin, renderGridPCGD());
        }

        private void dataGridThongTin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow rows = dataGridThongTin.Rows[e.RowIndex];
                txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
                cbHocPhan1.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
                cbGiangVien.Text = rows.Cells[2].Value == null ? "" : rows.Cells[2].Value.ToString();
                cbHocKy.Text = rows.Cells[3].Value == null ? "" : rows.Cells[3].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Cột không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
