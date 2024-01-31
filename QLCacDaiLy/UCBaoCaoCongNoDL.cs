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
    public partial class UCBaoCaoCongNoDL : UserControl
    {
        QLCacDaiLyEntities databse = new QLCacDaiLyEntities();
        public UCBaoCaoCongNoDL()
        {
            InitializeComponent();
            LoadBCCongNo();
            ChangeGridHeaderName();
            setDate();
        }

        private void ChangeGridHeaderName()
        {
            dgvBCCongNo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvBCCongNo.Columns[0].HeaderText = "Tên hàng hóa";
            dgvBCCongNo.Columns[1].HeaderText = "Số lượng";
            dgvBCCongNo.Columns[2].HeaderText = "Đơn giá";
            dgvBCCongNo.Columns[3].HeaderText = "Ưu đãi";
            dgvBCCongNo.Columns[4].HeaderText = "Bảng giá";
        }

        private void LoadBCCongNo()
        {
            var chiTietBCCN = from daily in databse.DAILies
                              from hanghoa in databse.HANGHOAs
                              from baocao in databse.BAOCAOCONGNODAILies
                              from chitietBC in databse.CHITIETBAOCAOCONGNOes
                              where daily.MADAILY == baocao.MADAILY && baocao.MABAOCAOCONGNO == chitietBC.MABAOCAOCONGNO && chitietBC.MAHANGHOA == hanghoa.MAHANGHOA
                              select new
                              {
                                  TenHH = "",
                                  SoLuong = "",
                                  DonGia = "",
                                  UuDai = "",
                                  BangGia = "",
                              };

            dgvBCCongNo.DataSource = chiTietBCCN.ToList();
        }

        // Set datetimepicker chỉ hiển thị tháng/năm
        private void setDate()
        {
            txtThangBC.Format = DateTimePickerFormat.Custom;
            txtThangBC.CustomFormat = "MM/ yyyy";
        }

        private void UCBaoCaoCongNoDL_Load(object sender, EventArgs e)
        {
            cbbQuan.DataSource = databse.QUANs.ToList();
            cbbQuan.DisplayMember = "TENQUAN";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMaDL.Text = "";
            txtTenDL.Text = "";
            cbbQuan.SelectedIndex = 0;
            txtThangBC.Value = DateTime.Now;

            tvTongDonGia.Text = "";
            tvTongTienDaThanhToan.Text = "";
            tvNoCu.Text = "";
            tvTongTienNo.Text = "";

            LoadBCCongNo();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            var chiTietBCCN = from daily in databse.DAILies
                              from hanghoa in databse.HANGHOAs
                              from baocao in databse.BAOCAOCONGNODAILies
                              from chitietBC in databse.CHITIETBAOCAOCONGNOes
                              from uudai in databse.UUDAIHANGHOAs
                              where daily.MADAILY == baocao.MADAILY && baocao.MABAOCAOCONGNO == chitietBC.MABAOCAOCONGNO && chitietBC.MAHANGHOA == hanghoa.MAHANGHOA && hanghoa.MAUUDAIHANGHOA == uudai.MAUUDAIHANGHOA
                              // So sánh tháng và năm với datetimepicker
                              && txtThangBC.Value.Month == baocao.THANGBAOCAO.Month && txtThangBC.Value.Year == baocao.THANGBAOCAO.Year
                              // So sánh các textbox
                              && txtMaDL.Text == daily.MADAILY && txtTenDL.Text == daily.TENDAILY && ((QUAN)cbbQuan.SelectedValue).MAQUAN == daily.MAQUAN
                              select new
                              {
                                  TenHH = hanghoa.TENHANGHOA,
                                  SoLuong = chitietBC.SOLUONG,
                                  DonGia = hanghoa.DONGIA,
                                  UuDai = uudai.PHANTRAMUUDAI,
                                  BangGia = chitietBC.SOLUONG * hanghoa.DONGIA - chitietBC.SOLUONG * hanghoa.DONGIA*(uudai.PHANTRAMUUDAI/100),
                              };

            dgvBCCongNo.DataSource = chiTietBCCN.ToList();

            // Kiểm tra thông tin đại lý đã tồn tại hay chưa
            var chiTietBCCN1 = (from daily in databse.DAILies
                                from baocao in databse.BAOCAOCONGNODAILies
                                where daily.MADAILY == baocao.MADAILY
                                // So sánh các textbox
                                && txtMaDL.Text == daily.MADAILY && txtTenDL.Text == daily.TENDAILY && ((QUAN)cbbQuan.SelectedValue).MAQUAN == daily.MAQUAN
                                select baocao).SingleOrDefault();

            // Đã tồn tại
            if (chiTietBCCN1 != null)
            {
                if (txtThangBC.Value.Month == chiTietBCCN1.THANGBAOCAO.Month && txtThangBC.Value.Year == chiTietBCCN1.THANGBAOCAO.Year)
                {
                    tvTongDonGia.Text = chiTietBCCN1.TONGDONGIA.ToString();
                    tvTongTienDaThanhToan.Text = chiTietBCCN1.TONGTIENDATHANHTOAN.ToString();
                    tvNoCu.Text = chiTietBCCN1.NOCU.ToString();
                    tvTongTienNo.Text = chiTietBCCN1.TONGTIENNO.ToString();
                }
                else
                {
                    tvTongDonGia.Text = "";
                    tvTongTienDaThanhToan.Text = "";
                    tvNoCu.Text = "";
                    tvTongTienNo.Text = "";

                    LoadBCCongNo();
                    MessageBox.Show("Đại lý chưa có báo cáo vào tháng này.", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            // Chưa tồn tại
            else
            {
                tvTongDonGia.Text = "";
                tvTongTienDaThanhToan.Text = "";
                tvNoCu.Text = "";
                tvTongTienNo.Text = "";

                LoadBCCongNo();
                MessageBox.Show("Đại lý này không tồn tại, vui lòng kiểm tra lại thông tin!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //// Tính tổng đơn giá
            //double tong = 0;
            //foreach (DataGridViewRow row in dgvBCCongNo.Rows)
            //{
            //    tong += Double.Parse(row.Cells[4].Value.ToString());
            //}
            //tvTongDonGia.Text = tong.ToString();

        }
    }
}
