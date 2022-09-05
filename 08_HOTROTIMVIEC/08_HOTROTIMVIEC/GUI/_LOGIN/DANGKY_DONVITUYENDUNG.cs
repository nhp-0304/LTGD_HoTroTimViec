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
    public partial class DANGKY_DONVITUYENDUNG : Form
    {
        BUS_DONVITUYENDUNG bUS_DONVITUYENDUNG;
        BUS_SERVICES bUS_SERVICES;
        private string txtImage = "";
        public DANGKY_DONVITUYENDUNG()
        {
            InitializeComponent();
        }
        private void DANGKY_DONVITUYENDUNG_Load(object sender, EventArgs e)
        {
            bUS_DONVITUYENDUNG = new BUS_DONVITUYENDUNG();
            bUS_SERVICES = new BUS_SERVICES();

            //INIT
            LoadInit();
            initDangXuat();
        }

        private void initGioiHan()
        {
            txtMaDV.MaxLength = 10;
            txtTenDV.MaxLength = 50;
            txtDiaChi.MaxLength = 50;
            txtSDT.MaxLength = 10;
        }

        //////////Text change
        private void txtMaDV_TextChanged(object sender, EventArgs e)
        {
            txtTaiKhoan.Text = txtMaDV.Text;
        }
        ////////ICON TRUE FALSE
        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTaiKhoan.Text))
                if (bUS_DONVITUYENDUNG.Check_MaDV_DVTD(txtTaiKhoan.Text) == 0)
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
            DialogResult dlr = MessageBox.Show("Bạn có muốn thoát khỏi đăng kí đơn vị tuyển dụng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                this.Hide();
                SELECT_DANGKY sl = new SELECT_DANGKY();
                sl.ShowDialog();
                this.Close();
            }
        }

        private void txtMaDV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsUpper(e.KeyChar) && !Char.IsDigit(e.KeyChar))  && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Không được ký tự khác ngoài chữ in và số!");
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
        private bool checkFullOP()
        {
            bool check = false;
            bUS_DONVITUYENDUNG = new BUS_DONVITUYENDUNG();
            if (!string.IsNullOrEmpty(txtTenDV.Text) && !string.IsNullOrEmpty(txtMaDV.Text) && !string.IsNullOrEmpty(txtDiaChi.Text) && !string.IsNullOrEmpty(txtSDT.Text) && !string.IsNullOrEmpty(txtTaiKhoan.Text) && !string.IsNullOrEmpty(txtMatKhau.Text) && !string.IsNullOrEmpty(txtNhapLai.Text))
            {
                if(bUS_DONVITUYENDUNG.Check_MaDV_DVTD(txtMaDV.Text) == 0)
                { 
                    if(bUS_DONVITUYENDUNG.Check_SDT_DVTD(txtSDT.Text) == 0)
                    {
                        if (txtMatKhau.Text.Length > 6 && txtNhapLai.Text.Length > 6)
                        {
                            if (txtMatKhau.Text.Equals(txtNhapLai.Text))
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
                        check = false;
                        txtSDT.Focus();
                        MessageBox.Show("Số điện thoại của đơn vị đã được sử dụng!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }    
                }
                else
                {
                    check = false;
                    txtMaDV.Focus();
                    MessageBox.Show("Mã đơn vị đã được sử dụng!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }    
            }    
            else
            {
                check = false;
                MessageBox.Show("Yêu cầu nhập đầy đủ thông tin!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return check;
        }
        private void LoadInit()
        {
            bUS_DONVITUYENDUNG = new BUS_DONVITUYENDUNG();
            initGioiHan();
            txtMaDV.Text = "";
            txtTenDV.Text = "";
            txtDiaChi.Text = "";
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

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if(checkFullOP())
            {
                bUS_SERVICES = new BUS_SERVICES();
                if (!string.IsNullOrEmpty(txtImage))
                {
                    if (bUS_SERVICES.Check_DVTD_image_TrungTen(txtImage) == 0)
                    {
                        bUS_SERVICES.Add_ThongTin_TaiKhoan_DVTD(txtMaDV.Text,txtTenDV.Text,txtDiaChi.Text,txtSDT.Text,txtNhapLai.Text);
                        bUS_SERVICES.Dky_DVTD_Image(txtMaDV.Text, txtImage, 1);
                        MessageBox.Show("Đăng Ký Thành Công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadInit();
                    }
                    else
                        MessageBox.Show("Lỗi lưu ảnh, vì hình ảnh đã trùng!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    bUS_SERVICES.Add_ThongTin_TaiKhoan_DVTD(txtMaDV.Text, txtTenDV.Text, txtDiaChi.Text, txtSDT.Text, txtNhapLai.Text);
                    MessageBox.Show("Đăng Ký Thành Công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bUS_SERVICES.Dky_DVTD_Image(txtMaDV.Text, txtImage, 0);
                    LoadInit();
                }
            }    
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "D:\\trancongthuc\\HOTROTIMVIEC\\08_HOTROTIMVIEC\\08_HOTROTIMVIEC\\bin\\Debug\\DONVI";//Định đường dẫn khi mở cửa sổ tìm ảnh
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
