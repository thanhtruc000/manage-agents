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
    public partial class UCXuatPhieuNhapKho : UserControl
    {
        private QLCacDaiLyEntities database = new QLCacDaiLyEntities();
        public UCXuatPhieuNhapKho()
        {
            InitializeComponent();
            LoadHangNhapKho();
            AddHangHoaNhapBinding();
            ChangeGridViewHeaderName();
        }

        private void ChangeGridViewHeaderName()
        {
            dgvPhieuNhapHang.Columns[0].HeaderText = "Mã Phiếu Nha Kho";
            dgvPhieuNhapHang.Columns[1].HeaderText = "Mã Hàng Hóa";
            dgvPhieuNhapHang.Columns[2].HeaderText = "Tên Hàng Hóa";
            dgvPhieuNhapHang.Columns[3].HeaderText = "Ngày Nhập Hàng";
            dgvPhieuNhapHang.Columns[4].HeaderText = "Đơn Vị Tính";
            dgvPhieuNhapHang.Columns[5].HeaderText = "Số Lượng Nhập";
            dgvPhieuNhapHang.Columns[6].HeaderText = "Số Tiền Chi";
        }

        private void AddHangHoaNhapBinding()
        {
            txtMaPhieuNhap.DataBindings.Clear();
            txtNgayNhapHang.DataBindings.Clear();
            txtMaHH.DataBindings.Clear();
            txtTenHH.DataBindings.Clear();
            cbbDonViTinh.DataBindings.Clear();
            txtSoLuong.DataBindings.Clear();
            txtSoTienChi.DataBindings.Clear();

            txtMaPhieuNhap.DataBindings.Add("Text", dgvPhieuNhapHang.DataSource, "maPhieuNhapKho");
            txtMaHH.DataBindings.Add("Text", dgvPhieuNhapHang.DataSource, "maHangHoa");
            txtTenHH.DataBindings.Add("Text", dgvPhieuNhapHang.DataSource, "tenHangHoa");
            cbbDonViTinh.DataBindings.Add("Text", dgvPhieuNhapHang.DataSource, "donViTinh");
            txtSoLuong.DataBindings.Add("Text", dgvPhieuNhapHang.DataSource, "soLuongNhap");
            txtSoTienChi.DataBindings.Add("Text", dgvPhieuNhapHang.DataSource, "soTienChi");
            txtNgayNhapHang.DataBindings.Add("Text", dgvPhieuNhapHang.DataSource, "ngayNhapHang");
        }

        private void LoadHangNhapKho()
        {
            var dsHangNhapKho = from ctphieunk in database.CHITIETPHIEUNHAPKHOes
                                from hanghoa in database.HANGHOAs
                                from phieunk in database.PHIEUNHAPKHOes
                                where ctphieunk.MAHANGHOA == hanghoa.MAHANGHOA
                                && ctphieunk.MAPHIEUNHAPKHO == phieunk.MAPHIEUNHAPKHO
                                orderby ctphieunk.MAPHIEUNHAPKHO ascending

                                select new
                                {
                                    maPhieuNhapKho = ctphieunk.MAPHIEUNHAPKHO,
                                    maHangHoa = ctphieunk.MAHANGHOA,
                                    tenHangHoa = hanghoa.TENHANGHOA,
                                    ngayNhapHang = ctphieunk.PHIEUNHAPKHO.NGAYNHAPKHO,
                                    donViTinh = hanghoa.DONVITINH.TENDONVITINH,
                                    soLuongNhap = ctphieunk.SOLUONGNHAP,
                                    soTienChi = ctphieunk.SOLUONGNHAP * hanghoa.DONGIA
                                };

            cbbDonViTinh.DataSource = database.DONVITINHs.ToList();
            cbbDonViTinh.DisplayMember = "TENDONVITINH";
            dgvPhieuNhapHang.DataSource = dsHangNhapKho.ToList();

            //AddHangHoaNhapBinding();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maPhieuNhapKho = txtMaPhieuNhap.Text;
            string maHangHoa = txtMaHH.Text;
            string tenHangHoa = txtTenHH.Text;
            int soLuongXuat = Convert.ToInt32(txtSoLuong.Text);
            string ngayNhapPhieu = txtNgayNhapHang.Text;
            DONVITINH donViTinh = cbbDonViTinh.SelectedValue as DONVITINH;

            if (String.IsNullOrEmpty(maPhieuNhapKho))
            {
                MessageBox.Show("Mã phiếu không được để trống");
                return;
            }
            else
            {
                double tong = 0;
                foreach (DataGridViewRow row in dgvPhieuNhapHang.Rows)
                {
                    tong = Double.Parse(row.Cells[6].Value.ToString());
                }

                PHIEUNHAPKHO pxk = database.PHIEUNHAPKHOes.Where(p => p.MAPHIEUNHAPKHO == txtMaPhieuNhap.Text).SingleOrDefault();
                if (pxk == null)
                {
                    MessageBox.Show("Mã phiếu nhập kho chưa tồn tại");
                }
                else
                {
                    CHITIETPHIEUNHAPKHO chitiet = new CHITIETPHIEUNHAPKHO();

                    chitiet.MAHANGHOA = txtMaHH.Text;
                    chitiet.SOLUONGNHAP = Convert.ToInt32(txtSoLuong.Text);
                    chitiet.SOTIENCHI = tong;
                    chitiet.MAPHIEUNHAPKHO = txtMaPhieuNhap.Text;

                    database.CHITIETPHIEUNHAPKHOes.Add(chitiet);
                    database.SaveChanges();
                    LoadHangNhapKho();
                    MessageBox.Show("Thêm mới phiếu  thành công");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maPhieuNhapKho = txtMaPhieuNhap.Text;
            //Da xuat hien trong CSDL
            CHITIETPHIEUNHAPKHO phieunk = database.CHITIETPHIEUNHAPKHOes.Where(phieu => phieu.MAPHIEUNHAPKHO == txtMaPhieuNhap.Text && phieu.MAHANGHOA == txtMaHH.Text).SingleOrDefault();
            if (phieunk == null)
            {
                MessageBox.Show("Hãy kiểm tra lại thông tin");
                return;
            }
            else if (String.IsNullOrEmpty(maPhieuNhapKho) || String.IsNullOrEmpty(txtMaHH.Text))
            {
                MessageBox.Show("Mã phiếu và mã hàng hóa cần xóa không được để trống");
                return;
            }
            else
            {
                database.CHITIETPHIEUNHAPKHOes.Remove(phieunk);
                database.SaveChanges();
                LoadHangNhapKho();

                MessageBox.Show("Xóa phiếu thành công");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maPhieuNhapKho = txtMaPhieuNhap.Text;
            string maHangHoa = txtMaHH.Text;
            string tenHangHoa = txtTenHH.Text;
            int soLuongXuat = Convert.ToInt32(txtSoLuong.Text);
            string ngayNhapPhieu = txtNgayNhapHang.Text;
            DONVITINH donViTinh = cbbDonViTinh.SelectedValue as DONVITINH;
            //Da xuat hien trong CSDL
            CHITIETPHIEUNHAPKHO phieunk = database.CHITIETPHIEUNHAPKHOes.Where(phieu => phieu.MAPHIEUNHAPKHO == txtMaPhieuNhap.Text && phieu.MAHANGHOA == txtMaHH.Text).SingleOrDefault();
            if (phieunk == null)
            {
                MessageBox.Show("Mã phiếu không tồn tại");
                return;
            }
            else if (String.IsNullOrEmpty(maPhieuNhapKho))
            {
                MessageBox.Show("Mã phiếu cần sửa không được để trống");
                return;
            }
            else
            {
                double tong = 0;
                foreach (DataGridViewRow row in dgvPhieuNhapHang.Rows)
                {
                    tong = Double.Parse(row.Cells[6].Value.ToString());
                }
                phieunk.MAHANGHOA = maHangHoa;
                phieunk.SOLUONGNHAP = soLuongXuat;
                phieunk.SOTIENCHI = tong;

                database.SaveChanges();
                LoadHangNhapKho();

                ChangeGridViewHeaderName();
                MessageBox.Show("Cập nhật thông tin phiếu xuất thành công");
            }
        }
    }
}
