namespace EntityFrameWork_BaiTapLon.Migrations
{
    using EntityFrameWork_BaiTapLon.Entities_BaiTapLon;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using static ComMon_BaiTapLon.EnumsHelper;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityFrameWork_BaiTapLon.DataAcces.QLSVDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntityFrameWork_BaiTapLon.DataAcces.QLSVDatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var KH = new List<KhoaHoc>
            {
                new KhoaHoc { TCTThieu = 8, TCTDa = 20 },
                new KhoaHoc { TCTThieu = 10, TCTDa = 21 },
                new KhoaHoc { TCTThieu = 8, TCTDa = 17 },
            };
            KH.ForEach(kh => context.KhoaHocs.AddOrUpdate(a => a.TCTDa, kh));
            context.SaveChanges();
            ////////////////////////////////HOC KY//////////////////////////////
            var hk = new List<HocKy>
            {
                new HocKy { tenHocKy ="I" },
                new HocKy { tenHocKy ="II" },
                new HocKy { tenHocKy ="III" }
            };
            hk.ForEach(hk1 => context.HocKies.AddOrUpdate(a => a.tenHocKy, hk1));
            context.SaveChanges();
            ////////////////////////////////MON HOC /////////////////////////////
            var mh = new List<MonHoc>
            {
                new MonHoc {TenMonHoc ="Lap trinh WWW",Sotinchi=3 },
                new MonHoc {TenMonHoc ="Tu Tuong Nguoi May",Sotinchi=3 },
                new MonHoc {TenMonHoc ="Kien truc va thiet ke phan mem",Sotinchi=4 },
                new MonHoc {TenMonHoc ="Dam bao va kiem thu phan mem",Sotinchi=3 }
            };
            mh.ForEach(mh1 => context.MonHocs.AddOrUpdate(a => a.TenMonHoc, mh1));
            context.SaveChanges();

            /////////////////////////GIANG VIEN//////////////////////////////////////////

            var gv = new List<GiangVien>
            {
                new GiangVien {GiangVienid="GV000001", TenGiangVien="Thanh Van", ChuyenNganh ="KTMT", Diachi="2 Nguyen Van Bao", Email="Van@gmail.com", Gioitinh= (GioitinhEnum)3,Ngaysinh = Convert.ToDateTime("01/01/1989") },
                new GiangVien {GiangVienid="GV000002",TenGiangVien="Ngoc Tram", ChuyenNganh ="KTPM", Diachi="40 Le Lai", Email="TramNgoc@gmail.com", Gioitinh= (GioitinhEnum)3,Ngaysinh = Convert.ToDateTime("03/03/1979")},
                new GiangVien {GiangVienid="GV000003",TenGiangVien="Hai Hoang", ChuyenNganh ="CNTT", Diachi="3 Le Loi", Email="Hoang@gmail.com", Gioitinh= (GioitinhEnum)2,Ngaysinh = Convert.ToDateTime("02/10/1980")}
            };
            gv.ForEach(gv1 => context.GiangViens.AddOrUpdate(a => a.TenGiangVien, gv1));
            context.SaveChanges();
            /////////////////////////// LOP HOC PHAN ////////////////////////////////////

