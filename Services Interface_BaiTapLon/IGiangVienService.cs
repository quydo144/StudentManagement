using EntityFrameWork_BaiTapLon.Entities_BaiTapLon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Interface_BaiTapLon
{
    public interface IGiangVienService: IBaseService<GiangVien>
    {
        GiangVien Add(GiangVien gv);
        GiangVien Update(GiangVien gv);
        bool Delete(string GiangVienId);
    }
}
