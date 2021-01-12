using EntityFrameWork_BaiTapLon.Entities_BaiTapLon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Interface_BaiTapLon
{
   public interface IHocKyService:IBaseService<HocKy> 
    {
        HocKy Add(HocKy hocky);
        HocKy Update(HocKy hocky);
        bool Delete(int hockyId);
    }
}
