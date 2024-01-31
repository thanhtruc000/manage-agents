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
    public partial class UCTraCuuLSHHBanRa : UserControl
    {
        QLCacDaiLyEntities database = new QLCacDaiLyEntities();
        public UCTraCuuLSHHBanRa()
        {
            InitializeComponent();
            LoadUCTraCuuLSHHBanRa();
            ChangeGridViewHeaderName();
        }
        public void LoadUCTraCuuLSHHBanRa()
        {
            var Ds_TraCuuLSHH = from hanghoa in database.HANGHOAs
                                from phieuXuatHang in database.PHIEUXUATHANGs
                                from chitietPXH in database.CHITIETPHIEUXUATHANGs
                                from donvitinh in database.DONVITINHs
                                from uudai in database.UUDAIHANGHOAs
                                where hanghoa.MAHANGHOA == chitietPXH.MAHANGHOA && chitietPXH.MAPHIEUXUATHANG == phieuXuatHang.MAPHIEUXUATHANG
                                && donvitinh.MADONVITINH == hanghoa.MADONVITINH && hanghoa.MAUUDAIHANGHOA == uudai.MAUUDAIHANGHOA
                                select new
                                {
                                    MaHH = hanghoa.MAHANGHOA,
                                    TenHH = hanghoa.TENHANGHOA,
                                    DonViTinh = donvitinh.TENDONVITINH,
                                    SoLuong = chitietPXH.SOLUONGXUAT,
                                    NgayBan = phieuXuatHang.NGAYXUATPHIEU,
                                    UuDai = uudai.PHANTRAMUUDAI,
                                    DonGia = hanghoa.DONGIA,
                                };

            dgv_TraCuuLSHHBanRa.DataSource = Ds_TraCuuLSHH.ToList();

        }

        private void ChangeGridViewHeaderName()
        {
            dgv_TraCuuLSHHBanRa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgv_TraCuuLSHHBanRa.Columns[0].HeaderText = "Mã hàng hóa";
            dgv_TraCuuLSHHBanRa.Columns[1].HeaderText = "Tên hàng hóa";
            dgv_TraCuuLSHHBanRa.Columns[2].HeaderText = "Đơn vị tính";
            dgv_TraCuuLSHHBanRa.Columns[3].HeaderText = "Số lượng";
            dgv_TraCuuLSHHBanRa.Columns[4].HeaderText = "Ngày bán";
            dgv_TraCuuLSHHBanRa.Columns[5].HeaderText = "Ưu đãi";
            dgv_TraCuuLSHHBanRa.Columns[6].HeaderText = "Đơn giá";

        }

        private void txtMaHH_TextChanged(object sender, EventArgs e)
        {
            var Ds_TraCuuLSHH = from hanghoa in database.HANGHOAs
                                from phieuXuatHang in database.PHIEUXUATHANGs
                                from chitietPXH in database.CHITIETPHIEUXUATHANGs
                                from donvitinh in database.DONVITINHs
                                from uudai in database.UUDAIHANGHOAs
                                where hanghoa.MAHANGHOA == chitietPXH.MAHANGHOA && chitietPXH.MAPHIEUXUATHANG == phieuXuatHang.MAPHIEUXUATHANG
                                && donvitinh.MADONVITINH == hanghoa.MADONVITINH && hanghoa.MAUUDAIHANGHOA == uudai.MAUUDAIHANGHOA
                                && hanghoa.MAHANGHOA.StartsWith(txtMaHH.Text)
                                select new
                                {
                                    MaHH = hanghoa.MAHANGHOA,
                                    TenHH = hanghoa.TENHANGHOA,
                                    DonViTinh = donvitinh.TENDONVITINH,
                                    SoLuong = chitietPXH.SOLUONGXUAT,
                                    NgayBan = phieuXuatHang.NGAYXUATPHIEU,
                                    UuDai = uudai.PHANTRAMUUDAI,
                                    DonGia = hanghoa.DONGIA,
                                };

            dgv_TraCuuLSHHBanRa.DataSource = Ds_TraCuuLSHH.ToList();
        }

        private void txtTenHH_TextChanged(object sender, EventArgs e)
        {
            var Ds_TraCuuLSHH = from hanghoa in database.HANGHOAs
                                from phieuXuatHang in database.PHIEUXUATHANGs
                                from chitietPXH in database.CHITIETPHIEUXUATHANGs
                                from donvitinh in database.DONVITINHs
                                from uudai in database.UUDAIHANGHOAs
                                where hanghoa.MAHANGHOA == chitietPXH.MAHANGHOA && chitietPXH.MAPHIEUXUATHANG == phieuXuatHang.MAPHIEUXUATHANG
                                && donvitinh.MADONVITINH == hanghoa.MADONVITINH && hanghoa.MAUUDAIHANGHOA == uudai.MAUUDAIHANGHOA
                                && hanghoa.TENHANGHOA.StartsWith(txtTenHH.Text)
                                select new
                                {
                                    MaHH = hanghoa.MAHANGHOA,
                                    TenHH = hanghoa.TENHANGHOA,
                                    DonViTinh = donvitinh.TENDONVITINH,
                                    SoLuong = chitietPXH.SOLUONGXUAT,
                                    NgayBan = phieuXuatHang.NGAYXUATPHIEU,
                                    UuDai = uudai.PHANTRAMUUDAI,
                                    DonGia = hanghoa.DONGIA,
                                };

            dgv_TraCuuLSHHBanRa.DataSource = Ds_TraCuuLSHH.ToList();
        }

        private void dtNgayBan_ValueChanged(object sender, EventArgs e)
        {
            var Ds_TraCuuLSHH = from hanghoa in database.HANGHOAs
                                from phieuXuatHang in database.PHIEUXUATHANGs
                                from chitietPXH in database.CHITIETPHIEUXUATHANGs
                                from donvitinh in database.DONVITINHs
                                from uudai in database.UUDAIHANGHOAs
                                where hanghoa.MAHANGHOA == chitietPXH.MAHANGHOA && chitietPXH.MAPHIEUXUATHANG == phieuXuatHang.MAPHIEUXUATHANG
                                && donvitinh.MADONVITINH == hanghoa.MADONVITINH && hanghoa.MAUUDAIHANGHOA == uudai.MAUUDAIHANGHOA
                                && phieuXuatHang.NGAYXUATPHIEU.Day == dtNgayBan.Value.Day
                                && phieuXuatHang.NGAYXUATPHIEU.Month == dtNgayBan.Value.Month
                                && phieuXuatHang.NGAYXUATPHIEU.Year == dtNgayBan.Value.Year
                                select new
                                {
                                    MaHH = hanghoa.MAHANGHOA,
                                    TenHH = hanghoa.TENHANGHOA,
                                    DonViTinh = donvitinh.TENDONVITINH,
                                    SoLuong = chitietPXH.SOLUONGXUAT,
                                    NgayBan = phieuXuatHang.NGAYXUATPHIEU,
                                    UuDai = uudai.PHANTRAMUUDAI,
                                    DonGia = hanghoa.DONGIA,
                                };

            dgv_TraCuuLSHHBanRa.DataSource = Ds_TraCuuLSHH.ToList();
        }
    }
}
