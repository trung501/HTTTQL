using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_LoaiVaccine
    {
        private string maLoaiVC;
        private string loaiVC;
        public string MALOAIVC { get => maLoaiVC; set => maLoaiVC = value; }
        public string TENLOAIVC { get => loaiVC; set => loaiVC = value; }
        public DTO_LoaiVaccine(string maLoaiVC, string loaiVC)
        {
            this.maLoaiVC = maLoaiVC;
            this.loaiVC = loaiVC;
        }
    }
}
