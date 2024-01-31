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
    public partial class UCBaoCaoDoanhThuDL : UserControl
    {
        QLCacDaiLyEntities database = new QLCacDaiLyEntities();
        public UCBaoCaoDoanhThuDL()
        {
            InitializeComponent();
            LoadBCDoanhThu();
            ChangeGridHeaderName();
            setDate();
        }

        private void ChangeGridHeaderName()
        {
            dgvBCDoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvBCDoanhThu.Columns[0].HeaderText = "Tên hàng hóa";
            dgvBCDoanhThu.Columns[1].HeaderText = "Số lượng";
            dgvBCDoanhThu.Columns[2].HeaderText = "Doanh thu";
        }

        private void LoadBCDoanhThu()
        {
            var chiTietBCDT = from daily in database.DAILies
                            from hanghoa in database.HANGHOAs
                            from baocao in database.BAOCAODOANHTHUs
                            from chitietBC in database.CHITIETBAOCAODOANHTHUs
                            where daily.MADAILY == baocao.MADAILY && baocao.MABAOCAODOANHTHU == chitietBC.MABAOCAODOANHTHU && chitietBC.MAHANGHOA == hanghoa.MAHANGHOA
                            select new
                            {
                                TenHH = "",
                                SoLuong = "",
                                DoanhThu = "",
                            };

            dgvBCDoanhThu.DataSource = chiTietBCDT.ToList();
        }

        // Set datetimepicker chỉ hiển thị tháng/năm
        private void setDate()
        {
            txtThangBC.Format = DateTimePickerFormat.Custom;
            txtThangBC.CustomFormat = "MM/ yyyy";
        }

        private void UCBaoCaoDoanhThuDL_Load(object sender, EventArgs e)
        {
            cbbQuan.DataSource = database.QUANs.ToList();
            cbbQuan.DisplayMember = "TENQUAN";
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            var chiTietBCDT = from daily in database.DAILies
                            from hanghoa in database.HANGHOAs
                            from baocao in database.BAOCAODOANHTHUs
                            from chitietBC in database.CHITIETBAOCAODOANHTHUs
                            where daily.MADAILY == baocao.MADAILY && baocao.MABAOCAODOANHTHU == chitietBC.MABAOCAODOANHTHU && chitietBC.MAHANGHOA == hanghoa.MAHANGHOA
                              // So sánh tháng và năm với datetimepicker
                              && txtThangBC.Value.Month == baocao.THANG.Month && txtThangBC.Value.Year == baocao.THANG.Year
                              // So sánh các textbox
                              && daily.MADAILY == txtMaDL.Text && daily.TENDAILY == txtTenDL.Text && ((QUAN)cbbQuan.SelectedValue).MAQUAN == daily.MAQUAN
                              select new
                              {
                                  TenHH = hanghoa.TENHANGHOA,
                                  SoLuong = chitietBC.SOLUONG,
                                  DoanhThu = chitietBC.DOANHTHU,
                              };
           
            dgvBCDoanhThu.DataSource = chiTietBCDT.ToList();

            // HIỂN THỊ TỔNG DOANH THU
            var chiTietBCDT1 = (from daily1 in database.DAILies
                                from baocao1 in database.BAOCAODOANHTHUs
                                where daily1.MADAILY == baocao1.MADAILY 
                                // So sánh các textbox
                                && daily1.MADAILY == txtMaDL.Text && daily1.TENDAILY == txtTenDL.Text && ((QUAN)cbbQuan.SelectedValue).MAQUAN == daily1.MAQUAN
                                select baocao1).SingleOrDefault();

            // Kiểm tra thông tin đại lý
            if (chiTietBCDT1 != null)
            {
                if (chiTietBCDT1.THANG.Month == txtThangBC.Value.Month && chiTietBCDT1.THANG.Year == txtThangBC.Value.Year)
                {
                    tvTongDoanhThu.Text = chiTietBCDT1.TONGDOANHTHU.ToString();
                }
                else
                {
                    tvTongDoanhThu.Text = "";
                    LoadBCDoanhThu();
                    MessageBox.Show("Đại lý chưa có báo cáo vào tháng này.", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            else
            {
                LoadBCDoanhThu();
                tvTongDoanhThu.Text = "";
                MessageBox.Show("Đại lý này không tồn tại, vui lòng kiểm tra lại thông tin!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

            // TÍNH TỔNG DOANH THU
            //double tong = 0;
            //double doanhthu;

            //foreach (DataGridViewRow row in dgvBCDoanhThu.Rows)
            //{
            //    doanhthu = Double.Parse(row.Cells[2].Value.ToString());
            //    tong += doanhthu;
            //}
            //tvTongDoanhThu.Text = tong.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMaDL.Text = "";
            txtTenDL.Text = "";
            cbbQuan.SelectedIndex = 0;
            txtThangBC.Value = DateTime.Now;

            tvTongDoanhThu.Text = "";

            LoadBCDoanhThu();
        }
    }
}
