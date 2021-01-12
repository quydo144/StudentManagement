using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork_BaiTapLon.Entities_BaiTapLon
{
    public class MonHoc
    {
        public int MonhocId { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        public string TenMonHoc { get; set; }
        [Required(ErrorMessage = "Số TC không được để trống")]
        public int Sotinchi { get; set; }

        public virtual List<LopHocPhan> LopHocPhans { get; set; }
    }
}
