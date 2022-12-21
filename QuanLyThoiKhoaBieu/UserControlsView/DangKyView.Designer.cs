
namespace QuanLyThoiKhoaBieu.UserControlsView
{
    partial class DangKyView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBang = new System.Windows.Forms.GroupBox();
            this.dataGridThongTin = new System.Windows.Forms.DataGridView();
            this.groupThongTin = new System.Windows.Forms.GroupBox();
            this.cbHocPhan = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.cbMaPCGD = new System.Windows.Forms.ComboBox();
            this.cbGiangVien = new System.Windows.Forms.ComboBox();
            this.cbHocKy = new System.Windows.Forms.ComboBox();
            this.groupBang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridThongTin)).BeginInit();
            this.groupThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBang
            // 
            this.groupBang.Controls.Add(this.dataGridThongTin);
            this.groupBang.Location = new System.Drawing.Point(4, 229);
            this.groupBang.Margin = new System.Windows.Forms.Padding(4);
            this.groupBang.Name = "groupBang";
            this.groupBang.Padding = new System.Windows.Forms.Padding(4);
            this.groupBang.Size = new System.Drawing.Size(1001, 295);
            this.groupBang.TabIndex = 11;
            this.groupBang.TabStop = false;
            this.groupBang.Text = "Bảng";
            // 
            // dataGridThongTin
            // 
            this.dataGridThongTin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridThongTin.Location = new System.Drawing.Point(9, 23);
            this.dataGridThongTin.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridThongTin.Name = "dataGridThongTin";
            this.dataGridThongTin.RowHeadersWidth = 51;
            this.dataGridThongTin.RowTemplate.Height = 24;
            this.dataGridThongTin.Size = new System.Drawing.Size(984, 264);
            this.dataGridThongTin.TabIndex = 0;
            this.dataGridThongTin.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridThongTin_CellContentClick);
            // 
            // groupThongTin
            // 
            this.groupThongTin.Controls.Add(this.cbHocKy);
            this.groupThongTin.Controls.Add(this.cbGiangVien);
            this.groupThongTin.Controls.Add(this.cbMaPCGD);
            this.groupThongTin.Controls.Add(this.cbHocPhan);
            this.groupThongTin.Controls.Add(this.pictureBox2);
            this.groupThongTin.Controls.Add(this.txtSearch);
            this.groupThongTin.Controls.Add(this.label4);
            this.groupThongTin.Controls.Add(this.label5);
            this.groupThongTin.Controls.Add(this.label3);
            this.groupThongTin.Controls.Add(this.label2);
            this.groupThongTin.Controls.Add(this.txt1);
            this.groupThongTin.Controls.Add(this.label1);
            this.groupThongTin.Controls.Add(this.btnHuy);
            this.groupThongTin.Controls.Add(this.btnLuu);
            this.groupThongTin.Controls.Add(this.btnXoa);
            this.groupThongTin.Controls.Add(this.btnSua);
            this.groupThongTin.Controls.Add(this.btnThem);
            this.groupThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupThongTin.Location = new System.Drawing.Point(0, 5);
            this.groupThongTin.Margin = new System.Windows.Forms.Padding(4);
            this.groupThongTin.Name = "groupThongTin";
            this.groupThongTin.Padding = new System.Windows.Forms.Padding(4);
            this.groupThongTin.Size = new System.Drawing.Size(1005, 232);
            this.groupThongTin.TabIndex = 12;
            this.groupThongTin.TabStop = false;
            this.groupThongTin.Text = "Thông tin";
            // 
            // cbHocPhan
            // 
            this.cbHocPhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHocPhan.FormattingEnabled = true;
            this.cbHocPhan.Location = new System.Drawing.Point(1019, 102);
            this.cbHocPhan.Margin = new System.Windows.Forms.Padding(4);
            this.cbHocPhan.Name = "cbHocPhan";
            this.cbHocPhan.Size = new System.Drawing.Size(265, 32);
            this.cbHocPhan.TabIndex = 5;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::QuanLyThoiKhoaBieu.Properties.Resources.Start_Menu_Search_icon;
            this.pictureBox2.Location = new System.Drawing.Point(667, 19);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(55, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(729, 27);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(249, 26);
            this.txtSearch.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1015, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tên học phần";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 157);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Học kỳ";
            this.label5.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(669, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên giảng viên";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã PCGD";
            this.label2.Visible = false;
            // 
            // txt1
            // 
            this.txt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt1.Location = new System.Drawing.Point(13, 103);
            this.txt1.Margin = new System.Windows.Forms.Padding(4);
            this.txt1.Name = "txt1";
            this.txt1.ReadOnly = true;
            this.txt1.Size = new System.Drawing.Size(246, 28);
            this.txt1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã đăng kí";
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(453, 27);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(104, 39);
            this.btnHuy.TabIndex = 0;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(343, 27);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(104, 39);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(231, 27);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(104, 39);
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(120, 27);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(104, 39);
            this.btnSua.TabIndex = 0;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(8, 27);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(104, 39);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cbMaPCGD
            // 
            this.cbMaPCGD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMaPCGD.FormattingEnabled = true;
            this.cbMaPCGD.Location = new System.Drawing.Point(343, 103);
            this.cbMaPCGD.Margin = new System.Windows.Forms.Padding(4);
            this.cbMaPCGD.Name = "cbMaPCGD";
            this.cbMaPCGD.Size = new System.Drawing.Size(237, 32);
            this.cbMaPCGD.TabIndex = 5;
            // 
            // cbGiangVien
            // 
            this.cbGiangVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGiangVien.FormattingEnabled = true;
            this.cbGiangVien.Location = new System.Drawing.Point(673, 103);
            this.cbGiangVien.Margin = new System.Windows.Forms.Padding(4);
            this.cbGiangVien.Name = "cbGiangVien";
            this.cbGiangVien.Size = new System.Drawing.Size(265, 32);
            this.cbGiangVien.TabIndex = 5;
            // 
            // cbHocKy
            // 
            this.cbHocKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHocKy.FormattingEnabled = true;
            this.cbHocKy.Location = new System.Drawing.Point(13, 182);
            this.cbHocKy.Margin = new System.Windows.Forms.Padding(4);
            this.cbHocKy.Name = "cbHocKy";
            this.cbHocKy.Size = new System.Drawing.Size(246, 32);
            this.cbHocKy.TabIndex = 5;
            // 
            // DangKyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBang);
            this.Controls.Add(this.groupThongTin);
            this.Name = "DangKyView";
            this.Size = new System.Drawing.Size(1009, 528);
            this.Load += new System.EventHandler(this.DangKyView_Load);
            this.groupBang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridThongTin)).EndInit();
            this.groupThongTin.ResumeLayout(false);
            this.groupThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBang;
        private System.Windows.Forms.DataGridView dataGridThongTin;
        private System.Windows.Forms.GroupBox groupThongTin;
        private System.Windows.Forms.ComboBox cbHocPhan;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cbHocKy;
        private System.Windows.Forms.ComboBox cbGiangVien;
        private System.Windows.Forms.ComboBox cbMaPCGD;
    }
}
