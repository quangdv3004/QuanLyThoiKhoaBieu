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

namespace QuanLyThoiKhoaBieu.UserControlsView
{
    public partial class GiangVienView : UserControl
    {
        ScheduleManagementEntities model = new ScheduleManagementEntities();
        int status = 0;
        public GiangVienView()
        {
            InitializeComponent();
        }

        private void groupBang_Enter(object sender, EventArgs e)
        {

        }

        private void groupThongTin_Enter(object sender, EventArgs e)
        {

        }

        private void GiangVienView_Load(object sender, EventArgs e)
        {
            TextControl.emptyTxt(this);
            try
            {
                List<sp_danhSachGiangVienFixSecond_Result> data = model.sp_danhSachGiangVienFixSecond().ToList<sp_danhSachGiangVienFixSecond_Result>();
                ShowGridView.showDataGridView(dataGridThongTin, data);
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu giảng viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ShowCombobox.initCombobox(cbGioiTinh, gioiTinh);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridThongTin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow rows = dataGridThongTin.Rows[e.RowIndex];
                txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
                txt2.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
                dtngaySinh.Text = rows.Cells[2].Value == null ? "" : rows.Cells[2].Value.ToString();
                cbGioiTinh.Text = rows.Cells[3].Value == null ? "" : (rows.Cells[3].Value.ToString() == "True" ? "Nam" : "Nữ");
                txt5.Text = rows.Cells[4].Value == null ? "" : rows.Cells[4].Value.ToString();
                txt6.Text = rows.Cells[5].Value == null ? "" : rows.Cells[5].Value.ToString();
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
                DateTime ngaySinh = dtngaySinh.Value;
                model.sp_themGiangVien(txt2.Text, ngaySinh, (bool)cbGioiTinh.SelectedValue, txt5.Text,
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
                gioiTinh = u.gioiTinh == true ? "Nam" : "Nữ",
                email = u.email,
                dienThoai = u.dienThoai
            }).ToList<Object>();
            return list;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowGridView.showDataGridView(dataGridThongTin, renderGridGiangVien());
        }

        private void dataGridThongTin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rows = dataGridThongTin.Rows[e.RowIndex];
            txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
            txt2.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
            dtngaySinh.Text = rows.Cells[2].Value == null ? "" : rows.Cells[2].Value.ToString();
            cbGioiTinh.Text = rows.Cells[3].Value == null ? "" : (rows.Cells[3].Value.ToString() == "True" ? "Nam" : "Nữ");
            txt5.Text = rows.Cells[4].Value == null ? "" : rows.Cells[4].Value.ToString();
            txt6.Text = rows.Cells[5].Value == null ? "" : rows.Cells[5].Value.ToString();
        }

        private static List<Object> gioiTinh = new List<Object>() {
            new {id= true, name = "Nam" },
            new {id= false, name = "Nữ" }
        };

        private void cbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
