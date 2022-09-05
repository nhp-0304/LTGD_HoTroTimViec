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
    public partial class TAOMAUTUYENDUNG : Form
    {
        MENU_DONVITUYENDUNG_VIECLAM frmDVTD;

        BUS_DONVITUYENDUNG_VIECLAM bUS_DONVITUYENDUNG_VIECLAM;
        BUS_VIECLAM bUS_VIECLAM;

        public string maDV = "";


        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        public TAOMAUTUYENDUNG(MENU_DONVITUYENDUNG_VIECLAM frmDVTD_ThamSo)
        {
            InitializeComponent();
            this.frmDVTD = frmDVTD_ThamSo;
        }

        private void TAOMAUTUYENDUNG_Load(object sender, EventArgs e)
        {
            bUS_DONVITUYENDUNG_VIECLAM = new BUS_DONVITUYENDUNG_VIECLAM();
            bUS_VIECLAM = new BUS_VIECLAM();

            this.dateTimePickerView();

            this.txtID.Text = (this.bUS_DONVITUYENDUNG_VIECLAM.getID_DVTD_HT() + 1).ToString();
            this.txtMaDV.Text = maDV;
        }

        /////////////////////////////////////////////////////////////////////////////////
        private void dateTimePickerView()
        {
            dtpTGBD.Format = DateTimePickerFormat.Custom;
            dtpTGBD.CustomFormat = "dd/MM/yyyy";

            dtpTGKT.Format = DateTimePickerFormat.Custom;
            dtpTGKT.CustomFormat = "dd/MM/yyyy";
        }

        /////////////////////////////////////////////////////////////////////////////////
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        /////////////////////////////////////////////////////////////////////////////////
        private void btnTraViec_Click(object sender, EventArgs e)
        {
            MENU_DANHSACHCONGVIEC frmDSCV = new MENU_DANHSACHCONGVIEC();
            frmDSCV.ShowDialog();
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

        private bool checkThem()
        {
            if (string.IsNullOrWhiteSpace(this.txtMaViec.Text) || string.IsNullOrWhiteSpace(this.txtQuyMo.Text))
            {
                MessageBox.Show("Chưa nhập đủ thông tin!", "Thông báo");
                return false;
            }
            if (!IsNumber(this.txtMaViec.Text) || !IsNumber(this.txtQuyMo.Text))
            {
                MessageBox.Show("Thông tin không hợp lệ.", "Không thể thêm!");
                return false;
            }
            if (this.dtpTGBD.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Thời gian bắt đầu không hợp lệ.", "Không thể thêm!");
                return false;
            }
            if (this.dtpTGKT.Value.Date <= this.dtpTGBD.Value.Date)
            {
                MessageBox.Show("Thời gian kết thúc không hợp lệ.", "Không thể thêm!");
                return false;
            }
            if (!this.bUS_VIECLAM.kTraMaViec(int.Parse(this.txtMaViec.Text)))
            {
                MessageBox.Show("Mã việc làm không tồn tại.", "Không thể thêm!");
                return false;
            }
            if (this.bUS_DONVITUYENDUNG_VIECLAM.kTraMaViecMTD(this.txtMaDV.Text, int.Parse(this.txtMaViec.Text)))
            {
                MessageBox.Show("Bạn đã có mẫu tuyển dụng với mã việc vừa nhập.", "Không thể thêm!");
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkThem())
            {
                try
                {
                    int ID = int.Parse(this.txtID.Text);
                    string maDV = this.txtMaDV.Text;
                    int maViec = int.Parse(this.txtMaViec.Text);
                    int quyMo = int.Parse(this.txtQuyMo.Text);
                    DateTime TGBD = this.dtpTGBD.Value;
                    DateTime TGKT = this.dtpTGKT.Value;

                    this.bUS_DONVITUYENDUNG_VIECLAM.themMauTuyenDung(ID, maDV, maViec, quyMo, TGBD, TGKT);
                    MessageBox.Show("Thêm thành công!!!", "Thông báo");

                    this.frmDVTD.loadDataTable();
                    this.frmDVTD.loadDataTableView();

                    this.txtID.Text = (this.bUS_DONVITUYENDUNG_VIECLAM.getID_DVTD_HT() + 1).ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Thêm thất bại!!!", "Lỗi!");
                }
            }
        }

        private void btnThem_MouseHover(object sender, EventArgs e)
        {
            this.btnThem.FlatStyle = FlatStyle.Flat;
            this.btnThem.FlatAppearance.BorderSize = 1;
            this.btnThem.FlatAppearance.BorderColor = Color.White;
            this.btnThem.BackColor = Color.MidnightBlue;
            this.btnThem.ForeColor = Color.White;
        }

        private void btnThem_MouseLeave(object sender, EventArgs e)
        {
            this.btnThem.FlatStyle = FlatStyle.Flat;
            this.btnThem.FlatAppearance.BorderSize = 1;
            this.btnThem.FlatAppearance.BorderColor = Color.Gainsboro;
            this.btnThem.BackColor = Color.White;
            this.btnThem.ForeColor = Color.Black;
        }

        /////////////////////////////////////////////////////////////////////////////////
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            this.txtID.Text = (this.bUS_DONVITUYENDUNG_VIECLAM.getID_DVTD_HT() + 1).ToString();
            this.txtMaViec.Text = "";
            this.txtQuyMo.Text = "";
            this.dtpTGBD.Value = DateTime.Now;
            this.dtpTGKT.Value = DateTime.Now;
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
