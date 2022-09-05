namespace _08_HOTROTIMVIEC.GUI._DONVITUYENDUNG
{
    partial class SUAAVTDONVITUYENDUNG
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pBoxAvtDVTD = new System.Windows.Forms.PictureBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.btnLuuAnh = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxAvtDVTD)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnChonAnh);
            this.panel1.Controls.Add(this.btnLuuAnh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 300);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 40);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pBoxAvtDVTD);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 300);
            this.panel2.TabIndex = 2;
            // 
            // pBoxAvtDVTD
            // 
            this.pBoxAvtDVTD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBoxAvtDVTD.Location = new System.Drawing.Point(0, 0);
            this.pBoxAvtDVTD.Name = "pBoxAvtDVTD";
            this.pBoxAvtDVTD.Size = new System.Drawing.Size(300, 300);
            this.pBoxAvtDVTD.TabIndex = 0;
            this.pBoxAvtDVTD.TabStop = false;
            this.pBoxAvtDVTD.DoubleClick += new System.EventHandler(this.pBoxAvtDVTD_DoubleClick);
            this.pBoxAvtDVTD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxAvtDVTD_MouseDown);
            this.pBoxAvtDVTD.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pBoxAvtDVTD_MouseMove);
            this.pBoxAvtDVTD.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxAvtDVTD_MouseUp);
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnChonAnh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChonAnh.FlatAppearance.BorderSize = 0;
            this.btnChonAnh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonAnh.Font = new System.Drawing.Font("Leelawadee UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonAnh.Location = new System.Drawing.Point(150, 0);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(150, 40);
            this.btnChonAnh.TabIndex = 8;
            this.btnChonAnh.Text = "Chọn Ảnh";
            this.btnChonAnh.UseVisualStyleBackColor = false;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            this.btnChonAnh.MouseLeave += new System.EventHandler(this.btnChonAnh_MouseLeave);
            this.btnChonAnh.MouseHover += new System.EventHandler(this.btnChonAnh_MouseHover);
            // 
            // btnLuuAnh
            // 
            this.btnLuuAnh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLuuAnh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLuuAnh.Enabled = false;
            this.btnLuuAnh.FlatAppearance.BorderSize = 0;
            this.btnLuuAnh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuAnh.Font = new System.Drawing.Font("Leelawadee UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuAnh.Location = new System.Drawing.Point(0, 0);
            this.btnLuuAnh.Name = "btnLuuAnh";
            this.btnLuuAnh.Size = new System.Drawing.Size(150, 40);
            this.btnLuuAnh.TabIndex = 9;
            this.btnLuuAnh.Text = "Lưu Ảnh";
            this.btnLuuAnh.UseVisualStyleBackColor = false;
            this.btnLuuAnh.Click += new System.EventHandler(this.btnLuuAnh_Click);
            this.btnLuuAnh.MouseLeave += new System.EventHandler(this.btnLuuAnh_MouseLeave);
            this.btnLuuAnh.MouseHover += new System.EventHandler(this.btnLuuAnh_MouseHover);
            // 
            // SUAAVTDONVITUYENDUNG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 340);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SUAAVTDONVITUYENDUNG";
            this.Load += new System.EventHandler(this.SUAAVTDONVITUYENDUNG_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxAvtDVTD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pBoxAvtDVTD;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.Button btnLuuAnh;
    }
}