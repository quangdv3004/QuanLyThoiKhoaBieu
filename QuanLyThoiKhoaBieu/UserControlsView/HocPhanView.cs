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
    public partial class HocPhanView : UserControl
    {
        ScheduleManagementEntities model = new ScheduleManagementEntities();
        int status = 0;
        public HocPhanView()
        {
            InitializeComponent();
        }

        private void HocPhanView_Load(object sender, EventArgs e)
        {
            TextControl.emptyTxt(this);
            try
            {
                ShowGridView.showDataGridView(dataGridThongTin, model.sp_danhSachHocPhan());
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu học phần", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridThongTin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow rows = dataGridThongTin.Rows[e.RowIndex];
                txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
                txtTenHocPhan.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
                txtSoTinChi.Text = rows.Cells[2].Value == null ? "" : rows.Cells[2].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Cột không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (status == 1)
            {
                try
                {
                    model.sp_themHocPhan(txtTenHocPhan.Text, int.Parse(txtSoTinChi.Text));
                    MessageBox.Show("Thêm học phần thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EnableButton();
                }
                catch
                {
                    MessageBox.Show("Số tín chỉ phải là chữ số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

            if (status == 2)
            {
                model.sp_suaHocPhan(int.Parse(txt1.Text), txtTenHocPhan.Text, int.Parse(txtSoTinChi.Text));
                MessageBox.Show("Sửa học phần thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableButton();
            }

            if (status == 3)
            {
                model.sp_xoaHocPhan(int.Parse(txt1.Text));
                MessageBox.Show("Xóa học phần thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableButton();
            }
            dataGridThongTin.DataSource = model.sp_danhSachHocPhan();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            TextControl.emptyTxt(this);
            EnableButton();
        }

        private void EnableButton(bool type = true)
        {
            btnThem.Enabled = type;
            btnSua.Enabled = type;
            btnXoa.Enabled = type;
        }

        private List<Object> renderGridHP()
        {
            List<Model.HocPhan> render = model.HocPhans.ToList();
            if (txtSearch.Text != "")
            {
                string key = txtSearch.Text;
                render = render.Where(u => u.tenHP.Contains(key) || u.soTinChi.ToString().Contains(key)).ToList();
            }
            List<Object> list = render.Select(u => new
            {
                maHP = u.maHP,
                tenHP = u.tenHP,
                soTinChi = u.soTinChi
            }).ToList<Object>();
            return list;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowGridView.showDataGridView(dataGridThongTin, renderGridHP());
        }

        private void dataGridThongTin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow rows = dataGridThongTin.Rows[e.RowIndex];
                txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
                txtTenHocPhan.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
                txtSoTinChi.Text = rows.Cells[2].Value == null ? "" : rows.Cells[2].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Cột không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
