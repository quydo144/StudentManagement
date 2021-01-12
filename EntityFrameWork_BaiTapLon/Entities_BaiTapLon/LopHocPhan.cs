using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Data.Entity.Migrations.Builders;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ComMon_BaiTapLon.EnumsHelper;

namespace EntityFrameWork_BaiTapLon.Entities_BaiTapLon
{
    public class LopHocPhan
    {
        public int LopHocPhanId { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        public string tenLopHocPhan { get; set; }
        [Required(ErrorMessage = "Mon hoc không được để trống")]
        public int MonHocId { get; set; }
        [Required(ErrorMessage = "SL không được để trống")]
        public int soLuongSV { get; set; }
        public TrangThaiLHP TrangThai { get; set; }
        public string Mota { get; set; }
        [Required(ErrorMessage = "NgayBD không được để trống")]
        [DataType(DataType.DateTime)]
        public DateTime NgayBD { get; set; }
        [Required(ErrorMessage = "NgayKTDK không được để trống")]
        [DataType(DataType.DateTime)]
        public DateTime NgayKTDK { get; set; }
        [Required(ErrorMessage = "NgayKT không được để trống")]
        [DataType(DataType.DateTime)]
        public DateTime NgayKT { get; set; }
        public virtual MonHoc MonHoc { get; set; }
        [Required(ErrorMessage = "HK không được để trống")]
        public int Hockyid { get; set; }
        public virtual HocKy HocKy { get; set; }
        [Required(ErrorMessage = "GV không được để trống")]
        public string GiangVienid { get; set; }
        public virtual GiangVien GiangVien { get; set; }
        public virtual List<KetQuaHocTap> KetQuaHocTaps { get; set; }
    }
}
