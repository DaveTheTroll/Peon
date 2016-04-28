using System;
using Peon.Maps;

namespace Peon.Game
{
    public interface IDriverList
    {
        void Add(Driver driver);
    }

    public class BaseStation : ILocated
    {
        public int ID { get; set; }
        public LatLong Location { get; set; }
        public string Name { get; set; }

        public virtual bool Update(DateTime now, IDriverList drivers) { return false; }
    }

    public class SpawnerStation : BaseStation
    {
        public SpawnerStation()
        {
            SpawnRate = TimeSpan.FromSeconds(20);
            LastUpdate = DateTime.Now;
        }
        
        public LatLong Destination { get; set; }
        public TimeSpan SpawnRate { get; set; }

        public DateTime LastUpdate { get; set; }

        public override bool Update(DateTime now, IDriverList drivers)
        {
            Random rnd = new Random();
            int i = 0;
            
            TimeSpan next = TimeSpan.FromSeconds(SpawnRate.TotalSeconds * (float)(-Math.Log(rnd.NextDouble())));
            while (next < now - LastUpdate)
            {
                LastUpdate += next;

                Driver driver =
                    new Driver()
                    {
                        Location = Location,
                        Name = "Spawned [" + next.TotalSeconds.ToString() + "]" + (i++).ToString(),
                        Destination = Destination,
                        LastUpdate = LastUpdate
                    };
                driver.GenerateDirections();
                drivers.Add(driver);

                next = TimeSpan.FromSeconds(SpawnRate.TotalSeconds * (float)(-Math.Log(rnd.NextDouble())));
            }

            LastUpdate = now;
            // n.b. Due to the nature of the Poisson distribution exiting and not storing the time of
            // the next event will not change the nature of the distribution.  Knowing that the next
            // event is "not yet" is sufficient.

            return true;
        }
    }
}
