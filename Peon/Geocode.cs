using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Peon.Maps
{
    public class AddressComponent
    {
        [JsonProperty("long_name")]
        public string LongName { get; set; }
        [JsonProperty("short_name")]
        public string ShortName { get; set; }
        [JsonProperty("types")]
        public List<string> Types { get; set; }

        public override string ToString() { return LongName; }
    }

    public class Rectangle
    {
        [JsonProperty("northeast"), TypeConverter(typeof(ExpandableObjectConverter))]
        public LatLong NorthEast { get; set; }
        [JsonProperty("southwest"), TypeConverter(typeof(ExpandableObjectConverter))]
        public LatLong SouthWest { get; set; }

        public LatLong NorthWest { get { return new LatLong(NorthEast.Latitude, SouthWest.Longitude); } }
        public LatLong SouthEast { get { return new LatLong(SouthWest.Latitude, NorthEast.Longitude); } }


        public override string ToString() { return string.Format("{0} - {1}", NorthEast, SouthWest); }
    }
    
    public class Geometry
    {
        [JsonProperty("bounds"), TypeConverter(typeof(ExpandableObjectConverter))]
        public Rectangle Bounds { get; set; }
        [JsonProperty("location"), TypeConverter(typeof(ExpandableObjectConverter))]
        public LatLong Location { get; set; }
        [JsonProperty("location_type")]
        public string LocationType { get; set; }
        [JsonProperty("viewport"), TypeConverter(typeof(ExpandableObjectConverter))]
        public Rectangle ViewPort { get; set; }
    }

    public class Geocode
    {
        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }
        [JsonProperty("address_components")]
        public List<AddressComponent> AddressComponents { get; set; }
        [JsonProperty("geometry"), TypeConverter(typeof(ExpandableObjectConverter))]
        public Geometry Geometry { get; set; }
        [JsonProperty("place_id")]
        public string PlaceId { get; set; }
        [JsonProperty("types")]
        public List<string> Types { get; set; }
    }
    
    public class GeocodeResponse
    {
        public static GeocodeResponse Get(GeocodeRequest request) { return GoogleAPI.Get<GeocodeResponse>(request); }
        public static GeocodeResponse Get(Place place) { return GoogleAPI.Get<GeocodeResponse>(new GeocodeRequest(place)); }
        public static GeocodeResponse Get(string address) { return Get(new NamedPlace(address)); }

        [JsonProperty("results")]
        public List<Geocode> Results { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class GeocodeRequest : IGoogleAPIRequest
    {
        public GeocodeRequest(Place address) { this.Address = address; }

        public Place Address { get; set; }

        public string URL { get { return string.Format(@"https://maps.googleapis.com/maps/api/geocode/json?address={0}&key={1}", Address, GoogleAPI.serverKey); } }
    }
}
