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

    public partial class HocKyView : UserControl
    {
        ScheduleManagementEntities model = new ScheduleManagementEntities();
        int status = 0;
        public HocKyView()
        {
            InitializeComponent();
        }

        private void HocKyView_Load(object sender, EventArgs e)
        {
            TextControl.emptyTxt(this);
            try
            {
                ShowGridView.showDataGridView(dataGridThongTin, model.sp_danhSachHocKy());
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu học kỳ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void dataGridThongTin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rows = dataGridThongTin.Rows[e.RowIndex];
            txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
            txt2.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
            txt3.Text = rows.Cells[2].Value == null ? "" : rows.Cells[2].Value.ToString();
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
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
        }

        private void EnableButton(bool type = true)
        {
            btnThem.Enabled = type;
            btnSua.Enabled = type;
            btnXoa.Enabled = type;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowGridView.showDataGridView(dataGridThongTin, renderGridHocKy());
        }
    }
}
