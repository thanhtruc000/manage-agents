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
    public partial class UCTraCuuPhieuXuatKho : UserControl
    {
        QLCacDaiLyEntities database = new QLCacDaiLyEntities();
        public UCTraCuuPhieuXuatKho()
        {
            InitializeComponent();
            LoadTCPhieuXuatHang();
            //AddTraCuuPhieuXuatHangBinding();
            ChangeGridViewHeaderName();
        }

        private void ChangeGridViewHeaderName()
        {
            dgvPhieuXuatHang.Columns[0].HeaderText = "Mã Phiếu Xuất Hàng";
            dgvPhieuXuatHang.Columns[1].HeaderText = "Mã Đại Lý";
            dgvPhieuXuatHang.Columns[2].HeaderText = "Tên Đại Lý";
            dgvPhieuXuatHang.Columns[3].HeaderText = "Ngày Xuất Phiếu";
            dgvPhieuXuatHang.Columns[4].HeaderText = "Tổng Tiền";
            dgvPhieuXuatHang.Columns[5].HeaderText = "Tổng Tiền Phải Trả";
        }

        //private void AddTraCuuPhieuXuatHangBinding()
        //{
        //    txtMaDL.DataBindings.Clear();
        //    txtTenDL.DataBindings.Clear();
        //    txtMaPhieu.DataBindings.Clear();
        //    txtNgayXuatPhieu.DataBindings.Clear();

        //    txtMaPhieu.DataBindings.Add("Text", dgvPhieuXuatHang.DataSource, "maPhieuXuatHang");
        //    txtMaDL.DataBindings.Add("Text", dgvPhieuXuatHang.DataSource, "maDaiLy");
        //    txtTenDL.DataBindings.Add("Text", dgvPhieuXuatHang.DataSource, "tenDaiLy");
        //    txtNgayXuatPhieu.DataBindings.Add("Text", dgvPhieuXuatHang.DataSource, "ngayXuatPhieu");

        //}

        private void LoadTCPhieuXuatHang()
        {
            var dsPhieuXuatHang = from phieuXK in database.PHIEUXUATHANGs
                                  from dl in database.DAILies
                                  where phieuXK.MADAILY == dl.MADAILY
                                  select new
                                  {
                                      maPhieuXuatHang = phieuXK.MAPHIEUXUATHANG,
                                      maDaiLy = phieuXK.MADAILY,
                                      tenDaiLy = dl.TENDAILY,
                                      ngayXuatPhieu = phieuXK.NGAYXUATPHIEU,
                                      tongTien = phieuXK.TONGTIEN,
                                      tongTienPhaiTra = phieuXK.TONGPHAITRA
                                  };
            dgvPhieuXuatHang.DataSource = dsPhieuXuatHang.ToList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTCPhieuXuatHang();
            MessageBox.Show("Đã cập nhật lại");
            txtMaDL.Text = string.Empty;
            txtMaPhieu.Text = string.Empty;
            txtTenDL.Text = string.Empty;
        }

        private void txtMaDL_TextChanged(object sender, EventArgs e)
        {
            dgvPhieuXuatHang.DataSource = (from madl in database.PHIEUXUATHANGs
                                           from dl in database.DAILies
                                           where madl.MADAILY == dl.MADAILY && madl.MADAILY.StartsWith(txtMaDL.Text)
                                           select new
                                           {
                                               maPhieuXuatHang = madl.MAPHIEUXUATHANG,
                                               maDaiLy = madl.MADAILY,
                                               tenDaiLy = dl.TENDAILY,
                                               ngayXuatPhieu = madl.NGAYXUATPHIEU,
                                               tongTien = madl.TONGTIEN,
                                               tongTienPhaiTra = madl.TONGPHAITRA
                                           }).ToList();
        }

        private void txtMaPhieu_TextChanged(object sender, EventArgs e)
        {
            dgvPhieuXuatHang.DataSource = (from maphieu in database.PHIEUXUATHANGs
                                           from dl in database.DAILies
                                           where maphieu.MADAILY == dl.MADAILY && maphieu.MAPHIEUXUATHANG.StartsWith(txtMaPhieu.Text)
                                           select new
                                           {
                                               maPhieuXuatHang = maphieu.MAPHIEUXUATHANG,
                                               maDaiLy = maphieu.MADAILY,
                                               tenDaiLy = dl.TENDAILY,
                                               ngayXuatPhieu = maphieu.NGAYXUATPHIEU,
                                               tongTien = maphieu.TONGTIEN,
                                               tongTienPhaiTra = maphieu.TONGPHAITRA
                                           }).ToList();
        }

        private void txtTenDL_TextChanged(object sender, EventArgs e)
        {
            dgvPhieuXuatHang.DataSource = (from phieuxh in database.PHIEUXUATHANGs
                                           from dl in database.DAILies
                                           where phieuxh.MADAILY == dl.MADAILY && dl.TENDAILY.StartsWith(txtTenDL.Text)
                                           select new
                                           {
                                               maPhieuXuatHang = phieuxh.MAPHIEUXUATHANG,
                                               maDaiLy = phieuxh.MADAILY,
                                               tenDaiLy = dl.TENDAILY,
                                               ngayXuatPhieu = phieuxh.NGAYXUATPHIEU,
                                               tongTien = phieuxh.TONGTIEN,
                                               tongTienPhaiTra = phieuxh.TONGPHAITRA
                                           }).ToList();
        }
    }
}
