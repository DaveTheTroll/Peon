namespace Peon.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveChanged : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TestThings", "Created");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TestThings", "Created", c => c.DateTime(nullable: false));
        }
    }
}
