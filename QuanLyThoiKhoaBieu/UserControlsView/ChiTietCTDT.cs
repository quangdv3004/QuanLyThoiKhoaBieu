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
    public partial class ChiTietCTDT : UserControl
    {
        ScheduleManagementEntities model = new ScheduleManagementEntities();
        int status = 0;
        public ChiTietCTDT()
        {
            InitializeComponent();
        }

        private void ChiTietCTDT_Load(object sender, EventArgs e)
        {
            TextControl.emptyTxt(this);
            try
            {
                ShowGridView.showDataGridView(dataGridThongTin, model.sp_danhSachChiTietCTDT());
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu chương trình đào tạo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ShowCombobox.initCombobox(cbHocPhan, model.sp_getHocPhan4CB());
            ShowCombobox.initCombobox(cbCTDT, model.sp_getCTDT4CB());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridThongTin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow rows = dataGridThongTin.Rows[e.RowIndex];
                txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
                cbHocPhan.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
                txtSoTInChi.Text = rows.Cells[2].Value == null ? "" : rows.Cells[2].Value.ToString();
                cbCTDT.Text = rows.Cells[4].Value == null ? "" : rows.Cells[4].Value.ToString();
                txtTenNganh.Text = rows.Cells[3].Value == null ? "" : rows.Cells[3].Value.ToString();
                txtTimeDT.Text = rows.Cells[6].Value == null ? "" : rows.Cells[6].Value.ToString();
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
                model.sp_themChiTietCTDT((int)cbHocPhan.SelectedValue, (int)cbCTDT.SelectedValue);
                MessageBox.Show("Thêm chi tiết chương trình đào tạo thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableButton();
            }

            if (status == 2)
            {
                model.sp_suaChiTietCTDT(int.Parse(txt1.Text), (int)cbHocPhan.SelectedValue, (int)cbCTDT.SelectedValue);
                MessageBox.Show("Sửa chi tiết chương trình đào tạo thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableButton();
            }

            if (status == 3)
            {
                model.sp_xoaChiTietCTDT(int.Parse(txt1.Text));
                MessageBox.Show("Xóa chi tiết chương trình đào tạo thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableButton();
            }
            dataGridThongTin.DataSource = model.sp_danhSachChiTietCTDT();
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

        private List<Object> renderGridChiTietCTDT()
        {
            List<Model.ChiTietCTDT> render = model.ChiTietCTDTs.ToList();
            if (txtSearch.Text != "")
            {
                string key = txtSearch.Text;
                render = render.Where(u => u.HocPhan.tenHP.Contains(key) || u.HocPhan.soTinChi.ToString().Contains(key)
                || u.CTDT.tenCTDT.ToString().Contains(key) || u.CTDT.Nganh.tenNganh.ToString().Contains(key) || 
                u.CTDT.tgianDT.Contains(key)).ToList();
            }
            List<Object> list = render.Select(u => new
            {
                maChiTiet = u.maChiTiet,
                tenHP = u.HocPhan.tenHP,
                soTinChi = u.HocPhan.soTinChi,
                tenCTDT = u.CTDT.tenCTDT,
                tenNganh = u.CTDT.Nganh.tenNganh,
                ngayKy = u.CTDT.ngayKy,
                tgianDT = u.CTDT.tgianDT,
            }).ToList<Object>();
            return list;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowGridView.showDataGridView(dataGridThongTin, renderGridChiTietCTDT());
        }

        private void cbHocPhan_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void cbHocPhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbHocPhan.SelectedValue.ToString() != "QuanLyThoiKhoaBieu.Model.sp_getHocPhan4CB_Result")
            {
                int maHP = int.Parse(cbHocPhan.SelectedValue.ToString());
                string soTinChi = model.HocPhans.FirstOrDefault(u => u.maHP == maHP).soTinChi.ToString();
                txtSoTInChi.Text = soTinChi;
            }
        }

        private void cbCTDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCTDT.SelectedValue.ToString() != "QuanLyThoiKhoaBieu.Model.sp_getCTDT4CB_Result")
            {
                int maCTDT = int.Parse(cbCTDT.SelectedValue.ToString());
                CTDT ct = model.CTDTs.FirstOrDefault(u => u.maCTDT == maCTDT);
                txtTenNganh.Text = ct.Nganh.tenNganh;
                txtTimeDT.Text = ct.tgianDT;
            }
        }

        private void dataGridThongTin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow rows = dataGridThongTin.Rows[e.RowIndex];
                txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
                cbHocPhan.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
                txtSoTInChi.Text = rows.Cells[2].Value == null ? "" : rows.Cells[2].Value.ToString();
                cbCTDT.Text = rows.Cells[4].Value == null ? "" : rows.Cells[4].Value.ToString();
                txtTenNganh.Text = rows.Cells[3].Value == null ? "" : rows.Cells[3].Value.ToString();
                txtTimeDT.Text = rows.Cells[6].Value == null ? "" : rows.Cells[6].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Cột không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
