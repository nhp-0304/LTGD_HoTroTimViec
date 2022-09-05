namespace _08_HOTROTIMVIEC.GUI._DONVITUYENDUNG
{
    partial class MENU_DANHSACHCONGVIEC
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
            this.btnTaoViec = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbViecLam = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbViecLam)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnTaoViec);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1078, 49);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // btnTaoViec
            // 
            this.btnTaoViec.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTaoViec.FlatAppearance.BorderSize = 0;
            this.btnTaoViec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoViec.Font = new System.Drawing.Font("Leelawadee UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoViec.Location = new System.Drawing.Point(442, 8);
            this.btnTaoViec.Name = "btnTaoViec";
            this.btnTaoViec.Size = new System.Drawing.Size(190, 30);
            this.btnTaoViec.TabIndex = 7;
            this.btnTaoViec.Text = "Tạo Mẫu Việc Làm";
            this.btnTaoViec.UseVisualStyleBackColor = false;
            this.btnTaoViec.Click += new System.EventHandler(this.btnTaoViec_Click);
            this.btnTaoViec.MouseLeave += new System.EventHandler(this.btnTaoViec_MouseLeave);
            this.btnTaoViec.MouseHover += new System.EventHandler(this.btnTaoViec_MouseHover);
            // 
            // btnThoat
            // 
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(1026, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(50, 47);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "[X]";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(12, 12);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(321, 22);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.Enter += new System.EventHandler(this.txtTimKiem_Enter);
            this.txtTimKiem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyUp);
            this.txtTimKiem.Leave += new System.EventHandler(this.txtTimKiem_Leave);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tbViecLam);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1078, 589);
            this.panel2.TabIndex = 1;
            // 
            // tbViecLam
            // 
            this.tbViecLam.BackgroundColor = System.Drawing.Color.White;
            this.tbViecLam.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbViecLam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbViecLam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbViecLam.Location = new System.Drawing.Point(0, 0);
            this.tbViecLam.Name = "tbViecLam";
            this.tbViecLam.RowHeadersWidth = 51;
            this.tbViecLam.RowTemplate.Height = 24;
            this.tbViecLam.Size = new System.Drawing.Size(1076, 587);
            this.tbViecLam.TabIndex = 0;
            this.tbViecLam.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbViecLam_CellContentClick);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btnLamMoi);
            this.panel5.Controls.Add(this.btnXoa);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 600);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1078, 38);
            this.panel5.TabIndex = 8;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLamMoi.Font = new System.Drawing.Font("Leelawadee UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Image = global::_08_HOTROTIMVIEC.Properties.Resources.LamMoi;
            this.btnLamMoi.Location = new System.Drawing.Point(0, 0);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(36, 36);
            this.btnLamMoi.TabIndex = 13;
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Image = global::_08_HOTROTIMVIEC.Properties.Resources.Xoa;
            this.btnXoa.Location = new System.Drawing.Point(1040, 0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(36, 36);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // DANHSACHCONGVIEC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 638);
            this.ControlBox = false;
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DANHSACHCONGVIEC";
            this.Load += new System.EventHandler(this.DANHSACHCONGVIEC_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbViecLam)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView tbViecLam;
        private System.Windows.Forms.Button btnTaoViec;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
    }
}