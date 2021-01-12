using EntityFrameWork_BaiTapLon.Entities_BaiTapLon;
using Repository_BaiTapLon;
using Services_Interface_BaiTapLon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Services_BaiTapLon
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DiemDanhService1" in both code and config file together.
    public class DiemDanhService : IDiemDanhService
    {
        private IQSinhVienRepository<DiemDanh> diemdanhrepository;

        public DiemDanhService()
        {
            diemdanhrepository = new QLSinhVienRepository<DiemDanh>();
        }
        public DiemDanh Add(DiemDanh dd)
        {
            return diemdanhrepository.Add(dd);
        }

        public bool delete(int KqhtId)
        {
            try
            {
                diemdanhrepository.Delete(KqhtId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<DiemDanh> GetAll()
        {
            return diemdanhrepository.GetByWhere(s => true);
        }
        public IEnumerable<DiemDanh> GetbyIDSV(string idsv, int idlhp)
        {
            KetQuaHocTapService kq = new KetQuaHocTapService();
            int a = kq.getIDkqht(idsv, idlhp);
            if (a != 0)
                return diemdanhrepository.GetByWhere(s => s.kqhtID == a);
            return null;
        }
        public DiemDanh getById(object id)
        {
            throw new NotImplementedException();
        }
    }
}
