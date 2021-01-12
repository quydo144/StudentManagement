using EntityFrameWork_BaiTapLon.Entities_BaiTapLon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Interface_BaiTapLon
{
    public interface IDiemDanhService : IBaseService<DiemDanh>
    {
        DiemDanh Add(DiemDanh dd);
        bool delete(int KqhtId);
    }
}
