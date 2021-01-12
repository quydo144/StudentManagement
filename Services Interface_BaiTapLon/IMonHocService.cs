using EntityFrameWork_BaiTapLon.Entities_BaiTapLon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Interface_BaiTapLon
{
  public interface IMonHocService: IBaseService<MonHoc> 
    {
        MonHoc Add(MonHoc monhoc);
        MonHoc Update(MonHoc monhoc);
        bool Delete(int MonHocId);
    }
}
