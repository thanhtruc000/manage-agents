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
    public partial class UCTraCuuDL : UserControl
    {
        QLCacDaiLyEntities database = new QLCacDaiLyEntities();
        public UCTraCuuDL()
        {
            InitializeComponent();
            LoadThongTinDaiLy();
            ChangeGridHeaderName();
            AddDaiLyBinding();
        }
        
        private void ChangeGridHeaderName()
        {
            dgvDaiLy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvDaiLy.Columns[0].HeaderText = "Mã đại lý";
            dgvDaiLy.Columns[1].HeaderText = "Tên đại lý";
            dgvDaiLy.Columns[2].HeaderText = "Địa chỉ";
            dgvDaiLy.Columns[3].HeaderText = "Quận";
            dgvDaiLy.Columns[4].HeaderText = "Số điện thoại";
            dgvDaiLy.Columns[5].HeaderText = "Ngày tiếp nhận";
            dgvDaiLy.Columns[6].HeaderText = "Ngày HĐ gần nhất";
            dgvDaiLy.Columns[7].HeaderText = "Điểm";
            dgvDaiLy.Columns[8].HeaderText = "Hạng thành viên";
            dgvDaiLy.Columns[9].HeaderText = "Tiền nợ";
        }

        private void AddDaiLyBinding()
        {
            //Refresh lại
            txtMaDL.DataBindings.Clear();
            txtTenDL.DataBindings.Clear();
            txtSoDienThoai.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();

            txtNgayTiepNhan.Value = DateTime.Now;

            cbbQuan.SelectedIndex = -1;
            cbbHangThanhVien.SelectedIndex = -1;


            //Add lại binding
            txtMaDL.DataBindings.Add("Text", dgvDaiLy.DataSource, "MaDL");
            txtTenDL.DataBindings.Add("Text", dgvDaiLy.DataSource, "TenDL");
            txtSoDienThoai.DataBindings.Add("Text", dgvDaiLy.DataSource, "SDT");
            txtDiaChi.DataBindings.Add("Text", dgvDaiLy.DataSource, "DiaChi");
            txtNgayTiepNhan.DataBindings.Add("Text", dgvDaiLy.DataSource, "NgayTiepNhan");

            cbbQuan.DataSource = database.QUANs.ToList();
            cbbQuan.DisplayMember = "TENQUAN";
            cbbQuan.DataBindings.Add("Text", dgvDaiLy.DataSource, "Quan");

            cbbHangThanhVien.DataSource = database.UUDAITHANHVIENs.ToList();
            cbbHangThanhVien.DisplayMember = "HANGTHANHVIEN";
            cbbHangThanhVien.DataBindings.Add("Text", dgvDaiLy.DataSource, "HangThanhVien");
        }

        private void LoadThongTinDaiLy()
        {
            var dsDaiLy = from daily in database.DAILies
                          from quan in database.QUANs
                          from hangtv in database.UUDAITHANHVIENs
                          where daily.MAQUAN == quan.MAQUAN && daily.MAUUDAITHANHVIEN == hangtv.MAUUDAITHANHVIEN
                          select new
                          {
                              MaDL = daily.MADAILY,
                              TenDL = daily.TENDAILY,
                              DiaChi = daily.DIACHI,
                              Quan = quan.TENQUAN,
                              SDT = daily.SODIENTHOAI,
                              NgayTiepNhan = daily.NGAYTIEPNHAN,
                              NgayHDGanNhat = daily.NGAYHDGAN,
                              Diem = daily.DIEM,
                              HangThanhVien = hangtv.HANGTHANHVIEN,
                              TienNo = daily.TIENNO,
                          };

            // Add dữ liệu vào datagridview 
            dgvDaiLy.DataSource = dsDaiLy.ToList();
        }

        private void UCTraCuuDL_Load(object sender, EventArgs e)
        {
            // set value cho cbbQuan, cbbHangThanhVien lấy từ database
            cbbQuan.DataSource = database.QUANs.ToList();
            cbbQuan.DisplayMember = "TENQUAN";

            cbbHangThanhVien.DataSource = database.UUDAITHANHVIENs.ToList();
            cbbHangThanhVien.DisplayMember = "HANGTHANHVIEN";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMaDL.Text = "";
            txtTenDL.Text = "";
            txtSoDienThoai.Text = "";
            txtNgayTiepNhan.Value = DateTime.Now;
            txtDiaChi.Text = "";
            cbbQuan.SelectedIndex = -1;
            cbbHangThanhVien.SelectedIndex = -1;

            // Cho load lại thông tin đại lý để cập nhật data grid view
            LoadThongTinDaiLy();
        }        

        private void btnSua_Click(object sender, EventArgs e)
        {
            string MaDL = txtMaDL.Text;

            // Xét mã đại lý đã xuất hiện trong csdl hay chưa
            DAILY daily = database.DAILies.Where(dl => dl.MADAILY == MaDL).SingleOrDefault();

            if (daily == null)
            {
                MessageBox.Show("Mã đại lý này không tồn tại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtMaDL.Text == "" || txtTenDL.Text == "" || txtDiaChi.Text == "" || txtSoDienThoai.Text == "")
                {
                    MessageBox.Show("Vui lòng không để trống thông tin đại lý! \n(Trừ hạng thành viên)", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {                   
                    daily.TENDAILY = txtTenDL.Text;
                    daily.SODIENTHOAI = txtSoDienThoai.Text;
                    daily.NGAYTIEPNHAN = txtNgayTiepNhan.Value;
                    daily.DIACHI = txtDiaChi.Text;
                    daily.MAQUAN = ((QUAN)cbbQuan.SelectedValue).MAQUAN;

                    database.SaveChanges();
                    LoadThongTinDaiLy();
                    MessageBox.Show("Cập nhật thông tin đại lý học thành công!", "Thông báo");
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTenDL.Text == "" || txtDiaChi.Text == "" || txtSoDienThoai.Text == "")
            {
                MessageBox.Show("Vui lòng không để trống thông tin đại lý cần tìm! \n(Trừ mã đại lý, ngày tiếp nhận, hạng thành viên)", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var dsDaiLy = from daily in database.DAILies
                              from quan in database.QUANs
                              from hangtv in database.UUDAITHANHVIENs
                              where daily.MAQUAN == quan.MAQUAN && daily.MAUUDAITHANHVIEN == hangtv.MAUUDAITHANHVIEN && daily.TENDAILY == txtTenDL.Text
                              && daily.SODIENTHOAI == txtSoDienThoai.Text && daily.DIACHI == txtDiaChi.Text && daily.MAQUAN == ((QUAN)cbbQuan.SelectedValue).MAQUAN
                              select new
                              {
                                  MaDL = daily.MADAILY,
                                  TenDL = daily.TENDAILY,
                                  DiaChi = daily.DIACHI,
                                  Quan = quan.TENQUAN,
                                  SDT = daily.SODIENTHOAI,
                                  NgayTiepNhan = daily.NGAYTIEPNHAN,
                                  NgayHDGanNhat = daily.NGAYHDGAN,
                                  Diem = daily.DIEM,
                                  HangThanhVien = hangtv.HANGTHANHVIEN,
                                  TienNo = daily.TIENNO,
                              };

                // Add dữ liệu vào datagridview 
                dgvDaiLy.DataSource = dsDaiLy.ToList();
            }
        }

        // Chỉ cho nhập số vào txtSDT
        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Chỉ được nhập số và các phím control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || (e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

    }
}
