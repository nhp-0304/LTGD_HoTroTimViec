using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _08_HOTROTIMVIEC.BUS;

namespace _08_HOTROTIMVIEC.GUI._DONVITUYENDUNG
{
    public partial class MENU_DONVITUYENDUNG_TAIKHOAN : Form
    {
        LOGIN logout;
        DONVITUYENDUNG dvtd;
        MENU_DONVITUYENDUNG_VIECLAM frmDVTD;

        BUS_DONVITUYENDUNG bUS_DONVITUYENDUNG;
        BUS_DONVITUYENDUNG_TAIKHOAN bUS_DONVITUYENDUNG_TAIKHOAN;
        BUS_SERVICES bUS_SERVICES;

        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        public MENU_DONVITUYENDUNG_TAIKHOAN(DONVITUYENDUNG getDVTD_ThamSo, MENU_DONVITUYENDUNG_VIECLAM frmDVTD_ThamSo)
        {
            InitializeComponent();
            dvtd = getDVTD_ThamSo;
            frmDVTD = frmDVTD_ThamSo;

            /////////////////////////////////////////// MK HIEN TAI
            this.txtMKHT.ForeColor = Color.Gray;
            this.txtMKHT.Text = " Mật khẩu hiện tại";
            this.txtMKHT.Leave += new System.EventHandler(this.txtMKHT_Leave);
            this.txtMKHT.Enter += new System.EventHandler(this.txtMKHT_Enter);

            /////////////////////////////////////////// MK MOI
            this.txtMKMoi.ForeColor = Color.Gray;
            this.txtMKMoi.Text = " Mật khẩu mới";
            this.txtMKMoi.Leave += new System.EventHandler(this.txtMKMoi_Leave);
            this.txtMKMoi.Enter += new System.EventHandler(this.txtMKMoi_Enter);

            /////////////////////////////////////////// NHAP LAI MK
            this.txtMKNhapLai.ForeColor = Color.Gray;
            this.txtMKNhapLai.Text = " Nhập lại mật khẩu mới";
            this.txtMKNhapLai.Leave += new System.EventHandler(this.txtMKNhapLai_Leave);
            this.txtMKNhapLai.Enter += new System.EventHandler(this.txtMKNhapLai_Enter);
        }

        private void MENU_DONVITUYENDUNG_TAIKHOAN_Load(object sender, EventArgs e)
        {
            bUS_DONVITUYENDUNG = new BUS_DONVITUYENDUNG();
            bUS_DONVITUYENDUNG_TAIKHOAN = new BUS_DONVITUYENDUNG_TAIKHOAN();
            bUS_SERVICES = new BUS_SERVICES();

            this.loadData();
            this.loadDataView();
        }

        ///////////////////////////////////////////////////////////////////////
        public void loadData()
        {
            if (!string.IsNullOrEmpty(bUS_SERVICES.getLinkDV(dvtd.MaDV)))
                this.pBoxAvtDVTD.Image = Image.FromFile("DONVI/" + bUS_SERVICES.getLinkDV(dvtd.MaDV));
            else
                this.pBoxAvtDVTD.Image = Properties.Resources.noImage;

            this.txtMaDV.Text = dvtd.MaDV;
            this.lblTenDV.Text = dvtd.TenDV;
            this.richtxtDiaChi.Text = dvtd.DiaChi;
            this.txtSDT.Text = dvtd.SDT;

            if (dvtd.TrangThai)
            {
                this.txtTrangThai.Text = " Bình thường";
            }
            else
            {
                this.txtTrangThai.Text = " Bị khóa!";
            }
        }

        public void loadDataView()
        {
            this.txtMaDV.BackColor = Color.White;
            this.richtxtDiaChi.BackColor = Color.White;
            this.txtSDT.BackColor = Color.White;
            this.txtTrangThai.ForeColor = Color.Black;
            if (this.txtTrangThai.Text == " Bình thường")
            {
                this.txtTrangThai.BackColor = Color.LimeGreen;
            }
            if (this.txtTrangThai.Text == " Bị khóa!")
            {
                this.txtTrangThai.BackColor = Color.LightCoral;
            }
        }

        ///////////////////////////////////////////////////////////////////////
        private void pBoxAvtDVTD_Click(object sender, EventArgs e)
        {
            SUAAVTDONVITUYENDUNG frmSuaAvtDVTD = new SUAAVTDONVITUYENDUNG(dvtd);
            frmSuaAvtDVTD.ShowDialog();
        }

