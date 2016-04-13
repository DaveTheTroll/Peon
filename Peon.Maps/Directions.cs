using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Peon.Maps
{
    // https://developers.google.com/maps/documentation/directions/intro
    
    public class GeocodedWaypoint
    {
        [JsonProperty("geocoder_status")]
        public string Status { get; set; }
        [JsonProperty("place_id")]
        public string PlaceId { get; set; }
        public List<string> Types { get; set; }
    }

    public class TextValuePair
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString() { return Text; }
    }

    public class Section
    {
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public TextValuePair Distance { get; set; }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public TextValuePair Duration { get; set; }
        [JsonProperty("end_location")]
        public LatLong EndLocation { get; set; }
        [JsonProperty("start_location")]
        public LatLong StartLocation { get; set; }
    }

    public class Polyline
    {
        public string Points { get; set; }
    }

    public class Step : Section
    {
        [JsonProperty("html_instructions")]
        public string Instructions { get; set; }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Polyline Polyline { get; set; }
        [JsonProperty("travel_mode")]
        public string TravelMode { get; set; }
        public string Maneuver { get; set; }
    }

    public class Leg : Section
    {
        [JsonProperty("end_address")]
        public string EndAddress { get; set; }
        [JsonProperty("start_address")]
        public string StartAddress { get; set; }

        public List<Step> Steps { get; set; }
        [JsonProperty("via_waypoints")]
        public List<object> ViaWaypoint { get; set; }   // TODO
    }

    public class Route
    {
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Rectangle Bounds { get; set; }
        public string Copyrights { get; set; }
        public List<Leg> Legs { get; set; }
        [JsonProperty("overview_polyline"), TypeConverter(typeof(ExpandableObjectConverter))]
        public Polyline OverviewPolyline { get; set; }
        public string Summary { get; set; }
        public List<string> Warnings { get; set; }
        [JsonProperty("waypoint_order")]
        public List<object> WaypointOrder { get; set; }   // TODO

        public override string ToString() { return Summary; }
    }

    public class DirectionsResponse
    {
        public static DirectionsResponse Get(DirectionsRequest request) { return GoogleAPI.Get<DirectionsResponse>(request); }
        public static DirectionsResponse Get(Place origin, Place destination) { return Get(new DirectionsRequest(origin, destination)); }
        public static DirectionsResponse Get(string origin, string destination) { return Get(new NamedPlace(origin), new NamedPlace(destination)); }

        [JsonProperty("geocoded_waypoints")]
        public List<GeocodedWaypoint> Waypoints { get; set; }
        public List<Route> Routes { get; set; }
        public string Status { get; set; }
    }

    public class DirectionsRequest : IGoogleAPIRequest
    {
        public DirectionsRequest(Place origin, Place destination)
        {
            this.Origin = origin;
            this.Destination = destination;
        }

        public Place Origin { get; set; }
        public Place Destination { get; set; }

        public string URL
        {
            get
            {
                return string.Format("https://maps.googleapis.com/maps/api/directions/json?origin={0}&destination={1}&key={2}", Origin, Destination, GoogleAPI.serverKey);
            }
        }
    }
}
