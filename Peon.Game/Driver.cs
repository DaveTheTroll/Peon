using Peon.Maps;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Peon.Game
{
    public class Driver : ILocated
    {
        public Driver()
        {
            Route = new List<RouteStep>();
        }

        public int ID { get; set; }
        public LatLong Location { get; set; }
        public string Name { get; set; }
        
        public LatLong Destination { get; set; }

        public DateTime LastUpdate { get; set; }
        public virtual List<RouteStep> Route { get; set; }

        public bool Update(DateTime now)
        {
            bool changed = false;
            while(Route.Count > 0 && Route[0].Duration < now - LastUpdate)
            {
                LastUpdate += Route[0].Duration;
                Location = Route[0].End;
                Route.RemoveAt(0);
                changed = true;
            }

            if (Route.Count > 0)
            {
                double fraction = (now - LastUpdate).TotalSeconds / Route[0].Duration.TotalSeconds;
                Location = Route[0].Polyline.GetList().ProportionalLocation(fraction);
            }

            return changed;
        }
    }

    public class RouteStep
    {
        public int ID { get; set; }
        public LatLong Start { get; set; }
        public LatLong End { get; set; }
        public float Distance { get; set; }
        public TimeSpan Duration { get; set; }
        
        public Polyline Polyline { get; set; }
    }
}
