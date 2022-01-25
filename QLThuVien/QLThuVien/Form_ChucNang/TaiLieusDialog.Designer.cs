namespace QLThuVien.Form_ChucNang
{
    partial class TaiLieusDialog
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
            this.dgvTaiLieus = new System.Windows.Forms.DataGridView();
            this.MaTaiLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTaiLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongMuon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhaXB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TacGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiLieus)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTaiLieus
            // 
            this.dgvTaiLieus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaiLieus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTaiLieu,
            this.TenTaiLieu,
            this.SoLuongMuon,
            this.NhaXB,
            this.TacGia});
            this.dgvTaiLieus.Location = new System.Drawing.Point(12, 12);
            this.dgvTaiLieus.Name = "dgvTaiLieus";
            this.dgvTaiLieus.Size = new System.Drawing.Size(592, 201);
            this.dgvTaiLieus.TabIndex = 0;
            // 
            // MaTaiLieu
            // 
            this.MaTaiLieu.DataPropertyName = "MaTaiLieu";
            this.MaTaiLieu.HeaderText = "Mã tài liệu";
            this.MaTaiLieu.Name = "MaTaiLieu";
            // 
            // TenTaiLieu
            // 
            this.TenTaiLieu.DataPropertyName = "TenTaiLieu";
            this.TenTaiLieu.HeaderText = "Tên tài liệu";
            this.TenTaiLieu.Name = "TenTaiLieu";
            this.TenTaiLieu.Width = 120;
            // 
            // SoLuongMuon
            // 
            this.SoLuongMuon.DataPropertyName = "SoLuongMuon";
            this.SoLuongMuon.HeaderText = "Số lượng mượn";
            this.SoLuongMuon.Name = "SoLuongMuon";
            this.SoLuongMuon.Width = 105;
            // 
            // NhaXB
            // 
            this.NhaXB.DataPropertyName = "NhaXuatBan";
            this.NhaXB.HeaderText = "Nhà xuất bản";
            this.NhaXB.Name = "NhaXB";
            // 
            // TacGia
            // 
            this.TacGia.DataPropertyName = "TacGia";
            this.TacGia.HeaderText = "Tác giả";
            this.TacGia.Name = "TacGia";
            this.TacGia.Width = 120;
            // 
            // TaiLieusDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 223);
            this.Controls.Add(this.dgvTaiLieus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaiLieusDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách tài liệu mượn";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiLieus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTaiLieus;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTaiLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTaiLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongMuon;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhaXB;
        private System.Windows.Forms.DataGridViewTextBoxColumn TacGia;
    }
}