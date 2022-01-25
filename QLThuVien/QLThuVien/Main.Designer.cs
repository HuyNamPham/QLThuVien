namespace QLThuVien
{
    partial class Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenDN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQuyen = new System.Windows.Forms.TextBox();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnQLSach = new System.Windows.Forms.Button();
            this.btnHoSo = new System.Windows.Forms.Button();
            this.btnQLTaiKhoan = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnQLMuonTra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(256, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý thư viện";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên đăng nhập";
            // 
            // txtTenDN
            // 
            this.txtTenDN.Enabled = false;
            this.txtTenDN.Location = new System.Drawing.Point(169, 43);
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.Size = new System.Drawing.Size(77, 20);
            this.txtTenDN.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Họ tên";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Enabled = false;
            this.txtHoTen.Location = new System.Drawing.Point(338, 43);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(142, 20);
            this.txtHoTen.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Quyền";
            // 
            // txtQuyen
            // 
            this.txtQuyen.Enabled = false;
            this.txtQuyen.Location = new System.Drawing.Point(169, 84);
            this.txtQuyen.Name = "txtQuyen";
            this.txtQuyen.Size = new System.Drawing.Size(95, 20);
            this.txtQuyen.TabIndex = 2;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Location = new System.Drawing.Point(519, 40);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(75, 23);
            this.btnDangXuat.TabIndex = 3;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnQLSach
            // 
            this.btnQLSach.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnQLSach.Image = global::QLThuVien.Properties.Resources.QLSach;
            this.btnQLSach.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQLSach.Location = new System.Drawing.Point(80, 314);
            this.btnQLSach.Name = "btnQLSach";
            this.btnQLSach.Size = new System.Drawing.Size(207, 157);
            this.btnQLSach.TabIndex = 4;
            this.btnQLSach.Text = "Quản lý sách";
            this.btnQLSach.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQLSach.UseVisualStyleBackColor = true;
            this.btnQLSach.Click += new System.EventHandler(this.btnQLSach_Click);
            // 
            // btnHoSo
            // 
            this.btnHoSo.Location = new System.Drawing.Point(519, 81);
            this.btnHoSo.Name = "btnHoSo";
            this.btnHoSo.Size = new System.Drawing.Size(75, 23);
            this.btnHoSo.TabIndex = 5;
            this.btnHoSo.Text = "Hồ sơ";
            this.btnHoSo.UseVisualStyleBackColor = true;
            this.btnHoSo.Click += new System.EventHandler(this.btnHoSo_Click);
            // 
            // btnQLTaiKhoan
            // 
            this.btnQLTaiKhoan.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnQLTaiKhoan.Image = global::QLThuVien.Properties.Resources.QLTaiKhoan;
            this.btnQLTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQLTaiKhoan.Location = new System.Drawing.Point(413, 314);
            this.btnQLTaiKhoan.Name = "btnQLTaiKhoan";
            this.btnQLTaiKhoan.Size = new System.Drawing.Size(153, 157);
            this.btnQLTaiKhoan.TabIndex = 7;
            this.btnQLTaiKhoan.Text = "Quản lý tài khoản";
            this.btnQLTaiKhoan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQLTaiKhoan.UseVisualStyleBackColor = true;
            this.btnQLTaiKhoan.Click += new System.EventHandler(this.btnQLTaiKhoan_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(616, 40);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnThongKe.Image = global::QLThuVien.Properties.Resources.ThongKe;
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnThongKe.Location = new System.Drawing.Point(413, 130);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(153, 156);
            this.btnThongKe.TabIndex = 9;
            this.btnThongKe.Text = "Thống kê báo cáo";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnQLMuonTra
            // 
            this.btnQLMuonTra.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnQLMuonTra.Image = global::QLThuVien.Properties.Resources.QLMuonTra;
            this.btnQLMuonTra.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQLMuonTra.Location = new System.Drawing.Point(80, 130);
            this.btnQLMuonTra.Name = "btnQLMuonTra";
            this.btnQLMuonTra.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnQLMuonTra.Size = new System.Drawing.Size(207, 156);
            this.btnQLMuonTra.TabIndex = 6;
            this.btnQLMuonTra.Text = "Quản lý mượn trả";
            this.btnQLMuonTra.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQLMuonTra.UseVisualStyleBackColor = true;
            this.btnQLMuonTra.Click += new System.EventHandler(this.btnQLMuonTra_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 498);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnQLTaiKhoan);
            this.Controls.Add(this.btnQLMuonTra);
            this.Controls.Add(this.btnHoSo);
            this.Controls.Add(this.btnQLSach);
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.txtQuyen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTenDN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý thư viện";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenDN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQuyen;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnQLSach;
        private System.Windows.Forms.Button btnHoSo;
        private System.Windows.Forms.Button btnQLMuonTra;
        private System.Windows.Forms.Button btnQLTaiKhoan;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnThongKe;
    }
}