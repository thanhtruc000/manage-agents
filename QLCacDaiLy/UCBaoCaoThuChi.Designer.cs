namespace QLCacDaiLy
{
    partial class UCBaoCaoThuChi
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtThangBC = new System.Windows.Forms.DateTimePicker();
            this.dgvBCChi = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvBCThu = new System.Windows.Forms.DataGridView();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tvTongChi = new System.Windows.Forms.Label();
            this.tvTongThu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBCChi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBCThu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(180, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO THU CHI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tháng:";
            // 
            // txtThangBC
            // 
            this.txtThangBC.Location = new System.Drawing.Point(325, 41);
            this.txtThangBC.Name = "txtThangBC";
            this.txtThangBC.Size = new System.Drawing.Size(91, 27);
            this.txtThangBC.TabIndex = 2;
            // 
            // dgvBCChi
            // 
            this.dgvBCChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBCChi.Location = new System.Drawing.Point(13, 97);
            this.dgvBCChi.Name = "dgvBCChi";
            this.dgvBCChi.RowHeadersWidth = 51;
            this.dgvBCChi.RowTemplate.Height = 24;
            this.dgvBCChi.Size = new System.Drawing.Size(652, 182);
            this.dgvBCChi.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Đã chi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(365, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tổng chi:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 317);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Đã thu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(365, 525);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Tổng thu:";
            // 
            // dgvBCThu
            // 
            this.dgvBCThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBCThu.Location = new System.Drawing.Point(13, 339);
            this.dgvBCThu.Name = "dgvBCThu";
            this.dgvBCThu.RowHeadersWidth = 51;
            this.dgvBCThu.RowTemplate.Height = 24;
            this.dgvBCThu.Size = new System.Drawing.Size(652, 182);
            this.dgvBCThu.TabIndex = 8;
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Location = new System.Drawing.Point(510, 554);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(88, 36);
            this.btnBaoCao.TabIndex = 11;
            this.btnBaoCao.Text = "Báo cáo";
            this.btnBaoCao.UseVisualStyleBackColor = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(406, 554);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(98, 36);
            this.btnRefresh.TabIndex = 44;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tvTongChi
            // 
            this.tvTongChi.AutoSize = true;
            this.tvTongChi.Location = new System.Drawing.Point(437, 280);
            this.tvTongChi.Name = "tvTongChi";
            this.tvTongChi.Size = new System.Drawing.Size(0, 20);
            this.tvTongChi.TabIndex = 45;
            // 
            // tvTongThu
            // 
            this.tvTongThu.AutoSize = true;
            this.tvTongThu.Location = new System.Drawing.Point(437, 525);
            this.tvTongThu.Name = "tvTongThu";
            this.tvTongThu.Size = new System.Drawing.Size(0, 20);
            this.tvTongThu.TabIndex = 46;
            // 
            // UCBaoCaoThuChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvTongThu);
            this.Controls.Add(this.tvTongChi);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnBaoCao);
            this.Controls.Add(this.dgvBCThu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvBCChi);
            this.Controls.Add(this.txtThangBC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCBaoCaoThuChi";
            this.Size = new System.Drawing.Size(678, 604);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBCChi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBCThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtThangBC;
        private System.Windows.Forms.DataGridView dgvBCChi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvBCThu;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label tvTongChi;
        private System.Windows.Forms.Label tvTongThu;
    }
}
