using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08_HOTROTIMVIEC;
using _08_HOTROTIMVIEC.DAO;

namespace _08_HOTROTIMVIEC.BUS
{
    class BUS_VIECLAM
    {
        DAO_VIECLAM dAO_VIECLAM;
        public BUS_VIECLAM()
        {
            dAO_VIECLAM = new DAO_VIECLAM();
        }
        public dynamic getListFromTenViec(string tenViec)
        {
            return dAO_VIECLAM.getListFromTenViec(tenViec);
        }

        public dynamic getListFromMucLuong(string mucluong)
        {
            return dAO_VIECLAM.getListFromMucLuong(mucluong);
        }
        public dynamic getViecLam()
        {
            return dAO_VIECLAM.getViecLam();
        }
        public VIECLAM GetVIECLAMByMaViec(int maViec)
        {
            return dAO_VIECLAM.GetVIECLAMByMaViec(maViec);
        }
        public VIECLAM GetVIECLAMByTenViec(string tenViec)
        {
            return dAO_VIECLAM.GetVIECLAMByTenViec(tenViec);
        }
        public VIECLAM getViecLam1(int maViec)
        {
            return dAO_VIECLAM.getViecLam1(maViec);
        }

        public dynamic getViecLam(int maViec)
        {
            return dAO_VIECLAM.getViecLam(maViec);
        }

        public dynamic getViecLam(string tenViec)
        {
            return dAO_VIECLAM.getViecLam(tenViec);
        }

        public bool kTraMaViec(int maViec)
        {
            return dAO_VIECLAM.kTraMaViec(maViec);
        }
        public void themMauViecLam(int maViec, string tenViec, string moTa, int mucLuong)
        {
            dAO_VIECLAM.themMauViecLam(maViec, tenViec, moTa, mucLuong);
        }

        public void suaMauViecLam(int maViec, string tenViec, string moTa, int mucLuong)
        {
            dAO_VIECLAM.suaMauViecLam(maViec, tenViec, moTa, mucLuong);
        }

        public void xoaMauViecLam(int maViec)
        {
            dAO_VIECLAM.xoaMauViecLam(maViec);
        }

        public int getMaViecHT()
        {
            return dAO_VIECLAM.getMaViecHT();
        }
    }
}