        ///////////////////////////////////////////////////////////////////////
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.txtMKHT.Text = "";
            this.txtMKHT_Leave(sender, e);
            this.pBoxMKHT.Image = Properties.Resources.White;
            this.txtMKMoi.Text = "";
            this.txtMKMoi_Leave(sender, e);
            this.pBoxMKMoi.Image = Properties.Resources.White;
            this.txtMKNhapLai.Text = "";
            this.txtMKNhapLai_Leave(sender, e);
            this.pBoxMKNhapLai.Image = Properties.Resources.White;

            this.btnHienAn.Image = Properties.Resources.Hien;
            hienAn = false;

            DoiMKClick = 1;
            this.panelDoiMK.Visible = false;
            this.btnHienAn.Visible = false;
            this.btnHienAn.Dock = DockStyle.None;
            this.btnCancel.Visible = false;

            this.Dispose();
            this.Close();
        }

        ///////////////////////////////////////////////////////////////////////
        private void btnUnlock_Click(object sender, EventArgs e)
        {
            if (!(this.richtxtDiaChi.Enabled && this.txtSDT.Enabled))
            {
                this.btnUnlock.Image = Properties.Resources.Unlock;
                this.btnUnlock.BackColor = Color.White;

                this.richtxtDiaChi.Enabled = true;
                this.txtSDT.Enabled = true;
            }
            else
            {
                this.btnUnlock.Image = Properties.Resources.Lock;
                this.btnUnlock.BackColor = Color.Gainsboro;

                this.richtxtDiaChi.Enabled = false;
                this.txtSDT.Enabled = false;
            }
        }

        private void btnSua_MouseHover(object sender, EventArgs e)
        {
            this.btnSua.FlatAppearance.BorderColor = Color.MidnightBlue;
            this.btnSua.BackColor = Color.MidnightBlue;
            this.btnSua.ForeColor = Color.White;
        }

        private void btnSua_MouseLeave(object sender, EventArgs e)
        {
            this.btnSua.FlatAppearance.BorderColor = Color.Gainsboro;
            this.btnSua.BackColor = Color.White;
            this.btnSua.ForeColor = Color.Black;
        }

        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private bool checkSua()
        {
            if (!(this.richtxtDiaChi.Enabled && this.txtSDT.Enabled))
            {
                MessageBox.Show("Chưa mở khóa!", "Thông báo");
                return false;
            }
            if (string.IsNullOrWhiteSpace(this.richtxtDiaChi.Text) || string.IsNullOrWhiteSpace(this.txtSDT.Text))
            {
                MessageBox.Show("Chưa nhập đủ thông tin!", "Thông báo");
                return false;
            }
            if (!IsNumber(this.txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Không thể sửa!");
                return false;
            }
            return true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (checkSua())
            {
                try
                {
                    bUS_DONVITUYENDUNG.suaDVTD(this.txtMaDV.Text, this.richtxtDiaChi.Text, this.txtSDT.Text);
                    MessageBox.Show("Sửa thành công!!!", "Thông báo");

                    this.btnUnlock.Image = Properties.Resources.Lock;
                    this.btnUnlock.BackColor = Color.Gainsboro;

                    this.richtxtDiaChi.Enabled = false;
                    this.txtSDT.Enabled = false;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Sửa thất bại!!!", "Lỗi!");
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////
        private void btnDangXuat_MouseHover(object sender, EventArgs e)
        {
            this.btnDangXuat.Image = Properties.Resources.DangXuatWhite;
            this.btnDangXuat.BackColor = Color.MidnightBlue;
        }

        private void btnDangXuat_MouseLeave(object sender, EventArgs e)
        {
            this.btnDangXuat.Image = Properties.Resources.DangXuatBlack;
            this.btnDangXuat.BackColor = Color.White;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận đăng xuất?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Dispose();
                this.Close();
                frmDVTD.Dispose();
                frmDVTD.Close();
                logout = new LOGIN();
                logout.ShowDialog();
            }
        }

        ///////////////////////////////////////////////////////////////////////
        private void btnDoiMK_MouseHover(object sender, EventArgs e)
        {
            this.btnDoiMK.BackColor = Color.MidnightBlue;
            this.btnDoiMK.ForeColor = Color.White;
        }

        private void btnDoiMK_MouseLeave(object sender, EventArgs e)
        {
            this.btnDoiMK.BackColor = Color.White;
            this.btnDoiMK.ForeColor = Color.Black;
        }

        private bool checkDoiMK()
        {
            if (string.IsNullOrWhiteSpace(this.txtMKHT.Text) || this.txtMKHT.ForeColor == Color.Gray ||
                string.IsNullOrWhiteSpace(this.txtMKMoi.Text) || this.txtMKMoi.ForeColor == Color.Gray ||
                string.IsNullOrWhiteSpace(this.txtMKNhapLai.Text) || this.txtMKNhapLai.ForeColor == Color.Gray)
            {
                MessageBox.Show("Chưa nhập đủ thông tin!", "Thông báo");
                return false;
            }
            if (!this.bUS_DONVITUYENDUNG_TAIKHOAN.kTraMKHT(dvtd.MaDV, this.txtMKHT.Text))
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng.", "Không thể đổi mật khẩu!");
                return false;
            }
            if (this.txtMKMoi.TextLength < 7)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 7 ký tự!", "Thông báo");
                return false;
            }
            if (!(this.txtMKMoi.Text == this.txtMKNhapLai.Text))
            {
                MessageBox.Show("Mật khẩu mới và nhập lại mật khẩu mới không trùng khớp.", "Không thể đổi mật khẩu!");
                return false;
            }
            return true;
        }

        private static int DoiMKClick = 1;
        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            if (DoiMKClick == 2)
            {
                if (checkDoiMK())
                {
                    if (MessageBox.Show("Xác nhận đổi mật khẩu?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            this.bUS_DONVITUYENDUNG_TAIKHOAN.DVTD_TK_doiMK(dvtd.MaDV, this.txtMKNhapLai.Text);
                            MessageBox.Show("Đổi mật khẩu thành công!!!", "Thông báo");

                            this.txtMKHT.Text = "";
                            this.txtMKHT_Leave(sender, e);
                            this.pBoxMKHT.Image = Properties.Resources.White;
                            this.txtMKMoi.Text = "";
                            this.txtMKMoi_Leave(sender, e);
                            this.pBoxMKMoi.Image = Properties.Resources.White;
                            this.txtMKNhapLai.Text = "";
                            this.txtMKNhapLai_Leave(sender, e);
                            this.pBoxMKNhapLai.Image = Properties.Resources.White;

                            this.btnHienAn.Image = Properties.Resources.Hien;
                            hienAn = false;
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Đổi mật khẩu thất bại!!!", "Lỗi!");
                        }
                    }
                }
            }

            if (DoiMKClick == 1)
            {
                this.panelDoiMK.Visible = true;
                this.btnHienAn.Visible = true;
                this.btnHienAn.Dock = DockStyle.Left;
                this.btnCancel.Visible = true;
                DoiMKClick = 2;
            }
        }

