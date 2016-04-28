using Newtonsoft.Json;
using System;

namespace Peon.Maps
{
    public class Place
    { }

    public class LatLong : Place
    {
        public LatLong() : this(0, 0) { }
        public LatLong(double latitute, double longitude)
        {
            this.Latitude = latitute;
            this.Longitude = longitude;
        }

        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lng")]
        public double Longitude { get; set; }

        public override string ToString() { return string.Format("{0},{1}", Latitude, Longitude); }

        // http://www.movable-type.co.uk/scripts/latlong.html
        public static double ApproxDistanceBetween(LatLong first, LatLong second)
        {
            const double radiusOfEarth = 6371000;
            double aLatRad = first.Latitude * Math.PI / 180;
            double bLatRad = second.Latitude * Math.PI / 180;
            double dLatRad = (((second.Latitude - first.Latitude + 180) % 360) - 180) * Math.PI / 180;
            double dLngRad = (((second.Longitude - first.Longitude + 180) % 360) - 180) * Math.PI / 180;

            double sinLatDelta = Math.Sin(dLatRad / 2);
            double sinLngDelta = Math.Sin(dLngRad / 2);
            double a = sinLatDelta * sinLatDelta +
                Math.Cos(aLatRad) * Math.Cos(bLatRad) *
                sinLngDelta * sinLngDelta;
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return radiusOfEarth * c;
        }       
    }

    public class NamedPlace : Place
    {
        public NamedPlace(string name) { this.Name = name; }

        public string Name { get; set; }
        public override string ToString() { return Name; }
    }
}
