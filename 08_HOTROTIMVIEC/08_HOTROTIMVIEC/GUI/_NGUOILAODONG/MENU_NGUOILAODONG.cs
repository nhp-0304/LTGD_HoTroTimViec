using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _08_HOTROTIMVIEC.BUS;

namespace _08_HOTROTIMVIEC.GUI._NGUOILAODONG
{
    public partial class MENU_NGUOILAODONG : Form
    {
        NGUOILAODONG getNLD;
        BUS_NGUOILAODONG_TAIKHOAN bUS_NGUOILAODONG_TAIKHOAN;
        public static NGUOILAODONG_TAIKHOAN nld_Cur_TK;
        BUS_NGUOILAODONG bUS_NGUOILAODONG;
        
        //TITLE
        const string str = "--CHÀO MỪNG BẠN ĐẾN VỚI HỆ THỐNG HỖ TRỢ TÌM VIỆC LÀM NHANH--!!";

        private static int? manld;
        public int? MANLD
        {
            get { return manld; }
            set { manld = value; }
        }

        public MENU_NGUOILAODONG()
        {
            InitializeComponent();
        }

        private void MENU_NGUOILAODONG_Load(object sender, EventArgs e)
        {
            //BUS NEW
            bUS_NGUOILAODONG = new BUS_NGUOILAODONG();
            bUS_NGUOILAODONG_TAIKHOAN = new BUS_NGUOILAODONG_TAIKHOAN();
            getNLD = bUS_NGUOILAODONG.getNLD_BangMaNLD(manld);
            nld_Cur_TK = bUS_NGUOILAODONG_TAIKHOAN.getTaiKhoanByMaNLD(getNLD.MaNLD);
            //KHOI TAO TRANG CHU
            this.btnTrangChu_Click(sender, e);
            initDangXuat();
            ///
            txtTitle.Text = str;
            timerTitle_Tick(sender, e);
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            panel_main.Controls.Clear();
            UC_TrangChu_NLD tc = new UC_TrangChu_NLD();
            panel_main.Controls.Add(tc);
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            panel_main.Controls.Clear();
            UC_ThongTinNLD tt = new UC_ThongTinNLD();
            panel_main.Controls.Add(tt);
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            panel_main.Controls.Clear();
            UC_DoiMatKhau dmk = new UC_DoiMatKhau();
            panel_main.Controls.Add(dmk);
        }

        private void btnQuanLyDon_Click(object sender, EventArgs e)
        {
            panel_main.Controls.Clear();
            UC_QuanLyDon_CaNhan qld = new UC_QuanLyDon_CaNhan();
            panel_main.Controls.Add(qld);
        }

        private void btnXemXuHuong_Click(object sender, EventArgs e)
        {
            panel_main.Controls.Clear();
            UC_XuHuongCongViec xh = new UC_XuHuongCongViec();
            panel_main.Controls.Add(xh);
        }
        /////////////ĐĂNG XUẤT
        private void lblDangXuat_MouseMove(object sender, MouseEventArgs e)
        {
            lblDangXuat.Font = new Font("Microsoft Sans Serif", 12, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))));
            lblDangXuat.ForeColor = Color.Red;
        }

        private void initDangXuat()
        {
            lblDangXuat.Font = new Font("Microsoft Sans Serif", 10);
            lblDangXuat.ForeColor = Color.DarkBlue;
        }

        private void lblDangXuat_MouseLeave(object sender, EventArgs e)
        {
            initDangXuat();
        }

        private void lblDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                this.Hide();
                LOGIN lg = new LOGIN();
                lg.ShowDialog();
                this.Close();
            }
        }
        ///////////LOAD TIEU DE
        private void timerTitle_Tick(object sender, EventArgs e)
        {
            txtTitle.Text = txtTitle.Text.Substring(txtTitle.Text.Length - 1, 1) + txtTitle.Text.Substring(0, txtTitle.Text.Length - 1);
        }
    }
}
