using System.Data.Entity;

namespace Peon.Web.Models
{
    public class PeonDbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PeonDbContext() : base("name=PeonDbContext")
        {
        }

        public System.Data.Entity.DbSet<Peon.Game.BaseStation> BaseStations { get; set; }

        public System.Data.Entity.DbSet<Peon.Game.Driver> Drivers { get; set; }
    }
}
