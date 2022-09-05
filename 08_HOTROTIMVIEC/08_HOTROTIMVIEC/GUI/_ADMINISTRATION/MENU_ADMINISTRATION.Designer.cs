
namespace _08_HOTROTIMVIEC.GUI._ADMINISTRATION
{
    partial class MENU_ADMINISTRATION
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDSViec = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnCamSuDung = new System.Windows.Forms.Button();
            this.btnChoPhepSD = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.richtxtDiaChi_Admin = new System.Windows.Forms.RichTextBox();
            this.txtTrangThai_Admin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSDT_Admin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenDV_Admin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaDV_Admin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbDVTKTaiKhoan = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDVTKTaiKhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDSViec);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 49);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // btnDSViec
            // 
            this.btnDSViec.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDSViec.FlatAppearance.BorderSize = 0;
            this.btnDSViec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDSViec.Font = new System.Drawing.Font("Leelawadee UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDSViec.Location = new System.Drawing.Point(346, 9);
            this.btnDSViec.Name = "btnDSViec";
            this.btnDSViec.Size = new System.Drawing.Size(214, 30);
            this.btnDSViec.TabIndex = 0;
            this.btnDSViec.Text = "Danh Sách Công Việc";
            this.btnDSViec.UseVisualStyleBackColor = false;
            this.btnDSViec.Click += new System.EventHandler(this.btnDSViec_Click);
            this.btnDSViec.MouseLeave += new System.EventHandler(this.btnDSViec_MouseLeave);
            this.btnDSViec.MouseHover += new System.EventHandler(this.btnDSViec_MouseHover);
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(566, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(50, 47);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "[X]";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(12, 14);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(321, 22);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.Enter += new System.EventHandler(this.txtTimKiem_Enter);
            this.txtTimKiem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyUp);
            this.txtTimKiem.Leave += new System.EventHandler(this.txtTimKiem_Leave);
            // 
            // btnCamSuDung
            // 
            this.btnCamSuDung.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCamSuDung.FlatAppearance.BorderSize = 0;
            this.btnCamSuDung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCamSuDung.Font = new System.Drawing.Font("Leelawadee UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCamSuDung.Location = new System.Drawing.Point(173, 376);
            this.btnCamSuDung.Name = "btnCamSuDung";
            this.btnCamSuDung.Size = new System.Drawing.Size(173, 30);
            this.btnCamSuDung.TabIndex = 7;
            this.btnCamSuDung.Text = "Cấm Sử Dụng";
            this.btnCamSuDung.UseVisualStyleBackColor = false;
            this.btnCamSuDung.Click += new System.EventHandler(this.btnCamSuDung_Click);
            this.btnCamSuDung.MouseLeave += new System.EventHandler(this.btnCamSuDung_MouseLeave);
            this.btnCamSuDung.MouseHover += new System.EventHandler(this.btnCamSuDung_MouseHover);
            // 
            // btnChoPhepSD
            // 
            this.btnChoPhepSD.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnChoPhepSD.FlatAppearance.BorderSize = 0;
            this.btnChoPhepSD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChoPhepSD.Font = new System.Drawing.Font("Leelawadee UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoPhepSD.Location = new System.Drawing.Point(0, 376);
            this.btnChoPhepSD.Name = "btnChoPhepSD";
            this.btnChoPhepSD.Size = new System.Drawing.Size(173, 30);
            this.btnChoPhepSD.TabIndex = 7;
            this.btnChoPhepSD.Text = "Cho Phép Sử Dụng";
            this.btnChoPhepSD.UseVisualStyleBackColor = false;
            this.btnChoPhepSD.Click += new System.EventHandler(this.btnChoPhepSD_Click);
            this.btnChoPhepSD.MouseLeave += new System.EventHandler(this.btnChoPhepSD_MouseLeave);
            this.btnChoPhepSD.MouseHover += new System.EventHandler(this.btnChoPhepSD_MouseHover);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel3.Controls.Add(this.richtxtDiaChi_Admin);
            this.panel3.Controls.Add(this.txtTrangThai_Admin);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtSDT_Admin);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtTenDV_Admin);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtMaDV_Admin);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btnCamSuDung);
            this.panel3.Controls.Add(this.btnChoPhepSD);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 49);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(347, 406);
            this.panel3.TabIndex = 0;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDown);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseMove);
            this.panel3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseUp);
            // 
            // richtxtDiaChi_Admin
            // 
            this.richtxtDiaChi_Admin.BackColor = System.Drawing.Color.White;
            this.richtxtDiaChi_Admin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richtxtDiaChi_Admin.Enabled = false;
            this.richtxtDiaChi_Admin.Font = new System.Drawing.Font("Leelawadee UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richtxtDiaChi_Admin.Location = new System.Drawing.Point(13, 189);
            this.richtxtDiaChi_Admin.Name = "richtxtDiaChi_Admin";
            this.richtxtDiaChi_Admin.Size = new System.Drawing.Size(321, 59);
            this.richtxtDiaChi_Admin.TabIndex = 34;
            this.richtxtDiaChi_Admin.Text = "";
            // 
            // txtTrangThai_Admin
            // 
            this.txtTrangThai_Admin.BackColor = System.Drawing.Color.White;
            this.txtTrangThai_Admin.Enabled = false;
            this.txtTrangThai_Admin.Font = new System.Drawing.Font("Leelawadee UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrangThai_Admin.Location = new System.Drawing.Point(217, 292);
            this.txtTrangThai_Admin.Name = "txtTrangThai_Admin";
            this.txtTrangThai_Admin.Size = new System.Drawing.Size(117, 27);
            this.txtTrangThai_Admin.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(214, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "TRẠNG THÁI";
            // 
            // txtSDT_Admin
            // 
            this.txtSDT_Admin.BackColor = System.Drawing.Color.White;
            this.txtSDT_Admin.Enabled = false;
            this.txtSDT_Admin.Font = new System.Drawing.Font("Leelawadee UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT_Admin.Location = new System.Drawing.Point(13, 292);
            this.txtSDT_Admin.Name = "txtSDT_Admin";
            this.txtSDT_Admin.Size = new System.Drawing.Size(198, 27);
            this.txtSDT_Admin.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(10, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "SỐ ĐIỆN THOẠI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "ĐỊA CHỈ";
            // 
            // txtTenDV_Admin
            // 
            this.txtTenDV_Admin.BackColor = System.Drawing.Color.White;
            this.txtTenDV_Admin.Enabled = false;
            this.txtTenDV_Admin.Font = new System.Drawing.Font("Leelawadee UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDV_Admin.Location = new System.Drawing.Point(14, 122);
            this.txtTenDV_Admin.Name = "txtTenDV_Admin";
            this.txtTenDV_Admin.Size = new System.Drawing.Size(321, 27);
            this.txtTenDV_Admin.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(11, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "TÊN ĐƠN VỊ";
            // 
            // txtMaDV_Admin
            // 
            this.txtMaDV_Admin.BackColor = System.Drawing.Color.White;
            this.txtMaDV_Admin.Enabled = false;
            this.txtMaDV_Admin.Font = new System.Drawing.Font("Leelawadee UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDV_Admin.Location = new System.Drawing.Point(13, 55);
            this.txtMaDV_Admin.Name = "txtMaDV_Admin";
            this.txtMaDV_Admin.Size = new System.Drawing.Size(321, 27);
            this.txtMaDV_Admin.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 29;
            this.label3.Text = "MÃ ĐƠN VỊ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbDVTKTaiKhoan);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(347, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(271, 406);
            this.panel2.TabIndex = 2;
            // 
            // tbDVTKTaiKhoan
            // 
            this.tbDVTKTaiKhoan.AllowUserToOrderColumns = true;
            this.tbDVTKTaiKhoan.BackgroundColor = System.Drawing.Color.White;
            this.tbDVTKTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbDVTKTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDVTKTaiKhoan.Location = new System.Drawing.Point(0, 0);
            this.tbDVTKTaiKhoan.Name = "tbDVTKTaiKhoan";
            this.tbDVTKTaiKhoan.RowHeadersWidth = 51;
            this.tbDVTKTaiKhoan.RowTemplate.Height = 24;
            this.tbDVTKTaiKhoan.Size = new System.Drawing.Size(271, 406);
            this.tbDVTKTaiKhoan.TabIndex = 0;
            this.tbDVTKTaiKhoan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbDVTKTaiKhoan_CellClick);
            // 
            // MENU_ADMINISTRATION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 455);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MENU_ADMINISTRATION";
            this.Load += new System.EventHandler(this.MENU_ADMINISTRATION_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbDVTKTaiKhoan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnChoPhepSD;
        private System.Windows.Forms.Button btnCamSuDung;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDSViec;
        private System.Windows.Forms.RichTextBox richtxtDiaChi_Admin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView tbDVTKTaiKhoan;
        private System.Windows.Forms.TextBox txtTrangThai_Admin;
        private System.Windows.Forms.TextBox txtSDT_Admin;
        private System.Windows.Forms.TextBox txtTenDV_Admin;
        private System.Windows.Forms.TextBox txtMaDV_Admin;
    }
}