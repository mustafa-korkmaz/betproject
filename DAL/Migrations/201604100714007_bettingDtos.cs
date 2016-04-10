namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bettingDtos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HomeTeamId = c.Int(nullable: false),
                        AwayTeamId = c.Int(nullable: false),
                        StartDateTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.AwayTeamId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.HomeTeamId, cascadeDelete: true)
                .Index(t => t.HomeTeamId)
                .Index(t => t.AwayTeamId);
            
            CreateTable(
                "dbo.PlayerBets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        BetId = c.Int(nullable: false),
                        ThresholdScore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bets", t => t.BetId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.BetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerBets", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.PlayerBets", "BetId", "dbo.Bets");
            DropForeignKey("dbo.Events", "HomeTeamId", "dbo.Teams");
            DropForeignKey("dbo.Bets", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "AwayTeamId", "dbo.Teams");
            DropIndex("dbo.PlayerBets", new[] { "BetId" });
            DropIndex("dbo.PlayerBets", new[] { "PlayerId" });
            DropIndex("dbo.Events", new[] { "AwayTeamId" });
            DropIndex("dbo.Events", new[] { "HomeTeamId" });
            DropIndex("dbo.Bets", new[] { "EventId" });
            DropTable("dbo.PlayerBets");
            DropTable("dbo.Events");
            DropTable("dbo.Bets");
        }
    }
}
