namespace Peon.Web.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Peon.Web.Models.ThingDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Peon.Web.Models.ThingDbContext";
        }

        protected override void Seed(Peon.Web.Models.ThingDbContext context)
        {
            context.Things.AddOrUpdate(t => t.Name,
                new TestThing { Name = "First", Sub = new SubThing(1, 1), Additional = 1.11, Value = 1, Group = "G1" },
                new TestThing { Name = "Second", Sub = new SubThing(2, 2), Additional = 2.22, Value = 2, Group = "G1" },
                new TestThing { Name = "Third", Sub = new SubThing(3, 1), Additional = 3.31, Value = 3, Group = "G3" },
                new TestThing { Name = "Fourth", Sub = new SubThing(4, 1), Additional = 4.14, Value = 4, Group = "G2" },
                new DerivedThing { Name = "Di", DerivedProp = 7}
                );
            
            context.SaveChanges();

            context.ChildThings.AddOrUpdate(t => t.C,
                new ChildThing() { C = "Child1", ThingID = context.Things.First().ID },
                new ChildThing() { C = "Child2", ThingID = context.Things.First().ID },
                new ChildThing() { C = "Child3", ThingID = context.Things.Where(t => t.Name == "Di").First().ID });
        }
    }
}
