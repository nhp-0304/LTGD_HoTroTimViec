using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _08_HOTROTIMVIEC.GUI._NGUOILAODONG
{
    public partial class UC_XuHuongCongViec : UserControl
    {
        public UC_XuHuongCongViec()
        {
            InitializeComponent();
        }
        private void UC_XuHuongCongViec_Load(object sender, EventArgs e)
        {
            loadDtp_Nam();
            loadChart();
        }

        private void dtP_Nam_ValueChanged(object sender, EventArgs e)
        {
            loadChart();
        }
        public void loadChart()
        {
            chart.Titles.Clear();
            chart.DataSource = null;
            chart.DataSource = hOTROTIMVIECDataSet.SV_ThongKeViec_NLDNhieuNhat;
            this.sV_ThongKeViec_NLDNhieuNhatTableAdapter.Fill(this.hOTROTIMVIECDataSet.SV_ThongKeViec_NLDNhieuNhat, dtP_Nam.Value.Year.ToString());
            chart.Titles.Add(new Title("THỐNG KÊ LƯỢNG NGƯỜI THEO MỖI VIỆC " + dtP_Nam.Value.Year.ToString(),Docking.Top,new Font("Verdana", 15f, FontStyle.Bold),Color.Red));
        }
        public void loadDtp_Nam()
        {
            dtP_Nam.Format = DateTimePickerFormat.Custom;
            dtP_Nam.CustomFormat = "yyyy";
            dtP_Nam.ShowUpDown = true;
        }
    }
}
