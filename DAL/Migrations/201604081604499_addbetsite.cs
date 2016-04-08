namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbetsite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BetSites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, storeType: "varchar"),
                        Desc = c.String(maxLength: 250, storeType: "varchar"),
                        MainUrl = c.String(nullable: false, maxLength: 100, storeType: "varchar"),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BetSites");
        }
    }
}
