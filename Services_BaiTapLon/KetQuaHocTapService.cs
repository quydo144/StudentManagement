using EntityFrameWork_BaiTapLon.Entities_BaiTapLon;
using Repository_BaiTapLon;
using Services_Interface_BaiTapLon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Services_BaiTapLon
{
    public class KetQuaHocTapService : IKetquahoctapService
    {
        private IQSinhVienRepository<KetQuaHocTap> ketquahoctaprepository;
        public KetQuaHocTapService()
        {
            ketquahoctaprepository = new QLSinhVienRepository<KetQuaHocTap>();
        }
        public KetQuaHocTap Add(KetQuaHocTap kqht)
        {
            return ketquahoctaprepository.Add(kqht);
        }

        public bool delete(int KqhtId)
        {
            try
            {
                ketquahoctaprepository.Delete(KqhtId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<KetQuaHocTap> GetAll()
        {
            return ketquahoctaprepository.GetByWhere(s => true);
        }

        public KetQuaHocTap getById(object id)
        {
            return ketquahoctaprepository.GetById(id);
        }

        public int getSLSVDK(int id)
        {
            return ketquahoctaprepository.GetByWhere(x => x.LopHocPhanId == id).Count();
        }

        public KetQuaHocTap Update(KetQuaHocTap kqht)
        {
            var exting = ketquahoctaprepository.GetById(kqht.kqhtID);
            if (exting != null)
            {
                exting.ThuongKy = kqht.ThuongKy;
                exting.GiuaKy = kqht.GiuaKy;
                exting.CuoiKy = kqht.CuoiKy;
                exting.LopHocPhanId = kqht.LopHocPhanId;
                exting.SinhVienId = kqht.SinhVienId;
                ketquahoctaprepository.Update(exting);
            }
            return null;
        }
        public int getIDkqht(string svid, int lhpid)
        {
            var a = ketquahoctaprepository.GetByWhere(s => (s.SinhVienId == svid && s.LopHocPhanId == lhpid));
            if (a != null)
            {
                return a.FirstOrDefault().kqhtID;
            }
            return 0;
        }
        public IEnumerable<KetQuaHocTap> getDSKQHT_by_idSV(string idsv)
        {
            return ketquahoctaprepository.GetByWhere(x => x.SinhVienId == idsv);
        }
        public KetQuaHocTap getKQHT_by_idsv_idlhp(string idsv, int idlhp)
        {
            return ketquahoctaprepository.GetByWhere(x => x.LopHocPhanId == idlhp && x.SinhVienId == idsv).FirstOrDefault();
        }
    }
}
