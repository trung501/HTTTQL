using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ThuNgan
    {
        private string maTN;
        private string tenTN;
        private string ngaySinh;
        private string diaChi;
        private string chucVu;
        public string MATHUNGAN { get => maTN; set => maTN = value; }
        public string HOTEN { get => tenTN; set => tenTN = value; }
        public string NGAYSINH { get => ngaySinh; set => ngaySinh = value; }
        public string DIACHI { get => diaChi; set => diaChi = value; }
        public string CHUCVU { get => chucVu; set => chucVu = value; }
        public DTO_ThuNgan(string maTN, string tenTN,string ngaySinh,string diaChi,string chucVu)
        {
            this.maTN = maTN;
            this.tenTN = tenTN;
            this.ngaySinh = ngaySinh;
            this.diaChi = diaChi;
            this.chucVu = chucVu;
        }
    }
}
