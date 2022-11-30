using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class BUS_Login
    {
        DBProvider dp = new DBProvider();

        public bool Login(string user, string pass)
        {
            if (dp.Login(user, pass))
            {
                return true;
            }
            return false;
        }
        public string getHashPass(string user, string pass)
        {
            return dp.getHashPass(user, pass);
        }
        
    }
}
