using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_LichSu
    {
        DAO_LichSu dao = new DAO_LichSu();
        public DataTable getAllLichSu(string maKH)
        {
            return dao.getAllLichSu(maKH);
        }
    }
}
