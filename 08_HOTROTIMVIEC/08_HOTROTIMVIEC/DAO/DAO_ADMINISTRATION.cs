﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08_HOTROTIMVIEC;

namespace _08_HOTROTIMVIEC.DAO
{
    class DAO_ADMINISTRATION
    {
        HTTVDataContext conn;
        public DAO_ADMINISTRATION()
        {
            conn = new HTTVDataContext();
        }
        public ADMINISTRATION getAdminFromTK_MK(string tk, string mk)
        {
            ADMINISTRATION admin = conn.ADMINISTRATIONs.FirstOrDefault(s => s.Taikhoan == tk && s.Matkhau == mk);
            return admin;
        }
    }
}
