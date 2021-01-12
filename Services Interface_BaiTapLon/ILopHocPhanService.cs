using EntityFrameWork_BaiTapLon.Entities_BaiTapLon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Interface_BaiTapLon
{
    public interface ILopHocPhanService: IBaseService<LopHocPhan> 
    {
        LopHocPhan Add(LopHocPhan lophocphan);
        LopHocPhan Update(LopHocPhan lophocphan);
        bool delete(int LhpId);
    }
}
