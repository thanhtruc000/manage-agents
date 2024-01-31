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
    public partial class UCTiepNhanUuDai : UserControl
    {
        QLCacDaiLyEntities database = new QLCacDaiLyEntities();
        public UCTiepNhanUuDai()
        {
            InitializeComponent();
            LoadUCTiepNhanUuDai();
            ChangeGridViewHeaderName();
            AddTiepNhanUuDaiBinding();
        }

        private void UCTiepNhanUuDai_Load(object sender, EventArgs e)
        {
            cbbDonViTinh.DataSource = database.DONVITINHs.ToList();
            cbbDonViTinh.DisplayMember = "TENDONVITINH";

            cbbPhanTramUuDai.DataSource = database.UUDAIHANGHOAs.ToList();
            cbbPhanTramUuDai.DisplayMember = "PHANTRAMUUDAI";
        }

        private void LoadUCTiepNhanUuDai()
        {
            var Ds_TiepNhanUuDai = from HANGHOA in database.HANGHOAs
                                   join UUDAIHH in database.UUDAIHANGHOAs on HANGHOA.MAUUDAIHANGHOA equals UUDAIHH.MAUUDAIHANGHOA
                                   join DONVT in database.DONVITINHs on HANGHOA.MADONVITINH equals DONVT.MADONVITINH
                                   select new
                                   {
                                       MaHH = HANGHOA.MAHANGHOA,
                                       TenHH = HANGHOA.TENHANGHOA,
                                       DonViTinh = DONVT.TENDONVITINH,
                                       UuDai = UUDAIHH.PHANTRAMUUDAI,
                                       DonGia = HANGHOA.DONGIA,
                                   };

            dgvTiepNhanUuDai.DataSource = Ds_TiepNhanUuDai.ToList();
        }
        private void AddTiepNhanUuDaiBinding()
        {
            txtMaHH.DataBindings.Clear();
            txtTenHH.DataBindings.Clear();
            //txtMaUuDai.DataBindings.Clear();

            txtMaHH.DataBindings.Add("Text", dgvTiepNhanUuDai.DataSource, "MaHH");
            txtTenHH.DataBindings.Add("Text", dgvTiepNhanUuDai.DataSource, "TenHH");
            //txtMaUuDai.DataBindings.Add("Text", dgvTiepNhanUuDai.DataSource, "UuDai");

            cbbDonViTinh.DataSource = database.QUANs.ToList();
            cbbDonViTinh.DisplayMember = "TENDONVITINH";
            cbbDonViTinh.DataBindings.Add("Text", dgvTiepNhanUuDai.DataSource, "DonViTinh");

            cbbPhanTramUuDai.DataSource = database.UUDAIHANGHOAs.ToList();
            cbbPhanTramUuDai.DisplayMember = "PHANTRAMUUDAI";
            cbbPhanTramUuDai.DataBindings.Add("Text", dgvTiepNhanUuDai.DataSource, "UuDai");
        }
        private void ChangeGridViewHeaderName()
        {
            dgvTiepNhanUuDai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvTiepNhanUuDai.Columns[0].HeaderText = "Mã hàng hóa";
            dgvTiepNhanUuDai.Columns[1].HeaderText = "Tên hàng hóa";
            dgvTiepNhanUuDai.Columns[2].HeaderText = "Đơn vị tính";
            dgvTiepNhanUuDai.Columns[3].HeaderText = "Ưu đãi";
            dgvTiepNhanUuDai.Columns[4].HeaderText = "Đơn giá";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMaHH.Text == "" || txtTenHH.Text == "")
            {
                MessageBox.Show("Không được để trống thông tin hàng hóa cần tìm! ", "Chú ý");
            }
            else
            {
                var Ds_TiepNhanUuDai = from HANGHOA in database.HANGHOAs
                                       from DonViTinh in database.DONVITINHs
                                       from UuDaiHH in database.UUDAIHANGHOAs
                                       where HANGHOA.MADONVITINH == DonViTinh.MADONVITINH && HANGHOA.MAUUDAIHANGHOA == UuDaiHH.MAUUDAIHANGHOA
                                       && txtMaHH.Text == HANGHOA.MAHANGHOA && txtTenHH.Text == HANGHOA.TENHANGHOA 
                                       && HANGHOA.MADONVITINH == ((DONVITINH)cbbDonViTinh.SelectedValue).MADONVITINH
                                       select new
                                       {
                                           MaHH = HANGHOA.MAHANGHOA,
                                           TenHH = HANGHOA.TENHANGHOA,
                                           DonViTinh = DonViTinh.TENDONVITINH,
                                           UuDai = UuDaiHH.PHANTRAMUUDAI,
                                           DonGia = HANGHOA.DONGIA,
                                       };
                dgvTiepNhanUuDai.DataSource = Ds_TiepNhanUuDai.ToList();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMaHH.Text = "";
            txtTenHH.Text = "";
            cbbDonViTinh.SelectedIndex = -1;
            cbbPhanTramUuDai.SelectedIndex = -1;

            LoadUCTiepNhanUuDai();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string MaHH = txtMaHH.Text;
            string TenHH = txtTenHH.Text;


            //HANGHOA h = new HANGHOA();
            //using (var ctx = new QLCacDaiLyEntities())
            //{
            //    h = ctx.HANGHOAs
            //        .Where(s => s.MAHANGHOA == MaHH)
            //        .FirstOrDefault<HANGHOA>();

            //}

            HANGHOA h = database.HANGHOAs.Where(hh => hh.MAHANGHOA == txtMaHH.Text).SingleOrDefault();

            if (h == null)
            {
                MessageBox.Show("Mã hàng hóa này chưa tồn tại");
            }

            else if (String.IsNullOrEmpty(txtMaHH.Text) || String.IsNullOrEmpty(txtTenHH.Text) ||
                 String.IsNullOrEmpty(cbbDonViTinh.Text) || String.IsNullOrEmpty(cbbPhanTramUuDai.Text))
            {
                MessageBox.Show("Không được để trống. Vui lòng nhập đầy đủ");
            }
            else
            {
                //HANGHOA hangHoaThem = new HANGHOA();
                //hangHoaThem.MAHANGHOA = MaHH;
                //hangHoaThem.TENHANGHOA = TenHH;
                //hangHoaThem.MADONVITINH = ((DONVITINH)cbbDonViTinh.SelectedValue).TENDONVITINH;
                //hangHoaThem.MAUUDAIHH = ((UUDAIHANGHOA)cbbPhanTramUuDai.SelectedValue).MAUUDAIHANGHOA ;
                //hangHoaThem.
                h.MAUUDAIHANGHOA = ((UUDAIHANGHOA)cbbPhanTramUuDai.SelectedValue).MAUUDAIHANGHOA;


                database.SaveChanges();
                LoadUCTiepNhanUuDai();
                MessageBox.Show("Thêm thành công");
            }
        }
    }
}
