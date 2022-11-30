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
    public class BUS_GiamHo
    {
        DAO_GiamHo dao = new DAO_GiamHo();

        public DataTable GetAllNGH()
        {
            return dao.GetAllNGH();
        }

        public string NextMaGH()
        {
            string MAGH = dao.GetLastestMaGH().Trim();
            int count = MAGH.Length - 2;
            int ghIndex = Convert.ToInt32(MAGH.Substring(2)) + 1;
            MAGH = "GH";
            for (int i = 0; i < count - ghIndex.ToString().Length; i++)
                MAGH += "0";
            MAGH += (ghIndex).ToString();
            return MAGH;
        }

        public bool InsertNGH(DTO_GiamHo gh)
        {
            return dao.InsertNGH(gh);
        }

        public bool IsMaGHExists(string maGH)
        {
            return dao.IsMaGHExists(maGH);
        }

        public bool AddMaGHtoKH(string maGH)
        {
            return dao.AddMaGHtoKH(maGH);
        }
    }
}
