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
    public partial class NganhView : UserControl
    {
        ScheduleManagementEntities model = new ScheduleManagementEntities();
        int status = 0;
        public NganhView()
        {
            InitializeComponent();
        }

        private void cbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NganhView_Load(object sender, EventArgs e)
        {
            TextControl.emptyTxt(this);
            try
            {
                ShowGridView.showDataGridView(dataGridThongTin, model.sp_danhSachNganh());
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu ngành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ShowCombobox.initCombobox(cbKhoa, model.sp_getKhoa4CB());
        }

        private void dataGridThongTin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow rows = dataGridThongTin.Rows[e.RowIndex];
                txt1.Text = rows.Cells[0].Value == null ? "": rows.Cells[0].Value.ToString();
                txtTenNganh.Text = rows.Cells[1].Value == null ? "": rows.Cells[1].Value.ToString();
                cbKhoa.Text = rows.Cells[2].Value == null ? "": rows.Cells[2].Value.ToString();
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
                model.sp_themNganh(txtTenNganh.Text, (int)cbKhoa.SelectedValue);
                MessageBox.Show("Thêm ngành thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableButton();
            }

            if (status == 2)
            {
                model.sp_suaNganh(int.Parse(txt1.Text), txtTenNganh.Text, (int)cbKhoa.SelectedValue);
                MessageBox.Show("Sửa ngành thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableButton();
            }

            if (status == 3)
            {
                model.sp_xoaNganh(int.Parse(txt1.Text));
                MessageBox.Show("Xóa ngành thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableButton();
            }
            dataGridThongTin.DataSource = model.sp_danhSachNganh();
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

        private List<Object> renderGridNganh()
        {
            List<Model.Nganh> render = model.Nganhs.ToList();
            if (txtSearch.Text != "")
            {
                string key = txtSearch.Text;
                render = render.Where(u => u.tenNganh.Contains(key)).ToList();
            }
            List<Object> list = render.Select(u => new
            {
                maNganh = u.maNganh,
                tenNganh = u.tenNganh,
                tenKhoa = u.Khoa.tenKhoa
            }).ToList<Object>();
            return list;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowGridView.showDataGridView(dataGridThongTin, renderGridNganh());
        }
    }
}
