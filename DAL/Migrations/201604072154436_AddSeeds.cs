namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeeds : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.TestCodeFirstModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TestCodeFirstModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        URL = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
