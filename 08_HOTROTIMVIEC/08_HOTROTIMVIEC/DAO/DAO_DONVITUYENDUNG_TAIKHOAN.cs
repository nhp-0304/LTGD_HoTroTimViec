using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08_HOTROTIMVIEC;

namespace _08_HOTROTIMVIEC.DAO
{
    class DAO_DONVITUYENDUNG_TAIKHOAN
    {
        HTTVDataContext conn;
        public DAO_DONVITUYENDUNG_TAIKHOAN()
        {
            conn = new HTTVDataContext();
        }
        public DONVITUYENDUNG_TAIKHOAN getTaiKhoanByTK_MK(string tk, string mk)
        {
            DONVITUYENDUNG_TAIKHOAN tk_nld = conn.DONVITUYENDUNG_TAIKHOANs.FirstOrDefault(a => a.MaDV_TaiKhoan == tk && a.Matkhau == mk);
            return tk_nld;
        }
        public void DVTD_TK_doiMK(string maDV, string matKhau)
        {
            conn.SP_DVTD_TK_DoiMatKhau(maDV, matKhau);
        }

        public void DVTD_TK_ChoPhepSD(string maDV)
        {
            conn.SP_DVTD_TK_ChoPhepSD(maDV);
        }

        public void DVTD_TK_CamSD(string maDV)
        {
            conn.SP_DVTD_TK_CamSD(maDV);
        }

        public bool kTraMKHT(string maDV, string matKhau)
        {
            var exist = (from s in conn.DONVITUYENDUNG_TAIKHOANs where s.MaDV_TaiKhoan.Equals(maDV) && s.Matkhau.Equals(matKhau) select s).Count();
            if (exist > 0)
                return true;
            return false;
        }
        public dynamic getDVTD_tk()
        {
            var ds = conn.DONVITUYENDUNG_TAIKHOANs.Select(s => new {
                s.MaDV_TaiKhoan,
                s.Vitri
            }).ToList();
            return ds;
        }

        public dynamic getDVTD_tk(string maDV)
        {
            var ds = conn.DONVITUYENDUNG_TAIKHOANs.Select(s => new {
                s.MaDV_TaiKhoan,
                s.Vitri
            }).Where(s => s.MaDV_TaiKhoan.Contains(maDV)).ToList();
            return ds;
        }
    }
}
