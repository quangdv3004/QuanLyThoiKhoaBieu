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
    public partial class SinhVienView : UserControl
    {
        ScheduleManagementEntities model = new ScheduleManagementEntities();
        int status = 0;
        public SinhVienView()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private static List<Object> gioiTinh = new List<Object>() {
            new {id= true, name = "Nam" },
            new {id= false, name = "Nữ" }
        };
        private void SinhVienView_Load(object sender, EventArgs e)
        {
            TextControl.emptyTxt(this);
            try
            {
                ShowGridView.showDataGridView(dataGridThongTin, model.sp_danhSachSinhVienThird(), false);
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ShowCombobox.initCombobox(cbGioiTinh, gioiTinh);
            ShowCombobox.initCombobox(cbLop, model.sp_getLop4CB());
        }
    }
}
