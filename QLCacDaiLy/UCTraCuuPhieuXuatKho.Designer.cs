namespace QLCacDaiLy
{
    partial class UCTraCuuPhieuXuatKho
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
            this.label2 = new System.Windows.Forms.Label();
            this.dgvPhieuXuatHang = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtNgayXuatPhieu = new System.Windows.Forms.DateTimePicker();
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.txtTenDL = new System.Windows.Forms.TextBox();
            this.txtMaDL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuXuatHang)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(121, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(475, 38);
            this.label2.TabIndex = 2;
            this.label2.Text = "TRA CỨU PHIẾU XUẤT HÀNG";
            // 
            // dgvPhieuXuatHang
            // 
            this.dgvPhieuXuatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuXuatHang.Location = new System.Drawing.Point(19, 131);
            this.dgvPhieuXuatHang.Name = "dgvPhieuXuatHang";
            this.dgvPhieuXuatHang.RowHeadersWidth = 51;
            this.dgvPhieuXuatHang.RowTemplate.Height = 24;
            this.dgvPhieuXuatHang.Size = new System.Drawing.Size(645, 417);
            this.dgvPhieuXuatHang.TabIndex = 11;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(539, 554);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(98, 36);
            this.btnRefresh.TabIndex = 44;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtNgayXuatPhieu
            // 
            this.txtNgayXuatPhieu.Location = new System.Drawing.Point(414, 92);
            this.txtNgayXuatPhieu.Name = "txtNgayXuatPhieu";
            this.txtNgayXuatPhieu.Size = new System.Drawing.Size(240, 27);
            this.txtNgayXuatPhieu.TabIndex = 52;
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Location = new System.Drawing.Point(116, 92);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.Size = new System.Drawing.Size(141, 27);
            this.txtMaPhieu.TabIndex = 51;
            this.txtMaPhieu.TextChanged += new System.EventHandler(this.txtMaPhieu_TextChanged);
            // 
            // txtTenDL
            // 
            this.txtTenDL.Location = new System.Drawing.Point(414, 57);
            this.txtTenDL.Name = "txtTenDL";
            this.txtTenDL.Size = new System.Drawing.Size(240, 27);
            this.txtTenDL.TabIndex = 50;
            this.txtTenDL.TextChanged += new System.EventHandler(this.txtTenDL_TextChanged);
            // 
            // txtMaDL
            // 
            this.txtMaDL.Location = new System.Drawing.Point(116, 59);
            this.txtMaDL.Name = "txtMaDL";
            this.txtMaDL.Size = new System.Drawing.Size(141, 27);
            this.txtMaDL.TabIndex = 49;
            this.txtMaDL.TextChanged += new System.EventHandler(this.txtMaDL_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 20);
            this.label5.TabIndex = 48;
            this.label5.Text = "Ngày xuất phiếu:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 47;
            this.label4.Text = "Mã phiếu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 46;
            this.label3.Text = "Tên đại lý:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 45;
            this.label1.Text = "Mã đại lý:";
            // 
            // UCTraCuuPhieuXuatKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNgayXuatPhieu);
            this.Controls.Add(this.txtMaPhieu);
            this.Controls.Add(this.txtTenDL);
            this.Controls.Add(this.txtMaDL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvPhieuXuatHang);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCTraCuuPhieuXuatKho";
            this.Size = new System.Drawing.Size(678, 604);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuXuatHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvPhieuXuatHang;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DateTimePicker txtNgayXuatPhieu;
        private System.Windows.Forms.TextBox txtMaPhieu;
        private System.Windows.Forms.TextBox txtTenDL;
        private System.Windows.Forms.TextBox txtMaDL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}
