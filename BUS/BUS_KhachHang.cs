using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_KhachHang
    {
        DAO_KhachHang dao = new DAO_KhachHang();
        public DataTable getAllKH()
        {
            return dao.GetAllKH();
        }

        public bool IsMaKHExists(string maKH)
        {
            return dao.IsMaKHExists(maKH);
        }

        public string NextMaKH()
        {
            string MAKH = dao.GetLastestMaKH().Trim();
            int count = MAKH.Length - 2;
            int khIndex = Convert.ToInt32(MAKH.Substring(2)) + 1;
            MAKH = "KH";
            for (int i = 0; i < count - khIndex.ToString().Length; i++)
                MAKH += "0";
            MAKH += (khIndex).ToString();
            return MAKH;
        }

        public bool InsertKHWithoutNGH(DTO_KhachHang kh)
        {
            return dao.InsertKHWithoutNGH(kh);
        }
    }
}
