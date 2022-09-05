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
    public partial class MENU_DONTUYENDUNG : Form
    {
        MENU_DONVITUYENDUNG_VIECLAM frmDVTD;
        uCtrlDONTUYENDUNG ufrmDTD;

        NGUOILAODONG getNLD;
        DON_TUYENDUNG getDTD;

        BUS_NGUOILAODONG bUS_NGUOILAODONG;
        BUS_DON_TUYENDUNG bUS_DON_TUYENDUNG;
        BUS_SERVICES bUS_SERVICES;

        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        public MENU_DONTUYENDUNG(MENU_DONVITUYENDUNG_VIECLAM frmDVTD_ThamSo)
        {
            InitializeComponent();
            this.frmDVTD = frmDVTD_ThamSo;

            /////////////////////////////////////////// TIM KIEM
            this.txtTimKiem.ForeColor = Color.Gray;
            this.txtTimKiem.Text = " Tìm kiếm trên bảng";
            this.txtTimKiem.Leave += new System.EventHandler(this.txtTimKiem_Leave);
            this.txtTimKiem.Enter += new System.EventHandler(this.txtTimKiem_Enter);
        }

        private void MENU_DONTUYENDUNG_Load(object sender, EventArgs e)
        {
            getNLD = new NGUOILAODONG();
            getDTD = new DON_TUYENDUNG();

            bUS_NGUOILAODONG = new BUS_NGUOILAODONG();
            bUS_DON_TUYENDUNG = new BUS_DON_TUYENDUNG();
            bUS_SERVICES = new BUS_SERVICES();

            this.loadDataTableInit();
        }

        public void loadDataTableInit()
        {
            int x = 1, y = 0;
            List<DON_TUYENDUNG> listDTD = bUS_DON_TUYENDUNG.getDTDTheoDV(ID);
            for (int i = 0; i < listDTD.Count; i++)
            {
                ufrmDTD = new uCtrlDONTUYENDUNG(frmDVTD, this);
                ufrmDTD.MANLD = listDTD[i].MaNLD;
                ufrmDTD.ID = listDTD[i].Id;
                ufrmDTD.NGAYDK = listDTD[i].NgayDK;
                ufrmDTD.TRANGTHAI = listDTD[i].TrangThai;
                if (!string.IsNullOrEmpty(bUS_SERVICES.getLinkNLD(listDTD[i].MaNLD)))
                    ufrmDTD.TEN_IMAGE = "NGUOILD/" + bUS_SERVICES.getLinkNLD(listDTD[i].MaNLD);
                this.tbDonTuyenDung.Controls.Add(ufrmDTD, y, x);

                y++;
                if (y == 5)
                {
                    y = 0;
                    x++;
                }
            }
        }

        public void loadDataTable()
        {
            this.txtMaNLD.Text = "";
            this.txtTenNLD.Text = "";
            this.txtCMND.Text = "";
            this.txtGioiTinh.Text = "";
            this.dtpNgaySinh.Value = DateTime.Now;
            this.richtxtDiaChi.Text = "";
            this.txtSDT.Text = "";
            this.txtBangCap.Text = "";
            this.pBox_AvtNLDLoad.Image = Properties.Resources.noImage;
            this.clearDataTable();

            int x = 1, y = 0;
            List<DON_TUYENDUNG> listDTD = bUS_DON_TUYENDUNG.getDTDTheoDV(ID);
            for (int i = 0; i < listDTD.Count; i++)
            {
                ufrmDTD = new uCtrlDONTUYENDUNG(frmDVTD, this);
                ufrmDTD.MANLD = listDTD[i].MaNLD;
                ufrmDTD.ID = listDTD[i].Id;
                ufrmDTD.NGAYDK = listDTD[i].NgayDK;
                ufrmDTD.TRANGTHAI = listDTD[i].TrangThai;
                if (!string.IsNullOrEmpty(bUS_SERVICES.getLinkNLD(listDTD[i].MaNLD)))
                    ufrmDTD.TEN_IMAGE = "NGUOILD/" + bUS_SERVICES.getLinkNLD(listDTD[i].MaNLD);
                this.tbDonTuyenDung.Controls.Add(ufrmDTD, y, x);

                y++;
                if (y == 5)
                {
                    y = 0;
                    x++;
                }
            }
        }

        public void loadDataTable(int maNLD)
        {
            if (bUS_NGUOILAODONG.kTraNLDTonTai(maNLD))
            {
                this.clearDataTable();
                bUS_NGUOILAODONG = new BUS_NGUOILAODONG();
                bUS_DON_TUYENDUNG = new BUS_DON_TUYENDUNG();
                bUS_SERVICES = new BUS_SERVICES();
                try
                {
                    DON_TUYENDUNG getDTD = bUS_DON_TUYENDUNG.getDTDTheoDV(maNLD, ID);
                    NGUOILAODONG getNLD = bUS_NGUOILAODONG.getNLD(getDTD.MaNLD, ID);

                    ufrmDTD = new uCtrlDONTUYENDUNG(frmDVTD, this);
                    ufrmDTD.MANLD = getDTD.MaNLD;
                    ufrmDTD.ID = getDTD.Id;
                    ufrmDTD.NGAYDK = getDTD.NgayDK;
                    ufrmDTD.TRANGTHAI = getDTD.TrangThai;
                    if (!string.IsNullOrEmpty(bUS_SERVICES.getLinkNLD(getNLD.MaNLD)))
                        ufrmDTD.TEN_IMAGE = "NGUOILD/" + bUS_SERVICES.getLinkNLD(getNLD.MaNLD);
                    this.tbDonTuyenDung.Controls.Add(ufrmDTD);

                    this.txtMaNLD.Text = getNLD.MaNLD.ToString();
                    this.txtTenNLD.Text = getNLD.Ten;
                    this.txtCMND.Text = getNLD.CMND;
                    this.txtGioiTinh.Text = getNLD.GioiTinh;
                    this.dtpNgaySinh.Value = getNLD.NgaySinh;
                    this.richtxtDiaChi.Text = getNLD.DiaChi;
                    this.txtSDT.Text = getNLD.SDT;
                    this.txtBangCap.Text = getNLD.BangCap;
                    if (!string.IsNullOrEmpty(bUS_SERVICES.getLinkNLD(getNLD.MaNLD)))
                        this.pBox_AvtNLDLoad.Image = Image.FromFile("NGUOILD/" + bUS_SERVICES.getLinkNLD(getNLD.MaNLD));
                }
                catch (NullReferenceException ex)
                {
                    this.loadDataTable();
                }
            }
        }

        public void loadDataTable(string tenNLD)
        {
            if (bUS_NGUOILAODONG.kTraNLDTonTai(tenNLD))
            {
                this.clearDataTable();
                bUS_NGUOILAODONG = new BUS_NGUOILAODONG();
                bUS_DON_TUYENDUNG = new BUS_DON_TUYENDUNG();
                bUS_SERVICES = new BUS_SERVICES();
                try
                {
                    DON_TUYENDUNG getDTD = bUS_DON_TUYENDUNG.getDTDTheoNLD_DV(tenNLD, ID);
                    NGUOILAODONG getNLD = bUS_NGUOILAODONG.getNLD(getDTD.MaNLD, tenNLD, ID);

                    ufrmDTD = new uCtrlDONTUYENDUNG(frmDVTD, this);
                    ufrmDTD.MANLD = getDTD.MaNLD;
                    ufrmDTD.ID = getDTD.Id;
                    ufrmDTD.NGAYDK = getDTD.NgayDK;
                    ufrmDTD.TRANGTHAI = getDTD.TrangThai;
                    if (!string.IsNullOrEmpty(bUS_SERVICES.getLinkNLD(getNLD.MaNLD)))
                        ufrmDTD.TEN_IMAGE = "NGUOILD/" + bUS_SERVICES.getLinkNLD(getNLD.MaNLD);
                    this.tbDonTuyenDung.Controls.Add(ufrmDTD);

                    this.txtMaNLD.Text = getNLD.MaNLD.ToString();
                    this.txtTenNLD.Text = getNLD.Ten;
                    this.txtCMND.Text = getNLD.CMND;
                    this.txtGioiTinh.Text = getNLD.GioiTinh;
                    this.dtpNgaySinh.Value = getNLD.NgaySinh;
                    this.richtxtDiaChi.Text = getNLD.DiaChi;
                    this.txtSDT.Text = getNLD.SDT;
                    this.txtBangCap.Text = getNLD.BangCap;
                    if (!string.IsNullOrEmpty(bUS_SERVICES.getLinkNLD(getNLD.MaNLD)))
                        this.pBox_AvtNLDLoad.Image = Image.FromFile("NGUOILD/" + bUS_SERVICES.getLinkNLD(getNLD.MaNLD));
                }
                catch (NullReferenceException ex)
                {
                    this.loadDataTable();
                }
            }
        }

        public void clearDataTable()
        {
            for (int i = this.tbDonTuyenDung.Controls.Count - 1; i >= 0; --i)
                this.tbDonTuyenDung.Controls[i].Dispose();

            this.tbDonTuyenDung.Controls.Clear();
            this.tbDonTuyenDung.RowCount = 0;
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
            {
                this.loadDataTable();
            }
            if (!(string.IsNullOrWhiteSpace(this.txtTimKiem.Text) && string.IsNullOrEmpty(this.txtTimKiem.Text)))
            {
                if (this.IsNumber(this.txtTimKiem.Text))
                {
                    this.loadDataTable(int.Parse(this.txtTimKiem.Text));
                }
                if (!this.IsNumber(this.txtTimKiem.Text))
                {
                    this.loadDataTable(this.txtTimKiem.Text.Trim());
                }
            }
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận loại bỏ tất cả đơn bạn từ chối?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    bUS_DON_TUYENDUNG.xoaDTDTuChoi(ID);
                    this.clearDataTable();
                    this.loadDataTableInit();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Thao tác thất bại!!!", "Lỗi!");
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            this.txtMaNLD.Text = "";
            this.txtTenNLD.Text = "";
            this.txtCMND.Text = "";
            this.txtGioiTinh.Text = "";
            this.dtpNgaySinh.Value = DateTime.Now;
            this.richtxtDiaChi.Text = "";
            this.txtSDT.Text = "";
            this.txtBangCap.Text = "";

            this.clearDataTable();
            this.loadDataTableInit();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        ////////////////////////////////////////////////////////////////// GD
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
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
    }
}
