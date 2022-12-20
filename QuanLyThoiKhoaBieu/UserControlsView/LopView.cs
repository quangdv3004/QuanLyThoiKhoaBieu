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
    public partial class LopView : UserControl
    {
        ScheduleManagementEntities model = new ScheduleManagementEntities();
        int status = 0;
        public LopView()
        {
            InitializeComponent();
        }

        private void LopView_Load(object sender, EventArgs e)
        {
            TextControl.emptyTxt(this);
            try
            {
                ShowGridView.showDataGridView(dataGridThongTin, model.sp_danhSachLopQuanLy());
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ShowCombobox.initCombobox(cbNganh, model.sp_getNganh4CB());
        }

        private void dataGridThongTin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow rows = dataGridThongTin.Rows[e.RowIndex];
                txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
                txtTenLop.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
                cbNganh.Text = rows.Cells[2].Value == null ? "" : rows.Cells[2].Value.ToString();
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
                model.sp_themLopQuanLy(txtTenLop.Text, (int)cbNganh.SelectedValue);
                MessageBox.Show("Thêm lớp quản lý thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableButton();
            }

            if (status == 2)
            {
                model.sp_suaLopQuanLy(int.Parse(txt1.Text), txtTenLop.Text, (int)cbNganh.SelectedValue);
                MessageBox.Show("Sửa lớp quản lý thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableButton();
            }

            if (status == 3)
            {
                model.sp_xoaLopQuanLy(int.Parse(txt1.Text));
                MessageBox.Show("Xóa lớp quản lý thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableButton();
            }
            dataGridThongTin.DataSource = model.sp_danhSachLopQuanLy();
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
            List<Model.Lop_QL> render = model.Lop_QL.ToList();
            if (txtSearch.Text != "")
            {
                string key = txtSearch.Text;
                render = render.Where(u => u.tenLop.Contains(key)).ToList();
            }
            List<Object> list = render.Select(u => new
            {
                maLop = u.maLop,
                tenLop = u.tenLop,
                tenNganh = u.Nganh.tenNganh
            }).ToList<Object>();
            return list;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowGridView.showDataGridView(dataGridThongTin, renderGridNganh());
        }
    }
}
