using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_QuanTri
    {
        DAO_QuanTri dao = new DAO_QuanTri();
        public DataRow GetQuanTriInfo(string MAQUANTRI)
        {
            return dao.GetQuanTriInfo(MAQUANTRI);
        }

        public string NextMAQUANTRI()
        {
            string MAQUANTRI = dao.GetLastestMAQUANTRI().Trim();
            int count = MAQUANTRI.Length - 2;
            int ptIndex = Convert.ToInt32(MAQUANTRI.Substring(2)) + 1;
            MAQUANTRI = "QT";
            for (int i = 0; i < count - ptIndex.ToString().Length; i++)
                MAQUANTRI += "0";
            MAQUANTRI += (ptIndex).ToString();
            return MAQUANTRI;
        }
    }
}