namespace Peon.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpawnStation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BaseStations", "Target_Latitude", c => c.Double());
            AddColumn("dbo.BaseStations", "Target_Longitude", c => c.Double());
            AddColumn("dbo.BaseStations", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BaseStations", "Discriminator");
            DropColumn("dbo.BaseStations", "Target_Longitude");
            DropColumn("dbo.BaseStations", "Target_Latitude");
        }
    }
}
