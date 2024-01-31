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
    public partial class UCTiepNhanHoSo : UserControl
    {
        QLCacDaiLyEntities database = new QLCacDaiLyEntities();

        public UCTiepNhanHoSo()
        {
            InitializeComponent();
        }

        private void UCTiepNhanHoSo_Load(object sender, EventArgs e)
        {
            // set value cho cbbQuan lấy từ database
            cbbQuan.DataSource = database.QUANs.ToList();
            cbbQuan.DisplayMember = "TENQUAN";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string MaDL = txtMaDL.Text;

            // Xét mã đại lý đã xuất hiện trong csdl hay chưa
            DAILY dl = database.DAILies.Where(d => d.MADAILY == MaDL).SingleOrDefault();

            if (dl != null)
            {
                MessageBox.Show("Mã đại lý này đã tồn tại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Không cho người dùng để trống các textbox
                if (txtMaDL.Text == "" || txtTenDL.Text == "" || txtTenChuDL.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin đại lý!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DAILY daily = new DAILY();
                    daily.MADAILY = MaDL;
                    daily.TENDAILY = txtTenDL.Text;
                    daily.TENCHUDAILY = txtTenChuDL.Text;
                    daily.DIACHI = txtDiaChi.Text;
                    daily.SODIENTHOAI = txtSDT.Text;
                    daily.MAQUAN = ((QUAN)cbbQuan.SelectedValue).MAQUAN;                    
                    daily.NGAYTIEPNHAN = txtNgayTiepNhan.Value;
                    daily.NGAYHDGAN = txtNgayTiepNhan.Value;
                    daily.DIEM = 0;
                    daily.TIENNO = 0;
                    daily.MAUUDAITHANHVIEN = "UD01";

                    database.DAILies.Add(daily);
                    database.SaveChanges();

                    MessageBox.Show("Thêm mới đại lý thành công!", "Thông báo");
                }
            }
        }

        // Chỉ cho nhập số vào txtSDT
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Chỉ được nhập số và các phím control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || (e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }       
    }
}
