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
    public partial class ThoiKhoaBieuView : UserControl
    {
        ScheduleManagementEntities model = new ScheduleManagementEntities();
        int status = 0;
        public ThoiKhoaBieuView()
        {
            InitializeComponent();
        }

        private void groupThongTin_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ThoiKhoaBieuView_Load(object sender, EventArgs e)
        {
            TextControl.emptyTxt(this);
            try
            {
                ShowGridView.showDataGridView(dataGridThongTin, model.sp_danhSachTKBThree());
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu thời khóa biểu của bạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ShowCombobox.initCombobox(cbPhong, model.sp_getPhong4CB());
            ShowCombobox.initCombobox(cbLop, model.sp_getLop4CB());
            ShowCombobox.initCombobox(cbHP, model.sp_getHocPhan4CB());
            ShowCombobox.initCombobox(cbGV, model.sp_getGiangVien4CB());
            ShowCombobox.initCombobox(cbPCGD, model.sp_getPCGD4CB());
            ShowCombobox.initCombobox(cbHK, model.sp_getHocKy4CB());
        }

        private void dataGridThongTin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow rows = dataGridThongTin.Rows[e.RowIndex];
                txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
                txtThu.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
                txtTiet.Text = rows.Cells[2].Value == null ? "" : rows.Cells[2].Value.ToString();
                cbGV.Text = rows.Cells[3].Value == null ? "" : rows.Cells[3].Value.ToString();
                cbPhong.Text = rows.Cells[4].Value == null ? "" : rows.Cells[4].Value.ToString();
                cbHP.Text = rows.Cells[5].Value == null ? "" : rows.Cells[5].Value.ToString();
                cbPCGD.Text = rows.Cells[6].Value == null ? "" : rows.Cells[6].Value.ToString();
                cbHK.Text = rows.Cells[7].Value == null ? "" : rows.Cells[7].Value.ToString();
                cbLop.Text = rows.Cells[8].Value == null ? "" : rows.Cells[8].Value.ToString();
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
                model.sp_themThoiKHoaBieu(txtThu.Text, int.Parse(txtTiet.Text), (int)cbPhong.SelectedValue,
                    (int)cbHP.SelectedValue, (int)cbGV.SelectedValue, (int)cbHK.SelectedValue,
                    (int)cbPCGD.SelectedValue, (int)cbLop.SelectedValue);
                MessageBox.Show("Thêm thời khóa biểu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableButton();
            }

            if (status == 2)
            {
                model.sp_suaThoiKHoaBieu(int.Parse(txt1.Text), txtThu.Text, int.Parse(txtTiet.Text), (int)cbPhong.SelectedValue,
                    (int)cbHP.SelectedValue, (int)cbGV.SelectedValue, (int)cbHK.SelectedValue,
                    (int)cbPCGD.SelectedValue, (int)cbLop.SelectedValue);
                MessageBox.Show("Sửa thời khóa biểu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableButton();
            }

            if (status == 3)
            {
                model.sp_xoaThoiKhoaBieu(int.Parse(txt1.Text));
                MessageBox.Show("Xóa thời khóa biểu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableButton();
            }
            dataGridThongTin.DataSource = model.sp_danhSachTKBThree();
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

        private List<Object> renderGridTKB()
        {
            List<Model.ThoiKhoaBieu> render = model.ThoiKhoaBieux.ToList();
            if (txtSearch.Text != "")
            {
                string key = txtSearch.Text;
                render = render.Where(u => u.thu.Contains(key) || u.tiet.ToString().Contains(key) 
                || u.Phong.tenPhong.Contains(key)|| u.HocPhan.tenHP.Contains(key)
                || u.GiangVien.tenGV.Contains(key)|| u.Lop_QL.tenLop.Contains(key)).ToList();
            }
            List<Object> list = render.Select(u => new
            {
                maTKB = u.maTKB,
                thu = u.thu,
                tiet = u.tiet,
                tenGV = u.GiangVien.tenGV,
                tenPhong = u.Phong.tenPhong,
                tenHP = u.HocPhan.tenHP,
                maPCGD = u.PhanCongGiangDay.maPCGD,
                hocKy = u.HocKy_NienKhoa.hocKy,
                tenLop = u.Lop_QL.tenLop,
            }).ToList<Object>();
            return list;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowGridView.showDataGridView(dataGridThongTin, renderGridTKB());
        }

        private static List<Object> gioiTinh = new List<Object>() {
            new {id= true, name = "Nam" },
            new {id= false, name = "Nữ" }
        };

        private void dataGridThongTin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow rows = dataGridThongTin.Rows[e.RowIndex];
                txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
                txtThu.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
                txtTiet.Text = rows.Cells[2].Value == null ? "" : rows.Cells[2].Value.ToString();
                cbGV.Text = rows.Cells[3].Value == null ? "" : rows.Cells[3].Value.ToString();
                cbPhong.Text = rows.Cells[4].Value == null ? "" : rows.Cells[4].Value.ToString();
                cbHP.Text = rows.Cells[5].Value == null ? "" : rows.Cells[5].Value.ToString();
                cbPCGD.Text = rows.Cells[6].Value == null ? "" : rows.Cells[6].Value.ToString();
                cbHK.Text = rows.Cells[7].Value == null ? "" : rows.Cells[7].Value.ToString();
                cbLop.Text = rows.Cells[8].Value == null ? "" : rows.Cells[8].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Cột không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
