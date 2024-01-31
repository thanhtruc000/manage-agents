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
    public partial class UCXuatPhieuXuatKho : UserControl
    {
        QLCacDaiLyEntities database = new QLCacDaiLyEntities();
        public UCXuatPhieuXuatKho()
        {
            InitializeComponent();
            LoadHangXuatKho();
            AddHangHoaXuatBinding();
            ChangeGridViewHeaderName();
        }

        private void ChangeGridViewHeaderName()
        {
            dgvHangXuatKho.Columns[0].HeaderText = "Mã Phiếu Xuất Kho";
            dgvHangXuatKho.Columns[1].HeaderText = "Mã Hàng Hóa";
            dgvHangXuatKho.Columns[2].HeaderText = "Tên Hàng Hóa";
            dgvHangXuatKho.Columns[3].HeaderText = "Số Lượng Xuất";
            dgvHangXuatKho.Columns[4].HeaderText = "Đơn Vị Tính";
            dgvHangXuatKho.Columns[5].HeaderText = "Đơn Giá";
            dgvHangXuatKho.Columns[6].HeaderText = "Bảng Giá";
            dgvHangXuatKho.Columns[7].Visible = false;
            dgvHangXuatKho.Columns[8].Visible = false;
            dgvHangXuatKho.Columns[9].Visible = false;
            dgvHangXuatKho.Columns[10].Visible = false;
        }

        private void AddHangHoaXuatBinding()
        {

            txtMaDL.DataBindings.Clear();
            txtMaHH.DataBindings.Clear();
            txtTenDL.DataBindings.Clear();
            txtTenHH.DataBindings.Clear();
            txtNgayXuatHang.DataBindings.Clear();
            txtSoLuongXuat.DataBindings.Clear();
            cbbDonViTinh.DataBindings.Clear();
            cbbHangThanhVien.DataBindings.Clear();
            txtPhieuChiTiet.DataBindings.Clear();

            txtPhieuChiTiet.DataBindings.Add("Text", dgvHangXuatKho.DataSource, "maPhieuXuatHang");
            txtMaDL.DataBindings.Add("Text", dgvHangXuatKho.DataSource, "maDaiLy");
            txtSoLuongXuat.DataBindings.Add("Text", dgvHangXuatKho.DataSource, "soLuongXuat");
            txtNgayXuatHang.DataBindings.Add("Text", dgvHangXuatKho.DataSource, "ngayXuatPhieu");
            txtMaHH.DataBindings.Add("Text", dgvHangXuatKho.DataSource, "maHangHoa");
            txtTenHH.DataBindings.Add("Text", dgvHangXuatKho.DataSource, "tenHangHoa");
            txtTenDL.DataBindings.Add("Text", dgvHangXuatKho.DataSource, "tenDaiLy");
            cbbDonViTinh.DataBindings.Add("Text", dgvHangXuatKho.DataSource, "donViTinh");
            cbbHangThanhVien.DataBindings.Add("Text", dgvHangXuatKho.DataSource, "hangThanhVien");
        }

        private void LoadHangXuatKho()
        {
            var dsHangXuatKho = from ctphieuxk in database.CHITIETPHIEUXUATHANGs
                                from phieuxk in database.PHIEUXUATHANGs
                                from daily in database.DAILies
                                from hanghoa in database.HANGHOAs
                                from uudai in database.UUDAIHANGHOAs
                                from donvitinh in database.DONVITINHs
                                from hangtv in database.UUDAITHANHVIENs

                                where ctphieuxk.MAPHIEUXUATHANG == phieuxk.MAPHIEUXUATHANG &&
                                daily.MADAILY == phieuxk.MADAILY &&
                                hanghoa.MAHANGHOA == ctphieuxk.MAHANGHOA &&
                                uudai.MAUUDAIHANGHOA == hanghoa.MAUUDAIHANGHOA &&
                                daily.MAUUDAITHANHVIEN == hangtv.MAUUDAITHANHVIEN &&
                                hanghoa.MADONVITINH == donvitinh.MADONVITINH
                                select new
                                {

                                    maPhieuXuatHang = ctphieuxk.MAPHIEUXUATHANG,
                                    maHangHoa = hanghoa.MAHANGHOA,
                                    tenHangHoa = hanghoa.TENHANGHOA,
                                    soLuongXuat = ctphieuxk.SOLUONGXUAT,
                                    donViTinh = donvitinh.TENDONVITINH,
                                    donGia = hanghoa.DONGIA,
                                    bangGia = (ctphieuxk.SOLUONGXUAT * hanghoa.DONGIA) - (ctphieuxk.SOLUONGXUAT * hanghoa.DONGIA * (uudai.PHANTRAMUUDAI / 100)),
                                    ngayXuatPhieu = phieuxk.NGAYXUATPHIEU,
                                    maDaiLy = daily.MADAILY,
                                    tenDaiLy = daily.TENDAILY,
                                    hangThanhVien = hangtv.HANGTHANHVIEN,
                                };



            dgvHangXuatKho.DataSource = dsHangXuatKho.ToList();
            ////Add binding
            //AddHangHoaXuatBinding();
        }

        private void Tinh()
        {
            // Tính tổng tiền
            double tongtien = 0;
            foreach (DataGridViewRow row in dgvHangXuatKho.Rows)
            {
                tongtien += Convert.ToDouble(row.Cells[6].Value.ToString());
            }
            tvTongTien.Text = tongtien.ToString();

            // Tính tổng phải trả, hiển thị phần trăm ưu đãi thành viên của đại lý
            double tongphaitra = 0;
            var uudaitv = (from uudai in database.UUDAITHANHVIENs
                           from daily in database.DAILies
                           where daily.MAUUDAITHANHVIEN == uudai.MAUUDAITHANHVIEN && txtMaDL.Text == daily.MADAILY && daily.TENDAILY == txtTenDL.Text
                           select uudai).SingleOrDefault();
            if (uudaitv != null)
            {
                tvUuDai.Text = uudaitv.UUDAITHANHVIEN1.ToString();
                tvTongPhaiTra.Text = (tongtien - tongtien * (Convert.ToInt32(uudaitv.UUDAITHANHVIEN1) / 100)).ToString();
                tongphaitra = Convert.ToDouble(tvTongPhaiTra.Text);
            }
            else
            {
                MessageBox.Show("Kiểm tra lại thông tin đại lý");
                tvUuDai.Text = "";
                tvTongPhaiTra.Text = "";
                LoadHangXuatKho();
            }

            // Số tiền đại lý đã trả và tiền còn dư
            var tiendatra = (from phieutt in database.PHIEUTHUTIENs
                             where phieutt.NGAYTHUTIEN.Day == txtNgayXuatHang.Value.Day
                             && phieutt.NGAYTHUTIEN.Month == txtNgayXuatHang.Value.Month
                             && phieutt.NGAYTHUTIEN.Year == txtNgayXuatHang.Value.Year
                             select phieutt).SingleOrDefault();
            if (tiendatra != null)
            {
                tvKhachTra.Text = tiendatra.SOTIENTHU.ToString();
                tvTienConDu.Text = (Convert.ToDouble(tvKhachTra.Text) - tongphaitra).ToString();
            }
            else
            {
                MessageBox.Show("Đại lý không có phiếu thu tiền vào ngày này");
                tvTienConDu.Text = "";
                tvKhachTra.Text = "";
                LoadHangXuatKho();
            }
        }

        private void UCXuatPhieuXuatKho_Load(object sender, EventArgs e)
        {
            cbbDonViTinh.DataSource = database.DONVITINHs.ToList();
            cbbDonViTinh.DisplayMember = "TENDONVITINH";

            cbbHangThanhVien.DataSource = database.UUDAITHANHVIENs.ToList();
            cbbHangThanhVien.DisplayMember = "HANGTHANHVIEN";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maPhieuXuatKho = txtPhieuChiTiet.Text;
            string maDaiLy = txtMaDL.Text;
            string tenDaiLy = txtTenDL.Text;
            string maHangHoa = txtMaHH.Text;
            string tenHangHoa = txtTenHH.Text;
            int soLuongXuat = Convert.ToInt32(txtSoLuongXuat.Text);
            string ngayXuatPhieu = txtNgayXuatHang.Text;

            DONVITINH donViTinh = cbbDonViTinh.SelectedValue as DONVITINH;
            UUDAITHANHVIEN hangThanhVien = cbbHangThanhVien.SelectedValue as UUDAITHANHVIEN;
            //Da xuat hien trong CSDL
            CHITIETPHIEUXUATHANG pXK = database.CHITIETPHIEUXUATHANGs.Where(xk => xk.MACHITIETPHIEUXUATHANG ==
           maPhieuXuatKho).SingleOrDefault();

            if (pXK != null)
            {
                MessageBox.Show("Mã phiếu đã tồn tại");
                return;
            }
            else if (String.IsNullOrEmpty(maPhieuXuatKho))
            {
                MessageBox.Show("Mã phiếu không được để trống");
                return;
            }
            else
            {
                double tong = 0;
                foreach (DataGridViewRow row in dgvHangXuatKho.Rows)
                {
                    tong = Double.Parse(row.Cells[6].Value.ToString());
                }


                PHIEUXUATHANG pxk = database.PHIEUXUATHANGs.Where(p => p.MAPHIEUXUATHANG == txtPhieuChiTiet.Text).SingleOrDefault();
                if (pxk == null)
                {
                    MessageBox.Show("Mã phiếu xuất kho chưa tồn tại");
                }

                else
                {
                    CHITIETPHIEUXUATHANG chitiet = new CHITIETPHIEUXUATHANG();
                    for (int i = 0; i < dgvHangXuatKho.Rows.Count; i++)
                    {
                        chitiet.MACHITIETPHIEUXUATHANG = "CTPXH" + (i + 2);

                    }

                    chitiet.MAHANGHOA = txtMaHH.Text;
                    chitiet.SOLUONGXUAT = Convert.ToInt32(txtSoLuongXuat.Text);
                    chitiet.BANGGIA = tong;
                    chitiet.MAPHIEUXUATHANG = txtPhieuChiTiet.Text;

                    database.CHITIETPHIEUXUATHANGs.Add(chitiet);
                    database.SaveChanges();
                    LoadHangXuatKho();
                    MessageBox.Show("Thêm mới phiếu  thành công");

                    Tinh();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maPhieuChiTiet = txtPhieuChiTiet.Text;
            //Da xuat hien trong CSDL
            CHITIETPHIEUXUATHANG phieuXK = database.CHITIETPHIEUXUATHANGs.Where(phieu => phieu.MAPHIEUXUATHANG == txtPhieuChiTiet.Text && phieu.MAHANGHOA == txtMaHH.Text).SingleOrDefault();
            if (phieuXK == null)
            {
                MessageBox.Show("Hãy kiểm tra lại thông tin");
                return;
            }
            else if (String.IsNullOrEmpty(maPhieuChiTiet) || String.IsNullOrEmpty(txtMaHH.Text))
            {
                MessageBox.Show("Mã phiếu và mã hàng hóa cần xóa không được để trống");
                return;
            }
            else
            {
                database.CHITIETPHIEUXUATHANGs.Remove(phieuXK);
                database.SaveChanges();
                LoadHangXuatKho();
                tvTongTien.Text = "";
                MessageBox.Show("Xóa phiếu thành công");

                Tinh();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maPhieuXuatKho = txtPhieuChiTiet.Text;
            string maDaiLy = txtMaDL.Text;
            string tenDaiLy = txtTenDL.Text;
            string maHangHoa = txtMaHH.Text;
            string tenHangHoa = txtTenHH.Text;
            int soLuongXuat = Convert.ToInt32(txtSoLuongXuat.Text);
            string ngayXuatPhieu = txtNgayXuatHang.Text;
            //Da xuat hien trong CSDL
            CHITIETPHIEUXUATHANG phieuXK = database.CHITIETPHIEUXUATHANGs.Where(phieu => phieu.MAPHIEUXUATHANG == txtPhieuChiTiet.Text && phieu.MAHANGHOA == txtMaHH.Text).SingleOrDefault();
            if (phieuXK == null)
            {
                MessageBox.Show("Mã phiếu không tồn tại");
                return;
            }
            else if (String.IsNullOrEmpty(maPhieuXuatKho))
            {
                MessageBox.Show("Mã lớp cần sửa không được để trống");
                return;
            }
            else
            {
                double tong = 0;
                foreach (DataGridViewRow row in dgvHangXuatKho.Rows)
                {
                    tong = Double.Parse(row.Cells[6].Value.ToString());
                }
                phieuXK.MAHANGHOA = maHangHoa;
                phieuXK.SOLUONGXUAT = soLuongXuat;
                phieuXK.BANGGIA = tong;

                database.SaveChanges();
                LoadHangXuatKho();
                tvTongTien.Text = "";
                ChangeGridViewHeaderName();
                MessageBox.Show("Cập nhật thông tin lớp học thành công");

                Tinh();
            }
        }
    }
}
