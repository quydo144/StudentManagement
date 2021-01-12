using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork_BaiTapLon.Entities_BaiTapLon
{
    public class HocKy
    {
        public int Hockyid { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        public string tenHocKy { get; set; }
        public virtual List<LopHocPhan> LopHocPhans { get; set; }
    }
}
