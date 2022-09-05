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
    public partial class uCtrlDONTUYENDUNG : UserControl
    {
        MENU_DONVITUYENDUNG_VIECLAM frmDVTD;
        MENU_DONTUYENDUNG frmDTD;

        BUS_DONVITUYENDUNG_VIECLAM bUS_DONVITUYENDUNG_VIECLAM;
        BUS_DON_TUYENDUNG bUS_DON_TUYENDUNG;
        BUS_NGUOILAODONG bUS_NGUOILAODONG;
        BUS_SERVICES bUS_SERVICES;

        private int manld;
        public int MANLD
        {
            get { return manld; }
            set { manld = value; }
        }

        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime ngaydk;
        public DateTime NGAYDK
        {
            get { return ngaydk; }
            set { ngaydk = value; }
        }

        private int trangthai;
        public int TRANGTHAI
        {
            get { return trangthai; }
            set { trangthai = value; }
        }

        private string ten_image = "";
        public string TEN_IMAGE
        {
            get { return ten_image; }
            set { ten_image = value; }
        }

        public uCtrlDONTUYENDUNG(MENU_DONVITUYENDUNG_VIECLAM frmDVTD_ThamSo, MENU_DONTUYENDUNG frmDTD_ThamSo)
        {
            InitializeComponent();
            this.frmDVTD = frmDVTD_ThamSo;
            this.frmDTD = frmDTD_ThamSo;

            dtpNgayDK.Format = DateTimePickerFormat.Custom;
            dtpNgayDK.CustomFormat = "dd/MM/yyyy";
        }

        private void uCtrlDONTUYENDUNG_Load(object sender, EventArgs e)
        {
            bUS_DONVITUYENDUNG_VIECLAM = new BUS_DONVITUYENDUNG_VIECLAM();
            bUS_DON_TUYENDUNG = new BUS_DON_TUYENDUNG();
            bUS_NGUOILAODONG = new BUS_NGUOILAODONG();
            bUS_SERVICES = new BUS_SERVICES();

            this.loadDataUser();
            this.loadDataUserView();
        }

        public void loadDataUser()
        {
            this.txtMaNLD.Text = this.manld.ToString();
            this.dtpNgayDK.Value = this.ngaydk;

            if (this.trangthai == 0)
            {
                this.txtTrangThai.Text = "Từ chối!";
            }

            if (this.trangthai == 1)
            {
                this.txtTrangThai.Text = "Đang chờ";
            }

            if (this.trangthai == 2)
            {
                this.txtTrangThai.Text = "Đã duyệt!";
            }

            if (!string.IsNullOrEmpty(ten_image))
            {
                this.pBoxAvtNLD.Image = Image.FromFile(ten_image);
            }
        }

        public void loadDataUserView()
        {
            if (this.txtTrangThai.Text == "Từ chối!")
            {
                this.BackColor = Color.LightCoral;
                this.btnDuyet.Visible = false;
                this.btnTuChoi.Enabled = false;
                this.btnTuChoi.FlatAppearance.BorderSize = 0;
            }

            if (this.txtTrangThai.Text == "Đang chờ")
            {
                this.BackColor = Color.WhiteSmoke;
            }

            if (this.txtTrangThai.Text == "Đã duyệt!")
            {
                this.BackColor = Color.LimeGreen;
                this.btnTuChoi.Visible = false;
                this.btnDuyet.Enabled = false;
                this.btnDuyet.FlatAppearance.BorderSize = 0;
            }
        }

        private void uCtrlDONTUYENDUNG_MouseHover(object sender, EventArgs e)
        {
            if (this.txtTrangThai.Text == "Từ chối!")
            {
                this.BackColor = Color.IndianRed;
                this.btnTuChoi.BackColor = Color.IndianRed;
            }

            if (this.txtTrangThai.Text == "Đang chờ")
            {
                this.BackColor = Color.Gainsboro;
            }

            if (this.txtTrangThai.Text == "Đã duyệt!")
            {
                this.BackColor = Color.ForestGreen;
                this.btnDuyet.BackColor = Color.ForestGreen;
            }
        }

        private void uCtrlDONTUYENDUNG_MouseLeave(object sender, EventArgs e)
        {
            if (this.txtTrangThai.Text == "Từ chối!")
            {
                this.BackColor = Color.LightCoral;
                this.btnTuChoi.BackColor = Color.LightCoral;
            }

            if (this.txtTrangThai.Text == "Đang chờ")
            {
                this.BackColor = Color.WhiteSmoke;
            }

            if (this.txtTrangThai.Text == "Đã duyệt!")
            {
                this.BackColor = Color.LimeGreen;
                this.btnDuyet.BackColor = Color.LimeGreen;
            }
        }

        private void uCtrlDONTUYENDUNG_Click(object sender, EventArgs e)
        {
            NGUOILAODONG getNLD = bUS_NGUOILAODONG.getNLD(int.Parse(this.txtMaNLD.Text));
            frmDTD.txtMaNLD.Text = getNLD.MaNLD.ToString();
            frmDTD.txtTenNLD.Text = getNLD.Ten;
            frmDTD.txtCMND.Text = getNLD.CMND;
            frmDTD.txtGioiTinh.Text = getNLD.GioiTinh;
            frmDTD.dtpNgaySinh.Value = getNLD.NgaySinh;
            frmDTD.richtxtDiaChi.Text = getNLD.DiaChi;
            frmDTD.txtSDT.Text = getNLD.SDT;
            frmDTD.txtBangCap.Text = getNLD.BangCap;
            if (!string.IsNullOrEmpty(ten_image))
            {
                frmDTD.pBox_AvtNLDLoad.Image = Image.FromFile(ten_image);
            }
            else
                frmDTD.pBox_AvtNLDLoad.Image = Properties.Resources.noImage;
        }

        private void pBoxAvtNLD_MouseHover(object sender, EventArgs e)
        {
            if (this.txtTrangThai.Text == "Từ chối!")
            {
                this.BackColor = Color.IndianRed;
                this.btnTuChoi.BackColor = Color.IndianRed;
            }

            if (this.txtTrangThai.Text == "Đang chờ")
            {
                this.BackColor = Color.Gainsboro;
            }

            if (this.txtTrangThai.Text == "Đã duyệt!")
            {
                this.BackColor = Color.ForestGreen;
                this.btnDuyet.BackColor = Color.ForestGreen;
            }
        }

        private void pBoxAvtNLD_MouseLeave(object sender, EventArgs e)
        {
            if (this.txtTrangThai.Text == "Từ chối!")
            {
                this.BackColor = Color.LightCoral;
                this.btnTuChoi.BackColor = Color.LightCoral;
            }

            if (this.txtTrangThai.Text == "Đang chờ")
            {
                this.BackColor = Color.WhiteSmoke;
            }

            if (this.txtTrangThai.Text == "Đã duyệt!")
            {
                this.BackColor = Color.LimeGreen;
                this.btnDuyet.BackColor = Color.LimeGreen;
            }
        }

        private void pBoxAvtNLD_Click(object sender, EventArgs e)
        {
            NGUOILAODONG getNLD = bUS_NGUOILAODONG.getNLD(int.Parse(this.txtMaNLD.Text));
            frmDTD.txtMaNLD.Text = getNLD.MaNLD.ToString();
            frmDTD.txtTenNLD.Text = getNLD.Ten.ToString();
            frmDTD.txtCMND.Text = getNLD.CMND.ToString();
            frmDTD.txtGioiTinh.Text = getNLD.GioiTinh.ToString();
            frmDTD.dtpNgaySinh.Value = getNLD.NgaySinh;
            frmDTD.richtxtDiaChi.Text = getNLD.DiaChi;
            frmDTD.txtSDT.Text = getNLD.SDT.ToString();
            frmDTD.txtBangCap.Text = getNLD.BangCap.ToString();
            //new
            //Avatar
            if (!string.IsNullOrEmpty(ten_image))
            {
                frmDTD.pBox_AvtNLDLoad.Image = Image.FromFile(ten_image);
            }
            else
                frmDTD.pBox_AvtNLDLoad.Image = Properties.Resources.noImage;
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận duyệt đơn này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (!this.bUS_DONVITUYENDUNG_VIECLAM.kTraDuQuyMo(id))
                {
                    try
                    {
                        bUS_DON_TUYENDUNG.setDonDuyet(MANLD);
                        bUS_DONVITUYENDUNG_VIECLAM.capNhatQuyMo(ID);
                        var get = bUS_DON_TUYENDUNG.getTrangThaiDon(ID, MANLD);
                        TRANGTHAI = get.TrangThai;
                        this.loadDataUser();
                        this.loadDataUserView();
                        this.frmDVTD.loadDataTable();
                        this.frmDVTD.loadDataTableView();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Duyệt đơn thất bại!!!", "Lỗi!");
                    }
                }
                else
                    MessageBox.Show("Công việc đã tuyển đủ số lượng", "Không thể duyệt đơn!");
            }
        }

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận từ chối đơn này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    bUS_DON_TUYENDUNG.setDonTuChoi(MANLD);
                    var get = bUS_DON_TUYENDUNG.getTrangThaiDon(ID, MANLD);
                    TRANGTHAI = get.TrangThai;
                    this.loadDataUser();
                    this.loadDataUserView();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Từ chối đơn thất bại!!!", "Lỗi!");
                }
            }
        }
    }
}
