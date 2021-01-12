using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WWW_BaiTapLon.Models;
using Services_BaiTapLon;
using EntityFrameWork_BaiTapLon.Entities_BaiTapLon;
using EntityFrameWork_BaiTapLon.DataAcces;
using ComMon_BaiTapLon;
using Microsoft.AspNet.Identity;

namespace WWW_BaiTapLon.Controllers
{
    [Authorize(Roles = "SinhVien")]
    public class SinhVienController : Controller
    {
        QLSVDatabaseContext db = new QLSVDatabaseContext();
        LopHocPhanService sc = new LopHocPhanService();
        MonHocService ser_mh = new MonHocService();
        // GET: SinhVien
        public ActionResult SinhVien()
        {
            string id = User.Identity.GetUserName();
            return View(db.SinhViens.Where(x=>x.SinhVienId.Equals(id)).FirstOrDefault());
        }

        public ActionResult DangKyHocPhan()
        {
            string idsv = User.Identity.GetUserName();
            Model_DangKyHocPhan a = new Model_DangKyHocPhan();
            List<MonHoc> monHocs = new List<MonHoc>();
            SinhVienService sinhVienService = new SinhVienService();
            MonHocService mh = new MonHocService();
            List<MonHoc> monhocs = db.MonHocs.Select(x => x).ToList();
            List<KetQuaHocTap> kqht = db.KetQuaHocTaps.Where(x => x.SinhVienId.Equals(idsv)).ToList();
            List<LopHocPhan> lhp = db.LopHocPhans.Select(x => x).ToList();
            List<LopHocPhan> listtemp = new List<LopHocPhan>();
            
            MonHocService ser_mh = new MonHocService();
            List<MonHoc> list_mh = ser_mh.GetAll().ToList();
            foreach (var item in kqht)
            {
                LopHocPhan lhpnew = new LopHocPhan();
                lhpnew = db.LopHocPhans.Where(x => x.LopHocPhanId == item.LopHocPhanId).FirstOrDefault()
;               int malop = lhpnew.MonHocId;
                for (int i = 0; i < list_mh.Count; i++)
                {
                    if (list_mh[i].MonhocId == malop)
                        list_mh.RemoveAt(i);
                }
            }
            //for (int i = 0; i < kqht.Count; i++)
            //{
            //    for (int j = 0; j < lhp.Count; j++)
            //    {
            //        if (kqht[i].LopHocPhanId == lhp[j].LopHocPhanId)
            //        {
            //            LopHocPhan temp = new LopHocPhan();
            //            temp = lhp[j];
            //            listtemp.Add(temp);
            //        }
            //    }
            //}
            //for (int i = 0; i < mon; i++)
            //{
            //    for (int j = 0; j < listtemp.Count; j++)
            //    {
            //        if (item.MonhocId != listtemp[i].MonHocId)
            //        {
            //            monHocs.Add(item);
            //        }
            //    }
            //}
            //foreach (var item in mh.GetAll())
            //{
            //    var monhoc = new MonHoc();
            //    monhoc = item;
            //    monHocs.Add(monhoc);
            //}
            //hoc ki
            List<HocKy> hockis = new List<HocKy>();
            HocKyService hk = new HocKyService();
            foreach (var item in hk.GetAll())
            {
                var hocky = new HocKy();
                hocky = item;
                hockis.Add(hocky);
            }

            //sinh vien
            SinhVien sv = new SinhVien();
            sv = db.SinhViens.Where(x => x.SinhVienId.Equals(idsv)).FirstOrDefault();
            a.mHocKy = hockis;
            //a.mMonHoc = monHocs;
            a.mMonHoc = list_mh;
            a.mSinhVien = sv;
            return PartialView(a);
        }
        public JsonResult getDanhSachLopHocPhan()//
        {
            LopHocPhanService sc = new LopHocPhanService();
            IEnumerable<LopHocPhan> lst = new List<LopHocPhan>();
            lst = sc.GetAll();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getDanhSachLopHocPhan_Hocky(int idmh, int idhk)//
        {
            LopHocPhanService sc = new LopHocPhanService();
            IEnumerable<LopHocPhan> lst = new List<LopHocPhan>();
            lst = sc.GetLopHocPhan_by_idMh_idHk(idmh, idhk);
            KetQuaHocTapService kqhtsev = new KetQuaHocTapService();
            List<LopHocPhan_soluong> lsl = new List<LopHocPhan_soluong>();
            foreach (var item in lst)
            {
                LopHocPhan_soluong x = new LopHocPhan_soluong();
                x.malophp = item.LopHocPhanId;
                x.sisotoida = item.soLuongSV;
                x.tenlophp = item.tenLopHocPhan;
                if (item.TrangThai.Equals("1"))
                {
                    x.trangthai = "Chờ sinh viên đăng kí";
                }
                else
                {
                    if (item.TrangThai.Equals("2"))
                    {
                        x.trangthai = "Chấp nhận mở lớp";
                    }
                    else
                        x.trangthai = "Chờ hủy lớp";
                }
                x.sisohientai = kqhtsev.getSLSVDK(item.LopHocPhanId);
                lsl.Add(x);
            }
            return Json(lsl, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getDangKyHocPhan(int id)
        {
            LopHocPhanService lopHocPhan = new LopHocPhanService();
            KetQuaHocTapService kqhtsev = new KetQuaHocTapService();
            List<LopHocPhan> lopHocPhans = lopHocPhan.GetLopHocPhansByID(id).ToList();
            List<LopHocPhan_soluong> lsl = new List<LopHocPhan_soluong>();
            foreach (var item in lopHocPhans)
            {
                LopHocPhan_soluong x = new LopHocPhan_soluong();
                x.malophp = item.LopHocPhanId;
                x.sisotoida = item.soLuongSV;
                x.tenlophp = item.tenLopHocPhan;
                if (item.TrangThai == EnumsHelper.TrangThaiLHP.Cho_SV_dang_ki)
                {
                    x.trangthai = "Chờ sinh viên đăng kí";
                }
                else if (item.TrangThai == EnumsHelper.TrangThaiLHP.Chap_Nhan_Mo_Lop)
                {
                    x.trangthai = "Chấp nhận mở lớp";
                }
                else
                    x.trangthai = "Chờ hủy lớp";

                x.sisohientai = kqhtsev.getSLSVDK(item.LopHocPhanId);
                lsl.Add(x);
            }
            var res = Json(lsl, JsonRequestBehavior.AllowGet);
            return res;
        }

        public JsonResult getKQHT_theoKy(int idhk)
        {
            LopHocPhanService sc = new LopHocPhanService();
            IEnumerable<LopHocPhan> lst = new List<LopHocPhan>();
            lst = sc.GetLopHocPhanByHK(idhk);
            List<KetQuaHocTap> list_kqht = new List<KetQuaHocTap>();
            KetQuaHocTapService kqhtsev = new KetQuaHocTapService();
            List<KQHT> lsl = new List<KQHT>();
            list_kqht = kqhtsev.GetAll().ToList();
            foreach (var item2 in lst)
            {
                foreach (var item in list_kqht)
                {
                    if (item2.LopHocPhanId == item.LopHocPhanId)
                    {
                        KQHT ketqua = new KQHT();
                        ketqua.kqhtid = item.kqhtID;
                        ketqua.lophpid = item.LopHocPhanId;
                        ketqua.svid = item.SinhVienId;
                        ketqua.tk = item.ThuongKy;
                        ketqua.gk = item.GiuaKy;
                        ketqua.ck = item.CuoiKy;
                        double? tongket = ketqua.tk * 0.2 + ketqua.gk * 0.3 + ketqua.ck * 0.5;
                        if (ketqua.tk == null && ketqua.gk==null && ketqua.ck == null)
                        {
                            break;
                        }
                        ketqua.tongdiem = tongket;
                        if (ketqua.tongdiem > 9)
                        {
                            ketqua.bac4 = 4.0;
                        }
                        else
                        {
                            if (ketqua.tongdiem >= 8.5) ketqua.bac4 = 3.8;
                            else
                            {
                                if (ketqua.tongdiem >= 8) ketqua.bac4 = 3.5;
                                else
                                {
                                    if (ketqua.tongdiem >= 7) ketqua.bac4 = 3.0;
                                    else
                                    {
                                        if (ketqua.tongdiem >= 6) ketqua.bac4 = 2.5;
                                        else
                                        {
                                            if (ketqua.tongdiem >= 5) ketqua.bac4 = 2.0;
                                            else
                                            {
                                                if (ketqua.tongdiem >= 4) ketqua.bac4 = 1.5;
                                                else
                                                    ketqua.bac4 = 0;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (ketqua.bac4 == 4.0) ketqua.xeploai = "Xuất sắc";
                        else
                        {
                            if (ketqua.bac4 == 3.8) ketqua.xeploai = "Giỏi";
                            else
                            {
                                if (ketqua.bac4 == 3.5 || ketqua.bac4 == 3.0) ketqua.xeploai = "Khá";
                                else
                                {
                                    if (ketqua.bac4 == 2.5 || ketqua.bac4 == 2.0) ketqua.xeploai = "Trung bình";
                                    else
                                    {
                                        if (ketqua.bac4 == 1.5) ketqua.xeploai = "Yếu";
                                        else ketqua.xeploai = "Không qua môn";
                                    }

                                }
                            }
                        }
                        lsl.Add(ketqua);
                    }
                }

            }
            var res = Json(lsl, JsonRequestBehavior.AllowGet);
            return res;
        }
        public ActionResult getDangKy(int idlhp)
        {
            List<DKHP> list_dkhp = new List<DKHP>();
            LopHocPhanService ser_lhp = new LopHocPhanService();
            List<LopHocPhan> list_lhp = new List<LopHocPhan>();
            LopHocPhan lhp = ser_lhp.getById(idlhp);

            List<KetQuaHocTap> list_kqht = new List<KetQuaHocTap>();
            KetQuaHocTapService kqhtsv = new KetQuaHocTapService();
            KetQuaHocTap kq = new KetQuaHocTap();
            kq.LopHocPhanId = idlhp;
            kq.SinhVienId = User.Identity.GetUserName();
            kq = kqhtsv.Add(kq);


            MonHocService ser_mh = new MonHocService();
            int idmon = lhp.MonHocId;
            MonHoc mh = ser_mh.getById(idmon);

            DKHP dkhp = new DKHP();
            dkhp.idkqht = kq.kqhtID;
            dkhp.malhp = kq.LopHocPhanId;
            dkhp.idsv = kq.SinhVienId;
            dkhp.malhp = idlhp;
            dkhp.tenmh = mh.TenMonHoc;
            dkhp.sotc = mh.Sotinchi;
            // dkhp.ngaydk = DateTime.Today;
            if (lhp.TrangThai == EnumsHelper.TrangThaiLHP.Cho_SV_dang_ki)
            {
                dkhp.trangthai = "Chờ sinh viên đăng kí";
            }
            else if (lhp.TrangThai == EnumsHelper.TrangThaiLHP.Chap_Nhan_Mo_Lop)
            {
                dkhp.trangthai = "Chấp nhận mở lớp";
            }
            else
                dkhp.trangthai = "Chờ hủy lớp";
            list_dkhp.Add(dkhp);

            return Json(dkhp, JsonRequestBehavior.AllowGet);
        }
        public JsonResult RangBuocDangky_DkLopChoHuy(int idlhp)
        {

            LopHocPhanService ser_lhp = new LopHocPhanService();
            LopHocPhan lhp = ser_lhp.getById(idlhp);
            if (lhp.TrangThai == EnumsHelper.TrangThaiLHP.Cho_Huy_Lop)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(lhp, JsonRequestBehavior.AllowGet);
            }

        }
        public bool RangBuocDangky_DkTime(int idlhp)
        {
            LopHocPhanService ser_lhp = new LopHocPhanService();
            LopHocPhan lhp = ser_lhp.getById(idlhp);
            if (lhp.NgayBD > DateTime.Today || lhp.NgayKT < DateTime.Today)
            {
                return false;
            }
            else
            {
                return true;
            }
        }               // kiểm tra xem có trong tgian đk không á
        public bool RangBuocDangky_DkSoTCchoPhep(string idsv, int idhk)
        {

            SinhVienService ser_sv = new SinhVienService();
            SinhVien sv = ser_sv.getById(idsv);
            int khoaid = sv.KhoaHocID;
            KhoaHocService ser_kh = new KhoaHocService();
            KhoaHoc kh = ser_kh.getById(khoaid);
            int sotc_max = kh.TCTDa;
            //lay ds lhp cua hoc ky do
            LopHocPhanService ser_lhp = new LopHocPhanService();
            List<LopHocPhan> list_lhp = ser_lhp.GetLopHocPhanByHK(idhk).ToList();
            //lay ds ketquahoctap cua sinh vien do
            KetQuaHocTapService ser_kqht = new KetQuaHocTapService();
            List<KetQuaHocTap> list_kqht = ser_kqht.getDSKQHT_by_idSV(idsv).ToList();
            int sotchientai = 0;
            foreach (var item in list_lhp)
            {
                foreach (var item2 in list_kqht)
                {
                    if (item2.LopHocPhanId == item.LopHocPhanId)
                    {
                        sotchientai += 1;
                    }
                }
            }
            if (sotchientai > sotc_max) return false;
            return true;
        }

        public ActionResult KetQuaHocTap()
        {
            Model_KetQuaHocTap a = new Model_KetQuaHocTap();
            List<KQHT> kqhts = new List<KQHT>();
            KetQuaHocTapService kq = new KetQuaHocTapService();
            List<KetQuaHocTap> list_kqht = kq.GetAll().ToList();
            foreach (var item in list_kqht)
            {
                KQHT ketqua = new KQHT();
                ketqua.kqhtid = item.kqhtID;
                ketqua.lophpid = item.LopHocPhanId;
                ketqua.svid = item.SinhVienId;
                ketqua.tk = item.ThuongKy;
                ketqua.gk = item.GiuaKy;
                ketqua.ck = item.CuoiKy;
                double? tongket = ketqua.tk * 0.2 + ketqua.gk * 0.3 + ketqua.ck * 0.5;
                ketqua.tongdiem = tongket;
                if (ketqua.tongdiem > 9)
                {
                    ketqua.bac4 = 4.0;
                }
                else
                {
                    if (ketqua.tongdiem >= 8.5) ketqua.bac4 = 3.8;
                    else
                    {
                        if (ketqua.tongdiem >= 8) ketqua.bac4 = 3.5;
                        else
                        {
                            if (ketqua.tongdiem >= 7) ketqua.bac4 = 3.0;
                            else
                            {
                                if (ketqua.tongdiem >= 6) ketqua.bac4 = 2.5;
                                else
                                {
                                    if (ketqua.tongdiem >= 5) ketqua.bac4 = 2.0;
                                    else
                                    {
                                        if (ketqua.tongdiem >= 4) ketqua.bac4 = 1.5;
                                        else
                                            ketqua.bac4 = 0;
                                    }
                                }
                            }
                        }
                    }
                }
                if (ketqua.bac4 == 4.0) ketqua.xeploai = "Xuất sắc";
                else
                {
                    if (ketqua.bac4 == 3.8) ketqua.xeploai = "Giỏi";
                    else
                    {
                        if (ketqua.bac4 == 3.5 || ketqua.bac4 == 3.0) ketqua.xeploai = "Khá";
                        else
                        {
                            if (ketqua.bac4 == 2.5 || ketqua.bac4 == 2.0) ketqua.xeploai = "Trung bình";
                            else
                            {
                                if (ketqua.bac4 == 1.5) ketqua.xeploai = "Yếu";
                                else ketqua.xeploai = "Không qua môn";
                            }

                        }
                    }
                }
                kqhts.Add(ketqua);
            }
            //hoc ki
            List<HocKy> hockis = new List<HocKy>();
            HocKyService hk = new HocKyService();
            foreach (var item in hk.GetAll())
            {
                var hocky = new HocKy();
                hocky = item;
                hockis.Add(hocky);
            }
            a.mHocKy = hockis;
            a.mKQHT = kqhts;
            return PartialView(a);
        }

        public JsonResult getDSDangKy_theoHK(int idhk)
        {
            IEnumerable<LopHocPhan> lst = new List<LopHocPhan>();
            lst = sc.GetLopHocPhanByHK(idhk);
            List<KetQuaHocTap> list_kqht = new List<KetQuaHocTap>();
            KetQuaHocTapService kqhtsev = new KetQuaHocTapService();
            List<DKHP> lsl = new List<DKHP>();
            list_kqht = kqhtsev.GetAll().ToList();
            string idsv = User.Identity.GetUserName();
            foreach (var item2 in lst)
            {
                foreach (var item in list_kqht)
                {
                    if (item2.LopHocPhanId == item.LopHocPhanId && item.SinhVienId == idsv)
                    {
                        MonHoc mh = ser_mh.getById(item2.MonHocId);
                        DKHP d = new DKHP();
                        d.idkqht = item.kqhtID;
                        d.idsv = item.SinhVienId;
                        d.malhp = item.LopHocPhanId;
                        d.sotc = mh.Sotinchi;
                        d.tenmh = mh.TenMonHoc; ;
                        if (item2.TrangThai == EnumsHelper.TrangThaiLHP.Cho_SV_dang_ki)
                        {
                            d.trangthai = "Chờ sinh viên đăng kí";
                        }
                        else if (item2.TrangThai == EnumsHelper.TrangThaiLHP.Chap_Nhan_Mo_Lop)
                        {
                            d.trangthai = "Chấp nhận mở lớp";
                        }
                        else
                            d.trangthai = "Chờ hủy lớp";
                        lsl.Add(d);
                    }
                }
            }
            return Json(lsl, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChanSauDangKy(int idlhp)
        {
            LopHocPhanService ser_lhp = new LopHocPhanService();
            MonHocService ser_mh = new MonHocService();
            //load lai mon hoc
            LopHocPhan lhp = ser_lhp.getById(idlhp);
            MonHoc mh = ser_mh.getById(lhp.MonHocId);
            List<MonHoc> list_mh = ser_mh.GetAll().ToList();

            for (int i = 0; i < list_mh.Count; i++)
            {
                if (list_mh[i].MonhocId == mh.MonhocId)
                    list_mh.RemoveAt(i);
            }
            return Json(list_mh, JsonRequestBehavior.AllowGet);
        }

        public JsonResult HuyLopHP(int idlhp, int idhk)
        {
            KetQuaHocTapService ser_kqht = new KetQuaHocTapService();
            string idsv = User.Identity.GetUserName();
            KetQuaHocTap kqht = ser_kqht.getKQHT_by_idsv_idlhp(idsv, idlhp);
            ser_kqht.delete(kqht.kqhtID);
            //load lai ds dang ky
            IEnumerable<LopHocPhan> lst = new List<LopHocPhan>();
            lst = sc.GetLopHocPhanByHK(idhk);
            List<KetQuaHocTap> list_kqht = new List<KetQuaHocTap>();
            KetQuaHocTapService kqhtsev = new KetQuaHocTapService();
            List<DKHP> lsl = new List<DKHP>();
            list_kqht = kqhtsev.GetAll().ToList();
            foreach (var item2 in lst)
            {
                foreach (var item in list_kqht)
                {
                    if (item2.LopHocPhanId == item.LopHocPhanId && item.SinhVienId == idsv)
                    {
                        MonHoc mh = ser_mh.getById(item2.MonHocId);
                        DKHP d = new DKHP();
                        d.idkqht = item.kqhtID;
                        d.idsv = item.SinhVienId;
                        d.malhp = item.LopHocPhanId;
                        d.sotc = mh.Sotinchi;
                        d.tenmh = mh.TenMonHoc; ;
                        if (item2.TrangThai == EnumsHelper.TrangThaiLHP.Cho_SV_dang_ki)
                        {
                            d.trangthai = "Chờ sinh viên đăng kí";
                        }
                        else if (item2.TrangThai == EnumsHelper.TrangThaiLHP.Chap_Nhan_Mo_Lop)
                        {
                            d.trangthai = "Chấp nhận mở lớp";
                        }
                        else
                            d.trangthai = "Chờ hủy lớp";
                        lsl.Add(d);
                    }
                }
            }
            return Json(lsl, JsonRequestBehavior.AllowGet);
        }
    }
}

