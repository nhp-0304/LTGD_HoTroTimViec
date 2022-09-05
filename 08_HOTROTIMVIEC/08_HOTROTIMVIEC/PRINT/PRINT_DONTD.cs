using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _08_HOTROTIMVIEC.BUS;
using Spire.Doc;
using Spire.Doc.Documents;

namespace _08_HOTROTIMVIEC.PRINT
{
    class PRINT_DONTD
    {
        BUS_NGUOILAODONG bUS_NGUOILAODONG;
        BUS_DONVITUYENDUNG bUS_DONVITUYENDUNG;
        BUS_DONVITUYENDUNG_VIECLAM bUS_DONVITUYENDUNG_VIECLAM;
        BUS_VIECLAM bUS_VIECLAM;
        public PRINT_DONTD(DON_TUYENDUNG dtd)
        {
            if (dtd.TrangThai == 2)
            {
                bUS_NGUOILAODONG = new BUS_NGUOILAODONG();
                bUS_DONVITUYENDUNG_VIECLAM = new BUS_DONVITUYENDUNG_VIECLAM();
                bUS_DONVITUYENDUNG = new BUS_DONVITUYENDUNG();
                bUS_VIECLAM = new BUS_VIECLAM();
                ////
                DONVITUYENDUNG_VIECLAM dv_vl = bUS_DONVITUYENDUNG_VIECLAM.GetDVTD_VL_By_Id(dtd);
                DONVITUYENDUNG dv = bUS_DONVITUYENDUNG.GetDVTDByMaDV(dv_vl.MaDV);
                VIECLAM vl = bUS_VIECLAM.GetVIECLAMByMaViec(dv_vl.MaViec);
                NGUOILAODONG nld = bUS_NGUOILAODONG.GetNLD_By_MaNLD(dtd.MaNLD);
                DateTime ngayViet = DateTime.Now;
                /////////////////
                // Tạo đối tượng tài liệu (Document)
                Document doc = new Document();
                // Tạo đối tượng đoạn (Paragraph)
                Paragraph paragraph = doc.AddSection().AddParagraph();
                //Du lieu

                //KHOI DAU
                Spire.Doc.Fields.TextRange title = paragraph.AppendText("\n\nCỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM\n");
                Spire.Doc.Fields.TextRange text = paragraph.AppendText("Độc lập – Tự do – Hạnh phúc\n\n");
                Spire.Doc.Fields.TextRange textXin = paragraph.AppendText("ĐƠN XIN ỨNG TUYỂN VÀO " + dv.TenDV.ToUpper() + "\n");
                text.CharacterFormat.Bold = true;      // kiểu in đậm
                title.CharacterFormat.Bold = true;
                textXin.CharacterFormat.Bold = true;
                textXin.CharacterFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 18);
                title.CharacterFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15);
                text.CharacterFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15);
                //CĂN LỀ
                paragraph.Format.TextAlignment = TextAlignment.Center;              // văn bản canh giữa 
                paragraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;  // đoạn canh giữa
                ///
                Paragraph thgian = doc.Sections[0].AddParagraph();
                Spire.Doc.Fields.TextRange textTG = thgian.AppendText("Vào lúc " + ngayViet.ToShortTimeString() + ", ngày " + ngayViet.Day + " tháng " + ngayViet.Month + " năm " + ngayViet.Year + "\n\n");
                thgian.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Right;
                ///
                Paragraph body = doc.Sections[0].AddParagraph();
                Spire.Doc.Fields.TextRange text_body = body.AppendText("- Kính gửi: Ban giám đốc " + dv.TenDV + "\n" +
                                                                            "- Đồng kính gửi: Phòng Quản lý Nhân sự Công ty \n" +
                                                                            "- Tôi tên là: " + nld.Ten + "\n" +
                                                                            "- Số CMND: " + nld.CMND + "\n" +
                                                                            "- Sinh ngày: " + nld.NgaySinh.ToShortDateString() + "\n" +
                                                                            "- Địa chỉ: " + nld.DiaChi + "\n" +
                                                                            "- Số điện thoại: " + nld.SDT + "\n");
                if (!string.IsNullOrEmpty(nld.BangCap))
                {
                    Spire.Doc.Fields.TextRange text_body_bc = body.AppendText("- Bằng cấp: " + nld.BangCap + "\n\n");
                }
                else
                {
                    Spire.Doc.Fields.TextRange text_body_newline = body.AppendText("\n");
                }
                Spire.Doc.Fields.TextRange text_body_last = body.AppendText("   Qua thông tin tuyển dụng của Quý Công ty đăng tải, tôi được biết Công ty đang có nhu cầu tuyển dụng nhân viên cho vị trí " + vl.TenViec + " . Tôi nhận thấy đây là công việc rất phù hợp với trình độ, kỹ năng, kinh nghiệm mà bản thân tôi đã đúc kết và tích luỹ trong quá trình học tập và làm việc trước đây.\n");
                //Canle BODY
                body.Format.TextAlignment = TextAlignment.Auto;              // văn bản canh giữa 
                body.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;  // đoạn canh giữa

                ///SAVE
                string fmNgayin = String.Format("{0:yyyy_MM_dd_hh_mm_ss}", ngayViet);
                string pathDoc = "D:\\trancongthuc\\HOTROTIMVIEC\\08_HOTROTIMVIEC\\DonTuyenDung\\" + nld.Ten + "_" + vl.TenViec + "_" + fmNgayin + ".doc";
                string pathPdf = "D:\\trancongthuc\\HOTROTIMVIEC\\08_HOTROTIMVIEC\\DonTuyenDung\\" + nld.Ten + "_" + vl.TenViec + "_" + fmNgayin + ".pdf";
                doc.SaveToFile(pathDoc, Spire.Doc.FileFormat.Doc);
                doc.SaveToFile(pathPdf, Spire.Doc.FileFormat.PDF); //-- tạo PDF
                MessageBox.Show("In đơn xin việc thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // đóng đối tượng
                doc.Close();
            }
            else
            {
                if (dtd.TrangThai == 1)
                    MessageBox.Show("Đơn hiện tại đang trong thời gian chờ kiểm duyệt, KHÔNG THỂ IN!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (dtd.TrangThai == 0)
                    MessageBox.Show("Đơn hiện tại đã bị từ chối bởi đơn vị tuyển dụng, KHÔNG THỂ IN!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
