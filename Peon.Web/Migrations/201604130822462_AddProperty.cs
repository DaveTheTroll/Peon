namespace Peon.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestThings", "Additional", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestThings", "Additional");
        }
    }
}
