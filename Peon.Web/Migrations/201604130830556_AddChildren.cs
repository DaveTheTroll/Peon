namespace Peon.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChildren : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChildThings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        C = c.String(maxLength: 64),
                        ThingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TestThings", t => t.ThingID, cascadeDelete: true)
                .Index(t => t.ThingID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChildThings", "ThingID", "dbo.TestThings");
            DropIndex("dbo.ChildThings", new[] { "ThingID" });
            DropTable("dbo.ChildThings");
        }
    }
}
