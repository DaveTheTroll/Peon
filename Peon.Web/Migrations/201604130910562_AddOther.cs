namespace Peon.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOther : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestThings", "Other", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestThings", "Other");
        }
    }
}
