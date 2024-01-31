namespace QLCacDaiLy
{
    partial class UCTraCuuLSHHBanRa
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_TraCuuLSHHBanRa = new System.Windows.Forms.DataGridView();
            this.txtTenHH = new System.Windows.Forms.TextBox();
            this.txtMaHH = new System.Windows.Forms.TextBox();
            this.dtNgayBan = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TraCuuLSHHBanRa)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(82, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(620, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "TRA CỨU LỊCH SỬ HÀNG HÓA BÁN RA";
            // 
            // dgv_TraCuuLSHHBanRa
            // 
            this.dgv_TraCuuLSHHBanRa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TraCuuLSHHBanRa.Location = new System.Drawing.Point(15, 151);
            this.dgv_TraCuuLSHHBanRa.Name = "dgv_TraCuuLSHHBanRa";
            this.dgv_TraCuuLSHHBanRa.RowHeadersWidth = 51;
            this.dgv_TraCuuLSHHBanRa.RowTemplate.Height = 24;
            this.dgv_TraCuuLSHHBanRa.Size = new System.Drawing.Size(648, 436);
            this.dgv_TraCuuLSHHBanRa.TabIndex = 7;
            // 
            // txtTenHH
            // 
            this.txtTenHH.Location = new System.Drawing.Point(392, 68);
            this.txtTenHH.Name = "txtTenHH";
            this.txtTenHH.Size = new System.Drawing.Size(271, 27);
            this.txtTenHH.TabIndex = 13;
            this.txtTenHH.TextChanged += new System.EventHandler(this.txtTenHH_TextChanged);
            // 
            // txtMaHH
            // 
            this.txtMaHH.Location = new System.Drawing.Point(147, 68);
            this.txtMaHH.Name = "txtMaHH";
            this.txtMaHH.Size = new System.Drawing.Size(95, 27);
            this.txtMaHH.TabIndex = 12;
            this.txtMaHH.TextChanged += new System.EventHandler(this.txtMaHH_TextChanged);
            // 
            // dtNgayBan
            // 
            this.dtNgayBan.Location = new System.Drawing.Point(206, 111);
            this.dtNgayBan.Name = "dtNgayBan";
            this.dtNgayBan.Size = new System.Drawing.Size(299, 27);
            this.dtNgayBan.TabIndex = 11;
            this.dtNgayBan.ValueChanged += new System.EventHandler(this.dtNgayBan_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(106, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ngày bán:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tên hàng hóa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mã hàng hóa:";
            // 
            // UCTraCuuLSHHBanRa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtTenHH);
            this.Controls.Add(this.txtMaHH);
            this.Controls.Add(this.dtNgayBan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv_TraCuuLSHHBanRa);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCTraCuuLSHHBanRa";
            this.Size = new System.Drawing.Size(678, 604);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TraCuuLSHHBanRa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_TraCuuLSHHBanRa;
        private System.Windows.Forms.TextBox txtTenHH;
        private System.Windows.Forms.TextBox txtMaHH;
        private System.Windows.Forms.DateTimePicker dtNgayBan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
