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
    public partial class UCXuatPhieuThuTien : UserControl
    {
        QLCacDaiLyEntities database = new QLCacDaiLyEntities();
        public UCXuatPhieuThuTien()
        {
            InitializeComponent();
        }

        private void UCXuatPhieuThuTien_Load(object sender, EventArgs e)
        {
            cbbQuan.DataSource = database.QUANs.ToList();
            cbbQuan.DisplayMember = "TENQUAN";
        }

        private void btnThu_Click(object sender, EventArgs e)
        {
            string MaDL = txtMaDL.Text;

            // Xét mã phiếu thu tiền và mã đại lý đã xuất hiện trong csdl hay chưa
            DAILY dl = database.DAILies.Where(d => d.MADAILY == MaDL).SingleOrDefault();

            if (dl == null)
            {
                MessageBox.Show("Mã đại lý này chưa tồn tại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                // Không cho người dùng để trống các textbox
                if (/*MaPhieu == "" ||*/ MaDL == "" || txtTenDL.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "" || txtSoTienThu.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ các thông tin!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Kiểm tra người dùng nhập thông tin đại lý đúng hay không
                else if (txtTenDL.Text != dl.TENDAILY || txtDiaChi.Text != dl.DIACHI || txtSDT.Text != dl.SODIENTHOAI || ((QUAN)cbbQuan.SelectedValue).MAQUAN != dl.MAQUAN)
                {
                    MessageBox.Show("Thông tin đại lý sai \nVui lòng nhập lại thông tin đại lý!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    PHIEUTHUTIEN phieu = new PHIEUTHUTIEN();

                    // Count dòng trong bảng PHIEUTHUTIEN để tự cập nhật mã phiếu
                    var phieu1 = from p in database.PHIEUTHUTIENs
                                 select p;
                    for (int i = 0; i < phieu1.Count(); i++)
                    {
                        phieu.MAPHIEUTHUTIEN = "PTT" + (i+2);
                    }

                    phieu.NGAYTHUTIEN = txtNgayThuTien.Value;
                    phieu.SOTIENTHU = Convert.ToDouble(txtSoTienThu.Text);
                    phieu.MADAILY = MaDL;

                    // TÍNH LẠI TIỀN NỢ ĐẠI LÝ SAU KHI THU TIỀN
                    double NoCu = dl.TIENNO;
                    dl.TIENNO = NoCu - Convert.ToDouble(txtSoTienThu.Text);

                    //database.DAILies.Add(dl);
                    database.PHIEUTHUTIENs.Add(phieu);
                    database.SaveChanges();

                    MessageBox.Show("Đã thu tiền đại lý thành công");                    
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
