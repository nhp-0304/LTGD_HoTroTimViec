using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08_HOTROTIMVIEC;

namespace _08_HOTROTIMVIEC.DAO
{
    class DAO_DONVITUYENDUNG
    {
        HTTVDataContext conn;
        public DAO_DONVITUYENDUNG()
        {
            conn = new HTTVDataContext();
        }
        public DONVITUYENDUNG getDVTDFromTK(DONVITUYENDUNG_TAIKHOAN acc)
        {
            DONVITUYENDUNG dvtd = conn.DONVITUYENDUNGs.FirstOrDefault(s => s.MaDV == acc.MaDV_TaiKhoan);
            return dvtd;
        }
        public DONVITUYENDUNG GetDVTDByMaDV(string maDV)
        {
            DONVITUYENDUNG dv = (from s in conn.DONVITUYENDUNGs where s.MaDV.Equals(maDV) select s).First();
            return dv;
        }
        public int Check_MaDV_DVTD(string maDV)
        {
            int sl = 0;
            sl = (from s in conn.DONVITUYENDUNGs where s.MaDV.Equals(maDV) select s).Count();
            return sl;
        }
        public int Check_SDT_DVTD(string sdt)
        {
            int sl = 0;
            sl = (from s in conn.DONVITUYENDUNGs where s.SDT.Equals(sdt) select s).Count();
            return sl;
        }
        public DONVITUYENDUNG getDVTD_BangMaDV(string maDV)
        {
            return (from s in conn.DONVITUYENDUNGs where s.MaDV == maDV select s).First();
        }

        public void suaDVTD(string maDV, string diaChi, string sdt)
        {
            conn.SP_SuaDonViTuyenDung(maDV, diaChi, sdt);
        }
    }
}
