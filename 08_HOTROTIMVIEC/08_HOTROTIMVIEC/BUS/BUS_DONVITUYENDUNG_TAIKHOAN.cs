using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08_HOTROTIMVIEC;
using _08_HOTROTIMVIEC.DAO;

namespace _08_HOTROTIMVIEC.BUS
{
    class BUS_DONVITUYENDUNG_TAIKHOAN
    {
        DAO_DONVITUYENDUNG_TAIKHOAN dAO_DONVITUYENDUNG_TAIKHOAN;
        public BUS_DONVITUYENDUNG_TAIKHOAN()
        {
            dAO_DONVITUYENDUNG_TAIKHOAN = new DAO_DONVITUYENDUNG_TAIKHOAN();
        }
        public DONVITUYENDUNG_TAIKHOAN getTaiKhoanByTK_MK(string tk, string mk)
        {
            DONVITUYENDUNG_TAIKHOAN tk_dvtd = dAO_DONVITUYENDUNG_TAIKHOAN.getTaiKhoanByTK_MK(tk, mk);
            return tk_dvtd;
        }
        public void DVTD_TK_doiMK(string maDV, string matKhau)
        {
            dAO_DONVITUYENDUNG_TAIKHOAN.DVTD_TK_doiMK(maDV, matKhau);
        }

        public void DVTD_TK_ChoPhepSD(string maDV)
        {
            dAO_DONVITUYENDUNG_TAIKHOAN.DVTD_TK_ChoPhepSD(maDV);
        }

        public void DVTD_TK_CamSD(string maDV)
        {
            dAO_DONVITUYENDUNG_TAIKHOAN.DVTD_TK_CamSD(maDV);
        }

        public bool kTraMKHT(string maDV, string matKhau)
        {
            return dAO_DONVITUYENDUNG_TAIKHOAN.kTraMKHT(maDV, matKhau);
        }
        public dynamic getDVTD_tk()
        {
            return dAO_DONVITUYENDUNG_TAIKHOAN.getDVTD_tk();
        }

        public dynamic getDVTD_tk(string maDV)
        {
            return dAO_DONVITUYENDUNG_TAIKHOAN.getDVTD_tk(maDV);
        }
    }
}
