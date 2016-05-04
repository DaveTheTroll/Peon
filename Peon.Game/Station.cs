using System;
using System.Collections.Generic;
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

    public class RouteSpec
    {
        public RouteSpec(LatLong source, LatLong destination)
        {
            Source = source;
            Destination = destination;
        }

        public LatLong Source { get; set; }
        public LatLong Destination { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is RouteSpec)
            {
                RouteSpec rs = (RouteSpec)obj;
                return Source.Equals(rs.Source) && Destination.Equals(rs.Destination);
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            return Source.GetHashCode() ^ Destination.GetHashCode();
        }
    }

    public static class CalculcatedRoutes
    {
        static CalculcatedRoutes()
        {
            RouteTimeout = TimeSpan.FromMinutes(5);
        }

        static Dictionary<RouteSpec, Tuple<List<RouteStep>, DateTime>> routes = new Dictionary<RouteSpec, Tuple<List<RouteStep>, DateTime>>();

        public static TimeSpan RouteTimeout { get; set; }
        public static List<RouteStep> Get(LatLong source, LatLong destination, bool store)
        {
            return Get(new RouteSpec(source, destination), store);
        }
        public static List<RouteStep> Get(RouteSpec spec, bool store)
        {
            bool generate = false;
            if (routes.ContainsKey(spec))
            {
                if (DateTime.Now - routes[spec].Item2 > RouteTimeout)
                    generate = true;
            }
            else
                generate = true;

            if (generate)
            {
                List<RouteStep> route = new List<RouteStep>();
                DirectionsResponse directions = DirectionsResponse.Get(spec.Source, spec.Destination);
                if (directions.Routes.Count > 0)
                {
                    // TODO: Consider equivalent Linq
                    foreach (Leg leg in directions.Routes[0].Legs)
                        foreach (Step step in leg.Steps)
                        {
                            route.Add(new RouteStep()
                            {
                                Start = step.StartLocation,
                                End = step.EndLocation,
                                Distance = step.Distance.Value,
                                Duration = TimeSpan.FromSeconds(step.Duration.Value),
                                Polyline = step.Polyline
                            });
                        }
                    routes[spec] = new Tuple<List<RouteStep>, DateTime>(route, DateTime.Now);
                }
                return new List<RouteStep>(route);
            }

            return new List<RouteStep>(routes[spec].Item1);

            // Return copy of route, as the list is modified by the things that use it.
        }
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
            
            TimeSpan next = TimeSpan.FromSeconds(SpawnRate.TotalSeconds * (float)(-Math.Log(rnd.NextDouble())));
            int added = 0;
            while (next < now - LastUpdate && added < 5)
            {
                LastUpdate += next;

                Driver driver =
                    new Driver()
                    {
                        Location = Location,
                        Name = "Spawned [" + next.TotalSeconds.ToString() + "]" + added.ToString(),
                        Destination = Destination,
                        LastUpdate = LastUpdate,
                        Route = CalculcatedRoutes.Get(Location, Destination, true)
                    };
                
                drivers.Add(driver);

                added++;

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
