using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_BacSi
    {
        DAO_BacSi dao = new DAO_BacSi();
        public DataRow GetBacSyInfo(string MABS)
        {
            return dao.GetBacSyInfo(MABS);
        }

        public string NextMABS()
        {
            string MABS = dao.GetLastestMABS().Trim();
            int count = MABS.Length - 2;
            int ptIndex = Convert.ToInt32(MABS.Substring(2)) + 1;
            MABS = "BS";
            for (int i = 0; i < count - ptIndex.ToString().Length; i++)
                MABS += "0";
            MABS += (ptIndex).ToString();
            return MABS;
        }
        public DataTable getAllBacSi()
        {
            return dao.getAllBacSi();
    }
    }
   
}