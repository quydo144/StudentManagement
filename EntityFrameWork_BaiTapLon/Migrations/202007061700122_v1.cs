namespace EntityFrameWork_BaiTapLon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiemDanhs",
                c => new
                    {
                        kqhtID = c.Int(nullable: false),
                        ngayDD = c.DateTime(nullable: false),
                        tragthai = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.kqhtID, t.ngayDD })
                .ForeignKey("dbo.KetQuaHocTaps", t => t.kqhtID, cascadeDelete: true)
                .Index(t => t.kqhtID);
            
            CreateTable(
                "dbo.KetQuaHocTaps",
                c => new
                    {
                        kqhtID = c.Int(nullable: false, identity: true),
                        SinhVienId = c.String(nullable: false, maxLength: 128),
                        LopHocPhanId = c.Int(nullable: false),
                        ThuongKy = c.Double(nullable: true),
                        GiuaKy = c.Double(nullable: true),
                        CuoiKy = c.Double(nullable: true),
                    })
                .PrimaryKey(t => t.kqhtID)
                .ForeignKey("dbo.LopHocPhans", t => t.LopHocPhanId, cascadeDelete: true)
                .ForeignKey("dbo.SinhViens", t => t.SinhVienId, cascadeDelete: true)
                .Index(t => t.SinhVienId)
                .Index(t => t.LopHocPhanId);
            
            CreateTable(
                "dbo.LopHocPhans",
                c => new
                    {
                        LopHocPhanId = c.Int(nullable: false, identity: true),
                        tenLopHocPhan = c.String(nullable: false),
                        MonHocId = c.Int(nullable: false),
                        soLuongSV = c.Int(nullable: false),
                        TrangThai = c.Int(nullable: false),
                        Mota = c.String(),
                        NgayBD = c.DateTime(nullable: false),
                        NgayKTDK = c.DateTime(nullable: false),
                        NgayKT = c.DateTime(nullable: false),
                        Hockyid = c.Int(nullable: false),
                        GiangVienid = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.LopHocPhanId)
                .ForeignKey("dbo.GiangViens", t => t.GiangVienid, cascadeDelete: true)
                .ForeignKey("dbo.HocKies", t => t.Hockyid, cascadeDelete: true)
                .ForeignKey("dbo.MonHocs", t => t.MonHocId, cascadeDelete: true)
                .Index(t => t.MonHocId)
                .Index(t => t.Hockyid)
                .Index(t => t.GiangVienid);
            
            CreateTable(
                "dbo.GiangViens",
                c => new
                    {
                        GiangVienid = c.String(nullable: false, maxLength: 128),
                        TenGiangVien = c.String(nullable: false),
                        Gioitinh = c.Int(nullable: false),
                        Ngaysinh = c.DateTime(nullable: false),
                        Diachi = c.String(nullable: false),
                        Email = c.String(),
                        ChuyenNganh = c.String(nullable: false),
                        passWord = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GiangVienid);
            
            CreateTable(
                "dbo.HocKies",
                c => new
                    {
                        Hockyid = c.Int(nullable: false, identity: true),
                        tenHocKy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Hockyid);
            
            CreateTable(
                "dbo.MonHocs",
                c => new
                    {
                        MonhocId = c.Int(nullable: false, identity: true),
                        TenMonHoc = c.String(nullable: false),
                        Sotinchi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MonhocId);
            
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        SinhVienId = c.String(nullable: false, maxLength: 128),
                        tenSinhVien = c.String(nullable: false),
                        Gioitinh = c.Int(nullable: false),
                        Ngaysinh = c.DateTime(nullable: false),
                        Diachi = c.String(nullable: false),
                        ChuyenNganh = c.String(nullable: false),
                        BacDT = c.String(nullable: false),
                        soDienThoai = c.String(),
                        KhoaHocID = c.Int(nullable: false),
                        passWord = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SinhVienId)
                .ForeignKey("dbo.KhoaHocs", t => t.KhoaHocID, cascadeDelete: true)
                .Index(t => t.KhoaHocID);
            
            CreateTable(
                "dbo.KhoaHocs",
                c => new
                    {
                        KhoaHocID = c.Int(nullable: false, identity: true),
                        TCTThieu = c.Int(nullable: false),
                        TCTDa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KhoaHocID);
            Sql(@"CREATE FUNCTION AUTO_IDSV()
            RETURNS NVARCHAR(20)
            AS
            BEGIN
	            DECLARE @ID NVARCHAR(20)
	            DECLARE @length int
	            IF (SELECT COUNT([SinhVienId]) FROM [dbo].[SinhViens]) = 0
		            SET @ID = '0'
	            ELSE
		             SELECT @ID = convert(int,MAX(right([SinhVienId],6))) FROM [dbo].[SinhViens]
		             set @length=len(@ID)
		             select @ID= case
				            when @length=1 and @ID<9 then 'SV00000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				            when @ID=9 then 'SV0000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				            when (@ID>9 and @length=2) and (@length=2 and @ID<99) then 'SV0000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				            when @ID=99 then 'SV000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				            when (@ID>99 and @length=3) and (@length=3 and @ID<999) then 'SV000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				            when @ID=999 then 'SV00' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				            when (@ID>999 and @length=4) and(@length=4 and @ID<9999) then 'SV00' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				            when @ID=9999 then 'SV0' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				            when (@ID>9999 and @length=5) and (@length=5 and @ID<99999) then 'SV0' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				            when (@ID>99999 and @length=6) and (@length=6 and @ID<999999) then 'SV' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
			            END
	            RETURN @ID
            END
            GO
            ALTER TABLE [dbo].[SinhViens] ADD CONSTRAINT DF_SV DEFAULT [dbo].[AUTO_IDSV]() FOR SinhVienId
            GO
            CREATE TRIGGER TGSV ON [dbo].[SinhViens] INSTEAD OF INSERT
            AS
            BEGIN 
	            INSERT [dbo].[SinhViens](tenSinhVien,Gioitinh,Ngaysinh,Diachi,ChuyenNganh,BacDT,soDienThoai,KhoaHocID,passWord)
		            SELECT I.tenSinhVien,I.Gioitinh,I.Ngaysinh,I.Diachi, i.ChuyenNganh,i.BacDT,i.soDienThoai,i.KhoaHocID,i.passWord
		            FROM inserted I
            END

            go
            CREATE FUNCTION AUTO_IDGV()
            RETURNS NVARCHAR(20)
            AS
            BEGIN
	            DECLARE @ID NVARCHAR(20)
	            DECLARE @length int
	            IF (SELECT COUNT(GiangVienid) FROM [dbo].GiangViens) = 0
		            SET @ID = '0'
	            ELSE
		             SELECT @ID = convert(int,MAX(right(GiangVienid,6))) FROM [dbo].GiangViens
		             set @length=len(@ID)
		             select @ID= case
				            when @length=1 and @ID<9 then 'GV00000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				            when @ID=9 then 'GV0000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				            when (@ID>9 and @length=2) and (@length=2 and @ID<99) then 'GV0000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				            when @ID=99 then 'GV000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				            when (@ID>99 and @length=3) and (@length=3 and @ID<999) then 'GV000' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				            when @ID=999 then 'GV00' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				            when (@ID>999 and @length=4) and(@length=4 and @ID<9999) then 'GV00' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				            when @ID=9999 then 'GV0' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				            when (@ID>9999 and @length=5) and (@length=5 and @ID<99999) then 'GV0' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
				            when (@ID>99999 and @length=6) and (@length=6 and @ID<999999) then 'GV' +CONVERT(NVARCHAR(8), CONVERT(INT, @ID) + 1)
			            END
	            RETURN @ID
            END
            GO
            ALTER TABLE [dbo].GiangViens ADD CONSTRAINT DF_GV DEFAULT [dbo].AUTO_IDGV() FOR GiangVienid
            GO
            CREATE TRIGGER TGGV ON [dbo].GiangViens INSTEAD OF INSERT
            AS
            BEGIN 
	            INSERT [dbo].GiangViens(TenGiangVien,Gioitinh,Ngaysinh,Diachi,Email,ChuyenNganh,passWord)
		            SELECT I.TenGiangVien,I.Gioitinh,I.Ngaysinh,I.Diachi, i.Email,i.ChuyenNganh,i.passWord
		            FROM inserted I
            END");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiemDanhs", "kqhtID", "dbo.KetQuaHocTaps");
            DropForeignKey("dbo.SinhViens", "KhoaHocID", "dbo.KhoaHocs");
            DropForeignKey("dbo.KetQuaHocTaps", "SinhVienId", "dbo.SinhViens");
            DropForeignKey("dbo.LopHocPhans", "MonHocId", "dbo.MonHocs");
            DropForeignKey("dbo.KetQuaHocTaps", "LopHocPhanId", "dbo.LopHocPhans");
            DropForeignKey("dbo.LopHocPhans", "Hockyid", "dbo.HocKies");
            DropForeignKey("dbo.LopHocPhans", "GiangVienid", "dbo.GiangViens");
            DropIndex("dbo.SinhViens", new[] { "KhoaHocID" });
            DropIndex("dbo.LopHocPhans", new[] { "GiangVienid" });
            DropIndex("dbo.LopHocPhans", new[] { "Hockyid" });
            DropIndex("dbo.LopHocPhans", new[] { "MonHocId" });
            DropIndex("dbo.KetQuaHocTaps", new[] { "LopHocPhanId" });
            DropIndex("dbo.KetQuaHocTaps", new[] { "SinhVienId" });
            DropIndex("dbo.DiemDanhs", new[] { "kqhtID" });
            DropTable("dbo.KhoaHocs");
            DropTable("dbo.SinhViens");
            DropTable("dbo.MonHocs");
            DropTable("dbo.HocKies");
            DropTable("dbo.GiangViens");
            DropTable("dbo.LopHocPhans");
            DropTable("dbo.KetQuaHocTaps");
            DropTable("dbo.DiemDanhs");
        }
    }
}
