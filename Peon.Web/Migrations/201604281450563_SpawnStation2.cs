namespace Peon.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpawnStation2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Drivers", "DestinationID", "dbo.BaseStations");
            DropForeignKey("dbo.RouteSteps", "Driver_ID", "dbo.Drivers");
            DropIndex("dbo.Drivers", new[] { "DestinationID" });
            DropIndex("dbo.RouteSteps", new[] { "Driver_ID" });
            AddColumn("dbo.BaseStations", "DestinationID", c => c.Int());
            AddColumn("dbo.BaseStations", "SpawnRate", c => c.Time(precision: 7));
            AddColumn("dbo.BaseStations", "LastUpdate", c => c.DateTime());
            CreateIndex("dbo.BaseStations", "DestinationID");
            AddForeignKey("dbo.BaseStations", "DestinationID", "dbo.BaseStations", "ID");
            DropColumn("dbo.BaseStations", "Target_Latitude");
            DropColumn("dbo.BaseStations", "Target_Longitude");
            DropTable("dbo.Drivers");
            DropTable("dbo.RouteSteps");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.ID);
            
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
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.BaseStations", "Target_Longitude", c => c.Double());
            AddColumn("dbo.BaseStations", "Target_Latitude", c => c.Double());
            DropForeignKey("dbo.BaseStations", "DestinationID", "dbo.BaseStations");
            DropIndex("dbo.BaseStations", new[] { "DestinationID" });
            DropColumn("dbo.BaseStations", "LastUpdate");
            DropColumn("dbo.BaseStations", "SpawnRate");
            DropColumn("dbo.BaseStations", "DestinationID");
            CreateIndex("dbo.RouteSteps", "Driver_ID");
            CreateIndex("dbo.Drivers", "DestinationID");
            AddForeignKey("dbo.RouteSteps", "Driver_ID", "dbo.Drivers", "ID");
            AddForeignKey("dbo.Drivers", "DestinationID", "dbo.BaseStations", "ID", cascadeDelete: true);
        }
    }
}
