using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_QuanKho
    {
        DAO_QuanKho dao = new DAO_QuanKho();
        public DataRow GetQuanKhoInfo(string MAQUANKHO)
        {
            return dao.GetQuanKhoInfo(MAQUANKHO);
        }

        public string NextMAQUANKHO()
        {
            string MAQUANKHO = dao.GetLastestMAQUANKHO().Trim();
            int count = MAQUANKHO.Length - 2;
            int ptIndex = Convert.ToInt32(MAQUANKHO.Substring(2)) + 1;
            MAQUANKHO = "QK";
            for (int i = 0; i < count - ptIndex.ToString().Length; i++)
                MAQUANKHO += "0";
            MAQUANKHO += (ptIndex).ToString();
            return MAQUANKHO;
        }
    }
}