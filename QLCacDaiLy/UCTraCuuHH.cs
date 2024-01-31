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
    public partial class UCTraCuuHH : UserControl
    {
        QLCacDaiLyEntities database = new QLCacDaiLyEntities();
        public UCTraCuuHH()
        {
            InitializeComponent();
            LoadUCTraCuuHH();
            ChangeGridViewHeaderName();
            AddTraCuuHHBinding();
        }

        private void UCTraCuuHH_Load(object sender, EventArgs e)
        {
            cbbDonViTinh.DataSource = database.DONVITINHs.ToList();
            cbbDonViTinh.DisplayMember = "TENDONVITINH";
        }

        private void LoadUCTraCuuHH()
        {
            var dsTraCuuHH = from HANGHOA in database.HANGHOAs
                             join UUDAIHH in database.UUDAIHANGHOAs on HANGHOA.MAUUDAIHANGHOA equals UUDAIHH.MAUUDAIHANGHOA
                             join DONVT in database.DONVITINHs on HANGHOA.MADONVITINH equals DONVT.MADONVITINH
                             select new
                             {
                                 MaHH = HANGHOA.MAHANGHOA,
                                 TenHH = HANGHOA.TENHANGHOA,
                                 DonViTinh = DONVT.TENDONVITINH,
                                 SoLuong = HANGHOA.SOLUONGCONLAI,
                                 DonGia = HANGHOA.DONGIA,
                                 MaUuDaiHH = UUDAIHH.PHANTRAMUUDAI,
                             };
            dgvTraCuuHH.DataSource = dsTraCuuHH.ToList();
            //AddTraCuuHHBinding();
        }

        private void AddTraCuuHHBinding()
        {
            txtMaHH.DataBindings.Clear();
            txtTenHH.DataBindings.Clear();
            txtSoLuong.DataBindings.Clear();
            txtDonGia.DataBindings.Clear();

            txtMaHH.DataBindings.Add("Text", dgvTraCuuHH.DataSource, "MaHH");
            txtTenHH.DataBindings.Add("Text", dgvTraCuuHH.DataSource, "TenHH");

            cbbDonViTinh.DataSource = database.QUANs.ToList();
            cbbDonViTinh.DisplayMember = "TENDONVITINH";
            cbbDonViTinh.DataBindings.Add("Text", dgvTraCuuHH.DataSource, "DonViTinh");

            txtSoLuong.DataBindings.Add("Text", dgvTraCuuHH.DataSource, "SoLuong");
            txtDonGia.DataBindings.Add("Text", dgvTraCuuHH.DataSource, "DonGia");
        }

        private void ChangeGridViewHeaderName()
        {
            dgvTraCuuHH.Columns[0].HeaderText = "Mã hàng hóa";
            dgvTraCuuHH.Columns[1].HeaderText = "Tên hàng hóa";
            dgvTraCuuHH.Columns[2].HeaderText = "Đơn vị tính";
            dgvTraCuuHH.Columns[3].HeaderText = "Số lượng";
            dgvTraCuuHH.Columns[4].HeaderText = "Đơn giá";
            dgvTraCuuHH.Columns[5].HeaderText = "Ưu đãi";

            dgvTraCuuHH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMaHH.Text = "";
            txtTenHH.Text = "";
            cbbDonViTinh.SelectedIndex = -1;
            txtSoLuong.Text = "";
            txtDonGia.Text = "";

            LoadUCTraCuuHH();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMaHH.Text == "" || txtTenHH.Text == "")
            {
                MessageBox.Show("Không được để trống thông tin hàng hóa cần tìm! \n(Trừ số lượng và đơn giá)", "Chú ý");
            }
            else
            {
                //int SoLuong = Convert.ToInt32(txtSoLuong.Text);
                //double donGia = Convert.ToDouble(txtDonGia.Text);

                var dsTraCuuHH = from TraCuuHH in database.HANGHOAs
                                 from DonViTinh in database.DONVITINHs
                                 from UuDaiHH in database.UUDAIHANGHOAs
                                 where TraCuuHH.MADONVITINH == DonViTinh.MADONVITINH && TraCuuHH.MAUUDAIHANGHOA == UuDaiHH.MAUUDAIHANGHOA
                                 && TraCuuHH.TENHANGHOA == txtTenHH.Text && TraCuuHH.MADONVITINH == ((DONVITINH)cbbDonViTinh.SelectedValue).MADONVITINH
                                 && TraCuuHH.MAHANGHOA == txtMaHH.Text
                                 select new
                                 {
                                     MaHH = TraCuuHH.MAHANGHOA,
                                     TenHH = TraCuuHH.TENHANGHOA,
                                     DonViTinh = DonViTinh.TENDONVITINH,
                                     SoLuong = TraCuuHH.SOLUONGCONLAI,
                                     DonGia = TraCuuHH.DONGIA,
                                     MaUuDaiHH = UuDaiHH.PHANTRAMUUDAI,
                                 };
                dgvTraCuuHH.DataSource = dsTraCuuHH.ToList();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int SoLuong = Convert.ToInt32(txtSoLuong.Text);
            double donGia = Convert.ToDouble(txtDonGia.Text);


            if (String.IsNullOrEmpty(txtMaHH.Text) || String.IsNullOrEmpty(txtTenHH.Text) || String.IsNullOrEmpty(cbbDonViTinh.Text) ||
                String.IsNullOrEmpty(txtSoLuong.Text) || String.IsNullOrEmpty(txtDonGia.Text))
            {
                MessageBox.Show("Không được để trống");
            }

            else
            {
                //var dsTraCuuHH = from TraCuuHH in database.HANGHOAs
                //                 from DonViTinh in database.DONVITINHs
                //                 from UuDaiHH in database.UUDAIHANGHOAs
                //                 where TraCuuHH.MADONVITINH == DonViTinh.MADONVITINH && TraCuuHH.MAUUDAIHH == UuDaiHH.MAUUDAIHANGHOA
                //                 && TraCuuHH.MAHANGHOA == txtMaHH.Text && TraCuuHH.TENHANGHOA == txtTenHH.Text && TraCuuHH.SOLUONGCONLAI == SoLuong
                //                 && TraCuuHH.DONGIA == donGia && TraCuuHH.MADONVITINH == ((DONVITINH)cbbDonViTinh.SelectedValue).MADONVITINH
                //                 select new
                //                 {
                //                     MaHH = TraCuuHH.MAHANGHOA,
                //                     TenHH = TraCuuHH.TENHANGHOA,
                //                     DonViTinh = DonViTinh.TENDONVITINH,
                //                     SoLuong = TraCuuHH.SOLUONGCONLAI,
                //                     DonGia = TraCuuHH.DONGIA,
                //                     MaUuDaiHH = TraCuuHH.PHANTRAMUUDAI,

                //                 };
                HANGHOA hangHoaSua = database.HANGHOAs.Single(h => h.MAHANGHOA == txtMaHH.Text);
                hangHoaSua.MAHANGHOA = txtMaHH.Text;
                hangHoaSua.TENHANGHOA = txtTenHH.Text;
                hangHoaSua.SOLUONGCONLAI = int.Parse(txtSoLuong.Text);
                hangHoaSua.DONGIA = Convert.ToDouble(txtDonGia.Text);
                hangHoaSua.MADONVITINH =  ((DONVITINH)cbbDonViTinh.SelectedValue).MADONVITINH;

                database.SaveChanges();

                MessageBox.Show("Sửa thành công");
                LoadUCTraCuuHH();
            }
        }
    }
}
