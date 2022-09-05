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
    public partial class MENU_DONVITUYENDUNG_VIECLAM : Form
    {
        DONVITUYENDUNG getDVTD;

        BUS_DONVITUYENDUNG bUS_DONVITUYENDUNG;
        BUS_DONVITUYENDUNG_VIECLAM bUS_DONVITUYENDUNG_VIECLAM;
        BUS_VIECLAM bUS_VIECLAM;
        BUS_DON_TUYENDUNG bUS_DON_TUYENDUNG;
        BUS_SERVICES bUS_SERVICES;

        private static string maDV;
        public string MADV
        {
            get { return maDV; }
            set { maDV = value; }
        }

        public MENU_DONVITUYENDUNG_VIECLAM()
        {
            InitializeComponent();
        }

        private void MENU_DONVITUYENDUNG_Load(object sender, EventArgs e)
        {
            bUS_DONVITUYENDUNG = new BUS_DONVITUYENDUNG();
            bUS_DONVITUYENDUNG_VIECLAM = new BUS_DONVITUYENDUNG_VIECLAM();
            bUS_VIECLAM = new BUS_VIECLAM();
            bUS_DON_TUYENDUNG = new BUS_DON_TUYENDUNG();
            bUS_SERVICES = new BUS_SERVICES();

            ///////////////////////////// LOAD ĐƠN VỊ
            getDVTD = bUS_DONVITUYENDUNG.getDVTD_BangMaDV(maDV);
            this.lblTenDV.Text = getDVTD.TenDV;
            if (!string.IsNullOrEmpty(bUS_SERVICES.getLinkDV(getDVTD.MaDV)))
            {
                this.pBoxAvtDVTD.Image = Image.FromFile("DONVI/" + bUS_SERVICES.getLinkDV(getDVTD.MaDV));
            }
            else
            {
                this.pBoxAvtDVTD.Image = Properties.Resources.noImage;
            }

            ///////////////////////////// LOAD VIEW FROM
            this.timKiemView();
            this.dateTimePickerView();
            this.txtViecLamView();

            ///////////////////////////// LOAD DATA MẪU TUYỂN DỤNG
            this.loadDataTableInit();
            this.loadDataTableView();

            ///////////////////////////// BỊ BAN THÌ CHIM CÚTT 
            if (!getDVTD.TrangThai)
            {
                this.btnTaoMau.Enabled = false;
                this.panel2.Enabled = false;
                this.panel3.Enabled = false;
                this.panel5.Enabled = false;
                MessageBox.Show("Tài khoản của bạn đang bị cấm sử dụng!", "Thông Báo");
            }
        }

        ////////////////////////////////////////////////////////////////// THÊM CÁC COLUMN DẠNG METHOD
        private void addButtonQLDon()
        {
            DataGridViewImageColumn imgQLDon = new DataGridViewImageColumn();
            imgQLDon.Name = "DS Don";
            imgQLDon.Image = Properties.Resources.QuanLy;
            this.tbMauTuyenDung.Columns.Add(imgQLDon);
        }

        private void addButtonSua()
        {
            DataGridViewImageColumn imgSua = new DataGridViewImageColumn();
            imgSua.Name = "Sua TT";
            imgSua.Image = Properties.Resources.Sua;
            this.tbMauTuyenDung.Columns.Add(imgSua);
        }

        private void addCheckBox()
        {
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            this.tbMauTuyenDung.Columns.Add(checkBoxColumn);
        }

        private bool unCheckedAll = true;
        private CheckBox checkboxHeader;
        private void addCheckBoxHeader()
        {
            Rectangle rect = this.tbMauTuyenDung.GetCellDisplayRectangle(8, -1, true);

            //rect.X = rect.Location.X + (rect.Width / 4);
            //rect.Y = rect.Location.Y + (rect.Height / 2);
            rect.X = rect.Location.X + 687;
            rect.Y = rect.Location.Y + 1;
            checkboxHeader = new CheckBox();
            checkboxHeader.Name = "checkBoxHeader";
            checkboxHeader.Location = rect.Location;
            checkboxHeader.Size = new Size(20, 20);
            checkboxHeader.CheckAlign = ContentAlignment.MiddleCenter;
            checkboxHeader.BackColor = Color.RoyalBlue;
            checkboxHeader.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);

            this.tbMauTuyenDung.Controls.Add(checkboxHeader);
        }

        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxHeader.Checked)
            {
                for (int i = 0; i < this.tbMauTuyenDung.RowCount; i++)
                {
                    this.tbMauTuyenDung[8, i].Value = true;
                }
            }
            else
            {
                if (unCheckedAll)
                {
                    for (int i = 0; i < this.tbMauTuyenDung.RowCount; i++)
                    {
                        this.tbMauTuyenDung[8, i].Value = false;
                    }
                }
            }
            unCheckedAll = true;
        }

        ////////////////////////////////////////////////////////////////// TEXT BOX TÌM KIẾM
        private void timKiemView()
        {
            this.txtTimKiem.ForeColor = Color.Gray;
            this.txtTimKiem.Text = " Mã Việc";
            this.txtTimKiem.TextAlign = HorizontalAlignment.Center;
            this.txtTimKiem.Leave += new System.EventHandler(this.txtTimKiem_Leave);
            this.txtTimKiem.Enter += new System.EventHandler(this.txtTimKiem_Enter);
        }
        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (this.txtTimKiem.Text == "")
            {
                this.txtTimKiem.Text = " Mã Việc";
                this.txtTimKiem.ForeColor = Color.Gray;
            }
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (this.txtTimKiem.Text == " Mã Việc")
            {
                this.txtTimKiem.Text = "";
                this.txtTimKiem.ForeColor = Color.Black;
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

        private void txtTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtTimKiem.Text) || string.IsNullOrEmpty(this.txtTimKiem.Text) && Convert.ToInt32(e.KeyCode) == 8)
            {
                this.loadDataTable();
                this.loadDataTableView();

                if (this.rbtnDangCho.Checked)
                {
                    this.loadDataTable_Cho();
                    this.loadDataTableView();
                }

                if (this.rbtnDuSL.Checked)
                {
                    this.loadDataTable_DuSL();
                    this.loadDataTableView();
                }

                if (this.rbtnHetHan.Checked)
                {
                    this.loadDataTable_HetHan();
                    this.loadDataTableView();
                }
            }

            if (!(string.IsNullOrWhiteSpace(this.txtTimKiem.Text) && string.IsNullOrEmpty(this.txtTimKiem.Text)))
            {
                if (this.IsNumber(this.txtTimKiem.Text))
                {
                    this.loadDataTable(int.Parse(this.txtTimKiem.Text));
                    this.loadDataTableView();
                }
            }
        }

        ////////////////////////////////////////////////////////////////// DATE TIME PICKER TÌM KIẾM
        private void dateTimePickerView()
        {
            dtpKT.Format = DateTimePickerFormat.Custom;
            dtpKT.CustomFormat = "dd/MM/yyyy";

            dtpBD.Format = DateTimePickerFormat.Custom;
            dtpBD.CustomFormat = "dd/MM/yyyy";
        }

        private void btnTimKiem_MouseHover(object sender, EventArgs e)
        {
            this.btnTimKiem.FlatStyle = FlatStyle.Flat;
            this.btnTimKiem.FlatAppearance.BorderSize = 1;
            this.btnTimKiem.FlatAppearance.BorderColor = Color.White;
            this.btnTimKiem.BackColor = Color.MidnightBlue;
            this.btnTimKiem.ForeColor = Color.White;
        }

        private void btnTimKiem_MouseLeave(object sender, EventArgs e)
        {
            this.btnTimKiem.FlatStyle = FlatStyle.Flat;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.BackColor = Color.WhiteSmoke;
            this.btnTimKiem.ForeColor = Color.Black;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (this.rbtnTatCa.Checked)
            {
                this.loadDataTableTim();
                this.loadDataTableView();
            }

            if (this.rbtnDangCho.Checked)
            {
                this.loadDataTable_ChoTim();
                this.loadDataTableView();
            }

            if (this.rbtnDuSL.Checked)
            {
                this.loadDataTable_DuSLTim();
                this.loadDataTableView();
            }

            if (this.rbtnHetHan.Checked)
            {
                this.loadDataTable_HetHanTim();
                this.loadDataTableView();
            }
        }

        ////////////////////////////////////////////////////////////////// THÔNG TIN VIỆC LÀM
        private void txtViecLamView()
        {
            this.txtTenViec.BackColor = Color.White;
            this.txtTenViec.ForeColor = Color.Black;

            this.txtMucLuong.BackColor = Color.White;
            this.txtMucLuong.ForeColor = Color.Black;

            this.richtxtMoTa.BackColor = Color.White;
            this.richtxtMoTa.ForeColor = Color.Black;
        }

        ////////////////////////////////////////////////////////////////// BẢNG TUYỂN DỤNG
        public void loadDataTableView()
        {
            this.tbMauTuyenDung.RowHeadersWidth = 4;
            this.tbMauTuyenDung.Columns[1].Visible = false;

            this.tbMauTuyenDung.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            this.tbMauTuyenDung.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";

            this.tbMauTuyenDung.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.tbMauTuyenDung.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.tbMauTuyenDung.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.tbMauTuyenDung.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.tbMauTuyenDung.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.tbMauTuyenDung.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.tbMauTuyenDung.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.tbMauTuyenDung.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.tbMauTuyenDung.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.tbMauTuyenDung.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.tbMauTuyenDung.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.tbMauTuyenDung.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.tbMauTuyenDung.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.tbMauTuyenDung.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.tbMauTuyenDung.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.tbMauTuyenDung.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.tbMauTuyenDung.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.tbMauTuyenDung.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.tbMauTuyenDung.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        public void loadDataTableInit()
        {
            this.tbMauTuyenDung.DataSource = this.bUS_DONVITUYENDUNG_VIECLAM.getDVTD_ViecLam(MADV);
            this.addButtonQLDon();
            this.addButtonSua();
            this.addCheckBox();
            this.addCheckBoxHeader();
        }

        public void loadDataTable()
        {
            this.tbMauTuyenDung.Columns.Clear();
            bUS_DONVITUYENDUNG_VIECLAM = new BUS_DONVITUYENDUNG_VIECLAM();
            this.tbMauTuyenDung.DataSource = this.bUS_DONVITUYENDUNG_VIECLAM.getDVTD_ViecLam(MADV);
            this.addButtonQLDon();
            this.addButtonSua();
            this.addCheckBox();
        }

        /////////////////////////////// LOAD DATA TIM KIEM
        public void loadDataTable(int maViec)
        {
            this.tbMauTuyenDung.Columns.Clear();
            bUS_DONVITUYENDUNG_VIECLAM = new BUS_DONVITUYENDUNG_VIECLAM();
            this.tbMauTuyenDung.DataSource = this.bUS_DONVITUYENDUNG_VIECLAM.getDVTD_ViecLam(MADV, maViec);
            this.addButtonQLDon();
            this.addButtonSua();
            this.addCheckBox();
        }

        public void loadDataTableTim()
        {
            this.tbMauTuyenDung.Columns.Clear();
            bUS_DONVITUYENDUNG_VIECLAM = new BUS_DONVITUYENDUNG_VIECLAM();
            this.tbMauTuyenDung.DataSource = this.bUS_DONVITUYENDUNG_VIECLAM.getDVTD_ViecLamTim(MADV, this.dtpBD.Value, this.dtpKT.Value);
            this.addButtonQLDon();
            this.addButtonSua();
            this.addCheckBox();
        }

        public void loadDataTable_ChoTim()
        {
            this.tbMauTuyenDung.Columns.Clear();
            bUS_DONVITUYENDUNG_VIECLAM = new BUS_DONVITUYENDUNG_VIECLAM();
            this.tbMauTuyenDung.DataSource = this.bUS_DONVITUYENDUNG_VIECLAM.getDVTD_ViecLam_ChoTim(MADV, this.dtpBD.Value, this.dtpKT.Value);
            this.addButtonQLDon();
            this.addButtonSua();
            this.addCheckBox();
        }

        public void loadDataTable_DuSLTim()
        {
            this.tbMauTuyenDung.Columns.Clear();
            bUS_DONVITUYENDUNG_VIECLAM = new BUS_DONVITUYENDUNG_VIECLAM();
            this.tbMauTuyenDung.DataSource = this.bUS_DONVITUYENDUNG_VIECLAM.getDVTD_ViecLam_DuSLTim(MADV, this.dtpBD.Value, this.dtpKT.Value);
            this.addButtonQLDon();
            this.addButtonSua();
            this.addCheckBox();
        }

        public void loadDataTable_HetHanTim()
        {
            this.tbMauTuyenDung.Columns.Clear();
            bUS_DONVITUYENDUNG_VIECLAM = new BUS_DONVITUYENDUNG_VIECLAM();
            this.tbMauTuyenDung.DataSource = this.bUS_DONVITUYENDUNG_VIECLAM.getDVTD_ViecLam_HetHanTim(MADV, this.dtpBD.Value, this.dtpKT.Value);
            this.addButtonQLDon();
            this.addButtonSua();
            this.addCheckBox();
        }

        /////////////////////////////// LOAD DATA RADIO BUTTON
        public void loadDataTable_Cho()
        {
            this.tbMauTuyenDung.Columns.Clear();
            bUS_DONVITUYENDUNG_VIECLAM = new BUS_DONVITUYENDUNG_VIECLAM();
            this.tbMauTuyenDung.DataSource = this.bUS_DONVITUYENDUNG_VIECLAM.getDVTD_ViecLam_Cho(MADV);
            this.addButtonQLDon();
            this.addButtonSua();
            this.addCheckBox();
        }

        public void loadDataTable_DuSL()
        {
            this.tbMauTuyenDung.Columns.Clear();
            bUS_DONVITUYENDUNG_VIECLAM = new BUS_DONVITUYENDUNG_VIECLAM();
            this.tbMauTuyenDung.DataSource = this.bUS_DONVITUYENDUNG_VIECLAM.getDVTD_ViecLam_DuSL(MADV);
            this.addButtonQLDon();
            this.addButtonSua();
            this.addCheckBox();
        }

        public void loadDataTable_HetHan()
        {
            this.tbMauTuyenDung.Columns.Clear();
            bUS_DONVITUYENDUNG_VIECLAM = new BUS_DONVITUYENDUNG_VIECLAM();
            this.tbMauTuyenDung.DataSource = this.bUS_DONVITUYENDUNG_VIECLAM.getDVTD_ViecLam_HetHan(MADV);
            this.addButtonQLDon();
            this.addButtonSua();
            this.addCheckBox();
        }

        private void tbMauTuyenDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.tbMauTuyenDung.SelectedCells.Count == 0)
            {
                if (e.RowIndex >= 0)
                {
                    if ((bool)this.tbMauTuyenDung[8, e.RowIndex].Value)
                    {
                        this.tbMauTuyenDung[8, e.RowIndex].Value = false;
                        foreach (DataGridViewRow r in this.tbMauTuyenDung.Rows)
                        {
                            if ((bool)r.Cells[8].Value)
                            {
                                unCheckedAll = false;
                                break;
                            }
                        }
                        checkboxHeader.Checked = false;
                    }
                    else
                    {
                        this.tbMauTuyenDung[8, e.RowIndex].Value = true;
                        bool check = true;
                        foreach (DataGridViewRow r in this.tbMauTuyenDung.Rows)
                        {
                            if (!((bool)r.Cells[8].Value))
                            {
                                check = false;
                                break;
                            }
                        }
                        if (check)
                        {
                            checkboxHeader.Checked = true;
                        }
                    }
                }
            }

            try
            {
                DataGridViewRow row = this.tbMauTuyenDung.Rows[e.RowIndex];
                if (Convert.ToBoolean(row.Cells[8].Value) || row.Cells[8].Selected)
                {
                    this.tbMauTuyenDung.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                    this.tbMauTuyenDung.Rows[e.RowIndex].Selected = true;
                }
            }
            catch (Exception ex) { }

            try
            {
                if (this.tbMauTuyenDung.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    this.tbMauTuyenDung.Rows[e.RowIndex].Selected = true;
                    int maViecTemp = int.Parse(this.tbMauTuyenDung.Rows[e.RowIndex].Cells[2].Value.ToString());
                    var get = bUS_VIECLAM.getViecLam1(maViecTemp);
                    this.txtTenViec.Text = get.TenViec.ToString();
                    this.txtMucLuong.Text = get.MucLuong.ToString();
                    this.richtxtMoTa.Text = get.MoTa.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chỉ chọn dòng tương ứng", "Cảnh báo!");
            }
        }

        ////////////////////////////////////////////////////////////////// LỌC BẢNG TUYỂN DỤNG
        private void rbtnTatCa_CheckedChanged(object sender, EventArgs e)
        {
            this.loadDataTable();
            this.loadDataTableView();
        }

        private void rbtnDangCho_CheckedChanged(object sender, EventArgs e)
        {
            this.loadDataTable_Cho();
            this.loadDataTableView();
        }

        private void rbtnDuSL_CheckedChanged(object sender, EventArgs e)
        {
            this.loadDataTable_DuSL();
            this.loadDataTableView();
        }

        private void rbtnHetHan_CheckedChanged(object sender, EventArgs e)
        {
            this.loadDataTable_HetHan();
            this.loadDataTableView();
        }

        ////////////////////////////////////////////////////////////////// TẠO MẪU TUYỂN DỤNG
        private void btnTaoMau_MouseHover(object sender, EventArgs e)
        {
            this.btnTaoMau.FlatStyle = FlatStyle.Flat;
            this.btnTaoMau.FlatAppearance.BorderSize = 1;
            this.btnTaoMau.FlatAppearance.BorderColor = Color.White;
            this.btnTaoMau.BackColor = Color.MidnightBlue;
            this.btnTaoMau.ForeColor = Color.White;
        }

        private void btnTaoMau_MouseLeave(object sender, EventArgs e)
        {
            this.btnTaoMau.FlatStyle = FlatStyle.Flat;
            this.btnTaoMau.FlatAppearance.BorderSize = 0;
            this.btnTaoMau.BackColor = Color.WhiteSmoke;
            this.btnTaoMau.ForeColor = Color.Black;
        }

        private void btnTaoMau_Click(object sender, EventArgs e)
        {
            TAOMAUTUYENDUNG frmTaoMTD = new TAOMAUTUYENDUNG(this);
            frmTaoMTD.maDV = MADV;
            frmTaoMTD.ShowDialog();
        }

        ////////////////////////////////////////////////////////////////// QUẢN LÝ ĐƠN TUYỂN DỤNG & SỬA MẪU TUYỂN DỤNG
        private void tbMauTuyenDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.tbMauTuyenDung.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    string colName = this.tbMauTuyenDung.Columns[e.ColumnIndex].Name;

                    if (colName == "DS Don")
                    {
                        this.tbMauTuyenDung.CurrentRow.Selected = true;
                        MENU_DONTUYENDUNG frmQuanLyDTD = new MENU_DONTUYENDUNG(this);
                        frmQuanLyDTD.ID = int.Parse(this.tbMauTuyenDung.Rows[e.RowIndex].Cells[0].Value.ToString());
                        frmQuanLyDTD.ShowDialog();
                    }

                    if (colName == "Sua TT")
                    {
                        this.tbMauTuyenDung.CurrentRow.Selected = true;
                        SUAMAUTUYENDUNG frmSuaMTD = new SUAMAUTUYENDUNG(this);
                        frmSuaMTD.txtID.Text = this.tbMauTuyenDung.Rows[e.RowIndex].Cells[0].Value.ToString();
                        frmSuaMTD.txtMaDV.Text = this.tbMauTuyenDung.Rows[e.RowIndex].Cells[1].Value.ToString();
                        frmSuaMTD.txtMaViec.Text = this.tbMauTuyenDung.Rows[e.RowIndex].Cells[2].Value.ToString();
                        frmSuaMTD.txtQuyMo.Text = this.tbMauTuyenDung.Rows[e.RowIndex].Cells[3].Value.ToString();
                        frmSuaMTD.dtpTGBD.Value = DateTime.Parse(this.tbMauTuyenDung.Rows[e.RowIndex].Cells[4].Value.ToString());
                        frmSuaMTD.dtpTGKT.Value = DateTime.Parse(this.tbMauTuyenDung.Rows[e.RowIndex].Cells[5].Value.ToString());
                        frmSuaMTD.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chỉ chọn dòng tương ứng", "Cảnh báo!");
            }
        }

        ////////////////////////////////////////////////////////////////// XÓA MẪU TUYỂN DỤNG
        private bool checkTruocXoa()
        {
            bool checkBoxCells = false;
            bool checkDon = false;
            for (int i = this.tbMauTuyenDung.RowCount - 1; i >= 0; i--)
            {
                DataGridViewRow row = this.tbMauTuyenDung.Rows[i];
                if (Convert.ToBoolean(row.Cells[8].Value))
                {
                    checkBoxCells = true;
                    if (this.bUS_DON_TUYENDUNG.kTraDonTonTai(Convert.ToInt32(row.Cells[0].Value)))
                    {
                        checkDon = true;
                        break;
                    }
                }
            }

            if (!checkBoxCells)
            {
                MessageBox.Show("Bạn chưa lựa chọn dòng để xóa!", "Thông báo");
                return false;
            }
            if (checkDon)
            {
                MessageBox.Show("Mẫu tuyển dụng vẫn còn đơn.", "Không thể xóa!");
                return false;
            }

            return true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (checkTruocXoa())
            {
                bool checkXoa = true;
                if (MessageBox.Show("Xác nhận xóa những mẫu tuyển dụng đã lựa chọn?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = this.tbMauTuyenDung.RowCount - 1; i >= 0; i--)
                    {
                        DataGridViewRow row = this.tbMauTuyenDung.Rows[i];
                        if (Convert.ToBoolean(row.Cells[8].Value))
                        {
                            try
                            {
                                int ID = Convert.ToInt32(row.Cells[0].Value);
                                bUS_DONVITUYENDUNG_VIECLAM.xoaMauTuyenDung(ID);
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show("Xóa thất bại!!!", "Lỗi!");
                                checkXoa = false;
                                this.loadDataTable();
                                this.loadDataTableView();
                            }
                        }
                    }
                }
                if (checkXoa)
                {
                    MessageBox.Show("Xóa thành công!!!", "Thông báo");
                    this.loadDataTable();
                    this.loadDataTableView();
                }
            }
        }

        ////////////////////////////////////////////////////////////////// DANH SÁCH CÔNG VIỆC
        private void btnDSViec_MouseHover(object sender, EventArgs e)
        {
            this.btnDSViec.FlatStyle = FlatStyle.Flat;
            this.btnDSViec.FlatAppearance.BorderSize = 1;
            this.btnDSViec.FlatAppearance.BorderColor = Color.White;
            this.btnDSViec.BackColor = Color.MidnightBlue;
            this.btnDSViec.ForeColor = Color.White;
        }

        private void btnDSViec_MouseLeave(object sender, EventArgs e)
        {
            this.btnDSViec.FlatStyle = FlatStyle.Flat;
            this.btnDSViec.FlatAppearance.BorderSize = 0;
            this.btnDSViec.BackColor = Color.WhiteSmoke;
            this.btnDSViec.ForeColor = Color.Black;
        }

        private void btnDSViec_Click(object sender, EventArgs e)
        {
            MENU_DANHSACHCONGVIEC frmDSCV = new MENU_DANHSACHCONGVIEC();
            frmDSCV.ShowDialog();
        }

        ////////////////////////////////////////////////////////////////// LÀM MỚI
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            this.dtpBD.Value = DateTime.Now;
            this.dtpKT.Value = DateTime.Now;
            this.txtTimKiem.Text = "";
            this.rbtnTatCa.Checked = true;
            this.rbtnTatCa_CheckedChanged(sender, e);
        }

        ////////////////////////////////////////////////////////////////// TÙY CHỌN
        private void btnTuyChon_MouseHover(object sender, EventArgs e)
        {
            this.btnTuyChon.BackColor = Color.RoyalBlue;
        }

        private void btnTuyChon_Click(object sender, EventArgs e)
        {
            MENU_DONVITUYENDUNG_TAIKHOAN frmDVTD_TK = new MENU_DONVITUYENDUNG_TAIKHOAN(getDVTD, this);
            frmDVTD_TK.ShowDialog();
        }
    }
}
