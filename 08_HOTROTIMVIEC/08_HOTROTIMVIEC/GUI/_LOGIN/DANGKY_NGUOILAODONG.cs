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

namespace _08_HOTROTIMVIEC.GUI._LOGIN
{
    public partial class DANGKY_NGUOILAODONG : Form
    {
        BUS_NGUOILAODONG bUS_NGUOILAODONG;
        BUS_NGUOILAODONG_TAIKHOAN bUS_NGUOILAODONG_TAIKHOAN;
        BUS_SERVICES bUS_SERVICES;
        /////INIT
        private int maNLD_Cur = 0;
        private string txtImage = "";
        public DANGKY_NGUOILAODONG()
        {
            InitializeComponent();
        }

        private void DANGKY_NGUOILAODONG_Load(object sender, EventArgs e)
        {
            bUS_NGUOILAODONG = new BUS_NGUOILAODONG();
            bUS_NGUOILAODONG_TAIKHOAN = new BUS_NGUOILAODONG_TAIKHOAN();
            bUS_SERVICES = new BUS_SERVICES();
            ///KHOI TAO
            LoadInit();
            initDangXuat();
        }
        /////////////////////////INIT
        private void LoadInit()
        {
            bUS_NGUOILAODONG = new BUS_NGUOILAODONG();
            initGioiHan();
            maNLD_Cur = bUS_NGUOILAODONG.getMaNNLD_HT();
            txtTen.Text = "";
            txtCMND.Text = "";
            cbbGioiTinh.SelectedIndex = 0;
            dtP_NgaySinh.Value = DateTime.Now.AddYears(-17);
            txtDiaChi.Text = "";
            txtBangCap.Text = "";
            txtSDT.Text = "";
            //hinhanh
            txtImage = "";
            ptcB_Avatar.Image = null;
            ptcB_Avatar.BackColor = Color.White;
            //Taikhoan
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            txtNhapLai.Text = "";
        }
        private void initGioiHan()
        {
            txtTen.MaxLength = 50;
            txtDiaChi.MaxLength = 50;
            txtBangCap.MaxLength = 50;
            txtSDT.MaxLength = 10;
            txtCMND.MaxLength = 12;
            //TAIKHOAN
            txtTaiKhoan.MaxLength = 25;
            txtMatKhau.MaxLength = 25;
            txtNhapLai.MaxLength = 25;
        }
        private void dtP_NgaySinh_ValueChanged(object sender, EventArgs e)
        {
            DateTime hople = DateTime.Now.AddYears(-17);
            if (DateTime.Now.Year - dtP_NgaySinh.Value.Year <= 16)
            {
                MessageBox.Show("Yêu cầu phải lớn hơn 16 tuổi!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtP_NgaySinh.Value = hople;
            }
                
        }
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Không được ký tự khác ngoài số!");
            }    
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Không được ký tự khác ngoài số!");
            }
        }
        //////////////////////////////
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "D:\\trancongthuc\\HOTROTIMVIEC\\08_HOTROTIMVIEC\\08_HOTROTIMVIEC\\bin\\Debug\\NGUOILD";//Định đường dẫn khi mở cửa sổ tìm ảnh
            openFileDialog.FileName = "";// Tên ảnh
            openFileDialog.Filter = "Images(*.jpg)|*.jpg|PNG (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.ShowDialog();// Hiện cửa sổ 
            if (openFileDialog.FileName != "")
            {
                txtImage = System.IO.Path.GetFileName(openFileDialog.FileName);// Hiển thị tên ảnh lên Textbox
                ptcB_Avatar.Image = Image.FromFile(openFileDialog.FileName);//Hiện ảnh lên Picbox.
                ptcB_Avatar.Show();
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if(checkFullOP())
            {
                bUS_SERVICES = new BUS_SERVICES();
                //////txtBangCap_stam
                string bangCap_stamp = "";
                if (!string.IsNullOrEmpty(txtBangCap.Text))
                    bangCap_stamp = txtBangCap.Text;
                if (!string.IsNullOrEmpty(txtImage))
                {
                    if (bUS_SERVICES.Check_NLD_image_TrungTen(txtImage) == 0)
                    {
                        bUS_SERVICES.Add_ThongTin_TaiKhoan_NLD(maNLD_Cur + 1, txtTen.Text, txtCMND.Text, cbbGioiTinh.Text, dtP_NgaySinh.Value.Date, txtDiaChi.Text, txtSDT.Text, bangCap_stamp, txtTaiKhoan.Text, txtNhapLai.Text);
                        bUS_SERVICES.Dky_NLD_Image(maNLD_Cur + 1, txtImage, 1);
                        MessageBox.Show("Đăng Ký Thành Công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadInit();
                    }
                    else
                        MessageBox.Show("Lỗi lưu ảnh, vì hình ảnh đã trùng!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bUS_SERVICES.Add_ThongTin_TaiKhoan_NLD(maNLD_Cur + 1, txtTen.Text, txtCMND.Text, cbbGioiTinh.Text, dtP_NgaySinh.Value.Date, txtDiaChi.Text, txtSDT.Text, bangCap_stamp, txtTaiKhoan.Text, txtNhapLai.Text);
                    MessageBox.Show("Đăng Ký Thành Công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bUS_SERVICES.Dky_NLD_Image(maNLD_Cur + 1, txtImage, 0);
                    LoadInit();
                } 
            }    
        }

        private bool checkFullOP()
        {
            bool check = false;
            bUS_NGUOILAODONG = new BUS_NGUOILAODONG();
            bUS_NGUOILAODONG_TAIKHOAN = new BUS_NGUOILAODONG_TAIKHOAN();
            if (!string.IsNullOrEmpty(txtTen.Text) && !string.IsNullOrEmpty(txtCMND.Text) && !string.IsNullOrEmpty(cbbGioiTinh.Text) && !string.IsNullOrEmpty(txtDiaChi.Text) && (DateTime.Now.Year - dtP_NgaySinh.Value.Year >= 16) && !string.IsNullOrEmpty(txtSDT.Text) && !string.IsNullOrEmpty(txtTaiKhoan.Text) && !string.IsNullOrEmpty(txtMatKhau.Text) && !string.IsNullOrEmpty(txtNhapLai.Text))
                if (bUS_NGUOILAODONG.Check_CMND_NLD(txtCMND.Text) == 0)
                {
                    if (bUS_NGUOILAODONG.Check_SDT_NLD(txtSDT.Text) == 0)
                    {
                        if (bUS_NGUOILAODONG_TAIKHOAN.Check_taikhoan_NLD(txtTaiKhoan.Text) == 0)
                        {
                            if (txtMatKhau.Text.Length > 6 && txtNhapLai.Text.Length > 6)
                            {
                                if(txtMatKhau.Text.Equals(txtNhapLai.Text))
                                    check = true;
                                else
                                    MessageBox.Show("Mật khẩu nhập lại không đúng!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                txtMatKhau.Focus();
                                check = false;
                                MessageBox.Show("Yêu cầu mật khẩu phải nhiều hơn 6 ký tự!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            txtTaiKhoan.Focus();
                            check = false;
                            MessageBox.Show("Tài khoản đăng kí đã trùng!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        txtSDT.Focus();
                        check = false;
                        MessageBox.Show("Sô điện thoại đã được đăng kí!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    txtCMND.Focus();
                    check = false;
                    MessageBox.Show("Sô CMND đã được đăng kí!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            else
            {
                check = false;
                MessageBox.Show("Yêu cầu nhập những thông tin cần thiết (trừ Bằng Cấp)!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return check;
        }
        ////////ICON TRUE FALSE
        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTaiKhoan.Text))
                if (bUS_NGUOILAODONG_TAIKHOAN.Check_taikhoan_NLD(txtTaiKhoan.Text) == 0)
                {
                    ptb_TK.Show();
                    ptb_TK.Image = Image.FromFile("Icon/icon_true.png");
                    
                }
                else
                {
                    ptb_TK.Show();
                    ptb_TK.Image = Image.FromFile("Icon/icon_false.png");
                }
            else
                ptb_TK.Hide();
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMatKhau.Text))
                if (txtMatKhau.Text.Length > 6)
                {
                    ptb_MK.Show();
                    ptb_MK.Image = Image.FromFile("Icon/icon_true.png");

                }
                else
                {
                    ptb_MK.Show();
                    ptb_MK.Image = Image.FromFile("Icon/icon_false.png");
                }
            else
                ptb_MK.Hide();
        }

        private void txtNhapLai_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNhapLai.Text))
                if (txtNhapLai.Text.Equals(txtMatKhau.Text) && txtNhapLai.Text.Length > 6)
                {
                    ptb_NL.Show();
                    ptb_NL.Image = Image.FromFile("Icon/icon_true.png");

                }
                else
                {
                    ptb_NL.Show();
                    ptb_NL.Image = Image.FromFile("Icon/icon_false.png");
                }
            else
                ptb_NL.Hide();
        }
        /////////////Tro ve
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
            DialogResult dlr = MessageBox.Show("Bạn có muốn thoát khỏi đăng kí người lao động không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                this.Hide();
                SELECT_DANGKY sl = new SELECT_DANGKY();
                sl.ShowDialog();
                this.Close();
            }
        }
        /////////////////////////////
        private void ckbMK_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbMK.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
                txtNhapLai.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
                txtNhapLai.UseSystemPasswordChar = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadInit();
        }
    }
}
