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
    public partial class SUAMAUTUYENDUNG : Form
    {
        MENU_DONVITUYENDUNG_VIECLAM frmDVTD;

        BUS_DONVITUYENDUNG_VIECLAM bUS_DONVITUYENDUNG_VIECLAM;
        BUS_DON_TUYENDUNG bUS_DON_TUYENDUNG;

        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        public SUAMAUTUYENDUNG(MENU_DONVITUYENDUNG_VIECLAM frmDVTD_ThamSo)
        {
            InitializeComponent();
            this.frmDVTD = frmDVTD_ThamSo;
        }

        private void SUAMAUTUYENDUNG_Load(object sender, EventArgs e)
        {
            bUS_DONVITUYENDUNG_VIECLAM = new BUS_DONVITUYENDUNG_VIECLAM();
            bUS_DON_TUYENDUNG = new BUS_DON_TUYENDUNG();

            this.dateTimePickerView();
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
        private void btnClearDTD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận tái sử dụng mẫu tuyển đụng này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MessageBox.Show("Điều này đồng nghĩa với việc xóa toàn bộ đơn tuyển dụng đã duyệt hoặc từ chối hiện có! (ngoại trừ những đơn còn đang chờ).", "Xác nhận lại", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        bUS_DON_TUYENDUNG.xoaDTDDuyet(int.Parse(this.txtID.Text));
                        bUS_DON_TUYENDUNG.xoaDTDTuChoi(int.Parse(this.txtID.Text));
                        MessageBox.Show("Thao tác thành công!!!", "Thông báo");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Thao tác thất bại!!!", "Lỗi!");
                    }
                }
            }
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
            if (string.IsNullOrWhiteSpace(this.txtMaViec.Text) || string.IsNullOrWhiteSpace(this.txtQuyMo.Text))
            {
                MessageBox.Show("Chưa nhập đủ thông tin!", "Thông báo");
                return false;
            }
            if (!IsNumber(this.txtMaViec.Text) || !IsNumber(this.txtQuyMo.Text))
            {
                MessageBox.Show("Thông tin không hợp lệ!", "Không thể sửa!");
                return false;
            }
            if (this.dtpTGBD.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Thời gian bắt đầu không hợp lệ.", "Không thể sửa!");
                return false;
            }
            if (this.dtpTGKT.Value.Date <= this.dtpTGBD.Value.Date)
            {
                MessageBox.Show("Thời gian kết thúc không hợp lệ.", "Không thể sửa!");
                return false;
            }
            if (int.Parse(this.txtQuyMo.Text) < this.bUS_DON_TUYENDUNG.getSLDonDuyet(int.Parse(this.txtID.Text)))
            {
                MessageBox.Show("Quy mô nhỏ hơn số đơn đã duyệt của mẫu tuyển dụng.", "Không thể sửa!");
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
                    int IDSua = int.Parse(this.txtID.Text);
                    string maDVSua = this.txtMaDV.Text;
                    int maViecSua = int.Parse(this.txtMaViec.Text);
                    int quyMoSua = int.Parse(this.txtQuyMo.Text);
                    DateTime TGBDSua = this.dtpTGBD.Value;
                    DateTime TGKTSua = this.dtpTGKT.Value;

                    this.bUS_DONVITUYENDUNG_VIECLAM.suaMauTuyenDung(IDSua, maDVSua, maViecSua, quyMoSua, TGBDSua, TGKTSua);
                    MessageBox.Show("Sửa thành công!!!", "Thông báo");

                    this.frmDVTD.loadDataTable();
                    this.frmDVTD.loadDataTableView();
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
