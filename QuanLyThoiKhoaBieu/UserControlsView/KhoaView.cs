using QuanLyThoiKhoaBieu.Model;
using QuanLyThoiKhoaBieu.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyThoiKhoaBieu.UserControlsView
{
    public partial class KhoaView : UserControl
    {
        ScheduleManagementEntities model = new ScheduleManagementEntities();
        int status = 0;
        public KhoaView()
        {
            InitializeComponent();
        }

        private void KhoaView_Load(object sender, EventArgs e)
        {
            try
            {
                ShowGridView.showDataGridView(dataGridThongTin, model.sp_danhSanhKhoa());
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu khoa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridThongTin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rows = dataGridThongTin.Rows[e.RowIndex];
            txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
            txt2.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowGridView.showDataGridView(dataGridThongTin, renderGridKhoa());

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

        private void btnLuu_Click(object sender, EventArgs e)
        {
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

        private void dataGridThongTin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rows = dataGridThongTin.Rows[e.RowIndex];
            txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
            txt2.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
        }
    }
}
