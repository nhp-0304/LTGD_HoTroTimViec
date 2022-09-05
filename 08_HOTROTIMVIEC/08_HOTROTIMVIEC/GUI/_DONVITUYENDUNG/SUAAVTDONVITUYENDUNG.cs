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
    public partial class SUAAVTDONVITUYENDUNG : Form
    {
        DONVITUYENDUNG dvtd;

        BUS_SERVICES bUS_SERVICES;

        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        private string linkImage = null;
        public SUAAVTDONVITUYENDUNG(DONVITUYENDUNG dvtd_ThamSo)
        {
            InitializeComponent();
            dvtd = dvtd_ThamSo;
        }

        private void SUAAVTDONVITUYENDUNG_Load(object sender, EventArgs e)
        {
            bUS_SERVICES = new BUS_SERVICES();

            if (!string.IsNullOrEmpty(bUS_SERVICES.getLinkDV(dvtd.MaDV)))
                this.pBoxAvtDVTD.Image = Image.FromFile("DONVI/" + bUS_SERVICES.getLinkDV(dvtd.MaDV));
            else
                this.pBoxAvtDVTD.Image = Properties.Resources.noImage;
        }

        //////////////////////////////////////////////////////////////////
        private void pBoxAvtDVTD_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void pBoxAvtDVTD_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void pBoxAvtDVTD_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        private void pBoxAvtDVTD_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận thoát?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Dispose();
                this.Close();
            }
        }

        //////////////////////////////////////////////////////////////////
        private void btnLuuAnh_MouseHover(object sender, EventArgs e)
        {
            this.btnLuuAnh.FlatAppearance.BorderSize = 1;
            this.btnLuuAnh.FlatAppearance.BorderColor = Color.White;
            this.btnLuuAnh.BackColor = Color.MidnightBlue;
            this.btnLuuAnh.ForeColor = Color.White;
        }

        private void btnLuuAnh_MouseLeave(object sender, EventArgs e)
        {
            this.btnLuuAnh.FlatAppearance.BorderSize = 0;
            this.btnLuuAnh.BackColor = Color.WhiteSmoke;
            this.btnLuuAnh.ForeColor = Color.Black;
        }

        private void btnLuuAnh_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Lưu ảnh đại diện?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    bUS_SERVICES.UpdateImage_Link_DV(dvtd.MaDV, linkImage);
                    MessageBox.Show("Cập nhật thành công!!!", "Thông báo");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Cập nhật thất bại!!!", "Lỗi!");
                }
            }
            this.btnLuuAnh.Enabled = false;
        }

        //////////////////////////////////////////////////////////////////
        private void btnChonAnh_MouseHover(object sender, EventArgs e)
        {
            this.btnChonAnh.FlatAppearance.BorderSize = 1;
            this.btnChonAnh.FlatAppearance.BorderColor = Color.White;
            this.btnChonAnh.BackColor = Color.MidnightBlue;
            this.btnChonAnh.ForeColor = Color.White;
        }

        private void btnChonAnh_MouseLeave(object sender, EventArgs e)
        {
            this.btnChonAnh.FlatAppearance.BorderSize = 0;
            this.btnChonAnh.BackColor = Color.WhiteSmoke;
            this.btnChonAnh.ForeColor = Color.Black;
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            this.btnLuuAnh.Enabled = true;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "D:\\trancongthuc\\HOTROTIMVIEC\\08_HOTROTIMVIEC\\08_HOTROTIMVIEC\\bin\\Debug\\DONVI";
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Images(*.jpg)|*.jpg|PNG (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                linkImage = System.IO.Path.GetFileName(openFileDialog.FileName);
                this.pBoxAvtDVTD.Image = Image.FromFile(openFileDialog.FileName);
                this.pBoxAvtDVTD.Show();
            }
        }
    }
}
