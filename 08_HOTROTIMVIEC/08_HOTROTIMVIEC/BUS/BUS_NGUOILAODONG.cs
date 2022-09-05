using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08_HOTROTIMVIEC;
using _08_HOTROTIMVIEC.DAO;

namespace _08_HOTROTIMVIEC.BUS
{
    class BUS_NGUOILAODONG
    {
        DAO_NGUOILAODONG dAO_NGUOILAODONG;
        public BUS_NGUOILAODONG()
        {
            dAO_NGUOILAODONG = new DAO_NGUOILAODONG();
        }
        public NGUOILAODONG getNLDFromTK(NGUOILAODONG_TAIKHOAN acc)
        {
            return dAO_NGUOILAODONG.getNLDFromTK(acc);
        }
        public void Update_ThongTin_NLD(int maNLD, string ten, string gt, DateTime ngaysinh, string ddiem, string bangcap)
        {
            dAO_NGUOILAODONG.Update_ThongTin_NLD(maNLD, ten, gt, ngaysinh, ddiem, bangcap);
        }
        public int getMaNNLD_HT()
        {
            return dAO_NGUOILAODONG.getMaNNLD_HT();
        }
        public int Check_CMND_NLD(string cmnd)
        {
            return dAO_NGUOILAODONG.Check_CMND_NLD(cmnd);
        }
        public int Check_SDT_NLD(string sdt)
        {
            return dAO_NGUOILAODONG.Check_SDT_NLD(sdt);
        }
        public NGUOILAODONG GetNLD_By_MaNLD(int maNLD)
        {
            return dAO_NGUOILAODONG.GetNLD_By_MaNLD(maNLD);
        }
        public NGUOILAODONG getNLD(int maNLD)
        {
            return dAO_NGUOILAODONG.getNLD(maNLD);
        }

        public bool kTraNLDTonTai(int maNLD)
        {
            return dAO_NGUOILAODONG.kTraNLDTonTai(maNLD);
        }

        public NGUOILAODONG getNLD(int maNLD, int ID)
        {
            return dAO_NGUOILAODONG.getNLD(maNLD, ID);
        }

        public bool kTraNLDTonTai(string tenNLD)
        {
            return dAO_NGUOILAODONG.kTraNLDTonTai(tenNLD);
        }

        public NGUOILAODONG getNLD(int maNLD, string tenNLD, int ID)
        {
            return dAO_NGUOILAODONG.getNLD(maNLD, tenNLD, ID);
        }
        public NGUOILAODONG getNLD_BangMaNLD(int? maNLD)
        {
            return dAO_NGUOILAODONG.getNLD_BangMaNLD(maNLD);
        }
    }
}
