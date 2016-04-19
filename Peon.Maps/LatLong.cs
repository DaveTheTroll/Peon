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
    }

    public class NamedPlace : Place
    {
        public NamedPlace(string name) { this.Name = name; }

        public string Name { get; set; }
        public override string ToString() { return Name; }
    }
}
