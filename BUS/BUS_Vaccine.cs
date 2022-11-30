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
    public class BUS_Vaccine
    {
        DAO_Vaccine dao = new DAO_Vaccine();

        public DataTable getAllVaccine()
        {
            return dao.getAllVaccine();
        }
        public DataTable getAllVaccineSHH(int SoNgay)
        {
            return dao.getAllVaccineSHH(SoNgay);
        }
        public List<DTO_Vaccine> SearchByMaVC(string value)
        {
            return dao.SearchByMaVC(value);
        }
        public List<DTO_VaccineSHH> SearchByMaVCSHH(string value, int SoNgay)
        {
            return dao.SearchByMaVCSHH(value,SoNgay);
        }
        public List<DTO_Vaccine> SearchByTenVC(string value)
        {
            return dao.SearchByTenVC(value);
        }
        public List<DTO_VaccineSHH> SearchByTenVCSHH(string value, int SoNgay)
        {
            return dao.SearchByTenVCSHH(value,SoNgay);
        }
        public List<DTO_Vaccine> SearchByLoaiVC(string value)
        {
            return dao.SearchByLoaiVC(value);
        }
        public List<DTO_VaccineSHH> SearchByLoaiVCSHH(string value, int SoNgay)
        {
            return dao.SearchByLoaiVCSHH(value,SoNgay);
        }
        public List<DTO_Vaccine> SearchByNhaSX(string value)
        {
            return dao.SearchByNhaSX(value);
        }
        public List<DTO_VaccineSHH> SearchByNhaSXSHH(string value,int SoNgay)
        {
            return dao.SearchByNhaSXSHH(value,SoNgay);
        }
        public List<DTO_Vaccine> SearchAll(string value)
        {
            return dao.SearchAll(value);
        }
        public List<DTO_VaccineSHH> SearchAllSHH(string value,int SoNgay)
        {
            return dao.SearchAllSHH(value,SoNgay);
        }
        public int getVCPrice(string maVC)
        {
            return dao.getVCPrice(maVC);
        }

        public string getVCName(string maVC)
        {
            return dao.getVCName(maVC);
        }

        public bool IsVCInStock(string maVC)
        {
            return dao.IsVCInStock(maVC);
        }

        public int GetSoLuongConLai(string maVC)
        {
            return dao.GetSoLuongConLai(maVC);
        }
        public string getMaLVCFromMaVC(string maVC)
        {
            return dao.getMaLVCFromMaVC(maVC);
        }
    }
}
