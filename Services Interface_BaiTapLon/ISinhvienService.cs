using EntityFrameWork_BaiTapLon.Entities_BaiTapLon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Interface_BaiTapLon
{
    public interface ISinhvienService:IBaseService<SinhVien> 
    {
        SinhVien Add(SinhVien sinhvien);
        SinhVien updatate(SinhVien sinhvien);
        bool Delete(int SinhvienId);
    }
}
