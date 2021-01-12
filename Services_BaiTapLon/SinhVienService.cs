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
    public class SinhVienService : ISinhvienService
    {
        private IQSinhVienRepository<SinhVien> sinhVienRepository;
        public SinhVienService()
        {
            sinhVienRepository = new QLSinhVienRepository<SinhVien>();
        }
        public SinhVien Add(SinhVien sinhvien)
        {
            return sinhVienRepository.Add(sinhvien);
        }

        public bool Delete(int SinhvienId)
        {
            try
            {
                sinhVienRepository.Delete(SinhvienId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<SinhVien> GetAll()
        {
            return sinhVienRepository.GetByWhere(s => true);
        }

        public SinhVien getById(object id)
        {
            return sinhVienRepository.GetById( id);
        }

        public SinhVien updatate(SinhVien sinhvien)
        {
            var existing = sinhVienRepository.GetById(sinhvien.SinhVienId);
            if(existing!=null)
            {
                existing.tenSinhVien = sinhvien.tenSinhVien;
                existing.Gioitinh = sinhvien.Gioitinh;
                existing.Ngaysinh = sinhvien.Ngaysinh;
                existing.Diachi = sinhvien.Diachi;
                existing.ChuyenNganh = sinhvien.ChuyenNganh;
                existing.BacDT = sinhvien.BacDT;
                existing.soDienThoai = sinhvien.soDienThoai;
                existing.KhoaHocID = sinhvien.KhoaHocID;
                sinhVienRepository.Update(existing);
            }
            return null;
        }
        public List<SinhVien> GetSVByMaLopHP(string id)
        {
            return sinhVienRepository.GetByWhere(x => x.SinhVienId == id).ToList();
        }
    }
}
