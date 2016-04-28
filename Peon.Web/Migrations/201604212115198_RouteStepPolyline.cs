namespace Peon.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RouteStepPolyline : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RouteSteps", "Polyline_Points", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RouteSteps", "Polyline_Points");
        }
    }
}
