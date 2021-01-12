using EntityFrameWork_BaiTapLon.Entities_BaiTapLon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WWW_BaiTapLon.Models
{
    public class Model_DangKyHocPhan
    {
        public SinhVien mSinhVien { get; set; }
        public List<MonHoc> mMonHoc { get; set; }
        public IEnumerable<HocKy> mHocKy { get; set; }
        public IEnumerable<LopHocPhan> mLopHocPhan { get; set; }

        
    }
}