using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08_HOTROTIMVIEC;
using _08_HOTROTIMVIEC.DAO;

namespace _08_HOTROTIMVIEC.BUS
{
    class BUS_DONVITUYENDUNG_VIECLAM
    {
        DAO_DONVITUYENDUNG_VIECLAM dAO_DONVITUYENDUNG_VIECLAM;
        public BUS_DONVITUYENDUNG_VIECLAM()
        {
            dAO_DONVITUYENDUNG_VIECLAM = new DAO_DONVITUYENDUNG_VIECLAM();
        }
        public DONVITUYENDUNG_VIECLAM GetDVTD_VL_By_DV_VL(DONVITUYENDUNG dv, VIECLAM vl)
        {
            return dAO_DONVITUYENDUNG_VIECLAM.GetDVTD_VL_By_DV_VL(dv, vl);
        }
        public DONVITUYENDUNG_VIECLAM GetDVTD_VL_By_Id(DON_TUYENDUNG dtd)
        {
            return dAO_DONVITUYENDUNG_VIECLAM.GetDVTD_VL_By_Id(dtd);
        }
        public dynamic getDVTD_ViecLam(string maDV)
        {
            return dAO_DONVITUYENDUNG_VIECLAM.getDVTD_ViecLam(maDV);
        }

        public dynamic getDVTD_ViecLam(string maDV, int maViec)
        {
            return dAO_DONVITUYENDUNG_VIECLAM.getDVTD_ViecLam(maDV, maViec);
        }

        public dynamic getDVTD_ViecLam_Cho(string maDV)
        {
            return dAO_DONVITUYENDUNG_VIECLAM.getDVTD_ViecLam_Cho(maDV);
        }

        public dynamic getDVTD_ViecLam_DuSL(string maDV)
        {
            return dAO_DONVITUYENDUNG_VIECLAM.getDVTD_ViecLam_DuSL(maDV);
        }

        public dynamic getDVTD_ViecLam_HetHan(string maDV)
        {
            return dAO_DONVITUYENDUNG_VIECLAM.getDVTD_ViecLam_HetHan(maDV);
        }

        public dynamic getDVTD_ViecLamTim(string maDV, DateTime tuNgay, DateTime denNgay)
        {
            return dAO_DONVITUYENDUNG_VIECLAM.getDVTD_ViecLamTim(maDV, tuNgay, denNgay);
        }

        public dynamic getDVTD_ViecLam_ChoTim(string maDV, DateTime tuNgay, DateTime denNgay)
        {
            return dAO_DONVITUYENDUNG_VIECLAM.getDVTD_ViecLam_ChoTim(maDV, tuNgay, denNgay);
        }

        public dynamic getDVTD_ViecLam_DuSLTim(string maDV, DateTime tuNgay, DateTime denNgay)
        {
            return dAO_DONVITUYENDUNG_VIECLAM.getDVTD_ViecLam_DuSLTim(maDV, tuNgay, denNgay);
        }

        public dynamic getDVTD_ViecLam_HetHanTim(string maDV, DateTime tuNgay, DateTime denNgay)
        {
            return dAO_DONVITUYENDUNG_VIECLAM.getDVTD_ViecLam_HetHanTim(maDV, tuNgay, denNgay);
        }

        public int getID_DVTD_HT()
        {
            return dAO_DONVITUYENDUNG_VIECLAM.getID_DVTD_HT();
        }

        public void themMauTuyenDung(int ID, string maDV, int maViec, int quyMo, DateTime TGBD, DateTime TGKT)
        {
            dAO_DONVITUYENDUNG_VIECLAM.themMauTuyenDung(ID, maDV, maViec, quyMo, TGBD, TGKT);
        }

        public void suaMauTuyenDung(int ID, string maDV, int maViec, int quyMo, DateTime TGBD, DateTime TGKT)
        {
            dAO_DONVITUYENDUNG_VIECLAM.suaMauTuyenDung(ID, maDV, maViec, quyMo, TGBD, TGKT);
        }

        public void xoaMauTuyenDung(int ID)
        {
            dAO_DONVITUYENDUNG_VIECLAM.xoaMauTuyenDung(ID);
        }

        public bool kTraMaViecMTD(string maDV, int maViec)
        {
            return dAO_DONVITUYENDUNG_VIECLAM.kTraMaViecMTD(maDV, maViec);
        }

        public bool kTraDuQuyMo(int ID)
        {
            return dAO_DONVITUYENDUNG_VIECLAM.kTraDuQuyMo(ID);
        }

        public void capNhatQuyMo(int ID)
        {
            dAO_DONVITUYENDUNG_VIECLAM.capNhatQuyMo(ID);
        }
        public bool kTraCoMTD(int maViec)
        {
            return dAO_DONVITUYENDUNG_VIECLAM.kTraCoMTD(maViec);
        }
    }
}
