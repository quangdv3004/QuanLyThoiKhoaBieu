using QuanLyThoiKhoaBieu.Model;
using QuanLyThoiKhoaBieu.Services;
using QuanLyThoiKhoaBieu.UserControlsView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public ThoiKhoaBieu()
        {
            InitializeComponent();
        }

        private void tabHeThong_Click(object sender, EventArgs e)
        {

        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            setHideAndPush("PhongView");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnGiangVien_Click(object sender, EventArgs e)
        {
            setHideAndPush("GiangVienView");
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            setHideAndPush("KhoaView");
        }

        private void btnHKNK_Click(object sender, EventArgs e)
        {
            setHideAndPush("HocKyView");
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
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
                var view = actions.FirstOrDefault(u => u.name == formName && u.active == false);
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
            actions.Add(new formActions(tabQuanLy, new DangKyView()) );
            actions.Add(new formActions(tabQuanLy, new GiangVienView()));
            actions.Add(new formActions(tabQuanLy, new KhoaView()));
            actions.Add(new formActions(tabQuanLy, new NganhView()));

            actions.Add(new formActions(tabQuanLy, new HocKyView()) );
            actions.Add(new formActions(tabQuanLy, new LopView()));
            actions.Add(new formActions(tabQuanLy, new HocPhanView()) );
            actions.Add(new formActions(tabQuanLy, new CTDTView()));
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
            setHideAndPush("NganhView");
        }

        private void btnLop_Click(object sender, EventArgs e)
        {
            setHideAndPush("LopView");
        }

        private void btnHocPhan_Click(object sender, EventArgs e)
        {
            setHideAndPush("HocPhanView");
        }

        private void btnCTDT_Click(object sender, EventArgs e)
        {
            setHideAndPush("CTDTView");
        }
    }
}
