using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ComMon_BaiTapLon.EnumsHelper;

namespace EntityFrameWork_BaiTapLon.Entities_BaiTapLon
{
    public class GiangVien
    {
        public string GiangVienid { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        public string TenGiangVien { get; set; }
        public GioitinhEnum Gioitinh { get; set; }
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [DataType(DataType.DateTime)]
        public DateTime Ngaysinh { get; set; }
        [Required(ErrorMessage = "Dia chi không được để trống")]
        public string Diachi { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Chuyen ngành không được để trống")]
        public string ChuyenNganh { get; set; }
        public virtual List<LopHocPhan> LopHocPhans { get; set; }
    }
}
