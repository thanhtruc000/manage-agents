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
    public partial class UCTiepNhanThongTin : UserControl
    {
        QLCacDaiLyEntities database = new QLCacDaiLyEntities();
        public UCTiepNhanThongTin()
        {
            InitializeComponent();
        }

        private void UCTiepNhanThongTin_Load(object sender, EventArgs e)
        {
            cbbDonViTinh.DataSource = database.DONVITINHs.ToList();
            cbbDonViTinh.DisplayMember = "TENDONVITINH";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string MaHH = txtMaHH.Text;
            string TenHH = txtTenHH.Text;

            int SoLuong = Convert.ToInt32(txtSoLuong.Text);
            double DonGia = Convert.ToDouble(txtDonGia.Text);



            HANGHOA h = new HANGHOA();
            using (var ctx = new QLCacDaiLyEntities())
            {
                h = ctx.HANGHOAs
                    .Where(s => s.MAHANGHOA == MaHH)
                    .FirstOrDefault<HANGHOA>();

            }
            if (h != null)
            {
                MessageBox.Show("Mã hàng hóa đã tồn tại");
            }

            else if (String.IsNullOrEmpty(txtMaHH.Text) || String.IsNullOrEmpty(txtTenHH.Text) ||
                 String.IsNullOrEmpty(cbbDonViTinh.Text) || String.IsNullOrEmpty(txtSoLuong.Text) ||
                 String.IsNullOrEmpty(txtDonGia.Text))
            {
                MessageBox.Show("Không được để trống. Vui lòng nhập đầy đủ");
            }
            else
            {
                HANGHOA hangHoaThem = new HANGHOA();
                hangHoaThem.MAHANGHOA = MaHH;
                hangHoaThem.TENHANGHOA = TenHH;
                hangHoaThem.MADONVITINH = ((DONVITINH)cbbDonViTinh.SelectedValue).MADONVITINH;
                hangHoaThem.SOLUONGCONLAI = SoLuong;
                hangHoaThem.DONGIA = DonGia;
                hangHoaThem.MAUUDAIHANGHOA = "UDHH01";

                database.HANGHOAs.Add(hangHoaThem);
                database.SaveChanges();
                //LoadUCTiepNhanThongTin();
                MessageBox.Show("Thêm thành công");
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập số");
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập số");
            }
        }
    }
}
