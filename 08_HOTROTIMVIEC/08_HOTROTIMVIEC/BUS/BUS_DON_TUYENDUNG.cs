using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08_HOTROTIMVIEC;
using _08_HOTROTIMVIEC.DAO;

namespace _08_HOTROTIMVIEC.BUS
{
    class BUS_DON_TUYENDUNG
    {
        DAO_DON_TUYENDUNG dAO_DON_TUYENDUNG;
        public BUS_DON_TUYENDUNG()
        {
            dAO_DON_TUYENDUNG = new DAO_DON_TUYENDUNG();
        }
        public int? SV_addDON_TUYENDUNG(int maNLD, int Id, DateTime ngayDK)
        {
            return dAO_DON_TUYENDUNG.SV_addDON_TUYENDUNG(maNLD, Id, ngayDK);
        }
        public DON_TUYENDUNG getDon_TuyenDung_ByMaNLD_Id(int maNLD, int id)
        {
            return dAO_DON_TUYENDUNG.getDon_TuyenDung_ByMaNLD_Id(maNLD, id);
        }
        public void DeleteDon_TuyenDung_ByMaNLD_Id(int maNLD, int id)
        {
            dAO_DON_TUYENDUNG.DeleteDon_TuyenDung_ByMaNLD_Id(maNLD, id);
        }
        public int getSLDonDuyet(int ID)
        {
            return dAO_DON_TUYENDUNG.getSLDonDuyet(ID);
        }

        public bool kTraDonTonTai(int ID)
        {
            return dAO_DON_TUYENDUNG.kTraDonTonTai(ID);
        }

        public List<DON_TUYENDUNG> getDTDTheoDV(int ID)
        {
            return dAO_DON_TUYENDUNG.getDTDTheoDV(ID);
        }

        public DON_TUYENDUNG getDTDTheoDV(int maNLD, int ID)
        {
            return dAO_DON_TUYENDUNG.getDTDTheoDV(maNLD, ID);
        }

        public DON_TUYENDUNG getDTDTheoNLD_DV(string tenNLD, int ID)
        {
            return dAO_DON_TUYENDUNG.getDTDTheoNLD_DV(tenNLD, ID);
        }

        public void setDonDuyet(int maNLD)
        {
            dAO_DON_TUYENDUNG.setDonDuyet(maNLD);
        }

        public void setDonTuChoi(int maNLD)
        {
            dAO_DON_TUYENDUNG.setDonTuChoi(maNLD);
        }

        public DON_TUYENDUNG getTrangThaiDon(int ID, int maNLD)
        {
            return dAO_DON_TUYENDUNG.getTrangThaiDon(ID, maNLD);
        }

        public void xoaDTDDuyet(int ID)
        {
            dAO_DON_TUYENDUNG.xoaDTDDuyet(ID);
        }

        public void xoaDTDTuChoi(int ID)
        {
            dAO_DON_TUYENDUNG.xoaDTDTuChoi(ID);
        }
    }
}
