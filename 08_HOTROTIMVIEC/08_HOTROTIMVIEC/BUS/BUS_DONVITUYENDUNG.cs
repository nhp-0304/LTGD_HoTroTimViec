﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08_HOTROTIMVIEC;
using _08_HOTROTIMVIEC.DAO;

namespace _08_HOTROTIMVIEC.BUS
{
    class BUS_DONVITUYENDUNG
    {
        DAO_DONVITUYENDUNG dAO_DONVITUYENDUNG;
        public BUS_DONVITUYENDUNG()
        {
            dAO_DONVITUYENDUNG = new DAO_DONVITUYENDUNG();
        }
        public DONVITUYENDUNG getDVTDFromTK(DONVITUYENDUNG_TAIKHOAN acc)
        {
            return dAO_DONVITUYENDUNG.getDVTDFromTK(acc);
        }
        public DONVITUYENDUNG GetDVTDByMaDV(string maDV)
        {
            return dAO_DONVITUYENDUNG.GetDVTDByMaDV(maDV);
        }
        public int Check_MaDV_DVTD(string maDV)
        {
            return dAO_DONVITUYENDUNG.Check_MaDV_DVTD(maDV);
        }
        public int Check_SDT_DVTD(string sdt)
        {
            return dAO_DONVITUYENDUNG.Check_SDT_DVTD(sdt);
        }
        public DONVITUYENDUNG getDVTD_BangMaDV(string maDV)
        {
            return dAO_DONVITUYENDUNG.getDVTD_BangMaDV(maDV);
        }

        public void suaDVTD(string maDV, string diaChi, string sdt)
        {
            dAO_DONVITUYENDUNG.suaDVTD(maDV, diaChi, sdt);
        }
    }
}
