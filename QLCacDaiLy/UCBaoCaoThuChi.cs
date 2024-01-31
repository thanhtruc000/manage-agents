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
    public partial class UCBaoCaoThuChi : UserControl
    {
        QLCacDaiLyEntities database = new QLCacDaiLyEntities();
        public UCBaoCaoThuChi()
        {
            InitializeComponent();
            LoadBCThuChi();
            ChangeGridViewHeader();
            SetDate();
        }

        private void LoadBCThuChi()
        {
            // Data grid view Chi
            var chitietChi = from hanghoa in database.HANGHOAs
                             from donvitinh in database.DONVITINHs
                             from chitiet in database.CHITIETBAOCAOCHIs
                             from baocao in database.BAOCAOTHUCHIs
                             where hanghoa.MAHANGHOA == chitiet.MAHANGHOA && hanghoa.MADONVITINH == donvitinh.MADONVITINH
                             && chitiet.MABAOCAOTHUCHI == baocao.MABAOCAOTHUCHI
                             select new
                             {
                                 TenHH = "",
                                 DonViTinh = "",
                                 SoLuong = "",
                                 SoTienChi = "",
                             };

            dgvBCChi.DataSource = chitietChi.ToList();

            // Data grid view Thu
            var chitietThu = from phieutt in database.PHIEUTHUTIENs
                             from baocao in database.BAOCAOTHUCHIs
                             select new
                             {
                                 MaPhieuTT = "",
                                 NgayXuatPhieuTT = "",
                                 SoTienThu = "",
                             };
            dgvBCThu.DataSource = chitietThu.ToList();
        }

        private void ChangeGridViewHeader()
        {
            dgvBCChi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBCThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvBCChi.Columns[0].HeaderText = "Tên hàng hóa";
            dgvBCChi.Columns[1].HeaderText = "Đơn vị tính";
            dgvBCChi.Columns[2].HeaderText = "Số lượng";
            dgvBCChi.Columns[3].HeaderText = "Số tiền chi";

            dgvBCThu.Columns[0].HeaderText = "Mã phiếu thu tiền";
            dgvBCThu.Columns[1].HeaderText = "Ngày xuất phiếu";
            dgvBCThu.Columns[2].HeaderText = "Giá trị phiếu";

        }

        // Set datetimepicker chỉ hiển thị tháng/năm
        private void SetDate()
        {
            txtThangBC.Format = DateTimePickerFormat.Custom;
            txtThangBC.CustomFormat = "MM/ yyyy";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtThangBC.Value = DateTime.Now;
            LoadBCThuChi();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            // CHI
            var chitietChi = from hanghoa in database.HANGHOAs
                             from donvitinh in database.DONVITINHs
                             from chitiet in database.CHITIETBAOCAOCHIs
                             from baocao in database.BAOCAOTHUCHIs
                             where hanghoa.MAHANGHOA == chitiet.MAHANGHOA && hanghoa.MADONVITINH == donvitinh.MADONVITINH
                             && chitiet.MABAOCAOTHUCHI == baocao.MABAOCAOTHUCHI
                             && txtThangBC.Value.Month == baocao.NGAYBAOCAO.Month && txtThangBC.Value.Year == baocao.NGAYBAOCAO.Year
                             select new
                             {
                                 TenHH = hanghoa.TENHANGHOA,
                                 DonViTinh = donvitinh.TENDONVITINH,
                                 SoLuong = chitiet.TONGSOLUONGTHU,
                                 SoTienChi = chitiet.SOTIENCHI,
                             };

            dgvBCChi.DataSource = chitietChi.ToList();

            // TÍNH TỔNG CHI
            double TongChi = 0;
            //double doanhthu;

            foreach (DataGridViewRow row in dgvBCChi.Rows)
            {
                TongChi += Double.Parse(row.Cells[3].Value.ToString());
            }
            tvTongChi.Text = TongChi.ToString();


            // THU
            var chitietThu = from phieutt in database.PHIEUTHUTIENs
                             from baocao in database.BAOCAOTHUCHIs
                             where txtThangBC.Value.Month == baocao.NGAYBAOCAO.Month && txtThangBC.Value.Year == baocao.NGAYBAOCAO.Year
                             && baocao.NGAYBAOCAO.Month == phieutt.NGAYTHUTIEN.Month && baocao.NGAYBAOCAO.Year == phieutt.NGAYTHUTIEN.Year
                             select new
                             {
                                 MaPhieuTT = phieutt.MAPHIEUTHUTIEN,
                                 NgayXuatPhieuTT = phieutt.NGAYTHUTIEN,
                                 SoTienThu = phieutt.SOTIENTHU,
                             };
            dgvBCThu.DataSource = chitietThu.ToList();

            // TÍNH TỔNG THU
            double TongThu = 0;
            //double doanhthu;

            foreach (DataGridViewRow row in dgvBCThu.Rows)
            {
                TongThu += Double.Parse(row.Cells[2].Value.ToString());
            }
            tvTongThu.Text = TongThu.ToString();
        }
    }
}