        private void txtMKHT_Leave(object sender, EventArgs e)
        {
            if (this.txtMKHT.Text == "")
            {
                this.txtMKHT.UseSystemPasswordChar = false;
                this.txtMKHT.Text = " Mật khẩu hiện tại";
                this.txtMKHT.ForeColor = Color.Gray;
            }
        }

        private void txtMKHT_Enter(object sender, EventArgs e)
        {
            if (this.txtMKHT.Text == " Mật khẩu hiện tại")
            {
                this.txtMKHT.Text = "";
                this.txtMKHT.ForeColor = Color.Black;
                this.txtMKHT.UseSystemPasswordChar = true;
            }

            if ((!this.txtMKMoi.UseSystemPasswordChar && !this.txtMKMoi.Text.Equals(" Mật khẩu mới")) ||
                (!this.txtMKNhapLai.UseSystemPasswordChar && !this.txtMKNhapLai.Text.Equals(" Nhập lại mật khẩu mới")))
                this.txtMKHT.UseSystemPasswordChar = false;
        }

        private void txtMKHT_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtMKHT.Text))
            {
                if (this.bUS_DONVITUYENDUNG_TAIKHOAN.kTraMKHT(dvtd.MaDV, this.txtMKHT.Text))
                {
                    this.pBoxMKHT.Image = Properties.Resources.MatKhauDung;
                }
                else
                {
                    this.pBoxMKHT.Image = Properties.Resources.MatKhauSai;
                }
            }
            else
            {
                this.pBoxMKHT.Image = Properties.Resources.White;
            }
        }

        private void txtMKMoi_Leave(object sender, EventArgs e)
        {
            if (this.txtMKMoi.Text == "")
            {
                this.txtMKMoi.UseSystemPasswordChar = false;
                this.txtMKMoi.Text = " Mật khẩu mới";
                this.txtMKMoi.ForeColor = Color.Gray;
            }
        }

        private void txtMKMoi_Enter(object sender, EventArgs e)
        {
            if (this.txtMKMoi.Text == " Mật khẩu mới")
            {
                this.txtMKMoi.Text = "";
                this.txtMKMoi.ForeColor = Color.Black;
                this.txtMKMoi.UseSystemPasswordChar = true;
            }

            if ((!this.txtMKHT.UseSystemPasswordChar && !this.txtMKHT.Text.Equals(" Mật khẩu hiện tại")) ||
                (!this.txtMKNhapLai.UseSystemPasswordChar && !this.txtMKNhapLai.Text.Equals(" Nhập lại mật khẩu mới")))
                this.txtMKMoi.UseSystemPasswordChar = false;
        }

        private void txtMKMoi_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtMKMoi.Text))
            {
                if (this.txtMKMoi.TextLength >= 7)
                {
                    this.pBoxMKMoi.Image = Properties.Resources.MatKhauDung;
                }
                else
                {
                    this.pBoxMKMoi.Image = Properties.Resources.MatKhauSai;
                }
            }
            else
            {
                this.pBoxMKMoi.Image = Properties.Resources.White;
            }
        }

        private void txtMKNhapLai_Leave(object sender, EventArgs e)
        {
            if (this.txtMKNhapLai.Text == "")
            {
                this.txtMKNhapLai.UseSystemPasswordChar = false;
                this.txtMKNhapLai.Text = " Nhập lại mật khẩu mới";
                this.txtMKNhapLai.ForeColor = Color.Gray;
            }
        }

        private void txtMKNhapLai_Enter(object sender, EventArgs e)
        {
            if (this.txtMKNhapLai.Text == " Nhập lại mật khẩu mới")
            {
                this.txtMKNhapLai.Text = "";
                this.txtMKNhapLai.ForeColor = Color.Black;
                this.txtMKNhapLai.UseSystemPasswordChar = true;
            }

            if ((!this.txtMKHT.UseSystemPasswordChar && !this.txtMKHT.Text.Equals(" Mật khẩu hiện tại")) ||
                (!this.txtMKMoi.UseSystemPasswordChar && !this.txtMKMoi.Text.Equals(" Mật khẩu mới")))
                this.txtMKNhapLai.UseSystemPasswordChar = false;
        }

        private void txtMKNhapLai_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtMKNhapLai.Text))
            {
                if ((this.txtMKMoi.TextLength >= 7) && (this.txtMKMoi.Text == this.txtMKNhapLai.Text))
                {
                    this.pBoxMKNhapLai.Image = Properties.Resources.MatKhauDung;
                }
                else
                {
                    this.pBoxMKNhapLai.Image = Properties.Resources.MatKhauSai;
                }
            }
            else
            {
                this.pBoxMKNhapLai.Image = Properties.Resources.White;
            }
        }

        private static bool hienAn = false;
        private void btnHienAn_Click(object sender, EventArgs e)
        {
            if (!hienAn)
            {
                this.btnHienAn.Image = Properties.Resources.An;
                hienAn = true;
            }
            else
            {
                this.btnHienAn.Image = Properties.Resources.Hien;
                hienAn = false;
            }

            ////////////////////////////////////////////////// WATERMARK
            if (this.txtMKHT.UseSystemPasswordChar || this.txtMKHT.Text.Equals(" Mật khẩu hiện tại"))
            {
                this.txtMKHT.UseSystemPasswordChar = false;
            }
            else
            {
                this.txtMKHT.UseSystemPasswordChar = true;
            }

            if (this.txtMKMoi.UseSystemPasswordChar || this.txtMKMoi.Text.Equals(" Mật khẩu mới"))
            {
                this.txtMKMoi.UseSystemPasswordChar = false;
            }
            else
            {
                this.txtMKMoi.UseSystemPasswordChar = true;
            }

            if (this.txtMKNhapLai.UseSystemPasswordChar || this.txtMKNhapLai.Text.Equals(" Nhập lại mật khẩu mới"))
            {
                this.txtMKNhapLai.UseSystemPasswordChar = false;
            }
            else
            {
                this.txtMKNhapLai.UseSystemPasswordChar = true;
            }
        }

        ///////////////////////////////////////////////////////////////////////
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtMKHT.Text = "";
            this.txtMKHT_Leave(sender, e);
            this.pBoxMKHT.Image = Properties.Resources.White;
            this.txtMKMoi.Text = "";
            this.txtMKMoi_Leave(sender, e);
            this.pBoxMKMoi.Image = Properties.Resources.White;
            this.txtMKNhapLai.Text = "";
            this.txtMKNhapLai_Leave(sender, e);
            this.pBoxMKNhapLai.Image = Properties.Resources.White;

            this.btnHienAn.Image = Properties.Resources.Hien;
            hienAn = false;

            DoiMKClick = 1;
            this.panelDoiMK.Visible = false;
            this.btnHienAn.Visible = false;
            this.btnHienAn.Dock = DockStyle.None;
            this.btnCancel.Visible = false;
        }

        ////////////////////////////////////////////////////////////////// GD
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }
    }
}
