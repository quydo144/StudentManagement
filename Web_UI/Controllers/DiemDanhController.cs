using EntityFrameWork_BaiTapLon.DataAcces;
using EntityFrameWork_BaiTapLon.Entities_BaiTapLon;
using Services_BaiTapLon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_UI.Controllers
{
    [Authorize(Roles = "GiangVien")]
    public class DiemDanhController : Controller
    {
        public ActionResult DiemDanh_Index()
        {
            LopHocPhanService lhp = new LopHocPhanService();
            List<LopHocPhan> lslhp = new List<LopHocPhan>();
            lslhp = lhp.GetLopHocPhansByID(3).ToList();
            return View(lslhp);
        }
        public ActionResult DiemDanh(int id)
        {
            List<KetQuaHocTap> lst = new List<KetQuaHocTap>();
            List<SinhVien> list = new List<SinhVien>();
            ViewBag.id = id;
            using (QLSVDatabaseContext db = new QLSVDatabaseContext())
            {
                var kq = db.KetQuaHocTaps.Where(x => x.LopHocPhanId == id);
                if (kq != null)
                    foreach (var item in kq)
                    {
                        KetQuaHocTap k = new KetQuaHocTap();
                        k = item;
                        lst.Add(k);
                    }

                foreach (var item in lst)
                {
                    SinhVien sv = db.SinhViens.Where(y => y.SinhVienId == item.SinhVienId).FirstOrDefault();
                    list.Add(sv);
                }
                ViewBag.name = db.LopHocPhans.Where(x => x.LopHocPhanId == id).FirstOrDefault();
            }
            return View(list);
        }
        public ActionResult DiemDanhCf(string idsv, int idlhp, int tt)
        {
            DiemDanhService a = new DiemDanhService();
            KetQuaHocTapService aa = new KetQuaHocTapService();
            DiemDanh dd = new DiemDanh();
            dd.kqhtID = aa.getIDkqht(idsv, idlhp);
            if (tt == 0)
                dd.tragthai = ComMon_BaiTapLon.EnumsHelper.TrangThaiDD.CoMat;
            else dd.tragthai = ComMon_BaiTapLon.EnumsHelper.TrangThaiDD.Vang;
            dd.ngayDD = DateTime.Now;
            var temp = a.GetbyIDSV(idsv, idlhp).Where(x => x.ngayDD.Day == dd.ngayDD.Day && x.ngayDD.Month == dd.ngayDD.Month && x.ngayDD.Year == dd.ngayDD.Year).FirstOrDefault();
            if (temp != null)
            {
                if (dd.tragthai == ComMon_BaiTapLon.EnumsHelper.TrangThaiDD.CoMat)
                    TempData["tb"] = "Hom nay da diem danh";
                else if (dd.tragthai == ComMon_BaiTapLon.EnumsHelper.TrangThaiDD.Vang)
                    TempData["tb"] = "Hom nay da bi vang";
            }
            else
            {
                a.Add(dd);
                if (dd.tragthai == ComMon_BaiTapLon.EnumsHelper.TrangThaiDD.CoMat)
                    TempData["tb"] = "Diem danh thanh cong";
                else if (dd.tragthai == ComMon_BaiTapLon.EnumsHelper.TrangThaiDD.Vang)
                    TempData["tb"] = "Sinh vien da duoc danh vang";
            }
            return RedirectToAction("DiemDanh", new { id = idlhp });
        }
        public ActionResult DanhSachDiemDanh(string idsv, int idlhp)
        {
            DiemDanhService a = new DiemDanhService();
            SinhVienService b = new SinhVienService();
            LopHocPhanService c = new LopHocPhanService();
            List<DiemDanh> lst = new List<DiemDanh>();
            foreach (var item in a.GetbyIDSV(idsv, idlhp))
            {
                DiemDanh m = new DiemDanh();
                m = item;
                lst.Add(m);
            }
            ViewBag.ten = b.getById(idsv).tenSinhVien;
            ViewBag.mon = c.getById(idlhp).tenLopHocPhan;
            return View(lst);
        }
    }
}