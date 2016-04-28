namespace Peon.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpawnStation3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Location_Latitude = c.Double(nullable: false),
                        Location_Longitude = c.Double(nullable: false),
                        Name = c.String(),
                        DestinationID = c.Int(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BaseStations", t => t.DestinationID, cascadeDelete: true)
                .Index(t => t.DestinationID);
            
            CreateTable(
                "dbo.RouteSteps",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Start_Latitude = c.Double(nullable: false),
                        Start_Longitude = c.Double(nullable: false),
                        End_Latitude = c.Double(nullable: false),
                        End_Longitude = c.Double(nullable: false),
                        Distance = c.Single(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        Polyline_Points = c.String(),
                        Driver_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Drivers", t => t.Driver_ID)
                .Index(t => t.Driver_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RouteSteps", "Driver_ID", "dbo.Drivers");
            DropForeignKey("dbo.Drivers", "DestinationID", "dbo.BaseStations");
            DropIndex("dbo.RouteSteps", new[] { "Driver_ID" });
            DropIndex("dbo.Drivers", new[] { "DestinationID" });
            DropTable("dbo.RouteSteps");
            DropTable("dbo.Drivers");
        }
    }
}
