
namespace _08_HOTROTIMVIEC.GUI._NGUOILAODONG
{
    partial class MENU_NGUOILAODONG
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel_main = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnXemXuHuong = new System.Windows.Forms.Button();
            this.btnQuanLyDon = new System.Windows.Forms.Button();
            this.btnDoiMatKhau = new System.Windows.Forms.Button();
            this.btnThongTin = new System.Windows.Forms.Button();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.lblDangXuat = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_main
            // 
            this.panel_main.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(0, 0);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(1035, 576);
            this.panel_main.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Controls.Add(this.btnXemXuHuong);
            this.groupBox1.Controls.Add(this.btnQuanLyDon);
            this.groupBox1.Controls.Add(this.btnDoiMatKhau);
            this.groupBox1.Controls.Add(this.btnThongTin);
            this.groupBox1.Controls.Add(this.btnTrangChu);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 576);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CHỨC NĂNG";
            // 
            // btnXemXuHuong
            // 
            this.btnXemXuHuong.BackColor = System.Drawing.Color.White;
            this.btnXemXuHuong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemXuHuong.ForeColor = System.Drawing.Color.Black;
            this.btnXemXuHuong.Location = new System.Drawing.Point(0, 423);
            this.btnXemXuHuong.Name = "btnXemXuHuong";
            this.btnXemXuHuong.Size = new System.Drawing.Size(197, 55);
            this.btnXemXuHuong.TabIndex = 3;
            this.btnXemXuHuong.Text = "Theo Dõi Xu Hướng";
            this.btnXemXuHuong.UseVisualStyleBackColor = false;
            this.btnXemXuHuong.Click += new System.EventHandler(this.btnXemXuHuong_Click);
            // 
            // btnQuanLyDon
            // 
            this.btnQuanLyDon.BackColor = System.Drawing.Color.White;
            this.btnQuanLyDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuanLyDon.ForeColor = System.Drawing.Color.Black;
            this.btnQuanLyDon.Location = new System.Drawing.Point(0, 337);
            this.btnQuanLyDon.Name = "btnQuanLyDon";
            this.btnQuanLyDon.Size = new System.Drawing.Size(197, 55);
            this.btnQuanLyDon.TabIndex = 2;
            this.btnQuanLyDon.Text = "Đơn Cá Nhân";
            this.btnQuanLyDon.UseVisualStyleBackColor = false;
            this.btnQuanLyDon.Click += new System.EventHandler(this.btnQuanLyDon_Click);
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.BackColor = System.Drawing.Color.White;
            this.btnDoiMatKhau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoiMatKhau.ForeColor = System.Drawing.Color.Black;
            this.btnDoiMatKhau.Location = new System.Drawing.Point(0, 255);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Size = new System.Drawing.Size(197, 55);
            this.btnDoiMatKhau.TabIndex = 2;
            this.btnDoiMatKhau.Text = "Tài Khoản";
            this.btnDoiMatKhau.UseVisualStyleBackColor = false;
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // btnThongTin
            // 
            this.btnThongTin.BackColor = System.Drawing.Color.White;
            this.btnThongTin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongTin.ForeColor = System.Drawing.Color.Black;
            this.btnThongTin.Location = new System.Drawing.Point(0, 167);
            this.btnThongTin.Name = "btnThongTin";
            this.btnThongTin.Size = new System.Drawing.Size(197, 55);
            this.btnThongTin.TabIndex = 1;
            this.btnThongTin.Text = "Thông Tin";
            this.btnThongTin.UseVisualStyleBackColor = false;
            this.btnThongTin.Click += new System.EventHandler(this.btnThongTin_Click);
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.BackColor = System.Drawing.Color.White;
            this.btnTrangChu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrangChu.ForeColor = System.Drawing.Color.Black;
            this.btnTrangChu.Location = new System.Drawing.Point(0, 76);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(197, 55);
            this.btnTrangChu.TabIndex = 0;
            this.btnTrangChu.Text = "Trang Chủ";
            this.btnTrangChu.UseVisualStyleBackColor = false;
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // lblDangXuat
            // 
            this.lblDangXuat.AutoSize = true;
            this.lblDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangXuat.ForeColor = System.Drawing.Color.Blue;
            this.lblDangXuat.Location = new System.Drawing.Point(3, 0);
            this.lblDangXuat.Name = "lblDangXuat";
            this.lblDangXuat.Size = new System.Drawing.Size(67, 16);
            this.lblDangXuat.TabIndex = 2;
            this.lblDangXuat.Text = "Đăng xuất";
            this.lblDangXuat.Click += new System.EventHandler(this.lblDangXuat_Click);
            this.lblDangXuat.MouseLeave += new System.EventHandler(this.lblDangXuat_MouseLeave);
            this.lblDangXuat.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblDangXuat_MouseMove);
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.RoyalBlue;
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTitle.ForeColor = System.Drawing.Color.White;
            this.txtTitle.Location = new System.Drawing.Point(0, 23);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(1232, 55);
            this.txtTitle.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 150;
            this.timer1.Tick += new System.EventHandler(this.timerTitle_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.lblDangXuat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1232, 78);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(197, 576);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel_main);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(197, 78);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1035, 576);
            this.panel3.TabIndex = 6;
            // 
            // MENU_NGUOILAODONG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1232, 654);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1248, 693);
            this.MinimumSize = new System.Drawing.Size(1248, 693);
            this.Name = "MENU_NGUOILAODONG";
            this.Text = "CHƯƠNG TRÌNH HỖ TRỢ TÌM VIỆC NHANH";
            this.Load += new System.EventHandler(this.MENU_NGUOILAODONG_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.Button btnThongTin;
        private System.Windows.Forms.Button btnDoiMatKhau;
        private System.Windows.Forms.Button btnQuanLyDon;
        private System.Windows.Forms.Label lblDangXuat;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnXemXuHuong;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}