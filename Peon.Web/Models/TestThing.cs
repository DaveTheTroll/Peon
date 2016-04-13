using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Peon.Web.Models
{
    public class SubThing
    {
        public int A { get; set; }
        public int B { get; set; }
    }

    public class ChildThing
    {
        public int ID { get; set; }
        [MaxLength(64)]
        public string C { get; set; }
        
        public int ThingID { get; set; }
        public TestThing Thing { get; set; }
    }

    public class TestThing
    {
        public TestThing()
        {
            Sub = new SubThing();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string Group { get; set; }
        public decimal Value { get; set; }
        public double Additional { get; set; }
        public SubThing Sub { get; set; }

        public virtual List<ChildThing> Children { get; set; }
    }

    public class DerivedThing : TestThing
    {
        [Display(Name = "Property on Derived Class")]
        public int DerivedProp { get; set; }
    }

    public class OtherThing : TestThing
    {
        public int Other { get; set; }
    }

    public class ThingDbContext : DbContext
    {
        public ThingDbContext()
        {
            Database.SetInitializer<ThingDbContext>(new CreateDatabaseIfNotExists<ThingDbContext>());
        }

        public DbSet<TestThing> Things { get; set; }

        public System.Data.Entity.DbSet<Peon.Web.Models.ChildThing> ChildThings { get; set; }
    }
}