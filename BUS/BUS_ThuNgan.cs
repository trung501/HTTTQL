using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_ThuNgan
    {
        DAO_ThuNgan dao = new DAO_ThuNgan();
        public string getTenThuNgan(string maTN)
        {
            return dao.getTenThuNgan(maTN);
        }

        public DataRow GetThuNganInfo(string MATHUNGAN)
        {
            return dao.GetThuNganInfo(MATHUNGAN);
        }

        public string NextMATHUNGAN()
        {
            string MATHUNGAN = dao.GetLastestMATHUNGAN().Trim();
            int count = MATHUNGAN.Length - 2;
            int ptIndex = Convert.ToInt32(MATHUNGAN.Substring(2)) + 1;
            MATHUNGAN = "TN";
            for (int i = 0; i < count - ptIndex.ToString().Length; i++)
                MATHUNGAN += "0";
            MATHUNGAN += (ptIndex).ToString();
            return MATHUNGAN;
        }

    }
}
