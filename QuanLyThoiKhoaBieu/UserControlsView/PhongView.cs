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
    public partial class PhongView : UserControl
    {
        ScheduleManagementEntities model = new ScheduleManagementEntities();
        int status = 0;
        public PhongView()
        {
            InitializeComponent();
        }

        private void groupThongTin_Enter(object sender, EventArgs e)
        {

        }

        private void PhongView_Load(object sender, EventArgs e)
        {
            TextControl.emptyTxt(this);
            try
            {
                ShowGridView.showDataGridView(dataGridThongTin, model.sp_danhSachPhong());
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGrid(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rows = dataGridThongTin.Rows[e.RowIndex];
            txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
            txt2.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (status == 1)
            {
                model.sp_themPhong(txt2.Text);
                MessageBox.Show("Thêm phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                EnableButton();
            }

            if (status == 2)
            {
                model.sp_suaPhong(int.Parse(txt1.Text), txt2.Text);
                MessageBox.Show("Sửa phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                EnableButton();
            }

            if (status == 3)
            {
                model.sp_xoaPhong(int.Parse(txt1.Text));
                MessageBox.Show("Xóa phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                EnableButton();
            }
            dataGridThongTin.DataSource = model.sp_danhSachPhong();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            TextControl.emptyTxt(this);
            EnableButton();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowGridView.showDataGridView(dataGridThongTin, renderGridPhong());
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
    }
}
