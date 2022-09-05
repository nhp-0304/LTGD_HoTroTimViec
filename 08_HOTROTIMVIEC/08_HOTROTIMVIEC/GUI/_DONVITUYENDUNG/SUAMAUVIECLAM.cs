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
    public partial class SUAMAUVIECLAM : Form
    {
        MENU_DANHSACHCONGVIEC frmDSCV;
        BUS_VIECLAM bUS_VIECLAM;

        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        public SUAMAUVIECLAM(MENU_DANHSACHCONGVIEC frmDSCV_TS)
        {
            InitializeComponent();
            this.frmDSCV = frmDSCV_TS;
        }

        private void SUAMAUVIECLAM_Load(object sender, EventArgs e)
        {
            bUS_VIECLAM = new BUS_VIECLAM();
        }

        /////////////////////////////////////////////////////////////////////////////////
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        /////////////////////////////////////////////////////////////////////////////////
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
            if (string.IsNullOrWhiteSpace(this.txtMaViec.Text) || string.IsNullOrWhiteSpace(this.txtTenViec.Text) ||
                string.IsNullOrWhiteSpace(this.txtMucLuong.Text) || string.IsNullOrWhiteSpace(this.richtxtMoTa.Text))
            {
                MessageBox.Show("Chưa nhập đủ thông tin!", "Thông báo");
                return false;
            }
            if (!IsNumber(this.txtMaViec.Text) || !IsNumber(this.txtMucLuong.Text))
            {
                MessageBox.Show("Thông tin không hợp lệ.", "Không thể sửa!");
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
                    int maViec = int.Parse(this.txtMaViec.Text);
                    string tenViec = this.txtTenViec.Text;
                    string moTa = this.richtxtMoTa.Text;
                    int mucLuong = int.Parse(this.txtMucLuong.Text);

                    this.bUS_VIECLAM.suaMauViecLam(maViec, tenViec, moTa, mucLuong);
                    MessageBox.Show("Sửa thành công!!!", "Thông báo");

                    this.frmDSCV.loadDataTable();
                    this.frmDSCV.loadDataTableView();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Sửa thất bại!!!", "Lỗi!");
                }
            }
        }

        private void btnSua_MouseHover(object sender, EventArgs e)
        {
            this.btnSua.FlatStyle = FlatStyle.Flat;
            this.btnSua.FlatAppearance.BorderSize = 1;
            this.btnSua.FlatAppearance.BorderColor = Color.White;
            this.btnSua.BackColor = Color.MidnightBlue;
            this.btnSua.ForeColor = Color.White;
        }

        private void btnSua_MouseLeave(object sender, EventArgs e)
        {
            this.btnSua.FlatStyle = FlatStyle.Flat;
            this.btnSua.FlatAppearance.BorderSize = 1;
            this.btnSua.FlatAppearance.BorderColor = Color.Gainsboro;
            this.btnSua.BackColor = Color.White;
            this.btnSua.ForeColor = Color.Black;
        }

        /////////////////////////////////////////////////////////////////////////////////
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            this.txtTenViec.Text = "";
            this.richtxtMoTa.Text = "";
            this.txtMucLuong.Text = "";
        }

        private void btnLamMoi_MouseHover(object sender, EventArgs e)
        {
            this.btnLamMoi.FlatStyle = FlatStyle.Flat;
            this.btnLamMoi.FlatAppearance.BorderSize = 1;
            this.btnLamMoi.FlatAppearance.BorderColor = Color.White;
            this.btnLamMoi.BackColor = Color.MidnightBlue;
            this.btnLamMoi.ForeColor = Color.White;
        }

        private void btnLamMoi_MouseLeave(object sender, EventArgs e)
        {
            this.btnLamMoi.FlatStyle = FlatStyle.Flat;
            this.btnLamMoi.FlatAppearance.BorderSize = 1;
            this.btnLamMoi.FlatAppearance.BorderColor = Color.Gainsboro;
            this.btnLamMoi.BackColor = Color.White;
            this.btnLamMoi.ForeColor = Color.Black;
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
