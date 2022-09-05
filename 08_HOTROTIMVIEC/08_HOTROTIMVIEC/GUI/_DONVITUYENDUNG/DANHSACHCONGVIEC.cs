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

namespace _08_HOTROTIMVIEC.GUI._DONVITUYENDUNG
{
    public partial class DANHSACHCONGVIEC : Form
    {
        BUS_VIECLAM bUS_VIECLAM;
        public DANHSACHCONGVIEC()
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
            this.loadDataTable();
            this.loadDataTableView();
        }

        private void loadDataTableView()
        {
            this.tbViecLam.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.tbViecLam.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.tbViecLam.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.tbViecLam.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.tbViecLam.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.tbViecLam.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.tbViecLam.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.tbViecLam.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.tbViecLam.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public void loadDataTable()
        {
            this.bUS_VIECLAM = new BUS_VIECLAM();
            this.tbViecLam.DataSource = bUS_VIECLAM.getViecLam();
        }

        public void loadDataTable(int maViec)
        {
            this.bUS_VIECLAM = new BUS_VIECLAM();
            this.tbViecLam.DataSource = bUS_VIECLAM.getViecLam(maViec);
        }

        public void loadDataTable(string tenViec)
        {
            this.bUS_VIECLAM = new BUS_VIECLAM();
            this.tbViecLam.DataSource = bUS_VIECLAM.getViecLam(tenViec);
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
            {
                if (this.IsNumber(this.txtTimKiem.Text))
                    this.loadDataTable(int.Parse(this.txtTimKiem.Text));
                if (!this.IsNumber(this.txtTimKiem.Text))
                    this.loadDataTable(this.txtTimKiem.Text.Trim());
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