            var lhp = new List<LopHocPhan>
            {
                new LopHocPhan {tenLopHocPhan="WWW01", Mota="Lap trinh WWW", NgayBD= Convert.ToDateTime("02/02/2020"),NgayKTDK= Convert.ToDateTime("12/02/2020"), NgayKT=Convert.ToDateTime("05/05/2020"), GiangVienid="GV000003", Hockyid=2, soLuongSV=50,TrangThai= (TrangThaiLHP)2, MonHocId = 1},
                new LopHocPhan {tenLopHocPhan="WWW02", Mota="Lap trinh WWW", NgayBD= Convert.ToDateTime("02/02/2020"),NgayKTDK= Convert.ToDateTime("12/02/2020"), NgayKT=Convert.ToDateTime("05/05/2020"), GiangVienid="GV000003", Hockyid=2, soLuongSV=50,TrangThai= (TrangThaiLHP)1, MonHocId = 1},
                new LopHocPhan {tenLopHocPhan="TTNM01", Mota="Tuong Tac Nguoi May", NgayBD= Convert.ToDateTime("02/08/2020"),NgayKTDK= Convert.ToDateTime("12/08/2020"), NgayKT=Convert.ToDateTime("12/12/2020"), GiangVienid="GV000001", Hockyid=1, soLuongSV=80,TrangThai= (TrangThaiLHP)1, MonHocId = 2},
                new LopHocPhan {tenLopHocPhan="TTNM02", Mota="Tuong Tac Nguoi May", NgayBD= Convert.ToDateTime("02/08/2020"),NgayKTDK= Convert.ToDateTime("12/08/2020"), NgayKT=Convert.ToDateTime("12/12/2020"), GiangVienid="GV000001", Hockyid=1, soLuongSV=80,TrangThai=(TrangThaiLHP)1, MonHocId = 2},
                new LopHocPhan {tenLopHocPhan="Kientruc01", Mota="Kien Truc Va Thiet Ke Phan Mem", NgayBD= Convert.ToDateTime("02/02/2020"),NgayKTDK= Convert.ToDateTime("12/02/2020"), NgayKT=Convert.ToDateTime("05/05/2020"), GiangVienid="GV000002", Hockyid=2, soLuongSV=90,TrangThai= (TrangThaiLHP)1, MonHocId = 3},
                new LopHocPhan {tenLopHocPhan="Kientruc02", Mota="Kien Truc Va Thiet Ke Phan Mem", NgayBD= Convert.ToDateTime("02/02/2020"),NgayKTDK= Convert.ToDateTime("12/02/2020"), NgayKT=Convert.ToDateTime("05/05/2020"), GiangVienid="GV000002", Hockyid=2, soLuongSV=90,TrangThai= (TrangThaiLHP)3, MonHocId = 3 },
                new LopHocPhan {tenLopHocPhan="Kientruc03", Mota="Kien Truc Va Thiet Ke Phan Mem", NgayBD= Convert.ToDateTime("02/08/2020"),NgayKTDK= Convert.ToDateTime("12/08/2020"), NgayKT=Convert.ToDateTime("12/12/2020"), GiangVienid="GV000001", Hockyid=1, soLuongSV=90,TrangThai= (TrangThaiLHP)1, MonHocId = 3},
                new LopHocPhan {tenLopHocPhan="DBKT01", Mota="Dam Bao Va Kiem Thu Phan Mem", NgayBD= Convert.ToDateTime("02/02/2020"),NgayKTDK= Convert.ToDateTime("12/02/2020"), NgayKT=Convert.ToDateTime("05/05/2020"), GiangVienid="GV000001", Hockyid=2, soLuongSV=40,TrangThai= (TrangThaiLHP)2, MonHocId = 4}
            };
            lhp.ForEach(lhp1 => context.LopHocPhans.AddOrUpdate(a => a.tenLopHocPhan, lhp1));
            context.SaveChanges();

            /////////////////////////////////SINH VIEN////////////////////////////////////

