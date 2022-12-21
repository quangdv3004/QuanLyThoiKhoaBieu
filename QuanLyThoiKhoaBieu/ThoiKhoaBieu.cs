using QuanLyThoiKhoaBieu.Model;
using QuanLyThoiKhoaBieu.Services;
using QuanLyThoiKhoaBieu.UserControlsView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThoiKhoaBieu
{
    public partial class ThoiKhoaBieu : Form
    {
        ScheduleManagementEntities model = new ScheduleManagementEntities();
        PhongView uc = new PhongView();
        DangKyView dk = new DangKyView();
        GiangVienView gv = new GiangVienView();
        HocKyView hk = new HocKyView();
        KhoaView khoa = new KhoaView();
        NganhView nganh = new NganhView();
        LopView lop = new LopView();
        HocPhanView hp = new HocPhanView();
        CTDTView ctdt = new CTDTView();
        public ThoiKhoaBieu()
        {
            InitializeComponent();
        }

        private void tabHeThong_Click(object sender, EventArgs e)
        {

        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            
            uc.Location = new Point(185, 25);
            tabQuanLy.Controls.Add(uc);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnGiangVien_Click(object sender, EventArgs e)
        {
            gv.Location = new Point(185, 25);
            tabQuanLy.Controls.Add(gv);
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            khoa.Location = new Point(185, 25);
            tabQuanLy.Controls.Add(khoa);
        }

        private void btnHKNK_Click(object sender, EventArgs e)
        {
            hk.Location = new Point(185, 25);
            tabQuanLy.Controls.Add(hk);
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            dk.Location = new Point(185, 25);
            tabQuanLy.Controls.Add(dk);
        }

        private void tabQuanLy_Click(object sender, EventArgs e)
        {

        }

        private void ThoiKhoaBieu_Load(object sender, EventArgs e)
        {

        }

        private void btnPhong_MouseLeave(object sender, EventArgs e)
        {
        }

        private void btnPhong_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void btnPhong_SystemColorsChanged(object sender, EventArgs e)
        {
        }

        private void btnPhong_StyleChanged(object sender, EventArgs e)
        {

        }

        private void btnNganh_Click(object sender, EventArgs e)
        {
            nganh.Location = new Point(185, 25);
            tabQuanLy.Controls.Add(nganh);
        }

        private void btnLop_Click(object sender, EventArgs e)
        {
            lop.Location = new Point(185, 25);
            tabQuanLy.Controls.Add(lop);
        }

        private void btnHocPhan_Click(object sender, EventArgs e)
        {
            hp.Location = new Point(185, 25);
            tabQuanLy.Controls.Add(hp);
        }

        private void btnCTDT_Click(object sender, EventArgs e)
        {
            ctdt.Location = new Point(185, 25);
            tabQuanLy.Controls.Add(ctdt);
        }
    }
}
