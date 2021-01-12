using EntityFrameWork_BaiTapLon.Entities_BaiTapLon;
using Repository_BaiTapLon;
using Services_Interface_BaiTapLon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_BaiTapLon
{
    public class HocKyService : IHocKyService
    {
        private IQSinhVienRepository<HocKy> hocKyrepository;
        public HocKyService()
        {
            hocKyrepository = new QLSinhVienRepository<HocKy>();
        }
        public HocKy Add(HocKy hocky)
        {
            return hocKyrepository.Add(hocky);
        }

        public bool Delete(int hockyId)
        {
            try
            {
                hocKyrepository.Delete(hockyId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<HocKy> GetAll()
        {
            return hocKyrepository.GetByWhere(s => true);
        }

        public HocKy getById(object id)
        {
            return hocKyrepository.GetById(id);
        }

        public HocKy Update(HocKy hocky)
        {
            var exting = hocKyrepository.GetById(hocky.Hockyid);
            if (exting != null)
            {
                exting.tenHocKy = hocky.tenHocKy;
                hocKyrepository.Update(exting);
            }
            return null;
        }
    }
}
