namespace Peon.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDerived : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestThings", "DerivedProp", c => c.Int());
            AddColumn("dbo.TestThings", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestThings", "Discriminator");
            DropColumn("dbo.TestThings", "DerivedProp");
        }
    }
}
