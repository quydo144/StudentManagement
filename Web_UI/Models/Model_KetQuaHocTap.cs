using EntityFrameWork_BaiTapLon.Entities_BaiTapLon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WWW_BaiTapLon.Models
{
    public class Model_KetQuaHocTap
    {
        public SinhVien mSinhVien { get; set; }
        public List<KetQuaHocTap> mKetQuaHocTap { get; set; }
        public List<KQHT> mKQHT { get; set; }
        public List<HocKy> mHocKy { get; set; }
    }
}