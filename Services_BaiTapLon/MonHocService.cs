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
    public class MonHocService : IMonHocService
    {
        private IQSinhVienRepository<MonHoc> monHocrepository;
        public MonHocService()
        {
            monHocrepository = new QLSinhVienRepository<MonHoc>();
        }
        public MonHoc Add(MonHoc monhoc)
        {
            return monHocrepository.Add(monhoc);
        }

        public bool Delete(int MonHocId)
        {
            try
            {
                monHocrepository.Delete(MonHocId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<MonHoc> GetAll()
        {
            return monHocrepository.GetByWhere(s => true);
        }

        public MonHoc getById(object id)
        {
            return monHocrepository.GetById(id);
        }

        public MonHoc Update(MonHoc monhoc)
        {
            var exting = monHocrepository.GetById(monhoc.MonhocId);
            if (exting != null)
            {
                exting.TenMonHoc = monhoc.TenMonHoc;
                exting.Sotinchi = monhoc.Sotinchi;
                monHocrepository.Update(exting);
            }
            return null;
        }
    }
}
