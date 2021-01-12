using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ComMon_BaiTapLon.EnumsHelper;

namespace EntityFrameWork_BaiTapLon.Entities_BaiTapLon
{
    public class SinhVien
    {
        public string SinhVienId { get; set; }
        [Required(ErrorMessage = "không được để trống")]
        public string tenSinhVien { get; set; }
        public GioitinhEnum Gioitinh { get; set; }
        [Required(ErrorMessage = "Ngay sinh không được để trống")]
        public DateTime Ngaysinh { get; set; }
        [Required(ErrorMessage = "Dia chi không được để trống")]
        public string Diachi { get; set; }
        [Required(ErrorMessage = "Chuyen ngành không được để trống")]
        public string ChuyenNganh { get; set; }
        [Required(ErrorMessage = "BacDT không được để trống")]
        public string BacDT { get; set; }
        public string soDienThoai { get; set; }
        public virtual List<KetQuaHocTap> KetQuaHocTaps { get; set; }
        [Required(ErrorMessage = "KH không được để trống")]
        public int KhoaHocID { get; set; }
        public virtual KhoaHoc KhoaHoc { get; set; }
    }
}
