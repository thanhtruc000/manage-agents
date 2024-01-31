using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLCacDaiLy.DAL;

namespace QLCacDaiLy
{
    public partial class UCTraCuuPhieuNhapKho : UserControl
    {
        QLCacDaiLyEntities database = new QLCacDaiLyEntities();
        public UCTraCuuPhieuNhapKho()
        {
            InitializeComponent();
            LoadTCPhieuNhapKho();
            ChangeDataGridViewHeaderName();
        }

        void LoadTCPhieuNhapKho()
        {
            var chitiet = from chitietPNK in database.CHITIETPHIEUNHAPKHOes
                          from phieuNK in database.PHIEUNHAPKHOes
                          where chitietPNK.MAPHIEUNHAPKHO == phieuNK.MAPHIEUNHAPKHO
                          select new
                          {
                              chitietPNK.SOTIENCHI
                          };
            double sum = chitiet.ToList().Select(c => c.SOTIENCHI).Sum();


            var dsPhieuNhapKho = from phieuNK in database.PHIEUNHAPKHOes
                                 from ctphieuNK in database.CHITIETPHIEUNHAPKHOes
                                 from hang in database.HANGHOAs
                                 where phieuNK.MAPHIEUNHAPKHO == ctphieuNK.MAPHIEUNHAPKHO && hang.MAHANGHOA == ctphieuNK.MAHANGHOA
                                 select new
                                 {
                                     maPhieuXuatHang = phieuNK.MAPHIEUNHAPKHO,
                                     ngayNhapPhieu = phieuNK.NGAYNHAPKHO,
                                     tongchi = sum,
                                 };
            dgvTraCuuPNK.DataSource = dsPhieuNhapKho.ToList();
        }

        private void ChangeDataGridViewHeaderName()
        {
            dgvTraCuuPNK.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvTraCuuPNK.Columns[0].HeaderText = "Mã phiếu";
            dgvTraCuuPNK.Columns[1].HeaderText = "Ngày nhập kho";
            dgvTraCuuPNK.Columns[2].HeaderText = "Giá trị phiếu";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var chitiet = from chitietPNK in database.CHITIETPHIEUNHAPKHOes
                          from phieuNK in database.PHIEUNHAPKHOes
                          where chitietPNK.MAPHIEUNHAPKHO == phieuNK.MAPHIEUNHAPKHO
                          select new
                          {
                              chitietPNK.SOTIENCHI
                          };
            double sum = chitiet.ToList().Select(c => c.SOTIENCHI).Sum();

            var dsPhieuNhapKho = from phieuNK in database.PHIEUNHAPKHOes
                                 from ctphieuNK in database.CHITIETPHIEUNHAPKHOes
                                 from hang in database.HANGHOAs
                                 where phieuNK.MAPHIEUNHAPKHO == ctphieuNK.MAPHIEUNHAPKHO && hang.MAHANGHOA == ctphieuNK.MAHANGHOA
                                 && phieuNK.MAPHIEUNHAPKHO.StartsWith(textBox1.Text)
                                 select new
                                 {
                                     maPhieuXuatHang = phieuNK.MAPHIEUNHAPKHO,
                                     ngayNhapPhieu = phieuNK.NGAYNHAPKHO,
                                     tongchi = sum,
                                 };
            dgvTraCuuPNK.DataSource = dsPhieuNhapKho.ToList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            LoadTCPhieuNhapKho();
        }
    }
}
