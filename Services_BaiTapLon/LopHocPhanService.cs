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
    public class LopHocPhanService : ILopHocPhanService
    {
        private IQSinhVienRepository<LopHocPhan> lopHocPhanrepository;
        public LopHocPhanService()
        {
            lopHocPhanrepository = new QLSinhVienRepository<LopHocPhan>();
        }
        public LopHocPhan Add(LopHocPhan lophocphan)
        {
            return lopHocPhanrepository.Add(lophocphan);
        }

        public bool delete(int LhpId)
        {
            try
            {
                lopHocPhanrepository.Delete(LhpId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<LopHocPhan> GetLopHocPhansByID(int id)
        {
            return lopHocPhanrepository.GetByWhere(s => s.MonHocId == id);
        }

        public IEnumerable<LopHocPhan> GetAll()
        {
            return lopHocPhanrepository.GetByWhere(s => true);
        }

        public LopHocPhan getById(object id)
        {
            return lopHocPhanrepository.GetById(id);
        }

        public LopHocPhan Update(LopHocPhan lophocphan)
        {
            var existing = lopHocPhanrepository.GetById(lophocphan.LopHocPhanId);
            if (existing != null)
            {
                existing.tenLopHocPhan = lophocphan.tenLopHocPhan;
                existing.MonHocId = lophocphan.MonHocId;
                existing.soLuongSV = lophocphan.soLuongSV;
                existing.NgayBD = lophocphan.NgayBD;
                existing.NgayKT = lophocphan.NgayKT;
                existing.NgayKTDK = lophocphan.NgayKTDK;
                existing.Mota = lophocphan.Mota;
                existing.TrangThai = lophocphan.TrangThai;
                existing.GiangVienid = lophocphan.GiangVienid;
                existing.Hockyid = lophocphan.Hockyid;
                lopHocPhanrepository.Update(existing);
            }
            return null;
        }

        public List<LopHocPhan> GetLopHocPhanByGV(string id)
        {
            return lopHocPhanrepository.GetByWhere(x => x.GiangVienid == id).ToList();
        }

        public List<LopHocPhan> GetLopHocPhan_by_idMh_idHk(int idmh, int idhk)
        {
            return lopHocPhanrepository.GetByWhere(x => x.Hockyid == idhk && x.MonHocId == idmh).ToList();
        }

        public List<LopHocPhan> GetLopHocPhanByHK(int idhk)
        {
            return lopHocPhanrepository.GetByWhere(x => x.Hockyid == idhk).ToList();
        }
    }
}
