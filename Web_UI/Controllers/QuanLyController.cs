using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services_BaiTapLon;
using EntityFrameWork_BaiTapLon;
using EntityFrameWork_BaiTapLon.Entities_BaiTapLon;
using ComMon_BaiTapLon;
using static ComMon_BaiTapLon.EnumsHelper;

namespace Web_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class QuanLyController : Controller
    {
        LopHocPhanService serlhp;
        MonHocService sermh;
        public QuanLyController()
        {
            serlhp = new LopHocPhanService();
            sermh = new MonHocService();
        }
        public ActionResult SinhVien()
        {
            SinhVienService sv = new SinhVienService();
            return View(sv.GetAll());
        }
        [HttpPost]
        public ActionResult themSV(FormCollection f)
        {
            SinhVienService svService = new SinhVienService();
            SinhVien sv = new SinhVien();
            sv.tenSinhVien = f["txtTenSV"];
            if (f["chkGioiTinh"].Equals("Nam"))
            {
                sv.Gioitinh = EnumsHelper.GioitinhEnum.Nam;
            }
            else if (f["chkGioiTinh"].Equals("Nữ"))
            {
                sv.Gioitinh = EnumsHelper.GioitinhEnum.Nu;
            }
            else
            {
                sv.Gioitinh = EnumsHelper.GioitinhEnum.Khac;
            }
            sv.Ngaysinh = Convert.ToDateTime(f["txtNgaySinh"]);
            sv.Diachi = f["txtDiaChi"];
            sv.ChuyenNganh = f["txtChuyenNganh"];
            sv.soDienThoai = f["txtSDT"];
            return RedirectToAction("SinhVien");
        }

        public ActionResult GiangVien(List<GiangVien> ls)
        {
            GiangVienService gv = new GiangVienService();
            ls = gv.GetAll().ToList();
            return View(ls);
        }

        [HttpPost]
        public ActionResult Save(FormCollection f)
        {
            GiangVienService gv = new GiangVienService();
            GiangVien s = new GiangVien();
            s.TenGiangVien = f["txtname"];
            if (f["txtGT"].Equals("Nam"))
                s.Gioitinh = ComMon_BaiTapLon.EnumsHelper.GioitinhEnum.Nam; /*f["txtGT"];*/
            if (f["txtGT"].Equals("Nu"))
                s.Gioitinh = ComMon_BaiTapLon.EnumsHelper.GioitinhEnum.Nu;
            else s.Gioitinh = ComMon_BaiTapLon.EnumsHelper.GioitinhEnum.Khac;
            s.ChuyenNganh = f["txtCN"];
            s.Ngaysinh = DateTime.Parse(f["txtNS"]);
            s.Diachi = f["txtDC"];
            s.Email = f["txtEM"];
            gv.Add(s);
            List<GiangVien> lsgv = new List<GiangVien>();
            lsgv = gv.GetAll().ToList();

            return RedirectToAction("Index", new { ls = lsgv });
        }
        public ActionResult Delete(string id)
        {
            GiangVienService gv = new GiangVienService();
            gv.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f1)
        {
            GiangVienService gv = new GiangVienService();
            GiangVien s = new GiangVien();
            s.TenGiangVien = f1["txtname1"];
            if (f1["sl1"].Equals("Nam"))
                s.Gioitinh = ComMon_BaiTapLon.EnumsHelper.GioitinhEnum.Nam;
            if (f1["sl1"].Equals("Nu"))
                s.Gioitinh = ComMon_BaiTapLon.EnumsHelper.GioitinhEnum.Nu;
            else s.Gioitinh = ComMon_BaiTapLon.EnumsHelper.GioitinhEnum.Khac;
            s.ChuyenNganh = f1["txtCN1"];
            s.Ngaysinh = DateTime.Parse(f1["txtNS1"]);
            s.Diachi = f1["txtDC1"];
            s.Email = f1["txtEM1"];
            List<GiangVien> lsgv = new List<GiangVien>();
            lsgv = gv.GetAll().ToList();
            gv.Update(s);
            return RedirectToAction("Index", new { ls = lsgv });
        }

        public ActionResult LopHocPhan()
        {
            MonHocService mh = new MonHocService();
            var list = mh.GetAll();
            return View(list);
        }


        public ActionResult them()
        {
            LopHocPhanService lopHocPhanService = new LopHocPhanService();
            LopHocPhan lopHocPhan = new LopHocPhan();
            return View();
        }

        public JsonResult AddLPH(LopHocPhan lp) /*int lophocphanid,int monhocid,int giangvienid,string tenhp,int SL,int trangthai,string mota,DateTime ngayBD,DateTime ngayketthuc,DateTime Ndk,int hockyid*/
        {
            LopHocPhanService lopHocPhanService = new LopHocPhanService();
            //LopHocPhan lopHocPhan = new LopHocPhan();
            //lopHocPhan.MonHocId = 1;
            //lopHocPhan.GiangVienid = 2;
            //lopHocPhan.tenLopHocPhan = "WWW";
            //lopHocPhan.soLuongSV = 12;
            //lopHocPhan.TrangThai = TrangThaiLHP.Chap_Nhan_Mo_Lop;
            //lopHocPhan.Mota = "";
            //lopHocPhan.NgayBD = Convert.ToDateTime("10/11/1999");
            //lopHocPhan.NgayKT = Convert.ToDateTime("10/1/2000");
            //lopHocPhan.NgayKTDK = Convert.ToDateTime("6/1/2000");
            //lopHocPhan.Hockyid = 1;
            //lopHocPhan = lopHocPhanService.Add(lopHocPhan);
            //var res = Json(lopHocPhanService, JsonRequestBehavior.AllowGet);
            //return res;
            List<LopHocPhan> lst = new List<LopHocPhan>();
            var lt = (from mh in sermh.GetAll()
                      join
                        lph in serlhp.GetAll() on mh.MonhocId equals lph.MonHocId
                      where (lph.MonHocId == lp.MonHocId)
                      select new
                      {
                          lph.MonHocId,
                          lph.Mota,
                          lph.NgayBD,
                          lph.NgayKT,
                          lph.NgayKTDK,
                          lph.soLuongSV,
                          lph.tenLopHocPhan,
                          lph.TrangThai
                      }).ToList();

            lst.Add(lp);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CapNhat()
        {
            LopHocPhanService lopHocPhanService = new LopHocPhanService();
            LopHocPhan lopHoc = new LopHocPhan();
            lopHoc.NgayBD = DateTime.Now;
            DateTime ngaykt = lopHoc.NgayBD.AddDays(0);
            if (ngaykt.CompareTo(lopHoc.NgayBD) == 1) return View(TrangThaiLHP.Cho_Huy_Lop);
            else
            {
                return View(TrangThaiLHP.Cho_SV_dang_ki);
            }
        }
        public JsonResult CapNhatLHP(LopHocPhan lopHocPhan)
        {
            LopHocPhanService lopHocPhanService = new LopHocPhanService();
            LopHocPhan lopHoc = new LopHocPhan();
            lopHoc.NgayBD = DateTime.Now;
            DateTime ngaykt = lopHoc.NgayBD.AddDays(0);
            if (ngaykt.CompareTo(lopHoc.NgayBD) == 0) return Json(lopHoc.TrangThai == (TrangThaiLHP.Cho_Huy_Lop), JsonRequestBehavior.AllowGet);
            else
            {
                return Json(lopHoc.TrangThai == (TrangThaiLHP.Cho_SV_dang_ki), JsonRequestBehavior.AllowGet);
            }
            //return Json(lopHoc.TrangThai == (TrangThaiLHP.Chap_Nhan_Mo_Lop), JsonRequestBehavior.AllowGet);
        }
    }
}