using QuanLyThoiKhoaBieu.Model;
using QuanLyThoiKhoaBieu.Services;
using QuanLyThoiKhoaBieu.UserControlsView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuanLyThoiKhoaBieu.ThoiKhoaBieu;

namespace QuanLyThoiKhoaBieu
{

    public partial class ThoiKhoaBieu : Form
    {
        public class formActions
        {
            public string name { get;}
            public UserControl view { get; set; }
            public bool active { get; set; } = false;
            public Control FormControl { get; set; }

            public formActions(Control f, UserControl View)
            {
                if(View != null)
                {
                    view= View;
                    FormControl = f;
                    name = view.Name;
                    view.Location = new Point(185, 25);
                }
            }
        }
        List<formActions> actions = new List<formActions>();
        ScheduleManagementEntities model = new ScheduleManagementEntities();
        SinhVien sv;

        public ThoiKhoaBieu()
        {
            InitializeComponent();
        }

        private void tabHeThong_Click(object sender, EventArgs e)
        {
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            reloadViewControl();
            setHideAndPush("PhongView");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnGiangVien_Click(object sender, EventArgs e)
        {
            reloadViewControl();
            setHideAndPush("GiangVienView");
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            reloadViewControl();
            setHideAndPush("KhoaView");
        }

        private void btnHKNK_Click(object sender, EventArgs e)
        {
            reloadViewControl();
            setHideAndPush("HocKyView");
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            reloadViewControl();
            setHideAndPush("DangKyView");
        }

        private void tabQuanLy_Click(object sender, EventArgs e)
        {

        }
        private void setHideAndPush(string formName)
        {
            foreach(formActions viewActive in actions.Where(u => u.active == true))
            {
                if(formName == viewActive.name)
                {
                    continue;

                }
                viewActive.FormControl.Controls.Remove(viewActive.view);
                viewActive.active = false;
            }
            if(!actions.Any(u => u.name == formName &&  u.active == true))
            {
                var view = actions.LastOrDefault(u => u.name == formName && u.active == false);
                if(view != null)
                {
                    view.FormControl.Controls.Add(view.view);
                    view.active = true;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy view");
                }
              
            }
        }
        private void ThoiKhoaBieu_Load(object sender, EventArgs e)
        {
            actions.Add(new formActions(tabQuanLy, new PhongView()));
            actions.Add(new formActions(tabQuanLy, new DangKyView()));
            actions.Add(new formActions(tabQuanLy, new GiangVienView()));
            actions.Add(new formActions(tabQuanLy, new KhoaView()));
            actions.Add(new formActions(tabQuanLy, new NganhView()));

            actions.Add(new formActions(tabQuanLy, new HocKyView()));
            actions.Add(new formActions(tabQuanLy, new LopView()));
            actions.Add(new formActions(tabQuanLy, new HocPhanView()));
            actions.Add(new formActions(tabQuanLy, new CTDTView()));
            actions.Add(new formActions(tabQuanLy, new PCGDView()));
            actions.Add(new formActions(tabQuanLy, new UserControlsView.ChiTietCTDT()));

            sv = model.SinhViens.FirstOrDefault(u => u.maSV == Program.userLogged.maSV);
            if (sv.maSV != 1)
            {
                pbAvatar1.Image = byteArratToImage(sv.avatar);
                lbLop.Text = sv.Lop_QL.tenLop;
                lbHoTen1.Text = sv.tenSV;
                DateTime dt = DateTime.ParseExact(sv.ngaySinh.ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

                string s = dt.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                lbNgaySinh.Text = s;
            }

            lbGioiTinh.Text = sv.gioiTinh == true ? "Nam" : "Nữ";
            lbDiaChi.Text = sv.diaChi;
            lbEmail.Text = sv.email;
            lbDienThoai.Text = sv.dienThoai;
            lbTenSV.Text = sv.tenSV + " !";

            ShowGridView.showDataGridView(dataGridViewtkb, model.sp_danhSachTKBThree());
            ShowGridView.showDataGridView(dataGridLop, model.sp_danhSachLopQuanLy());
            ShowGridView.showDataGridView(dataGridKhoa, model.sp_danhSanhKhoa());
        }

        public byte[] imageToByteArr(Image img)
        {
            if (img != null)
            {
                ImageConverter image = new ImageConverter();
                byte[] xbyte = (byte[])image.ConvertTo(img, typeof(byte[]));
                return xbyte;
            }
            return null;
        }

        public Image byteArratToImage(byte[] Arr)
        {
            if (Arr != null)
            {
                Image bmp = (Bitmap)((new ImageConverter()).ConvertFrom(Arr));
                return bmp;
            }
            return null;

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
            reloadViewControl();
            setHideAndPush("NganhView");
        }

        private void btnLop_Click(object sender, EventArgs e)
        {
            reloadViewControl();
            setHideAndPush("LopView");
        }

        private void btnHocPhan_Click(object sender, EventArgs e)
        {
            reloadViewControl();
            setHideAndPush("HocPhanView");
        }

        private void btnCTDT_Click(object sender, EventArgs e)
        {
            reloadViewControl();
            setHideAndPush("CTDTView");
        }

        private void ThoiKhoaBieu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnCTCTDT_Click(object sender, EventArgs e)
        {
            reloadViewControl();
            setHideAndPush("ChiTietCTDT");
        }

        private void reloadViewControl()
        {
            actions.Add(new formActions(tabQuanLy, new PhongView()));
            actions.Add(new formActions(tabQuanLy, new DangKyView()));
            actions.Add(new formActions(tabQuanLy, new GiangVienView()));
            actions.Add(new formActions(tabQuanLy, new KhoaView()));
            actions.Add(new formActions(tabQuanLy, new NganhView()));
            actions.Add(new formActions(tabQuanLy, new HocKyView()));
            actions.Add(new formActions(tabQuanLy, new LopView()));
            actions.Add(new formActions(tabQuanLy, new HocPhanView()));
            actions.Add(new formActions(tabQuanLy, new CTDTView()));
            actions.Add(new formActions(tabQuanLy, new SinhVienView()));
            actions.Add(new formActions(tabQuanLy, new PCGDView()));
            actions.Add(new formActions(tabQuanLy, new ThoiKhoaBieuView()));
            actions.Add(new formActions(tabQuanLy, new UserControlsView.ChiTietCTDT()));
        }

        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            reloadViewControl();
            setHideAndPush("SinhVienView");
        }

        private void btnPCGD_Click(object sender, EventArgs e)
        {
            reloadViewControl();
            setHideAndPush("PCGDView");
        }

        private void btnTKB_Click(object sender, EventArgs e)
        {
            reloadViewControl();
            setHideAndPush("ThoiKhoaBieuView");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Program.userLogged = null;
            this.Hide();
            MessageBox.Show("Bạn đã đăng xuất, vui lòng đăng nhập lại để sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form1 f = new Form1();
            f.Show();
        }

        private void lbTenSV_Click(object sender, EventArgs e)
        {

        }

        private void pbAvatar1_Click(object sender, EventArgs e)
        {

        }

        private void lbLop_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
