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
using _08_HOTROTIMVIEC.GUI._DONVITUYENDUNG;

namespace _08_HOTROTIMVIEC.GUI._ADMINISTRATION
{
    public partial class MENU_ADMINISTRATION : Form
    {
        BUS_ADMINISTRATION bUS_ADMINISTRATION;
        private ADMINISTRATION admin_Cur = LOGIN.admin_Cur_TK();
        BUS_DONVITUYENDUNG_TAIKHOAN bUS_DONVITUYENDUNG_TAIKHOAN;
        BUS_DONVITUYENDUNG bUS_DONVITUYENDUNG;

        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        public MENU_ADMINISTRATION()
        {
            InitializeComponent();
            this.txtTimKiem.ForeColor = Color.Gray;
            this.txtTimKiem.Text = " Tìm kiếm trên bảng";
            this.txtTimKiem.Leave += new System.EventHandler(this.txtTimKiem_Leave);
            this.txtTimKiem.Enter += new System.EventHandler(this.txtTimKiem_Enter);
        }
        private void MENU_ADMINISTRATION_Load(object sender, EventArgs e)
        {
            bUS_DONVITUYENDUNG_TAIKHOAN = new BUS_DONVITUYENDUNG_TAIKHOAN();
            bUS_DONVITUYENDUNG = new BUS_DONVITUYENDUNG();

            this.loadDataTable();
            this.loadDataTableView();
        }

        public void loadDataTable()
        {
            bUS_DONVITUYENDUNG_TAIKHOAN = new BUS_DONVITUYENDUNG_TAIKHOAN();
            this.tbDVTKTaiKhoan.DataSource = bUS_DONVITUYENDUNG_TAIKHOAN.getDVTD_tk();
        }

        public void loadDataTable(string maDV)
        {
            bUS_DONVITUYENDUNG_TAIKHOAN = new BUS_DONVITUYENDUNG_TAIKHOAN();
            this.tbDVTKTaiKhoan.DataSource = bUS_DONVITUYENDUNG_TAIKHOAN.getDVTD_tk(maDV);
        }

        public void loadDataTableView()
        {
            this.tbDVTKTaiKhoan.RowHeadersWidth = 4;
            this.tbDVTKTaiKhoan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.tbDVTKTaiKhoan.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.tbDVTKTaiKhoan.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.tbDVTKTaiKhoan.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.tbDVTKTaiKhoan.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btnDSViec_Click(object sender, EventArgs e)
        {
            MENU_DANHSACHCONGVIEC frmDSCV = new MENU_DANHSACHCONGVIEC();
            frmDSCV.ShowDialog();
        }

        private void tbDVTKTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.tbDVTKTaiKhoan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    this.tbDVTKTaiKhoan.Rows[e.RowIndex].Selected = true;
                    var get = bUS_DONVITUYENDUNG.getDVTD_BangMaDV(this.tbDVTKTaiKhoan.Rows[e.RowIndex].Cells[0].Value.ToString());
                    this.txtMaDV_Admin.Text = get.MaDV;
                    this.txtTenDV_Admin.Text = get.TenDV;
                    this.richtxtDiaChi_Admin.Text = get.DiaChi;
                    this.txtSDT_Admin.Text = get.SDT;
                    if (this.tbDVTKTaiKhoan.Rows[e.RowIndex].Cells[1].Value.ToString() == "1")
                    {
                        this.txtTrangThai_Admin.Text = " Bình thường";
                        this.txtTrangThai_Admin.BackColor = Color.LimeGreen;
                    }
                    else
                    {
                        this.txtTrangThai_Admin.Text = " Bị cấm!";
                        this.txtTrangThai_Admin.BackColor = Color.LightCoral;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chỉ chọn dòng tương ứng", "Cảnh báo!");
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (this.txtTimKiem.Text == "")
            {
                this.txtTimKiem.Text = " Tìm kiếm trên bảng";
                this.txtTimKiem.ForeColor = Color.Gray;
            }
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (this.txtTimKiem.Text == " Tìm kiếm trên bảng")
            {
                this.txtTimKiem.Text = "";
                this.txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void txtTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtTimKiem.Text) || string.IsNullOrEmpty(this.txtTimKiem.Text) && Convert.ToInt32(e.KeyCode) == 8)
                this.loadDataTable();
            if (!(string.IsNullOrWhiteSpace(this.txtTimKiem.Text) && string.IsNullOrEmpty(this.txtTimKiem.Text)))
                this.loadDataTable(this.txtTimKiem.Text.Trim());
        }

        private void btnChoPhepSD_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtMaDV_Admin.Text))
            {
                if (MessageBox.Show("Xác nhận mở khóa cho nhà tuyển dụng này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        bUS_DONVITUYENDUNG_TAIKHOAN.DVTD_TK_ChoPhepSD(this.txtMaDV_Admin.Text);
                        MessageBox.Show("Mở khóa thành công!!!", "Thông báo");
                        this.loadDataTable();
                        this.loadDataTableView();
                        this.txtTrangThai_Admin.Text = " Bình thường";
                        this.txtTrangThai_Admin.BackColor = Color.LimeGreen;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Mở khóa thất bại!!!", "Lỗi!");
                        this.loadDataTable();
                        this.loadDataTableView();
                    }
                }
                else
                    MessageBox.Show("Bạn chưa lựa chọn dòng nào để thao tác!", "Thông báo");
            }
        }

        private void btnCamSuDung_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtMaDV_Admin.Text))
            {
                if (MessageBox.Show("Xác nhận cấm nhà tuyển dụng này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        bUS_DONVITUYENDUNG_TAIKHOAN.DVTD_TK_CamSD(this.txtMaDV_Admin.Text);
                        MessageBox.Show("Cấm thành công!!!", "Thông báo");
                        this.loadDataTable();
                        this.loadDataTableView();
                        this.txtTrangThai_Admin.Text = " Bị cấm!";
                        this.txtTrangThai_Admin.BackColor = Color.LightCoral;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Cấm sử dụng thất bại!!!", "Lỗi!");
                        this.loadDataTable();
                        this.loadDataTableView();
                    }
                }
                else
                    MessageBox.Show("Bạn chưa lựa chọn dòng nào để thao tác!", "Thông báo");
            }
        }

        private void btnChoPhepSD_MouseHover(object sender, EventArgs e)
        {
            this.btnChoPhepSD.BackColor = Color.MidnightBlue;
            this.btnChoPhepSD.ForeColor = Color.White;
        }

        private void btnChoPhepSD_MouseLeave(object sender, EventArgs e)
        {
            this.btnChoPhepSD.BackColor = Color.WhiteSmoke;
            this.btnChoPhepSD.ForeColor = Color.Black;
        }

        private void btnCamSuDung_MouseHover(object sender, EventArgs e)
        {
            this.btnCamSuDung.BackColor = Color.MidnightBlue;
            this.btnCamSuDung.ForeColor = Color.White;
        }

        private void btnCamSuDung_MouseLeave(object sender, EventArgs e)
        {
            this.btnCamSuDung.BackColor = Color.WhiteSmoke;
            this.btnCamSuDung.ForeColor = Color.Black;
        }

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

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        private void btnDSViec_MouseHover(object sender, EventArgs e)
        {
            this.btnDSViec.BackColor = Color.MidnightBlue;
            this.btnDSViec.ForeColor = Color.White;
        }

        private void btnDSViec_MouseLeave(object sender, EventArgs e)
        {
            this.btnDSViec.BackColor = Color.WhiteSmoke;
            this.btnDSViec.ForeColor = Color.Black;
        }
    }
}
