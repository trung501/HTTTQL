using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_ChiTietTiem
    {
        DAO_ChiTietTiem dao = new DAO_ChiTietTiem();
        public bool InsertCTT(DTO_ChiTietTiem ctt)
        {
            return dao.InsertCTT(ctt);
        }
    }
}
