namespace Peon.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpawnStation4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BaseStations", "DestinationID", "dbo.BaseStations");
            DropForeignKey("dbo.Drivers", "DestinationID", "dbo.BaseStations");
            DropIndex("dbo.BaseStations", new[] { "DestinationID" });
            DropIndex("dbo.Drivers", new[] { "DestinationID" });
            AddColumn("dbo.BaseStations", "Destination_Latitude", c => c.Double());
            AddColumn("dbo.BaseStations", "Destination_Longitude", c => c.Double());
            AddColumn("dbo.Drivers", "Destination_Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Drivers", "Destination_Longitude", c => c.Double(nullable: false));
            DropColumn("dbo.BaseStations", "DestinationID");
            DropColumn("dbo.Drivers", "DestinationID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drivers", "DestinationID", c => c.Int(nullable: false));
            AddColumn("dbo.BaseStations", "DestinationID", c => c.Int());
            DropColumn("dbo.Drivers", "Destination_Longitude");
            DropColumn("dbo.Drivers", "Destination_Latitude");
            DropColumn("dbo.BaseStations", "Destination_Longitude");
            DropColumn("dbo.BaseStations", "Destination_Latitude");
            CreateIndex("dbo.Drivers", "DestinationID");
            CreateIndex("dbo.BaseStations", "DestinationID");
            AddForeignKey("dbo.Drivers", "DestinationID", "dbo.BaseStations", "ID", cascadeDelete: true);
            AddForeignKey("dbo.BaseStations", "DestinationID", "dbo.BaseStations", "ID");
        }
    }
}
