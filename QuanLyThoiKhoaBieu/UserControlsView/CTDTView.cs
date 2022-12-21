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
    public partial class CTDTView : UserControl
    {
        ScheduleManagementEntities model = new ScheduleManagementEntities();
        int status = 0;
        public CTDTView()
        {
            InitializeComponent();
        }

        private void CTDTView_Load(object sender, EventArgs e)
        {
            TextControl.emptyTxt(this);
            try
            {
                ShowGridView.showDataGridView(dataGridThongTin, model.sp_danhSachCTDT());
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu chương trình đào tạo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ShowCombobox.initCombobox(cbNganh, model.sp_getNganh4CB());
        }

        private void groupThongTin_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridThongTin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow rows = dataGridThongTin.Rows[e.RowIndex];
                txt1.Text = rows.Cells[0].Value == null ? "" : rows.Cells[0].Value.ToString();
                txtTenCTDT.Text = rows.Cells[1].Value == null ? "" : rows.Cells[1].Value.ToString();
                txtTimeDT.Text = rows.Cells[2].Value == null ? "" : rows.Cells[2].Value.ToString();
                dtngayKy.Text = rows.Cells[3].Value == null ? "" : rows.Cells[3].Value.ToString();
                cbNganh.Text = rows.Cells[4].Value == null ? "" : rows.Cells[4].Value.ToString();
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
                model.sp_themCTDT(txtTenCTDT.Text, txtTimeDT.Text, dtngayKy.Value, int.Parse(cbNganh.SelectedValue.ToString()));
                MessageBox.Show("Thêm chương trình đào tạo thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableButton();
            }

            if (status == 2)
            {
                model.sp_suaCTDT(int.Parse(txt1.Text),txtTenCTDT.Text, txtTimeDT.Text, dtngayKy.Value, int.Parse(cbNganh.SelectedValue.ToString()));
                MessageBox.Show("Sửa  chương trình đào tạo thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableButton();
            }

            if (status == 3)
            {
                model.sp_xoaCTDT(int.Parse(txt1.Text));
                MessageBox.Show("Xóa  chương trình đào tạo thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableButton();
            }
            dataGridThongTin.DataSource = model.sp_danhSachCTDT();
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
            List<Model.CTDT> render = model.CTDTs.ToList();
            if (txtSearch.Text != "")
            {
                string key = txtSearch.Text;
                render = render.Where(u => u.tenCTDT.Contains(key) || u.tgianDT.Contains(key) 
                || u.ngayKy.ToString().Contains(key) || u.Nganh.tenNganh.ToString().Contains(key)).ToList();
            }
            List<Object> list = render.Select(u => new
            {
                maCTDT = u.maCTDT,
                tenCTDT = u.tenCTDT,
                tgianDT = u.tgianDT,
                ngayKy = u.ngayKy,
                tenNganh = u.Nganh.tenNganh,
            }).ToList<Object>();
            return list;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowGridView.showDataGridView(dataGridThongTin, renderGridNganh());
        }
    }
}
