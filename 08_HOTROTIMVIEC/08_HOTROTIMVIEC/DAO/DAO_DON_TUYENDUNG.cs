using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08_HOTROTIMVIEC;

namespace _08_HOTROTIMVIEC.DAO
{
    class DAO_DON_TUYENDUNG
    {
        HTTVDataContext conn;
        public DAO_DON_TUYENDUNG()
        {
            conn = new HTTVDataContext();
        }

        public int? SV_addDON_TUYENDUNG(int maNLD, int Id, DateTime ngayDK)
        {
            int? check = 0;
            conn.SV_addDON_TUYENDUNG(maNLD, Id, ngayDK.Date, ref check);
            return check;
        }
        public DON_TUYENDUNG getDon_TuyenDung_ByMaNLD_Id(int maNLD, int id)
        {
            DON_TUYENDUNG don = (from s in conn.DON_TUYENDUNGs where s.MaNLD == maNLD && s.Id == id select s).First();
            return don;
        }
        public void DeleteDon_TuyenDung_ByMaNLD_Id(int maNLD, int id)
        {
            conn.SV_Delete_Don_TuyenDung(maNLD,id);
        }
        public int getSLDonDuyet(int ID)
        {
            var get = (from s in conn.DON_TUYENDUNGs where s.Id == ID && s.TrangThai == 2 select s).Count();
            return get;
        }

        public bool kTraDonTonTai(int ID)
        {
            var exist = (from s in conn.DON_TUYENDUNGs where s.Id == ID select s).Count();
            if (exist > 0)
                return true;
            return false;
        }

        public List<DON_TUYENDUNG> getDTDTheoDV(int ID)
        {
            return (from s in conn.DON_TUYENDUNGs where s.Id == ID orderby s.TrangThai descending select s).ToList();
        }

        public DON_TUYENDUNG getDTDTheoDV(int maNLD, int ID)
        {
            var get = new DON_TUYENDUNG();
            try
            {
                get = (from s in conn.DON_TUYENDUNGs where s.MaNLD == maNLD && s.Id == ID select s).FirstOrDefault();
            }
            catch (SqlException ex) { };
            return get;
        }

        public DON_TUYENDUNG getDTDTheoNLD_DV(string tenNLD, int ID)
        {
            var get = new DON_TUYENDUNG();
            try
            {
                var getNLD = (from s in conn.NGUOILAODONGs where s.Ten.Contains(tenNLD) select s).FirstOrDefault();
                int maNLD = getNLD.MaNLD;
                get = (from s in conn.DON_TUYENDUNGs where s.MaNLD == maNLD && s.Id == ID select s).FirstOrDefault();
            }
            catch (SqlException ex) { };
            return get;
        }


        public void setDonDuyet(int maNLD)
        {
            conn.SP_SetDonDuyet(maNLD);
        }

        public void setDonTuChoi(int maNLD)
        {
            conn.SP_SetDonTuChoi(maNLD);
        }

        public DON_TUYENDUNG getTrangThaiDon(int ID, int maNLD)
        {
            return (from s in conn.DON_TUYENDUNGs where s.Id == ID && s.MaNLD == maNLD select s).FirstOrDefault();
        }

        public void xoaDTDDuyet(int ID)
        {
            conn.SP_XoaDTDDuyet(ID);
        }

        public void xoaDTDTuChoi(int ID)
        {
            conn.SP_XoaDTDTuChoi(ID);
        }
    }
}
