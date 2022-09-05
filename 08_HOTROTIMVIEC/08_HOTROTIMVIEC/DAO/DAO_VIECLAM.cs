using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _08_HOTROTIMVIEC;

namespace _08_HOTROTIMVIEC.DAO
{
    class DAO_VIECLAM
    {
        HTTVDataContext conn;
        public DAO_VIECLAM()
        {
            conn = new HTTVDataContext();
        }
        public dynamic getListFromTenViec(string tenViec)
        {
            var ds = conn.SV_Timkiem_TenViec(tenViec).Select(s => new {
                s.MaViec,
                s.TenViec,
                s.MoTa,
                s.MucLuong
            }).ToList();
            return ds;
        }
        public dynamic getListFromMucLuong(string mucluong)
        {
            try
            {
                var ds = conn.SV_Timkiem_MucLuong(decimal.Parse(mucluong)).Select(s => new {
                    s.MaViec,
                    s.TenViec,
                    s.MoTa,
                    s.MucLuong
                }).ToList();
                return ds;
            }
            catch
            {
                return getViecLam();
            }
            
        }
        public dynamic getViecLam()
        {
            var ds = conn.VIECLAMs.Select(s => new {
                s.MaViec,
                s.TenViec,
                s.MoTa,
                s.MucLuong
            }).ToList();
            return ds;
        }

        public VIECLAM GetVIECLAMByMaViec(int maViec)
        {
            VIECLAM vl = (from s in conn.VIECLAMs where s.MaViec == maViec select s).First();
            return vl;
        }
        public VIECLAM GetVIECLAMByTenViec(string tenViec)
        {
            VIECLAM vl = (from s in conn.VIECLAMs where s.TenViec.Equals(tenViec) select s).First();
            return vl;
        }

        public VIECLAM getViecLam1(int maViec)
        {
            var get = (from s in conn.VIECLAMs where s.MaViec == maViec select s).First();
            return get;
        }

        public dynamic getViecLam(int maViec)
        {
            var get = conn.VIECLAMs.Select(s => new
            {
                s.MaViec,
                s.TenViec,
                s.MoTa,
                s.MucLuong,
            }).Where(s => s.MaViec == maViec).ToList();
            return get;
        }

        public dynamic getViecLam(string tenViec)
        {
            var get = conn.VIECLAMs.Select(s => new
            {
                s.MaViec,
                s.TenViec,
                s.MoTa,
                s.MucLuong,
            }).Where(s => s.TenViec.Contains(tenViec)).ToList();
            return get;
        }

        public bool kTraMaViec(int maViec)
        {
            var exist = (from s in conn.VIECLAMs where s.MaViec == maViec select s).Count();
            if (exist > 0)
                return true;
            return false;
        }
        public void themMauViecLam(int maViec, string tenViec, string moTa, int mucLuong)
        {
            conn.SP_ThemMauViecLam(maViec, tenViec, moTa, mucLuong);
        }

        public void suaMauViecLam(int maViec, string tenViec, string moTa, int mucLuong)
        {
            conn.SP_SuaMauViecLam(maViec, tenViec, moTa, mucLuong);
        }

        public void xoaMauViecLam(int maViec)
        {
            conn.SP_XoaMauViecLam(maViec);
        }

        public int getMaViecHT()
        {
            try
            {
                return conn.VIECLAMs.Select(s => s.MaViec).Max();
            }
            catch
            {
                return 0;
            }
        }
    }
}
