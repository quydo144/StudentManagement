namespace EntityFrameWork_BaiTapLon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GiangViens", "passWord");
            DropColumn("dbo.SinhViens", "passWord");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SinhViens", "passWord", c => c.String(nullable: false));
            AddColumn("dbo.GiangViens", "passWord", c => c.String(nullable: false));
        }
    }
}
