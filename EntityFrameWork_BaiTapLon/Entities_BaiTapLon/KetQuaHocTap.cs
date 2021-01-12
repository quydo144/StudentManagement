using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork_BaiTapLon.Entities_BaiTapLon
{
    public class KetQuaHocTap
    {
        [Key]
        public int kqhtID { get; set; }
        [Required(ErrorMessage = "SV không được để trống")]
        public string SinhVienId { get; set; }
        public virtual SinhVien SinhVien { get; set; }
        [Required(ErrorMessage = "LHP không được để trống")]
        public int LopHocPhanId { get; set; }
        public virtual LopHocPhan LopHocPhan { get; set; }
        public double? ThuongKy { get; set; }
        public double? GiuaKy { get; set; }
        public double? CuoiKy { get; set; }
    }
}
