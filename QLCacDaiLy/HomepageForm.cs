using QLCacDaiLy.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCacDaiLy
{
    public partial class Form1 : Form
    {
        private bool isCollapsed;
        public Form1()
        {
            InitializeComponent();
        }

        private void timerBaoCao_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                btnDropDownBaoCao.Image = Resources.Collapse_Arrow_20px;
                panelDropDownBaoCao.Height += 10;
               
                if (panelDropDownBaoCao.Size == panelDropDownBaoCao.MaximumSize)
                {
                    timerBaoCao.Stop();
                    isCollapsed = false;
                }  
            }

            else
            {
                btnDropDownBaoCao.Image = Resources.Expand_Arrow_20px;
                panelDropDownBaoCao.Height -= 10;
               
                if (panelDropDownBaoCao.Size == panelDropDownBaoCao.MinimumSize)
                {
                    timerBaoCao.Stop();
                    isCollapsed = true;
                }    
            }
        }

        private void btnDropDownBaoCao_Click(object sender, EventArgs e)
        {
            timerBaoCao.Start();
        }

        private void timerTraCuuHH_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                btnDropDownTraCuuHH.Image = Resources.Collapse_Arrow_20px;
                panelDropDownTraCuuHH.Height += 10;

                if (panelDropDownTraCuuHH.Size == panelDropDownTraCuuHH.MaximumSize)
                {
                    timerTraCuuHH.Stop();
                    isCollapsed = false;
                }
            }

            else
            {
                btnDropDownTraCuuHH.Image = Resources.Expand_Arrow_20px;
                panelDropDownTraCuuHH.Height -= 10;

                if (panelDropDownTraCuuHH.Size == panelDropDownTraCuuHH.MinimumSize)
                {
                    timerTraCuuHH.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void btnDropDownTraCuuHH_Click(object sender, EventArgs e)
        {
            timerTraCuuHH.Start();
        }

        private void timerXuatPhieu_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                btnDropDownXuatPhieu.Image = Resources.Collapse_Arrow_20px;
                panelDropDownXuatPhieu.Height += 10;

                if (panelDropDownXuatPhieu.Size == panelDropDownXuatPhieu.MaximumSize)
                {
                    timerXuatPhieu.Stop();
                    isCollapsed = false;
                }
            }

            else
            {
                btnDropDownXuatPhieu.Image = Resources.Expand_Arrow_20px;
                panelDropDownXuatPhieu.Height -= 10;

                if (panelDropDownXuatPhieu.Size == panelDropDownXuatPhieu.MinimumSize)
                {
                    timerXuatPhieu.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void btnDropDownXuatPhieu_Click(object sender, EventArgs e)
        {
            timerXuatPhieu.Start();
        }

        private void timerTraCuuPhieu_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                btnDropDownTraCuuPhieu.Image = Resources.Collapse_Arrow_20px;
                panelDropDownTraCuuPhieu.Height += 10;

                if (panelDropDownTraCuuPhieu.Size == panelDropDownTraCuuPhieu.MaximumSize)
                {
                    timerTraCuuPhieu.Stop();
                    isCollapsed = false;
                }
            }

            else
            {
                btnDropDownTraCuuPhieu.Image = Resources.Expand_Arrow_20px;
                panelDropDownTraCuuPhieu.Height -= 10;

                if (panelDropDownTraCuuPhieu.Size == panelDropDownTraCuuPhieu.MinimumSize)
                {
                    timerTraCuuPhieu.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void btnDropDownTraCuuPhieu_Click(object sender, EventArgs e)
        {
            timerTraCuuPhieu.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set giao diện ở tab Đại lý
            // Khi vừa bắt đầu chạy chương trình, chỉ cho UC Tiếp nhận hồ sơ được show
            ucTiepNhanHoSo1.Show();
            ucTraCuuDL1.Hide();
            ucXuatPhieuThuTien1.Hide();
            ucBaoCaoDoanhThuDL1.Hide();
            ucBaoCaoCongNoDL1.Hide();

            // Set giao diện ở tab Hàng hóa
            // Khi vừa bắt đầu chạy chương trình, chỉ cho UC Tiếp nhận thông tin được show
            ucTiepNhanThongTin1.Show();
            ucTraCuuHH1.Hide();
            ucTraCuuLSHHBanRa1.Hide();

            // Set giao diện ở tab Ưu đãi
            // Khi vừa bắt đầu chạy chương trình, chỉ cho UC Tiếp nhận ưu đãi được show
            ucTiepNhanUuDai1.Show();

            // Set giao diện ở tab Công ty
            // Khi vừa bắt đầu chạy chương trình, chỉ cho UC Báo cáo thu chi được show
            ucBaoCaoThuChi1.Show();
            ucXuatPhieuXuatKho1.Hide();
            ucXuatPhieuNhapKho1.Hide();
            ucTraCuuPhieuXuatKho1.Hide();
            ucTraCuuPhieuNhapKho1.Hide();
        }

        // Menu button ở tab Đại lý
        private void btnTiepNhanHoSo_Click(object sender, EventArgs e)
        {
            ucTiepNhanHoSo1.Show();
            ucTraCuuDL1.Hide();
            ucXuatPhieuThuTien1.Hide();
            ucBaoCaoDoanhThuDL1.Hide();
            ucBaoCaoCongNoDL1.Hide();
        }

        private void btnXuatPhieuThuTien_Click(object sender, EventArgs e)
        {
            ucTiepNhanHoSo1.Hide();
            ucTraCuuDL1.Hide();
            ucXuatPhieuThuTien1.Show();
            ucBaoCaoDoanhThuDL1.Hide();
            ucBaoCaoCongNoDL1.Hide();
        }

        private void btnTraCuuDL_Click(object sender, EventArgs e)
        {
            ucTiepNhanHoSo1.Hide();
            ucTraCuuDL1.Show();
            ucXuatPhieuThuTien1.Hide();
            ucBaoCaoDoanhThuDL1.Hide();
            ucBaoCaoCongNoDL1.Hide();
        }

        private void btnBCDoanhThuDL_Click(object sender, EventArgs e)
        {
            ucTiepNhanHoSo1.Hide();
            ucTraCuuDL1.Hide();
            ucXuatPhieuThuTien1.Hide();
            ucBaoCaoDoanhThuDL1.Show();
            ucBaoCaoCongNoDL1.Hide();
        }

        private void btnBCCongNoDL_Click(object sender, EventArgs e)
        {
            ucTiepNhanHoSo1.Hide();
            ucTraCuuDL1.Hide();
            ucXuatPhieuThuTien1.Hide();
            ucBaoCaoDoanhThuDL1.Hide();
            ucBaoCaoCongNoDL1.Show();
        }

        // Menu button ở tab Hàng hóa
        private void btnTiepNhanThongTin_Click(object sender, EventArgs e)
        {
            ucTiepNhanThongTin1.Show();
            ucTraCuuHH1.Hide();
            ucTraCuuLSHHBanRa1.Hide();
        }

        private void btnTraCuuHH_Click(object sender, EventArgs e)
        {
            ucTraCuuHH1.Show();
            ucTiepNhanThongTin1.Hide();
            ucTraCuuLSHHBanRa1.Hide();
        }

        private void btnTraCuuLSHH_Click(object sender, EventArgs e)
        {
            ucTraCuuLSHHBanRa1.Show();
            ucTraCuuHH1.Hide();
            ucTiepNhanThongTin1.Hide();
        }

        // Menu button ở tab Ưu đãi
        private void btnTiepNhanUuDai_Click(object sender, EventArgs e)
        {
            ucTiepNhanUuDai1.Show();
        }


        // Menu button ở tab Công ty
        private void btnBaoCaoThuChi_Click(object sender, EventArgs e)
        {
            ucBaoCaoThuChi1.Show();
            ucXuatPhieuXuatKho1.Hide();
            ucXuatPhieuNhapKho1.Hide();
            ucTraCuuPhieuXuatKho1.Hide();
            ucTraCuuPhieuNhapKho1.Hide();
        }

        private void btnXuatPhieuXuatKho_Click(object sender, EventArgs e)
        {
            ucBaoCaoThuChi1.Hide();
            ucXuatPhieuXuatKho1.Show();
            ucXuatPhieuNhapKho1.Hide();
            ucTraCuuPhieuXuatKho1.Hide();
            ucTraCuuPhieuNhapKho1.Hide();
        }

        private void btnXuatPhieuNhapKho_Click(object sender, EventArgs e)
        {
            ucBaoCaoThuChi1.Hide();
            ucXuatPhieuXuatKho1.Hide();
            ucXuatPhieuNhapKho1.Show();
            ucTraCuuPhieuXuatKho1.Hide();
            ucTraCuuPhieuNhapKho1.Hide();
        }

        private void btnTraCuuPhieuXuatKho_Click(object sender, EventArgs e)
        {
            ucBaoCaoThuChi1.Hide();
            ucXuatPhieuXuatKho1.Hide();
            ucXuatPhieuNhapKho1.Hide();
            ucTraCuuPhieuXuatKho1.Show();
            ucTraCuuPhieuNhapKho1.Hide();
        }

        private void btnTraCuuPhieuNhapKho_Click(object sender, EventArgs e)
        {
            ucBaoCaoThuChi1.Hide();
            ucXuatPhieuXuatKho1.Hide();
            ucXuatPhieuNhapKho1.Hide();
            ucTraCuuPhieuXuatKho1.Hide();
            ucTraCuuPhieuNhapKho1.Show();
        }
    }
}
