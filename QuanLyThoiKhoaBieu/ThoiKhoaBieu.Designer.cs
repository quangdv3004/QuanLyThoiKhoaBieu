
namespace QuanLyThoiKhoaBieu
{
    partial class ThoiKhoaBieu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTrangChu = new System.Windows.Forms.TabPage();
            this.tabHeThong = new System.Windows.Forms.TabPage();
            this.tabQuanLy = new System.Windows.Forms.TabPage();
            this.btnLop = new System.Windows.Forms.Button();
            this.btnSinhVien = new System.Windows.Forms.Button();
            this.btnNganh = new System.Windows.Forms.Button();
            this.btnTKB = new System.Windows.Forms.Button();
            this.btnCTCTDT = new System.Windows.Forms.Button();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnPCGD = new System.Windows.Forms.Button();
            this.btnKhoa = new System.Windows.Forms.Button();
            this.btnCTDT = new System.Windows.Forms.Button();
            this.btnHKNK = new System.Windows.Forms.Button();
            this.btnHocPhan = new System.Windows.Forms.Button();
            this.btnGiangVien = new System.Windows.Forms.Button();
            this.btnPhong = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabQuanLy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.CausesValidation = false;
            this.tabControl1.Controls.Add(this.tabTrangChu);
            this.tabControl1.Controls.Add(this.tabHeThong);
            this.tabControl1.Controls.Add(this.tabQuanLy);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1478, 617);
            this.tabControl1.TabIndex = 0;
            // 
            // tabTrangChu
            // 
            this.tabTrangChu.BackColor = System.Drawing.Color.White;
            this.tabTrangChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTrangChu.Location = new System.Drawing.Point(4, 29);
            this.tabTrangChu.Margin = new System.Windows.Forms.Padding(4);
            this.tabTrangChu.Name = "tabTrangChu";
            this.tabTrangChu.Padding = new System.Windows.Forms.Padding(4);
            this.tabTrangChu.Size = new System.Drawing.Size(1470, 584);
            this.tabTrangChu.TabIndex = 0;
            this.tabTrangChu.Text = "Trang chủ";
            // 
            // tabHeThong
            // 
            this.tabHeThong.BackColor = System.Drawing.Color.White;
            this.tabHeThong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabHeThong.Location = new System.Drawing.Point(4, 29);
            this.tabHeThong.Margin = new System.Windows.Forms.Padding(4);
            this.tabHeThong.Name = "tabHeThong";
            this.tabHeThong.Padding = new System.Windows.Forms.Padding(4);
            this.tabHeThong.Size = new System.Drawing.Size(1470, 584);
            this.tabHeThong.TabIndex = 1;
            this.tabHeThong.Text = "Hệ thống";
            this.tabHeThong.Click += new System.EventHandler(this.tabHeThong_Click);
            // 
            // tabQuanLy
            // 
            this.tabQuanLy.BackColor = System.Drawing.Color.White;
            this.tabQuanLy.Controls.Add(this.pictureBox1);
            this.tabQuanLy.Controls.Add(this.btnLop);
            this.tabQuanLy.Controls.Add(this.btnSinhVien);
            this.tabQuanLy.Controls.Add(this.btnNganh);
            this.tabQuanLy.Controls.Add(this.btnTKB);
            this.tabQuanLy.Controls.Add(this.btnCTCTDT);
            this.tabQuanLy.Controls.Add(this.btnDangKy);
            this.tabQuanLy.Controls.Add(this.btnPCGD);
            this.tabQuanLy.Controls.Add(this.btnKhoa);
            this.tabQuanLy.Controls.Add(this.btnCTDT);
            this.tabQuanLy.Controls.Add(this.btnHKNK);
            this.tabQuanLy.Controls.Add(this.btnHocPhan);
            this.tabQuanLy.Controls.Add(this.btnGiangVien);
            this.tabQuanLy.Controls.Add(this.btnPhong);
            this.tabQuanLy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabQuanLy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabQuanLy.Location = new System.Drawing.Point(4, 29);
            this.tabQuanLy.Margin = new System.Windows.Forms.Padding(4);
            this.tabQuanLy.Name = "tabQuanLy";
            this.tabQuanLy.Size = new System.Drawing.Size(1470, 584);
            this.tabQuanLy.TabIndex = 2;
            this.tabQuanLy.Text = "Quản lý";
            this.tabQuanLy.Click += new System.EventHandler(this.tabQuanLy_Click);
            // 
            // btnLop
            // 
            this.btnLop.Location = new System.Drawing.Point(556, -1);
            this.btnLop.Name = "btnLop";
            this.btnLop.Size = new System.Drawing.Size(90, 34);
            this.btnLop.TabIndex = 0;
            this.btnLop.Text = "Lớp";
            this.btnLop.UseVisualStyleBackColor = true;
            this.btnLop.Click += new System.EventHandler(this.btnLop_Click);
            // 
            // btnSinhVien
            // 
            this.btnSinhVien.Location = new System.Drawing.Point(923, -1);
            this.btnSinhVien.Name = "btnSinhVien";
            this.btnSinhVien.Size = new System.Drawing.Size(90, 34);
            this.btnSinhVien.TabIndex = 0;
            this.btnSinhVien.Text = "Sinh viên";
            this.btnSinhVien.UseVisualStyleBackColor = true;
            // 
            // btnNganh
            // 
            this.btnNganh.Location = new System.Drawing.Point(467, -1);
            this.btnNganh.Name = "btnNganh";
            this.btnNganh.Size = new System.Drawing.Size(90, 34);
            this.btnNganh.TabIndex = 0;
            this.btnNganh.Text = "Ngành";
            this.btnNganh.UseVisualStyleBackColor = true;
            this.btnNganh.Click += new System.EventHandler(this.btnNganh_Click);
            // 
            // btnTKB
            // 
            this.btnTKB.Location = new System.Drawing.Point(1100, -1);
            this.btnTKB.Name = "btnTKB";
            this.btnTKB.Size = new System.Drawing.Size(90, 34);
            this.btnTKB.TabIndex = 0;
            this.btnTKB.Text = "TKB";
            this.btnTKB.UseVisualStyleBackColor = true;
            // 
            // btnCTCTDT
            // 
            this.btnCTCTDT.Location = new System.Drawing.Point(823, -1);
            this.btnCTCTDT.Name = "btnCTCTDT";
            this.btnCTCTDT.Size = new System.Drawing.Size(101, 34);
            this.btnCTCTDT.TabIndex = 0;
            this.btnCTCTDT.Text = "CT_CTDT";
            this.btnCTCTDT.UseVisualStyleBackColor = true;
            // 
            // btnDangKy
            // 
            this.btnDangKy.Location = new System.Drawing.Point(378, -1);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(90, 34);
            this.btnDangKy.TabIndex = 0;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnPCGD
            // 
            this.btnPCGD.Location = new System.Drawing.Point(1012, -1);
            this.btnPCGD.Name = "btnPCGD";
            this.btnPCGD.Size = new System.Drawing.Size(90, 34);
            this.btnPCGD.TabIndex = 0;
            this.btnPCGD.Text = "PCGD";
            this.btnPCGD.UseVisualStyleBackColor = true;
            // 
            // btnKhoa
            // 
            this.btnKhoa.Location = new System.Drawing.Point(200, -1);
            this.btnKhoa.Name = "btnKhoa";
            this.btnKhoa.Size = new System.Drawing.Size(90, 34);
            this.btnKhoa.TabIndex = 0;
            this.btnKhoa.Text = "Khoa";
            this.btnKhoa.UseVisualStyleBackColor = true;
            this.btnKhoa.Click += new System.EventHandler(this.btnKhoa_Click);
            // 
            // btnCTDT
            // 
            this.btnCTDT.Location = new System.Drawing.Point(734, -1);
            this.btnCTDT.Name = "btnCTDT";
            this.btnCTDT.Size = new System.Drawing.Size(90, 34);
            this.btnCTDT.TabIndex = 0;
            this.btnCTDT.Text = "CTDT";
            this.btnCTDT.UseVisualStyleBackColor = true;
            this.btnCTDT.Click += new System.EventHandler(this.btnCTDT_Click);
            // 
            // btnHKNK
            // 
            this.btnHKNK.Location = new System.Drawing.Point(289, -1);
            this.btnHKNK.Name = "btnHKNK";
            this.btnHKNK.Size = new System.Drawing.Size(90, 34);
            this.btnHKNK.TabIndex = 0;
            this.btnHKNK.Text = "HK_NK";
            this.btnHKNK.UseVisualStyleBackColor = true;
            this.btnHKNK.Click += new System.EventHandler(this.btnHKNK_Click);
            // 
            // btnHocPhan
            // 
            this.btnHocPhan.Location = new System.Drawing.Point(645, -1);
            this.btnHocPhan.Name = "btnHocPhan";
            this.btnHocPhan.Size = new System.Drawing.Size(90, 34);
            this.btnHocPhan.TabIndex = 0;
            this.btnHocPhan.Text = "Học phần";
            this.btnHocPhan.UseVisualStyleBackColor = true;
            this.btnHocPhan.Click += new System.EventHandler(this.btnHocPhan_Click);
            // 
            // btnGiangVien
            // 
            this.btnGiangVien.Location = new System.Drawing.Point(90, -1);
            this.btnGiangVien.Name = "btnGiangVien";
            this.btnGiangVien.Size = new System.Drawing.Size(111, 34);
            this.btnGiangVien.TabIndex = 0;
            this.btnGiangVien.Text = "Giảng viên";
            this.btnGiangVien.UseVisualStyleBackColor = true;
            this.btnGiangVien.Click += new System.EventHandler(this.btnGiangVien_Click);
            // 
            // btnPhong
            // 
            this.btnPhong.Location = new System.Drawing.Point(1, -1);
            this.btnPhong.Name = "btnPhong";
            this.btnPhong.Size = new System.Drawing.Size(90, 34);
            this.btnPhong.TabIndex = 0;
            this.btnPhong.Text = "Phòng";
            this.btnPhong.UseVisualStyleBackColor = true;
            this.btnPhong.Click += new System.EventHandler(this.btnPhong_Click);
            this.btnPhong.MouseLeave += new System.EventHandler(this.btnPhong_MouseLeave);
            this.btnPhong.ChangeUICues += new System.Windows.Forms.UICuesEventHandler(this.btnPhong_ChangeUICues);
            this.btnPhong.StyleChanged += new System.EventHandler(this.btnPhong_StyleChanged);
            this.btnPhong.SystemColorsChanged += new System.EventHandler(this.btnPhong_SystemColorsChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyThoiKhoaBieu.Properties.Resources.wall_calendar_clip_branding_mockup_460658_215;
            this.pictureBox1.Location = new System.Drawing.Point(0, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(241, 564);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ThoiKhoaBieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 617);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ThoiKhoaBieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thời khóa biểu";
            this.Load += new System.EventHandler(this.ThoiKhoaBieu_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabQuanLy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTrangChu;
        private System.Windows.Forms.TabPage tabHeThong;
        private System.Windows.Forms.TabPage tabQuanLy;
        private System.Windows.Forms.Button btnLop;
        private System.Windows.Forms.Button btnSinhVien;
        private System.Windows.Forms.Button btnNganh;
        private System.Windows.Forms.Button btnTKB;
        private System.Windows.Forms.Button btnCTCTDT;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnPCGD;
        private System.Windows.Forms.Button btnKhoa;
        private System.Windows.Forms.Button btnCTDT;
        private System.Windows.Forms.Button btnHKNK;
        private System.Windows.Forms.Button btnHocPhan;
        private System.Windows.Forms.Button btnGiangVien;
        private System.Windows.Forms.Button btnPhong;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}