            var sv = new List<SinhVien>
            {
                new SinhVien {SinhVienId="SV000001", tenSinhVien = "Thanh Nghia", ChuyenNganh="KTPM", Gioitinh=(GioitinhEnum)2, Diachi ="3 Hoang Hoa Tham", soDienThoai="09256263366", Ngaysinh=Convert.ToDateTime("01/10/1999"), BacDT="Dai Hoc", KhoaHocID=1, },
                new SinhVien {SinhVienId="SV000002", tenSinhVien = "Hoanh Anh", ChuyenNganh="CNTT", Gioitinh=(GioitinhEnum)3, Diachi ="35 Hai Ba Trung", soDienThoai="09745454526", Ngaysinh=Convert.ToDateTime("01/05/1999"), BacDT="Dai Hoc", KhoaHocID=1, },
                new SinhVien {SinhVienId="SV000003", tenSinhVien = "Hoai Sa", ChuyenNganh="HTMT", Gioitinh=(GioitinhEnum)3, Diachi ="100 Do Son", soDienThoai="09223243346", Ngaysinh=Convert.ToDateTime("12/11/1998"), BacDT="Cao Dang", KhoaHocID=2, },
                new SinhVien {SinhVienId="SV000004", tenSinhVien = "Truong An", ChuyenNganh="HTMT", Gioitinh=(GioitinhEnum)2, Diachi ="23 Thanh Tinh", soDienThoai="0935628946", Ngaysinh=Convert.ToDateTime("01/11/2000"), BacDT="Cao Dang", KhoaHocID=1,}
            };
            sv.ForEach(sv1 => context.SinhViens.AddOrUpdate(a => a.tenSinhVien, sv1));
            context.SaveChanges();

            //////////////////////////////////// KET QUA HOC TAP///////////////////////////

            var kqht = new List<KetQuaHocTap>
            {
                new KetQuaHocTap {LopHocPhanId= 1, SinhVienId="SV000001", ThuongKy= 9.0, GiuaKy= 7.5, CuoiKy= 8.0 },
                new KetQuaHocTap {LopHocPhanId= 5, SinhVienId="SV000003", ThuongKy= 9.0, GiuaKy= 9.5, CuoiKy= 8.75 },
                new KetQuaHocTap {LopHocPhanId= 1, SinhVienId="SV000001", ThuongKy= 9.0, GiuaKy= 7.5, CuoiKy= 8.0 },
                new KetQuaHocTap {LopHocPhanId= 3, SinhVienId="SV000003" },
                new KetQuaHocTap {LopHocPhanId= 5, SinhVienId="SV000001", ThuongKy= 7.3, GiuaKy= 5.0, CuoiKy= 6.5 },
                new KetQuaHocTap {LopHocPhanId= 1, SinhVienId="SV000002", ThuongKy= 8.3, GiuaKy= 6.5, CuoiKy= 6.9 },
                new KetQuaHocTap {LopHocPhanId= 3, SinhVienId="SV000002", ThuongKy= 5.3, GiuaKy= 5.5, CuoiKy= 5.9 },
                new KetQuaHocTap {LopHocPhanId= 8, SinhVienId="SV000002" },
                new KetQuaHocTap {LopHocPhanId= 2, SinhVienId="SV000003" },
            };

            kqht.ForEach(kqht1 => context.KetQuaHocTaps.AddOrUpdate(a => a.ThuongKy, kqht1));
            context.SaveChanges();

            /////////////////////////////////// Diem Danh ////////////////////////////////

            var dd = new List<DiemDanh>
            {
                new DiemDanh { kqhtID=1 , tragthai= (TrangThaiDD)1,ngayDD = Convert.ToDateTime("03/01/2020") },
                new DiemDanh { kqhtID=1 , tragthai=(TrangThaiDD)1,ngayDD = Convert.ToDateTime("03/08/2020") },
                new DiemDanh { kqhtID=1 , tragthai=(TrangThaiDD)2,ngayDD = Convert.ToDateTime("03/03/2020") },
                new DiemDanh { kqhtID=1 , tragthai=(TrangThaiDD)1,ngayDD = Convert.ToDateTime("03/09/2020") },
                new DiemDanh { kqhtID=2 , tragthai=(TrangThaiDD)1,ngayDD = Convert.ToDateTime("03/07/2020") },
                new DiemDanh { kqhtID=2 , tragthai=(TrangThaiDD)2,ngayDD = Convert.ToDateTime("03/08/2020") },
                new DiemDanh { kqhtID=2 , tragthai=(TrangThaiDD)1,ngayDD = Convert.ToDateTime("03/02/2020") },
            };
            dd.ForEach(dd1 => context.DiemDanhs.AddOrUpdate(a => a.tragthai, dd1));
            context.SaveChanges();
        }
    }
}
