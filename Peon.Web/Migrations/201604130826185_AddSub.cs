namespace Peon.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSub : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestThings", "Sub_A", c => c.Int(nullable: false));
            AddColumn("dbo.TestThings", "Sub_B", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestThings", "Sub_B");
            DropColumn("dbo.TestThings", "Sub_A");
        }
    }
}
