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
    public class BUS_NhapKho
    {
        DAO_Vaccine daoVC = new DAO_Vaccine();
        DAO_QuanLyVaccine daoQLVC = new DAO_QuanLyVaccine();

        public DataTable getAllVaccine()
        {
            return daoVC.getAllVaccine();
        }

        public List<DTO_Vaccine> SearchByMaVC(string value)
        {
            return daoVC.SearchByMaVC(value);
        }

        public List<DTO_Vaccine> SearchByTenVC(string value)
        {
            return daoVC.SearchByTenVC(value);
        }

        public List<DTO_Vaccine> SearchByLoaiVC(string value)
        {
            return daoVC.SearchByLoaiVC(value);
        }

        public List<DTO_Vaccine> SearchByNhaSX(string value)
        {
            return daoVC.SearchByNhaSX(value);
        }

        public List<DTO_Vaccine> SearchAll(string value)
        {
            return daoVC.SearchAll(value);
        }

        public int getVCPrice(string maVC)
        {
            return daoVC.getVCPrice(maVC);
        }

        public string getVCName(string maVC)
        {
            return daoVC.getVCName(maVC);
        }

        public bool IsVCInStock(string maVC)
        {
            return daoVC.IsVCInStock(maVC);
        }

        public int GetSoLuongConLai(string maVC)
        {
            return daoVC.GetSoLuongConLai(maVC);
        }
        public bool ChinhSuaVaccine(DTO_QuanLyVaccine vc)
        {
            return daoQLVC.ChinhSuaVaccine(vc);
        }
        public bool InsertVaccine(DTO_QuanLyVaccine vc)
        {
            return daoQLVC.InsertVaccine(vc);
        }
        public string NextMAVACCINE()
        {
            string MaVC = daoVC.GetLastestMAVACCINE().Trim();
            if (MaVC == null)
            {
                return "VC001";
            }
            int count = MaVC.Length - 2;
            int ptIndex = Convert.ToInt32(MaVC.Substring(2)) + 1;
            MaVC = "VC";
            for (int i = 0; i < count - ptIndex.ToString().Length; i++)
                MaVC += "0";
            MaVC += (ptIndex).ToString();
            return MaVC;
        }
        public string getMaLVCFromMaVC(string maVC)
        {
            return daoVC.getMaLVCFromMaVC(maVC);
        }
    }

    }
