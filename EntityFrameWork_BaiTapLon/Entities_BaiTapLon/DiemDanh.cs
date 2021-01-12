using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ComMon_BaiTapLon.EnumsHelper;

namespace EntityFrameWork_BaiTapLon.Entities_BaiTapLon
{
    public class DiemDanh
    {
        [Key]
        [Column(Order = 1)]
        public int kqhtID { get; set; }
        [Key]
        [Column(Order =2)]
        [DataType(DataType.DateTime)]
        public DateTime ngayDD { get; set; }      
        public TrangThaiDD tragthai { get; set; }
        public virtual KetQuaHocTap ketquahoctap { get; set; }
    }
}
