using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork_BaiTapLon.Entities_BaiTapLon
{
    public class KhoaHoc
    {
        public int KhoaHocID { get; set; }
        [Required(ErrorMessage = "TCThieu không được để trống")]
        public int TCTThieu { get; set; }
        [Required(ErrorMessage = "TCTDa không được để trống")]
        public int TCTDa { get; set; }
        public virtual List<SinhVien> SinhViens { get; set; }
    }
}
