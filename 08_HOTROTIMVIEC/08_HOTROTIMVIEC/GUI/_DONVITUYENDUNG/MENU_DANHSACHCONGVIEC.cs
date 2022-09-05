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
    public partial class MENU_DANHSACHCONGVIEC : Form
    {
        BUS_VIECLAM bUS_VIECLAM;
        BUS_DONVITUYENDUNG_VIECLAM bUS_DONVITUYENDUNG_VIECLAM;

        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        public MENU_DANHSACHCONGVIEC()
        {
            InitializeComponent();

            /////////////////////////////////////////// TIM KIEM
            this.txtTimKiem.ForeColor = Color.Gray;
            this.txtTimKiem.Text = " Tìm kiếm trên bảng";
            this.txtTimKiem.Leave += new System.EventHandler(this.txtTimKiem_Leave);
            this.txtTimKiem.Enter += new System.EventHandler(this.txtTimKiem_Enter);
        }

        private void DANHSACHCONGVIEC_Load(object sender, EventArgs e)
        {
            bUS_VIECLAM = new BUS_VIECLAM();
            bUS_DONVITUYENDUNG_VIECLAM = new BUS_DONVITUYENDUNG_VIECLAM();

            this.loadDataTableInit();
            this.loadDataTableView();
        }

        ////////////////////////////////////////////////////////////////// THÊM CÁC COLUMN DẠNG METHOD
        private void addButtonSua()
        {
            DataGridViewImageColumn imgSua = new DataGridViewImageColumn();
            imgSua.Name = "Sua TT";
            imgSua.Image = Properties.Resources.Sua;
            this.tbViecLam.Columns.Add(imgSua);
        }

        private void addCheckBox()
        {
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            this.tbViecLam.Columns.Add(checkBoxColumn);
        }

        private bool unCheckedAll = true;
        private CheckBox checkboxHeader;
        private void addCheckBoxHeader()
        {
            Rectangle rect = this.tbViecLam.GetCellDisplayRectangle(5, -1, true);
            rect.X = rect.Location.X + 234;
            rect.Y = rect.Location.Y + 1;
            checkboxHeader = new CheckBox();
            checkboxHeader.Name = "checkBoxHeader";
            checkboxHeader.Location = rect.Location;
            checkboxHeader.Size = new Size(20, 20);
            checkboxHeader.CheckAlign = ContentAlignment.MiddleCenter;
            checkboxHeader.BackColor = Color.RoyalBlue;

            checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);

            this.tbViecLam.Controls.Add(checkboxHeader);
        }

        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxHeader.Checked)
            {
                for (int i = 0; i < this.tbViecLam.RowCount; i++)
                {
                    this.tbViecLam[5, i].Value = true;
                }
            }
            else
            {
                if (unCheckedAll)
                {
                    for (int i = 0; i < this.tbViecLam.RowCount; i++)
                    {
                        this.tbViecLam[5, i].Value = false;
                    }
                }
            }
            unCheckedAll = true;
        }

        ////////////////////////////////////////////////////////////////// LOAD DATAGIRDVIEW
        public void loadDataTableView()
        {
            this.tbViecLam.RowHeadersWidth = 4;

            this.tbViecLam.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.tbViecLam.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.tbViecLam.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.tbViecLam.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.tbViecLam.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.tbViecLam.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.tbViecLam.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.tbViecLam.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.tbViecLam.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.tbViecLam.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.tbViecLam.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.tbViecLam.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.tbViecLam.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void loadDataTableInit()
        {
            bUS_VIECLAM = new BUS_VIECLAM();
            this.tbViecLam.DataSource = bUS_VIECLAM.getViecLam();
            this.addButtonSua();
            this.addCheckBox();
            this.addCheckBoxHeader();
        }

        public void loadDataTable()
        {
            this.tbViecLam.Columns.Clear();
            bUS_VIECLAM = new BUS_VIECLAM();
            this.tbViecLam.DataSource = bUS_VIECLAM.getViecLam();
            this.addButtonSua();
            this.addCheckBox();
        }

        public void loadDataTable(int maViec)
        {
            this.tbViecLam.Columns.Clear();
            this.bUS_VIECLAM = new BUS_VIECLAM();
            this.tbViecLam.DataSource = bUS_VIECLAM.getViecLam(maViec);
            this.addButtonSua();
            this.addCheckBox();
        }

        public void loadDataTable(string tenViec)
        {
            this.tbViecLam.Columns.Clear();
            this.bUS_VIECLAM = new BUS_VIECLAM();
            this.tbViecLam.DataSource = bUS_VIECLAM.getViecLam(tenViec);
            this.addButtonSua();
            this.addCheckBox();
        }

        ////////////////////////////////////////////////////////////////// TÌM KIẾM 
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
                this.loadDataTableView();
            }
            if (!(string.IsNullOrWhiteSpace(this.txtTimKiem.Text) && string.IsNullOrEmpty(this.txtTimKiem.Text)))
            {
                if (this.IsNumber(this.txtTimKiem.Text))
                {
                    this.loadDataTable(int.Parse(this.txtTimKiem.Text));
                    this.loadDataTableView();
                }
                if (!this.IsNumber(this.txtTimKiem.Text))
                {
                    this.loadDataTable(this.txtTimKiem.Text.Trim());
                    this.loadDataTableView();
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

        ////////////////////////////////////////////////////////////////// THOÁT
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        ////////////////////////////////////////////////////////////////// SỬA CLICK
        private void tbViecLam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.tbViecLam.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    string colName = this.tbViecLam.Columns[e.ColumnIndex].Name;

                    if (colName == "Sua TT")
                    {
                        this.tbViecLam.CurrentRow.Selected = true;
                        SUAMAUVIECLAM frmSuaMVL = new SUAMAUVIECLAM(this);
                        frmSuaMVL.txtMaViec.Text = this.tbViecLam.Rows[e.RowIndex].Cells[0].Value.ToString();
                        frmSuaMVL.txtTenViec.Text = this.tbViecLam.Rows[e.RowIndex].Cells[1].Value.ToString();
                        frmSuaMVL.richtxtMoTa.Text = this.tbViecLam.Rows[e.RowIndex].Cells[2].Value.ToString();
                        frmSuaMVL.txtMucLuong.Text = this.tbViecLam.Rows[e.RowIndex].Cells[3].Value.ToString();
                        frmSuaMVL.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chỉ chọn dòng tương ứng", "Cảnh báo!");
            }
        }

        ////////////////////////////////////////////////////////////////// LÀM MỚI
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            this.txtTimKiem.Text = " Tìm kiếm trên bảng";
            this.txtTimKiem.ForeColor = Color.Gray;
            this.loadDataTable();
            this.loadDataTableView();
        }

        ////////////////////////////////////////////////////////////////// XÓA
        private bool checkTruocXoa()
        {
            bool checkBoxCells = false;
            bool checkMau = false;
            for (int i = this.tbViecLam.RowCount - 1; i >= 0; i--)
            {
                DataGridViewRow row = this.tbViecLam.Rows[i];
                if (Convert.ToBoolean(row.Cells[5].Value))
                {
                    checkBoxCells = true;
                    if (this.bUS_DONVITUYENDUNG_VIECLAM.kTraCoMTD(Convert.ToInt32(row.Cells[0].Value)))
                    {
                        checkMau = true;
                        break;
                    }
                }
            }

            if (!checkBoxCells)
            {
                MessageBox.Show("Bạn chưa lựa chọn dòng để xóa!", "Thông báo");
                return false;
            }
            if (checkMau)
            {
                MessageBox.Show("Có mẫu việc làm đang được sử dụng.", "Không thể xóa!");
                return false;
            }

            return true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (checkTruocXoa())
            {
                bool checkXoa = true;
                if (MessageBox.Show("Xác nhận xóa những mẫu việc làm đã lựa chọn?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = this.tbViecLam.RowCount - 1; i >= 0; i--)
                    {
                        DataGridViewRow row = this.tbViecLam.Rows[i];
                        if (Convert.ToBoolean(row.Cells[5].Value))
                        {
                            try
                            {
                                int maViec = Convert.ToInt32(row.Cells[0].Value);
                                bUS_VIECLAM.xoaMauViecLam(maViec);
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

        ////////////////////////////////////////////////////////////////// TẠO VIỆC
        private void btnTaoViec_MouseHover(object sender, EventArgs e)
        {
            this.btnTaoViec.FlatStyle = FlatStyle.Flat;
            this.btnTaoViec.FlatAppearance.BorderSize = 1;
            this.btnTaoViec.FlatAppearance.BorderColor = Color.White;
            this.btnTaoViec.BackColor = Color.MidnightBlue;
            this.btnTaoViec.ForeColor = Color.White;
        }

        private void btnTaoViec_MouseLeave(object sender, EventArgs e)
        {
            this.btnTaoViec.FlatStyle = FlatStyle.Flat;
            this.btnTaoViec.FlatAppearance.BorderSize = 0;
            this.btnTaoViec.BackColor = Color.WhiteSmoke;
            this.btnTaoViec.ForeColor = Color.Black;
        }

        private void btnTaoViec_Click(object sender, EventArgs e)
        {
            TAOMAUVIECLAM frmTaoMVL = new TAOMAUVIECLAM(this);
            frmTaoMVL.ShowDialog();
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
