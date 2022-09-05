using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08_HOTROTIMVIEC;

namespace _08_HOTROTIMVIEC.DAO
{
    class DAO_DONVITUYENDUNG_VIECLAM
    {
        HTTVDataContext conn;
        public DAO_DONVITUYENDUNG_VIECLAM()
        {
            conn = new HTTVDataContext();
        }

        public DONVITUYENDUNG_VIECLAM GetDVTD_VL_By_DV_VL(DONVITUYENDUNG dv, VIECLAM vl)
        {
            DONVITUYENDUNG_VIECLAM dv_vl = (from s in conn.DONVITUYENDUNG_VIECLAMs where s.MaDV.Equals(dv.MaDV) && s.MaViec == vl.MaViec select s).First();
            return dv_vl;
        }
        public DONVITUYENDUNG_VIECLAM GetDVTD_VL_By_Id(DON_TUYENDUNG dtd)
        {
            DONVITUYENDUNG_VIECLAM dv_vl = (from s in conn.DONVITUYENDUNG_VIECLAMs where s.Id == dtd.Id select s).First();
            return dv_vl;
        }


        public dynamic getDVTD_ViecLam(string maDV)
        {
            var get = conn.DONVITUYENDUNG_VIECLAMs.Select(s => new
            {
                s.Id,
                s.MaDV,
                s.MaViec,
                s.QuyMo,
                s.TGBatDau,
                s.TGKetThuc
            }).Where(s => s.MaDV == maDV).ToList();
            return get;
        }

        public dynamic getDVTD_ViecLam(string maDV, int maViec)
        {
            var get = conn.DONVITUYENDUNG_VIECLAMs.Select(s => new
            {
                s.Id,
                s.MaDV,
                s.MaViec,
                s.QuyMo,
                s.TGBatDau,
                s.TGKetThuc
            }).Where(s => s.MaDV == maDV && s.MaViec == maViec).ToList();
            return get;
        }

        public dynamic getDVTD_ViecLam_Cho(string maDV)
        {
            var get = conn.DONVITUYENDUNG_VIECLAMs.Select(s => new
            {
                s.Id,
                s.MaDV,
                s.MaViec,
                s.QuyMo,
                s.TGBatDau,
                s.TGKetThuc
            }).Where(s => s.MaDV == maDV && s.QuyMo > 0 && s.TGKetThuc.Value.Date >= DateTime.Now.Date).ToList();
            return get;
        }

        public dynamic getDVTD_ViecLam_DuSL(string maDV)
        {
            var get = conn.DONVITUYENDUNG_VIECLAMs.Select(s => new
            {
                s.Id,
                s.MaDV,
                s.MaViec,
                s.QuyMo,
                s.TGBatDau,
                s.TGKetThuc
            }).Where(s => s.MaDV == maDV && s.QuyMo == 0).ToList();
            return get;
        }

        public dynamic getDVTD_ViecLam_HetHan(string maDV)
        {
            var get = conn.DONVITUYENDUNG_VIECLAMs.Select(s => new
            {
                s.Id,
                s.MaDV,
                s.MaViec,
                s.QuyMo,
                s.TGBatDau,
                s.TGKetThuc
            }).Where(s => s.MaDV == maDV && s.TGKetThuc.Value.Date < DateTime.Now.Date).ToList();
            return get;
        }

        public dynamic getDVTD_ViecLamTim(string maDV, DateTime tuNgay, DateTime denNgay)
        {
            var get = conn.DONVITUYENDUNG_VIECLAMs.Select(s => new
            {
                s.Id,
                s.MaDV,
                s.MaViec,
                s.QuyMo,
                s.TGBatDau,
                s.TGKetThuc
            }).Where(s => s.MaDV == maDV && (s.TGBatDau.Value.Date >= tuNgay.Date && s.TGKetThuc.Value.Date <= denNgay.Date)).ToList();
            return get;
        }

        public dynamic getDVTD_ViecLam_ChoTim(string maDV, DateTime tuNgay, DateTime denNgay)
        {
            var get = conn.DONVITUYENDUNG_VIECLAMs.Select(s => new
            {
                s.Id,
                s.MaDV,
                s.MaViec,
                s.QuyMo,
                s.TGBatDau,
                s.TGKetThuc
            }).Where(s => s.MaDV == maDV && s.QuyMo > 0 && s.TGKetThuc.Value.Date >= DateTime.Now.Date && (s.TGBatDau.Value.Date >= tuNgay.Date && s.TGKetThuc.Value.Date <= denNgay.Date)).ToList();
            return get;
        }

        public dynamic getDVTD_ViecLam_DuSLTim(string maDV, DateTime tuNgay, DateTime denNgay)
        {
            var get = conn.DONVITUYENDUNG_VIECLAMs.Select(s => new
            {
                s.Id,
                s.MaDV,
                s.MaViec,
                s.QuyMo,
                s.TGBatDau,
                s.TGKetThuc
            }).Where(s => s.MaDV == maDV && s.QuyMo == 0 && (s.TGBatDau.Value.Date >= tuNgay.Date && s.TGKetThuc.Value.Date <= denNgay.Date)).ToList();
            return get;
        }

        public dynamic getDVTD_ViecLam_HetHanTim(string maDV, DateTime tuNgay, DateTime denNgay)
        {
            var get = conn.DONVITUYENDUNG_VIECLAMs.Select(s => new
            {
                s.Id,
                s.MaDV,
                s.MaViec,
                s.QuyMo,
                s.TGBatDau,
                s.TGKetThuc
            }).Where(s => s.MaDV == maDV && s.TGKetThuc.Value.Date < DateTime.Now.Date && (s.TGBatDau.Value.Date >= tuNgay.Date && s.TGKetThuc.Value.Date <= denNgay.Date)).ToList();
            return get;
        }

        public int getID_DVTD_HT()
        {
            try
            {
                return conn.DONVITUYENDUNG_VIECLAMs.Select(s => s.Id).Max();
            }
            catch
            {
                return 0;
            }
        }

        public void themMauTuyenDung(int ID, string maDV, int maViec, int quyMo, DateTime TGBD, DateTime TGKT)
        {
            conn.SP_ThemMauTuyenDung(ID, maDV, maViec, quyMo, TGBD, TGKT);
        }

        public void suaMauTuyenDung(int ID, string maDV, int maViec, int quyMo, DateTime TGBD, DateTime TGKT)
        {
            conn.SP_SuaMauTuyenDung(ID, maDV, maViec, quyMo, TGBD, TGKT);
        }

        public void xoaMauTuyenDung(int ID)
        {
            conn.SP_XoaMauTuyenDung(ID);
        }

        public bool kTraMaViecMTD(string maDV, int maViec)
        {
            var exist = (from s in conn.DONVITUYENDUNG_VIECLAMs where s.MaDV == maDV && s.MaViec == maViec select s).Count();
            if (exist > 0)
                return true;
            return false;
        }

        public bool kTraDuQuyMo(int ID)
        {
            var exist = (from s in conn.DONVITUYENDUNG_VIECLAMs where s.Id == ID && s.QuyMo == 0 select s).Count();
            if (exist > 0)
                return true;
            return false;
        }

        public void capNhatQuyMo(int ID)
        {
            conn.SP_CapNhatQuyMo(ID);
        }

        public bool kTraCoMTD(int maViec)
        {
            var exist = (from s in conn.DONVITUYENDUNG_VIECLAMs where s.MaViec == maViec select s).Count();
            if (exist > 0)
                return true;
            return false;
        }
    }
}
