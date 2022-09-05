using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08_HOTROTIMVIEC;

namespace _08_HOTROTIMVIEC.DAO
{
    class DAO_NGUOILAODONG
    {
        HTTVDataContext conn;
        public DAO_NGUOILAODONG()
        {
            conn = new HTTVDataContext();
        }
        public NGUOILAODONG getNLDFromTK(NGUOILAODONG_TAIKHOAN acc)
        {
            NGUOILAODONG nld = conn.NGUOILAODONGs.FirstOrDefault(s => s.MaNLD == acc.MaNLD);
            return nld;
        }
        public void Update_ThongTin_NLD(int maNLD,string ten, string gt, DateTime ngaysinh,string ddiem,string bangcap)
        {
            conn.SV_UpdateThongTin_NLD(maNLD,ten,gt,ngaysinh,ddiem,bangcap);
        }
        public int getMaNNLD_HT()
        {
            try
            {
                return conn.NGUOILAODONGs.Select(s => s.MaNLD).Max();
            }
            catch
            {
                int ma = 0;
                return ma;
            }
        }
        public int Check_CMND_NLD(string cmnd)
        {
            int sl = 0;
            sl = (from s in conn.NGUOILAODONGs where s.CMND.Equals(cmnd) select s).Count();
            return sl;
        }
        public int Check_SDT_NLD(string sdt)
        {
            int sl = 0;
            sl = (from s in conn.NGUOILAODONGs where s.SDT.Equals(sdt) select s).Count();
            return sl;
        }
        public NGUOILAODONG GetNLD_By_MaNLD(int maNLD)
        {
            NGUOILAODONG nld = (from s in conn.NGUOILAODONGs where s.MaNLD == maNLD select s).First();
            return nld;
        }
        public NGUOILAODONG getNLD(int maNLD)
        {
            return (from s in conn.NGUOILAODONGs where s.MaNLD == maNLD select s).FirstOrDefault();
        }

        public bool kTraNLDTonTai(int maNLD)
        {
            var exist = (from s in conn.NGUOILAODONGs where s.MaNLD == maNLD select s).Count();
            if (exist > 0)
                return true;
            return false;
        }

        public NGUOILAODONG getNLD(int maNLD, int ID)
        {
            DAO_DON_TUYENDUNG dAO_DON_TUYENDUNG = new DAO_DON_TUYENDUNG();
            var get = new NGUOILAODONG();
            try
            {
                var getDTD = (from s in conn.DON_TUYENDUNGs where s.MaNLD == maNLD && s.Id == ID select s).FirstOrDefault();
                get = (from s in conn.NGUOILAODONGs where s.MaNLD == getDTD.MaNLD select s).FirstOrDefault();
            }
            catch (SqlException ex) { };
            return get;
        }

        public bool kTraNLDTonTai(string tenNLD)
        {
            var exist = (from s in conn.NGUOILAODONGs where s.Ten.Contains(tenNLD) select s).Count();
            if (exist > 0)
                return true;
            return false;
        }

        public NGUOILAODONG getNLD(int maNLD, string tenNLD, int ID)
        {
            DAO_DON_TUYENDUNG dAO_DON_TUYENDUNG = new DAO_DON_TUYENDUNG();
            var get = new NGUOILAODONG();
            try
            {
                get = (from s in conn.NGUOILAODONGs where s.Ten.Contains(tenNLD) && s.MaNLD == maNLD select s).FirstOrDefault();
            }
            catch (SqlException ex) { };
            return get;
        }
        public NGUOILAODONG getNLD_BangMaNLD(int? maNLD)
        {
            return (from s in conn.NGUOILAODONGs where s.MaNLD == maNLD select s).First();
        }
    }
}
