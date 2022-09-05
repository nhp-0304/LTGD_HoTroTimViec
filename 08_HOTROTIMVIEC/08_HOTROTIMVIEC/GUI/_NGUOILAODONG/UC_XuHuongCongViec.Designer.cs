
namespace _08_HOTROTIMVIEC.GUI._NGUOILAODONG
{
    partial class UC_XuHuongCongViec
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sVThongKeViecNLDNhieuNhatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hOTROTIMVIECDataSet = new _08_HOTROTIMVIEC.HOTROTIMVIECDataSet();
            this.sV_ThongKeViec_NLDNhieuNhatTableAdapter = new _08_HOTROTIMVIEC.HOTROTIMVIECDataSetTableAdapters.SV_ThongKeViec_NLDNhieuNhatTableAdapter();
            this.dtP_Nam = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sVThongKeViecNLDNhieuNhatBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hOTROTIMVIECDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            this.chart.DataSource = this.sVThongKeViecNLDNhieuNhatBindingSource;
            legend2.Name = "Legend1";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(0, 66);
            this.chart.Name = "chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "SoLuong";
            series2.Points.Add(dataPoint2);
            series2.XValueMember = "TenViec";
            series2.YValueMembers = "SoLuong";
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(1030, 465);
            this.chart.TabIndex = 0;
            this.chart.Text = "XU HƯỚNG CÔNG VIỆC THU HÚT NHẤT";
            // 
            // sVThongKeViecNLDNhieuNhatBindingSource
            // 
            this.sVThongKeViecNLDNhieuNhatBindingSource.DataMember = "SV_ThongKeViec_NLDNhieuNhat";
            this.sVThongKeViecNLDNhieuNhatBindingSource.DataSource = this.hOTROTIMVIECDataSet;
            // 
            // hOTROTIMVIECDataSet
            // 
            this.hOTROTIMVIECDataSet.DataSetName = "HOTROTIMVIECDataSet";
            this.hOTROTIMVIECDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sV_ThongKeViec_NLDNhieuNhatTableAdapter
            // 
            this.sV_ThongKeViec_NLDNhieuNhatTableAdapter.ClearBeforeFill = true;
            // 
            // dtP_Nam
            // 
            this.dtP_Nam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtP_Nam.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtP_Nam.Location = new System.Drawing.Point(149, 21);
            this.dtP_Nam.Name = "dtP_Nam";
            this.dtP_Nam.Size = new System.Drawing.Size(118, 26);
            this.dtP_Nam.TabIndex = 1;
            this.dtP_Nam.ValueChanged += new System.EventHandler(this.dtP_Nam_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn năm:";
            // 
            // UC_XuHuongCongViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtP_Nam);
            this.Controls.Add(this.chart);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UC_XuHuongCongViec";
            this.Size = new System.Drawing.Size(1030, 531);
            this.Load += new System.EventHandler(this.UC_XuHuongCongViec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sVThongKeViecNLDNhieuNhatBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hOTROTIMVIECDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.BindingSource sVThongKeViecNLDNhieuNhatBindingSource;
        private HOTROTIMVIECDataSet hOTROTIMVIECDataSet;
        private HOTROTIMVIECDataSetTableAdapters.SV_ThongKeViec_NLDNhieuNhatTableAdapter sV_ThongKeViec_NLDNhieuNhatTableAdapter;
        private System.Windows.Forms.DateTimePicker dtP_Nam;
        private System.Windows.Forms.Label label1;
    }
}
