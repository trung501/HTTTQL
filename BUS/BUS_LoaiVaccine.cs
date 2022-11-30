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
    public class BUS_LoaiVaccine
    {
        DAO_LoaiVaccine daoLoaiVC = new DAO_LoaiVaccine();
        public DataTable getAllLoaiVC()
        {
            return daoLoaiVC.getAllLoaiVC();
        }
        public bool IsLoaiVCExists(string LOAIVACCINE)
        {
            return daoLoaiVC.IsLoaiVCExists(LOAIVACCINE);
        }
        public string GetLastestMaLoaiVC()
        {
            return daoLoaiVC.GetLastestMaLoaiVC();
        }
        public string NextMAVACCINE()
        {
            string MaLVC = daoLoaiVC.GetLastestMaLoaiVC().Trim();            
            int count = MaLVC.Length - 3;
            int ptIndex = Convert.ToInt32(MaLVC.Substring(3)) + 1;
            MaLVC = "LVC";
            for (int i = 0; i < count - ptIndex.ToString().Length; i++)
                MaLVC += "0";
            MaLVC += (ptIndex).ToString();
            return MaLVC;
        }
        public bool InsertLoaiVC(DTO_LoaiVaccine lvc)
        {
            return daoLoaiVC.InsertLoaiVC(lvc);
        }
        public bool XoaLoaiVC(string MALOAIVC)
        {
            return daoLoaiVC.XoaLoaiVC(MALOAIVC);
        }
    }    
}
