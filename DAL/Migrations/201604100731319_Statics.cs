namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Statics : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BotStatics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BetSiteId = c.Int(nullable: false),
                        ResponseCode = c.Int(nullable: false),
                        ResponseText = c.String(unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BetSites", t => t.BetSiteId, cascadeDelete: true)
                .Index(t => t.BetSiteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BotStatics", "BetSiteId", "dbo.BetSites");
            DropIndex("dbo.BotStatics", new[] { "BetSiteId" });
            DropTable("dbo.BotStatics");
        }
    }
}
